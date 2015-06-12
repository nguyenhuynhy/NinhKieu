<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="XacNhanHoSo.ascx.vb" Inherits="CPVHQH.XacNhanHoSoVanHoa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'>
</script>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<TABLE id="main" cellSpacing="0" cellPadding="3" width="100%" border="0">
	<tr>
		<td height="5"></td>
	</tr>
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">Xác nhận hồ sơ chuyển sở cấp phép</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td vAlign="top" align="center" width="*">
						<!--=====================================================-->
						<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
							<tr>
								<td width="423" height="22"><asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Thông tin chung</asp:label></td>
								<td width="50%" height="22"><asp:label id="Label2" CssClass="QH_LabelLeftBold" runat="server">Thông tin cá nhân</asp:label></td>
							</tr>
							<TR>
								<!-- start thong tin chung -->
								<TD vAlign="top" width="50%">
									<table class="QH_Table" width="100%" border="0">
										<TBODY>
											<tr>
												<td class="QH_ColLabel" width="30%">Số biên nhận<FONT color="#ff0000" size="2">*</FONT></td>
												<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoBienNhan" CssClass="QH_Textbox" Width="90%" runat="server" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td class="QH_ColLabel" width="30%">Ngày xác nhận <FONT color="#ff0000" size="2">*</FONT></td>
												<td class="QH_ColControl" width="70%"><asp:textbox id="txtNgayXacNhan" tabIndex="1" CssClass="QH_Textbox" Width="30%" runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayXacNhan" CssClass="CommandButton" Runat="server">
														<asp:image id="imgNgayXacNhan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
													</asp:hyperlink></td>
											</tr>
											<tr>
												<td class="QH_ColLabel" width="20%">Loại&nbsp;hồ sơ<FONT color="#ff0000" size="2">&nbsp;</FONT></td>
												<td class="QH_ColControl" width="80%">
													<asp:textbox id="txtTenLoaiHoSo" CssClass="QH_Textbox" Width="90%" runat="server" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td class="QH_ColLabel" height="22">Ngành KD<FONT color="#ff0000" size="2"> *</FONT></td>
												<td class="QH_ColControl" height="22"><asp:dropdownlist id="ddlMaNganhKinhDoanh" tabIndex="3" CssClass="QH_Dropdownlist" Width="90%" runat="server"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td class="QH_ColLabel">Nội dung</td>
												<td class="QH_ColControl" colSpan="2"><asp:textbox id="txtNoiDungKinhDoanh" tabIndex="4" CssClass="QH_Textbox" Width="90%" runat="server"
														Rows="2" Height="32px" TextMode="MultiLine"></asp:textbox></td>
											</tr>
											<tr>
												<td colSpan="2" height="15"></td>
											</tr>
											<tr>
												<td colSpan="2"><asp:label id="Label13" CssClass="QH_LabelLeftBold" runat="server">Địa chỉ đăng ký</asp:label></td>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Số nhà<FONT color="#ff0000" size="2">&nbsp;*</FONT></TD>
												<td class="QH_ColControl" width="40%"><asp:textbox id="txtSoNha" tabIndex="10" CssClass="QH_Textbox" Width="30%" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="QH_ColLabel" width="10%">Đường<FONT color="#ff0000" size="2">&nbsp;*</FONT></td>
												<td class="QH_ColControl" width="40%">
													<cc1:KeySortDropDownList id="ddlMaDuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></td>
											</tr>
										</TBODY></table>
								</TD>
								<!-- end thong tin chung -->
								<!-- start thong tin ca nhan -->
								<TD vAlign="top" width="50%">
									<table class="QH_Table" height="60" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td class="QH_ColLabel" width="20%" height="23">Họ và tên <FONT color="#ff0000" size="2">
													&nbsp;*</FONT></td>
											<td class="QH_ColControl" width="80%" height="23"><asp:textbox id="txtHoTen" tabIndex="5" CssClass="QH_Textbox" Width="90%" runat="server"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="30%" height="24">Giới tính<FONT color="#ff0000" size="2">
													&nbsp;</FONT></td>
											<td width="70%" height="24"><asp:dropdownlist id="ddlGioiTinh" tabIndex="6" CssClass="QH_Dropdownlist" Width="30%" runat="server"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
										</tr>
										<tr>
											<td class="QH_ColLabel" vAlign="top" width="30%" height="24">Thường trú<FONT color="#ff0000" size="2">
													&nbsp;*</FONT></td>
											<td class="QH_ColControl" vAlign="top" width="70%" height="24"><asp:textbox id="txtDiaChiThuongTru" tabIndex="7" CssClass="QH_Textbox" Width="90%" runat="server"
													Rows="2" Height="40px" TextMode="MultiLine"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" height="22">Người ký<FONT color="#ff0000" size="2">&nbsp;*</FONT></td>
											<td class="QH_ColControl" height="22"><asp:dropdownlist id="ddlMaSoLanhDao" tabIndex="8" CssClass="QH_Dropdownlist" Width="90%" runat="server"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="QH_ColLabel">Ghi chú</td>
											<td class="QH_ColControl"><asp:textbox id="txtGhiChu" tabIndex="9" CssClass="QH_Textbox" Width="90%" runat="server" Rows="2"
													Height="32px" TextMode="MultiLine"></asp:textbox></td>
										</tr>
										<tr>
											<td colSpan="2" height="19"></td>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Phường<FONT color="#ff0000" size="2">&nbsp;*</FONT></TD>
											<td class="QH_ColControl">
												<cc1:KeySortDropDownList id="ddlMaPhuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></td>
										</tr>
										<tr>
											<td class="QH_ColLabel">Diện tích</td>
											<td class="QH_ColControl"><asp:textbox id="txtDienTich" tabIndex="13" CssClass="QH_Textbox" Width="90%" runat="server"></asp:textbox></td>
										</tr>
									</table>
									<!-- End thong tin ca nhan --></TD>
							</TR>
							<tr>
								<td vAlign="middle" align="center" colSpan="2" height="30"><asp:linkbutton id="btnLuuDiaChi" tabIndex="14" CssClass="QH_Button" runat="server">Lưu xuống</asp:linkbutton></td>
							</tr>
							<TR>
								<TD align="center" width="100%" colSpan="2" height="5"></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="2"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="96%" Runat="server" PageSize="5"
										DataKeyField="DiaChiID" ShowFooter="false" OnPageIndexChanged="dgdDanhSach_PageIndexChanged" OnSortCommand="dgdDanhSach_SortCommand"
										OnDeleteCommand="dgdDanhSach_DeleteCommand" OnEditCommand="dgdDanhSach_EditCommand" OnItemDataBound="dgdDanhSach_ItemDataBound"
										OnUpdateCommand="dgdDanhSach_UpdateCommand" OnCancelCommand="dgdDanhSach_CancelCommand" CellPadding="3" autogeneratecolumns="False">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img alt=Sửa align=middle border= 0 src= ./Images/Edit.gif&gt;" HeaderText="Sửa"
												CommandName="Edit">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle Width="3%"></ItemStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn HeaderText="Xoá" Text="&lt;img alt=&quot;Xo&#225;&quot; align=middle border= 0 src= ./Images/delete.gif&gt;"
												CommandName="Delete">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle Width="3%"></ItemStyle>
											</asp:ButtonColumn>
											<asp:TemplateColumn HeaderText="Số nh&#224;">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemTemplate>
													<asp:Label runat="server" ID="lblgrdSoNha" Text='<%# DataBinder.Eval(Container.DataItem, "SoNha") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="MaĐường">
												<HeaderStyle Width="0px"></HeaderStyle>
												<ItemTemplate>
													<asp:Label runat="server" ID="lblgrdMaDuong" Text='<%# DataBinder.Eval(Container.DataItem, "MaDuong") %>' Visible="False">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Đường">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemTemplate>
													<asp:Label runat="server" ID="Label3" Text='<%# DataBinder.Eval(Container.DataItem, "TenDuong") %>' Visible="true">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="MaPhường">
												<HeaderStyle Width="0px"></HeaderStyle>
												<ItemTemplate>
													<asp:Label runat="server" ID="lblgrdMaPhuong" Text='<%# DataBinder.Eval(Container.DataItem, "MaPhuong") %>' Visible="False">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Phường">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemTemplate>
													<asp:Label runat="server" ID="Label4" Text='<%# DataBinder.Eval(Container.DataItem, "TenDonVi") %>' Visible="true">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Diện t&#237;ch">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemTemplate>
													<asp:Label runat="server" ID="lblgrdDienTich" Text='<%# DataBinder.Eval(Container.DataItem, "DienTich") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<tr>
								<td colSpan="2" height="5"></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:linkbutton id="btnCapNhat" tabIndex="15" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton><asp:linkbutton id="btnXoa" tabIndex="16" CssClass="QH_Button" Width="50px" runat="server">Xoá</asp:linkbutton><asp:linkbutton id="btnDeXuat" tabIndex="17" CssClass="QH_Button" runat="server">Đề xuất</asp:linkbutton><asp:linkbutton id="btnYCBS" tabIndex="18" CssClass="QH_Button" runat="server">Bổ sung hồ sơ</asp:linkbutton><asp:linkbutton id="btnHoSoKhong" tabIndex="19" CssClass="QH_Button" runat="server"> Hồ sơ không giải quyết</asp:linkbutton><asp:linkbutton id="btnBoQua" tabIndex="20" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
			<asp:textbox id="txtHoSoXacNhanID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Visible="False"></asp:textbox></TD>
	</TR>
</TABLE>
