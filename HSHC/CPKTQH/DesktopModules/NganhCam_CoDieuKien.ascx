<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NganhCam_CoDieuKien.ascx.vb" Inherits="CPKTQH.NghanhCam_CoDieuKien" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" width="30%">Ngành</TD>
					<TD width="70%"><asp:dropdownlist id="ddlNganh" Width="50%" Runat="server" CssClass="QH_DropDownList"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:radiobuttonlist id="rblLoai" Width="100%" RepeatDirection="Vertical" runat="server" CssClass="QH_LabelLeft">
							<asp:ListItem Value="0">Được phép kinh doanh</asp:ListItem>
							<asp:ListItem Value="1">Cấm kinh doanh</asp:ListItem>
							<asp:ListItem Value="2">Kinh doanh có điều kiện</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
			</TABLE>
		</TD>
	<TR>
	<tr>
		<td>
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="20%"><asp:label id="label1" Runat="server" CssClass="QH_LabelLeftBold">Thời gian hiệu lực</asp:label></TD>
					<td class="QH_ColLabel" width="10%">Từ ngày</td>
					<td width="20%"><asp:textbox id="txtTuNgay" Width="70%" Runat="server" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>
						<asp:HyperLink id="cmdTuNgay" CssClass="commandbutton" runat="server">
							<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:HyperLink>
					</td>
					<td class="QH_ColLabel" width="10%">Đến ngày</td>
					<td width="20%"><asp:textbox id="txtDenNgay" Width="70%" Runat="server" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>
						<asp:HyperLink id="cmdDenNgay" CssClass="commandbutton" runat="server">
							<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:HyperLink>
					</td>
					<td width="20%"></td>
				</TR>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td>
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td width="30%"><asp:label id="Label2" Runat="server" CssClass="QH_LabelLeftBold">Phạm vi</asp:label></td>
					<td width="70%"><asp:checkbox id="chkToanQuan" Width="100%" CssClass="QH_LabelLeft" runat="server" Text="Toàn quận"></asp:checkbox></td>
				</TR>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td>
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td width="10%"></td>
					<td width="38%"><asp:label id="lblPhuong" Runat="server" CssClass="QH_LabelLeftBoldItalic">Phường</asp:label></td>
					<td width="4%"></td>
					<td width="38%"><asp:label id="lblDuong" Runat="server" CssClass="QH_LabelLeftBoldItalic">Đường</asp:label></td>
					<td width="10%"></td>
				</TR>
				<tr>
					<td></td>
					<td><asp:datagrid id="dgrPhuong" Width="100%" CssClass="QH_DataGrid" runat="server"></asp:datagrid></td>
					<td></td>
					<td><asp:datagrid id="dgrDuong" Width="100%" CssClass="QH_DataGrid" runat="server"></asp:datagrid></td>
				</tr>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td vAlign="middle" align="center"><asp:imagebutton id="btnCapNhat" CssClass="QH_ImageButton" runat="server" ImageUrl="../../Images/btn_CapNhat.gif"></asp:imagebutton><asp:imagebutton id="btnThemMoi" CssClass="QH_ImageButton" runat="server" ImageUrl="../../Images/btn_BoQua.gif"></asp:imagebutton></td>
	</tr>
	<tr>
		<td align="center"><asp:datagrid id="dgrDanhSach" CssClass="QH_DataGrid" runat="server"></asp:datagrid></td>
	</tr>
</TABLE>
