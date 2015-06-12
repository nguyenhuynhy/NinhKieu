<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/Actions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<TABLE WIDTH="100%" BORDER=0 CELLPADDING=0 CELLSPACING=0>
	<TR>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_01.gif" RUNAT="SERVER" NoWrap WIDTH=25 HEIGHT=35 ALT=""></TD>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_02.gif" RUNAT="SERVER" NoWrap HEIGHT=35 ALT="" ALIGN="LEFT" VALIGN="MIDDLE">
			<TABLE WIDTH="100%" BORDER="0" CELLPADDING="0" CELLSPACING="0">
			<TR>
				<TD WIDTH=20><dnn:ACTIONS runat="server" id="dnnACTIONS" /></TD>
				<TD><dnn:TITLE runat="server" id="dnnTITLE" /></TD>
			</TR>
			</TABLE>
		</TD>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_03.gif" RUNAT="SERVER" NoWrap WIDTH=27 HEIGHT=35 ALT="">
			<dnn:VISIBILITY runat="server" id="dnnVISIBILITY" />
		</TD>
	</TR>
	<TR>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_04.gif" RUNAT="SERVER" WIDTH=25 ALT=""></TD>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_05.gif" ALT="" ID="ContentPane" RUNAT="SERVER"></TD>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_06.gif" RUNAT="SERVER" WIDTH=27 ALT=""></TD>
	</TR>
	<TR>
		<TD>
			<IMG SRC="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_07.gif" RUNAT="SERVER" WIDTH=25 HEIGHT=24 ALT=""></TD>
		<TD BACKGROUND="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_08.gif" RUNAT="SERVER" HEIGHT=24 ALT=""></TD>
		<TD>
			<IMG SRC="/PortalQH/Portals/_default/Containers/GoodDogs_MetalContainer/standard_09.gif" RUNAT="SERVER" WIDTH=27 HEIGHT=24 ALT=""></TD>
	</TR>
</TABLE>


