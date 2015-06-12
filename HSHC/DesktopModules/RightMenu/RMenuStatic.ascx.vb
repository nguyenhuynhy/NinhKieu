Imports PortalQH
Imports HSHC
Imports System.Configuration
Imports System.IO
Imports System.Web.UI.WebControls
Namespace PortalQH
    Public Class RMenuStatic
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Img2 As System.Web.UI.WebControls.Image
        Protected WithEvents img1 As System.Web.UI.WebControls.Image
        Protected WithEvents lblContent1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblContent2 As System.Web.UI.WebControls.Label
        Protected WithEvents tdTitle As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents tr1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents tr2 As System.Web.UI.HtmlControls.HtmlTableRow

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            MyBase.Actions.Add(GetNextActionID, "Edit", "", URL:=EditURL(), secure:=SecurityAccessLevel.Edit, Visible:=True)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here            
            ' Neu imgName1=""
            ' Neu noi dung ="" : Khong hien thi ca hinh va menu 1
            ' Noi dung <>"" Khiong hien thi hinh anh ma chi hien thi noi dung
            ' Neu chi co hinh anh ma khong co noi dung thi hien thi hinh anh thoi
            If CType(Settings("imgName"), String) = "" Then
                If CType(Settings("NoiDung"), String) = "" Then
                    ' khong hein thi tr1
                    tr1.Visible = False
                Else
                    'Hien thi tr1 va dong thoi gan noi dung vao text box lblContent1
                    tr1.Visible = True
                    lblContent1.Text = CType(Settings("NoiDung"), String)
                End If
            Else
                tr1.Visible = True
                Showimage()
            End If
            ' tuong tu nhu vay cho img2
            If CType(IIf(Settings("imgName2") Is DBNull.Value, "", Settings("imgName2")), String) = "" Then
                If CType(Settings("NoiDung2"), String) = "" Then
                    ' khong hein thi tr1
                    tr2.Visible = False
                Else
                    'Hien thi tr1 va dong thoi gan noi dung vao text box lblContent1
                    tr2.Visible = True
                    lblContent2.Text = CType(Settings("NoiDung2"), String)
                End If
            Else
                tr2.Visible = True
                Showimage()
            End If


                
        End Sub
        Private Sub Showimage()
            Try
                Dim imageSrc1 As String = "" ' = CType(Settings("imgSrc"), String)
                Dim imageName1 As String = CType(Settings("imgName"), String)
                If imageName1 <> "" Then
                    imageSrc1 = Global.ApplicationPath & "/" & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder") & imageName1
                    img1.ImageUrl = imageSrc1
                    If CType(Settings("Chieurong"), String) <> "" Then
                        img1.Width = Unit.Pixel(CType(Settings("Chieurong"), Integer))
                    Else
                        img1.Width = Unit.Pixel(CType(ConfigurationSettings.AppSettings("ImgWidth"), Integer))
                    End If

                    If CType(Settings("ChieuCao"), String) <> "" Then
                        img1.Height = Unit.Pixel(CType(Settings("ChieuCao"), Integer))
                    Else
                        img1.Width = Unit.Pixel(CType(ConfigurationSettings.AppSettings("ImgHeight"), Integer))
                    End If
                Else
                    img1.Visible = False
                End If
                lblContent1.Text = CType(Settings("NoiDung"), String)
                'lblTitle.Text = CType(Settings("TieuDe"), String)
                tdTitle.InnerText = CType(Settings("TieuDe"), String)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
    End Class
End Namespace