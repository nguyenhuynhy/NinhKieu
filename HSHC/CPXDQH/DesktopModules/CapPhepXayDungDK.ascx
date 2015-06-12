<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapPhepXayDungDK.ascx.vb" Inherits="CPXD.CapPhepXayDungDK" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc2" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Import Namespace="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="title" Width="100%" CssClass="QH_Label_Title" runat="server">nhập giấy phép xây dựng đầu kỳ</asp:label></td>
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
					<td align="center" width="*">
						<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td>
									<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%">Số giấy phép</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" Width="60%" CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Ngày cấp phép</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCap" Width="40%" CssClass="QH_Textbox" runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayCapPhep" CssClass="CommandButton" Runat="server">
													<asp:image id="btnNgayCapPhep" BorderWidth="0" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Tên chủ đầu tư</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" Width="60%" CssClass="QH_Textbox" runat="server"></asp:textbox>&nbsp;Giới 
												tính
												<asp:DropDownList id="ddlGioiTinh" runat="server" CssClass="QH_dropdownlist" Width="20%"></asp:DropDownList></TD>
											<TD class="QH_ColLabel" width="15%">Thường trú</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTru" Width="80%" CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Phân loại xây dựng</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhanLoaiXayDung" Width="60%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Loại công trình</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaCapNha" Width="80%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ký hiệu thiết kế</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:TextBox id="txtKyHieuThietKe" runat="server" CssClass="QH_Textbox" Width="60%"></asp:TextBox></TD>
											<TD class="QH_ColLabel" width="15%">Đơn vị thiết kế</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDonViThietKe" Width="80%" CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Kết cấu</TD>
											<TD class="QH_ColControl" width="35%" colspan="3">
												<asp:TextBox id="txtKetCau" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Chiều cao từng tầng</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtChieuCaoTungTang" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Chiều cao toàn công trình</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtChieuCaoToanCongTrinh" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Diện tích xây dựng</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtDienTichXayDung" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ghi chú</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtGhiChu" runat="server" CssClass="QH_Textbox" Width="95%" TextMode="MultiLine"
													Rows="5"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Trên lô đất</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtLoDat" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Diện tích khuôn viên</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtDienTichKhuonVien" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Chỉ giới xây dựng</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtChiGioiXayDung" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Số nhà</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="TextBox1" runat="server" CssClass="QH_Textbox" Width="25%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Đường</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<cc2:KeySortDropDownList id="ddlMaDuong" runat="server"></cc2:KeySortDropDownList></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Phường</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<cc2:KeySortDropDownList id="ddlMaPhuong" runat="server"></cc2:KeySortDropDownList></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Giấy sử dụng đất</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtGiaySuDungDat" runat="server" CssClass="QH_Textbox" Width="95%" TextMode="MultiLine"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Thời hạn hoàn thành</TD>
											<TD class="QH_ColControl" width="35%" colSpan="3">
												<asp:TextBox id="txtThoiHanHoanThanh" runat="server" CssClass="QH_Textbox" Width="95%"></asp:TextBox></TD>
										</TR>
									</table>
								</td>
							</tr>
							<tr>
								<td height="42">
									<table cellSpacing="2" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<td align="center">
												<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server" visible='False'>In giấy phép</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server" Visible="False">Xóa</asp:linkbutton>&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><asp:textbox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaLinhVuc" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtReload" Width="0px" runat="server"></asp:textbox></td>
							</tr>
							<TR>
								<TD>
									<asp:TextBox id="txtGiayPhepXayDungID" runat="server" Width="0px"></asp:TextBox></TD>
							</TR>
						</table>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
