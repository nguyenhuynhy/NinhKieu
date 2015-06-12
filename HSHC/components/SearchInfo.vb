Imports System.Configuration
Imports System
Imports System.IO
Imports System.Web.Mail
Imports System.Text
Imports System.Net
Imports PortalQH.Web.UI.WebControls
Imports System.Data
Imports System.Security.Cryptography
Imports PortalQH

Public Class SearchInfoController
    Public Const glbXMLFile As String = "XMLFILE\Global.xml"
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
    Public Function GetSearchInfoList(ByVal DBName As String, ByVal LoaiHoSo As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_GetSearchInfoList", LoaiHoSo, gPortalID)
    End Function
    Public Function GetSearchInfo(ByVal DBName As String, ByVal LoaiHoSo As String, ByVal ItemCode As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_GetSearchInfo", LoaiHoSo, ItemCode, gPortalID)
    End Function
    Public Function GetSearchParams(ByVal DBName As String, ByVal SearchInfoID As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_GetSearchParams", SearchInfoID)
    End Function
    Public Function GetThongTinTimKiem(ByVal DBName As String, ByVal arr As ArrayList, ByVal ProcedureName As String) As DataSet
        Dim arrParam() As Object
        Dim i As Integer
        ReDim arrParam(arr.Count - 1)
        For i = 0 To arr.Count - 1
            arrParam(i) = arr(i)
        Next
        If InStr(DBName, ConfigurationSettings.AppSettings("db_hshc")) > 0 Then
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & ".." & ProcedureName, arrParam)
        Else
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & ".." & ProcedureName, arrParam)
        End If

    End Function
    Public Function GetThongTinTimKiem_ChiTiet(ByVal DBName As String, ByVal arr As ArrayList) As DataSet
        Dim arrParam() As Object
        Dim i As Integer
        ReDim arrParam(arr.Count - 1)
        For i = 0 To arr.Count - 1
            arrParam(i) = arr(i)
        Next
        If InStr(DBName, ConfigurationSettings.AppSettings("db_hshc")) > 0 Then
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_Web_ChiTietHoSo", arrParam)
        Else
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_Web_ChiTietHoSo", arrParam)
        End If

    End Function
    'Public Function GetThongTinTimKiem(ByVal obj As Object) As DataSet

    '    Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_Web_HoSo_Search", obj)


    'End Function
    Public Function GetThongTinTimKiem(ByVal DBName As String, ByVal obj As Object, ByVal ProcedureName As String) As DataSet

        If InStr(DBName, ConfigurationSettings.AppSettings("db_hshc")) > 0 Then
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo(ConfigurationSettings.AppSettings("db_hshc") & ".." & ProcedureName, obj)
        Else
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo(DBName & ".." & ProcedureName, obj)
        End If

    End Function
    'Lay Control Load len theo LinhVuc
    Public Function getTargetControlFile(ByVal p_TabId As String, ByVal p_LinhVuc As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getMenuSearch", p_TabId, p_LinhVuc)
    End Function
    Public Function GetThongTinTimKiemKinhTe(ByVal Db As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal SoGP As String, ByVal HoTen As String, ByVal SoCMND As String, ByVal SoNha As String, ByVal MaDuong As String, ByVal MaPhuong As String, ByVal SoBienNhan As String, ByVal MaLoaiHoSo As String, ByVal URL As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_cpkt") & "..sp_Web_HoSo_Search", Db, TuNgay, DenNgay, SoGP, HoTen, SoCMND, SoNha, MaDuong, MaPhuong, SoBienNhan, MaLoaiHoSo, URL)
    End Function
    Public Function GetThongTinTimKiemMotCua(ByVal Db As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal SoNha As String, ByVal HoTen As String, ByVal MaDuong As String, ByVal LoaiHoSo As String, ByVal MaPhuong As String, ByVal MaLinhVuc As String, ByVal SoBienNhan As String, ByVal URL As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_Web_HoSo_Search", Db, TuNgay, DenNgay, SoNha, HoTen, MaDuong, LoaiHoSo, MaPhuong, MaLinhVuc, SoBienNhan, URL)
    End Function
    Public Function GetDefaultLinhVuc(ByVal p_TabId As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc("sp_LinhVucSeach", p_TabId)
    End Function
    Public Function GetDBByLinhVuc(ByVal p_LinhVuc As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDBByLinhVucSearch", p_LinhVuc)
    End Function
    Public Function GetThongTinTimKiemXayDung(ByVal Db As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal SoGP As String, ByVal HoTen As String, ByVal DiaChiThuongTru As String, ByVal SoTo As String, ByVal SoThua As String, ByVal SoNha As String, ByVal MaDuong As String, ByVal MaPhuong As String, ByVal SoBienNhan As String, ByVal MaLoaiHoSo As String, ByVal URL As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_cpxd") & "..sp_Web_HoSo_Search", Db, TuNgay, DenNgay, SoNha, SoGP, MaDuong, HoTen, MaPhuong, MaLoaiHoSo, DiaChiThuongTru, SoBienNhan, SoTo, SoThua, URL)
    End Function
    Public Function GetThongTinTimKiemNhaDat(ByVal Db As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal SoGP As String, ByVal HoTen As String, ByVal SoCMND As String, ByVal SoNha As String, ByVal MaDuong As String, ByVal MaPhuong As String, ByVal MaLinhVuc As String, ByVal SoBienNhan As String, ByVal MaLoaiHoSo As String, ByVal SoTo As String, ByVal SoThua As String, ByVal URL As String) As DataSet
        Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_sdnd") & "..sp_Web_HoSo_Search", Db, TuNgay, DenNgay, SoGP, HoTen, SoCMND, SoNha, MaDuong, MaPhuong, MaLinhVuc, SoBienNhan, MaLoaiHoSo, SoTo, SoThua, URL)
    End Function
End Class
