<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_ChiTietVPHC_Pie.ascx.vb" Inherits="THTT.VPHC_ChiTietVPHC_Pie" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="right" colSpan="6" height="5"></TD>
	</TR>
	<TR>
		<TD colSpan="6" align="center">
			<OBJECT id="Pie3D" codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
				height="450" width="600" align="middle" border="0" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
				VIEWASTEXT>
				<PARAM NAME="_cx" VALUE="15875">
				<PARAM NAME="_cy" VALUE="11906">
				<PARAM NAME="FlashVars" VALUE="">
				<PARAM NAME="Movie" VALUE="xml/Pie3D.swf?IsLocal=1&amp;dataURL=xml/<%=prefile%>_VPHC_ChiTietVPHC.xml">
				<PARAM NAME="Src" VALUE="xml/Pie3D.swf?IsLocal=1&amp;dataURL=xml/<%=prefile%>_VPHC_ChiTietVPHC.xml">
				<PARAM NAME="WMode" VALUE="Window">
				<PARAM NAME="Play" VALUE="-1">
				<PARAM NAME="Loop" VALUE="-1">
				<PARAM NAME="Quality" VALUE="High">
				<PARAM NAME="SAlign" VALUE="">
				<PARAM NAME="Menu" VALUE="-1">
				<PARAM NAME="Base" VALUE="">
				<PARAM NAME="AllowScriptAccess" VALUE="always">
				<PARAM NAME="Scale" VALUE="ShowAll">
				<PARAM NAME="DeviceFont" VALUE="0">
				<PARAM NAME="EmbedMovie" VALUE="0">
				<PARAM NAME="BGColor" VALUE="FFFFFF">
				<PARAM NAME="SWRemote" VALUE="">
				<PARAM NAME="MovieData" VALUE="">
				<PARAM NAME="SeamlessTabbing" VALUE="1">
				<PARAM NAME="Profile" VALUE="0">
				<PARAM NAME="ProfileAddress" VALUE="">
				<PARAM NAME="ProfilePort" VALUE="0">
			</OBJECT>
		</TD>
	</TR>
	<TR>
		<TD colSpan="6" height="5"></TD>
	</TR>
	<TR>
		<TD colspan="3" align="center"><asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
	</TR>
</TABLE>
