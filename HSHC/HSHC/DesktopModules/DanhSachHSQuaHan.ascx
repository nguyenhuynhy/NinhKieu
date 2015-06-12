<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachHSQuaHan.ascx.vb" Inherits="HSHC.DanhSachHSQuaHan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= ResolveUrl("~/Inc/Common.js")%>'>
</script>
<script language=javascript 
src='<%= ResolveUrl("~/Inc/popcalendar.js")%>'>
</script>
<script language=javascript src='<%= ResolveUrl("~/Inc/Popupcalendar.js")%>'>
</script>
<script language="javascript">
function reportShow(){
	var LinhVuc, TuNgay, DenNgay;
	LinhVuc = document.getElementById("<%= ddlLinhVuc.ClientID%>");
	TuNgay = document.getElementById("<%= txtTuNgay.ClientID%>").value;
	DenNgay = document.getElementById("<%= txtDenNgay.ClientID%>").value;
	var Formula = "TenLinhVuc;TuNgay;DenNgay";
	var FormulaValue = LinhVuc.options[LinhVuc.selectedIndex].text;
	FormulaValue += ";" + TuNgay;
	FormulaValue += ";" + DenNgay;
	var sSQL = "sp_DanhSachHSQuaHan ";
	sSQL += "N'" + LinhVuc.value + "'";
	sSQL += ",N'" + document.getElementById("<%= ddlLoaiHoSo.ClientID%>").value + "'";
	sSQL += ",N'" + TuNgay + "'";
	sSQL += ",N'" + DenNgay + "'";
	var path = '<%= ResolveUrl("~/HSHC")%>';
	ShowReport("CTQTTLQuaHan.rpt", sSQL, Formula, FormulaValue, path);
	return false;
}
</script>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td>
			<table width="80%" align="center">
				<TR>
					<TD class="QH_ColLabel" width="15%">Lĩnh vực hồ sơ</TD>
					<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlLinhVuc" runat="server" CssClass="QH_DropDownList" AutoPostBack="True" Width="95%"></asp:dropdownlist></TD>
					<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
					<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlLoaiHoSo" runat="server" CssClass="QH_DropDownList" Width="95%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
					<TD class="QH_ColControl" width="35%"><asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
					<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
					<TD class="QH_ColControl" width="35%"><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Cán bộ thụ lý</TD>
					<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaNguoiNhan" runat="server" CssClass="QH_DropDownList" Width="60%"></asp:dropdownlist></TD>
					<TD class="QH_ColLabel" width="15%">Tình trạng hồ sơ</TD>
					<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaTinhTrang" runat="server" CssClass="QH_DropDownList" Width="95%"></asp:dropdownlist></TD>
				</TR>
			</table>
		</td>
	</tr>
	<TR>
		<TD align="center" width="70%"><asp:linkbutton id="btnPreview" runat="server" CssClass="QH_Button">Xem trước</asp:linkbutton>&nbsp;
			<asp:linkbutton id="btnInRaGiay" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>&nbsp;
			<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
	</TR>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<TR>
		<TD align="right"><asp:label id="Label1" cssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Width="50px" CssClass="QH_TextRight" AutoPostBack="True" Runat="server"
				MaxLength="3"></asp:textbox></TD>
	</TR>
	<tr>
		<td>
			<asp:DataGrid ID="dgDanhSach" Runat="server" Width="100%" CssClass="QH_DataGrid" CellPadding="3"
				PagerStyle-Mode="NumericPages" AllowSorting="True" AllowPaging="True" autogeneratecolumns="False">
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="Số bi&#234;n nhận">
						<ItemTemplate>
							<asp:LinkButton ID="btnViewHistory" Runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.HoSoTiepNhanID") %>' CommandName="ViewHistory">
								<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>
							</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="TenLoaiHoSo" HeaderText="Loại hồ sơ"></asp:BoundColumn>
					<asp:BoundColumn DataField="NgayNhan" HeaderText="Ng&#224;y nhận (của t&#236;nh trạng qu&#225; hạn)"></asp:BoundColumn>
					<asp:BoundColumn DataField="SoNgayGiaiQuyet" HeaderText="Số ng&#224;y giải quyết"></asp:BoundColumn>
					<asp:BoundColumn DataField="SoNgayQuaHan" HeaderText="Số ng&#224;y quá hạn"></asp:BoundColumn>
					<asp:BoundColumn DataField="TinhTrangQuaHan" HeaderText="T&#236;nh trạng qu&#225; hạn"></asp:BoundColumn>
					<asp:BoundColumn DataField="NguoiThuLy" HeaderText="Người thụ l&#253;"></asp:BoundColumn>
					<asp:BoundColumn DataField="TinhTrangHienTai" HeaderText="T&#236;nh trạng hiện tại"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="HoSoTiepNhanID"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</td>
	</tr>
</table>
