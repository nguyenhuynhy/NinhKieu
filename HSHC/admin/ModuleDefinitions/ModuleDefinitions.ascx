<%@ Control CodeBehind="ModuleDefinitions.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.ModuleDefinitions" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" EditText="Add New Module Definition" />
<div align="center" class="Normal">
	<asp:Label ID="lblMessage" runat="server" CssClass="Normal></asp:Label>
</div>
<asp:datagrid id="grdDefinitions" Border="0" CellPadding="4" cellspacing="4" AutoGenerateColumns="false" EnableViewState="false" runat="server" summary="Module Defs Design Table">
	<Columns>
		<asp:TemplateColumn ItemStyle-Width="20">
			<ItemTemplate>
				<asp:HyperLink NavigateUrl='<%# EditURL("desktopmoduleid",DataBinder.Eval(Container.DataItem,"DesktopModuleId")) %>' Visible="<%# IsEditable %>" runat="server" ID="Hyperlink1"><asp:Image ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%# IsEditable %>" runat="server" ID="Hyperlink1Image"/></asp:HyperLink>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Module Name" DataField="FriendlyName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-Wrap="False" HeaderStyle-Wrap="False" />
		<asp:BoundColumn HeaderText="Description" DataField="Description" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Premium" DataField="IsPremium" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
	</Columns>
</asp:datagrid>