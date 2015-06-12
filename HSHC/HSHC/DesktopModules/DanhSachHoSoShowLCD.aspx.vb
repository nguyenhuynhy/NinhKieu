Imports PortalQH
Imports System.Configuration

Namespace HSHC

    Public Class DanhSachHoSoShowLCD
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents dtlDSHoSoKhongGiaiQuyet As System.Web.UI.WebControls.DataList
        Protected WithEvents dtlDSHoSoBoSung As System.Web.UI.WebControls.DataList
        Protected WithEvents dtlDSHoSoTraKetQua As System.Web.UI.WebControls.DataList

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

            Dim objTiepNhan As New TiepNhanHoSoController
            Dim ds As New DataSet

            ds = objTiepNhan.DSHoSoShowLCD()

            If Not ds Is Nothing And ds.Tables.Count > 0 Then
                'Hien thi du lieu ho so khong giai quyet
                dtlDSHoSoKhongGiaiQuyet.DataSource = ds.Tables(0)
                dtlDSHoSoKhongGiaiQuyet.DataBind()

                'Hien thi du lieu ho so bo sung
                dtlDSHoSoBoSung.DataSource = ds.Tables(1)
                dtlDSHoSoBoSung.DataBind()

                'Hien thi du lieu ho so tra ket qua cho dan
                dtlDSHoSoTraKetQua.DataSource = ds.Tables(2)
                dtlDSHoSoTraKetQua.DataBind()
            End If

            objTiepNhan = Nothing
            ds = Nothing

        End Sub

    End Class

End Namespace