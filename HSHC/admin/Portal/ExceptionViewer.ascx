<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control CodeBehind="ExceptionViewer.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.ExceptionsViewer" %>
<SCRIPT language="JavaScript" type="text/javascript">
<!--
function CheckExceptions()
{
    var j,isChecked = false;
    if (document.forms[0].item("Exception").length)
        {
            j=document.forms[0].item("Exception").length;
            for (var i=0;i<j;i++)
                {
                    if (document.forms[0].item("Exception")(i).checked==true)
                    {
                        isChecked = true;
                    }
                }
            if (isChecked!=true)
                {
                    alert('Please select at least one exception.');
                }
            return isChecked;
        }
    else 
        {
           
                    if (document.forms[0].item("Exception").checked)
                        return true;
                    else
                        {
                        alert('Please select at least one exception.');
                        return false;
                        }
                         
        }
}
function flipFlop(eTarget,sBGColor) {
    if (document.getElementById(eTarget).style.display=='')
    {
    	document.getElementById(eTarget).style.display='none';
    }
    else
    {
    	document.getElementById(eTarget).style.display='';
    	document.getElementById(eTarget).style.background=sBGColor;
    }

}
function changeSymbol(eTarget) {
    var plusImg = "images/plus.gif"
    var minusImg = "images/minus.gif"
    if (document.getElementById(eTarget).src.indexOf(plusImg)>0)
        {
            document.getElementById(eTarget).src=minusImg;
        }
    else
        {
            document.getElementById(eTarget).src=plusImg;
        }
}

  
//-->
</SCRIPT>
<ASP:PANEL id="pnlPortalID" Runat="server" CssClass="NormalBold"><BR>Portal ID: <ASP:DROPDOWNLIST id=ddlPortalID Runat="server" AutoPostBack="True"></ASP:DROPDOWNLIST><BR><BR></ASP:PANEL>
<ASP:PLACEHOLDER id="phExceptions" Runat="server"></ASP:PLACEHOLDER>
<asp:LinkButton CssClass="CommandButton" ID="btnDelete" Runat="server">Delete Selected Exceptions</asp:LinkButton>
&nbsp;&nbsp;<asp:LinkButton CssClass="CommandButton" ID="btnClear" Runat="server">Clear Log</asp:LinkButton>

<ASP:PANEL id="pnlSendExceptions" Runat="server" CssClass="Normal">
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TR>
            <TD vAlign=bottom noWrap align=left width="100%" height=34><SPAN class=Head>Send Exceptions</SPAN>&nbsp; </TD></TR>
        <TR>
            <TD width="100%">
                <HR noShade SIZE=1>
            </TD></TR></TABLE><B>Please note</B>: By using these features below, you 
<I>may</I> be sending sensitive data over the Internet in clear text (<I>not</I> 
encrypted). Before sending your exception submission, please review the contents 
of your exception log to verify that no sensitive data is contained within it. 
Only the log entries checked above will be sent. </SPAN>
<HR noShade SIZE=1>
<ASP:PANEL id=pnlSendEmail Runat="server"><A class=CommandButton href="javascript:flipFlop('excSendEmail','#FFFFFF');changeSymbol('excSendEmailExpand')"><IMG id=excSendEmailExpand src="images/plus.gif" border=0>Send 
            Exceptions via
            Email</A>
        <DIV id=excSendEmail style="DISPLAY: none">
            <TABLE cellSpacing=0 cellPadding=0 border=0>
                <TR>
                    <TH>Destination Email Address:&nbsp;</TH>
                    <TD><ASP:TEXTBOX id=txtEmailAddress Runat="server"></ASP:TEXTBOX></TD></TR>
                <TR>
                    <TH>Message (optional):&nbsp;</TH>
                    <TD><ASP:TEXTBOX id=txtMessage Runat="server" Rows="6" Columns="25" TextMode="MultiLine"></ASP:TEXTBOX></TD></TR>
                <TR>
                    <TH>&nbsp;</TH>
                    <TD><A class=CommandButton id=btnEmail onclick="return CheckExceptions();" RUNAT="server">Email 
                            Selected
                            Exceptions</A></TD></TR></TABLE></DIV><BR></ASP:PANEL><ASP:PANEL id=pnlSendServer CssClass="Normal" Runat="server"><A class=CommandButton href="javascript:flipFlop('excSendServer','#FFFFFF');changeSymbol('excSendServerExpand')"><IMG id=excSendServerExpand src="images/plus.gif" border=0>Send 
            Exceptions to Core
            Team</A> (web server must support accessing web services) 
<DIV id=excSendServer style="DISPLAY: none">
            <TABLE cellSpacing=0 cellPadding=0 border=0>
                <TR>
                    <TH>Your Email Address:&nbsp;</TH>
                    <TD><ASP:TEXTBOX id=txtServerSendDNNEmail Runat="server"></ASP:TEXTBOX></TD></TR>
                <TR>
                    <TH>Message (optional):&nbsp;</TH>
                    <TD><ASP:TEXTBOX id=txtServerSendDNNMessage Runat="server" Rows="6" Columns="25" TextMode="MultiLine"></ASP:TEXTBOX></TD></TR>
                <TR>
                    <TH>&nbsp;</TH>
                    <TD><A class=CommandButton id=btnServerSendToDNN onclick="return CheckExceptions();" RUNAT="server">Send 
                            Exceptions to
                            PortalQH.com</A></TD></TR></TABLE></DIV></ASP:PANEL></ASP:PANEL>
