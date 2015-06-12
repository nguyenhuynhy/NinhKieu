<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Codebehind="Search.ascx.vb" Inherits="PortalQH.Search" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title EditText="Edit" runat="server" ID="Title1" />
<asp:Panel ID="pnlModuleContent" Runat="server">
<TABLE cellSpacing=0 cellPadding=4 border=0 summary="Search Design Table">
  <TR vAlign=top>
    <TD noWrap align=middle>
<label class="SubHead" for="<%=txtSearch.ClientID%>">Search:</label>&nbsp; 
<asp:TextBox id=txtSearch runat="server" cssclass="NormalTextBox" maxlength="100" columns="35" Width="150px"></asp:TextBox>
<asp:LinkButton id=cmdGo Runat="server" CssClass="CommandButton">Go</asp:LinkButton></TD></TR>
  <TR vAlign=top>
    <TD>
<asp:DataList id=lstResults runat="server" Width="100%" CellPadding="4" EnableViewState="false">
					<ItemTemplate>
						<asp:Label ID="lblResult" Runat="server">
							<%# FormatResult(DataBinder.Eval(Container.DataItem,"TabId"),DataBinder.Eval(Container.DataItem,"TabName"),DataBinder.Eval(Container.DataItem,"ModuleTitle"),DataBinder.Eval(Container.DataItem,"TitleField"),DataBinder.Eval(Container.DataItem,"DescriptionField"),DataBinder.Eval(Container.DataItem,"CreatedDateField"),DataBinder.Eval(Container.DataItem,"CreatedByUserField")) %>
						</asp:Label>
					</ItemTemplate>
				</asp:DataList></TD></TR></TABLE>
</asp:Panel>
