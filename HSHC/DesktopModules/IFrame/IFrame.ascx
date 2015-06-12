<%@ Control language="vb" Inherits="PortalQH.IFrame" CodeBehind="IFrame.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<TABLE cellSpacing="0" cellPadding="0" width="100%" height="100%">
	<TR>
		<TD width="100%" height="25">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD class="QH_Content_TopLeft" width="9"></TD>
					<TD class="QH_Content_TopMid" width="*">&nbsp;</TD>
					<TD class="QH_Content_TopRight" width="8"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD width="100%" height="100%">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_Content_Left" width="9">&nbsp;</TD>
					<TD vAlign="top" width="*">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="center">
									<asp:Panel id="pnlModuleContent" Runat="server">
										<asp:Label id="lblIFrame" Runat="server"></asp:Label>
									</asp:Panel>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="QH_Content_Right" width="8">&nbsp;</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<!--Footer-->
	<TR>
		<TD width="100%">
			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_Content_BottomLeft" width="8"></TD>
					<TD class="QH_Content_BottomMid" width="*">&nbsp;</TD>
					<TD class="QH_Content_BottomRight" width="8"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
