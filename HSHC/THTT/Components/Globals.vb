Option Strict Off
Imports PortalQH
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Web.Mail
Imports System.Text
Imports System.Net
Imports PortalQH.Web.UI.WebControls
Imports System.Data
Imports System.Security.Cryptography
Namespace THTT

    Public Module Globals
        Public Const glbXMLFile As String = "XMLFILE\GlobalHSHC.xml"
        Public Function GetValueItem(ByVal Request As HttpRequest, ByVal pItem As String, ByVal glbXmlFile As String) As String
            Dim xmldoc As New Xml.XmlDocument
            Dim elemList As Xml.XmlNodeList
            Dim xmlNode As Xml.XmlNode
            Dim i, k As Integer
            Dim strXMLFile As String
            strXMLFile = GetAbsoluteServerPath(Request) & glbXmlFile
            xmldoc.Load(strXMLFile)


            elemList = xmldoc.GetElementsByTagName("Variable")
            For i = 0 To elemList.Count - 1
                xmlNode = elemList.Item(i)
                For k = 0 To xmlNode.ChildNodes.Count - 1
                    If xmlNode.ChildNodes(k).Name = pItem Then
                        GetValueItem = xmlNode.ChildNodes(k).InnerXml
                        Exit For
                    End If
                Next
                xmlNode = Nothing
            Next
            xmldoc = Nothing
            elemList = Nothing

        End Function

        'Public Sub BindDropDownList_NguoiKy(ByVal ddlNguoiKy As DropDownList)
        '    Dim strNguoiKy As String

        '    strNguoiKy = GetParamByID("nguoiky", glbXMLFile)
        '    BindControl.BindDropDownList(ddlNguoiKy, "sp_GetUsersByChucDanh", "", strNguoiKy, 1) '1: lay mot item rong
        'End Sub
        'Public Sub BindDropDownList_ChuyenVienPhongBan(ByVal ddl As DropDownList)
        '    Dim strMaPhongBan As String
        '    strMaPhongBan = GetParamByID("maphongban", glbXMLFile)
        '    BindControl.BindDropDownList(ddl, GetCommonDB() & ".dbo.sp_GetUsersByPhongBan", "", strMaPhongBan, 1) '1: lay mot item rong
        'End Sub

        'thuytt 28/10/2004
        Public Function InitCell(Optional ByVal text As String = "", Optional ByVal colspan As Integer = 1, Optional ByVal rowspan As Integer = 1) As TableCell
            Dim cell As New TableCell
            cell.ColumnSpan = colspan
            cell.RowSpan = rowspan
            cell.Text = text
            Return cell
        End Function

        Public Function GetSoDongHienThiLuoi() As Integer
            Return CType(GetParamByID("SoDongHienThiDatagrid", glbXMLFile), Integer)
        End Function
        'end thuytt
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
        Public Function ISLOGGED(ByVal value As String) As Boolean
            If value = "" Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Sub BindDBList(ByVal list As DropDownList)
            'Select the newest PUB 
            Dim newitem As New ListItem
            Dim newitem1 As New ListItem
            Dim newitem2 As New ListItem
            Dim newitem3 As New ListItem
            newitem.Text = "Kinh doanh"  ' cap phep kinh te
            newitem.Value = "DB_vpktBT"
            list.Items.Insert(0, newitem)
            '.Add(newitem)
            newitem1.Text = "Xây d?ng"  ' cap phep do thi
            newitem1.Value = "DB_vpDTBT"
            list.Items.Insert(1, newitem1)

            newitem2.Text = "Van hóa"  ' cap phep van hoa
            newitem2.Value = "DB_vpVHBT"
            list.Items.Insert(2, newitem2)

            newitem3.Text = "Lao d?ng"  ' cap phep lao dong
            newitem3.Value = "DB_vpLDBT"
            list.Items.Insert(3, newitem3)
        End Sub

        Public Function ShowDate(ByVal dDate As Date) As String
            Dim tmpDate As String
            If Not IsDate(dDate) Then
                Return ""
            Else
                tmpDate = Right("0" & Day(dDate), 2) & "/" & Right("0" & Month(dDate), 2) & "/" & Year(dDate)
                Return tmpDate
            End If
        End Function

        'Ngay dau tien trong tuan -dDate:ngay hien tai
        Public Function FirstDateOfWeek(ByVal dDate) As Date
            Dim dt, offset
            offset = Weekday(dDate) - 2
            dt = DateAdd("d", -CInt(offset), dDate)
            FirstDateOfWeek = dt
        End Function

        Public Function LastDateOfWeek(ByVal dDate) As Date
            Dim dt, offset
            offset = 7 - Weekday(dDate) + 1
            dt = DateAdd("d", offset, dDate)
            LastDateOfWeek = dt
        End Function

        Public Function FirstDateOfMonth(ByVal dDate)
            Dim dt
            dt = DateSerial(Year(dDate), Month(dDate), 1)
            FirstDateOfMonth = dt
        End Function

        Public Function LastDateOfMonth(ByVal dDate)
            Dim dt
            dt = DateSerial(Year(dDate), Month(dDate) + 1, 1)
            dt = DateAdd("d", -1, dt)
            LastDateOfMonth = dt
        End Function

        Public Function FirstDateOfYear(ByVal dDate)
            FirstDateOfYear = "01/01/" & Year(dDate)
        End Function

        Public Function LastDateOfYear(ByVal dDate)
            LastDateOfYear = "31/12/" & Year(dDate)
        End Function

        Function GETSOGP_DT(ByVal STRFULLSOGP As String, ByVal STRDB As String, ByVal strTable As String)
            Dim myConnection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(ConfigurationSettings.AppSettings("connectionstring_forums"))
            Dim commandText As String
            Dim firstRow As Boolean = True
            commandText = "sp_web_getFullSoGP '" & STRFULLSOGP & "','" & STRDB & "','" & strTable & "'"

            Dim sqlCommand As New System.Data.SqlClient.SqlCommand(commandText, myConnection)

            Dim dataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(sqlCommand)
            Dim dataSet As System.Data.DataSet = New System.Data.DataSet
            dataAdapter.Fill(dataSet)
            Dim r As DataRow
            For Each r In dataSet.Tables(0).Rows
                Return r.Item("sogiayphep")
            Next
            sqlCommand.Dispose()
            dataAdapter.Dispose()
            dataSet.Dispose()
            myConnection.Dispose()
        End Function
        Function getTTrangXLy(ByVal strDB As String, ByVal curid As String)

            Dim firstRow As Boolean = True
            Dim dataSet As System.Data.DataSet = New System.Data.DataSet
            Dim objVPHC As New ViPhamHanhChinhController
            dataSet = objVPHC.GetTinhTrangXuLy(strDB, ConfigurationSettings.AppSettings("commonDB"), curid)
            Dim r As DataRow
            Dim datastring As String
            Dim strNgayXL, strNoiGQ, strNguoiThuLy, strTinhTrang As String
            Dim strNhomCV, strMasoHoso As String
            Dim iTimes As Integer
            For Each r In dataSet.Tables(0).Rows
                If Not IsDBNull(r.Item("NgayXL")) Then
                    strNgayXL = ShowDate(r.Item("NgayXL"))
                Else
                    strNgayXL = "&nbsp;"
                End If
                If Not IsDBNull(r.Item("TenBoPhan")) Then
                    strNoiGQ = r.Item("TenboPhan")
                Else
                    strNoiGQ = "&nbsp;"
                End If
                If Not IsDBNull(r.Item("NGuoiThuLy")) Then
                    strNguoiThuLy = r.Item("NguoiThuLy")
                Else
                    strNguoiThuLy = "&nbsp;"
                End If
                If Not IsDBNull(r.Item("TTrang")) Then
                    strTinhTrang = r.Item("TTrang")
                Else
                    strTinhTrang = "&nbsp;"
                End If

                If Not IsDBNull(r.Item("nhomcvid")) Then
                    If strNhomCV <> r.Item("nhomcvid") Then
                        iTimes = 1
                        strNhomCV = r.Item("nhomcvid")
                        datastring = datastring & "<TR><td colspan=""4"" bgcolor=""#FFFCD7"">&nbsp;&nbsp;&nbsp;" & r.Item("TENNHOMCV") & "</TD></TR>"
                    End If
                Else
                    strNhomCV = ""
                    datastring = datastring & "<TR><td colspan=""4"" bgcolor=""#FFFCD7"">&nbsp;&nbsp;&nbsp;KHAC </TD></TR>"
                End If

                If Not IsDBNull(r.Item("nhomcvid")) And Not IsDBNull(r.Item("MASOHOSO")) Then
                    If UCase(r.Item("nhomcvid")) = "QUYETDINH" Or UCase(r.Item("nhomcvid")) = "CUONGCHE" Or UCase(r.Item("nhomcvid")) = "CUONGCHE_THONGBAO" Or UCase(r.Item("nhomcvid")) = "KHIEUNAI" Then
                        If strMasoHoso <> r.Item("MasoHoSo") Then
                            strMasoHoso = r.Item("MasoHoSo")
                            datastring = datastring & "<TR><td colspan=""4"" bgcolor=""#FFFEEA"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & r.Item("TENNHOMCV") & " l?n " & iTimes & " </TD></TR>"
                            iTimes = iTimes + 1
                        End If
                    End If
                End If

                datastring = datastring & "<TR>"
                datastring = datastring & "<TD align=""center"">" & strNgayXL & "</TD><TD>" & strNoiGQ & "</TD>"
                datastring = datastring & "<TD>" & strNguoiThuLy & "</TD><TD>" & strTinhTrang & "</TD>"
                datastring = datastring & "</TR>"
            Next
            Return datastring

        End Function
    End Module
End Namespace
