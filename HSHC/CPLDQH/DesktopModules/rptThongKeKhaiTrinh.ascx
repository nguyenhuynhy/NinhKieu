<%@ Control Language="vb" AutoEventWireup="false" Codebehind="rptThongKeKhaiTrinh.ascx.vb" Inherits="CPLDQH.rptThongKeKhaiTrinh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
		<TD class="QH_ColControl" width="20%"><asp:textbox id="txtTuNgay" CssClass="QH_Textbox" runat="server" Width="70px"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
		<TD class="QH_ColLabel" width="10%" colSpan="1" rowSpan="1">Đến ngày</TD>
		<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDenNgay" CssClass="QH_Textbox" runat="server" Width="70px"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">Phường</TD>
		<TD class="QH_ColControl" width="20%"><cc1:KeySortDropDownList id="ddlPhuong" CssClass="QH_DropDownList" Width="90%" runat="server"></cc1:KeySortDropDownList></TD>
		<TD class="QH_ColLabel" width="10%" colSpan="1" rowSpan="1">Loại hình DN</TD>
		<TD class="QH_ColControl" width="20%">
			<asp:DropDownList id="ddlLoaiHinhDoanhNghiep" runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
	</TR>
</TABLE>
