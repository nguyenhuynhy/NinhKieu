<%@ Control Language="vb" AutoEventWireup="false" Codebehind="MenuList.ascx.vb" Inherits="PortalQH.MenuList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table class="MenuTable" width="100%">
	<!--<TR>
		<TD height="21">
			<asp:label id="lblHeader" runat="server" CssClass="QH_MenuHeader" Width="100%">Danh sách ngu?i s? d?ng</asp:label>
		</TD>
	</TR>-->
	<tr vAlign="top">
		<td><asp:datalist id="MyList" CssClass="QH_Menu" Width="100%" runat="server" EnableViewState="False">
				<HeaderStyle CssClass="QH_MenuHeader_THTT"></HeaderStyle>
				<HeaderTemplate>
				</HeaderTemplate>
				<SelectedItemStyle CssClass="QH_MenuSelected_THTT"></SelectedItemStyle>
				<SelectedItemTemplate>
					<asp:HyperLink id="HyperLink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' NavigateUrl='<%# "~/Default.aspx?tabid="& cstr(request.params("TabID")) & "&SelectItemCode=" & iSelectItemCode & "&SelectIndex=" & Cstr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma") & "&SelectTitle=" & DataBinder.Eval(Container.DataItem,"Title") %>'>
					</asp:HyperLink>
				</SelectedItemTemplate>
				<ItemStyle CssClass="QH_NEWS_MENU_ITEM_THTT"></ItemStyle>
				<ItemTemplate>
					<asp:HyperLink id="HyperLink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' NavigateUrl='<%# "~/Default.aspx?tabid="& cstr(request.params("TabID")) & "&SelectItemCode=" & iSelectItemCode & "&SelectIndex=" &Cstr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma") & "&SelectTitle=" & DataBinder.Eval(Container.DataItem,"Title") %>' cssclass="QH_MenuLink">
					</asp:HyperLink>
				</ItemTemplate>
				<SeparatorStyle CssClass="QH_MenuSelected_THTT"></SeparatorStyle>
			</asp:datalist></td>
	</tr>
	<!-- cssclass="QH_MenuLink_Selected"-->
</table>
