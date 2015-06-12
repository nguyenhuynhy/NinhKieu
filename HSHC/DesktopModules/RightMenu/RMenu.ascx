<%@ Control Language="vb" AutoEventWireup="false" Codebehind="RMenu.ascx.vb" Inherits="PortalQH.RMenu" Explicit="True" %>
<TABLE cellSpacing="0" cellPadding="0" width="158" runat=server border="0" id="tblTitle">
	<TR>
		<TD width="158" class="QH_MenuRight_Header" id="tdTitle">&nbsp;</TD>
	</TR>
	<TR>
		<TD width="158" class="QH_MenuRight_Middle" align=center>
			<asp:Panel ID="pnlDong" Runat="server" Width=150>
				<MARQUEE onmouseover="javasrcipt:this.stop();" onmouseout="javasrcipt:this.start();" scrollAmount="2"
					direction="up" width="100%" bgColor="aliceblue" height="150">
					<TABLE id="tblContent" cellSpacing="0" cellPadding="0" width="100%" runat="server">
						<TR>
							<TD align="center">
								<asp:Image id="img" Runat="server"></asp:Image></TD>
						</TR>
						<TR>
							<TD align="center">
								<asp:Label id="lblContent" Runat="server" Width="100%"></asp:Label></TD>
						</TR>
					</TABLE>
				</MARQUEE>
			</asp:Panel>
		</TD>
	</TR>
	<TR>
		<TD width="158" height="25" class="QH_MenuRight_Footer"></TD>
	</TR>
</TABLE>