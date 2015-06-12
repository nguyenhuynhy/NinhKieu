<%@ Import Namespace="PortalQH" %>
<%@ Control Inherits="PortalQH.Users" CodeBehind="Users.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*">&nbsp;
					</td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<tr>
		<td vAlign="top" align="center" width="70%">
			<table class="QH_LoaiHS" cellSpacing="0" cellPadding="0" width="70%" border="0">
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td class="QH_ColLabel2" vAlign="middle" width="15%">Nội dung tìm
					</td>
					<td vAlign="middle" width="25%"><asp:textbox id="txtNoiDung" runat="server" cssclass="QH_Textbox" Width="100%"></asp:textbox></td>
					<td class="QH_ColLabel2" vAlign="middle" width="10%">Tìm theo
					</td>
					<td vAlign="middle" width="25%"><asp:dropdownlist id="ddlHinhThucTim" runat="server" cssclass="QH_DropdownList" Width="100%">
							<asp:ListItem Value="0">Theo tên tài khoản</asp:ListItem>
							<asp:ListItem Value="1">Theo địa chỉ mail</asp:ListItem>
							<asp:ListItem Value="2">Theo tên đầy đủ</asp:ListItem>
						</asp:dropdownlist></td>
					<td vAlign="middle" width="20%"><asp:linkbutton id="lnkTim" runat="server" CssClass="QH_button">Tìm kiếm</asp:linkbutton></td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
			</table>
		</td>
	</tr>
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
					<td width="*"><asp:datagrid id="grdABC" runat="server" AllowPaging="True" AutoGenerateColumns="false" width="100%"
							CellPadding="1" border="0">
							<PagerStyle Position="Top" HorizontalAlign="Center"></PagerStyle>
							<Columns>
								<asp:TemplateColumn HeaderText=""></asp:TemplateColumn>
							</Columns>
						</asp:datagrid><asp:datagrid id="grdUsers" runat="server" AllowPaging="True" AutoGenerateColumns="false" width="100%"
							CellPadding="4" Border="0">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
							<Columns>
								<asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Sửa">
									<ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink NavigateUrl='<%# EditURL("UserID",DataBinder.Eval(Container.DataItem,"UserID")) %>' runat="server" ID="Hyperlink1">
											<asp:Image ImageUrl="~/images/edit.gif" runat="server" ID="Hyperlink1Image" />
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Stt" HeaderStyle-HorizontalAlign="Right">
									<ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle>
									<ItemTemplate>
										<%# grdUsers.CurrentPageIndex*grdUsers.PageSize + grdUsers.Items.Count+1 %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="">
									<ItemStyle Width="2%"></ItemStyle>
									<ItemTemplate>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="Tên đầy đủ" DataField="FullName" HeaderStyle-HorizontalAlign="Left"
									ItemStyle-Width="40%" />
								<asp:BoundColumn HeaderText="Tên dang nhập" DataField="Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="23%" />
								<asp:BoundColumn HeaderText="Ðịa chỉ Email" DataField="Email" HeaderStyle-HorizontalAlign="Left"
									ItemStyle-Width="20%" />
								<asp:TemplateColumn HeaderText="Kích hoạt" HeaderStyle-HorizontalAlign="Center">
									<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkActive" Runat="server" Enabled=False Checked='<%# DataBinder.Eval(Container, "DataItem.Active")%>'>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid><asp:linkbutton id="cmdAddNew" runat="server" CssClass="QH_Button">Add New User</asp:linkbutton>&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="UpdateLDAPUser" runat="server" CssClass="QH_Button">Update LDAP Users</asp:linkbutton></td>
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
