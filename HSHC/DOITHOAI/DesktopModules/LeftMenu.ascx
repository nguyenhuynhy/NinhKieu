<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LeftMenu.ascx.vb" Inherits="DOITHOAI.LeftMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table class="MenuTable" width="100%" cellpadding="0" cellspacing="0" border="0">
	<!--<TR>
		<TD height="21">
			<asp:label id="lblHeader" runat="server" CssClass="QH_MenuHeader" Width="100%">Danh sách ngu?i s? d?ng</asp:label>
		</TD>
	</TR>-->
	<TR>
		<TD class="QH_MenuLeft_Header">Hỏi đáp</TD>
	</TR>
	<tr vAlign="top">
		<td class="QH_MenuLeft_Middle"><asp:datalist id="MyList" Width="94%" runat="server" EnableViewState="False">
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<SelectedItemStyle CssClass="QH_MenuLeft_Item_Selected"></SelectedItemStyle>
				<SeparatorStyle CssClass="QH_MenuSeparator"></SeparatorStyle>
				<ItemTemplate>
					<asp:HyperLink id="Hyperlink1" Width="100%" runat="server" Text='' NavigateUrl='<%# "~/Default.aspx?tabid="& cstr(request.params("TabID")) & "&SelectIndex=" &Cstr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma")%>' cssclass="QH_MenuLeft_Item">
						<asp:Label CssClass="QH_MenuLeft_ItemText" Runat="server" Width="100%" ID="Label2">
							<%# DataBinder.Eval(Container.DataItem, "Title") %>
						</asp:Label>
					</asp:HyperLink>
				</ItemTemplate>
			</asp:datalist></td>
	</tr>
	<TR>
		<TD class="QH_MenuLeft_Footer" height="25"></TD>
	</TR>
</table>
