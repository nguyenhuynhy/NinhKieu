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
	
	var doImage=doImage;
	var TType=TType;
	function mhHover(tbl,idx,cls){
		var t,d;
		if(document.getElementById)t=document.getElementById(tbl);
		else t=document.all(tbl);
		if(t==null)return;
		if(t.getElementsByTagName)d=t.getElementsByTagName("TD");
		else d=t.all.tags("TD");
		if(d==null)return;
		if(d.length<=idx)return;d[idx].className=cls;
	}
</script>
<!-- End Script cho Help -->

<TABLE width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" id="TABLEMAIN" style="border-collapse: collapse">
<!-- HEADER -->

	<TR>
		<TD>
			<TABLE height="100%" cellSpacing=0 cellPadding=0 width="100%" border=0>
				<TBODY>
					<TR class="QH_HeaderBG">
						<TD ROWSPAN=2 class="QH_HeaderLeft"></TD>
						<TD class="QH_HeaderMiddle">&nbsp;</TD>
						<TD class="QH_HeaderBG">&nbsp;</TD>
						<TD class="QH_HeaderRight"></TD>
					</TR>
					<TR>
						<TD class="QH_HeaderPaneBG" colspan="2">
							<table width="100%">
								<tr>
									<td><!--<a href="#" onclick="CallHelp();" class="QH_Help">Giúp đỡ</a> <FONT style="color:#FFFFBF">|</FONT>--> <dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="QH_Login"/></td>
									<td align="right"><dnn:CHANGEPW runat="server" id="dnnCHANGEPW" CssClass="QH_ChangePass"/></td>
								</tr>
							</table>
						</TD>
						<TD class="QH_HeaderPaneRight">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<dnn:USER runat="server" id="dnnUSER" CssClass="QH_User"/></TD>
					</TR>
				</TBODY>
			</TABLE>
		</TD>
	</TR>

<!-- END HEADER -->
<!-- MENU 1-->
	<TR style="height:23">
		<TD>
			<TABLE cellSpacing=0 cellPadding=0 width="100%" class="QH_MainMenu" >
				<TBODY>
					<TR>
						<TD></TD>
						<TD width="50%" height="23"><dnn:MENU runat="server" id="dnnMENU" /></TD>
					</TR>
				</TBODY>
			</TABLE>
		</TD>
	</TR>
<!-- END MENU 1-->	
<!-- MENU 2-->	
	<TR style="height:23">
		<TD class="QH_2_MenuBg">
			<TABLE height=22 cellSpacing=0 cellPadding=0 width="100%" border=0>
				<TBODY>
					<TR>
						<TD class="QH_DateBG"><dnn:CURRENTDATE runat="server" id="dnnCURRENTDATE" CssClass="QH_Date" /> &nbsp;&nbsp;&nbsp;</TD>
						<TD class="QH_BreadCumbBG" valign="top"><dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" CssClass="QH_BreadCumb"/>&nbsp;</TD>
					</TR>
				</TBODY>
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
				<TR valign="middle">
					<TD class="QH_FooterLeft"></TD>
					<TD class="QH_FooterMiddle">
						<table border="0" width="100%" id="table16" cellpadding="0" style="border-collapse: collapse">
						<tr>
							<td width="71" class="QH_FooterLeftTop"></td>
							<td class="QH_FooterBgTop">&nbsp;</td>
						</tr>
						<tr>
							<td width="71">&nbsp;</td>
							<td><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="QH_CopyRight"/></td>
						</tr>
						<tr>
							<td width="71" class="QH_FooterLeftBottom"></td>
							<td class="QH_FooterBgBottom">&nbsp;</td>
						</tr>
					</table>
					</TD>
					<TD class="QH_FooterRight"></TD>
				</TR>			
			</TABLE>
		</TD>
	</TR>
<!-- END FOOTER -->	
</TABLE>
<!--end Table main-->
<script type="text/javascript">
<!--
  //initInputHighlightScript();
-->
</script>