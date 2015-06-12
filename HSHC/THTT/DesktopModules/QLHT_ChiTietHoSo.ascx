<%@ Control Language="vb" AutoEventWireup="false" Codebehind="QLHT_ChiTietHoSo.ascx.vb" Inherits="THTT.QLHT_ChiTietHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Chi tiết hồ sơ</asp:label></TD>
	</TR>
	<TR>
		<TD height="10"></TD>
	</TR>
	<TR>
		<td>
			<TABLE id="myTable" cellSpacing="0" cellPadding="0" width="90%" border="0" runat="server"
				align="center">
			</TABLE>
		</td>
	</TR>
	<tr>
		<TD width="10%"></TD>
	</tr>
	<tr>
		<td align="center" colspan="4">
			<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
		</td>
	</tr>
</TABLE>
