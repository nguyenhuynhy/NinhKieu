<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.2.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="InBaoCao.ascx.vb" Inherits="HSHC.InBaoCao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%">
			<TABLE class="QH_Table" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:textbox id="txtSoBienNhan" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><cr:crystalreportviewer id="CrystalReportViewer2" runat="server" width="100%"></cr:crystalreportviewer></td>
				</tr>
			</TABLE>
		</TD>
	</TR>
</TABLE>
