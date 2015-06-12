Option Strict Off
Option Explicit Off
Imports System
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
'Imports PortalQH.Web.UI.WebControls
Imports System.Text

Imports PortalQH
Namespace CreateControlTool

    Public Class clsCreateControl
        Shared strDataKeyField As String = ""

        Public Sub New()
        End Sub

        'Create dynamic controls
        Public Shared Sub CreateControls(ByVal strTableName As String, ByVal objHtmlTable As HtmlTable, ByVal XMLFileName As String, ByVal grdList As DataGrid, ByVal btnUpdate As Button, ByVal btnCancel As Button, ByVal btnTroVe As Button, ByVal lblSoDong As Label, ByVal txtSoDong As TextBox)
            'Generate rows and cells
            Dim img As Image
            Dim hlk As HyperLink
            Dim obj As New Object
            Dim txt, txt1 As TextBox
            Dim ds As DataSet = New DataSet
            ds.ReadXml(XMLFileName)
            Dim dv As DataView = New DataView(ds.Tables(strTableName))
            Dim r As HtmlTableRow
            Dim c As HtmlTableCell

            For j As Integer = 0 To dv.Count - 1
                r = New HtmlTableRow
                Dim drw As DataRowView = dv(j)
                c = New HtmlTableCell
                c.Controls.Add(CreateLabel(drw))
                c.Width = "25%"
                c.VAlign = "middle"
                r.Cells.Add(c)
                c = Nothing
                c = New HtmlTableCell
                c.Controls.Add(CreateInputControls(drw))
                CreateValidateControl(drw, c)
                ''''''''''''''''''''''''''''
                If drw("ControlType").ToString.ToUpper = "DATETEXTBOX" And drw("Visible").ToString = "1" Then
                    img = New Image
                    CType(img, Image).ID = "btn" & drw("ID").ToString
                    CType(img, Image).Attributes.Add("runat", "server")
                    CType(img, Image).ImageUrl = "~/Images/calendar.gif"
                    CType(img, Image).CssClass = "QH_ImageButton"

                    hlk = New HyperLink
                    hlk.ID = "cmdCalendar" & drw("ID").ToString
                    hlk.CssClass = "CommandButton"
                    hlk.Attributes.Add("Runat", "server")
                    hlk.Controls.Add(img)
                    c.Controls.Add(New LiteralControl(" "))
                    c.Controls.Add(hlk)

                End If
                ''''''''''''''''''''''''''''
                c.Width = "75%"
                c.VAlign = "top"
                r.Cells.Add(c)
                c = Nothing
                objHtmlTable.Rows.Add(r)
            Next
            'kiem tra du lieu kieu ngay
            txt = CType(objHtmlTable.FindControl("txtTuNgay"), TextBox)
            hlk = CType(objHtmlTable.FindControl("cmdCalendarTuNgay"), HyperLink)

            If Not hlk Is Nothing And Not txt Is Nothing Then
                txt.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txt.ClientID & ");")
                Dim rightNow As DateTime = DateAdd(DateInterval.Month, -1, DateTime.Now)
                If Init Then
                    txt.Text = rightNow.ToString("dd/MM/yyyy")
                End If

                txt.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                hlk.NavigateUrl = AdminDB.InvokePopupCal(txt)
            End If
            txt = CType(objHtmlTable.FindControl("txtDenNgay"), TextBox)
            hlk = CType(objHtmlTable.FindControl("cmdCalendarDenNgay"), HyperLink)
            If Not hlk Is Nothing And Not txt Is Nothing Then
                txt.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txt.ClientID & ");")
                If Init Then
                    txt.Text = NgayHienTai()
                End If
                txt.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                hlk.NavigateUrl = AdminDB.InvokePopupCal(txt)
            End If
            'end kiem tra du lieu kieu ngay
            'kiem tra du lieu kieu so
            'For Each txt1 In objHtmlTable.Controls
            'Next
            'end kiem tra du lieu kieu so
        End Sub

        Private Shared Function CreateLabel(ByVal drw As DataRowView) As Label
            Dim lbl As Label = New Label
            lbl.Width = New Unit("100%")
            lbl.ID = "lbl" + drw("ID").ToString + "1"
            lbl.Text = drw("Description").ToString
            'If drw("IsNull").ToString.Trim = "1" Then
            '    lbl.CssClass = "Label"
            'Else
            '    lbl.CssClass = "Label"
            'End If
            lbl.Visible = Microsoft.VisualBasic.IIf(drw("Visible").ToString.Trim = "1", True, False)
            Return lbl
        End Function

        Private Shared Sub CreateValidateControl(ByVal drw As DataRowView, ByVal c As HtmlTableCell)
            If drw("IsNull").ToString.Trim = "1" Then
                Dim NameControl As String
                Dim obj As RequiredFieldValidator = New RequiredFieldValidator
                obj.ID = "rfv" + drw("ID").ToString
                obj.Attributes.Add("runat", "server")
                obj.ErrorMessage = "(<font color=#ff0000 size=2>*</font>)"
                Select Case drw("ControlType").ToString.ToUpper.Trim
                    Case "TEXTBOX", "DATETEXTBOX"
                        NameControl = "txt" + drw("ID").ToString
                        'break 
                    Case "DROPDOWNLIST"
                        NameControl = "ddl" + drw("ID").ToString
                        'break 
                    Case "CHECKBOXLIST"
                        NameControl = "ckl" + drw("ID").ToString
                        'break 
                    Case "CHECKBOX"
                        NameControl = "chk" + drw("ID").ToString
                        'break 
                    Case "RADIOBUTTON"
                        NameControl = "opt" + drw("ID").ToString
                        'break()
                    Case "RADIOBUTTONLIST"
                        NameControl = "rbl" + drw("ID").ToString
                        'break 
                End Select
                obj.ControlToValidate = NameControl
                c.Controls.Add(obj)
            End If
        End Sub

        Private Shared Function CreateInputControls(ByVal drw As DataRowView) As Control
            Dim obj As Control = New Control
            Select Case drw("ControlType").ToString.ToUpper
                Case "TEXTBOX", "DATETEXTBOX"
                    Dim obj1 As TextBox = New TextBox

                    obj1.ID = "txt" + drw("ID").ToString
                    obj1.Attributes.Add("runat", "server")

                    If drw("TextMode").ToString.Trim = "1" Then
                        obj1.TextMode = TextBoxMode.MultiLine
                    Else
                        If drw("TextMode").ToString.Trim = "2" Then
                            obj1.TextMode = TextBoxMode.Password
                        End If
                    End If

                    If Not (drw("Width").ToString = "") Then
                        obj1.Width = New Unit(drw("Width").ToString)
                    End If

                    'If drw("IsNumber").ToString.Trim = "1" Then
                    '    CType(obj1, TextBox).Attributes.Add("onblur", "javascript:CheckSoNguyen(" & obj1.ClientID & ");")
                    'End If


                    If drw("IsKey").ToString.Trim = "1" Then
                        strDataKeyField = drw("ID").ToString.Trim
                    End If

                    obj1.Visible = Microsoft.VisualBasic.IIf(drw("Visible").ToString.Trim = "1", True, False)
                    obj1.Enabled = Microsoft.VisualBasic.IIf(drw("Enabled").ToString.Trim = "1", True, False)

                    If obj1.ID = "txtMaLinhVucHidden" Then
                        obj1.Text = CType(HttpContext.Current.Session.Item("ItemCode"), String)
                    Else
                        obj1.Text = drw("DefaultValue").ToString
                    End If


                    obj1.CssClass = drw("CssClass").ToString
                    If Not (Convert.ToInt32(drw("MaxLength")) = 0) Then
                        obj1.MaxLength = Convert.ToInt32(drw("MaxLength"))
                    End If
                    obj = obj1
                Case "DROPDOWNLIST"
                    Dim obj2 As DropDownList = New DropDownList
                    obj2.ID = "ddl" + drw("ID").ToString
                    obj2.Attributes.Add("runat", "server")

                    If drw("IsKey").ToString.Trim = "1" Then
                        strDataKeyField = drw("ID").ToString.Trim
                    End If
                    If Not (drw("Width").ToString = "") Then
                        obj2.Width = New Unit(drw("Width").ToString)
                    End If
                    obj2.CssClass = drw("CssClass").ToString

                    BindControl.BindDropDownList_StoreProc(obj2, True, drw("DefaultValue").ToString.Trim, "sp_GetDanhMucCBO", ConfigurationSettings.AppSettings("commonDB"), drw("DataSource").ToString.Trim) ', CType(HttpContext.Current.Session.Item("ItemCode"), String)
                    'break 
                    obj = obj2
                Case "CHECKBOXLIST"
                    Dim obj3 As CheckBoxList = New CheckBoxList
                    obj3.ID = "ckl" + drw("ID").ToString
                    obj3.Attributes.Add("runat", "server")
                    If drw("IsKey").ToString.Trim = "1" Then
                        strDataKeyField = drw("ID").ToString.Trim
                    End If
                    obj3.RepeatDirection = RepeatDirection.Vertical
                    obj3.RepeatColumns = 2
                    If Not (drw("Width").ToString.Trim = "") Then
                        obj3.Width = New Unit(drw("Width").ToString)
                    End If

                    BindControl.BindCheckBoxList(obj3, drw("DataSource").ToString.Trim, drw("DefaultValue").ToString.Trim, Microsoft.VisualBasic.IIf(drw("Isnull").ToString.Trim = "1", True, False), -1)
                    obj = obj3
                Case "CHECKBOX"
                    Dim obj4 As CheckBox = New CheckBox
                    obj4.ID = "chk" + drw("ID").ToString
                    obj4.Attributes.Add("runat", "server")
                    If drw("IsKey").ToString.Trim = "1" Then
                        strDataKeyField = drw("ID").ToString.Trim
                    End If
                    obj4.Enabled = Microsoft.VisualBasic.IIf(drw("Enabled").ToString.Trim = "1", True, False)
                    obj4.Checked = True
                    obj = obj4
                    'break 
                Case "RADIOBUTTONLIST"
                    Dim obj5 As RadioButtonList = New RadioButtonList
                    obj5.ID = "ckl" + drw("ID").ToString
                    obj5.Attributes.Add("runat", "server")
                    If drw("IsKey").ToString.Trim = "1" Then
                        strDataKeyField = drw("ID").ToString.Trim
                    End If
                    obj5.RepeatDirection = RepeatDirection.Vertical
                    obj5.RepeatColumns = 2
                    If Not (drw("Width").ToString.Trim = "") Then
                        obj5.Width = New Unit(drw("Width").ToString)
                    End If

                    BindControl.BindRadioButtonList(obj5, drw("DataSource").ToString.Trim, drw("DefaultValue").ToString.Trim, Microsoft.VisualBasic.IIf(drw("Isnull").ToString.Trim = "1", True, False), -1)
                    'break 
                    obj = obj5
            End Select
            Return obj
        End Function

        Public Shared Function ReturnControlName(ByVal strName As String, ByVal strType As String) As String
            Dim strCtrlName As String = ""
            Select Case strType.Trim.ToUpper
                Case "TEXTBOX", "DATETEXTBOX"
                    strCtrlName = "txt" + strName.Trim
                    'break 
                Case "DROPDOWNLIST"
                    strCtrlName = "ddl" + strName.Trim
                    'break 
                Case "CHECKBOXLIST"
                    strCtrlName = "ckl" + strName.Trim
                    'break 
                Case "CHECKBOX"
                    strCtrlName = "chk" + strName.Trim
                    'break 
                Case "RADIOBUTTON"
                    strCtrlName = "opt" + strName.Trim
                    'break()
                Case "RADIOBUTTONLIST"
                    strCtrlName = "rbl" + strName.Trim
                    'break 
            End Select
            Return strCtrlName
        End Function

        Public Shared Function GetControlsofCatalog(ByVal strTableName As String, ByVal XMLFileName As String) As DataTable
            Try
                Dim ds As DataSet = New DataSet
                ds.ReadXml(XMLFileName)
                'Return ds.Tables(CInt(strTableName))
                Return ds.Tables(strTableName)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class
End Namespace