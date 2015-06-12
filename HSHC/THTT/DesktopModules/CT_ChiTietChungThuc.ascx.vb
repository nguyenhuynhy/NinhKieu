Option Strict Off
Imports PortalQH
Imports System.Configuration
Imports System
Imports System.Web
Namespace THTT
    Public Class CT_ChiTietChungThuc
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents Image1 As System.Web.UI.WebControls.Image
        Protected WithEvents lblSoChungThuc As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLoaiCT As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayGD As System.Web.UI.WebControls.Label
        Protected WithEvents lblQuyenSo As System.Web.UI.WebControls.Label
        Protected WithEvents lblViecChungThuc As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoBC As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoTo As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoTrang As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenNGuoiKy As System.Web.UI.WebControls.Label
        Protected WithEvents lblGhiChu As System.Web.UI.WebControls.Label
        Protected WithEvents dG As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents datagrid1 As System.Web.UI.WebControls.DataGrid


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
            BindData()
        End Sub

        Public Function BindData()
            Dim objHSCT As New HoSoChungThucController
            Dim ML As String = Request.QueryString("ML")
            Dim CurID As String = Request.QueryString("ID")

            Dim dataSet As System.Data.DataSet = New System.Data.DataSet
            Dim r As DataRow
            dataSet = objHSCT.GetHoSoChungThucChiTiet(ConfigurationSettings.AppSettings("DB_CHUNGTHUC"), CurID, ML)
            For Each r In dataSet.Tables(0).Rows
                Me.lblSoChungThuc.Text = Trim(IIf(IsDBNull(r.Item("SoChungThuc")), "", r.Item("SoChungThuc")))
                Me.lblNgayGD.Text = ShowDate(IIf(IsDBNull(r.Item("NgayGD")), "", r.Item("NgayGD")))
                Me.lblTenLoaiCT.Text = Trim(IIf(IsDBNull(r.Item("TenLoaiCT")), "", r.Item("TenLoaiCT")))
                Me.lblQuyenSo.Text = Trim(IIf(IsDBNull(r.Item("QuyenSo")), "", r.Item("QuyenSo")))
                Me.lblViecChungThuc.Text = Trim(IIf(IsDBNull(r.Item("VIECCHUNGTHUC")), "", r.Item("VIECCHUNGTHUC")))
                Me.lblSoBC.Text = Trim(IIf(IsDBNull(r.Item("SOBC")), "", r.Item("SOBC")))
                Me.lblSoTo.Text = Trim(IIf(IsDBNull(r.Item("SOTO")), "", r.Item("SOTO")))
                Me.lblSoTrang.Text = Trim(IIf(IsDBNull(r.Item("SOTRANG")), "", r.Item("SOTRANG")))
                Me.lblTenNGuoiKy.Text = Trim(IIf(IsDBNull(r.Item("TENNGUOIKY")), "", r.Item("TENNGUOIKY")))
                Me.lblGhiChu.Text = Trim(IIf(IsDBNull(r.Item("GHICHU")), "", r.Item("GHICHU")))
                Exit For
            Next
            'Add data to grid chi tiet

            Dim dataSet2 As System.Data.DataSet = New System.Data.DataSet
            dataSet2 = objHSCT.GetHoSoChungThucChiTiet2(ConfigurationSettings.AppSettings("DB_CHUNGTHUC"), CurID, ML)
            Dim iCount As Long = dataSet2.Tables(0).Rows.Count
            If iCount = 0 Then
                'tell the user search returned no messages"
            End If
            datagrid1.DataSource = dataSet2.Tables(0).DefaultView
            datagrid1.DataBind()
            dataSet2.Dispose()


        End Function


        Function ShowDate(ByVal dDate As String) As String
            Dim tmpDate As String
            If Not IsDate(dDate) Then
                Return ""
            Else
                tmpDate = Right("0" & Day(dDate), 2) & "/" & Right("0" & Month(dDate), 2) & "/" & Year(dDate)
                Return tmpDate
            End If
        End Function
        'Ngay dau tien trong tuan -dDate:ngay hien tai
        Function FirstDateOfWeek(ByVal dDate) As Date
            Dim dt, offset
            offset = Weekday(dDate) - 2
            dt = DateAdd("d", -CInt(offset), dDate)
            FirstDateOfWeek = dt
        End Function

        Function LastDateOfWeek(ByVal dDate) As Date
            Dim dt, offset
            offset = 7 - Weekday(dDate) + 1
            dt = DateAdd("d", offset, dDate)
            LastDateOfWeek = dt
        End Function

        Function FirstDateOfMonth(ByVal dDate)
            Dim dt
            dt = DateSerial(Year(dDate), Month(dDate), 1)
            FirstDateOfMonth = dt
        End Function

        Function LastDateOfMonth(ByVal dDate)
            Dim dt
            dt = DateSerial(Year(dDate), Month(dDate) + 1, 1)
            dt = DateAdd("d", -1, dt)
            LastDateOfMonth = dt
        End Function

        Function FirstDateOfYear(ByVal dDate)
            FirstDateOfYear = "01/01/" & Year(dDate)
        End Function

        Function LastDateOfYear(ByVal dDate)
            LastDateOfYear = "31/12/" & Year(dDate)
        End Function
        Public Function StringToNumber(ByVal Str As String) As String
            Dim result As String
            Dim count As Integer = 0
            Dim remain As String
            Dim addstr As String
            Dim curlen As Integer
            Dim rLen As Integer
            remain = Str
            rLen = Len(Str)

            If rLen <= 0 Then Return ""
            Do While count <= Len(Str)
                count = count + 3
                If Len(remain) < 3 Then
                    addstr = remain
                Else
                    addstr = Right(remain, 3)
                End If
                result = result & "." & StrReverse(addstr)
                If rLen - count < 0 Then
                    curlen = 0

                Else
                    curlen = rLen - count
                    remain = Mid(Str, 1, curlen)
                End If
                If remain = "" Then Exit Do

            Loop
            result = Mid(result, 2)
            result = StrReverse(result)
            Return result
        End Function
       
        Protected Function GetMidURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(KeyName, KeyValue, ControlKey)
            If Not Session("MidOfStartPage") Is Nothing Then
                strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("MidOfStartPage").ToString)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectID=" & Request.Params("SelectID")
            End If
            Return strURL
        End Function

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(GetMidURL("DocCode", Request.QueryString("ML"), "CT_DSHOSO"))
        End Sub

    End Class
End Namespace