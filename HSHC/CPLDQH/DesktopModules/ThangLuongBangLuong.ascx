<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="uc2" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThangLuongBangLuong.ascx.vb" Inherits="CPLDQH.ThangLuongBangLuong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<uc2:combofilter id="ctrlScriptComboFilterPhuong" runat="server"></uc2:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" align="center" border="0">
	<tr>
		<td width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" Width="100%" CssClass="QH_Label_Title" runat="server">Thang lương bảng lương</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="top" width="50%">
						<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colSpan="4"><asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Thông tin hồ sơ</asp:label></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="35%">Số biên nhận<font color="#ff0000" size="2">&nbsp;*</font>
								</td>
								<td class="QH_ColControl" width="65%"><asp:textbox id="txtSoBienNhan" Width="90%" CssClass="QH_TextBox" runat="server" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Tên đơn vị<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl"><asp:textbox id="txtHoTen" Width="90%" CssClass="QH_TextBox" runat="server" tabIndex="1"></asp:textbox></td>
							</tr>
							<TR>
								<td class="QH_ColLabel">Loại hình DN<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl"><asp:dropdownlist id="ddlMaLoaiHinhDoanhNghiep" Width="90%" CssClass="QH_dropdownlist" runat="server"
										tabIndex="2"></asp:dropdownlist></td>
							</TR>
							<TR>
								<td class="QH_ColLabel">Họ tên giám đốc<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl"><asp:textbox id="txtHoTenGiamDoc" Width="90%" CssClass="QH_TextBox" runat="server" tabIndex="1"></asp:textbox></td>
							</TR>
							<TR>
								<td class="QH_ColLabel">Ngành nghề kinh doanh<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl"><asp:textbox id="txtNganhKinhDoanh" Width="90%" CssClass="QH_TextBox" runat="server" tabIndex="1"></asp:textbox></td>
							</TR>
						</table>
					</td>
					<td align="top">
						<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colSpan="4"><asp:label id="Label7" CssClass="QH_LabelLeftBold" runat="server">Địa chỉ đơn vị</asp:label></td>
							</tr>
							<TR>
								<TD class="QH_ColLabel" width="35%">Số nhà<font color="#ff0000" size="2">&nbsp;*</font></TD>
								<TD class="QH_ColControl" width="65%"><asp:textbox id="txtSoNha" Width="90%" CssClass="QH_TextBox" runat="server" tabIndex="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="18">Phường<font color="#ff0000" size="2">&nbsp;*</font></TD>
								<TD class="QH_ColControl" height="18">
									<cc1:KeySortDropDownList id="ddlMaPhuong" runat="server" CssClass="QH_DropDownList" Width="90%"></cc1:KeySortDropDownList></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Đường<font color="#ff0000" size="2">&nbsp;*</font></TD>
								<TD class="QH_ColControl">
									<cc1:KeySortDropDownList id="ddlMaDuong" runat="server" CssClass="QH_DropDownList" Width="90%"></cc1:KeySortDropDownList></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Ðiện thoại</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtDienThoai" Width="90%" CssClass="QH_TextBox" runat="server" tabIndex="7"></asp:textbox></TD>
							</TR>
							<TR>
								<td class="QH_ColLabel">Ngày&nbsp;xác nhận<FONT color="#ff0000" size="2">&nbsp;*</FONT></td>
								<td class="QH_ColControl"><asp:textbox id="txtNgayXacNhan" Width="40%" CssClass="QH_TextBox" runat="server" tabIndex="3"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayXacNhan" CssClass="CommandButton" Runat="server">
										<asp:image id="imgNgayXacNhan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></td>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colSpan="4"><asp:label id="Label2" CssClass="QH_LabelLeftBold" runat="server">Thang lương bảng lương</asp:label></td>
							</tr>
							<TR>
								<TD class="QH_ColLabel" width="35%" colSpan="1">Tổng số lao động</TD>
								<TD class="QH_ColControl" width="65%" colSpan="1"><asp:textbox id="txtTongSoLaoDong" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="5"
										tabIndex="8"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Tiến lương tối thiểu</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtTienLuongToiThieu" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="12"
										tabIndex="9"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Tiền lương thấp nhất</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtThuNhapThapNhat" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="12"
										tabIndex="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Tiền lương cao nhất</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtThuNhapCaoNhat" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="12"
										tabIndex="11"></asp:textbox></TD>
							</TR>
							<!--
							<TR>
								<TD class="QH_ColLabel">Khác BQ</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtKhacBQ" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="12"
										tabIndex="12"></asp:textbox></TD>
							</TR>
							-->
						</table>
					</td>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colSpan="4" height="15"><asp:label id="Label3" CssClass="QH_LabelLeftBold" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td width="50%">
								</td>
							</tr>
							<TR>
								<TD width="100%" height="25"><asp:label id="Label6" Width="100%" CssClass="QH_LabelLeftBold" runat="server">&nbsp;Kết quả giải quyết</asp:label></TD>
							</TR>
							<tr>
								<td class="QH_Control">&nbsp;
									<asp:textbox id="txtKetQuaGiaiQuyet" Width="355" CssClass="QH_TextBox" runat="server" Rows="3"
										TextMode="MultiLine" tabIndex="15"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td vAlign="top">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%" colSpan="2"><asp:label id="Label5" CssClass="QH_LabelLeftBold" runat="server">Công nhân sản xuất trực tiếp</asp:label></td>
				</tr>
				<tr>
					<td align="top" width="50%">
						<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="QH_ColLabel" width="35%">Mức lương thấp nhất</TD>
								<TD class="QH_ColControl" width="65%"><asp:textbox id="txtSXMucLuongThapNhat" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="12"
										tabIndex="16"></asp:textbox></TD>
							</tr>
							<TR>
								<TD class="QH_ColLabel">Mức lương cao nhất</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtSXMucLuongCaoNhat" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="12"
										tabIndex="17"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Số bậc lương</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtSXSoBacLuong" Width="90%" CssClass="QH_TextRight" runat="server" MaxLength="12"
										tabIndex="18"></asp:textbox></TD>
							</TR>
						</table>
					</td>
					<td align="top">
						<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td class="QH_ColLabel" width="15%">Số CV</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoCongVan" Width="95%" CssClass="QH_Textbox" runat="server" tabIndex="19"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Ngày</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCongVan" Width="80%" CssClass="QH_Textbox" runat="server" tabIndex="20"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayCongVan" CssClass="CommandButton" Runat="server">
										<asp:image id="imgNgayCongVan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></td>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Mã số</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtMaSo" Width="95%" CssClass="QH_TextBox" runat="server" tabIndex="21"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Ngày</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayBangLuong" Width="80%" CssClass="QH_TextBox" runat="server" tabIndex="22"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayBangLuong" CssClass="CommandButton" Runat="server">
										<asp:image id="imgNgayBangLuong" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">LÐ duyệt</TD>
								<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaSoLanhDao" Width="95%" CssClass="QH_dropdownlist" runat="server" tabIndex="23"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel">In lần</TD>
								<TD class="QH_ColControl"><asp:dropdownlist id="ddlInLan" Width="80%" CssClass="QH_dropdownlist" runat="server" tabIndex="24">
										<asp:ListItem Value="0" Selected="True">Lần 1</asp:ListItem>
										<asp:ListItem Value="1">Lần 2</asp:ListItem>
										<asp:ListItem Value="2">Bổ sung</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
	<tr>
		<td align="center" width="100%"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server" tabIndex="25">Cập nhật</asp:linkbutton><asp:linkbutton id="btnXoa" Width="50px" CssClass="QH_Button" runat="server" tabIndex="26">Xoá</asp:linkbutton><asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server" tabIndex="27">Bổ sung hồ sơ</asp:linkbutton><asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server" tabIndex="28"> Hồ sơ không giải quyết</asp:linkbutton><asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server" tabIndex="29">In thông báo</asp:linkbutton><asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server" tabIndex="30">Trở về</asp:linkbutton></td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
</TABLE>
<asp:textbox id="txtThangLuongBangLuongID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Visible="False"></asp:textbox>
