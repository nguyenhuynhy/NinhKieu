<%@ Control Language="vb" AutoEventWireup="false" Codebehind="rptBaoCaoDoanhNghiep.ascx.vb" Inherits="CPLDQH.rptBaoCaoDoanhNghiep" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript src='<%= Page.ResolveURL("~/Inc/Common.js")%>'></script>
<script language=javascript src='<%= Page.ResolveURL("~/Inc/popcalendar.js")%>'></script>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/Popupcalendar.js")%>'></script>
<!--Main-->
<table id="table1" runat="server" class="QH_Table" width="100%">
	<tr>
		<td class="QH_ColLabel" width="15%">Từ ngày</td>
		<td class="QH_ColControl" width="20%"><asp:TextBox Runat="server" ID="txtTuNgay" CssClass="QH_ColControlDate"></asp:TextBox>&nbsp;&nbsp;<asp:HyperLink ID="btnTuNgay" Runat="server" CssClass="CommandButton">
				<asp:Image Runat="server" id="imgTuNgay" CssClass="QH_imageButton" ImageUrl="~/Images/calendar.gif"></asp:Image>
			</asp:HyperLink></td>
		<td class="QH_ColLabel" width="15%">Đến ngày</td>
		<td class="QH_ColControl" width="20%"><asp:TextBox Runat="server" ID="txtDenNgay" CssClass="QH_ColControlDate"></asp:TextBox>&nbsp;&nbsp;<asp:HyperLink ID="btnDenNgay" Runat="server" CssClass="CommandButton">
				<asp:Image Runat="server" id="imgDenNgay" CssClass="QH_imageButton" ImageUrl="~/Images/calendar.gif"></asp:Image>
			</asp:HyperLink></td>
	</tr>
</table>
