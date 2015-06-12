<%@ Page CodeBehind="ErrorPage.aspx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.ErrorPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML LANG="en-US">
    <HEAD>
        <TITLE runat="server" id="Title">Error</TITLE> 
        <!--*************************************************************************************************************************************************************************-->
        <!-- PortalQH - http://www.PortalQH.com                                                                                                                                  -->
        <!-- Copyright (c) 2002-2004                                                                                                                                                 -->
        <!-- Shaun Walker - Perpetual Motion Interactive Systems Inc.                                                                                                                -->
        <!-- http://www.perpetualmotion.ca                                                                                                                                           -->
        <!-- sales@perpetualmotion.ca                                                                                                                                                -->
        <!-- ADA (American Disiabilities Act) & Section 508 Compliance Copyright 2003 UTEP http://www.utep.edu  Author: Robin Lilly (http://www.ilogbook.com)                        -->
        <!--*************************************************************************************************************************************************************************-->
        <LINK id="StyleSheet" runat="server" href="portal.css" type="text/css" rel="stylesheet"></LINK>
    </HEAD>
    <BODY id="Body" runat="server" onscroll="bodyscroll()" bottommargin="0" leftmargin="0"
        topmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
        <FORM id="Form" runat="server" enctype="multipart/form-data">
            <ASP:PLACEHOLDER id="ErrorPlaceHolder" runat="server" />
        </FORM>
    </BODY>
</HTML>
