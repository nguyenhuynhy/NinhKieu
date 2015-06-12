<%@ Control Inherits="PortalQH.Roles" CodeBehind="Roles.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title EditText="Add New Role" runat="server" ID="Title1" />
<asp:datagrid id="grdRoles" Border="0" CellPadding="4" CellSpacing="0" Width="100%" AutoGenerateColumns="false" EnableViewState="false" runat="server" summary="Roles Design Table">
	<Columns>
		<asp:TemplateColumn ItemStyle-Width="20">
			<ItemTemplate>
				<asp:HyperLink NavigateUrl='<%# EditURL("RoleID",DataBinder.Eval(Container.DataItem,"RoleID")) %>' Visible="<%# IsEditable %>" runat="server" ID="Hyperlink1"><asp:Image ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%# IsEditable %>" runat="server" ID="Hyperlink1Image"/></asp:HyperLink>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Name" DataField="RoleName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Description" DataField="Description" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:TemplateColumn HeaderText="Fee" HeaderStyle-CssClass="NormalBold">
			<ItemTemplate>
				<asp:Label runat="server" Text='<%#FormatPrice(DataBinder.Eval(Container.DataItem, "ServiceFee")) %>' CssClass="Normal" ID="Label1"/>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn HeaderText="Every" HeaderStyle-CssClass="NormalBold">
			<ItemTemplate>
				<asp:Label runat="server" Text='<%#FormatPeriod(DataBinder.Eval(Container.DataItem, "BillingPeriod")) %>' CssClass="Normal" ID="Label2"/>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Period" DataField="BillingFrequency" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:TemplateColumn HeaderText="Trial" HeaderStyle-CssClass="NormalBold">
			<ItemTemplate>
				<asp:Label runat="server" Text='<%#FormatPrice(DataBinder.Eval(Container.DataItem, "TrialFee")) %>' CssClass="Normal" ID="Label3"/>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn HeaderText="Every" HeaderStyle-CssClass="NormalBold">
			<ItemTemplate>
				<asp:Label runat="server" Text='<%#FormatPeriod(DataBinder.Eval(Container.DataItem, "TrialPeriod")) %>' CssClass="Normal" ID="Label4"/>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Period" DataField="TrialFrequency" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Public" DataField="IsPublic" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
		<asp:BoundColumn HeaderText="Auto" DataField="AutoAssignment" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
	</Columns>
</asp:datagrid>
