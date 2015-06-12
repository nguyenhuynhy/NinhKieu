'
' DotNetNuke -  http://www.dotnetnuke.com
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

    Public MustInherit Class Links
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents pnlList As System.Web.UI.WebControls.Panel
        Protected WithEvents lstLinks As System.Web.UI.WebControls.DataList
        Protected WithEvents pnlDropdown As System.Web.UI.WebControls.Panel
        Protected WithEvents cboLinks As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdEdit As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdInfo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdGo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel
        Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
        Protected WithEvents tdNoiDung As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents tdEdit As System.Web.UI.HtmlControls.HtmlTableCell

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            MyBase.Actions.Add(GetNextActionID, "View Options", "", URL:=EditURL(, , "ViewOptions"), secure:=SecurityAccessLevel.Edit, Visible:=True)
            MyBase.Actions.Add(GetNextActionID, "Add Link", "", URL:=EditURL(), secure:=SecurityAccessLevel.Edit, Visible:=True)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not Page.IsPostBack Then

                    Dim objLinks As New LinkController

                    If CType(Settings("linkcontrol"), String) = "D" Then
                        pnlDropdown.Visible = True
                        pnlList.Visible = False
                        If IsEditable Then
                            cmdEdit.Visible = True
                        Else
                            cmdEdit.Visible = False
                        End If
                        cmdGo.ToolTip = "Go"
                        If CType(Settings("displayinfo"), String) = "Y" Then
                            cmdInfo.Visible = True
                        Else
                            cmdInfo.Visible = False
                        End If
                        cmdInfo.ToolTip = "View Link Description"
                        cboLinks.DataSource = objLinks.GetLinks(ModuleId)
                        cboLinks.DataBind()
                    Else
                        pnlList.Visible = True
                        pnlDropdown.Visible = False
                        If CType(Settings("linkview"), String) = "H" Then
                            lstLinks.RepeatDirection = RepeatDirection.Horizontal
                        Else
                            lstLinks.RepeatDirection = RepeatDirection.Vertical
                        End If
                        lstLinks.DataSource = objLinks.GetLinks(ModuleId)
                        lstLinks.DataBind()
                    End If
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Function FormatURL(ByVal Link As String, ByVal ID As Integer) As String
            Try
                If InStr(1, Link, "://") = 0 Then
                    If IsNumeric(Link) Then ' internal tab link
                        Link = CType(IIf(Global.ApplicationPath = "/", Global.ApplicationPath, Global.ApplicationPath & "/"), String) & "Default.aspx?tabid=" & Link
                    End If
                End If
                Return Link
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdEdit.Click
            Try
                Response.Redirect(EditURL("ItemID", cboLinks.SelectedItem.Value), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Function DisplayInfo() As String
            Try
                If CType(Settings("displayinfo"), String) = "Y" Then
                    Return "True"
                Else
                    Return "False"
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function DisplayToolTip(ByVal strDescription As String) As String
            Try
                If CType(Settings("displayinfo"), String) = "N" Then
                    Return strDescription
                Else
                    Return ""
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function HtmlDecode(ByVal strValue As String) As String
            Try
                HtmlDecode = Server.HtmlDecode(strValue)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub lstLinks_Select(ByVal Sender As Object, ByVal e As DataListCommandEventArgs) Handles lstLinks.ItemCommand
            Try
                lstLinks.Items(e.Item.ItemIndex).FindControl("pnlDescription").Visible = True
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub cmdInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdInfo.Click
            Try
                Dim objLinks As New LinkController

                Dim objLink As LinkInfo = objLinks.GetLink(Integer.Parse(cboLinks.SelectedItem.Value), ModuleId)
                If Not objLink Is Nothing Then
                    lblDescription.Text = HtmlDecode(objLink.Description.ToString)
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGo.Click
            Try
                Dim strURL As String = ""

                Dim objLinks As New LinkController

                Dim objLink As LinkInfo = objLinks.GetLink(Integer.Parse(cboLinks.SelectedItem.Value), ModuleId)
                If Not objLink Is Nothing Then
                    strURL = FormatURL(objLink.Url.ToString, Integer.Parse(cboLinks.SelectedItem.Value))
                End If

                'use javascript to open a new window if the combobox link style is used
                If Not objLink Is Nothing Then
                    If objLink.NewWindow = True Then
                        Response.Write("<script language=javascript>window.open('" + strURL + "','_new')</script>")
                    Else
                        Response.Redirect(strURL, True)
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
