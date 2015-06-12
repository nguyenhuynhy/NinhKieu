<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ViPhamHanhChinhList.ascx.vb" Inherits="CPXD.ViPhamHanhChinhList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">Danh sách đơn vị vi phạm hành chính</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
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
					<td align="center" width="*">
						<TABLE class="QH_Table" cellSpacing="0" cellPadding="0" width="95%" border="0" class="QH_Table">
							<br>
							<TR>
								<TD class="QH_ColLabel" width="15%">Số quyết định</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoQuyetDinh" Width="70%" CssClass="QH_TextBox" Runat="server"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Số nhà</TD>
								<TD class="QH_ColControl" width="*"><asp:textbox id="txtSoNha" Width="90%" CssClass="QH_TextBox" Runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Số giấy phép</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtSoGiayPhep" Width="70%" CssClass="QH_TextBox" Runat="server"></asp:textbox></TD>
								<TD class="QH_ColLabel">Đường</TD>
								<TD class="QH_ColControl"><asp:dropdownlist id="ddlDuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Số CMND</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" Width="70%" CssClass="QH_TextBox" Runat="server"></asp:textbox></TD>
								<TD class="QH_ColLabel">Phường</TD>
								<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD colSpan="4" height="5"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="4">
									<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton>&nbsp;
								</TD>
							<tr>
								<TD align="right" colSpan="4"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" MaxLength="3" Runat="server"
										AutoPostBack="True"></asp:textbox></TD>
							</tr>
							<TR>
								<TD colspan="4">
									<asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" AllowPaging="True"
										autogeneratecolumns="False" CellPadding="3">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
								</TD>
							</TR>
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
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
