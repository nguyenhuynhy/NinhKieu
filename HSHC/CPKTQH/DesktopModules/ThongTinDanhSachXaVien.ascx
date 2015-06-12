<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinDanhSachXaVien.ascx.vb" Inherits="CPKTQH.ThongTinDanhSachXaVien" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function KiemTraNhapLieu()
{
	var txtHoTen = document.all('<%=txtHoTen.clientID%>');
	var txtNgaySinh = document.all('<%=txtNgaySinh.clientID%>');
	var txtDiaChiThuongTru = document.all('<%=txtDiaChiThuongTru.clientID%>'); 
	var txtSoCMND = document.all('<%=txtSoCMND.clientID%>');
	if (txtHoTen.value=="")
	{
		alert("Chua nhap Ho Ten");
		txtHoTen.focus();
		return false;
	}
	if (txtNgaySinh.value=="")
	{
		alert("Chua nhap Ngay Sinh");
		txtNgaySinh.focus();
		return false;
	}
	if (txtSoCMND.value=="")
	{
		alert("Chua nhap CMND");
		txtSoCMND.focus();
		return false;
	}
	if (txtDiaChiThuongTru.value=="")
	{
		alert("Chua nhap Dia Chi Thuong Tru");
		txtDiaChiThuongTru.focus();
		return false;
	}
	
	return true;
}
</script>
<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="96%" border="0">
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Họ và tên <FONT color="#ff0000">*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" EnableViewState="true" runat="server" CssClass="QH_textbox" Width="80%"></asp:textbox><asp:dropdownlist id="ddlGioiTinh" EnableViewState="true" runat="server" CssClass="QH_DropDownList"
				Width="19%">
				<asp:ListItem Value="1" Selected="True">Nam</asp:ListItem>
				<asp:ListItem Value="0">Nữ</asp:ListItem>
			</asp:dropdownlist></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%" height="3">Ngày sinh <FONT color="#ff0000">
				*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtNgaySinh" CssClass="QH_TextBox" Width="40%" Runat="server"></asp:textbox>&nbsp;</td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Dân tộc</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtDanToc" CssClass="QH_TextBox" Width="100%" Runat="server"></asp:textbox></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Số CMND <FONT color="#ff0000">*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoCMND" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="20"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%" height="18">Nơi cấp</td>
		<td class="QH_ColControl" width="35%" height="18"><asp:textbox id="txtNoiCapCMND" CssClass="QH_TextBox" Width="100%" Runat="server"></asp:textbox></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%" height="18">Ngày cấp</td>
		<td class="QH_ColControl" width="35%" height="18"><asp:textbox id="txtNgayCapCMND" CssClass="QH_TextBox" Width="40%" Runat="server"></asp:textbox>&nbsp;</td>
	</tr>
	<TR>
		<TD class="QH_ColLabel" vAlign="middle" width="15%">Thường trú <FONT color="#ff0000">*</FONT></TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTru" CssClass="QH_TextBox" Width="100%" Runat="server"></asp:textbox></TD>
		<TD class="QH_ColLabel" vAlign="middle" width="15%">Chỗ ở hiện nay</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNay" CssClass="QH_TextBox" Width="100%" Runat="server"></asp:textbox></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" width="100%" colSpan="4"><BR>
			<asp:linkbutton id="btnThem" runat="server" CssClass="QH_Button">Thêm</asp:linkbutton><asp:linkbutton id="btnSua" runat="server" CssClass="QH_Button" Visible="False">Sửa</asp:linkbutton></TD>
	</TR>
	<TR>
		<td vAlign="middle" width="100%" colSpan="4" height="23"><asp:label id="Label2" runat="server" CssClass="QH_LabelLeftBold" Width="100%">
				<b>Danh sách xã viên</b></asp:label></td>
	</TR>
	<TR>
		<TD vAlign="top" align="center" width="100%" colSpan="4"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGridBottom" Width="100%" Runat="server" AllowPaging="True"
				autogeneratecolumns="False" CellPadding="3">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="STT">
						<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="HoTen" HeaderText="Họ t&#234;n">
						<HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SoCMND" HeaderText="Số CMND">
						<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NgaySinh" HeaderText="Ng&#224;y sinh">
						<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DiaChiThuongTru" HeaderText="Địa chỉ thường tr&#250;">
						<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Sửa">
						<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:ImageButton id="imgSua" runat="server" CommandName="Sua" ImageUrl="~/images/edit.gif"></asp:ImageButton>
						</ItemTemplate>
						<FooterStyle HorizontalAlign="Center"></FooterStyle>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="X&#243;a">
						<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:ImageButton id="imgXoa" runat="server" CommandName="Xoa" ImageUrl="~/images/delete.gif"></asp:ImageButton>
						</ItemTemplate>
						<FooterStyle HorizontalAlign="Center"></FooterStyle>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
</table>
