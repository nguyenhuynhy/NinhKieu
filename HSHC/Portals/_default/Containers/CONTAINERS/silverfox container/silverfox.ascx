<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<table border="0" cellpadding="0" width="100%" cellspacing="0" id="table1">
	<tr>
		<td width="14" height="46" background="/PortalQH/Portals/_default/Containers/silverfox container/topleft.gif" style="float: left">&nbsp;</td>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/silverfox container/topmid.gif" HEIGHT=46 ALIGN=LEFT VALIGN=TOP>
			<TABLE BORDER=0 CELLPADDING=0 CELLSPACING=0>
				<TR HEIGHT=6><TD COLSPAN=3></TD></TR>
				<TR><TD VALIGN=TOP>[VISIBILITY]</TD><TD><dnn:ACTIONS runat="server" id="dnnACTIONS" /></TD><TD ALIGN=LEFT VALIGN=MIDDLE>[TITLE]</TD></TR>
			</TABLE>
		</TD>
		<td background="/PortalQH/Portals/_default/Containers/silverfox container/topright.gif" width="14">&nbsp;</td>
	</tr>
	<tr>
		<td width="14" background="/PortalQH/Portals/_default/Containers/silverfox container/left.gif">&nbsp;</td>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/silverfox container/container_05.jpg" ALIGN=LEFT VALIGN=TOP>
			<TABLE BORDER=0 CELLPADDING=0 CELLSPACING=0>
				<TR><TD id="ContentPane" runat="server" ALIGN=LEFT VALIGN=TOP></TD></TR>
			</TABLE>
		</TD>

		<td background="/PortalQH/Portals/_default/Containers/silverfox container/right.gif">&nbsp;</td>
	</tr>
	<tr>
		<td width="14" background="/PortalQH/Portals/_default/Containers/silverfox container/bLeft.gif" height="24">&nbsp;</td>
		<td background="/PortalQH/Portals/_default/Containers/silverfox container/bMid.gif">&nbsp;</td>
		<td background="/PortalQH/Portals/_default/Containers/silverfox container/bright.gif">&nbsp;</td>
	</tr>
</table>
