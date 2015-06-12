﻿Imports PortalQH
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Web.Mail
Imports System.Text
Imports System.Net
Imports PortalQH.Web.UI.WebControls
Imports System.Data
Imports System.Security.Cryptography
Namespace CPKTQH
    Public Module Globals
        Public Const glbXMLFile As String = "CPKTQH\XMLFILE\GLOBAL.xml"
        Public Const glbFilePath_BangHieu As String = "CPKTQH/DesktopModules/DanhSachGiayCNDKKDPage.aspx"
        Public Const HS_CAPMOICNDKKD As String = "CAPMOICNDKKD"
        Public Const HS_THAYDOIDKKD As String = "THAYDOIDKKD"
        Public Const HS_HOSOKHONG As String = "HOSOKHONG"
        Public Const HS_HUYCNDKKD As String = "HUYCNDKKD"
        Public Const HS_DONVITRUCTHUOC As String = "DONVITRUCTHUOC"
        Public glbNgayKiemTraHetHanGiayPhep As String

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

        Public Sub BindDropDownList_NguoiKy(ByVal ddlNguoiKy As DropDownList)
            Dim strNguoiKy As String
            strNguoiKy = GetParamByID("nguoiky", glbXMLFile)
            BindControl.BindDropDownList(ddlNguoiKy, "sp_GetUsersByChucDanh", "", strNguoiKy, 1) '1: lay mot item rong
        End Sub
        Public Sub BindCombobox_NguoiKy(ByVal ddlNguoiKy As ProgStudios.WebControls.ComboBox)
            Dim strNguoiKy As String
            strNguoiKy = GetParamByID("nguoiky", glbXMLFile)
            BindControl.BindCombobox(ddlNguoiKy, "sp_GetUsersByChucDanh", "", strNguoiKy, 1)  '1: lay mot item rong
        End Sub
        Public Sub BindDropDownList_ChuyenVienPhongBan(ByVal ddl As DropDownList)
            Dim strMaPhongBan As String
            strMaPhongBan = GetParamByID("maphongban", glbXMLFile)
            BindControl.BindDropDownList(ddl, "sp_GetUsersByPhongBan", "", strMaPhongBan, 1) '1: lay mot item rong
        End Sub
        Public Function GetSoDongHienThiLuoi() As Integer
            Return CType(GetParamByID("SoDongHienThiDatagrid", glbXMLFile), Integer)
        End Function
        Public Sub BindGrdInBanSao(ByVal ds As DataSet, _
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

                Dim c2 As New DataColumn
                c2.ColumnName = "TienBangChu"
                dsTemp.Tables(0).Columns.Add(c2)

                Dim strVon As String
                For i = 0 To dsTemp.Tables(0).Rows.Count - 1
                    strVon = dsTemp.Tables(0).Rows(i).Item("VonKinhDoanh").ToString
                    strVon = Replace(Replace(strVon, ".", ""), ",", ".")
                    dsTemp.Tables(0).Rows(i).Item("TienBangChu") = Trim(Trans_VietNam(Val(strVon)).ToString)
                Next

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

                'For i = colBegin To ds.Tables(0).Columns.Count - 3
                For i = colBegin To ds.Tables(0).Columns.Count - 1
                    strColumnName = ds.Tables(0).Columns(i).ToString
                    Select Case strColumnName
                        Case "URL"
                        Case "STT"
                        Case "TienBangChu"
                            objbc = New BoundColumn
                            objbc.DataField = ds.Tables(0).Columns(i).ToString
                            objbc.HeaderText = "Vốn kinh doanh"
                            objbc.HeaderStyle.Width = Unit.Pixel(CInt(200))
                            objbc.ItemStyle.Width = Unit.Pixel(CInt(200))

                            grdDataGrid.Columns.Add(objbc)
                            objbc = Nothing
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
        Public Function GetLinhVuc() As String
            Return ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(HttpContext.Current.Session.Item("ActiveDB"), String))
        End Function

        Public Function GetReportPath(ByVal pMaLinhVuc As String) As String
            Return ConfigurationSettings.AppSettings("ReportPath" & pMaLinhVuc)
        End Function

        Public Function getSoNgayLoc(ByVal request As HttpRequest) As Integer
            Dim mSoNgay As Integer

            mSoNgay = CType(GetValueItem(request, "SoNgayLoc", glbXMLFile), Integer)
            Return mSoNgay
        End Function

        Public Function SuDungDangKyQuaMang() As Boolean
            Return CBool(ConfigurationSettings.AppSettings("UseDangKyQuaMang"))
        End Function

        Public Function getControlCapMoiCNDKKD() As String
            Return GetParamByID("ControlCapMoiCNDKKD", glbXMLFile)
        End Function

        Public Function getControlCapDoiCNDKKD() As String
            Return GetParamByID("ControlCapDoiCNDKKD", glbXMLFile)
        End Function

        'ThuyTT add date 16/01/2006
        Public Function getTienVonMin() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "TienVonMin")
            If strResult = "" Then strResult = "null"
            Return strResult
        End Function
        Public Function getTienVonMax() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "TienVonMax")
            If strResult = "" Then strResult = "null"
            Return strResult
        End Function
        Public Function getSoKiSoThapPhan() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "SoKiSoThapPhan")
            If strResult = "" Then strResult = "null"
            Return strResult
        End Function
        Public Function getLabelDonViTinh() As String
            Return ParamController.GetParamValue("", "LabelDonViTinh")
        End Function
        'TuanNH add date 01/03/2006
        Public Function getDonViTinh() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "DonViTinh")
            If strResult = "" Then strResult = "0"
            Return strResult
        End Function
        Public Function InGiayCNDKKD(ByVal request As HttpRequest, ByVal ds As DataSet, ByVal strItemCode As String) As String
            Dim url As String
            Dim Script As String
            Dim strServerPath As String

            Dim strTemplateFileName As String = GetParamByID("FileGiayCNDKKD", glbXMLFile)

            'Co nguoi gop von
            If (ds.Tables(1).Rows.Count > 0) Then
                strTemplateFileName = GetParamByID("FileGiayCNDKKDGopVon", glbXMLFile)
            End If

            strServerPath = GetAbsoluteServerPath(request)

            Dim sFileName As String
            Dim sourceFileName As String = strServerPath & getTemplatePathOfWord() & strItemCode & "\" & strTemplateFileName
            Dim destFilePath As String = strServerPath & getOutputPathOfWord() & strItemCode & "\"
            Dim ExportFileName As String = "GiayCNDKKD" & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"
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

            'Danh sach gop von
            If (ds.Tables(1).Rows.Count > 0) Then
                m_doc.ExecuteWithRegions(ds)
            End If

            'Phan thong tin chinh
            m_doc.MergeField(ds.Tables(0))

            'Close file
            'm_doc.Save()
            m_doc.Save(destFilePath & ExportFileName)

            'InGiayCNDKKD = getOutputPathOfWord().Replace("\", "/") & strItemCode & "/" & sFileName
            InGiayCNDKKD = getOutputPathOfWord().Replace("\", "/") & strItemCode & "/" & ExportFileName
        End Function
    End Module

End Namespace
