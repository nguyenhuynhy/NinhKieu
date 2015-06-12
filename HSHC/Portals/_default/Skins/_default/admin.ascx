<%@ Control language="vb" CodeBehind="admin.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="admin" %>
<%@ Register TagPrefix="dnn" TagName="Logo" Src="~/admin/Skins/Logo.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Banner" Src="~/admin/Skins/Banner.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Menu" Src="~/admin/Skins/Menu.ascx"%>
<%@ Register TagPrefix="dnn" TagName="CurrentDate" Src="~/admin/Skins/CurrentDate.ascx"%>
<%@ Register TagPrefix="dnn" TagName="BreadCrumb" Src="~/admin/Skins/BreadCrumb.ascx"%>
<%@ Register TagPrefix="dnn" TagName="ChangePassword" Src="~/admin/Skins/ChangePassword.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Login" Src="~/admin/Skins/Login.ascx"%>
<%@ Register TagPrefix="dnn" TagName="User" Src="~/admin/Skins/User.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Copyright" Src="~/admin/Skins/Copyright.ascx"%>
<table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0" summary="Main table for design"
	id="Table1">
	<tr valign="top">
		<td valign="top" class="HeadBgImage">
			<table cellspacing="0" cellpadding="0" width="100%" border="0" summary="Banner Heading Design Table">
				<tr class="HeadBg">
					<td width="100%" colspan="2" height="3"><img runat="server" src="~/Portals/_default/Skins/_default/spacer.gif" alt="*" style="BORDER-TOP-WIDTH:0px;BORDER-LEFT-WIDTH:0px;BORDER-BOTTOM-WIDTH:0px;WIDTH:1px;HEIGHT:3px;BORDER-RIGHT-WIDTH:0px"></td>
				</tr>
				<tr class="HeadBg">
					<td valign="middle" align="center">&nbsp;&nbsp;<dnn:Logo runat="server" id="dnnLogo" /></td>
					<td valign="middle" width="100%" height="100%">
						<table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0" summary="Banner Heading Design Table">
							<tr valign="middle">
								<td valign="middle" width="60"><img runat="server" src="~/Portals/_default/Skins/_default/spacer.gif" alt="*" style="BORDER-TOP-WIDTH:0px;BORDER-LEFT-WIDTH:0px;BORDER-BOTTOM-WIDTH:0px;WIDTH:60px;HEIGHT:3px;BORDER-RIGHT-WIDTH:0px"></td>
								<td valign="middle" align="center" width="100%" height="100%"><dnn:Banner runat="server" id="dnnBanner" /></td>
							</tr>
							<tr class="HeadBg">
								<td width="100%" colspan="2" height="3"><img runat="server" src="~/Portals/_default/Skins/_default/spacer.gif" alt="*" style="BORDER-TOP-WIDTH:0px;BORDER-LEFT-WIDTH:0px;BORDER-BOTTOM-WIDTH:0px;WIDTH:1px;HEIGHT:3px;BORDER-RIGHT-WIDTH:0px"></td>
							</tr>
							<tr class="HeadBg" valign="bottom">
								<td width="100%" colspan="2">
									<table height="31" cellspacing="0" cellpadding="0" width="100%" border="0" summary="Banner Heading Design Table">
										<tr>
											<td width="60" rowspan="2"><img runat="server" src="~/Portals/_default/Skins/_default/tabimage_blue.gif" alt="*"
													style="BORDER-TOP-WIDTH:0px;BORDER-LEFT-WIDTH:0px;BORDER-BOTTOM-WIDTH:0px;WIDTH:60px;HEIGHT:31px;BORDER-RIGHT-WIDTH:0px"></td>
											<td width="100%" colspan="3" height="10"><img runat="server" src="~/Portals/_default/Skins/_default/bevel_blue.gif" alt="*" style="BORDER-TOP-WIDTH:0px;BORDER-LEFT-WIDTH:0px;BORDER-BOTTOM-WIDTH:0px;WIDTH:100%;HEIGHT:11px;BORDER-RIGHT-WIDTH:0px"></td>
										</tr>
										<tr>
											<td align="left" class="TabBg" height="20"><dnn:Menu runat="server" id="dnnMenu" /></td>
											<td align="right" width="100%" class="TabBg" height="20">
												<dnn:Login runat="server" id="dnnLogin" />&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class="HeadBg">
					<td width="100%" colspan="2">
						<table height="25" cellspacing="0" cellpadding="0" width="100%" border="0" summary="Banner Heading Design Table">
							<tr valign="top">
								<td class="footerBg" valign="middle" nowrap align="center">&nbsp;&nbsp;<dnn:CurrentDate runat="server" id="dnnCurrentDate" /></td>
								<td class="footerBg" valign="middle" nowrap align="center" width="626"><dnn:BreadCrumb runat="server" id="dnnBreadCrumb" /></td>
								<td class="footerBg" valign="middle" nowrap align="right">
									<dnn:ChangePassword id="dnnChangePassword" runat="server"></dnn:ChangePassword>
									<dnn:User runat="server" id="dnnUser" />&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr valign="top">
		<td valign="top" height="100%">
			<table cellspacing="0" cellpadding="4" width="100%" height="100%" border="0" summary="Table for design"
				id="Table2">
				<tr vAlign="top">
					<td valign="top" height="100%" align="center">
						<br>
						<table cellspacing="0" cellpadding="4" border="0">
							<tr height="*" valign="top">
								<td id="ContentPane" runat="server" valign="top" align="center"></td>
							</tr>
						</table>
						<br>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr valign="bottom">
		<td>
			<table cellspacing="0" cellpadding="0" width="100%" border="0" summary="Footer Design Table">
				<tr valign="bottom">
					<td align="center" valign="middle" class="FooterBg" height="25"><dnn:Copyright runat="server" id="dnnCopyright" /></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
