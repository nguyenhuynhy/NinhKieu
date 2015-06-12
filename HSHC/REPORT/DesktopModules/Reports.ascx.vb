Option Strict Off
Imports System.Configuration
Imports System.Data.OleDb

Public Class Reports
    Inherits System.Web.UI.UserControl
    Private strTableName As String
    Dim valueGrp1, valueGrp2, valueGrp3 As String
    Dim valueDes1, valueDes2, valueDes3 As String
    Dim valueSrt1, valueSrt2, valueSrt3 As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErr As System.Web.UI.WebControls.Label
    Protected WithEvents btnPreview As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents grp1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents grp2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents grp3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents des1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents des2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents des3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents sort1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents sort2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents sort3 As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Sub Load_Page(ByVal TabID As String)
        lblErr.Text = ""
        Try
            If Not TabID Is Nothing Then
                strTableName = TabID.Trim
                CreateControlTool.clsCreateControl.CreateControls(strTableName, Table2, Server.MapPath(".") & "\" & CType(Session.Item("ActiveDB"), String) & ConfigurationSettings.AppSettings("pstrPathReportsXML"), New DataGrid, Nothing, Nothing, Nothing, New Label, Nothing)
            End If
            GetValueGroup()
            LoadCombos()
            SetValueGroup()
        Catch
            lblErr.Text = "Báo cáo này hiện không tồn tại!"
        End Try
        Session("TabID") = strTableName
    End Sub

    Private Sub GetValueGroup()
        If grp1.Items.Count > 0 Then
            valueGrp1 = grp1.SelectedValue
        End If
        If grp2.Items.Count > 0 Then
            valueGrp2 = grp2.SelectedValue
        End If
        If grp3.Items.Count > 0 Then
            valueGrp3 = grp3.SelectedValue
        End If

        If des1.Items.Count > 0 Then
            valueDes1 = des1.SelectedValue
        End If
        If des2.Items.Count > 0 Then
            valueDes2 = des3.SelectedValue
        End If
        If des3.Items.Count > 0 Then
            valueDes3 = des3.SelectedValue
        End If

        If sort1.Items.Count > 0 Then
            valueSrt1 = sort1.SelectedValue
        End If
        If sort2.Items.Count > 0 Then
            valueSrt2 = sort2.SelectedValue
        End If
        If sort3.Items.Count > 0 Then
            valueSrt3 = sort3.SelectedValue
        End If
    End Sub

    Sub BindDdl(ByRef Ddl As DropDownList, Optional ByVal ItemSelected As String = "")
        Dim i As Integer
        If Ddl.Items.Count > 0 Then
            For i = Ddl.Items.Count - 1 To 1 Step -1
                If Ddl.Items(i).Value = ItemSelected Then
                    Ddl.Items(i).Selected = True
                End If
            Next
        End If
    End Sub

    Private Sub SetValueGroup()
        If grp1.Items.Count > 0 Then
            BindDdl(grp1, valueGrp1)
        End If
        If grp2.Items.Count > 0 Then
            BindDdl(grp2, valueGrp2)
        End If
        If grp3.Items.Count > 0 Then
            BindDdl(grp3, valueGrp3)
        End If

        If des1.Items.Count > 0 Then
            BindDdl(des1, valueDes1)
        End If
        If des2.Items.Count > 0 Then
            BindDdl(des2, valueDes2)
        End If
        If des3.Items.Count > 0 Then
            BindDdl(des3, valueDes3)
        End If

        If sort1.Items.Count > 0 Then
            BindDdl(sort1, valueSrt1)
        End If
        If sort2.Items.Count > 0 Then
            BindDdl(sort2, valueSrt2)
        End If
        If sort3.Items.Count > 0 Then
            BindDdl(sort3, valueSrt3)
        End If
    End Sub

    'Get value of control
    Private Function GetValueControl(ByVal strControlName As String, Optional ByVal flgText As Boolean = False) As String
        Dim strReturnValue As String = ""
        Try
            Dim ctrFound As Control = FindControl(strControlName)

            If Not (ctrFound Is Nothing) Then
                Dim strType As String = ctrFound.GetType.ToString.Trim.Substring(ctrFound.GetType.ToString.Trim.LastIndexOf(".") + 1).ToString.Trim
                Select Case strType
                    Case "TextBox", "DateTextBox"
                        strReturnValue = CType(ctrFound, TextBox).Text
                        'break 
                    Case "DropDownList"
                        If flgText = False Then
                            strReturnValue = CType(ctrFound, DropDownList).SelectedValue.Trim
                        Else
                            strReturnValue = CType(ctrFound, DropDownList).SelectedItem.Text
                        End If

                        'break 
                    Case "RadioButtonList"
                        strReturnValue = CType(ctrFound, RadioButtonList).SelectedValue.Trim
                        'break 
                    Case "CheckBox"
                        strReturnValue = CType(ctrFound, CheckBox).Checked.ToString
                        'break 
                    Case "RadioButton"
                        strReturnValue = CType(ctrFound, RadioButton).Checked.ToString
                        'break
                    Case Else
                        'break 
                End Select
            End If
        Catch ex As Exception
            Return ""
        End Try
        Return strReturnValue
    End Function

    Private Sub LoadCombos()
        'GET STORE NAME
        Dim XMLFileName As String = Server.MapPath(".") & "\" & CType(Session.Item("ActiveDB"), String) & ConfigurationSettings.AppSettings("pstrPathReportsXML")
        Dim ds As DataSet = New DataSet
        ds.ReadXml(XMLFileName)
        Dim strStoreProcedureName As String = "EXEC "
        '== NamTH update===='
        strStoreProcedureName += ds.Tables(strTableName).Rows(ds.Tables(strTableName).Rows.Count - 1)("ID").ToString
        'strStoreProcedureName += ds.Tables(CInt(strTableName)).Rows(ds.Tables(CInt(strTableName)).Rows.Count - 1)("ID").ToString
        'Session("TabID") = ds.Tables(CInt(strTableName)).Rows(ds.Tables(CInt(strTableName)).Rows.Count - 1)("ID").ToString
        'LOAD GROUPS, DESCRIPTIONS, SORTS COMBOS
        Dim strOleConnString As String = ConfigurationSettings.AppSettings("pstrConnSQLExcelReport" & CType(Session.Item("ActiveDB"), String))

        Dim tblSchema As DataTable = GetTableSchema(strOleConnString, strStoreProcedureName)

        'CREATE GROUPS - DESCRIPTIONS - SORTS COMBOS
        grp1.Items.Clear()
        grp2.Items.Clear()
        grp3.Items.Clear()
        'grp4.Items.Clear()
        'grp5.Items.Clear()
        des1.Items.Clear()
        des2.Items.Clear()
        des3.Items.Clear()
        'des4.Items.Clear()
        'des5.Items.Clear()
        sort1.Items.Clear()
        sort2.Items.Clear()
        sort3.Items.Clear()
        'sort4.Items.Clear()
        'sort5.Items.Clear()

        grp1.Items.Add("")
        grp2.Items.Add("")
        grp3.Items.Add("")
        'grp4.Items.Add("")
        'grp5.Items.Add("")
        des1.Items.Add("")
        des2.Items.Add("")
        des3.Items.Add("")
        'des4.Items.Add("")
        'des5.Items.Add("")
        sort1.Items.Add("")
        sort2.Items.Add("")
        sort3.Items.Add("")
        'sort4.Items.Add("")
        'sort5.Items.Add("")
        For index As Integer = 0 To tblSchema.Rows.Count - 1
            'GROUPS
            grp1.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            grp2.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            grp3.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            'grp4.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            'grp5.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)

            des1.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            des2.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            des3.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            'des4.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)
            'des5.Items.Add(tblSchema.Rows(index)("ColumnName").ToString)

            sort1.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " ASC")
            sort1.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " DESC")
            sort2.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " ASC")
            sort2.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " DESC")
            sort3.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " ASC")
            sort3.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " DESC")
            'sort4.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " ASC")
            'sort4.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " DESC")
            'sort5.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " ASC")
            'sort5.Items.Add(tblSchema.Rows(index)("ColumnName").ToString + " DESC")
        Next

        tblSchema.Dispose()
        tblSchema = Nothing
        ds.Dispose()
        ds = Nothing
    End Sub

    Private Function GetTableSchema(ByVal strConn As String, ByVal strSQL As String) As DataTable
        Dim conn As OleDbConnection = Nothing

        Dim cmd As OleDbCommand = Nothing
        Dim myReader As OleDbDataReader
        Try
            conn = New OleDbConnection(strConn)
            conn.Open()
            cmd = New OleDbCommand(strSQL, conn)

            myReader = cmd.ExecuteReader(CommandBehavior.SchemaOnly)
            Return myReader.GetSchemaTable
        Catch ex As Exception
            Return Nothing
        Finally 'release onbject
            myReader = Nothing
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
        End Try
    End Function

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim dtList As DataTable = New DataTable
        Dim strCtrlName As String = ""
        Dim strTemp As String = ""

        strTableName = Session("TabID")
        dtList = CreateControlTool.clsCreateControl.GetControlsofCatalog(strTableName, Server.MapPath(".") & "\" & CType(Session.Item("ActiveDB"), String) & ConfigurationSettings.AppSettings("pstrPathReportsXML"))

        Dim strFileName As String = dtList.Rows(dtList.Rows.Count - 1)("ReportName").ToString.Trim
        If Not (strFileName.IndexOf(".xls") = -1) Then
            Dim arrParams As ArrayList = New ArrayList
            Dim arrValues As ArrayList = New ArrayList
            Dim arrGroups As ArrayList = New ArrayList
            Dim arrGroupDescripts As ArrayList = New ArrayList
            Dim arrGroupSorts As String = ""
            Dim strStoreInputs As String = ""

            For i As Integer = 0 To dtList.Rows.Count - 2
                'CHECK IF IT'S PARAM
                If dtList.Rows(i)("IsParam").ToString.Trim.ToLower = "true" Then
                    arrParams.Add(dtList.Rows(i)("ID").ToString.Trim)
                    strCtrlName = CreateControlTool.clsCreateControl.ReturnControlName(dtList.Rows(i)("ID").ToString, dtList.Rows(i)("ControlType").ToString)
                    arrValues.Add(GetValueControl(strCtrlName, True))
                    'arrValues.Add(PortalQH.GetControlValues(strCtrlName, Me))
                End If
                If dtList.Rows(i)("IsWhere").ToString.Trim.ToLower = "true" Then
                    strCtrlName = CreateControlTool.clsCreateControl.ReturnControlName(dtList.Rows(i)("ID").ToString, dtList.Rows(i)("ControlType").ToString)
                    If Not (GetValueControl(strCtrlName).Trim = "") Then
                        strStoreInputs += " ,@p" + dtList.Rows(i)("ID").ToString + " = N'" + GetValueControl(strCtrlName).Trim + "' "
                    End If
                End If
            Next
            'GROUPS AND SORTS
            If Not (grp1.SelectedValue = "") Then
                arrGroups.Add(grp1.SelectedValue)
                arrGroupDescripts.Add(des1.SelectedValue)
            End If
            If Not (grp2.SelectedValue = "") Then
                arrGroups.Add(grp2.SelectedValue)
                arrGroupDescripts.Add(des2.SelectedValue)
            End If
            If Not (grp3.SelectedValue = "") Then
                arrGroups.Add(grp3.SelectedValue)
                arrGroupDescripts.Add(des3.SelectedValue)
            End If
            'If Not (grp4.SelectedValue = "") Then
            '    arrGroups.Add(grp4.SelectedValue)
            '    arrGroupDescripts.Add(des4.SelectedValue)
            'End If
            'If Not (grp5.SelectedValue = "") Then
            '    arrGroups.Add(grp5.SelectedValue)
            '    arrGroupDescripts.Add(des5.SelectedValue)
            'End If

            'SORTS
            If Not (sort1.SelectedValue = "") Then
                arrGroupSorts += sort1.SelectedValue + ","
            End If
            If Not (sort2.SelectedValue = "") Then
                arrGroupSorts += sort2.SelectedValue + ","
            End If
            If Not (sort3.SelectedValue = "") Then
                arrGroupSorts += sort3.SelectedValue + ","
            End If
            'If Not (sort4.SelectedValue = "") Then
            '    arrGroupSorts += sort4.SelectedValue + ","
            'End If
            'If Not (sort5.SelectedValue = "") Then
            '    arrGroupSorts += sort5.SelectedValue + ","
            'End If

            If Not (arrGroupSorts = "") Then
                arrGroupSorts = arrGroupSorts.Remove(arrGroupSorts.Length - 1, 1)
            End If

            Dim exr1 As ExcelReportTool.clsExcelReport = New ExcelReportTool.clsExcelReport
            exr1.SQLConnString = ConfigurationSettings.AppSettings("pstrConnSQLExcelReport" + CType(Session.Item("ActiveDB"), String))
            exr1.ExcelConnString = ConfigurationSettings.AppSettings("pstrConnExcel")

            strTemp = Server.MapPath(".") + "\" & CType(Session.Item("ActiveDB"), String) & ConfigurationSettings.AppSettings("pstrTemplatesFolderBaoCao") & CType(Session.Item("ItemCode"), String) & "\"
            'strTemp += dtList.Rows(dtList.Rows.Count - 1)("Description").ToString.Trim
            exr1.TemplatesFolder = strTemp
            exr1.TemporaryFolder = Server.MapPath(".") & "\" + CType(Session.Item("ActiveDB"), String) & ConfigurationSettings.AppSettings("pstrDataReportsFolderBaoCao") & CType(Session.Item("ItemCode"), String) & "\"

            exr1.SetParams(arrParams, arrValues)
            exr1.SetGroups(arrGroups, arrGroupDescripts)
            exr1.SetSorts(arrGroupSorts)

            Dim strStoreName As String = dtList.Rows(dtList.Rows.Count - 1)("ID").ToString.Trim

            If Not (strStoreInputs = "") Then
                strStoreInputs = " " + strStoreInputs.Substring(2)
            End If
            strStoreName += strStoreInputs

            lblErr.Text = exr1.ToExcel(strFileName, strStoreName, Me.Page)
            exr1 = Nothing
        End If
        dtList.Dispose()
    End Sub
End Class

