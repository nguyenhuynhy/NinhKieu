<%@ Control language="vb" Inherits="PortalQH.Discussion" CodeBehind="Discussion.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<asp:DataList id="lstDiscussions" runat="server" Summary="Discussion Design Table" CellPadding="4"
	DataKeyField="Parent" ItemStyle-Cssclass="Normal">
	<ItemTemplate>
		<asp:ImageButton id="btnSelect" AlternateText="Select" ImageUrl='<%# NodeImage(Cint(DataBinder.Eval(Container.DataItem, "ChildCount"))) %>' CommandName="select" runat="server" />
		<asp:hyperlink Text='<%# FormatMultiLine(DataBinder.Eval(Container.DataItem, "Title")) %>' NavigateUrl='<%# EditUrl("ItemID",DataBinder.Eval(Container.DataItem, "ItemID")) & "&itemindex=" & lstDiscussions.Items.Count %>' runat="server" />, 
		from&nbsp;<%# FormatUser(DataBinder.Eval(Container.DataItem,"CreatedByUser")) %>, 
		posted
		<%# DataBinder.Eval(Container.DataItem,"CreatedDate", "{0:g}") %>
	</ItemTemplate>
	<SelectedItemTemplate>
		<asp:ImageButton id="btnCollapse" AlternateText="Collapse" ImageUrl="~/images/minus.gif" runat="server"
			CommandName="collapse" />
		<asp:hyperlink Text='<%# FormatMultiLine(DataBinder.Eval(Container.DataItem, "Title")) %>' NavigateUrl='<%# EditUrl("ItemID",DataBinder.Eval(Container.DataItem, "ItemID")) & "&itemindex=" & lstDiscussions.Items.Count %>' runat="server" />, 
		from&nbsp;<%# FormatUser(DataBinder.Eval(Container.DataItem,"CreatedByUser")) %>, 
		posted
		<%# DataBinder.Eval(Container.DataItem,"CreatedDate", "{0:g}") %>
		<asp:DataList id="DetailList" ItemStyle-Cssclass="Normal" datasource="<%# GetThreadMessages() %>" runat="server">
			<ItemTemplate>
				<br>
				<%# IndentChild(DataBinder.Eval(Container.DataItem, "Indent")) %>
				<asp:hyperlink Text='<%# FormatMultiLine(DataBinder.Eval(Container.DataItem, "Title")) %>' NavigateUrl='<%# EditUrl("ItemID",DataBinder.Eval(Container.DataItem, "ItemID")) & "&itemindex=" & lstDiscussions.Items.Count %>' runat="server" />, 
				from&nbsp;<%# FormatUser(DataBinder.Eval(Container.DataItem,"CreatedByUser")) %>, 
				posted
				<%# DataBinder.Eval(Container.DataItem,"CreatedDate", "{0:g}") %>
			</ItemTemplate>
		</asp:DataList>
	</SelectedItemTemplate>
</asp:DataList>
