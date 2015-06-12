<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Codebehind="Vendors.ascx.vb" Inherits="PortalQH.Vendors" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title EditText="Add New Vendor" runat="server" ID="Title1" />
<asp:datagrid id="grdVendors" Border="0" CellPadding="4" width="100%" AutoGenerateColumns="false" EnableViewState="false" runat="server" AllowPaging="True" summary="Vendors Design Table">
	<PagerStyle Position="Top" HorizontalAlign="Center"></PagerStyle>
	<Columns>
		<asp:TemplateColumn ItemStyle-Width="20">
			<ItemTemplate>
				<asp:HyperLink NavigateUrl='<%# FormatURL("VendorID",DataBinder.Eval(Container.DataItem,"VendorID")) %>' Visible="<%# IsEditable %>" runat="server" ID="Hyperlink1"><asp:Image ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%# IsEditable %>" runat="server" ID="Hyperlink1Image"/></asp:HyperLink>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Name" DataField="VendorName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:TemplateColumn HeaderText="Address" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
			<ItemTemplate>
				<asp:Label ID="lblAddress" Runat="server" Text='<%# DisplayAddress(DataBinder.Eval(Container.DataItem, "Unit"),DataBinder.Eval(Container.DataItem, "Street"), DataBinder.Eval(Container.DataItem, "City"), DataBinder.Eval(Container.DataItem, "Region"), DataBinder.Eval(Container.DataItem, "Country"), DataBinder.Eval(Container.DataItem, "PostalCode")) %>'></asp:Label>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Telephone" DataField="Telephone" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Fax" DataField="Fax" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:TemplateColumn HeaderText="Email" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
			<ItemTemplate>
				<asp:Label ID="lblEmail" Runat="server" Text='<%# DisplayEmail(DataBinder.Eval(Container.DataItem, "Email")) %>'></asp:Label>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Authorized" DataField="Authorized" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
		<asp:BoundColumn HeaderText="Banners" DataField="Banners" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
	</Columns>
</asp:datagrid>
<p align="center">
<asp:Label Runat="server" CssClass="Normal">Vendors are used within the portal for managing your Service Directory as well as Banner Advertising</asp:Label>
</p>
<p align="center">
<asp:LinkButton ID="cmdDelete" Runat="server" CssClass="CommandButton">Delete Unauthorized Vendors</asp:LinkButton>
</p>
