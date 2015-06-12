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
Imports System.IO

Namespace PortalQH

    Public Class SkinControl
        Inherits System.Web.UI.UserControl

        Protected WithEvents cboSkin As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdPreview As System.Web.UI.WebControls.LinkButton

        Private _Width As String = ""
        Private _SkinRoot As String
        Private _SkinType As String
        Private _SkinName As String
        Private _SkinSrc As String

        ' public properties
        Public Property Width() As String
            Get
                Width = Convert.ToString(ViewState("SkinControlWidth"))
            End Get
            Set(ByVal Value As String)
                _Width = Value
            End Set
        End Property

        Public Property SkinRoot() As String
            Get
                SkinRoot = Convert.ToString(ViewState("SkinRoot"))
            End Get
            Set(ByVal Value As String)
                _SkinRoot = Value
            End Set
        End Property

        Public Property SkinType() As String
            Get
                If Not cboSkin.SelectedItem Is Nothing Then
                    SkinType = Split(cboSkin.SelectedItem.Value, "|")(0)
                Else
                    SkinType = ""
                End If
            End Get
            Set(ByVal Value As String)
                _SkinType = Value
            End Set
        End Property

        Public Property SkinName() As String
            Get
                If Not cboSkin.SelectedItem Is Nothing Then
                    SkinName = Split(cboSkin.SelectedItem.Value, "|")(1)
                Else
                    SkinName = ""
                End If
            End Get
            Set(ByVal Value As String)
                _SkinName = Value
            End Set
        End Property

        Public Property SkinSrc() As String
            Get
                If Not cboSkin.SelectedItem Is Nothing Then
                    SkinSrc = Split(cboSkin.SelectedItem.Value, "|")(2)
                Else
                    SkinSrc = ""
                End If
            End Get
            Set(ByVal Value As String)
                _SkinSrc = Value
            End Set
        End Property


#Region " Web Form Designer Generated Code "


        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '*******************************************************
        '
        ' The Page_Load server event handler on this page is used
        ' to populate the role information for the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim strRoot As String
                Dim strFolder As String
                Dim arrFolders As String()
                Dim strFile As String
                Dim arrFiles As String()

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If Not Page.IsPostBack Then

                    ' set width of control
                    If _Width <> "" Then
                        cboSkin.Width = System.Web.UI.WebControls.Unit.Parse(_Width)
                    End If

                    ' default value
                    cboSkin.Items.Insert(0, New ListItem("<Not Specified>", "||"))

                    ' load host skins
                    strRoot = Request.MapPath(Global.HostPath & _SkinRoot)
                    If Directory.Exists(strRoot) Then
                        arrFolders = Directory.GetDirectories(strRoot)
                        For Each strFolder In arrFolders
                            arrFiles = Directory.GetFiles(strFolder, "*.ascx")
                            For Each strFile In arrFiles
                                strFolder = Mid(strFolder, InStrRev(strFolder, "\") + 1)
                                If strFolder <> "_default" Then
                                    cboSkin.Items.Add(New ListItem(strFolder & " - " & Path.GetFileNameWithoutExtension(strFile), "G|" & strFolder & "|" & Path.GetFileName(strFile)))
                                End If
                            Next
                        Next
                    End If

                    ' load portal skins
                    strRoot = Request.MapPath(_portalSettings.UploadDirectory & _SkinRoot)
                    If Directory.Exists(strRoot) Then
                        arrFolders = Directory.GetDirectories(strRoot)
                        For Each strFolder In arrFolders
                            arrFiles = Directory.GetFiles(strFolder, "*.ascx")
                            For Each strFile In arrFiles
                                strFolder = Mid(strFolder, InStrRev(strFolder, "\") + 1)
                                cboSkin.Items.Add(New ListItem(strFolder & " - " & Path.GetFileNameWithoutExtension(strFile), "L|" & strFolder & "|" & Path.GetFileName(strFile)))
                            Next
                        Next
                    End If

                    ' select current skin
                    Dim intIndex As Integer
                    For intIndex = 0 To cboSkin.Items.Count - 1
                        If cboSkin.Items(intIndex).Value = (_SkinType & "|" & _SkinName & "|" & _SkinSrc) Then
                            cboSkin.Items(intIndex).Selected = True
                        End If
                    Next

                    ' save persistent values
                    ViewState("SkinControlWidth") = _Width
                    ViewState("SkinRoot") = _SkinRoot

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPreview.Click

            If SkinType <> "" Then

                Dim strType As String = SkinRoot.Substring(0, SkinRoot.Length - 1)

                Dim strURL As String = AddHTTP(GetDomainName(Request)) & ApplicationURL.Replace("~", "")
                strURL += "&" & strType & "Type=" & SkinType
                strURL += "&" & strType & "Name=" & SkinName
                strURL += "&" & strType & "Src=" & SkinSrc

                If SkinRoot = SkinInfo.RootContainer Then
                    If Not Request.Params("ModuleId") Is Nothing Then
                        strURL += "&ModuleId=" & Request.Params("ModuleId").ToString
                    End If
                End If

                Response.Write("<script>window.open('" & strURL & "','_new')</script>")
            End If

        End Sub

    End Class

End Namespace
