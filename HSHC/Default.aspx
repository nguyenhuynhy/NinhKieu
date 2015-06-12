<%@ Page CodeBehind="Default.aspx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.CDefault" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD id="Head">
		<TITLE>
			<%= Title %>
		</TITLE>
		<!--*************************************************************************************************************************************************************************-->
		<!-- PortalQH - http://www.PortalQH.com                                                                                                                                  -->
		<!-- Copyright (c) 2002-2004                                                                                                                                                 -->
		<!-- Shaun Walker - Perpetual Motion Interactive Systems Inc.                                                                                                                -->
		<!-- http://www.perpetualmotion.ca                                                                                                                                           -->
		<!-- sales@perpetualmotion.ca                                                                                                                                                -->
		<!--*************************************************************************************************************************************************************************-->
		<META NAME="DESCRIPTION" CONTENT="<%= Description %>">
		<META NAME="KEYWORDS" CONTENT="<%= KeyWords %>">
		<META NAME="COPYRIGHT" CONTENT="<%= Copyright %>">
		<META NAME="GENERATOR" CONTENT="<%= Generator %>">
		<META NAME="RESOURCE-TYPE" CONTENT="DOCUMENT">
		<META NAME="DISTRIBUTION" CONTENT="GLOBAL">
		<META NAME="AUTHOR" CONTENT="PortalQH">
		<META NAME="ROBOTS" CONTENT="INDEX, FOLLOW">
		<META NAME="REVISIT-AFTER" CONTENT="1 DAYS">
		<META NAME="RATING" CONTENT="GENERAL">
		<asp:placeholder id="CSS" runat="server"></asp:placeholder>
	</HEAD>
	<BODY ID="Body" runat="server" ONSCROLL="bodyscroll()" BOTTOMMARGIN="0" LEFTMARGIN="0"
		TOPMARGIN="0" RIGHTMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<script language="JavaScript"><!--
         function bodyscroll() {
           var F=document.forms[0];
           F.ScrollTop.value=Body.scrollTop;
         }
         //--></script>
		<noscript></noscript>
		<FORM ID="Form" runat="server" ENCTYPE="multipart/form-data">
			<asp:Label ID="SkinError" Runat="server" CssClass="NormalRed" Visible="False"></asp:Label>
			<asp:placeholder id="SkinPlaceHolder" runat="server" />
			<INPUT ID="ScrollTop" runat="server" NAME="ScrollTop" TYPE="hidden">
			<input id="MsgBox_Hidden" type="hidden" name="MsgBox_Hidden" runat="server"> 
		</FORM>
		<script language="javascript">
		if(document.all("MsgBox_Hidden").value != '')
		{
		alert(document.all("MsgBox_Hidden").value) ;
		document.all("MsgBox_Hidden").value = '';		
		}
		</script>
	</BODY>
</HTML>
