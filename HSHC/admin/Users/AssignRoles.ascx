<%@ Control Language="vb" AutoEventWireup="false" Codebehind="AssignRoles.ascx.vb" Inherits="PortalQH.AssignRoles" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript"> 
function CheckNullGrid()
{
	var j,flag;
	flag=0;
	var NameOfCheckbox;
	for (j=3; j<eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdUsers")').rows.length+1; j++)
		{
		NameOfCheckbox = "<%=Me.ClientID%>_dgdUsers__ctl" + j + "_" + "dgdchkChonUser";
		if(eval('document.forms[0].all("' + NameOfCheckbox + '")').checked)
			{
				flag=1;		
				break;	
			}
		}
	if (flag == 0)
		{
			alert('Bạn phải chọn một user!');
			return false;
		}
	return true;	
}	

function select_deselect()
{
	var j,flag;
	
	var NameOfCheckbox;
	for (j=3; j<eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdUsers")').rows.length+1; j++)
		{
		NameOfCheckbox = "<%=Me.ClientID%>_dgdUsers__ctl" + j + "_" + "dgdchkChonUser";
		if(eval('document.forms[0].all("' + NameOfCheckbox + '")').checked)
			{
				eval('document.forms[0].all("' + NameOfCheckbox + '")').checked = false;
				break;	
			}
		}	
	return true;	
}
</script>
<TABLE width="800" align="center">
	<tr>
		<td><asp:label id="Label1" Cssclass="QH_Header_Login" Width="100%" runat="server">Phân quyền</asp:label></td>
	</tr>
	<tr>
		<td>
			<table class="QH_Table" width="800">
				<tr>
					<td colspan="2" width="800" class="QH_TextBox" align="center">Tên truy cập:
						<asp:label id="lblFullName" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center" bgColor="#3399cc" colSpan="2" height="5"><font color="#333366"><b>Danh 
								Sách quyền</b></font></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:datagrid id="dgdRole" Width="800px" CssClass="QH_datagrid" Runat="server" AutoGenerateColumns="False"
							EnableViewState="false">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="STT">
									<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label align=center id="Label2" Enabled="True" runat="server" Text='<%# dgdRole.CurrentPageIndex*dgdRole.PageSize + dgdRole.Items.Count+1 %>' />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="RoleId" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="UserId" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="RoleName" HeaderStyle-Width="500px" DataField="RoleName"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Chọn quyền">
									<HeaderStyle Width="13%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgdRoleCheck" Runat="server" CssClass="QH_CheckBox"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td colspan="2" height="5"></td>
				</tr>
				<tr>
					<td colspan="2">
						<table>
							<tr>
								<td class="QH_ColLabel" width="200">UserName</td>
								<td class="QH_ColControl" width="600">
									<asp:TextBox ID="txtUserName" Runat="server" CssClass="QH_TextBox"></asp:TextBox>
								</td>
								<td class="QH_ColLabel" width="200">KeyWords</td>
								<td class="QH_ColControl" width="600">
									<asp:TextBox ID="txtKeyWords" Runat="server" CssClass="QH_TextBox"></asp:TextBox>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:linkbutton id="btnGetDanhSach" CssClass="QH_Button" Runat="server">Lấy danh sách</asp:linkbutton></td>
				<tr>
					<td align="right" colSpan="2"><asp:label id="label4" Runat="server">Số dòng hiển thị</asp:label>&nbsp;&nbsp;<asp:textbox id="txtSoDong" CssClass="QH_TextBox" Width="30px" Runat="server" AutoPostBack="True"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td align="center" bgColor="#3399cc" colSpan="2" height="5"><font color="#333366"><b>Danh 
								sách người có quyền tương đương</b></font></td>
				</tr>
				<tr>
					<td colSpan="2"><asp:datagrid id="dgdUsers" Width="100%" CssClass="QH_DataGrid" Runat="server" autogeneratecolumns="False"
							AllowPaging="true" CellPadding="3">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="STT">
									<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdUsers.CurrentPageIndex*dgdUsers.PageSize + dgdUsers.Items.Count+1 %>' />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="UserID" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="RoleID" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn HeaderStyle-Width="100px" HeaderText="Họ tên" DataField="FullName"></asp:BoundColumn>
								<asp:BoundColumn HeaderStyle-Width="100px" HeaderText="UserName" DataField="UserName"></asp:BoundColumn>
								<asp:BoundColumn HeaderStyle-Width="100px" HeaderText="Phòng ban" DataField="TenDonVi"></asp:BoundColumn>
								<asp:BoundColumn HeaderStyle-Width="100px" HeaderText="Role Name" DataField="RoleName"></asp:BoundColumn>
								<asp:BoundColumn HeaderStyle-Width="100px" HeaderText="KeyWords" DataField="KeyWords"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Chọn User">
									<HeaderStyle Width="13%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgdchkChonUser" Runat="server" CssClass="QH_CheckBox"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" Runat="server">Cập nhật</asp:linkbutton>&nbsp;
						<asp:linkbutton id="btnTroVe" CssClass="QH_Button" Runat="server">Trở về</asp:linkbutton></td>
				</tr>
			</table>
		</td>
	</tr>
</TABLE>
