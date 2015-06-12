<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Codebehind="Affiliates.ascx.vb" Inherits="PortalQH.Affiliates" %>
<asp:datagrid id="grdAffiliates" runat="server" Width="100%" Border="0" CellSpacing="3" AutoGenerateColumns="false" EnableViewState="true">
	<Columns>
		<asp:TemplateColumn ItemStyle-Width="20">
			<ItemTemplate>
				<asp:HyperLink ImageUrl="~/images/edit.gif" NavigateUrl='<%# FormatURL("AffiliateId",DataBinder.Eval(Container.DataItem,"AffiliateId")) %>' runat="server" ID="Hyperlink2" />
			</ItemTemplate>
		</asp:TemplateColumn>
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
		<asp:BoundColumn HeaderText="CPC" DataField="CPC" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:#,##0.0000}" />
		<asp:BoundColumn HeaderText="Clicks" DataField="Clicks" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
		<asp:BoundColumn HeaderText="Total" DataField="CPCTotal" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:#,##0.0000}" />
		<asp:BoundColumn HeaderText="CPA" DataField="CPA" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:#,##0.0000}" />
		<asp:BoundColumn HeaderText="Acquisitions" DataField="Acquisitions" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
		<asp:BoundColumn HeaderText="Total" DataField="CPATotal" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:#,##0.0000}" />
	</Columns>
</asp:datagrid>
<br>
<asp:HyperLink CssClass="CommandButton" ID="cmdAdd" Runat="server" BorderStyle="None">Create New Affiliate</asp:HyperLink>

