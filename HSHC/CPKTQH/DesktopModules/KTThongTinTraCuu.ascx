<%@ Control Language="vb" AutoEventWireup="false" Codebehind="KTThongTinTraCuu.ascx.vb" Inherits="CPKTQH.KTThongTinTraCuu" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center"
	border="0">
	<tr>
		<td width="45%">
			<table id="Table20" cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<TD class="QH_ColLabel" width="30%">Họ tên</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtHoTen" Width="90%" CssClass="QH_Textbox" runat="server" MaxLength="50"></asp:textbox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Số nhà</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtSoNha" Width="90%" CssClass="QH_TextBox" Runat="server" MaxLength="50"></asp:textbox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel" height="18">Ðường</TD>
					<TD class="QH_ColControl" height="18">
						<asp:dropdownlist id="ddlDuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Phường</TD>
					<TD class="QH_ColControl">
						<asp:dropdownlist id="ddlPhuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
				</tr>
				<tr>
					<TD width="30%" class="QH_ColLabel">Bảng hiệu</TD>
					<TD width="70%" class="QH_ColControl"><asp:textbox id="txtBangHieu" Width="90%" CssClass="QH_TextBox" Runat="server" MaxLength="100"></asp:textbox></TD>
				</tr>
				<tr>
					<TD width="30%" class="QH_ColLabel">Số CNMD</TD>
					<TD width="70%" class="QH_ColControl"><asp:textbox id="txtSoCMND" Width="90%" CssClass="QH_TextBox" Runat="server" MaxLength="100"></asp:textbox></TD>
				</tr>
			</table>
		</td>
		<td width="55%">
			<table id="Table21" cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<TD width="30%" class="QH_ColLabel">
						Tình trạng</TD>
					<TD width="70%" class="QH_ColControl"><asp:dropdownlist id="ddlTinhTrangHienTai" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Mặt hàng kinh doanh</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtMatHang" Width="90%" CssClass="QH_TextBox" Runat="server" MaxLength="100"></asp:textbox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Số GCN ĐKKD</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtSoGiayPhep" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="50"></asp:textbox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Từ ngày</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>
						&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
				</tr>
				<tr>
					<td class="QH_ColLabel">Ðến ngày</td>
					<td class="QH_ColControl"><asp:textbox id="txtDenNgay" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>
						&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></td>
				</tr>
			</table>
		</td>
	</tr>
</TABLE>
