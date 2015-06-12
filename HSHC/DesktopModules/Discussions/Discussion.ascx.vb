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

    Public MustInherit Class Discussion
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents lstDiscussions As System.Web.UI.WebControls.DataList
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel

        Private itemIndex As Integer

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            MyBase.Actions.Add(GetNextActionID, "Add New Thread", "", URL:=EditURL(), secure:=SecurityAccessLevel.Edit, Visible:=True)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try

                If Not (Request.Params("ItemIndex") Is Nothing) Then
                    itemIndex = Int32.Parse(Request.Params("ItemIndex"))
                Else
                    itemIndex = Convert.ToInt32(Null.SetNull(itemIndex))
                End If

                If Page.IsPostBack = False Then
                    BindList()

                    If Not Null.IsNull(itemIndex) Then
                        lstDiscussions.SelectedIndex = itemIndex
                        BindList()
                    End If
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Sub BindList()
            Try
                ' Obtain a list of discussion messages for the module
                ' and bind to datalist
                Dim objDiscussionController As New DiscussionController

                lstDiscussions.DataSource = objDiscussionController.GetTopLevelMessages(ModuleId)
                lstDiscussions.DataBind()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Function GetThreadMessages() As ArrayList
            Try
                ' Obtain a list of discussion messages for the module
                Dim objDiscussionController As New DiscussionController
                Dim arrDiscussionMessages As ArrayList = objDiscussionController.GetThreadMessages(Convert.ToString(lstDiscussions.DataKeys(lstDiscussions.SelectedIndex)))

                ' Return the filtered DataView
                Return arrDiscussionMessages
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub lstDiscussions_Select(ByVal Sender As Object, ByVal e As DataListCommandEventArgs) Handles lstDiscussions.ItemCommand
            Try
                ' Determine the command of the button (either "select" or "collapse")
                Dim command As String = CType(e.CommandSource, ImageButton).CommandName

                ' Update asp:datalist selection index depending upon the type of command
                ' and then rebind the asp:datalist with content
                If command = "collapse" Then
                    lstDiscussions.SelectedIndex = -1
                Else
                    lstDiscussions.SelectedIndex = e.Item.ItemIndex
                End If

                BindList()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Function NodeImage(ByVal count As Integer) As String
            Try
                If count > 0 Then
                    Return "~/images/plus.gif"
                Else
                    Return "~/images/minus.gif"
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function FormatUser(ByVal CreatedByUser As String) As String
            Try
                If Not Null.IsNull(CreatedByUser) Then
                    Return CreatedByUser
                Else
                    Return "Anonymous"
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function FormatMultiLine(ByVal strValue As String) As String
            Try
                Return (New PortalSecurity).InputFilter(strValue, PortalSecurity.FilterFlag.MultiLine)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function IndentChild(ByVal Indent As Integer) As String
            Try
                Dim strIndent As String
                Dim intCounter As Integer

                For intCounter = 1 To Indent
                    strIndent += "&nbsp;"
                Next

                Return strIndent
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

    End Class

End Namespace
