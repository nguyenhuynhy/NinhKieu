<%@ Control Language="vb" AutoEventWireup="false" Codebehind="rptTinhHinhThuLyHoSo.ascx.vb" Inherits="HSHC.rptTinhHinhThuLyHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
</SCRIPT>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" width="20%">Hình thức lọc hồ sơ</TD>
					<TD colSpan="3">
						<asp:RadioButtonList id="rblHinhThucLoc" runat="server" RepeatDirection="Horizontal" Width="400px">
							<asp:ListItem Value="1" Selected="True">Ng&#224;y nhận hồ sơ</asp:ListItem>
							<asp:ListItem Value="2">Đ&#227; giải quyết hồ sơ</asp:ListItem>
							<asp:ListItem Value="3">Hồ sơ q&#250;a hạn</asp:ListItem>
						</asp:RadioButtonList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
					<TD width="30%" colSpan="2">
						<asp:TextBox id="txtTuNgay" runat="server" Width="70px" CssClass="QH_Textbox"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Đến ngày</TD>
					<TD colSpan="2">
						<asp:TextBox id="txtDenNgay" runat="server" Width="70px" CssClass="QH_Textbox"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
					<TD>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
