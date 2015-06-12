<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SearchHoSo.ascx.vb" Inherits="SearchHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="LinhVucSearch" Src="LinhVucSearch.ascx" %>
<script language=javascript src='<%= ResolveUrl("~/Inc/Common.js")%>'></script>
<script language=javascript src='<%= ResolveUrl("~/Inc/popcalendar.js")%>'></script>
<script language=javascript src='<%= ResolveUrl("~/Inc/Popupcalendar.js")%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" colSpan="3" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label3" Width="100%" CssClass="QH_Label_Title" runat="server">Tìm kiếm thông tin hồ sơ</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<tr>
		<td colspan="3">
			<TABLE class="QH_LoaiHS" id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0" runat="server">
				<tr>
					<td width="15%"><asp:label id="Label1" Width="100%" CssClass="QH_LabelBold" Runat="server"> Lĩnh vực</asp:label></td>
					<td width="75%">
						<uc1:LinhVucSearch id="LinhVucSearch1" runat="server"></uc1:LinhVucSearch></td>
				</tr>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td colspan="3">&nbsp;</td>
	</tr>
	<TR>
		<td>&nbsp;&nbsp;&nbsp;</td>
		<TD vAlign="top" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td id="getUserControl" vAlign="top" width="100%" runat="Server"></td>
				</tr>
			</table>
		</TD>
		<td>&nbsp;&nbsp;&nbsp;</td>
	</TR>
	</TR>
</TABLE>
