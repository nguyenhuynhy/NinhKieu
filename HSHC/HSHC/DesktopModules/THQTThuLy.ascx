<%@ Control Language="vb" AutoEventWireup="false" Codebehind="THQTThuLy.ascx.vb" Inherits="HSHC.THQTThuLy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript src='<%= ResolveUrl("~/Inc/Common.js")%>'>
</script>
<script language=javascript src='<%= ResolveUrl("~/Inc/popcalendar.js")%>'>
</script>
<script language=javascript src='<%= ResolveUrl("~/Inc/Popupcalendar.js")%>'>
</script>
<script language="javascript">
function reportShow(){
	var LinhVuc, TuNgay, DenNgay;
	LinhVuc = document.getElementById("<%= ddlLinhVuc.ClientID%>");
	TuNgay = document.getElementById("<%= txtTuNgay.ClientID%>").value;
	DenNgay = document.getElementById("<%= txtDenNgay.ClientID%>").value;
	var Formula = "TenLinhVuc;TuNgay;ToiNgay";
	var FormulaValue = LinhVuc.options[LinhVuc.selectedIndex].text;
	FormulaValue += ";" + TuNgay;
	FormulaValue += ";" + DenNgay;
	var sSQL = "sp_THQTTLHoSo ";
	sSQL += "N'" + LinhVuc.value + "'";
	sSQL += ",N'" + document.getElementById("<%= ddlLoaiHoSo.ClientID%>").value + "'";
	sSQL += ",N'" + TuNgay + "'";
	sSQL += ",N'" + DenNgay + "'";
	var path = '<%= ResolveUrl("~/HSHC")%>';
	ShowReport("THQTThuLy.rpt", sSQL, Formula, FormulaValue, path);
	return false;
}
</script>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td>
			<table width="80%" align="center">
				<TR>
					<TD class="QH_ColLabel" width="15%">Lĩnh vực hồ sơ</TD>
					<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlLinhVuc" Width="95%" AutoPostBack="True" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
					<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
					<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlLoaiHoSo" Width="95%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
					<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTuNgay" Width="70px" CssClass="QH_TextBox" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
					<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
					<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDenNgay" Width="70px" CssClass="QH_TextBox" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
				</TR>
			</table>
		</td>
	</tr>
	<TR>
		<TD align="center" width="70%"><asp:linkbutton id="btnPreview" CssClass="QH_Button" runat="server">Xem trước</asp:linkbutton>&nbsp;
			<asp:linkbutton id="btnInRaGiay" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton></TD>
	</TR>
	<tr>
		<td>&nbsp;
		</td>
	</tr>
	<tr>
		<td align="center"><asp:datagrid id="dgDanhSach" Width="60%" CssClass="QH_DataGrid" Runat="server" autogeneratecolumns="False"
				AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages" ShowHeader="False">
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="Loại hồ sơ">
						<ItemTemplate>
							<table width="100%" border=0 cellpadding=0 cellspacing=0>
								<tr id="lblTenLoaiHoSo" Class="QH_TableHeader" runat="server" visible='<%# DataBinder.Eval(Container, "DataItem.TinhTrangOrder") = 1%>'>
									<td>
										<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo")%>
									</td>
								</tr>
								<tr>
									<td>
										<table width="100%" border=0>
											<tr id="lblHeaderDetail" Class="QH_TableHeader" runat=server visible='<%# DataBinder.Eval(Container, "DataItem.TinhTrangOrder") = 1%>'>
												<td width="40%" align=center>
													Tình trạng
												</td>
												<td width="30%" align=center>
													Số hồ sơ đúng hạn
												</td>
												<td width="30%" align=center>
													Số hồ sơ trễ hạn
												</td>
											</tr>
											<tr class="QH_TableItem">
												<td width="50%" >
													<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>
												</td>
												<td width="25%" align=center >
													<%# DataBinder.Eval(Container, "DataItem.SoHSDungHan") %>
												</td>
												<td width="25%" align=center >
													<%# DataBinder.Eval(Container, "DataItem.SoHSQuaHan") %>
												</td>
											</tr>
											<tr id="Tr2" class="QH_TableFooter" runat=server visible='<%# DataBinder.Eval(Container, "DataItem.TinhTrangOrder") = -1%>'>
												<td align=center>
													Tổng
												</td>
												<td  align=center>
													<asp:Label ID="lblTSHSQuaHan" Font-Bold="True" Runat="server">
														<%# DataBinder.Eval(Container, "DataItem.TSHSDungHan")%>
													</asp:Label>
												</td>
												<td align=center>
													<asp:LinkButton ID="btnDSQuaHan" Runat="server" Font-Bold="True" CommandName="DSQuaHan" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.MaLoaiHoSo")%>' Visible = '<%# DataBinder.Eval(Container, "DataItem.TSHSQuaHan") > 0%>'>
														<%# DataBinder.Eval(Container, "DataItem.TSHSQuaHan") %>
													</asp:LinkButton>
													<asp:Label ID="Label1" Runat="server" Font-Bold="True" Visible='<%# DataBinder.Eval(Container, "DataItem.TSHSQuaHan") = 0%>'>
														<%# DataBinder.Eval(Container, "DataItem.TSHSQuaHan")%>
													</asp:Label>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</td>
	</tr>
</table>
