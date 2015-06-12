<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NXHS_NoiDungGP.ascx.vb" Inherits="CPXD.NXHS_NoiDungGP" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1NoiDung" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD>
			<TABLE id="TableNoiDung" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<tr>
					<TD class="QH_ColLabel" width="20%">Số quyết định</TD>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtSoQuyetDinh" tabIndex="19" CssClass="QH_Textbox" runat="server"></asp:textbox></td>
					<TD class="QH_ColLabel" width="20%">DT hiện trạng (m2)</TD>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtDienTichHienTrangGiayPhep" tabIndex="24" Width="80%" CssClass="QH_Textbox"
							runat="server"></asp:textbox>&nbsp;</td>
				</tr>
				<tr>
					<TD class="QH_ColLabel" width="20%">Ngày quyết định</TD>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtNgayQuyetDinh" tabIndex="20" CssClass="QH_Textbox" runat="server"></asp:textbox>&nbsp;
						<asp:hyperlink id="cmdNgayQD" CssClass="CommandButton" Runat="server">
							<asp:image id="btnNgayQD" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></td>
					<TD class="QH_ColLabel" width="20%">DT Khuôn viên (m2)</TD>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtDienTichKhuonVienGiayPhep" tabIndex="25" Width="80%" CssClass="QH_Textbox"
							runat="server"></asp:textbox>&nbsp;</td>
				</tr>
				<tr>
					<TD class="QH_ColLabel" width="20%">Cao độ nền</TD>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtCaoDoNen" tabIndex="21" Width="80%" CssClass="QH_Textbox" runat="server"></asp:textbox>&nbsp;<asp:linkbutton id="LinkCaoDoNen" runat="server">Chọn...</asp:linkbutton></td>
					<TD width="20%"></TD>
					<td width="30%"></td>
				</tr>
				<tr>
					<TD class="QH_ColLabel" width="20%">Nội dung xây dựng</TD>
					<td class="QH_ColControl" width="30%"><asp:textbox id="TxTNoiDungXayDung" tabIndex="22" Width="80%" CssClass="QH_Textbox" runat="server"></asp:textbox></td>
					<TD width="20%"></TD>
					<td width="30%"></td>
				</tr>
				<tr>
					<TD class="QH_ColLabel" width="20%">Ngày hoàn công</TD>
					<td class="QH_ColControl" width="30%"><asp:textbox id="TxtNgayHoanCong" tabIndex="23" CssClass="QH_Textbox" runat="server"></asp:textbox>&nbsp;
						<asp:hyperlink id="cmdNgayHoanCong" CssClass="CommandButton" Runat="server">
							<asp:image id="Image1" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></td>
					<TD width="20%"></TD>
					<td width="30%"></td>
				</tr>
			</TABLE>
			&nbsp;
		</TD>
	</TR>
</TABLE>
