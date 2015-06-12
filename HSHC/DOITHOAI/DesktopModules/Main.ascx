<%@ Register TagPrefix="uc1" TagName="LeftMenu" Src="LeftMenu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Main.ascx.vb" Inherits="DOITHOAI.Main" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="main" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
	<tr>
		<td width="160" vAlign="top">
			<uc1:LeftMenu id="LeftMenu1" runat="server"></uc1:LeftMenu></td>
		<td width="*" valign="top">
			<TABLE id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<!--Header-->
				<tr>
					<td align="left" width="100%" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Content_TopLeft" width="9" height="25"></td>
								<td class="QH_Content_TopMid" align="center" width="*" height="25"><asp:label id="lblTitle" CssClass="QH_Content_Header_Middle" Width="100%" Runat="server"></asp:label></td>
								<td class="QH_Content_TopRight" width="8" height="25"></td>
							</tr>
						</table>
					</td>
				</tr>
				<!--Content-->
				<tr>
					<td align="left" width="100%" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Content_Left" width="9">&nbsp;</td>
								<td id="tdUserControl" vAlign="top" align="left" width="*" runat="server">&nbsp;</td>
								<td class="QH_Content_Right" width="8">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<!--Footer-->
				<tr>
					<td width="100%" colSpan="3" height="12">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Content_BottomLeft" width="9" height="100%"></td>
								<td class="QH_Content_BottomMid" width="*" height="100%">&nbsp;
								</td>
								<td class="QH_Content_BottomRight" width="8" height="100%"></td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</td>
	</tr>
</TABLE>
