<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Container" %>
<%@ Register TagPrefix="dnn" TagName="SolPartActions" Src="~/admin/Containers/SolPartActions.ascx"%>
<table cellpadding="2" cellspacing="0" summary="Module Design Table" width="100%">
  <tr>
    <td runat="server" id="ContentPane">
      <dnn:SolPartActions runat="server" id="dnnSolPartActions" />
    </td>
  </tr>
</table>