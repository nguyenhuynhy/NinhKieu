'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Shaun Walker ( sales@perpetualmotion.ca ) of Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Namespace PortalQH

    Public Class DiscussDetails
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents cmdReply As System.Web.UI.WebControls.LinkButton
        Protected WithEvents TitleField As System.Web.UI.WebControls.TextBox
        Protected WithEvents BodyField As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents EditPanel As System.Web.UI.WebControls.Panel
        Protected WithEvents Subject As System.Web.UI.WebControls.Label
        Protected WithEvents CreatedByUser As System.Web.UI.WebControls.Label
        Protected WithEvents CreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents Body As System.Web.UI.WebControls.Label
        Protected WithEvents cmdCancel2 As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdEdit As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents tblOriginalMessage As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents rowOriginalMessage As System.Web.UI.HtmlControls.HtmlTableRow

        Private itemId As Integer
        Protected WithEvents valTitleField As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valBodyField As System.Web.UI.WebControls.RequiredFieldValidator
        Private itemIndex As Integer

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not (Request.Params("ItemIndex") Is Nothing) Then
                    itemIndex = Int32.Parse(Request.Params("ItemIndex"))
                Else
                    itemIndex = Convert.ToInt32(Null.SetNull(itemIndex))
                End If

                If Not (Request.Params("ItemId") Is Nothing) Then
                    itemId = Int32.Parse(Request.Params("ItemId"))
                Else
                    itemId = Convert.ToInt32(Null.SetNull(itemId))
                End If

                ' Populate message contents if this is the first visit to the page
                If Page.IsPostBack = False Then

                    If Not PortalSecurity.IsInRoles(PortalSettings.AdministratorRoleId.ToString) Then
                        cmdEdit.Visible = False
                        cmdDelete.Visible = False
                    Else
                        cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")
                    End If

                    If Not Null.IsNull(itemId) Then
                        ' Obtain the selected item from the Discussion table
                        Dim objDiscussionController As New DiscussionController
                        Dim objDiscussionMessageInfo As DiscussionInfo = objDiscussionController.GetMessage(itemId, ModuleId)

                        ' Load row from database
                        If Not objDiscussionMessageInfo Is Nothing Then
                            Dim objSecurity As New PortalSecurity
                            Subject.Text = objSecurity.InputFilter(objDiscussionMessageInfo.Title, PortalSecurity.FilterFlag.MultiLine)
                            Body.Text = objSecurity.InputFilter(objDiscussionMessageInfo.Body, PortalSecurity.FilterFlag.MultiLine)
                            CreatedByUser.Text = objDiscussionMessageInfo.CreatedByUser
                            CreatedDate.Text = String.Format("{0:d}", objDiscussionMessageInfo.CreatedDate)
                            If (objDiscussionMessageInfo.DisplayOrder.Length = 19) Then
                                TitleField.Text = objDiscussionMessageInfo.Title
                            Else
                                TitleField.Text = ReTitle(objDiscussionMessageInfo.Title)
                            End If

                            BodyField.Text = objDiscussionMessageInfo.Body
                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If
                    Else
                        EditPanel.Visible = True
                        cmdReply.Visible = False
                        cmdUpdate.Text = "Save"
                        tblOriginalMessage.Visible = False
                    End If

                End If

                If PortalSecurity.HasEditPermissions(ModuleId) = False Then

                    If Null.IsNull(itemId) Then
                        Response.Redirect(NavigateURL(), True)
                    Else
                        cmdReply.Visible = False
                    End If

                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdReply_Click(ByVal Sender As Object, ByVal e As EventArgs) Handles cmdReply.Click
            Try
                BodyField.Text = ""
                EditPanel.Visible = True
                rowOriginalMessage.Visible = True
                cmdReply.Visible = False
                cmdCancel2.Visible = False
                cmdEdit.Visible = False
                cmdDelete.Visible = False
                cmdUpdate.Text = "Save"
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try

                Dim objDiscussion As New DiscussionInfo

                objDiscussion = CType(CBO.InitializeObject(objDiscussion, GetType(DiscussionInfo)), DiscussionInfo)

                objDiscussion.ItemID = itemId
                objDiscussion.ModuleID = ModuleId
                objDiscussion.Title = Replace(Server.HtmlEncode(TitleField.Text), vbCrLf, "<br>")
                objDiscussion.Body = Replace(Server.HtmlEncode(BodyField.Text), vbCrLf, "<br>")
                If Not Context.User.Identity.Name Is Nothing Then
                    objDiscussion.CreatedByUser = Context.User.Identity.Name
                End If
                If cmdUpdate.Text = "Save" And Not Null.IsNull(itemId) Then
                    objDiscussion.ParentID = itemId
                End If

                ' Create new discussion database component
                Dim objDiscussionController As New DiscussionController

                If cmdUpdate.Text = "Update" Then
                    objDiscussionController.UpdateMessage(objDiscussion)
                Else
                    objDiscussionController.AddMessage(objDiscussion)
                End If

                Response.Redirect(NavigateURL() & Convert.ToString(IIf(itemIndex <> -1, "&ItemIndex=" & itemIndex, "")), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click, cmdCancel2.Click
            Try
                If (Null.IsNull(itemIndex)) Then
                    Response.Redirect(NavigateURL(), True)
                Else
                    Response.Redirect(NavigateURL() & "&ItemIndex=" & Convert.ToString(itemIndex), True)
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Function ReTitle(ByVal title As String) As String
            Try
                If title.Length > 0 And title.IndexOf("Re: ", 0) = -1 Then
                    title = "Re: " & title
                End If

                Return title
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try
                ' Create new discussion database component
                Dim objDiscussionController As New DiscussionController
                objDiscussionController.DeleteMessage(itemId, ModuleId)

                If (Null.IsNull(itemIndex)) Then
                    Response.Redirect(NavigateURL(), True)
                Else
                    Response.Redirect(NavigateURL() & "&ItemIndex=" & Convert.ToString(itemIndex), True)
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
            Try
                EditPanel.Visible = True
                rowOriginalMessage.Visible = True
                cmdReply.Visible = False
                cmdCancel2.Visible = False
                cmdEdit.Visible = False
                cmdDelete.Visible = False
                cmdUpdate.Text = "Update"
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
