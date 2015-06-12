<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SuDungLaoDong.ascx.vb" Inherits="CPLDQH.SuDungLaoDong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
	<tr>
		<td colSpan="2">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">Đăng ký sử dụng lao động</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD vAlign="top" width="50%">
			<table class="QH_Table" width="100%">
				<tr>
					<td class="QH_ColLabel" width="30%">Số biên nhận</td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtSoBienNhan" runat="server" Width="90%" CssClass="QH_Textbox" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%" height="18">Ngày nhận<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtNgayNhan" runat="server" Width="50%" CssClass="QH_Textbox" MaxLength="10"
							tabIndex="1"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayNhan" CssClass="CommandButton" Runat="server">
							<asp:image id="imgNgayNhan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Tên đơn vị<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtHoTen" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="2"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Tên chủ đơn vị</td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtTenChuDonVi" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="3"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%" height="20"><asp:label id="Label5" runat="server">Loại hình DN</asp:label></td>
					<td class="QH_ColControl" colSpan="3" height="20"><asp:dropdownlist id="ddlMaLoaiHinhDoanhNghiep" runat="server" Width="90%" CssClass="QH_DropDownList"
							tabIndex="4"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Tổng số LĐ</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtTongSoLaoDong" runat="server" Width="70%" CssClass="QH_TextRight" MaxLength="5"
							tabIndex="5"></asp:textbox></td>
					<td class="QH_ColLabel" width="15%">LĐ nữ
					</td>
					<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLaoDongNu" runat="server" Width="70%" CssClass="QH_TextRight" MaxLength="5"
							tabIndex="6"></asp:textbox></td>
				</tr>
			</table>
		</TD>
		<!-- Start dia chi co quan -->
		<TD vAlign="top" width="50%">
			<table class="QH_Table" width="100%">
				<tr>
					<td colSpan="2" height="23"><asp:label id="Label7" runat="server" CssClass="QH_LabelLeftBold">Địa chỉ cơ quan</asp:label></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Số nhà<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoNha" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="7"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Phường<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="70%">
						<cc1:KeySortDropDownList id="ddlMaPhuong" CssClass="QH_DropDownList" Width="90%" runat="server" tabIndex="8"></cc1:KeySortDropDownList></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Đường<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="70%">
						<cc1:KeySortDropDownList id="ddlMaDuong" CssClass="QH_DropDownList" Width="90%" runat="server" tabIndex="9"></cc1:KeySortDropDownList></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Điện thoại</td>
					<td class="QH_ColControl" width="70%"><asp:textbox id="txtDienThoai" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="10"></asp:textbox></td>
				</tr>
			</table>
		</TD>
	</TR>
	<!-- End dia chi co quan -->
	<TR>
		<!--Start left DANG KI MOI -->
		<TD vAlign="top" width="50%">
			<table class="QH_Table" width="100%">
				<tr>
					<td colSpan="2"><asp:label id="Label12" runat="server" CssClass="QH_LabelLeftBold">Đăng ký mới</asp:label></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">HĐLĐ ký mới</td>
					<td class="QH_ColControl" width="70%"><asp:textbox id="txtHopDongLaoDongKyMoi" runat="server" Width="50%" CssClass="QH_TextRight" MaxLength="5"
							tabIndex="11"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Trong đó nữ</td>
					<td class="QH_ColControl"><asp:textbox id="txtHopDongLaoDongKyMoiNu" runat="server" Width="50%" CssClass="QH_TextRight"
							MaxLength="5" tabIndex="12"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="QH_ColLabel">HĐLĐ gia hạn</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtHopDongLaoDongGiaHan" runat="server" Width="50%" CssClass="QH_TextRight"
							MaxLength="5" tabIndex="13"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Trong đó nữ</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtHopDongLaoDongGiaHanNu" runat="server" Width="50%" CssClass="QH_TextRight"
							MaxLength="5" tabIndex="14"></asp:textbox></TD>
				</TR>
				<tr>
					<td class="QH_ColLabel">Ngày HĐLĐ</td>
					<td class="QH_ColControl"><asp:textbox id="txtNgayHopDongLaoDong" runat="server" Width="50%" CssClass="QH_Textbox" MaxLength="10"
							tabIndex="15"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayHopDong" CssClass="CommandButton" Runat="server">
							<asp:image id="imgNgayHopDong" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Tổng thu nhập</td>
					<td class="QH_ColControl"><asp:textbox id="txtTongThuNhap" runat="server" Width="50%" CssClass="QH_TextRight" MaxLength="15"
							tabIndex="16"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Lương chính</td>
					<td class="QH_ColControl" vAlign="top" height="32"><asp:textbox id="txtLuongChinh" runat="server" Width="50%" CssClass="QH_TextRight" MaxLength="15"
							tabIndex="17"></asp:textbox></td>
				</tr>
			</table>
		</TD>
		<!--End left DANG KI MOI -->
		<!--Start Right DANG KI MOI -->
		<TD align="center" width="50%" valign="top">
			<table class="QH_Table" width="100%">
				<tr>
					<td width="50%"><asp:label id="Label18" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Hộ khẩu thành phố</asp:label></td>
					<td width="50%"><asp:label id="Label21" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Hộ khẩu tỉnh</asp:label></td>
				</tr>
				<tr>
					<!-- start HO KHAU THANH PHO -->
					<td width="50%">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="30%">Nam</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauThanhPhoNam" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="18"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Nữ</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauThanhPhoNu" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="19"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<!-- End HO KHAU THANH PHO -->
					<!-- start HO KHAU TINH -->
					<td width="50%" colSpan="2">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="30%">Nam</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTinhNam" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="20"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Nữ</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTinhNu" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="21"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- End HO KHAU TINH -->
				<tr>
					<td colSpan="2">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="51%">Hợp đồng lao động không xác định</td>
								<td class="QH_ColControl"><asp:textbox id="txtSoLaoDongKhongXacDinh" runat="server" Width="88%" CssClass="QH_TextRight"
										MaxLength="5" tabIndex="22"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Hợp đồng lao động từ 12 đến 36 tháng</td>
								<td class="QH_ColControl"><asp:textbox id="txtSoLaoDongXacDinh" runat="server" Width="88%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="23"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Hợp đồng lao động dưới 12 tháng</td>
								<td class="QH_ColControl"><asp:textbox id="txtSoLaoDongThoiVu" runat="server" Width="88%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="24"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</TD>
		<!--End Right DANG KI MOI --></TR>
	<TR>
		<TD vAlign="top" width="100%" colSpan="2" height="5"></TD>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" width="100%" colSpan="2">
			<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button" tabIndex="25">Cập nhật</asp:linkbutton>
			<asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button" tabIndex="26">Thêm mới</asp:linkbutton>
			<asp:linkbutton id="btnXoa" runat="server" Width="50px" CssClass="QH_Button" tabIndex="27">Xóa</asp:linkbutton>
			<asp:linkbutton id="btnDeXuat" runat="server" CssClass="QH_Button" Visible="False" tabIndex="28">Đề xuất</asp:linkbutton>
			<asp:linkbutton id="btnYCBS" runat="server" CssClass="QH_Button" tabIndex="29">Bổ sung hồ sơ</asp:linkbutton>
			<asp:linkbutton id="btnHoSoKhong" runat="server" CssClass="QH_Button" tabIndex="30"> Hồ sơ không giải quyết</asp:linkbutton>
			<asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button" tabIndex="31">Trở về</asp:linkbutton></TD>
	</TR>
</TABLE>
<asp:textbox id="txtSuDungLaoDongID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaSoNguoiSuDung" runat="server" Visible="False"></asp:textbox>
