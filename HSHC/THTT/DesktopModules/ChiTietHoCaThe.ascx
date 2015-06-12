<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChiTietHoCaThe.ascx.vb" Inherits="THTT.ChiTietHoCaThe" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table width="90%" class="QH_Table" align="center" cellpadding="0" cellspacing="0">
	<tr>
		<td Width="100%" valign="top"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Thông tin chi tiết hộ kinh doanh</asp:label></td>
	</tr>
	<tr>
		<td vAlign="top" Width="100%">
			<table id="Table2" width="100%">
				<TR>
					<TD width="48"></TD>
					<TD align="right" width="162" class="QH_ColLabel">Chủ hộ kinh doanh:</TD>
					<TD width="120" class="QH_ColLabelLeft">
						<asp:label id="lblHoTen" CssClass="QH_LabelDisplay" runat="server"></asp:label></TD>
					<TD align="right"></TD>
					<TD></TD>
				</TR>
				<tr>
					<td width="48"></td>
					<td align="right" width="162" colSpan="1" rowSpan="1" class="QH_ColLabel">Số&nbsp;giấy CN ĐKKD:&nbsp;</td>
					<td width="120" class="QH_ColLabelLeft"><asp:label id="lblSoGP" CssClass="QH_LabelDisplay" runat="server"></asp:label>&nbsp;</td>
					<td align="right" class="QH_ColLabel">Ngày cấp:&nbsp;</td>
					<td class="QH_ColLabelLeft"><asp:label id="lblNgayCap" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td width="48"></td>
					<td align="right" width="162" class="QH_ColLabel">Số CMND:&nbsp;</td>
					<td width="120" class="QH_ColLabelLeft"><asp:label id="lblCMND" CssClass="QH_LabelDisplay" runat="server"></asp:label>&nbsp;</td>
					<td align="right" class="QH_ColLabel">Ngày cấp CMND:&nbsp;</td>
					<td class="QH_ColLabelLeft"><asp:label id="lblNgayCapCMND" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td noWrap width="48" colSpan="1" rowSpan="1"></td>
					<td align="right" width="162" class="QH_ColLabel">Nơi cấp CMND:&nbsp;</td>
					<td colSpan="3" class="QH_ColLabelLeft"><asp:label id="lblNoiCapCMND" CssClass="QH_LabelDisplay" runat="server"></asp:label>&nbsp;</td>
				</tr>
				<tr>
					<td width="48"></td>
					<td align="right" width="162" class="QH_ColLabel">Nơi ĐKTT:&nbsp;</td>
					<td colSpan="3" class="QH_ColLabelLeft"><asp:label id="lblNoiDKTT" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td width="48"></td>
					<td align="right" width="162" class="QH_ColLabel">Địa chỉ kinh doanh:&nbsp;</td>
					<td colSpan="3" class="QH_ColLabelLeft"><asp:label id="lblDiaChi" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td width="48"></td>
					<td align="right" width="162" class="QH_ColLabel">Bảng hiệu:&nbsp;</td>
					<td colSpan="3" class="QH_ColLabelLeft"><asp:label id="lblBangHieu" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td width="48"></td>
					<td align="right" width="162" class="QH_ColLabel">Ngành nghề kinh doanh:&nbsp;</td>
					<td colSpan="3" class="QH_ColLabelLeft"><asp:label id="lblNoidungKD" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td width="48"></td>
					<td align="right" width="162" class="QH_ColLabel">Vốn kinh doanh:&nbsp;</td>
					<td colSpan="3" class="QH_ColLabelLeft"><asp:label id="lblVon" CssClass="QH_LabelDisplay" runat="server"></asp:label>&nbsp;đồng</td>
				</tr>
				<tr>
					<td width="48"></td>
					<td align="right" width="162"></td>
					<td colSpan="3"></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD height="10"></TD>
	</TR>
	<tr>
		<td vAlign="top">
			<table id="Table3" width="100%">
				<tr>
					<td colSpan="4" class="QH_LabelLeftBold">Tình hình hoạt động</td>
				</tr>
				<tr>
					<td width="48"></td>
					<td width="160" class="QH_ColLabel">Ngưng kinh doanh</td>
					<td class="QH_ColLabelLeft"><asp:label id="lblTamNgung" CssClass="QH_LabelDisplay" runat="server"></asp:label>&nbsp;lần</td>
					<td></td>
				</tr>
				<tr>
					<td width="48"></td>
					<td width="160" class="QH_ColLabel">Cấp đổi giấy CN ĐKKD</td>
					<td class="QH_ColLabelLeft"><asp:label id="lblThayDoi" CssClass="QH_LabelDisplay" runat="server"></asp:label>&nbsp;lần</td>
					<td></td>
				</tr>
				<tr>
					<td width="48"></td>
					<td width="160" class="QH_ColLabel">Số lần vi phạm hành chánh</td>
					<td class="QH_ColLabelLeft"><asp:label id="lblViPhamHC" CssClass="QH_LabelDisplay" runat="server"></asp:label>&nbsp;lần</td>
					<td></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD align="center"><asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
	</TR>
</table>
