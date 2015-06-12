<%@ Control language="vb" Inherits="PortalQH.DisplayBanners" CodeBehind="DisplayBanners.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<asp:DataList id=lstBanners runat="server" CellPadding="4" Summary="Banner Design Table" EnableViewState="false">
	<ItemStyle HorizontalAlign="Center"></ItemStyle>
	<ItemTemplate>
	    <asp:HyperLink id="Hyperlink1" Runat="server"  NavigateUrl=' <%# "~/Admin/Vendors/BannerClickThrough.aspx?BannerId=" & DataBinder.Eval(Container.DataItem,"BannerId") & "&VendorId=" & DataBinder.Eval(Container.DataItem,"VendorId") %> '><asp:Image id="editLinkImage" AlternateText=' <%# DataBinder.Eval(Container.DataItem,"BannerName") %> ' ImageUrl=' <%# FormatImagePath(DataBinder.Eval(Container.DataItem,"ImageFile")) %> ' Runat=Server/></asp:HyperLink>
		<br>
	</ItemTemplate>
</asp:DataList>
