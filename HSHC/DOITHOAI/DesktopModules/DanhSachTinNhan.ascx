<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachTinNhan.ascx.vb" Inherits="DOITHOAI.DanhSachTinNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="main" cellSpacing="0" cellPadding="0" width="98%" border="0" align="center">
	<tr>
		<td width="70%"></td>
		<td width="*" align="right"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label>&nbsp;<asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="30px" Runat="server" MaxLength="3"
				AutoPostBack="True"></asp:textbox></td>
	</tr>
	<tr>
		<td colspan="2"><asp:datagrid id="grdDanhSach" Width="100%" CssClass="QH_DataGrid" Runat="server" CellPadding="3"
				PagerStyle-Mode="NumericPages" AllowSorting="True" AllowPaging="True" autogeneratecolumns="False">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
</TABLE>
