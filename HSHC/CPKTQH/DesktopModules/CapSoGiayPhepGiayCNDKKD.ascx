<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapSoGiayPhepGiayCNDKKD.ascx.vb" Inherits="CPKTQH.CapSoGiayPhepGiayCNDKKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="JavaScript">
	function CheckCapNhat()
	{
		if (!CheckNull())
			return false;
		else return true;
	}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" Width="100%" runat="server" CssClass="QH_Label_Title">Nội dung giấy chứng nhận đăng ký kinh doanh</asp:label></td>
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
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<TD height="5"></TD>
								</TR>
								<TR>
									<TD align="center"></TD>
								</TR>
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="90%" border="0">
											<TR>
												<TD width="100%">
													<TABLE class="QH_LoaiHS" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD colSpan="4"><asp:label id="Label6" CssClass="QH_LabelLeftBold" Runat="server"><strong>Thông 
																		tin chung</strong></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="20%">Số biên nhận</TD>
															<TD class="QH_ColControl" width="30%"><asp:label id="lblSoBienNhan" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="20%"></TD>
															<TD class="QH_ColControl" width="30%" colSpan="4"></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="20%">Số GCN ĐKKD</TD>
															<TD class="QH_ColControl" width="30%"><asp:textbox id="txtSoGiayCNDKKD" runat="server" CssClass="QH_TextBox"></asp:textbox></TD>
															<TD class="QH_ColLabel" width="20%">Lĩnh vực cấp phép</TD>
															<TD class="QH_ColControl" width="30%" colSpan="4"><asp:label id="lblTenLinhVucCapPhep" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Ngày cấp</TD>
															<TD class="QH_ColControl"><asp:textbox id="txtNgayCap" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>
																<asp:image id="imgNgayCap" CssClass="QH_IMAGEBUTTON" runat="server" AlternateText="Chọn ngày tháng nam"
																	ImageUrl="~/images/calendar.gif"></asp:image></TD>
															<TD class="QH_ColLabel">Ngành kinh doanh chính</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblTenNganhKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Ngày hết hạn</TD>
															<TD class="QH_ColControl"><asp:label id="lblNgayHetHanGiayPhep" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Mặt hàng kinh doanh</TD>
															<TD class="QH_ColControl" width="270" colSpan="4"><asp:label id="lblMatHangKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Bảng hiệu</TD>
															<TD class="QH_ColControl" width="150"><asp:label id="lblBangHieu" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Vốn kinh doanh</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblVonKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label>&nbsp;
																<asp:label id="lblLabelDonViTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColControl" colSpan="11"><asp:label id="Label1" CssClass="QH_LabelLeftBold" Runat="server"><strong>Địa 
																		chỉ kinh doanh</strong></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ kinh doanh</TD>
															<TD class="QH_ColControl"><asp:label id="lblDiaChiKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Điện thoại</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblDienThoai" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ cũ</TD>
															<TD class="QH_ColControl" width="200"><asp:label id="lblDiaChiCu" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Email</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblEmail" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColControl" colSpan="11"><asp:label id="Label7" CssClass="QH_LabelLeftBold" Runat="server"><strong>Thông 
																		tin người đại diện</strong></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Họ tên:</TD>
															<TD class="QH_ColControl"><asp:label id="lblHoTen" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Ngày sinh:</TD>
															<TD class="QH_ColControl" width="15%"><asp:label id="lblNgaySinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="10%">Giới tính:</TD>
															<TD class="QH_ColControl" width="*"><asp:label id="lblChuoiGioiTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ thường trú:</TD>
															<TD class="QH_ColControl" width="150"><asp:label id="lblThuongTru" Width="100%" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Số CMND:</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblSoCMND" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
										<BR>
										<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button"> Cập nhật</asp:linkbutton>&nbsp;
										<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;
										<asp:linkbutton id="btnInGiayCNDKKD" runat="server" CssClass="QH_Button" Visible="False">In Giấy CNDKKD</asp:linkbutton>&nbsp;
										<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
								</TR>
								<TR>
									<TD align="center"></TD>
					</td>
				</tr>
			</table>
			<div style="DISPLAY: none"><asp:textbox id="txtMaNguoiNhan" Width="0px" runat="server" CssClass="QH_Textbox" Visible="true"></asp:textbox>
				<asp:textbox id="txtGiayCNDKKDID" Runat="server" Enabled="False"></asp:textbox>
			</div>
		<TD class="QH_Khung_Right" width="16">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="*">
					<TD></TD>
				</TR>
				<TR height="141">
					<TD class="QH_Khung_Right1"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
