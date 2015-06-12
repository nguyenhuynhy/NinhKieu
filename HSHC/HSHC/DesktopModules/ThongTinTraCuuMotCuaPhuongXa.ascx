<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuuMotCuaPhuongXa.ascx.vb" Inherits="HSHC.ThongTinTraCuuMotCuaPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
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
		<TD Width="35%" class="QH_ColControl">
			<asp:TextBox id="txtHoTen" CssClass="QH_Textbox" runat="server" Width="90%"></asp:TextBox></TD>
		<TD width="15%" class="QH_ColLabel">
			Tình trạng</TD>
		<TD width="35%" class="QH_ColControl"><asp:DropDownList ID="ddlTinhTrang" Runat="server" CssClass="QH_DropDownList" Width="75%"></asp:DropDownList></TD>
	</TR>
	<TR>
		<TD width="15%" class="QH_ColLabel">Số nhà</TD>
		<TD width="35%" class="QH_ColControl"><asp:TextBox ID="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="90%"></asp:TextBox></TD>
		<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
		<TD class="QH_ColControl" Width="35%">
			<asp:TextBox id="txtSoBienNhan" Width="35%" CssClass="QH_TextBox" Runat="server"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">
			Phường</TD>
		<TD Width="35%" class="QH_ColControl">
			<cc1:KeySortDropDownList id="ddlPhuong" Width="90%" runat="server" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></TD>
		<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
		<TD Width="35%" class="QH_ColControl"><asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%" height="11">
			Đường</TD>
		<TD Width="35%" class="QH_ColControl" height="11">
			<cc1:KeySortDropDownList id="ddlDuong" Width="90%" runat="server" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></TD>
		<TD class="QH_ColLabel" width="15%" height="11">Đến ngày</TD>
		<TD Width="35%" class="QH_ColControl" height="11"><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%"></TD>
		<TD Width="35%" class="QH_ColControl"></TD>
		<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
		<TD Width="35%" class="QH_ColControl"><asp:DropDownList ID="ddlLoaiHoSo" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
	</TR>
</TABLE>
