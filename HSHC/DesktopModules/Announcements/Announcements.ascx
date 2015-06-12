<%@ Control language="vb" Inherits="PortalQH.Announcements" CodeBehind="Announcements.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<asp:DataList id="lstAnnouncements" runat="server" Summary="Announcements Design Table" CellPadding="4"
	EnableViewState="False">
	<ItemTemplate>
		<asp:HyperLink id="editLink" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' Visible="<%#IsEditable%>" runat="server">
			<asp:Image id="editLinkImage" AlternateText="Edit" Visible="<%#IsEditable%>" ImageUrl="~/images/edit.gif" Runat=Server/>
		</asp:HyperLink>
		<span class="SubHead">
			<%# DataBinder.Eval(Container.DataItem,"Title") %>
		</span>
		<br>
		<span class="Normal">
        <%# DataBinder.Eval(Container.DataItem,"Description") %>
        &nbsp;
        <asp:HyperLink id="moreLink" NavigateUrl='<%# FormatURL(DataBinder.Eval(Container.DataItem,"URL"),DataBinder.Eval(Container.DataItem,"ItemID")) %>' Visible='<%# DataBinder.Eval(Container.DataItem,"URL") <> String.Empty %>' runat="server">
            read more...</asp:HyperLink>
    </span>
		<br>
	</ItemTemplate>
</asp:DataList>
