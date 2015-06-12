<%@ Register TagPrefix="cc1" Namespace="SolpartWebControls" Assembly="SolpartWebControls" %>
<%@ Control CodeBehind="DesktopPortalBanner.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.DesktopPortalBanner" %>
<%@ Import Namespace="PortalQH"%>
<table cellSpacing="0" cellPadding="0" width="100%" border="0" summary="Banner Heading Design Table">
	<tr class="HeadBg">
		<td width="100%" colSpan="2" height="3"><asp:image id="imgSpacer1" AlternateText="*" runat="server" ImageUrl="~/images/spacer.gif" height="3" width="1" borderwidth="0"></asp:image></td>
	</tr>
	<tr class="HeadBg">
		<td vAlign="center" align="middle">&nbsp;&nbsp;<asp:hyperlink id="hypLogo" runat="server"><asp:Image ID="hypLogoImage" BorderWidth="0" runat=server /></asp:hyperlink></td>
		<td vAlign="center" width="100%" height="100%">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" summary="Banner Heading Design Table">
				<tr vAlign="center">
					<td vAlign="center" width="60"><asp:image id="imgSpacer2"  AlternateText="*" runat="server" ImageUrl="~/images/spacer.gif" height="1" width="60" borderwidth="0"></asp:image></td>
					<td vAlign="center" align="middle" width="100%" height="100%"><asp:hyperlink id="hypBanner" runat="server"><asp:Image ID="hypBannerImage" BorderWidth="0" runat=server /></asp:hyperlink></td>
				</tr>
				<tr class="HeadBg">
					<td width="100%" colSpan="2" height="3"><asp:image id="imgSpacer3"  AlternateText="*" runat="server" ImageUrl="~/images/spacer.gif" height="3" width="1" borderwidth="0"></asp:image></td>
				</tr>
				<tr class="HeadBg" vAlign="bottom">
					<td width="100%" colSpan="2">
						<table height="31" cellSpacing="0" cellPadding="0" width="100%" border="0" summary="Banner Heading Design Table">
							<tr>
								<td width="60" rowSpan="2"><asp:image id="imgTabImage"  AlternateText="*" runat="server" ImageUrl="~/images/tabimage.gif" height="31" width="60" borderwidth="0"></asp:image></td>
								<td width="100%" bgColor="#333333" colSpan="3" height="11"><asp:image id="imgBevel"  AlternateText="*" runat="server" ImageUrl="~/images/bevel.gif" height="11" width="100%" BorderWidth="0"></asp:image></td>
							</tr>
							<tr>
								<td align="left" bgColor="#333333" height="20"><cc1:solpartmenu id="ctlMenu" runat="server" MenuEffects-MouseOutHideDelay="500" MouseOutHideDelay="1" ForceDownlevel="False" MenuBorderWidth="0" MenuItemHeight="21" MenuBarHeight="16" Moveable="False" SelectedBorderColor="#333333" IconWidth="0" SelectedForeColor="White" HighlightColor="#FF8080" IconBackgroundColor="#333333" ShadowColor="#404040" MenuEffects-MouseOverExpand="True" SelectedColor="#CCCCCC" MenuEffects-MouseOverDisplay="Highlight" MenuEffects-Style="filter:progid:DXImageTransform.Microsoft.Shadow(color='DimGray', Direction=135, Strength=3) ;" Font-Size="9pt" Font-Bold="True" Font-Names="Tahoma,Arial,Helvetica" ForeColor="White" BackColor="#333333" SystemImagesPath="/" MenuCSSPlaceHolderControl="SPMenuStyle"></cc1:solpartmenu></td>
								<td align="right" width="100%" bgColor="#333333" height="20"><asp:hyperlink id="hypHelp" runat="server" CssClass="OtherTabs">Help</asp:hyperlink><asp:label id="lblSeparator" runat="server" CssClass="OtherTabs">&nbsp;|&nbsp;</asp:label><asp:hyperlink id="hypLogin" runat="server" CssClass="OtherTabs"></asp:hyperlink>&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr class="HeadBg">
		<td width="100%" colSpan="2">
			<table height="25" cellSpacing="0" cellPadding="0" width="100%" border="0" summary="Banner Heading Design Table">
				<tr vAlign="top">
					<td class="TabBg" vAlign="center" noWrap align="middle">&nbsp;&nbsp;
						<asp:label id="lblDate" runat="server" CssClass="SelectedTab">Date</asp:label></td>
					<td class="TabBg" vAlign="center" noWrap align="middle" width="100%"><asp:label id="lblBreadCrumbs" runat="server" CssClass="SelectedTab">Home > Level2 > Level3 > Level4</asp:label></td>
					<td class="TabBg" vAlign="center" noWrap align="middle"><asp:hyperlink id="hypUser" runat="server" CssClass="SelectedTab">User</asp:hyperlink>&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
