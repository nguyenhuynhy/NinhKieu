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
Namespace HSHC

    Public Module Globals
        Public Function glbXMLFile() As String
            Return ConfigurationSettings.AppSettings("PathHSHCQH") & "Global.xml"
        End Function
        Public Const glbPathFileTemplate As String = " "
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
        Public Function GetXMLChildValues(ByVal Request As HttpRequest, ByVal pParent As String, ByVal glbXmlFile As String) As ArrayList
            Dim xmldoc As New Xml.XmlDocument
            Dim elemList As Xml.XmlNodeList
            Dim xmlNode As Xml.XmlNode
            Dim i, k As Integer
            Dim strXMLFile As String
            Dim arr As New ArrayList
            strXMLFile = GetAbsoluteServerPath(Request) & glbXmlFile
            xmldoc.Load(strXMLFile)


            elemList = xmldoc.GetElementsByTagName(pParent)
            For i = 0 To elemList.Count - 1
                xmlNode = elemList.Item(i)
                For k = 0 To xmlNode.ChildNodes.Count - 1
                    arr.Add(xmlNode.ChildNodes(k).InnerXml)
                Next
                xmlNode = Nothing
            Next
            xmldoc = Nothing
            elemList = Nothing
            GetXMLChildValues = arr
        End Function

        Public Sub BindDropDownList_NguoiKy(ByVal ddlNguoiKy As DropDownList)
            Dim strNguoiKy As String

            strNguoiKy = GetParamByID("nguoiky", glbXMLFile)
            BindControl.BindDropDownList(ddlNguoiKy, "sp_GetUsersByChucDanh", "", strNguoiKy, 1) '1: lay mot item rong
        End Sub
        Public Sub BindDropDownList_ChuyenVienPhongBan(ByVal ddl As DropDownList)
            Dim strMaPhongBan As String
            strMaPhongBan = GetParamByID("maphongban", glbXMLFile)
            BindControl.BindDropDownList(ddl, GetCommonDB() & ".dbo.sp_GetUsersByPhongBan", "", strMaPhongBan, 1) '1: lay mot item rong
        End Sub

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

        'lấy chuỗi lĩnh vực cần kiểm tra hồ sơ lúc tiếp nhận
        Public Function LinhVucKiemTraHoSoTiepNhan() As Array
            Dim strChuoiLinhVuc As String
            strChuoiLinhVuc = GetParamByID("LinhVucKiemTraHoSoTiepNhan", glbXMLFile)
            Return Split(strChuoiLinhVuc, ",")
        End Function
        'end thuytt

        Public Function InPhieuChuyen(ByVal request As HttpRequest, ByVal ds As DataSet, ByVal strItemCode As String) As String
            Dim url As String
            Dim Script As String
            Dim strServerPath As String

            Dim strTemplateFileName As String = GetParamByID("FilePhieuChuyen", glbXMLFile)

            strServerPath = GetAbsoluteServerPath(request)

            Dim sFileName As String
            Dim sourceFileName As String = strServerPath & getTemplatePathOfWord() & strItemCode & "\" & strTemplateFileName
            Dim destFilePath As String = strServerPath & getOutputPathOfWord() & strItemCode & "\"

            Do
                sFileName = genRandomKey() & ".doc"
                If (Not File.Exists(destFilePath & sFileName)) Then
                    Exit Do
                End If
            Loop
            File.Copy(sourceFileName, destFilePath & sFileName)

            'Open temp file
            Dim m_doc As New OfficeHelper.Utilities.Data.WordHelper
            m_doc.Open(destFilePath & sFileName)

            'Phan thong tin chinh
            m_doc.MergeField(ds.Tables(0))

            'Close file
            m_doc.Save()

            InPhieuChuyen = getOutputPathOfWord().Replace("\", "/") & strItemCode & "/" & sFileName

        End Function

    End Module
End Namespace
