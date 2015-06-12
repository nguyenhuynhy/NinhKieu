'
' by AnhLH (anhlh@fpt.com.vn)
' date May 12, 2004
' Purpose: view, addnew, edit, delete on DanhMuc tables
'

Imports System
Imports System.Configuration
Imports System.Data

Namespace PortalQH
    Public Class DanhMucInfo
        ' local property declarations
        Private _Ma As String
        Private _Ten As String

        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property Ma() As String
            Get
                Return _Ma
            End Get
            Set(ByVal Value As String)
                _Ma = Value
            End Set
        End Property

        Public Property Ten() As String
            Get
                Return _Ten
            End Get
            Set(ByVal Value As String)
                _Ten = Value
            End Set
        End Property

    End Class
    Public Class DanhMucController
        Public Function GetDanhMucListCBO(ByVal strTableName As String, Optional ByVal IsNull As Boolean = True) As ArrayList
            If Not IsNull Then
                Return CBO.FillCollection(DataProvider.Instance().GetDanhMucCBO(strTableName), GetType(DanhMucInfo))
            Else
                Dim arrDM As New ArrayList
                Dim arr As New ArrayList
                Dim i As Integer
                Dim objDanhMuc As New DanhMucInfo
                objDanhMuc.Ma = ""
                objDanhMuc.Ten = ""

                arr = CBO.FillCollection(DataProvider.Instance().GetDanhMucCBO(strTableName), GetType(DanhMucInfo))
                If arr.Count <> 1 Then 'kiem tra trong truong hop chi co 1 item thi khong su dung chon tat ca ( Null )
                    arrDM.Add(objDanhMuc)
                End If
                For i = 0 To arr.Count - 1
                    arrDM.Add(arr(i))
                Next
                Return arrDM

                End If


        End Function

        Public Function GetDanhMucList(ByVal strTableName As String, Optional ByVal strSortExpression As String = "", Optional ByVal strFilterExpression As String = "") As DataSet

            Return DataProvider.Instance().GetDanhMucList(strTableName, strSortExpression, strFilterExpression)

        End Function


        'Public Function GetDanhMuc(ByVal objPage As Object, ByVal strTableName As String) As DataSet

        'Return DataProvider.Instance().GetDanhMuc(objPage, strTableName)

        'End Function
        Public Function GetDanhMuc(ByVal objPage As Object, ByVal strTableName As String, ByVal ParamArray arrParams() As Object) As DataSet

            Return DataProvider.Instance().GetDanhMuc(objPage, strTableName, arrParams)

        End Function

        'Public Sub DeleteDanhMuc(ByVal objPage As Object, ByVal strTableName As String)

        '   DataProvider.Instance().DeleteDanhMuc(objPage, strTableName)

        'End Sub
        Public Sub DeleteDanhMuc(ByVal objPage As Object, ByVal strTableName As String, ByVal ParamArray arrParams() As Object)

            DataProvider.Instance().DeleteDanhMuc(objPage, strTableName, arrParams)

        End Sub

        Public Sub AddDanhMuc(ByVal objPage As Object, ByVal strTableName As String)
            DataProvider.Instance().AddDanhMuc(objPage, strTableName)
        End Sub

        Public Sub UpdateDanhMuc(ByVal objPage As Object, ByVal strTableName As String)

            DataProvider.Instance().UpdateDanhMuc(objPage, strTableName)

        End Sub
        Public Function GetByID(ByVal strStoreProc As String, ByVal ParamArray ParaValues() As Object) As DataSet

            Return DataProvider.Instance().GetByID(strStoreProc, ParaValues)
        End Function
        Public Function GetByChucDanh(ByVal strStoreProc As String, ByVal ParamArray ParaValues() As Object) As DataSet
            Return DataProvider.Instance().GetByID(strStoreProc, ParaValues)
        End Function
        Public Function GetTenQuan() As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_GetTenQuan")
        End Function


    End Class


End Namespace

