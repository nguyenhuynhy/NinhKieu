<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Skin" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/Admin/Skins/SolPartMenu.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CHANGEPW" Src="~/Admin/Skins/ChangePassword.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<!-- Script cho Help -->
<script language="javascript">
	function CallHelp()
	{
		window.open("Help/UserGuide.htm");
	}
</script>
<!-- End Script cho Help -->

<TABLE width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" id="TABLEMAIN" style="border-collapse: collapse">
<!-- HEADER -->
	<TR style="height:23">
		<TD class="QH_HeaderBg">
			<TABLE border="0" width="100%" id="TABLEHEADER" cellpadding="0" style="border-collapse: collapse">
				<TR> 		
					<TD class="QH_HeaderLeft">&nbsp;</TD>			
					<TD class= "QH_HeaderMiddle">&nbsp;</TD>
					<TD align="right" class="QH_HeaderRight"><dnn:CHANGEPW runat="server" id="dnnCHANGEPW" CssClass="QH_ChangePass"/></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
<!-- END HEADER -->
<!-- MENU 1-->	
	<TR style="height:23">
		<TD>
			<TABLE border="0" width="100%" height="100%" id="TABLEMENU" cellpadding="0" style="border-collapse: collapse">
				<TR> 		
					<TD class="QH_1_MenuBg" align="center"><dnn:MENU runat="server" id="dnnMENU" CssClass="QH_Menu"/></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
<!-- END MENU 1-->	
<!-- MENU 2-->	
	<TR style="height:23">
		<TD class="QH_2_MenuBg">
			<TABLE border="0" width="100%" height="100%" id="TABLEMENU" cellpadding="0" style="border-collapse: collapse">
				<TR> 		
					<TD class="QH_2_MenuLeftBg_2" width="110px" align="center"><dnn:CURRENTDATE runat="server" id="dnnCURRENTDATE" CssClass="QH_Date" /></TD>
					<TD class="QH_2_MenuLeftBg_1" width="28px"></TD>
					<TD align="left" width="*">&nbsp;<dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" CssClass="QH_BreadCumb"/></TD>
					<TD align="right" width="150px">&nbsp;<dnn:USER runat="server" id="dnnUSER" CssClass="QH_USER"/></TD>					
					<TD class="QH_2_MenuRightBg_1" width="28px"></TD>
					<TD class="QH_2_MenuRightBg_2" width="110px" align="center"><a href="#" onclick="CallHelp();" class="QH_Help">Giúp đỡ</a> | <dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="QH_Login"/></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
<!-- END MENU 2-->	
<!-- CONTENT -->	
	<TR style="height:100%">
		<TD valign="top">
			<TABLE WIDTH="100%" height="100%" border="0" cellpadding="0" cellspacing="0" id="TABLECONTENT">
				<TR>
					<TD id="LeftPane" runat="server" WIDTH="158" visible="false" ALIGN=LEFT VALIGN=TOP></TD>
					<TD id="ContentPane" runat="server" HEIGHT="100%" visible="TRue" ALIGN=LEFT VALIGN=TOP></TD>
					<TD id="RightPane" runat="server" WIDTH="158" visible="false" ALIGN=LEFT VALIGN=TOP></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
<!-- END CONTENT -->		
<!-- FOOTER -->	
	<TR style="height:20">
		<TD>
			<TABLE border="0" width="100%" id="TABLEFOOTER" cellpadding="0" style="border-collapse: collapse">
				<TR> 		
					<TD class="QH_FooterLeft"></TD>			
					<TD class="QH_FooterMiddle"align="center"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="QH_CopyRight"/></TD>
					<TD class="QH_FooterRight"></TD>
				</TR>			
			</TABLE>
		</TD>
	</TR>
<!-- END FOOTER -->	
</TABLE>