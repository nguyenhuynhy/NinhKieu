<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuuKD.ascx.vb" Inherits="CPXD.ThongTinTraCuuKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD vAlign="top" width="100%">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" width="15%">Họ tên</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:TextBox id="txtHoTen" runat="server" CssClass="QH_Textbox" Width="90%"></asp:TextBox></TD>
					<TD class="QH_ColLabel" width="15%">Tình trạng</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:DropDownList id="ddlTinhTrang" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Số nhà</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:TextBox id="txtSoNha" CssClass="QH_TextBox" Width="30%" Runat="server"></asp:TextBox>
					<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:TextBox id="txtSoBienNhan" CssClass="QH_TextBox" Width="50%" Runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Đường</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:DropDownList id="ddlDuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:DropDownList></TD>
					<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:TextBox id="txtTuNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:TextBox>&nbsp;
						<asp:image id="imgTuNgay" runat="server" CssClass="QH_IMAGEBUTTON" AlternateText="Chọn ngày tháng năm"
							ImageUrl="~/images/calendar.gif"></asp:image></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Phường</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:DropDownList id="ddlPhuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:DropDownList></TD>
					<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:TextBox id="txtDenNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:TextBox>&nbsp;
						<asp:image id="imgDenNgay" runat="server" CssClass="QH_IMAGEBUTTON" AlternateText="Chọn ngày tháng năm"
							ImageUrl="~/images/calendar.gif"></asp:image></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Loại hồ sơ</TD>
					<TD class="QH_ColControl">
						<asp:DropDownList id="ddlLoaiHoSo" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:DropDownList></TD>
					<TD class="QH_ColLabel">
						<asp:label id="lblNgay" runat="server">Ngày công văn</asp:label></TD>
					<TD class="QH_ColControl">
						<asp:textbox id="txtNgayCongVan" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>
						<asp:image id="imgNgayCongVan" runat="server" CssClass="QH_IMAGEBUTTON" AlternateText="Chọn ngày tháng năm"
							ImageUrl="~/images/calendar.gif"></asp:image></TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
					<TD class="QH_ColControl" colSpan="2">
						<asp:RadioButtonList id="optLoaiCongVan" runat="server" Width="305px" RepeatDirection="Horizontal">
							<asp:ListItem Value="0" Selected="True">Tất cả</asp:ListItem>
							<asp:ListItem Value="1">B&#225;o c&#225;o đề xuất</asp:ListItem>
							<asp:ListItem Value="2">C&#244;ng văn</asp:ListItem>
						</asp:RadioButtonList></TD>
				</TR>
			</TABLE>
		</TD>
	<tr>
		<!--<td><asp:panel id="Panel1" runat="server">
				<TABLE class="QH_Table" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="QH_ColControl" colSpan="2">
							<asp:RadioButtonList id="Radiobuttonlist1" runat="server" Width="305px" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">B&#225;o c&#225;o đề xuất</asp:ListItem>
								<asp:ListItem Value="2">C&#244;ng văn</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
				</TABLE>
			</asp:panel></td>-->
	</tr>
</TABLE>
