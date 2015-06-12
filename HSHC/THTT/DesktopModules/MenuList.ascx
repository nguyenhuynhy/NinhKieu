<%@ Control Language="vb" AutoEventWireup="false" Codebehind="MenuList.ascx.vb" Inherits="THTT.MenuList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0" class="QH_tableMain">
	<TR>
		<TD width="2" Class="QH_HeaderLeft_THTT"></TD>
		<TD width="*">
			<asp:label id="lblHeader" Width="100%" runat="server" CssClass="QH_Header_THTT">TỔNG HỢP THÔNG TIN</asp:label>
		</TD>
		<td width="4" align="right" class="QH_HeaderRight_THTT"></td>
	</TR>
	<tr valign="top">
		<td valign="top" colspan="3"><asp:datalist id="MyList" CssClass="QH_NEWS_MENU_THTT" Width="100%" runat="server" EnableViewState="False">
				<HeaderStyle CssClass="QH_MenuHeader_THTT"></HeaderStyle>
				<HeaderTemplate>
				</HeaderTemplate>
				<SelectedItemStyle CssClass="QH_MenuSelected_THTT"></SelectedItemStyle>
				<SelectedItemTemplate>
					<asp:HyperLink id="HyperLink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' NavigateUrl='<%# GetLink() & "&SelectIndex=" & Cstr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma") & "&LinhVuc=" & DataBinder.Eval(Container.DataItem, "Ma") & "&SelectTitle=" & DataBinder.Eval(Container.DataItem,"Title") & "&SelectChildIndex=0" %>'>
					</asp:HyperLink>
				</SelectedItemTemplate>
				<ItemStyle CssClass="QH_NEWS_MENU_ITEM_THTT"></ItemStyle>
				<ItemTemplate>
					<asp:HyperLink id="HyperLink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' NavigateUrl='<%# GetLink() & "&SelectIndex=" & CStr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma") & "&LinhVuc=" & DataBinder.Eval(Container.DataItem, "Ma") & "&SelectTitle=" & DataBinder.Eval(Container.DataItem, "Title") & "&SelectChildIndex=0" %>' cssclass="QH_MenuLink">
					</asp:HyperLink>
				</ItemTemplate>
				<SeparatorStyle CssClass="QH_MenuSelected_THTT"></SeparatorStyle>
			</asp:datalist></td>
	</tr>
</table>
