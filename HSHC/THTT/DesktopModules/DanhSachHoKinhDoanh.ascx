<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachHoKinhDoanh.ascx.vb" Inherits="THTT.DanhSachHoKinhDoanh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD colspan="3"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Danh sách hộ kinh doanh cá thể</asp:label></TD>
	</TR>
	<tr>
		<TD colspan="3" align="right">
			<asp:Label ID="Label4" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:Label>
			<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextBox" Width="25px"
				MaxLength="3"></asp:TextBox>
		</TD>
	</tr>
	<TR>
		<TD colspan="3">
			<asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" autogeneratecolumns="False"
				Runat="server" AllowSorting="True" AllowPaging="True" CellPadding="3">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</TR>
	<TR>
		<TD colspan="3" height="5"></TD>
	</TR>
	<TR>
		<TD colspan="3" align="center">
			<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
			<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
		</TD>
	</TR>
</TABLE>
