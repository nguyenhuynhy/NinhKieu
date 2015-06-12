<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SearchInfo.ascx.vb" Inherits="SearchInfo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= ResolveUrl("~/Inc/Common.js")%>'></script>
<script language=javascript 
src='<%= ResolveUrl("~/Inc/popcalendar.js")%>'></script>
<script language=javascript 
src='<%= ResolveUrl("~/Inc/Popupcalendar.js")%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" colSpan="2" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label3" runat="server" CssClass="QH_Label_Title" Width="100%">Tìm kiếm thông tin hồ sơ</asp:label></td>
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
							<TR>
								<TD width="100%">
									<TABLE id="Table2" class="QH_LoaiHS" cellSpacing="0" cellPadding="0" width="100%" align="center"
										border="0" runat="server">
										<tr>
											<td width="15%"><asp:label id="Label1" CssClass="QH_LabelBold" Width="100%" Runat="server"> Lĩnh vực</asp:label></td>
											<td width="75%"><asp:dropdownlist id="ddlLoaiHoSo" Width="92%" CssClass="QH_DropDownList" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
											<td width="5%"><asp:label id="Label2" CssClass="QH_LabelBold" Width="100%" Runat="server" Visible="False">Thông tin tìm kiếm</asp:label></td>
											<td width="5%"><asp:radiobuttonlist id="lstReports" runat="server" Width="92%" AutoPostBack="True" Visible="False"></asp:radiobuttonlist></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="myTable" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0"
										runat="server">
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td>
									<table width="100%" cellpadding="0" cellspacing="0">
										<tr>
											<td width="55%" align="right">
												<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>
											</td>
											<td width="45%" align="right"><asp:label id="Label4" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" Runat="server" AutoPostBack="True"
													MaxLength="3"></asp:textbox>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD colSpan="4"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" CellPadding="3"
										AllowPaging="True" AllowSorting="True" autogeneratecolumns="False">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</table>
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
		</td>
	</tr>
</TABLE>
