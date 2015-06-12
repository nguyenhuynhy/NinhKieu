<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Codebehind="Banners.ascx.vb" Inherits="PortalQH.Banners" %>
<asp:datagrid id="grdBanners" runat="server" Width="100%" Border="0" CellSpacing="3" AutoGenerateColumns="false" EnableViewState="true" summary="Edit Vendors Design Table">
	<Columns>
		<asp:TemplateColumn ItemStyle-Width="20">
			<ItemTemplate>
				<asp:HyperLink NavigateUrl='<%# FormatURL("BannerId",DataBinder.Eval(Container.DataItem,"BannerId")) %>' runat="server" ID="Hyperlink1">
					<asp:Image ImageUrl="~/images/edit.gif" AlternateText="Edit" runat="server" ID="Hyperlink1Image" />
				</asp:HyperLink>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn HeaderText="Banner" DataField="BannerName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Type" DataField="BannerTypeName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="URL" DataField="URL" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="Impressions" DataField="Impressions" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
		<asp:BoundColumn HeaderText="CPM" DataField="CPM" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:#,##0.00}" />
		<asp:BoundColumn HeaderText="Views" DataField="Views" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
		<asp:BoundColumn HeaderText="Clicks" DataField="ClickThroughs" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
		<asp:TemplateColumn HeaderText="Start" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
			<ItemTemplate>
				<asp:Label ID="lblStartDate" Runat="server" Text='<%# DisplayDate(DataBinder.Eval(Container.DataItem, "StartDate")) %>'></asp:Label>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn HeaderText="End" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
			<ItemTemplate>
				<asp:Label ID="lblEndDate" Runat="server" Text='<%# DisplayDate(DataBinder.Eval(Container.DataItem, "EndDate")) %>'></asp:Label>
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
<br>
<asp:HyperLink CssClass="CommandButton" ID="cmdAdd" Runat="server" BorderStyle="None">Create New Banner</asp:HyperLink>
