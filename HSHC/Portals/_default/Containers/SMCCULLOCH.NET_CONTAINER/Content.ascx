<%@ Control language="vb" CodeBehind="~/admin/Skins/container.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Container" %>
<%@ Register TagPrefix="dnn" TagName="Icon" Src="~/admin/Containers/Icon.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Actions" Src="~/admin/Containers/Actions.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Title" Src="~/admin/Containers/Title.ascx"%>
<div id="SMContainer">
	<table cellSpacing="0" cellPadding="0" width="100%" summary="Module Title Table">
    <tr class="SMTitleBg"> 
        <td width="2" height="23 align=" align="center"" vAlign="middle" noWrap> 
			<dnn:Icon runat="server" id="dnnIcon" /> <dnn:Actions runat="server" id="dnnActions" /> 
        </td>
        <td width="100%" align="left" vAlign="middle" noWrap> 
        <dnn:Title runat="server" id="dnnTitle" CssClass="SMHead" />&nbsp; </td>
        <td width="20" align="right" vAlign="middle" noWrap></td>
    </tr>
    <tr> 
		<td height="24" valign="top" colspan="3" > 
			<table cellSpacing="0" cellPadding="4" width="100%" summary="Module Content Table">
			<tr>
				<td id="ContentPane" runat="server"></td>
			</tr>
			</table>
		</td>
	</tr>
    </table>
</div>
<table cellSpacing="0" cellPadding="0" width="100%" summary="Module Title Table">
<tr>
	<td height="5"><img src="/PortalQH/Portals/_default/Containers/smcculloch.net_container/1pix.gif" runat="server" width="5" height="1"></td>
</tr>
</table>
