<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThoaUocLaoDong.ascx.vb" Inherits="CPLDQH.ThoaUocLaoDong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" align="center" border="0">
	<tr>
		<td width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">Thoả ước lao động</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table width="100%" cellpadding="0" cellspacing="0" border="0" class="QH_Table">
				<TR>
					<td class="QH_ColLabel" width="20%">Số biên nhận<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtSoBienNhan" CssClass="QH_Textbox" Width="90%" runat="server" ReadOnly="True"></asp:textbox></td>
					<td width="*">
						<asp:label id="Label2" CssClass="QH_LabelLeftBold" runat="server">Kết quả giải quyết</asp:label>
					</td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Tên đơn vị<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtHoTen" CssClass="QH_TextBox" Width="90%" runat="server"></asp:textbox></td>
					<td vAlign="top" align="left" rowSpan="3" colspan="2">&nbsp;<asp:textbox id="txtKetQuaGiaiQuyet" Width="92%" runat="server" CssClass="QH_Textbox" TextMode="MultiLine"
							Rows="4"></asp:textbox></td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Loại hình doanh nghiệp<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaloaiHinhDoanhNghiep" cssclass="QH_DropDownList" Width="90%" runat="server"></asp:dropdownlist></td>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Ngày đăng ký thoả ước<font color="#ff0000" size="2">&nbsp;*</font></TD>
					<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayDangKyThoaUoc" CssClass="QH_TextBox" Width="50%" runat="server"></asp:textbox>
						<asp:hyperlink id="cmdNgayDangKyThoaUoc" Runat="server" CssClass="CommandButton">
							<asp:image id="imgNgayDangKyThoaUoc" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink>
					</TD>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Đại diện người SDLĐ</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtDaiDienNSDLD" CssClass="QH_TextBox" Width="90%" runat="server"></asp:textbox></td>
					<td>
						<table width="100%" runat="server" id="tblSoThongBao">
							<TR>
								<td class="QH_ColLabel" width="10%">Số TB</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoThongBao" CssClass="QH_TextBox" Width="90%" runat="server"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Ngày TB</td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtNgayThongBao" CssClass="QH_TextBox" Width="70%" runat="server"></asp:textbox>
									<asp:hyperlink id="cmdNgayThongBao" Runat="server" CssClass="CommandButton">
										<asp:image id="imgNgayThongBao" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</td>
							</TR>
						</table>
					</td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Chức vụ</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtChucVuNSDLD" CssClass="QH_TextBox" Width="90%" runat="server"></asp:textbox></td>
					<td vAlign="bottom" rowSpan="7" colspan="2"><asp:label id="Label15" CssClass="QH_LabelLeftBold" runat="server">Địa chỉ đơn vị</asp:label>
						<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_ColLabel" width="30%">Số nhà<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Width="90%" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%" height="12">Phường<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl" height="12">
									<cc1:KeySortDropDownList id="ddlMaPhuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Đường<font color="#ff0000" size="2">&nbsp;*</font></td>
								<td class="QH_ColControl">
									<cc1:KeySortDropDownList id="ddlMaDuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Điện thoại</td>
								<td class="QH_ColControl"><asp:textbox id="txtDienThoai" CssClass="QH_TextBox" Width="50%" runat="server"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Đại diện tập thể lao động</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtDaiDienTapTheLD" CssClass="QH_TextBox" Width="90%" runat="server"></asp:textbox></td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Chức vụ</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtChucVuTapTheLD" CssClass="QH_TextBox" Width="90%" runat="server"></asp:textbox></td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Tổng số lao động</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtTongSoLD" CssClass="QH_TextBox" Width="50%" runat="server" style="TEXT-ALIGN:right"></asp:textbox></td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Thời hạn từ ngày</td>
					<td>
						<table>
							<tr>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtThoiHanTuNgay" CssClass="QH_TextBox" Width="80%" runat="server"></asp:textbox>
									<asp:hyperlink id="cmdThoiHanTuNgay" Runat="server" CssClass="CommandButton">
										<asp:image id="ImgThoiHanTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</td>
								<td class="QH_ColLabel" width="15%">Đến ngày</td>
								<td class="QH_ColControl" width="25%"><asp:textbox id="txtThoiHanDenNgay" CssClass="QH_TextBox" Width="80%" runat="server"></asp:textbox>
									<asp:hyperlink id="cmdThoiHanDenNgay" Runat="server" CssClass="CommandButton">
										<asp:image id="ImgThoiHanDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</td>
							</tr>
						</table>
					</td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Ngày xác nhận hồ sơ</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtNgayXacNhan" CssClass="QH_TextBox" Width="50%" runat="server"></asp:textbox>
						<asp:hyperlink id="cmdNgayXacNhan" Runat="server" CssClass="CommandButton">
							<asp:image id="imgNgayXacNhan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink>
					</td>
				</TR>
				<TR>
					<td class="QH_ColLabel" width="20%">Lãnh đạo duyệt</td>
					<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaSoLanhDao" cssclass="QH_DropDownList" Width="90%" runat="server"></asp:dropdownlist></td>
				</TR>
				<tr>
					<td colSpan="3" height="5"></td>
				</tr>
				<tr>
					<td align="center" colSpan="3"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>
						<asp:linkbutton id="btnXoa" CssClass="QH_Button" Width="50px" runat="server">Xoá</asp:linkbutton>
						<asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server">Bổ sung hồ sơ</asp:linkbutton>
						<asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server"> Hồ sơ không giải quyết</asp:linkbutton>
						<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In thông báo</asp:linkbutton>
						<asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</TABLE>
<asp:TextBox id="txtThoaUocLaoDongID" runat="server" Visible="False"></asp:TextBox>
<asp:TextBox id="txtHoSoTiepNhanID" runat="server" Visible="False"></asp:TextBox>
<asp:TextBox id="txtMaLinhVuc" runat="server" Visible="False"></asp:TextBox>
<asp:TextBox id="txtTabCode" runat="server" Visible="False"></asp:TextBox>
<asp:TextBox id="txtMaSoNguoiSuDung" runat="server" Visible="False"></asp:TextBox>
