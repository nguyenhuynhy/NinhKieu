Option Strict Off
Imports System
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports System.Collections
Imports System.Data.OleDb
Imports System.Web.UI
'Imports Microsoft.Office.Interop


Namespace ExcelReportTool

    Class clsExcelReport
        'Frequenty-used variable for optional arguments
        Private objMissing As Object = Missing.Value
        Private strSQLConnString As String = ""
        Private strExcelConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=strExcelFile; Extended Properties=Excel 8.0"
        Private strTemporaryFolder As String = ""
        Private strTemplatesFolder As String = ""
        Private arrParamsField As ArrayList = Nothing
        Private arrParamsValue As ArrayList = Nothing
        Private arrGroupsField As ArrayList = Nothing
        Private arrGroupsDescp As ArrayList = Nothing
        Private strSortsField As String = Nothing
        Private strFilters As String = Nothing

        Public Sub New()
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
        End Sub

#Region "set value for class"

        'set sql connection string
        Public WriteOnly Property SQLConnString() As String
            Set(ByVal Value As String)
                strSQLConnString = Value
            End Set
        End Property

        'set excel connection string
        Public WriteOnly Property ExcelConnString() As String
            Set(ByVal Value As String)
                strExcelConnString = Value
            End Set
        End Property

        'set temporary folder
        Public WriteOnly Property TemporaryFolder() As String
            Set(ByVal Value As String)
                strTemporaryFolder = Value
            End Set
        End Property

        'set templates folder
        Public WriteOnly Property TemplatesFolder() As String
            Set(ByVal Value As String)
                strTemplatesFolder = Value
            End Set
        End Property

        'set params
        Public Sub SetParams(ByVal ParamsField As ArrayList, ByVal ParamsValue As ArrayList)
            arrParamsField = ParamsField
            arrParamsValue = ParamsValue
        End Sub

        'set groups
        Public Sub SetGroups(ByVal GroupsField As ArrayList, ByVal GroupsDesciption As ArrayList)
            arrGroupsField = GroupsField
            arrGroupsDescp = GroupsDesciption
        End Sub

        'set sorts
        Public Sub SetSorts(ByVal SortsField As String)
            strSortsField = SortsField
        End Sub

        'set filters
        Public WriteOnly Property Filters() As String
            Set(ByVal Value As String)
                strFilters = Value
            End Set
        End Property


#End Region

#Region "other function"

        'copy file to temporary folder
        Public Function CopyTemplates(ByVal strSrcFolder As String, ByVal strDesFolder As String, ByVal strFileName As String) As String
            Dim srcName As String = strSrcFolder.Trim
            Dim desName As String = strDesFolder
            Dim unitID As String = ""
            Dim rand As Random = New Random

            'delete old file if too many file exits
            Dim files As String() = Directory.GetFiles(strDesFolder, "*.xls")
            Dim count As Integer = files.Length
            If count > 50 Then
                Dim i As Integer
                For i = 0 To count - 1 Step 1
                    If CType((DateTime.Now.Subtract(File.GetCreationTime(files(i)))), TimeSpan).Days > 1 Then
                        File.Delete(files(i))
                    End If
                Next
            End If
            files = Nothing

            If Not (srcName.Substring(srcName.Length - 1, 1) = "\") Then
                srcName += "\"
            End If
            If Not (desName.Substring(desName.Length - 1, 1) = "\") Then
                desName += "\"
            End If

            srcName += strFileName
            Try
                unitID = DateTime.Now.ToString.Replace("/", "")
                unitID = unitID.Replace(" ", "")
                unitID = unitID.Replace(":", "")
                unitID += rand.Next().ToString()
                desName += unitID + strFileName
                File.Copy(srcName, desName, True)
                File.SetAttributes(desName, FileAttributes.Normal)

                Return desName
            Catch e As Exception
                Return "Error " + e.Message
            End Try
        End Function

        'open popup window on server-side
        Public Shared Sub OpenFile(ByVal pPage As Page, ByVal sURL As String)
            Dim strFileName As String
            Dim strServerName As String = pPage.Request.ServerVariables("SERVER_NAME")
            Dim strInvalid As String = pPage.Server.MapPath(".")

            strFileName = pPage.Request.Url.AbsoluteUri
            strFileName = strFileName.Substring(0, strFileName.LastIndexOf("/"))
            strFileName = sURL.Replace(strInvalid, strFileName)
            strFileName = strFileName.Replace("\", "/")

            Dim strScript As String = "<script language=JavaScript>"
            strScript += "var win=window.open('" + strFileName + "','Recipient','status=1,toolbar=0,menubar=1,scrollbars=1,resizable=1,alwaysRaised=yes,top=10,left=10,width='+(screen.width-50)+',height='+(screen.height-50)+',1,align=center');"
            strScript += "</script>"
            If Not pPage.IsStartupScriptRegistered("clientScript") Then
                pPage.RegisterStartupScript("clientScript", strScript)
            End If
        End Sub

#End Region

#Region "report excel main"

        Public Function ToExcel(ByVal strFileName As String, ByVal strSQL As String, ByVal pPage As Page) As String
            Dim strConn As String = strSQLConnString
            Dim objAdapter As OleDbDataAdapter = New OleDbDataAdapter(strSQL, strConn)
            Dim dtbSQL As DataTable = New DataTable
            objAdapter.Fill(dtbSQL)
            objAdapter.Dispose()

            Return ToExcel(strFileName, dtbSQL, pPage)
        End Function

        Public Function ToExcel(ByVal strFileName As String, ByVal dtbSQL As DataTable, ByVal pPage As Page) As String
            'excel object references
            'Dim xlsApp As Excel.Application = New Excel.Application
            Dim xlsApp As Excel.Application = Nothing
            Dim objWBooks As Excel.Workbooks = Nothing
            Dim objWBook As Excel.Workbook = Nothing
            Dim objSheets As Excel.Sheets = Nothing
            Dim objWSheet As Excel.Worksheet = Nothing
            Dim objWSheet1 As Excel.Worksheet = Nothing
            Dim objRange As Excel.Range = Nothing
            Dim objRangeT As Excel.Range = Nothing

            Dim strExcelTableName As String = "DataTable"
            Dim cmd As OleDbCommand = Nothing
            Dim objAdapter As OleDbDataAdapter = Nothing
            Dim connExcel As OleDbConnection = Nothing
            Dim dsExcel As DataSet = Nothing
            Dim dtbExcel As DataTable = Nothing
            Dim i, k As Integer
            Dim strCols As String = ""
            Dim strParam As String = ""
            Dim strColName As String = ""
            Dim strGFields As String = ""
            Dim strGValue(4) As String
            Dim strGField(4) As String
            Dim strGDataF(4) As String
            Dim strGDataV(4) As String
            Dim intGStart(4) As Integer
            Dim intEndFixRow As Integer = 5 'end fix row in table params of excel param sheet
            Dim dtbG As DataTable = Nothing
            Dim dtbParams As DataTable = Nothing
            Dim dr As DataRow() = Nothing

            Try
                For i = 0 To strGField.Length - 1 Step 1
                    strGValue(i) = ""
                    strGField(i) = ""
                    intGStart(i) = 0
                    strGDataF(i) = ""
                    strGDataV(i) = ""
                Next

                'copy file excel sang temp folder
                Dim strExcelFile As String = CopyTemplates(strTemplatesFolder, strTemporaryFolder, strFileName)
                'exit if copy file error
                If strExcelFile.Trim.IndexOf("Error ", 0) = 0 Then
                    Return strExcelFile
                End If

                Dim strConnExcel As String = strExcelConnString
                Dim strSQL As String = ""
                Dim strSQLExcel As String = "Select top 1 * from " + strExcelTableName

                'open connection to excel file
                strConnExcel = strConnExcel.Replace("strExcelFile", strExcelFile)
                connExcel = New OleDbConnection(strConnExcel)
                connExcel.Open()
                'get excel format
                'get params table
                strSQLExcel = "Select * from Params"
                objAdapter = New OleDbDataAdapter(strSQLExcel, strConnExcel)
                dsExcel = New DataSet
                dtbParams = New DataTable("Params")
                objAdapter.Fill(dsExcel, dtbParams.TableName)
                dtbParams = dsExcel.Tables(dtbParams.TableName)

                'get group field name
                'default is groups in excel template file
                For i = 0 To strGField.Length - 1 Step 1
                    strGField(i) = dtbParams.Rows(i + intEndFixRow)("Type").ToString.Trim
                    strGDataF(i) = dtbParams.Rows(i + intEndFixRow)("RuntimeValue").ToString.Trim
                Next

                'if set group when run
                If arrGroupsField Is Nothing Then
                    arrGroupsField = New ArrayList
                End If
                If arrGroupsField.Count > 0 Then
                    If Not (arrGroupsField(0).ToString.Trim = "") Then
                        For i = 0 To strGField.Length - 1 Step 1
                            If i < arrGroupsField.Count Then
                                strGField(i) = arrGroupsField(i).ToString
                            Else
                                strGField(i) = ""
                            End If
                            If i < arrGroupsDescp.Count Then
                                strGDataF(i) = arrGroupsDescp(i).ToString
                            Else
                                strGDataF(i) = ""
                            End If
                        Next
                    End If
                End If

                'get column names in report table in excel file
                strSQLExcel = "Select top 1 * from " + strExcelTableName
                objAdapter = New OleDbDataAdapter(strSQLExcel, strConnExcel)
                objAdapter.Fill(dsExcel, strExcelTableName)

                dtbExcel = New DataTable
                dtbExcel = dsExcel.Tables(strExcelTableName)

                'get columns, build param for insert data in excel file
                For i = 0 To dtbExcel.Columns.Count - 1
                    strColName = dtbExcel.Columns(i).ColumnName.ToString
                    strCols += ",[" + strColName + "]"
                    strParam += ",?"
                Next
                strCols = strCols.Substring(1)
                strParam = strParam.Substring(1)

                'command to excel, buil insert statement
                cmd = New OleDbCommand
                cmd.Connection = connExcel
                strSQL = "Insert into " + strExcelTableName + " (" + strCols + ") Values (" + strParam + ")"

                'buil sort field for groups field
                strGFields = ""
                For i = 0 To strGField.Length - 1 Step 1
                    If Not (strGField(i) = "") Then
                        strGFields += ", " + strGField(i)
                    End If
                Next
                If Not (strGFields = "") Then
                    strGFields = strGFields.Substring(2)
                End If
                'sort string
                If Not (strSortsField.Trim = "") Then
                    If Not (strGFields = "") Then
                        strGFields += ", " + strSortsField
                    Else
                        strGFields += strSortsField
                    End If
                End If

                'filters
                dr = dtbSQL.Select(Microsoft.VisualBasic.IIf(Not (strFilters Is Nothing), strFilters, ""), strGFields)
                'set the first for group fields
                If dr.Length > 0 Then
                    For i = 0 To strGField.Length - 1 Step 1
                        If Not (strGField(i) = "") Then
                            strGValue(i) = dr(0)(strGField(i)).ToString.Trim
                        End If
                        If Not (strGDataF(i) = "") Then
                            strGDataV(i) = dr(0)(strGDataF(i)).ToString.Trim
                        End If
                    Next
                End If

                k = 0
                'insert data into excel file
                dtbG = InsertData(strSQL, cmd, objAdapter, connExcel, dtbExcel, dtbParams, dr, strGValue, strGField, strGDataF, strGDataV, intGStart, k)

                'format data and calculate group count
                FormatData(xlsApp, objWBooks, objWBook, objSheets, objWSheet, objWSheet1, objRange, objRangeT, strColName, dtbG, dtbParams, dr, strExcelFile, k)

                OpenFile(pPage, strExcelFile)
                Return ""
            Catch e As Exception
                Return e.Message
            Finally
                If Not (arrParamsField Is Nothing) Then
                    arrParamsField.Clear()
                End If
                arrParamsField = Nothing
                If Not (arrParamsValue Is Nothing) Then
                    arrParamsValue.Clear()
                End If
                arrParamsValue = Nothing
                If Not (arrGroupsField Is Nothing) Then
                    arrGroupsField.Clear()
                End If
                arrGroupsField = Nothing
                If Not (arrGroupsDescp Is Nothing) Then
                    arrGroupsDescp.Clear()
                End If
                arrGroupsDescp = Nothing

                strGValue = Nothing
                strGField = Nothing
                strGDataF = Nothing
                strGDataV = Nothing

                dr = Nothing
                If Not (cmd Is Nothing) Then
                    cmd.Dispose()
                End If
                cmd = Nothing
                If Not (objAdapter Is Nothing) Then
                    objAdapter.Dispose()
                End If
                objAdapter = Nothing
                If Not (connExcel Is Nothing) Then
                    connExcel.Dispose()
                End If
                connExcel = Nothing
                If Not (dsExcel Is Nothing) Then
                    dsExcel.Dispose()
                End If
                dsExcel = Nothing
                If Not (dtbSQL Is Nothing) Then
                    dtbSQL.Dispose()
                End If
                dtbSQL = Nothing
                If Not (dtbExcel Is Nothing) Then
                    dtbExcel.Dispose()
                End If
                dtbExcel = Nothing
                If Not (dtbG Is Nothing) Then
                    dtbG.Dispose()
                End If
                dtbG = Nothing

                Dim stemp As String = ""

                Try
                    objWBook.Close(objMissing, objMissing, objMissing)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    xlsApp.Quit()
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objRangeT)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWSheet1)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWSheet)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheets)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWBook)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWBooks)
                Catch e As Exception
                    stemp = e.Message
                End Try

                Try
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp)
                Catch e As Exception
                    stemp = e.Message
                End Try

                objRange = Nothing
                objRangeT = Nothing
                objWSheet = Nothing
                objWSheet1 = Nothing
                objSheets = Nothing
                objWBook = Nothing
                objWBooks = Nothing
                xlsApp = Nothing

                Try
                    System.GC.Collect() 'force final cleanup
                    GC.WaitForPendingFinalizers()
                Catch e As Exception
                    stemp = e.Message
                End Try
            End Try
        End Function

        Private Function InsertData(ByRef strSQL As String, ByRef cmd As OleDbCommand, ByRef objAdapter As OleDbDataAdapter, ByRef connExcel As OleDbConnection, ByRef dtbExcel As DataTable, ByRef dtbParams As DataTable, ByRef dr As DataRow(), ByRef strGValue As String(), ByRef strGField As String(), ByRef strGDataF As String(), ByRef strGDataV As String(), ByRef intGStart As Integer(), ByRef k As Integer) As DataTable
            Dim intStartGParamRow As Integer = 5 'start param row in excel of param sheet
            Dim dr1 As DataRow = Nothing
            Dim i, j As Integer

            'create table for group count
            Dim dtbG As DataTable = New DataTable("Group")
            dtbG.Columns.Add(New DataColumn("GLevelRow", Type.GetType("System.Int32")))
            dtbG.Columns.Add(New DataColumn("GValue", Type.GetType("System.String")))
            dtbG.Columns.Add(New DataColumn("StartRow", Type.GetType("System.Int32")))
            dtbG.Columns.Add(New DataColumn("EndRow", Type.GetType("System.Int32")))
            dtbG.Columns.Add(New DataColumn("GData", Type.GetType("System.String")))
            dtbG.Columns.Add(New DataColumn("GFValue", Type.GetType("System.String")))

            For i = 0 To dr.Length - 1 Step 1
                'set group information
                For k = 0 To strGField.Length - 1 Step 1
                    If Not (strGField(k) = "") Then
                        If Not (dr(i)(strGField(k)).ToString.Trim = strGValue(k)) Then
                            'save small group if had
                            If k < strGField.Length - 1 Then
                                For j = k + 1 To strGField.Length - 1 Step 1
                                    If Not (strGField(j) = "") Then
                                        dr1 = dtbG.NewRow
                                        dr1("GLevelRow") = intStartGParamRow + j 'set grop row in param table
                                        dr1("GValue") = strGValue(j)
                                        dr1("StartRow") = intGStart(j)
                                        dr1("EndRow") = i.ToString
                                        dr1("GData") = strGDataV(j)
                                        dr1("GFValue") = strGField(j)
                                        dtbG.Rows.Add(dr1)
                                        'reset value
                                        strGValue(j) = dr(i)(strGField(j)).ToString.Trim
                                        If Not (strGDataF(j) = "") Then
                                            strGDataV(j) = dr(i)(strGDataF(j)).ToString.Trim
                                        End If
                                        intGStart(j) = i
                                    End If
                                Next
                            End If
                            dr1 = dtbG.NewRow
                            dr1("GLevelRow") = intStartGParamRow + k 'set grop row in param table
                            dr1("GValue") = strGValue(k)
                            dr1("StartRow") = intGStart(k)
                            dr1("EndRow") = i.ToString
                            dr1("GData") = strGDataV(k)
                            dr1("GFValue") = strGField(k)
                            dtbG.Rows.Add(dr1)
                            'reset value
                            strGValue(k) = dr(i)(strGField(k)).ToString.Trim
                            If Not (strGDataF(k) = "") Then
                                strGDataV(k) = dr(i)(strGDataF(k)).ToString.Trim
                            End If
                            intGStart(k) = i
                        End If
                    End If
                Next

                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                For j = 0 To dtbExcel.Columns.Count - 1 Step 1
                    'if report has seq number
                    If dtbParams.Rows(4)("DataString").ToString.Trim.ToLower = "yes" AndAlso j = 0 Then
                        cmd.Parameters.Add("Seq", i + 1)
                    Else
                        Try
                            cmd.Parameters.Add(dtbExcel.Columns(j).ColumnName, dr(i)(dtbExcel.Columns(j).ColumnName))
                        Catch e As Exception
                            cmd.Parameters.Add(dtbExcel.Columns(j).ColumnName, "0")
                        End Try
                    End If
                Next
                cmd.ExecuteNonQuery()
            Next

            'set last row group information
            For k = 0 To strGField.Length - 1 Step 1
                If Not (strGField(k) = "") Then
                    'save small group if had
                    If k < strGField.Length - 1 Then
                        For j = k + 1 To strGField.Length - 1 Step 1
                            If Not (strGField(j) = "") Then
                                dr1 = dtbG.NewRow
                                dr1("GLevelRow") = intStartGParamRow + j 'set grop row in param table
                                dr1("GValue") = strGValue(j)
                                dr1("StartRow") = intGStart(j)
                                dr1("EndRow") = i.ToString
                                dr1("GData") = strGDataV(j)
                                dr1("GFValue") = strGField(j)
                                dtbG.Rows.Add(dr1)
                            End If
                        Next
                    End If

                    dr1 = dtbG.NewRow
                    dr1("GLevelRow") = intStartGParamRow + k 'set grop row in param table
                    dr1("GValue") = strGValue(k)
                    dr1("StartRow") = intGStart(k)
                    dr1("EndRow") = i.ToString
                    dr1("GData") = strGDataV(k)
                    dr1("GFValue") = strGField(k)
                    dtbG.Rows.Add(dr1)
                End If
            Next
            'release object
            cmd.Dispose()
            objAdapter.Dispose()
            connExcel.Close()
            connExcel.Dispose()

            Return dtbG
        End Function

        Private Sub FormatData(ByRef xlsApp As Excel.Application, ByRef objWBooks As Excel.Workbooks, ByRef objWBook As Excel.Workbook, ByRef objSheets As Excel.Sheets, ByRef objWSheet As Excel.Worksheet, ByRef objWSheet1 As Excel.Worksheet, ByRef objRange As Excel.Range, ByRef objRangeT As Excel.Range, ByRef strColName As String, ByRef dtbG As DataTable, ByRef dtbParams As DataTable, ByRef dr As DataRow(), ByRef strExcelFile As String, ByRef k As Integer)
            Dim i, j, m, n As Integer
            Dim intStartRow, intLastRow, intLastDataParamRow, intTotalRow As Integer
            Dim intEndFixRow As Integer = 5 'end fix row in table params of excel param sheet
            Dim strS1, strS2 As String

            'open workbook in excel
            xlsApp = New Excel.Application
            xlsApp.Visible = False
            xlsApp.DisplayAlerts = False
            'Start a new workbook 
            objWBooks = xlsApp.Workbooks
            Dim sV As String = xlsApp.Version
            objWBooks.Open(strExcelFile)

            objWBook = objWBooks.Item(1)
            objSheets = objWBook.Worksheets

            intLastDataParamRow = 10
            'get fix data for report
            'data field must in template file
            If arrParamsField Is Nothing Then
                arrParamsField = New ArrayList
            End If

            If arrParamsField.Count > 0 Then
                objWSheet = CType(objSheets.Item(2), Excel.Worksheet)
                objRange = objWSheet.Range("A1", objMissing)
                k = Int32.Parse(dtbParams.Rows(intEndFixRow + 5)("RowF").ToString)
                m = Int32.Parse(dtbParams.Rows(intEndFixRow + 5)("ColF").ToString)
                'pass all params list in excel file
                'check is params type is input data
                For i = intEndFixRow + 6 To dtbParams.Rows.Count - 1 Step 1
                    If dtbParams.Rows(i)("Type").ToString.Trim = "Data" Then
                        'check params runtime value
                        For j = 0 To arrParamsField.Count - 1 Step 1
                            If dtbParams.Rows(i)("Params").ToString.Trim.ToLower = arrParamsField(j).ToString.Trim.ToLower Then
                                objRange(k, m) = arrParamsValue(j)
                                k += 1
                            End If
                        Next
                        intLastDataParamRow = i
                    End If
                Next
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objWSheet)
            End If

            'finish get fix data for report
            'select sheet1 for process data
            objWSheet1 = CType((objSheets.Item(1)), Excel.Worksheet)
            'calculate start row, last row
            intStartRow = Int32.Parse(dtbParams.Rows(0)("RowF").ToString)
            'intToltalRow = dtbSQL.Rows.Count
            intTotalRow = dr.Length 'for filters data
            intLastRow = intTotalRow
            intLastRow += intStartRow - Int32.Parse(dtbParams.Rows(0)("RowF").ToString) + Int32.Parse(dtbParams.Rows(0)("RowT").ToString)

            'reformat field row
            strS1 = dtbParams.Rows(0)("RowT").ToString
            strS1 += ":" + strS1
            objRange = objWSheet1.Range(strS1, objMissing)
            objRange.Copy(objMissing)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
            'copy and paste format
            strS1 = dtbParams.Rows(0)("RowT").ToString.ToString + ":" + CType((Int32.Parse(dtbParams.Rows(0)("RowT").ToString) + intTotalRow).ToString, String)
            objRange = objWSheet1.Range(strS1, objMissing)
            objRange.PasteSpecial(Excel.XlPasteType.xlPasteFormats, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, False, False)

            objRangeT = objRange.Rows
            objRangeT.AutoFit()

            System.Runtime.InteropServices.Marshal.ReleaseComObject(objRangeT)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)

            'delete field row
            strS1 = dtbParams.Rows(0)("RowF").ToString + ":" + dtbParams.Rows(0)("RowT").ToString
            objRange = objWSheet1.Range(strS1, objMissing)
            objRange.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)

            'copy last row format
            strS1 = dtbParams.Rows(2)("RowF").ToString.Trim
            If Not (strS1 = "") Then
                'template
                objWSheet = CType((objSheets.Item(3)), Excel.Worksheet)
                objRange = objWSheet.Range(strS1 + ":" + strS1, objMissing)
                objRange.Copy(objMissing)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objWSheet)

                i = intStartRow + intTotalRow - 1
                strS1 = i.ToString
                objRange = objWSheet1.Range(strS1 + ":" + strS1, objMissing)
                objRange.PasteSpecial(Excel.XlPasteType.xlPasteFormats, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, objMissing, objMissing)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
            End If

            'copy footer
            strS1 = dtbParams.Rows(1)("RowF").ToString.Trim
            If Not (strS1 = "") Then
                strS2 = dtbParams.Rows(1)("RowT").ToString.Trim
                i = intStartRow + intTotalRow + Int32.Parse(dtbParams.Rows(1)("ColF").ToString)
                CopyRow(strS1, strS2, i, objWSheet, objSheets, objRange)
            End If

            'grandtotal/total row
            strS1 = dtbParams.Rows(3)("RowF").ToString.Trim
            If Not (strS1 = "") Then
                strS2 = dtbParams.Rows(3)("RowT").ToString.Trim
                i = intStartRow + intTotalRow
                CopyRow(strS1, strS2, i, objWSheet, objSheets, objRange)

                j = Int32.Parse(dtbParams.Rows(3)("ColF").ToString)
                strS2 = dtbParams.Rows(3)("DataString").ToString + ":" + intTotalRow.ToString
                strS1 = i.ToString
                objRange = objWSheet1.Range(strS1 + ":" + strS1, objMissing)
                objRange(1, j) = strS2
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)

                CalSum(intLastDataParamRow + 1, intStartRow + intTotalRow, intTotalRow, objWSheet1, dtbParams, objRange)
            End If

            'group data
            For i = dtbG.Rows.Count - 1 To 0 Step -1
                m = CType(dtbG.Rows(i)("GLevelRow"), Integer)
                strS1 = dtbParams.Rows(m)("RowF").ToString.Trim
                strS2 = strS1
                j = intStartRow + CType(dtbG.Rows(i)("EndRow"), Integer)
                CopyRow(strS1, strS2, j, objWSheet, objSheets, objRange)

                If Not (strS1 = "") Then
                    n = CType(dtbG.Rows(i)("GLevelRow"), Integer)
                    m = Int32.Parse(dtbParams.Rows(n)("ColF").ToString)
                    k = CType(dtbG.Rows(i)("StartRow"), Integer)
                    k = Int32.Parse(dtbG.Rows(i)("EndRow").ToString) - k

                    strS2 = ""
                    strS2 = CType(dtbG.Rows(i)("GValue"), String) 'total group value
                    strColName = CType(dtbG.Rows(i)("GData"), String) 'total group data
                    If Not (strColName = "") Then
                        strS2 += "-" + CType(dtbG.Rows(i)("GData"), String) 'total group data
                    End If
                    If strS2.Trim = "" Then
                        strS2 = dtbParams.Rows(n)("DataString").ToString 'defaul data of total(total:)
                    End If

                    If strS2.Trim = "" Then
                        strS2 = "Total" 'if havent't got defaul and data
                    End If
                    strS2 += ":" + k.ToString

                    objRange = objWSheet1.Range(j.ToString + ":" + j.ToString, objMissing)
                    objRange(1, m) = strS2

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
                End If
                CalSum(intLastDataParamRow + 1, j, k + 1, objWSheet1, dtbParams, objRange)
            Next

            'release excel
            objWSheet1.Activate()
            objRange = objWSheet1.Range("A10", objMissing)
            objRange.Select() 'last cell select
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)

            objWBook.Save()
            objWBook.Close()
            'release object
            xlsApp.Quit()
        End Sub

#End Region

#Region "support for excel function"

        Private Function CopyRow(ByVal strCopyF As String, ByVal strCopyT As String, ByVal intPasteRow As Integer, ByVal objWSheet As Excel.Worksheet, ByVal objSheets As Excel.Sheets, ByVal objRange As Excel.Range) As String
            Try
                If Not (strCopyF = "") Then
                    If strCopyT = "" Then
                        strCopyT = strCopyF
                    End If
                    'template
                    objWSheet = CType((objSheets.Item(3)), Excel.Worksheet)
                    objRange = objWSheet.Range(strCopyF + ":" + strCopyT, objMissing)
                    objRange.Copy(objMissing)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWSheet)

                    objWSheet = CType((objSheets.Item(1)), Excel.Worksheet)
                    objRange = objWSheet.Range(intPasteRow.ToString + ":" + intPasteRow.ToString, objMissing)

                    objRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, objMissing)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWSheet)
                End If
                Return ""
            Catch e As Exception
                Return e.Message
            End Try
        End Function

        Private Function CalSum(ByVal intParamRow As Integer, ByVal intDataRow As Integer, ByVal intTotalRow As Integer, ByVal objWSheet As Excel.Worksheet, ByVal dtbParams As DataTable, ByVal objRange As Excel.Range) As String
            Dim i, k As Integer
            Dim strS1, strS2 As String
            Dim strT As String = ""
            Try
                i = intParamRow
                While i < dtbParams.Rows.Count
                    strT = dtbParams.Rows(i)("RowF").ToString
                    If dtbParams.Rows(i)("Type").ToString.Trim.ToUpper = "SUM" AndAlso Int32.Parse(strT) > 0 Then
                        strT = dtbParams.Rows(i)("RowF").ToString
                        If Not (strT.Trim = "") Then
                            strT = "9" 'default is SUM
                        End If

                        strS1 = dtbParams.Rows(i)("DataString").ToString + intDataRow.ToString
                        k = intTotalRow - 1
                        If k < 1 Then
                            strS2 = "=SUBTOTAL(" + dtbParams.Rows(i)("RowF").ToString + ",R[-1]C)"
                        Else
                            strS2 = "=SUBTOTAL(" + dtbParams.Rows(i)("RowF").ToString + ",R[-" + k.ToString + "]C:R[-1]C)"
                        End If

                        objRange = objWSheet.Range(strS1, objMissing)
                        objRange.FormulaR1C1 = strS2
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(objRange)
                    End If
                    i += 1
                End While

                Return ""
            Catch e As Exception
                Return e.Message
            End Try
        End Function

#End Region

    End Class
End Namespace