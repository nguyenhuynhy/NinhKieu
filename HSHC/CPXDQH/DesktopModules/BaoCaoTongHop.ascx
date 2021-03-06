<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BaoCaoTongHop.ascx.vb" Inherits="CPXD.BaoCaoTongHop" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/PopupCalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" CssClass="QH_Label_Title" Width="100%"></asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<TR>
								<TD colSpan="5" height="5"></TD>
							</TR>
							<TR vAlign="top">
								<TD vAlign="top" width="50%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
										<TR vAlign="top">
											<TD class="QH_ColLabel" width="30%" height="21"><asp:label id="lblMaPhuong" runat="server">Phường</asp:label></TD>
											<TD class="QH_ColControl" width="70%" height="21"><asp:dropdownlist id="ddlMaPhuong" Runat="server" CssClass="QH_DropDownList" Width="60%"></asp:dropdownlist><asp:textbox id="txtMaNguoiTacNghiep" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox></TD>
										</TR>
										<TR vAlign="top">
											<TD class="QH_ColLabel" width="30%" height="4"><asp:label id="lblMaloaiHoSo" runat="server">Loại hồ sơ</asp:label></TD>
											<TD class="QH_ColControl" width="70%" height="4"><asp:dropdownlist id="ddlMaLoaiHoSo" Runat="server" CssClass="QH_DropDownList" Width="80%"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%"><asp:label id="lblThang" runat="server">Tháng</asp:label><asp:label id="lblTuNgay" runat="server">Từ ngày</asp:label></TD>
											<TD class="QH_ColControl" width="70%"><asp:dropdownlist id="ddlThang" Runat="server" CssClass="QH_DropDownList" Width="30%"></asp:dropdownlist><asp:textbox id="txtTuNgay" Runat="server" CssClass="QH_TextBox" Width="30%" MaxLength="10"></asp:textbox>&nbsp;
												<asp:hyperlink id="cmdStartCalendar" Runat="server" CssClass="CommandButton">
													<asp:image id="btnTuNgay" BorderWidth="0" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%"><asp:label id="lblNam" runat="server">Năm</asp:label><asp:label id="lblDenNgay" runat="server">Đến ngày</asp:label></TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtNam" Runat="server" CssClass="QH_TextBox" Width="30%" MaxLength="10"></asp:textbox><asp:textbox id="txtDenNgay" Runat="server" CssClass="QH_TextBox" Width="30%" MaxLength="10"></asp:textbox>&nbsp;
												<asp:hyperlink id="cmdEndCalendar" Runat="server" CssClass="CommandButton">
													<asp:image id="btnDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Quy mô</TD>
											<TD class="QH_ColControl" width="70%">
												<asp:textbox id="txtQuyMo" Width="30%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top" width="50%"><asp:radiobuttonlist id="lstReports" CssClass="QH_LoaiHS" runat="server" AutoPostBack="True"></asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<td width="100%" colSpan="2"></td>
							</TR>
							<TR>
								<TD colSpan="2">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
										<tr>
											<td align="right" height="5"></td>
										</tr>
										<TR>
											<TD align="center" width="50%" height="24"><asp:linkbutton id="btnExport" CssClass="QH_Button" runat="server">Xuất ra Excel</asp:linkbutton>&nbsp;<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btntroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;
												<asp:linkbutton id="Linkbutton1" CssClass="QH_Button" runat="server">Mở File Excel</asp:linkbutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="5" height="23"><asp:textbox id="txtLoai" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox></TD>
							</TR>
						</TABLE>
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
