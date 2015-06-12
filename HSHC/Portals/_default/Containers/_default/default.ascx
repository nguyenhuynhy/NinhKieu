<%@ Control language="vb" CodeBehind="default.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="Containers" %>
<%@ Register TagPrefix="dnn" TagName="Icon" Src="~/admin/Containers/Icon.ascx"%>
<%@ Register TagPrefix="dnn" TagName="SolPartActions" Src="~/admin/Containers/SolPartActions.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Title" Src="~/admin/Containers/Title.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Visibility" Src="~/admin/Containers/Visibility.ascx"%>
<table cellpadding="2" cellspacing="0" summary="Module Design Table" width="100%">
	<tr>
		<td runat="server" id="ContentPane">
			<table cellSpacing="0" cellPadding="0" width="98%" summary="Module Title Table">
				<tr>
					<td vAlign="bottom" noWrap align="left" height="34">
						<dnn:SolPartActions runat="server" id="dnnSolPartActions" />
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
					<td colspan="4" width="100%">
						<hr noshade size="1">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
