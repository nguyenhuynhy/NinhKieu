<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TangGiamLaoDong.ascx.vb" Inherits="CPLDQH.TangGiamLaoDong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
	<tr>
		<td width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">Tăng giảm lao động</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td align="center" width="100%">
			<table class="QH_Table" width="90%">
				<TR>
					<TD width="50%">
						<table width="100%" border="0">
							<tr>
								<td class="QH_ColLabel" width="20%">Ngày nhập<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtNgayNhap" CssClass="QH_Textbox" Width="30%" runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayNhap" CssClass="CommandButton" Runat="server">
										<asp:image id="imgNgayNhap" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Kỳ báo cáo<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaKyBaoCao" CssClass="QH_DropDownList" Width="90%" runat="server" AutoPostBack="True"
										tabIndex="1"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Tên đơn vị<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtTenDonVi" CssClass="QH_Textbox" Width="90%" runat="server" MaxLength="500"
										Enabled="False" tabIndex="2"></asp:textbox></td>
							</tr>
						</table>
					</TD>
					<TD width="50%">
						<table width="100%" border="0">
							<tr>
								<td class="QH_ColLabel" width="20%">Số nhà<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtSoNha" CssClass="QH_Textbox" Width="50%" runat="server" MaxLength="50" Enabled="False"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Đường<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaDuong" CssClass="QH_DropDownList" Width="90%" runat="server" Enabled="False"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Phường<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaPhuong" CssClass="QH_DropDownList" Width="90%" runat="server" Enabled="False"></asp:dropdownlist></td>
							</tr>
						</table>
					</TD>
				</TR>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
				<tr>
					<td width="50%">
						<table class="QH_Table" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<TD vAlign="top" width="100%" colSpan="4"><asp:label id="Label10" CssClass="QH_LabelLeftBoldRed" Runat="server">Số lao động đầu kỳ</asp:label></TD>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLDDauKy" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="3"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDNuDauKy" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="4"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label1" CssClass="QH_LabelLeftBold" Runat="server">Số lao động tăng giảm trong kỳ</asp:label></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label2" CssClass="QH_LabelLeft" runat="server">Số lao động tăng</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLDTangTK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="5"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDNuTangTK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="6"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label3" CssClass="QH_LabelLeft" runat="server">Số lao động giảm</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="85%" colSpan="3"><asp:textbox id="txtTongSoLDGiamTK" CssClass="QH_TextRight" Width="34%" runat="server" MaxLength="5"
										tabIndex="7"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Nghĩ hưu</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamNghiHuuTK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="8"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Thôi việc</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamThoiViecTK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="9"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Sa thải</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamSaThaiTK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="10"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Khác</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamKhacTK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="11"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table class="QH_Table" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label4" CssClass="QH_LabelLeftBoldRed" Runat="server">Số lao động có mặt cuối kỳ</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLDCK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="12"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDNuCK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="13"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label5" CssClass="QH_LabelLeftBold" Runat="server">Hợp đồng lao động</asp:label></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label6" CssClass="QH_LabelLeft" runat="server">Không xác định thời hạn</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongHDLDKXD" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="14"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtHDLDKXDNu" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="15"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label7" CssClass="QH_LabelLeft" runat="server">Từ 12-36 tháng</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongHDLDXD" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="16"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtHDLDXDNu" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="17"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label8" CssClass="QH_LabelLeft" runat="server">Dưới 12 tháng</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%" height="29">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongHDLDTV" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="18"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtHDLDTVNu" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="19"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
				<tr>
					<td colSpan="2"><asp:label id="Label9" CssClass="QH_LabelLeftBoldRed" runat="server">Dự kiến tuyển lao động</asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" width="50%">
						<table class="QH_Table" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label11" CssClass="QH_LabelLeftBold" runat="server">Lao động dự kiến</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLDDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="20"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDNuDk" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="21"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label12" CssClass="QH_LabelLeft" runat="server">Lao động đã qua đào tạo</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLDDTDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="22"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDDTNuDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="23"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label13" CssClass="QH_LabelLeft" runat="server">Hình thức</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%" height="36">Tự tuyển</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDDuTuyenDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="24"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Tổ chức GTVL</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDThongQuaDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="25"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td width="50%">
						<table class="QH_Table" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label15" CssClass="QH_LabelLeftBold" Runat="server">Hợp đồng lao động</asp:label></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label17" CssClass="QH_LabelLeft" runat="server">Không xác định thời hạn</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLDKXDDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="26"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDKXDNuDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="27"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label18" CssClass="QH_LabelLeft" runat="server">Từ 12-36 tháng</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLDXDDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="28"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDTVNuDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="29"></asp:textbox></td>
							</tr>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label19" CssClass="QH_LabelLeft" runat="server">Dưới 12 tháng</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Tổng số</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLD12DK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="30"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Nữ</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLD12NuDK" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
										tabIndex="31"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD vAlign="top" align="center" width="100%" colSpan="4"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server" tabIndex="32">Cập nhật</asp:linkbutton><asp:linkbutton id="btnXoa" CssClass="QH_Button" Width="49px" runat="server" tabIndex="33">Xóa</asp:linkbutton><asp:linkbutton id="btnDeXuat" CssClass="QH_Button" runat="server" Visible="False" tabIndex="34">Đề xuất</asp:linkbutton><asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server" Visible="False" tabIndex="35">Bổ sung hồ sơ</asp:linkbutton><asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server" Visible="False" tabIndex="36">Hồ sơ không giải quyết</asp:linkbutton><asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server" tabIndex="37">Trở về</asp:linkbutton></TD>
	</TR>
</TABLE>
<asp:textbox id="txtTangGiamLaoDongID" runat="server" Visible="False"></asp:textbox>
<asp:textbox id="txtSuDungLaoDongID" runat="server" Visible="False"></asp:textbox>
<asp:textbox id="txtHoSoTiepNhanID" runat="server" Visible="False"></asp:textbox>
<asp:textbox id="txtMaLinhVuc" runat="server" Visible="False"></asp:textbox>
<asp:textbox id="txtTabCode" runat="server" Visible="False"></asp:textbox>
<asp:textbox id="txtMaSoNguoiSuDung" runat="server" Visible="False"></asp:textbox>
<asp:textbox id="txtMaNguoiTacNghiep" runat="server" Visible="False"></asp:textbox>
