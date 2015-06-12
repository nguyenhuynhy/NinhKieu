'
'by AnhLH
'date May 13 2004
'
Imports System
Imports System.Web.Caching
Imports System.Reflection
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports System.IO
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports PortalQH.Web.UI.WebControls
Imports System.Web.UI


Namespace PortalQH

    '*********************************************************************
    '
    ' BindControl Class
    '
    ' Class that hydrates custom business objects with data
    '
    '*********************************************************************

    Public Class BindControl

        Public Shared Sub CreateControlsFromXMLFile(ByVal Request As HttpRequest, _
                                                ByVal strTableName As String, _
                                                ByVal objPage As Object, _
                                                ByRef objGrid As DataGrid, _
                                                ByRef objUpdate As ImageButton, _
                                                ByRef objCancel As ImageButton, _
                                                ByVal XMLFileName As String, _
                                                Optional ByRef objTroVe As ImageButton = Nothing)
            ' Create dynamic controls here.
            Dim i, j, k As Integer

            Const TOP As Integer = 170
            Const COL1 As Integer = 50 '100
            Const COL2 As Integer = 330 '420
            Dim intLeft, intTop As Integer
            Dim intLeftNext, intTopNext As Integer
            Dim strName As String
            Dim obj As Control
            Dim lbl As Label
           

            Dim ds As New DataSet
            ds.ReadXml(XMLFileName)


            k = 1
            For i = 0 To ds.Tables(strTableName).Rows.Count - 1
                If i <> 0 Then
                    Select Case ds.Tables(strTableName).Rows(i).Item("Crlf")
                        Case 0
                            intTop = TOP * k
                            intLeft = COL2 + 50 '150
                        Case Else
                            'k += 1
                            'intTop = TOP * k + 180
                            intTop = intTop + 25
                            intLeft = COL1 + 50 '150
                    End Select
                Else
                    'intTop = TOP * k + 180
                    intTop = TOP * k
                    intLeft = COL1 + 50 '150
                End If
                lbl = New Label
                lbl.ID = "lbl" & ds.Tables(strTableName).Rows(i).Item("ID").ToString
                lbl.Text = ds.Tables(strTableName).Rows(i).Item("Description").ToString
                lbl.Style("Position") = "Absolute"
                lbl.Style("Top") = intTop.ToString
                lbl.Style("Left") = intLeft.ToString
                lbl.CssClass = "QH_Label"
                CType(objPage, Control).Controls.Add(lbl)

                Select Case UCase(ds.Tables(strTableName).Rows(i).Item("ControlType").ToString)
                    Case "TEXTBOX"
                        obj = New TextBoxA
                        CType(obj, TextBox).ID = "txt" & ds.Tables(strTableName).Rows(i).Item("ID").ToString
                        CType(obj, TextBox).Style("Position") = "Absolute"
                        CType(obj, TextBox).Attributes.Add("runat", "server")
                        CType(obj, TextBox).Style("Top") = intTop.ToString
                        CType(obj, TextBox).Style("Left") = (intLeft + 100 + 40).ToString
                        If ds.Tables(strTableName).Rows(i).Item("TextMode").ToString <> "" Then
                            CType(obj, TextBox).TextMode = CType(ds.Tables(strTableName).Rows(i).Item("TextMode"), TextBoxMode)
                        End If
                        If ds.Tables(strTableName).Rows(i).Item("Width").ToString <> "" Then
                            CType(obj, TextBox).Width = New Unit((Val(ds.Tables(strTableName).Rows(i).Item("Width"))))
                        End If
                        CType(obj, TextBoxA).IsNull = CType(Val(ds.Tables(strTableName).Rows(i).Item("IsNull")), Boolean)
                        CType(obj, TextBoxA).IsKey = CType(Val(ds.Tables(strTableName).Rows(i).Item("IsKey")), Boolean)
                        CType(obj, TextBoxA).Visible = CType(Val(ds.Tables(strTableName).Rows(i).Item("Visible")), Boolean)
                        CType(obj, TextBoxA).IsNumber = CType(Val(ds.Tables(strTableName).Rows(i).Item("IsNumber")), Boolean)

                        CType(obj, TextBoxA).Enabled = CType(ds.Tables(strTableName).Rows(i).Item("Enabled"), Boolean)
                        CType(obj, TextBoxA).Text = CType(ds.Tables(strTableName).Rows(i).Item("DefaultValue"), String)
                        CType(obj, TextBoxA).CssClass = CType(ds.Tables(strTableName).Rows(i).Item("CssClass"), String)
                        If Val(ds.Tables(strTableName).Rows(i).Item("MaxLength")) <> 0 Then
                            CType(obj, TextBoxA).MaxLength = CType(ds.Tables(strTableName).Rows(i).Item("MaxLength"), Integer)
                        End If

                        CType(objPage, Control).Controls.Add(obj)
                    Case "DROPDOWNLIST"
                        obj = New DropDownList
                        CType(obj, DropDownList).ID = "cbo" & ds.Tables(strTableName).Rows(i).Item("ID").ToString
                        CType(obj, DropDownList).Style("Position") = "Absolute"
                        CType(obj, DropDownList).Attributes.Add("runat", "server")
                        CType(obj, DropDownList).Style("Top") = intTop.ToString
                        CType(obj, DropDownList).Style("Left") = (intLeft + 100 + 40).ToString
                        If ds.Tables(strTableName).Rows(i).Item("Width").ToString <> "" Then
                            CType(obj, DropDownList).Width = New Unit((Val(ds.Tables(strTableName).Rows(i).Item("Width"))))
                        End If
                        CType(objPage, Control).Controls.Add(obj)
                        BindControl.BindDropDownList(CType(obj, DropDownList), ds.Tables(strTableName).Rows(i).Item("DataSource").ToString, ds.Tables(strTableName).Rows(i).Item("DefaultValue").ToString, CType(ds.Tables(strTableName).Rows(i).Item("Isnull").ToString, Boolean))

                    Case "CHECKBOX"
                        obj = New CheckBox
                        CType(obj, CheckBox).ID = "chk" & ds.Tables(strTableName).Rows(i).Item("ID").ToString
                        CType(obj, CheckBox).Style("Position") = "Absolute"
                        CType(obj, CheckBox).Attributes.Add("runat", "server")
                        CType(obj, CheckBox).Style("Top") = intTop.ToString
                        CType(obj, CheckBox).Style("Left") = (intLeft + 100 + 40).ToString
                        CType(obj, CheckBox).Enabled = CType(Val(ds.Tables(strTableName).Rows(i).Item("Enabled")), Boolean)
                        CType(obj, CheckBox).Checked = True
                        CType(objPage, Control).Controls.Add(obj)
                End Select

            Next

            objUpdate.Style("Position") = "Absolute"
            objUpdate.Attributes.Add("runat", "server")
            objUpdate.Style("Top") = (intTop + 25).ToString
            objUpdate.Style("Left") = (intLeft + 100 + 40).ToString

            objCancel.Style("Position") = "Absolute"
            objCancel.Attributes.Add("runat", "server")
            objCancel.Style("Top") = (intTop + 25).ToString
            objCancel.Style("Left") = (intLeft + 100 + 80 + 70).ToString

            If Not objTroVe Is Nothing Then
                objTroVe.Style("Position") = "Absolute"
                objTroVe.Attributes.Add("runat", "server")
                objTroVe.Style("Top") = (intTop + 25).ToString
                objTroVe.Style("Left") = (intLeft + 100 + 80 + 70 + 110).ToString
            End If

         
            objGrid.Style("Position") = "Absolute"
            objGrid.Attributes.Add("runat", "server")
            objGrid.Style("Top") = (intTop + 50).ToString
            objGrid.Style("Left") = (intLeft - 25).ToString



        End Sub

        Public Shared Sub BindDropDownList(ByVal obj As DropDownList, ByVal strProcName As String, ByVal IsNull As Boolean, ByVal strDefaultValue As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID(strProcName, ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()

            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
            If IsNull = True Then
                obj.Items.Insert(0, New ListItem("", ""))
            End If
        End Sub

        Public Shared Sub BindDropDownList(ByVal obj As DropDownList, Optional ByVal strTableName As String = "", Optional ByVal strDefaultValue As String = "", Optional ByVal IsNull As Boolean = True, Optional ByVal intDefaultIndex As Integer = -1)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetDanhMucListCBO(strTableName, IsNull)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()


            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
            If intDefaultIndex <> -1 And obj.Items.Count > intDefaultIndex Then
                obj.SelectedIndex = intDefaultIndex
            End If
        End Sub
        Public Shared Sub BindDropDownList(ByVal obj As ProgStudios.WebControls.ComboBox, Optional ByVal strTableName As String = "", Optional ByVal strDefaultValue As String = "", Optional ByVal IsNull As Boolean = True, Optional ByVal intDefaultIndex As Integer = -1)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetDanhMucListCBO(strTableName, IsNull)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()


            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
            If intDefaultIndex <> -1 And obj.Items.Count > intDefaultIndex Then
                obj.SelectedIndex = intDefaultIndex
            End If
        End Sub



        Public Shared Sub BindDropDownList(ByVal obj As DropDownList, ByVal strProcName As String, ByVal strDefaultValue As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID(strProcName, ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()

            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
        End Sub
        Public Shared Sub BindCombobox(ByVal obj As ProgStudios.WebControls.ComboBox, ByVal strProcName As String, ByVal strDefaultValue As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID(strProcName, ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()

            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
        End Sub

        Public Shared Sub BindRadioButtonList(ByVal obj As RadioButtonList, ByVal ds As DataSet)

            obj.DataSource = ds
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()
            If obj.Items.Count > 0 Then
                obj.SelectedIndex = 0
            End If

        End Sub

        Public Shared Sub BindDropDownList_StoreProc(ByVal obj As DropDownList, ByVal All As Boolean, ByVal strDefaultValue As String, ByVal strStoreProc As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID(strStoreProc, ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"
            obj.DataBind()
            'ngantl upd
            Dim tmpItem As New ListItem
            tmpItem.Value = ""
            tmpItem.Text = ""
            If All = True Then
                obj.Items.Insert(0, tmpItem)
            End If

            If strDefaultValue <> "" Then
                obj.SelectedIndex = obj.Items.IndexOf(obj.Items.FindByValue(strDefaultValue))
            End If

        End Sub
        Public Shared Sub BindCheckBoxList(ByVal obj As CheckBoxList, Optional ByVal strTableName As String = "", Optional ByVal strDefaultValue As String = "", Optional ByVal IsNull As Boolean = True, Optional ByVal intDefaultIndex As Integer = -1)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetDanhMucListCBO(strTableName, IsNull)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()

            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
            If intDefaultIndex <> -1 And obj.Items.Count > intDefaultIndex Then
                obj.SelectedIndex = intDefaultIndex
            End If
        End Sub
        Public Shared Sub BindCheckBoxList(ByVal obj As CheckBoxList, ByVal strProcName As String, ByVal strDefaultValue As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID(strProcName, ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()


            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

        End Sub
        Public Shared Sub BindRadioButtonList(ByVal obj As RadioButtonList, ByVal strProcName As String, ByVal strDefaultValue As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID(strProcName, ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"

            obj.DataBind()


            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            Else
                If obj.Items.Count >= 0 Then
                    obj.SelectedIndex = 0
                End If
            End If
        End Sub


        Public Shared Sub BindDropDownListControls(ByVal obj As Object, ByVal arrDM As ArrayList, Optional ByVal IsNull As Boolean = False)
            Dim oControl As Control
            Dim i As Integer
            Dim dm As New DanhMucController

            For Each oControl In CType(obj, Control).Controls
                If TypeOf oControl Is DropDownList Then
                    For i = 0 To arrDM.Count - 1
                        If UCase(Mid(oControl.ID, 4)) = UCase(Mid(arrDM(i).ToString, 3)) Then
                            CType(oControl, DropDownList).DataSource = dm.GetDanhMucListCBO(arrDM(i).ToString)
                            CType(oControl, DropDownList).DataTextField = "Ten"
                            CType(oControl, DropDownList).DataValueField = "Ma"
                            CType(oControl, DropDownList).DataBind()
                            Exit For
                        End If
                    Next
                End If
            Next


        End Sub
        Public Shared Sub ddlNguoiSuDung_ByChucDanh(ByVal obj As DropDownList, ByVal strDefaultValue As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID("sp_GetUsersByChucDanh", ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"
            obj.DataBind()

            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
        End Sub

        Public Shared Sub BindDataGrid(ByVal ds As DataSet, _
                                        ByVal grdDataGrid As DataGrid, _
                                        ByVal colSTT As Boolean, _
                                        ByVal colDel As Boolean, _
                                        ByVal colEdit As Boolean, _
                                        ByVal colSTTName As String, _
                                        ByVal colDelName As String, _
                                        ByVal colEditName As String, _
                                        ByVal ImageUrl As String, _
                                        ByVal ParamArray ColWidth() As Object)
            Try

                Dim i As Integer
                Dim j As Integer
                Dim objtc As TemplateColumn
                Dim objbc As BoundColumn
                'Clear grid
                grdDataGrid.DataSource = Nothing
                grdDataGrid.DataBind()
                For i = 0 To grdDataGrid.Columns.Count - 1
                    grdDataGrid.Columns.RemoveAt(0)
                Next


                Dim dsTemp As DataSet
                Dim arrColWidth As New ArrayList

                'Default
                For i = 0 To ds.Tables(0).Columns.Count - 1
                    arrColWidth.Add(200)
                    For j = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Columns(i).ToString <> "URL" Then
                            ds.Tables(0).Rows(j)(i) = HttpUtility.HtmlEncode(ds.Tables(0).Rows(j)(i).ToString())
                        End If
                    Next
                Next
                'Set values
                For i = 0 To ColWidth.Length - 1
                    If i > ds.Tables(0).Columns.Count - 1 Then Exit For
                    If CType(ColWidth(i), Integer) <> -1 Then
                        arrColWidth(i) = ColWidth(i)
                    End If
                Next
                dsTemp = ds

                grdDataGrid.AutoGenerateColumns = False
                grdDataGrid.DataSource = dsTemp

                Dim cl As New DataColumn
                cl.ColumnName = colSTTName
                dsTemp.Tables(0).Columns.Add(cl)

                For i = 0 To dsTemp.Tables(0).Rows.Count - 1
                    dsTemp.Tables(0).Rows(i).Item(colSTTName) = i + 1
                Next
                If colSTT Then
                    objtc = New TemplateColumn
                    objtc.ItemTemplate = New DataGridTemplate(colSTTName, "LABEL")

                    objtc.HeaderText = colSTTName
                    objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    grdDataGrid.Columns.Add(objtc)
                    objtc = Nothing
                End If
                If colDel Then
                    objtc = New TemplateColumn
                    objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "CHECKBOX")
                    objtc.HeaderText = colDelName
                    objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    grdDataGrid.Columns.Add(objtc)
                    objtc = Nothing
                End If

                For i = 0 To ds.Tables(0).Columns.Count - 2

                    If UCase(ds.Tables(0).Columns(i).ToString) <> "URL" Then
                        objbc = New BoundColumn
                        objbc.DataField = ds.Tables(0).Columns(i).ToString

                        Dim strHeaderName As String
                        Select Case ds.Tables(0).Columns(i).ToString
                            Case "Ma"
                                strHeaderName = "Mã"
                                objbc.SortExpression = ds.Tables(0).Columns(i).ToString
                            Case "Ten"
                                strHeaderName = "Tên"
                                objbc.SortExpression = ds.Tables(0).Columns(i).ToString
                            Case Else
                                strHeaderName = ds.Tables(0).Columns(i).ToString
                        End Select

                        objbc.HeaderText = strHeaderName 'ds.Tables(0).Columns(i).ToString
                        If ColWidth.Length <> 0 Then
                            objbc.HeaderStyle.Width = Unit.Pixel(CInt(arrColWidth(i)))
                            objbc.ItemStyle.Width = Unit.Pixel(CInt(arrColWidth(i)))

                        End If
                        If CType(arrColWidth(i), Integer) = 0 Then
                            objbc.Visible = False
                        End If
                        grdDataGrid.Columns.Add(objbc)
                        objbc = Nothing
                    End If

                Next
                If colEdit Then
                    If Left(UCase(colEditName), 3) <> "URL" Then
                        objtc = New TemplateColumn
                        objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "IMAGEBUTTON", ImageUrl)
                        objtc.HeaderText = colEditName
                        objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                        grdDataGrid.Columns.Add(objtc)
                        objtc = Nothing
                    Else
                        objtc = New TemplateColumn
                        objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns("URL").ToString, "HYPERLINK", ImageUrl)
                        objtc.HeaderText = Mid(colEditName, 4)
                        objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                        grdDataGrid.Columns.Add(objtc)

                        objtc = Nothing
                    End If
                End If


                grdDataGrid.DataBind()

            Catch ex As Exception
                ProcessModuleLoadException(grdDataGrid, ex)
            End Try

        End Sub

        Public Shared Sub BindDataGrid(ByVal ds As DataSet, _
                                        ByVal grdDataGrid As DataGrid, _
                                        Optional ByVal intRows As Integer = 10)
            Dim intCol As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dsTemp As DataSet
                dsTemp = ds
                If ds.Tables(0).Rows.Count <> intRows And ds.Tables(0).Rows.Count < intRows Then
                    Dim dr As DataRow
                    Dim i, j As Integer
                    intCol = grdDataGrid.Columns.Count
                    If ds.Tables(0).Columns.Count < intCol Then
                        intCol = ds.Tables(0).Columns.Count
                    End If
                    For j = ds.Tables(0).Rows.Count To intRows - 1
                        dr = dsTemp.Tables(0).NewRow()
                        For i = 0 To intCol - 1
                            dr.Item(i) = DBNull.Value
                        Next
                        dsTemp.Tables(0).Rows.Add(dr)
                    Next

                End If
                grdDataGrid.DataSource = dsTemp
                grdDataGrid.DataBind()
            Else
                BindDataGridDefault(ds, grdDataGrid, intRows)
            End If

        End Sub
        Public Shared Sub BindDataGridDefault(ByVal ds As DataSet, _
                                        ByVal grdDataGrid As DataGrid, _
                                        Optional ByVal intRows As Integer = 10)
            Try
                Dim intCol As Integer
                Dim i, j As Integer
                Dim objtc As TemplateColumn
                Dim objbc As BoundColumn
                'Clear grid
                grdDataGrid.DataSource = ds
                grdDataGrid.DataBind()
                Dim dr As DataRow
                intCol = grdDataGrid.Columns.Count
                If ds.Tables(0).Columns.Count < intCol Then
                    intCol = ds.Tables(0).Columns.Count
                End If
                For j = 0 To intRows - 1
                    dr = ds.Tables(0).NewRow()
                    For i = 0 To intCol - 1
                        If i = 0 Then
                            dr.Item(i) = j
                        Else
                            dr.Item(i) = DBNull.Value
                        End If
                    Next
                    ds.Tables(0).Rows.Add(dr)
                Next

                grdDataGrid.DataBind()

                grdDataGrid.AlternatingItemStyle.ForeColor = Color.DarkBlue
                grdDataGrid.AlternatingItemStyle.BorderColor = Color.Black
                grdDataGrid.AlternatingItemStyle.BackColor = Color.AliceBlue
                grdDataGrid.HeaderStyle.Font.Bold = True
                grdDataGrid.HeaderStyle.ForeColor = Color.DarkBlue
            Catch ex As Exception
            Finally

            End Try

        End Sub

        'Created:NghiaDTQ
        'Date: 26 aug 2005
        Public Shared Sub BindGrdXacNhanHoSoVanHoa(ByVal ds As DataSet, _
                                ByVal grdDataGrid As DataGrid, _
                                ByVal colDel As Boolean, _
                                ByVal strHeader As String, _
                                ByVal strColWidth As String, _
                                Optional ByVal IsCheckAll As Boolean = True, _
                                Optional ByVal IsHyperLink As Boolean = True)
            Try
                Dim i As Integer
                Dim colBegin As Integer = 0
                Dim objtc As TemplateColumn
                Dim objbc As BoundColumn
                'Clear grid
                grdDataGrid.DataSource = Nothing
                grdDataGrid.DataBind()
                For i = 0 To grdDataGrid.Columns.Count - 1
                    grdDataGrid.Columns.RemoveAt(0)
                Next
                Dim dsTemp As DataSet
                Dim arrColWidth As New ArrayList
                Dim arrHeader As New ArrayList

                'Default

                For i = 0 To ds.Tables(0).Columns.Count - 1
                    arrColWidth.Add(200)
                Next
                For i = 0 To ds.Tables(0).Columns.Count - 1
                    arrHeader.Add(ds.Tables(0).Columns(i).ToString)
                Next
                'set value
                'Set values

                Dim strTemp As String
                Dim Pos As Int32
                If strHeader <> "" Then

                    strTemp = strHeader
                    i = 0
                    While strTemp.Length <> 0
                        Pos = InStr(strTemp, ",")
                        If Pos <> 0 Then
                            If Trim(Left(strTemp, Pos - 1)) <> "" Then
                                arrHeader(i) = Trim(Left(strTemp, Pos - 1))
                            End If
                            strTemp = Mid(strTemp, Pos + 1)
                            i += 1
                        Else
                            If Trim(strTemp) <> "" Then
                                arrHeader(i) = strTemp
                            End If
                            Exit While
                        End If
                    End While
                End If

                If strColWidth <> "" Then

                    strTemp = strColWidth
                    i = 0
                    While strTemp.Length <> 0
                        Pos = InStr(strTemp, ",")
                        If Pos <> 0 Then
                            If Trim(Left(strTemp, Pos - 1)) <> "" Then
                                arrColWidth(i) = Val(Trim(Left(strTemp, Pos - 1)))
                            End If
                            strTemp = Mid(strTemp, Pos + 1)
                            i += 1
                        Else
                            If Trim(strTemp) <> "" Then
                                arrColWidth(i) = Val(strTemp)
                            End If
                            Exit While
                        End If
                    End While
                End If

                dsTemp = ds

                grdDataGrid.AutoGenerateColumns = False
                grdDataGrid.DataSource = dsTemp

                Dim cl As New DataColumn
                cl.ColumnName = "STT"
                dsTemp.Tables(0).Columns.Add(cl)

                For i = 0 To dsTemp.Tables(0).Rows.Count - 1
                    dsTemp.Tables(0).Rows(i).Item("STT") = i + 1
                Next

                objtc = New TemplateColumn
                objtc.ItemTemplate = New DataGridTemplate("STT", "LABEL")
                objtc.HeaderText = "STT"
                objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                grdDataGrid.Columns.Add(objtc)
                objtc = Nothing

                If colDel Then
                    objtc = New TemplateColumn
                    If IsCheckAll Then
                        objtc.HeaderTemplate = New DataGridTemplate("", "CHECKBOXHEADER")
                    End If
                    objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "CHECKBOX")
                    objtc.HeaderText = "Chọn"
                    objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    grdDataGrid.Columns.Add(objtc)
                    objtc = Nothing
                End If
                If IsHyperLink Then
                    objtc = New TemplateColumn
                    objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "HYPERLINKTEXT")
                    objtc.HeaderText = arrHeader(0).ToString
                    objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    objtc.HeaderStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                    objtc.ItemStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                    grdDataGrid.Columns.Add(objtc)

                    objtc = Nothing
                    colBegin += 1
                End If
                Dim strColumnName As String

                For i = colBegin To ds.Tables(0).Columns.Count - 9 'undisplay 9 last columns
                    strColumnName = ds.Tables(0).Columns(i).ToString
                    Select Case strColumnName
                        Case "URL"
                            objtc = New TemplateColumn
                            objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "HYPERLINK")
                            objtc.HeaderText = ""
                            objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                            objtc.HeaderStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                            objtc.ItemStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                            grdDataGrid.Columns.Add(objtc)

                            objtc = Nothing
                        Case "STT"
                        Case Else
                            objbc = New BoundColumn
                            objbc.DataField = ds.Tables(0).Columns(i).ToString
                            objbc.HeaderText = CType(arrHeader(i), String)

                            objbc.HeaderStyle.Width = Unit.Pixel(CInt(arrColWidth(i)))
                            objbc.ItemStyle.Width = Unit.Pixel(CInt(arrColWidth(i)))
                            If CType(arrColWidth(i), Integer) = 0 Then
                                objbc.Visible = False
                            End If
                            grdDataGrid.Columns.Add(objbc)
                            objbc = Nothing
                    End Select

                Next
                grdDataGrid.DataBind()
                grdDataGrid.CssClass = "QH_DataGridBottom"
                grdDataGrid.AlternatingItemStyle.CssClass = "QH_DatagridAlternation"
                grdDataGrid.HeaderStyle.CssClass = "QH_DatagridHeader"
                If IsCheckAll Then
                    Dim chkAll As CheckBox
                    For i = 0 To grdDataGrid.Controls(0).Controls.Count - 1
                        chkAll = CType(grdDataGrid.Controls(0).Controls(i).FindControl("chkAll"), CheckBox)
                        If Not chkAll Is Nothing Then
                            chkAll.Attributes.Add("OnClick", "javascript: return select_deselectAll ('" & chkAll.ID & "');")
                        End If
                    Next


                End If
            Catch ex As Exception
                ProcessModuleLoadException(grdDataGrid, ex)
            End Try
        End Sub
        Public Shared Sub BindGrdHoSo(ByVal ds As DataSet, _
                                ByVal grdDataGrid As DataGrid, _
                                ByVal colDel As Boolean, _
                                ByVal strHeader As String, _
                                ByVal strColWidth As String, _
                                Optional ByVal IsCheckAll As Boolean = True, _
                                Optional ByVal IsHyperLink As Boolean = True, _
                                Optional ByVal isTTXuLy As Boolean = False)
            Try

                Dim i As Integer
                Dim j As Integer
                Dim colBegin As Integer = 0
                Dim objtc As TemplateColumn
                Dim objbc As BoundColumn
                'Clear grid
                grdDataGrid.DataSource = Nothing
                grdDataGrid.DataBind()
                For i = 0 To grdDataGrid.Columns.Count - 1
                    grdDataGrid.Columns.RemoveAt(0)
                Next

                Dim dsTemp As DataSet
                Dim arrColWidth As New ArrayList
                Dim arrHeader As New ArrayList

                'Default
                For i = 0 To ds.Tables(0).Columns.Count - 1
                    arrColWidth.Add(200)
                Next
                For i = 0 To ds.Tables(0).Columns.Count - 1
                    arrHeader.Add(ds.Tables(0).Columns(i).ToString)
                    For j = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Columns(i).ToString <> "URL" And isTTXuLy = False Then
                            ds.Tables(0).Rows(j)(i) = HttpUtility.HtmlEncode(ds.Tables(0).Rows(j)(i).ToString())
                        End If
                    Next
                Next
                'Set values

                Dim strTemp As String
                Dim Pos As Int32
                If strHeader <> "" Then

                    strTemp = strHeader
                    i = 0
                    While strTemp.Length <> 0
                        Pos = InStr(strTemp, ",")
                        If Pos <> 0 Then
                            If Trim(Left(strTemp, Pos - 1)) <> "" Then
                                arrHeader(i) = Trim(Left(strTemp, Pos - 1))
                            End If
                            strTemp = Mid(strTemp, Pos + 1)
                            i += 1
                        Else
                            If Trim(strTemp) <> "" Then
                                arrHeader(i) = strTemp
                            End If
                            Exit While
                        End If
                    End While
                End If

                If strColWidth <> "" Then

                    strTemp = strColWidth
                    i = 0
                    While strTemp.Length <> 0
                        Pos = InStr(strTemp, ",")
                        If Pos <> 0 Then
                            If Trim(Left(strTemp, Pos - 1)) <> "" Then
                                arrColWidth(i) = Val(Trim(Left(strTemp, Pos - 1)))
                            End If
                            strTemp = Mid(strTemp, Pos + 1)
                            i += 1
                        Else
                            If Trim(strTemp) <> "" Then
                                arrColWidth(i) = Val(strTemp)
                            End If
                            Exit While
                        End If
                    End While
                End If

                dsTemp = ds

                grdDataGrid.AutoGenerateColumns = False
                grdDataGrid.DataSource = dsTemp

                Dim cl As New DataColumn
                cl.ColumnName = "STT"
                dsTemp.Tables(0).Columns.Add(cl)

                For i = 0 To dsTemp.Tables(0).Rows.Count - 1
                    dsTemp.Tables(0).Rows(i).Item("STT") = i + 1
                Next

                objtc = New TemplateColumn
                objtc.ItemTemplate = New DataGridTemplate("STT", "LABEL")
                objtc.HeaderText = "STT"
                objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                grdDataGrid.Columns.Add(objtc)
                objtc = Nothing

                If colDel Then
                    objtc = New TemplateColumn
                    If IsCheckAll Then
                        objtc.HeaderTemplate = New DataGridTemplate("", "CHECKBOXHEADER")
                    End If
                    objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "CHECKBOX")
                    objtc.HeaderText = "Chọn"
                    objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    grdDataGrid.Columns.Add(objtc)
                    objtc = Nothing
                End If
                If IsHyperLink Then
                    objtc = New TemplateColumn
                    objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "HYPERLINKTEXT")
                    objtc.HeaderText = arrHeader(0).ToString
                    objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    objtc.HeaderStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                    objtc.ItemStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                    grdDataGrid.Columns.Add(objtc)

                    objtc = Nothing
                    colBegin += 1
                End If
                Dim strColumnName As String

                For i = colBegin To ds.Tables(0).Columns.Count - 3
                    strColumnName = ds.Tables(0).Columns(i).ToString
                    Select Case strColumnName
                        Case "URL"
                            objtc = New TemplateColumn
                            objtc.ItemTemplate = New DataGridTemplate(ds.Tables(0).Columns(0).ToString, "HYPERLINK")
                            objtc.HeaderText = ""
                            objtc.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                            objtc.HeaderStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                            objtc.ItemStyle.Width = Unit.Pixel(CInt(arrColWidth(0)))
                            grdDataGrid.Columns.Add(objtc)

                            objtc = Nothing
                        Case "STT"
                        Case Else
                            objbc = New BoundColumn
                            objbc.DataField = ds.Tables(0).Columns(i).ToString
                            objbc.HeaderText = CType(arrHeader(i), String)

                            objbc.HeaderStyle.Width = Unit.Pixel(CInt(arrColWidth(i)))
                            objbc.ItemStyle.Width = Unit.Pixel(CInt(arrColWidth(i)))
                            If CType(arrColWidth(i), Integer) = 0 Then
                                objbc.Visible = False
                            End If
                            grdDataGrid.Columns.Add(objbc)
                            objbc = Nothing
                    End Select

                Next

                grdDataGrid.DataBind()
                grdDataGrid.CssClass = "QH_DataGridBottom"
                grdDataGrid.AlternatingItemStyle.CssClass = "QH_DatagridAlternation"
                grdDataGrid.HeaderStyle.CssClass = "QH_DatagridHeader"
                If IsCheckAll Then
                    Dim chkAll As CheckBox
                    For i = 0 To grdDataGrid.Controls(0).Controls.Count - 1
                        chkAll = CType(grdDataGrid.Controls(0).Controls(i).FindControl("chkAll"), CheckBox)
                        If Not chkAll Is Nothing Then
                            chkAll.Attributes.Add("OnClick", "javascript: return select_deselectAll ('" & chkAll.ID & "');")
                        End If
                    Next


                End If
            Catch ex As Exception
                'ProcessModuleLoadException(grdDataGrid, ex)
            End Try
        End Sub

    End Class


    Public Class DataGridTemplate

        Implements ITemplate
        Private columnName As String
        Private ColumnType As String
        Private myImageUrl As String
        Private myDataSource As ArrayList

        'Private WithEvents lbl As Label
        Private lbl As Control

        '========================================================================================
        'Sub New - Constructor
        '========================================================================================
        Public Sub New(ByVal ColName As String, ByVal ColType As String, Optional ByVal ImageUrl As String = "")
            Me.columnName = ColName
            Me.ColumnType = ColType
            Me.myImageUrl = ImageUrl

        End Sub

        '========================================================================================
        'Sub InstantiateIn - From ITemplate
        '========================================================================================
        Private Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn

            Select Case UCase(ColumnType)
                Case "LABEL"
                    lbl = New Label
                    CType(lbl, Label).ID = "lblSTT"
                Case "CHECKBOX"
                    lbl = New CheckBox
                    CType(lbl, CheckBox).ID = "chkXoa"
                Case "CHECKBOXHEADER"
                    lbl = New CheckBox
                    CType(lbl, CheckBox).ID = "chkAll"
                    CType(lbl, CheckBox).Text = columnName
                Case "TEXTBOX"
                    lbl = New TextBox
                    CType(lbl, TextBox).ID = "txtTextBox"
                Case "DROPDOWNLIST"
                    lbl = New DropDownList
                    CType(lbl, DropDownList).ID = "ddlDropDownList"

                Case "IMAGEBUTTON"
                    lbl = New ImageButton
                    CType(lbl, ImageButton).ID = "imgEdit"
                    CType(lbl, ImageButton).CommandName = "Edit"
                Case "HYPERLINK", "HYPERLINKTEXT"
                    lbl = New HyperLink
                    CType(lbl, HyperLink).ID = "moreLink"

            End Select
            If ColumnType <> "CHECKBOXHEADER" Then
                AddHandler container.DataBinding, AddressOf BindDataCtrl
            End If
            container.Controls.Add(lbl)

        End Sub

        '========================================================================================
        'Sub BindDataCtrl - Data binding event
        '========================================================================================
        Private Sub BindDataCtrl(ByVal sender As Object, ByVal e As EventArgs) 'Handles lbl.DataBinding

            Dim container As DataGridItem = CType(lbl.NamingContainer, DataGridItem)
            Dim str As String = (CType(container.DataItem, DataRowView))(columnName).ToString()

            Select Case ColumnType
                Case "LABEL"
                    CType(lbl, Label).Text = HttpUtility.HtmlEncode(DataBinder.Eval(container.DataItem, columnName).ToString)
                Case "CHECKBOX"
                    CType(lbl, CheckBox).ToolTip = DataBinder.Eval(container.DataItem, columnName).ToString
                Case "TEXTBOX"
                    lbl = New TextBox
                    CType(lbl, TextBox).Text = DataBinder.Eval(container.DataItem, columnName).ToString
                Case "DROPDOWNLIST"
                    lbl = New DropDownList
                    CType(lbl, DropDownList).DataSource = myDataSource
                    CType(lbl, DropDownList).SelectedValue = DataBinder.Eval(container.DataItem, columnName).ToString

                Case "IMAGEBUTTON"
                    CType(lbl, ImageButton).ImageUrl = myImageUrl
                Case "HYPERLINK"
                    CType(lbl, HyperLink).ImageUrl = myImageUrl
                    CType(lbl, HyperLink).NavigateUrl = CType(DataBinder.Eval(container.DataItem, columnName), String)
                    CType(lbl, HyperLink).Target = "_blank"
                    CType(lbl, HyperLink).Visible = CType(DataBinder.Eval(container.DataItem, columnName), String) <> String.Empty
                Case "HYPERLINKTEXT"
                    CType(lbl, HyperLink).Text = DataBinder.Eval(container.DataItem, columnName).ToString
                    CType(lbl, HyperLink).NavigateUrl = CType(DataBinder.Eval(container.DataItem, "URL"), String)
            End Select

        End Sub

    End Class
    Public Class ItemLists

        Private _Field As String
        Private _Name As String
        Private _Width As Integer
        Private _DataSource As ArrayList
        Private _Type As String

        Public Sub New(ByVal Field As String, ByVal Name As String, ByVal Type As String, _
                        ByVal Width As Integer, ByVal DataSource As ArrayList)
            MyBase.New()
            _Field = Field
            _Name = Name
            _Width = Width
            _DataSource = DataSource
            _Type = Type
        End Sub

        Public ReadOnly Property Code() As String
            Get
                Return _Field
            End Get
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return _Name
            End Get
        End Property
        Public ReadOnly Property width() As Integer
            Get
                Return _Width
            End Get
        End Property

        Public ReadOnly Property DataSource() As ArrayList
            Get
                Return _DataSource
            End Get
        End Property
        Public ReadOnly Property Type() As String
            Get
                Return _Type
            End Get
        End Property

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
    

End Namespace