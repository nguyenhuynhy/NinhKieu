<%--<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DinhNghiaHanBaoCao.ascx.vb" Inherits="DinhNghiaHanBaoCao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>--%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="~/BAOCAOTUAN/ADMIN/DinhNghiaHanBaoCao.ascx.vb" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td>
			<table id="table2" width="70%" align="center">
				<tr>
					<TD class="QH_ColLabel" width="45%" align="right">Hạn báo cáo tháng (ngày)</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtHanBaoCaoThang" Width="100px" runat="server" CssClass="QH_Textbox" MaxLength=2></asp:textbox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel" width="45%" align="right">Hạn báo cáo tuần (thứ)</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtHanBaoCaoTuan" Width="100px" runat="server" CssClass="QH_Textbox" MaxLength=2></asp:textbox></TD>
				</tr>
				<tr>
					<td colspan="2" align="center"><asp:LinkButton Runat="server" CssClass="QH_Button" id="btnCapNhat">Cập nhật</asp:LinkButton>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
