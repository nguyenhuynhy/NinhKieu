<%@ Control language="vb" CodeBehind="~/admin/Skins/container.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Container" %>
<%@ Register TagPrefix="dnn" TagName="Icon" Src="~/admin/Containers/Icon.ascx"%>
<%@ Register TagPrefix="dnn" TagName="DropDownActions" Src="~/admin/Containers/DropDownActions.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Title" Src="~/admin/Containers/Title.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Visibility" Src="~/admin/Containers/Visibility.ascx"%>
<table border="0" cellspacing="0" cellpadding="0" width="100%" Summary="Module Design Table">
  <tr>
    <td width="23">
	<img runat="server" border="0" src="../Classic/top-left.gif" WIDTH="23" HEIGHT="31" Alt="Module Border"></td>
    <td runat="server" background="../Classic/top-tile.gif"></td>
    <td width="23">
	<img runat="server" border="0" src="../Classic/top-right.gif" WIDTH="23" HEIGHT="31" Alt="Module Border"></td>
  </tr>
  <tr>
    <td runat="server" background="../Classic/left-tile.gif" width="23"></td>
    <td runat="server" id="ContentPane">
      <table cellSpacing="0" cellPadding="0" width="98%" summary="Module Title Table">
		<tr>
          <td vAlign="bottom" noWrap align="left" height="34">
      		<dnn:DropDownActions runat="server" id="dnnActions" />
          </td>
          <td vAlign="bottom" noWrap align="left" height="34">
            <dnn:Icon runat="server" id="dnnIcon" />&nbsp;
          </td>
          <td vAlign="bottom" noWrap align="left" width="100%" height="34">
            <dnn:Title runat="server" id="dnnTitle" />&nbsp;
          </td>
          <td vAlign="bottom" noWrap align="right" height="34">
            <dnn:Visibility runat="server" id="dnnVisibility" />
          </td>
		</tr>
        <tr>
          <td colspan="3" width="100%">
          </td>
        </tr>
      </table>
      <hr noshade size="1">
    </td>
    <td runat="server" background="../Classic/right-tile.gif" width="23"></td>
  </tr>
  <tr>
    <td width="23">
	<img runat="server" border="0" src="../Classic/bottom-left.gif" WIDTH="23" HEIGHT="31" Alt="Module Border"></td>
    <td runat="server" background="../Classic/bottom-tile.gif"></td>
    <td width="23">
	<img runat="server" border="0" src="../Classic/bottom-right.gif" WIDTH="23" HEIGHT="31" Alt="Module Border"></td>
  </tr>
</table>
