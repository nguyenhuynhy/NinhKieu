Namespace PortalQH
    Public Class ReportsInfo
        Private _ReportID As String
        Private _MaLinhVuc As String
        Private _TabCode As String
        Private _ItemCode As String
        Private _ReportName As String
        Private _ProcedureName As String
        Private _Title As String
        Private _MaNguoiXemBaoCao As String


        Public Property ReportID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ReportID
            Get
                Return _ReportID
            End Get
            Set(ByVal Value As String)
                _ReportID = Value
            End Set
        End Property

        Public Property MaLinhVuc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaLinhVuc
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
            End Set
        End Property

        Public Property TabCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.TabCode
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property

        Public Property ItemCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ItemCode
            Get
                Return _ItemCode
            End Get
            Set(ByVal Value As String)
                _ItemCode = Value
            End Set
        End Property

        Public Property ReportName() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ReportName
            Get
                Return _ReportName
            End Get
            Set(ByVal Value As String)
                _ReportName = Value
            End Set
        End Property

        Public Property ProcedureName() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ProcedureName
            Get
                Return _ProcedureName
            End Get
            Set(ByVal Value As String)
                _ProcedureName = Value
            End Set
        End Property
        'HieuLc
        Public Property MaNguoiXemBaoCao() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaLinhVuc
            Get
                Return _MaNguoiXemBaoCao
            End Get
            Set(ByVal Value As String)
                _MaNguoiXemBaoCao = Value
            End Set
        End Property
        'End HieuLC
        Public Property Title() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ReportName
            Get
                Return _Title
            End Get
            Set(ByVal Value As String)
                _Title = Value
            End Set
        End Property
        Public Sub ResetAll()
            _ReportID = ""
            _MaLinhVuc = ""
            _TabCode = ""
            _ItemCode = ""
            _ReportName = ""
            _ProcedureName = ""
            _Title = ""
        End Sub
    End Class
    Public Class ReportController
        Public Function GetReportInfo(ByVal obj As ReportsInfo) As ReportsInfo
            Dim ds As DataSet
            Dim dv As DataView
            Dim objReport As New ReportsInfo
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_getReportInfo", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.ItemCode)
            If ds.Tables(0).Rows.Count <> 0 Then
                dv = ds.Tables(0).DefaultView
                objReport.MaLinhVuc = CType(dv.Item(0).Item("MaLinhVuc"), String)
                objReport.TabCode = CType(dv.Item(0).Item("TabCode"), String)
                objReport.ItemCode = CType(dv.Item(0).Item("ItemCode"), String)
                objReport.ReportName = CType(dv.Item(0).Item("ReportName"), String)
                objReport.ProcedureName = CType(dv.Item(0).Item("ProcedureName"), String)
                objReport.Title = CType(dv.Item(0).Item("Title"), String)
            End If
            dv = Nothing
            ds = Nothing
            Return objReport
        End Function
        Public Sub AddReport(ByVal obj As Object)
            DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_InsReport", obj)
        End Sub
        Public Sub UpdateReport(ByVal obj As Object)
            DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_UpdReport", obj)
        End Sub
        Public Sub DelReport(ByVal obj As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelReport", obj)
        End Sub
        Public Function GetByIDReport(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetByIDReport", obj)
        End Function
        Public Function GetReports(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetReports", obj)
        End Function
        Public Function GetParamArray(ByVal strProcName As String, ByVal objPage As Object) As String
            Dim dr As IDataReader
            Dim c As DataColumn
            Dim r As DataRow
            Dim i, j As Integer
            Dim arr As New ArrayList
            Dim strSQL As String

            dr = DataProvider.Instance.ExecuteSQLApp("sp_sproc_columns '" & strProcName & "'")
            j = 1
            While dr.Read
                For i = 1 To dr.FieldCount - 1
                    If UCase(dr.GetName(i)) = "COLUMN_NAME" Then
                        If dr.GetString(i) <> "@RETURN_VALUE" Then
                            AddArray(arr, dr.GetString(i), objPage)
                            If arr.Count < j Then
                                arr.Add(Nothing)
                            End If
                            j += 1
                        End If
                    End If
                Next
            End While
            strSQL = strProcName & " "
            For i = 0 To arr.Count - 1
                If i <> 0 Then strSQL = strSQL & ","
                strSQL = strSQL & """" & CType(arr(i), String) & """"
            Next
            Return strSQL

        End Function
        Private Function AddArray(ByRef arr As ArrayList, ByVal strPamaName As String, ByVal objPage As Object) As Integer
            AddArray = FindControlAddArray(arr, strPamaName, objPage)
        End Function
        Private Function FindControlAddArray(ByRef arr As ArrayList, ByVal strPamaName As String, ByVal obj As Object) As Integer
            Dim oControl As Object
            Dim intAddArray As Integer
            Try
                If obj Is Nothing Then Exit Function
                intAddArray = 0
                For Each oControl In CType(obj, Control).Controls
                    Select Case True
                        Case TypeOf oControl Is TextBox
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                'arr.Add(IIf(CType(oControl, TextBox).Text = "", Nothing, CType(oControl, TextBox).Text))
                                arr.Add(CType(oControl, TextBox).ClientID)
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is HtmlInputHidden
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                'arr.Add(IIf(CType(oControl, TextBox).Text = "", Nothing, CType(oControl, TextBox).Text))
                                arr.Add(CType(oControl, HtmlInputHidden).ClientID)
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is DropDownList
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                'arr.Add(IIf(CType(oControl, DropDownList).SelectedItem.Value = "", Nothing, CType(oControl, DropDownList).SelectedItem.Value))
                                arr.Add(CType(oControl, DropDownList).ClientID)
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is RadioButtonList
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                'arr.Add(IIf(CType(oControl, RadioButtonList).SelectedItem.Value = "", Nothing, CType(oControl, RadioButtonList).SelectedItem.Value))
                                arr.Add(CType(oControl, RadioButtonList).ClientID)
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is CheckBox
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                'arr.Add(IIf(CType(oControl, CheckBox).Checked = True, 1, 0))
                                arr.Add(CType(oControl, CheckBox).ClientID)
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is RadioButton
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                'arr.Add(IIf(CType(oControl, RadioButton).Checked = True, 1, 0))
                                arr.Add(CType(oControl, RadioButton).ClientID)
                                intAddArray = 1
                                Exit For
                            End If
                        Case Else
                            FindControlAddArray(arr, strPamaName, oControl)
                    End Select
                Next oControl
            Catch ex As Exception
            Finally
                FindControlAddArray = intAddArray
            End Try
        End Function
        'HieuLc
        Public Function GetReportPhuongXa(ByVal obj As ReportsInfo) As ReportsInfo
            Dim ds As DataSet
            Dim dv As DataView
            Dim objReport As New ReportsInfo
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_getReportPhuongxa", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.ItemCode)
            If ds.Tables(0).Rows.Count <> 0 Then
                dv = ds.Tables(0).DefaultView
                objReport.MaLinhVuc = CType(dv.Item(0).Item("MaLinhVuc"), String)
                objReport.TabCode = CType(dv.Item(0).Item("TabCode"), String)
                objReport.ItemCode = CType(dv.Item(0).Item("ItemCode"), String)
                objReport.ReportName = CType(dv.Item(0).Item("ReportName"), String)
                objReport.ProcedureName = CType(dv.Item(0).Item("ProcedureName"), String)
                objReport.Title = CType(dv.Item(0).Item("Title"), String)
            End If
            dv = Nothing
            ds = Nothing
            Return objReport
        End Function
        'End HieuLC

    End Class
End Namespace