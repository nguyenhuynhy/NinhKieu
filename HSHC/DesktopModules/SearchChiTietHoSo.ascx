<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SearchChiTietHoSo.ascx.vb" Inherits="SearchChiTietHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language="javascript">
function rptHistory(res,formula,values){
	ShowReport("BCLichSu.rpt","sp_rptHistory N'" + res + "'",formula,values,"CPKTQH");
	return false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label1" runat="server" Width="100%" CssClass="QH_Label_Title">Chi tiết hồ sơ</asp:label></td>
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
					<td>
						<table>
							<TBODY>
								<TR>
									<td colSpan="4">
										<TABLE id="myTable" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0"
											runat="server">
										</TABLE>
									</td>
								</TR>
								<tr>
									<TD width="10%" colSpan="4"></TD>
								</tr>
								<TR>
									<TD align="center" colSpan="4"><asp:label id="Label12" Width="100%" CssClass="QH_Label_Title1" Runat="server">Quá trình giải quyết hồ sơ</asp:label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" autogeneratecolumns="False"
											AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages" CellPadding="3" PageSize="20">
											<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
											<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="STT">
													<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' ID="Label25">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="NgayThuLy" HeaderText="Ngày thụ lý"></asp:BoundColumn>
												<asp:BoundColumn DataField="TenCongViec" HeaderText="Công việc"></asp:BoundColumn>
												<asp:BoundColumn DataField="NguoiThuLy" HeaderText="Người thụ lý"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR id="rowTitle" runat="server">
									<TD align="center" colSpan="4"><asp:label id="Label2" Width="100%" CssClass="QH_Label_Title1" Runat="server">Lịch sử hồ sơ</asp:label></TD>
								</TR>
								<TR id="rowHistory" runat="server">
									<TD align="center" colSpan="4">
										<asp:datagrid id="dgdHistory" CssClass="QH_DataGrid" Width="100%" Runat="server" autogeneratecolumns="False"
											AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages" CellPadding="3" PageSize="20">
											<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
											<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="STT">
													<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# dgdHistory.CurrentPageIndex*dgdHistory.PageSize + dgdHistory.Items.Count+1 %>' ID="Label3">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="Ngay" HeaderText="Ngày"></asp:BoundColumn>
												<asp:BoundColumn DataField="CongViec" HeaderText="Công việc"></asp:BoundColumn>
												<asp:BoundColumn DataField="NoiDung" HeaderText="Nội dung"></asp:BoundColumn>
												<asp:BoundColumn DataField="SoGiayPhep" HeaderText="Số giấy phép"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
									</TD>
								</TR>
								<tr>
									<td align="center" colSpan="4"><asp:linkbutton id="btnInLichSu" runat="server" CssClass="QH_Button" Visible="False">In lịch sử</asp:linkbutton>&nbsp;<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;
									</td>
								</tr>
					</td>
			</table>
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
</TABLE>
</TD></TR></TBODY></TABLE>
