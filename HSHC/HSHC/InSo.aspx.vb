Imports PortalQH
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Namespace HSHC
    Public Class InSo
        Inherits System.Web.UI.Page       


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlLoaiHS As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.Button
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents data As System.Web.UI.WebControls.DataGrid
        Protected WithEvents CrystalReportViewer1 As CrystalDecisions.Web.CrystalReportViewer
        Protected WithEvents btnXuatExcel As System.Web.UI.WebControls.Button
        Protected WithEvents txtKQ As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        'Dim con As SqlConnection
        Dim da As SqlDataAdapter
        Dim tb As DataTable
        Dim da1 As SqlDataAdapter
        Dim tb1 As DataTable
        Dim con As SqlConnection
        Dim conportal As SqlConnection
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim reader As New System.Configuration.AppSettingsReader
            Dim str As String
            Dim str2 As String
            str = reader.GetValue("connectionStringHSHCQH", GetType(String)).ToString()
            str2 = reader.GetValue("connectionStringPortalQH", GetType(String)).ToString()
            con = New SqlConnection(str)
            conportal = New SqlConnection(str2)
            If Not IsPostBack Then
                Try
                    Dim lhs As String
                    Dim lv As String
                    Dim sql As String
                    lv = Request.QueryString.Get("LINHVUC").ToString()

                    sql = "select 'All' as MaLoaiHoSo, N'--Tất Cả--' as TenLoaiHoSo union all select MaLoaiHoSo,TenLoaiHoSo from DMLOAIHOSO where MaLinhVuc='" + lv + "' and Used='1'"
                    da1 = New SqlDataAdapter(sql, con)
                    tb1 = New DataTable
                    da1.Fill(tb1)
                    'ddlLoaiHS.DataSource = tb1
                    ddlLoaiHS.DataTextField = "TenLoaiHoSo"
                    ddlLoaiHS.DataValueField = "MaLoaiHoSo"
                    ddlLoaiHS.DataSource = tb1
                    ddlLoaiHS.DataBind()
                    lhs = ddlLoaiHS.SelectedValue.ToString()
                    loaddata(lhs)
                    'You may place an exception here 
                    'Label1.Text = ex.Message;
                Catch ex As Exception
                    Response.Write(ex.ToString())
                End Try
            End If            
            If txtTuNgay.Text.Equals("") Then
                txtTuNgay.Text = "01" + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()
            End If
            If txtDenNgay.Text.Equals("") Then
                txtDenNgay.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()
            End If
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
        End Sub
        Private Sub loaddata(ByVal lhs As String)
            'Dim lv As String
            Dim users As String
            Dim donvi As String            
            Dim str As String
            Dim da2 As SqlDataAdapter
            Dim tb2 As DataTable
            Dim lv As String
            lv = Request.QueryString.Get("LINHVUC").ToString()

            users = Session.Item("UserName").ToString()
            'lhs = ddlLoaiHS.SelectedValue.ToString()
            da2 = New SqlDataAdapter("select upper(DMDONVI.TenDonVi) from Users join DMDONVI on Users.MaPhongBan=DMDONVI.MaDonVi where Users.UserName='" + users + "'", conportal)
            tb2 = New DataTable
            da2.Fill(tb2)
            If tb2.Rows.Count > 0 Then
                donvi = tb2.Rows(0).Item(0).ToString()
            Else
                donvi = ""
            End If
            da = New SqlDataAdapter("Exec sp_rptInSo '" + lhs + "', '" + users + "','" + txtTuNgay.Text + "','" + txtDenNgay.Text + "','" + lv + "'", con)
            tb = New DataTable
            da.Fill(tb)

            'data.DataSource = tb
            'data.DataBind()
            str = "<p align='center'><b><span style='font-size:15px'>DANH SÁCH HỒ SƠ TIẾP NHẬN</span><br>"
            If (ddlLoaiHS.SelectedItem.Value.Equals("All")) Then
                'str += "<span style='font-size:20px'>LĨNH VỰC</span><br>"
            Else
                str += "<span style='font-size:20px'>" + ddlLoaiHS.SelectedItem.Text.ToString().ToUpper() + "</span><br>"
            End If

            str += "<span style='font-size:15px'>TỪ NGÀY " + txtTuNgay.Text + " ĐẾN " + txtDenNgay.Text + "</span></b></p>"
            str += "<table Class='QH_DataGrid' id='data' Width='100%' CellPadding='3' border='1' style='border-collapse: collapse;'>"

            str += "<tr>"
            str += "<th class='QH_DatagridHeader'>STT</th>"
            str += "<th class='QH_DatagridHeader'>Số biên nhận</th>"
            str += "<th class='QH_DatagridHeader'>Người nộp</th>"
            str += "<th class='QH_DatagridHeader'>Địa chỉ</th>"
            str += "<th class='QH_DatagridHeader'>Ngày nhận</th>"
            str += "<th class='QH_DatagridHeader'>Ngày hẹn trả</th>"
            str += "<th class='QH_DatagridHeader'>Ngày thực trả</th>"
            str += "<th class='QH_DatagridHeader'>Nội dung trích yếu</th>"
            str += "<th class='QH_DatagridHeader'>Ghi chú</th>"
            str += "</tr>"
         
            Dim i As Integer
            Dim title As String = ""
            Dim sodong As Integer
            If tb.Rows.Count > 0 Then
                sodong = tb.Rows.Count

                For i = 0 To tb.Rows.Count - 1 Step 1

                    If ddlLoaiHS.SelectedValue.Equals("All") Then
                        title = tb.Rows(i).Item(9).ToString()

                        Try
                            If i = 0 Then
                                str += "<tr bgcolor='#9CCEFC'>"
                                str += "<td colspan='9'>" + tb.Rows(i).Item(9).ToString() + "</td>"
                                str += "</tr>"
                            Else
                                If title.Equals(tb.Rows(i - 1).Item(9).ToString()) = False Then
                                    str += "<tr bgcolor='#9CCEFC'>"
                                    str += "<td colspan='9'>" + tb.Rows(i).Item(9).ToString() + "</td>"
                                    str += "</tr>"
                                End If
                            End If

                        Catch ex As Exception
                            Response.Write(ex.ToString())
                        End Try
                    End If
                    str += "<tr><td>" + tb.Rows(i).Item(0).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(1).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(2).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(3).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(4).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(5).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(6).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(7).ToString() + "</td>"
                    str += "<td>" + tb.Rows(i).Item(8).ToString() + "</td>"
                    str += "</tr>"
                Next
            End If
            str += " </table>"
            txtKQ.Text = str


        End Sub

        Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim lhs As String
            lhs = ddlLoaiHS.SelectedValue.ToString()
            loaddata(lhs)
            'PortalQH.Globals.ExportToExcel(lv,"abc",            
        End Sub

        Private Sub ddlLoaiHS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLoaiHS.SelectedIndexChanged
            Dim lv As String
            lv = ddlLoaiHS.SelectedValue.ToString()
            loaddata(lv)
        End Sub
        Private Sub ExportGridToword()
            Dim FileName As String
            Dim strwritter As New StringWriter
            Dim tenhs As String
            tenhs = chuyensangkhongdau(ddlLoaiHS.SelectedItem.ToString())

            Response.Clear()
            Response.Buffer = True
            Response.ClearContent()
            Response.ClearHeaders()
            Response.Charset = ""
            FileName = PortalQH.Globals.genRandomKey() + ".xls"
            Dim htmltextwrtter As New HtmlTextWriter(strwritter)
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Response.ContentType = "application/msword"
            Response.ContentType = "application/msexcel"
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName)
            'txtKQ.GridLines = GridLines.Both
            'txtKQ.HeaderStyle.Font.Bold = True
            txtKQ.RenderControl(htmltextwrtter)
            Response.Write(strwritter.ToString())
            Response.End()

        End Sub
        Function chuyensangkhongdau(ByVal mystr As String) As String
            Dim myChar() As String = {"aàáảãạăằắẳẵặâầấẩẫậ", "AÀÁẢÃẠĂẰẮẲẴẶÂẦẤẨẪẬ", "ÒÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢ", "EÈÉẺẼẸÊỀẾỂỄỆ", "UÙÚỦŨỤƯỪỨỬỮỰ", "IÌÍỈĨỊ", "YỲÝỶỸỴ", "Đ", "oòóỏõọôồốổỗộơờớởỡợ", "eèéẻẽẹêềếểễệ", "uùúủũụưừứửữự", "iìíỉĩị", "yỳýỷỹỵ", "đ"}
            Dim myChar1() As String = {"a", "A", "O", "E", "U", "I", "Y", "Đ", "o", "e", "u", "i", "y", "d"}
            Dim str As String = mystr
            Dim strReturn As String = ""
            For i As Int32 = 0 To str.Length - 1
                Dim iStr As String = str.Substring(i, 1)
                Dim rStr As String = iStr

                For j As Int32 = 0 To myChar.Length - 1
                    If myChar(j).IndexOf(iStr) >= 0 Then
                        rStr = myChar1(j)
                        Exit For
                    End If
                Next
                strReturn += rStr
            Next
            Return strReturn
        End Function
        Private Sub btnXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatExcel.Click
            ExportGridToword()
        End Sub
    End Class
End Namespace
