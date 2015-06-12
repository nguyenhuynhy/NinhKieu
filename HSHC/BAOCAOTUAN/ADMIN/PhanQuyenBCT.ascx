<%@ Control Language="vb" AutoEventWireup="false" Codebehind="PhanQuyenBCT.ascx.vb" Inherits="PhanQuyenBCT" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<!--Start bound-->
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" CssClass="QH_Label_Title" runat="server" Width="100%">PHÂN QUYỀN BÁO CÁO TUẦN</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<tr>
		<td>
			<table  width="70%" align="center">
			<tr>
				<td>
				<table class="QH_LoaiHS">
				<tr>
					<td class="QH_ColLabel" width="20%">Đơn vị</td>
					<td  width="70%"><asp:dropdownlist id="ddlDonvi" CssClass="QH_dropdownlist" Width="60%" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="20%">Phân quyền <font color="#cc0000">*</font></td>
					<td width="70%"><asp:dropdownlist id="ddlPhanQuyen" CssClass="QH_dropdownlist" Width="60%" AutoPostBack="True" Runat="server"></asp:dropdownlist></td>
				</tr>
				</table>
				</td>
			</tr>
				<tr>
					<td><asp:checkboxlist id="chkUsers" CssClass="QH_LoaiHS" Runat="server" RepeatColumns="5"></asp:checkboxlist></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" height="5"></td>
	</tr>
	<tr>
		<td align="center">
			<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">CẬP NHẬT</asp:linkbutton>
			<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">XÓA HẾT</asp:linkbutton>
		</td>
	</tr>
	<TR>
		<TD align="center">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
		<td class="QH_Khung_Right" width="16">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr height="*">
					<td></td>
				</tr>
				<tr height="141">
					<td class="QH_Khung_Right1"></td>
				</tr>
			</TABLE>
		</td>
	</TR>
</TABLE>
</TD></TR></TABLE></TABLE>
