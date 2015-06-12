<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuuChuyenNhan1CuaPhuongXa.ascx.vb" Inherits="HSHC.ThongTinTraCuuChuyenNhan1CuaPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" class="QH_Table">
	<TR>
		<TD class="QH_ColLabel" width="15%">Họ tên</TD>
		<TD class="QH_ColControl" width="35%">
			<asp:TextBox id="txtHoTen" Width="90%" CssClass="QH_Textbox" runat="server"></asp:TextBox></TD>
		<TD width="15%" class="QH_ColLabel">
			Người chuyển</TD>
		<TD width="35%" class="QH_ColControl"><asp:DropDownList ID="ddlNguoiChuyen" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
	</TR>
	<TR>
		<TD width="15%" class="QH_ColLabel">Số nhà</TD>
		<TD width="35%" class="QH_ColControl"><asp:TextBox ID="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="90%"></asp:TextBox>
		<TD width="15%" class="QH_ColLabel">
			Người nhận</TD>
		<TD width="35%" class="QH_ColControl"><asp:DropDownList ID="ddlNguoiNhan" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
	<TR>
		<TD class="QH_ColLabel" width="15%">
			Phường</TD>
		<TD class="QH_ColControl" width="35%">
			<cc1:KeySortDropDownList id="ddlPhuong" runat="server" CssClass="QH_DropDownList" Width="90%"></cc1:KeySortDropDownList></TD>
		<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
		<TD class="QH_ColControl" width="35%">
			<asp:TextBox id="txtSoBienNhan" Width="35%" CssClass="QH_TextBox" Runat="server"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">
			Đường</TD>
		<TD class="QH_ColControl" width="35%">
			<cc1:KeySortDropDownList id="ddlDuong" runat="server" CssClass="QH_DropDownList" Width="90%"></cc1:KeySortDropDownList></TD>
		<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
		<TD class="QH_ColControl" width="35%"><asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
		<TD class="QH_ColControl" width="35%"><asp:DropDownList ID="ddlLoaiHoSo" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
		<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
		<TD class="QH_ColControl" width="35%"><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">
			Tình trạng</TD>
		<TD class="QH_ColControl" width="35%"><asp:DropDownList ID="ddlTinhTrang" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
		<TD class="QH_ColLabel" width="15%">&nbsp;Ngày chuyển</TD>
		<TD Width="35%" class="QH_ColControl"><asp:TextBox ID="txtNgayChuyen" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdNgayChuyen" CssClass="CommandButton" Runat="server">
				<asp:image id="Image1" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
</TABLE>
