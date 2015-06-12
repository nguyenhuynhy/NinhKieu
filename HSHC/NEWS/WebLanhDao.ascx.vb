Option Strict Off
Imports PortalQH
Imports System.Configuration
Public Class WebLanhDao
    Inherits PortalQH.PortalModuleControl
    Dim objLanhDao As LanhDaoController
    Protected WithEvents DltTinTuc As System.Web.UI.WebControls.DataList
    Protected WithEvents txtNoiDungTim As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnTimNoiDung As System.Web.UI.WebControls.ImageButton
    Protected WithEvents tdCongViec As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdHoiDap As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Table3 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table5 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Dim objControl As Object

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DltHoiDap As System.Web.UI.WebControls.DataList
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents DltCongViec As System.Web.UI.WebControls.DataList
    Protected WithEvents DltLich As System.Web.UI.WebControls.DataList
    Protected WithEvents DltTongHop As System.Web.UI.WebControls.DataList
    Protected WithEvents tdControl As System.Web.UI.HtmlControls.HtmlTableCell

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Session("Mid") = ModuleId.ToString()
        objLanhDao = New LanhDaoController
        InitState()
        LoadAsc()
        SetSelectItem()

    End Sub

    Public Sub LoadAsc()
        Dim iAscx As String
        If Not Request.Params("Cat") Is Nothing Then
            iAscx = ConfigurationSettings.AppSettings(CType(Request.Params("Cat"), String))
        Else
            iAscx = ConfigurationSettings.AppSettings("DefaultCat")
        End If
        
        tdControl.Controls.Add(Page.LoadControl(iAscx))
        objControl = Page.LoadControl(iAscx)
    End Sub

    Public Sub SetSelectItem()
        Dim iSelectIndex As Integer
        Dim iCat As String
        If Not Request.Params("Cat") Is Nothing Then
            iCat = CType(Request.Params("Cat"), String)
        End If
        If Not Request.Params("SelectIndex") Is Nothing Then
            iSelectIndex = CType(Request.Params("SelectIndex"), Integer)
        Else
            iSelectIndex = 0
        End If
        Select Case iCat
            Case "LCT"
                'ap style select for item
                DltLich.SelectedIndex = iSelectIndex
                lblTitle.Text = ".:: Lịch công tác trong ngày::."
            Case "TT"
                'ap style select for item
                'gan select for item
                DltTinTuc.SelectedIndex = iSelectIndex
                lblTitle.Text = ".:: Bản tin nội bộ ::."
            Case Else
                DltTinTuc.SelectedIndex = iSelectIndex
                lblTitle.Text = ".:: Bản tin nội bộ ::."
        End Select
    End Sub

    Public Sub InitState()
        Dim db As String
        db = CType(ConfigurationSettings.AppSettings("db_web"), String)

        DltLich.DataSource = objLanhDao.GetMenuLichTrongNgay(db)
        DltLich.DataBind()

        'DltTongHop.DataSource = objLanhDao.GetMenuTongHop(db)
        'DltTongHop.DataBind()

        'DltCongViec.DataSource = objLanhDao.GetMenuCongViec(db, CType(Session("UserName"), String))
        'DltCongViec.DataBind()

        'DltHoiDap.DataSource = objLanhDao.GetMenuHoiDap(db, CType(Session("UserName"), String))
        'DltHoiDap.DataBind()

        DltTinTuc.DataSource = objLanhDao.GetMenuTinTuc(db)
        DltTinTuc.DataBind()

        'If Session("UserName") Is Nothing Then
        '    tdHoiDap.Visible = False
        '    tdCongViec.Visible = False
        'Else
        '    tdHoiDap.Visible = True
        '    tdCongViec.Visible = True
        'End If
    End Sub

    Public Function GetLink() As String
        Dim TabId As String
        If Not Request.Params("TabID") Is Nothing Then
            TabId = Request.Params("TabID").ToString()
        Else
            TabId = CType(ConfigurationSettings.AppSettings("TabDefault"), String)
        End If
        Return "~/Default.aspx?tabid=" & TabId
    End Function

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        objLanhDao = Nothing
    End Sub

    Private Sub btnTimNoiDung_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTimNoiDung.Click
        Dim iAscx As String
        iAscx = ConfigurationSettings.AppSettings("TT")
        'tdControl.Controls.Add(Page.LoadControl(iAscx))
        objControl = Page.LoadControl(iAscx)
        objControl.TimNoiDung(txtNoiDungTim.Text)
        'Page.Controls.Remove(objControl)
    End Sub
End Class
