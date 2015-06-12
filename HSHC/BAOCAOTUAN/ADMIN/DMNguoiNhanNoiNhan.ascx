<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DMNguoiNhanNoiNhan.ascx.vb" Inherits="DMNguoiNhanNoiNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td>
			<table id="table2" width="70%" align="center">
				<tr>
					<td class="QH_ColLabel" width="20%">Đơn vị</td>
					<td class="QH_ColControl" width="70%"><asp:dropdownlist id="ddlDonvi" CssClass="QH_dropdownlist" Width="60%" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td colspan="2"><asp:CheckBoxList ID="chkUsers" RepeatColumns="4" Runat="server" CssClass="QH_LoaiHS"></asp:CheckBoxList>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center"><asp:LinkButton Runat="server" CssClass="QH_Button" id="btnCapNhat">Cập nhật</asp:LinkButton>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
