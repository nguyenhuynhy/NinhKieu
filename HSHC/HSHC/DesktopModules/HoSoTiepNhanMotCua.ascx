<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HoSoTiepNhanMotCua.ascx.vb" Inherits="HSHC.ConvertHoSoTiepNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblHeader" CssClass="QH_Label_Title" runat="server" Width="100%">Danh sách hồ sơ</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<tr>
		<td>
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
							<tr>
								<td height="10"></td>
							</tr>
							<tr>
								<td align="center">
									<asp:datagrid id="dgdDanhSach" CellPadding="3" AllowPaging="True" AllowSorting="True" autogeneratecolumns="False"
										Width="100%" CssClass="QH_DataGrid" Runat="server">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
								</td>
							</tr>
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
				<tr>
				</tr>
			</table>
		</td>
	<tr>
		<td align="center">
			<asp:linkbutton id="btnNhanHoSo" CssClass="QH_Button" runat="server"> Nhận hồ sơ</asp:linkbutton>
			<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>
		</td>
	</tr>
</TABLE>
