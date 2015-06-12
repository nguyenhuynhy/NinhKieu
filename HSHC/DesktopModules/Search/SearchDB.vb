'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Shaun Walker ( shaunw1@shaw.ca ) of Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.Configuration
Imports System.Data

Namespace PortalQH
    Public Class SearchInfo
        ' local property declarations
        Private _PortalId As Integer
        Private _ModuleId As Integer
        Private _Search As String
        Private _MaxResults As Integer
        Private _TableName As String
        Private _SearchId As Integer
        Private _TitleField As String
        Private _DescriptionField As String
        Private _CreatedByUserField As String
        Private _CreatedDateField As String

        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property PortalId() As Integer
            Get
                Return _PortalId
            End Get
            Set(ByVal Value As Integer)
                _PortalId = Value
            End Set
        End Property
        Public Property ModuleId() As Integer
            Get
                Return _ModuleId
            End Get
            Set(ByVal Value As Integer)
                _ModuleId = Value
            End Set
        End Property
        Public Property Search() As String
            Get
                Return _Search
            End Get
            Set(ByVal Value As String)
                _Search = Value
            End Set
        End Property
        Public Property MaxResults() As Integer
            Get
                Return _MaxResults
            End Get
            Set(ByVal Value As Integer)
                _MaxResults = Value
            End Set
        End Property
        Public Property TableName() As String
            Get
                Return _TableName
            End Get
            Set(ByVal Value As String)
                _TableName = Value
            End Set
        End Property
        Public Property SearchId() As Integer
            Get
                Return _SearchId
            End Get
            Set(ByVal Value As Integer)
                _SearchId = Value
            End Set
        End Property
        Public Property TitleField() As String
            Get
                Return _TitleField
            End Get
            Set(ByVal Value As String)
                _TitleField = Value
            End Set
        End Property
        Public Property DescriptionField() As String
            Get
                Return _DescriptionField
            End Get
            Set(ByVal Value As String)
                _DescriptionField = Value
            End Set
        End Property
        Public Property CreatedByUserField() As String
            Get
                Return _CreatedByUserField
            End Get
            Set(ByVal Value As String)
                _CreatedByUserField = Value
            End Set
        End Property
        Public Property CreatedDateField() As String
            Get
                Return _CreatedDateField
            End Get
            Set(ByVal Value As String)
                _CreatedDateField = Value
            End Set
        End Property

    End Class
    Public Class SearchController

        Public Function GetResults(ByVal PortalId As Integer, ByVal ModuleId As Integer, ByVal Search As String, ByVal MaxResults As Integer) As DataSet

            ' create dataset
            Dim dataSet As dataSet = New dataSet

            Dim intCounter As Integer
            Dim dr As IDataReader

            dr = DataProvider.Instance().GetSearchResults(-1, "", "", "", "", "", "")

            Dim dataTable As dataTable = New dataTable
            Dim schema As dataTable = dr.GetSchemaTable()
            For intCounter = 0 To schema.Rows.Count - 1
                Dim dataRow As DataRow = schema.Rows(intCounter)
                Dim columnName As String = CType(dataRow("ColumnName"), String)
                Dim column As DataColumn = New DataColumn(columnName, System.Type.GetType("System.String"))
                dataTable.Columns.Add(column)
            Next
            dataSet.Tables.Add(dataTable)
            dr.Close()

            Dim intResults As Integer = 0
            Dim dr2 As IDataReader

            dr = CType(GetSearch(ModuleId), IDataReader)
            While dr.Read
                If Not IsDBNull(dr("TitleField")) Then
                    dr2 = DataProvider.Instance().GetSearchResults(PortalId, dr("TableName").ToString, dr("TitleField").ToString, dr("DescriptionField").ToString, dr("CreatedDateField").ToString, dr("CreatedByUserField").ToString, Search)
                    If dr2.Read Then
                        ' check security
                        If PortalSecurity.IsInRoles(Convert.ToString(IIf(dr2("AuthorizedViewRoles").ToString <> "", dr2("AuthorizedViewRoles").ToString, dr2("AuthorizedRoles").ToString))) Then
                            If intResults < MaxResults Or MaxResults = -1 Then
                                Dim dataRow As DataRow = dataTable.NewRow()

                                For intCounter = 0 To dr2.FieldCount - 1
                                    dataRow(intCounter) = dr2.GetValue(intCounter)
                                Next

                                dataTable.Rows.Add(dataRow)

                                intResults = intResults + 1
                            End If
                        End If
                    End If
                    dr2.Close()
                End If
            End While
            dr.Close()

            ' Return the dataset
            Return dataSet

        End Function


        Public Function GetSearch(ByVal ModuleId As Integer) As SearchInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetSearchModule(ModuleId), GetType(SearchInfo)), SearchInfo)

        End Function

        Public Sub AddSearch(ByVal objSearch As SearchInfo)
            Try

                DataProvider.Instance().AddSearch(objSearch.ModuleId, objSearch.TableName)
            Catch
                ' table already defined for this search
            End Try

        End Sub


        Public Function GetSearch(ByVal SearchId As Integer, ByVal ModuleId As Integer) As SearchInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetSearch(SearchId, ModuleId), GetType(SearchInfo)), SearchInfo)

        End Function

        Public Sub UpdateSearch(ByVal objSearch As SearchInfo)

            DataProvider.Instance().UpdateSearch(objSearch.SearchId, objSearch.TitleField, objSearch.DescriptionField, objSearch.CreatedDateField, objSearch.CreatedByUserField)

        End Sub


        Public Sub DeleteSearch(ByVal SearchId As Integer)

            DataProvider.Instance().DeleteSearch(SearchId)

        End Sub


        Public Function GetSearchTables() As ArrayList

            Dim arrTables As New ArrayList
            Dim dr2 As IDataReader

            Dim dr As IDataReader = DataProvider.Instance().GetTables
            While dr.Read
                dr2 = DataProvider.Instance().GetFields(Convert.ToString(dr(0))) 'Geert - Changed for better support for databases that cannot return a columnname "TableName", instead always use first column.
                Try
                    If dr2.GetOrdinal("ModuleId") <> -1 Then
                        arrTables.Add(dr(0))  'Geert - Changed for better support for databases that cannot return a columnname "TableName", instead always use first column.
                    End If
                Catch exc As IndexOutOfRangeException
                End Try
                dr2.Close()
            End While
            dr.Close()

            Return arrTables

        End Function


        Public Function GetSearchFields(ByVal SearchId As Integer, ByVal ModuleId As Integer) As ArrayList

            Dim arrFields As New ArrayList

            Dim dr As IDataReader = CType(GetSearch(SearchId, ModuleId), IDataReader)
            If dr.Read Then

                Dim dr2 As IDataReader = DataProvider.Instance().GetFields(Convert.ToString(dr("TableName")))
                Dim schema As DataTable = dr2.GetSchemaTable()
                Dim intFields As Integer
                For intFields = 0 To schema.Rows.Count - 1
                    Dim dataRow As dataRow = schema.Rows(intFields)
                    arrFields.Add(CType(dataRow("ColumnName"), String))
                Next
                dr2.Close()

            End If
            dr.Close()

            Return arrFields

        End Function

    End Class

End Namespace
