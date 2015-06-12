<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuuPhanCong.ascx.vb" Inherits="HSHC.ThongTinTraCuuPhanCong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="50%">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="30%" class="QH_ColLabel">Số nhà</TD>
					<TD width="70%"><asp:TextBox ID="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="90%"></asp:TextBox>
					<TD></TD>
				<TR>
					<TD class="QH_ColLabel">
						Đường</TD>
					<TD><asp:DropDownList ID="ddlDuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">
						Phường</TD>
					<TD><asp:DropDownList ID="ddlPhuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Loại hồ sơ</TD>
					<TD><asp:DropDownList ID="ddlLoaiHoSo" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Tình trạng</TD>
					<TD><asp:DropDownList ID="ddlTinhTrang" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="50%">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="30%" class="QH_ColLabel">Người chuyển</TD>
					<TD width="70%"><asp:DropDownList ID="ddlNguoiChuyen" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Người nhận</TD>
					<TD><asp:DropDownList ID="ddlNguoiNhan" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Số biên nhận</TD>
					<TD>
						<asp:TextBox id="txtSoBienNhan" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:TextBox></TD>
				<TR>
					<TD class="QH_ColLabel">Từ ngày</TD>
					<TD><asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Đến ngày</TD>
					<TD><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
