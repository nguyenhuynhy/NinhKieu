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
Namespace LICHCONGTAC

    Public Module Globals
        Public Const glbXMLFile As String = "LICHCONGTAC\XMLFILE\GlobalLICHCONGTAC.xml"
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

      
    End Module
End Namespace
