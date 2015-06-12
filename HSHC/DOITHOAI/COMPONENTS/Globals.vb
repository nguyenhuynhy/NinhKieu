Imports PortalQH
Imports System
'
Namespace DOITHOAI
    Public Module Globals
        Public Const strPathChonNguoiNhan As String = "DOITHOAI/DesktopModules/ChonNguoiNhanCauHoi.aspx"
        Public Const glbXMLFile As String = "DOITHOAI\XMLFILE\Global.xml"

        Public Function getLoaiDanhSachCauHoi(ByVal request As HttpRequest, ByVal pSelectID As String) As String
            Dim xmldoc As New Xml.XmlDocument
            Dim elemList As Xml.XmlNodeList
            Dim xmlNode As Xml.XmlNode
            Dim i, k As Integer
            Dim strXMLFile As String
            strXMLFile = GetAbsoluteServerPath(request) & glbXMLFile
            xmldoc.Load(strXMLFile)

            elemList = xmldoc.GetElementsByTagName("LoaiDanhSach")
            For i = 0 To elemList.Count - 1
                xmlNode = elemList.Item(i)
                For k = 0 To xmlNode.ChildNodes.Count - 1
                    If xmlNode.ChildNodes(k).Name = "SelectID" & pSelectID Then
                        getLoaiDanhSachCauHoi = xmlNode.ChildNodes(k).InnerXml
                        Exit For
                    End If
                Next
                xmlNode = Nothing
            Next
            xmldoc = Nothing
            elemList = Nothing
        End Function
        Public Function GetSoDongHienThiLuoi() As Integer
            Return CType(GetParamByID("SoDongHienThiDatagrid", glbXMLFile), Integer)
        End Function
        Public Function GetSoNgayLoc() As Integer
            Return CType(GetParamByID("SoNgayLoc", glbXMLFile), Integer)
        End Function
        Public Function getTieuDeDefault() As String
            Return GetParamByID("TieuDeDefault", glbXMLFile)
        End Function
        Public Function ReplaceHTML(ByVal str As String) As String
            'replace các thẻ html
            str = Replace(Replace(str, "<", "&lt;"), ">", "&gt;")
            'replace kí tự xuống dòng
            str = Replace(str, Chr(13), "<br>")
            Return str
        End Function
    End Module
End Namespace