<%@ Control language="vb" CodeBehind="Portals.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Portals" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" EditText="Add New Portal" EditURL="~/DesktopDefault.aspx?def=Signup" />
<asp:datagrid id="grdPortals" runat="server" Width="100%" EnableViewState="false" AutoGenerateColumns="false" CellSpacing="0" CellPadding="4" Border="0" summary="Portals Design Table">
	<Columns>
		<asp:TemplateColumn ItemStyle-Width="20">
			<ItemTemplate>
				<asp:HyperLink NavigateUrl='<%# EditURL("pid",DataBinder.Eval(Container.DataItem,"PortalID")) %>' runat="server" ID="Hyperlink1"><asp:Image ImageUrl="~/images/edit.gif" AlternateText="Edit" runat="server" ID="Hyperlink1Image"/></asp:HyperLink>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn HeaderText="Title" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
			<ItemTemplate>
				<asp:Label ID="lblPortal" Runat="server" Text='<%# FormatPortal(DataBinder.Eval(Container.DataItem, "PortalName"),DataBinder.Eval(Container.DataItem, "PortalAlias")) %>'></asp:Label>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Alias" DataField="PortalAlias" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Users" DataField="Users" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
		<asp:BoundColumn HeaderText="Disk Space" DataField="HostSpace" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Hosting Fee" DataField="HostFee" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" DataFormatString="{0:0.00}" />
		<asp:TemplateColumn HeaderText="Expires" HeaderStyle-CssClass="NormalBold">
			<ItemTemplate>
				<asp:Label runat="server" Text='<%#FormatExpiryDate(DataBinder.Eval(Container.DataItem, "ExpiryDate")) %>' CssClass="Normal" ID="Label1"/>
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>

