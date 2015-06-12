﻿<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_TinhHinhVPHC_Col.ascx.vb" Inherits="THTT.VPHC_TinhHinhVPHC_Col" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="right" colSpan="6" height="10"></TD>
	</TR>
	<TR>
		<TD width="15%"></TD>
		<TD class="QH_ColLabel" width="12%">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
		<TD width="22%" class="QH_ColControl">
			<asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="65%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:hyperlink id="cmdStartCalendar" CssClass="CommandButton" Runat="server">
				<asp:image id="btnTuNgay" BorderWidth="0" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink>
		</TD>
		<TD class="QH_ColLabel" width="12%">Đến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
		<TD width="20%" class="QH_ColControl">
			<asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="65%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:hyperlink id="cmdEndCalendar" CssClass="CommandButton" Runat="server">
				<asp:image id="btnDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink>
		</TD>
		<TD align="right" width="15%">
			<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Thực hiện</asp:linkbutton></TD>
		<TD width="10%"></TD>	
	</TR>
	<TR>
		<TD align="right" colSpan="6" height="5"></TD>
	</TR>
	<TR>
		<TD colSpan="6" align="center">
			<OBJECT id="ColumnF" codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
				height="450" width="600" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>
				<PARAM NAME="_cx" VALUE="15875">
				<PARAM NAME="_cy" VALUE="11906">
				<PARAM NAME="FlashVars" VALUE="">
				<PARAM NAME="Movie" VALUE="xml/Column.swf?IsLocal=1&amp;dataURL=xml/<%=prefile%>_VPHC_TinhHinhVPHC.xml">
				<PARAM NAME="Src" VALUE="xml/Column.swf?IsLocal=1&amp;dataURL=xml/<%=prefile%>_VPHC_TinhHinhVPHC.xml">
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
				<!--FFFFFF-->
			</OBJECT>
		</TD>
	</TR>
	<TR>
		<TD colSpan="6" height="5"></TD>
	</TR>
</TABLE>
