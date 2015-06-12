<%@ Control Language="vb" AutoEventWireup="false" Codebehind="RMenu.ascx.vb" Inherits="PortalQH.RMenu" Explicit="True" %>
<table width=170px class="QH_image" cellpadding="0" cellspacing="0" id="tblTitle">
	<tr class="QH_MENULD_Border">
		<td class="QH_MENULD_Header" id="tdTitle" runat="server"></td>
	<tr>
		<td>
			<asp:Panel ID="pnlDong" Runat="server">
				<MARQUEE onmouseover="javasrcipt:this.stop();" onmouseout="javasrcipt:this.start();" scrollAmount="2"
					direction="up" width="100%" bgColor="aliceblue" height="150">
					<TABLE id="tblContent" cellSpacing="0" cellPadding="0" width="100%" runat="server">
						<TR>
							<TD align="center">
								<asp:Image id="img" Runat="server"></asp:Image></TD>
						</TR>
						<TR>
							<TD align="center">
								<asp:Label id="lblContent" Runat="server" Font-Name="arial" Width="100%" CssClass="QH_LabelRMenu"></asp:Label></TD>
						</TR>
					</TABLE>
				</MARQUEE>
			</asp:Panel>
		</td>
	</tr>
</table>
