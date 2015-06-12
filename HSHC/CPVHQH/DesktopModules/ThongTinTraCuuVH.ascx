<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuuVH.ascx.vb" Inherits="CPVHQH.ThongTinTraCuuVH" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD class="QH_ColLabel" width="15%">Họ tên</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" runat="server" CssClass="QH_Textbox" Width="90%"></asp:textbox></TD>
		<TD class="QH_ColLabel" width="15%">Tình trạng</TD>
		<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlTinhTrang" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">Số nhà</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Width="30%" Runat="server"></asp:textbox>
		<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" CssClass="QH_TextBox" Width="50%" Runat="server"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Phường</TD>
		<TD class="QH_ColControl">
			<cc1:KeySortDropDownList id="ddlPhuong" Width="90%" CssClass="QH_DropDownList" runat="server"></cc1:KeySortDropDownList></TD>
		<TD class="QH_ColLabel">Từ ngày</TD>
		<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:HyperLink id="cmdTuNgay" CssClass="CommandButton" runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:HyperLink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Đường</TD>
		<TD class="QH_ColControl">
			<cc1:KeySortDropDownList id="ddlDuong" Width="90%" CssClass="QH_DropDownList" runat="server"></cc1:KeySortDropDownList></TD>
		<TD class="QH_ColLabel">Đến ngày</TD>
		<TD class="QH_ColControl"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:HyperLink id="cmdDenNgay" CssClass="CommandButton" runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:HyperLink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Loại hồ sơ</TD>
		<TD class="QH_ColControl"><asp:dropdownlist id="ddlLoaiHoSo" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
		<TD class="QH_ColLabel"><asp:label id="lblNgay" runat="server">Ngày công văn</asp:label></TD>
		<TD class="QH_ColControl"><asp:textbox id="txtNgayCongVan" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:HyperLink id="cmdNgayCongVan" CssClass="CommandButton" runat="server">
				<asp:image id="imgNgayCongVan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:HyperLink></TD>
	</TR>
	<tr>
		<td colspan="2"></td>
		<td colspan="2" class="QH_ColControl">
			<asp:RadioButtonList id="optLoaiCongVan" Width="305px" runat="server" RepeatDirection="Horizontal" CssClass="QH_RadioButtonList">
				<asp:ListItem Value="0" Selected="True">Tất cả</asp:ListItem>
				<asp:ListItem Value="1">B&#225;o c&#225;o đề xuất</asp:ListItem>
				<asp:ListItem Value="2">C&#244;ng văn</asp:ListItem>
			</asp:RadioButtonList></td>
	</tr>
</TABLE>
