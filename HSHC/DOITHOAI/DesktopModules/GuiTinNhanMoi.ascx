<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GuiTinNhanMoi.ascx.vb" Inherits="DOITHOAI.GuiTinNhanMoi" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script>
function CheckCapNhat()
{
	if (!CheckNull())
		return false;
	var objNguoiNhan = document.forms[0].all("<%=txtNguoiNhan.ClientID%>");
	var objNguoiGui = document.forms[0].all("<%=txtNguoiHoi.ClientID%>");
	var objTieuDe = document.forms[0].all("<%=txtTieuDe.ClientID%>");
	
	objNguoiNhan.value = trim(objNguoiNhan.value);
	objTieuDe.value = trim(objTieuDe.value);
	
	if (objNguoiNhan.value == objNguoiGui.value)
	{
		alert('Người nhận câu hỏi không được trùng với người truy cập hệ thống!');
		objNguoiNhan.select();
		objNguoiNhan.focus();
		return false;
	}
	return true;
}
</script>
<TABLE id="main" cellSpacing="0" cellPadding="0" width="570" border="0" align="center">
	<tr>
		<td colspan="2"><asp:Label ID="lblTitle" Runat="server" CssClass="QH_Label_Title" Width="100%">Soạn và gửi tin nhắn</asp:Label></td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
	<tr>
		<td class="QH_ColLabel">Lĩnh vực <FONT color="#ff0000" size="2">*</FONT></td>
		<td class="QH_ColControl">
			<asp:DropDownList id="ddlMaLinhVuc" Width="400px" CssClass="QH_DropDownList" runat="server"></asp:DropDownList></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" width="120">Tiêu đề <FONT color="#ff0000" size="2">*</FONT></td>
		<td class="QH_ColControl" width="450">
			<asp:TextBox id="txtTieuDe" CssClass="QH_TextBox" runat="server" Width="400px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel">Nội dung câu hỏi <FONT color="#ff0000" size="2">*</FONT></td>
		<td class="QH_ColControl">
			<asp:TextBox id="txtNoiDung" CssClass="QH_TextBox" runat="server" TextMode="MultiLine" Rows="10"
				Width="400px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel">Người nhận <FONT color="#ff0000" size="2">*</FONT></td>
		<td class="QH_ColControl">
			<asp:TextBox id="txtNguoiNhan" Width="400px" CssClass="QH_TextBox" runat="server"></asp:TextBox>
			<asp:ImageButton id="btnChonNguoiNhan" runat="server" ToolTip="Chọn người nhận hồ sơ" ImageUrl="~/images/search.gif"
				CssClass="QH_ImageButton"></asp:ImageButton></td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
	<tr>
		<td colspan="2" align="center">
			<asp:linkbutton id="btnGui" CssClass="QH_Button" runat="server">Gửi</asp:linkbutton>&nbsp;
			<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
</TABLE>
<div style="DISPLAY:none">
	<asp:TextBox ID="txtNguoiHoi" Runat="server" Enabled="False"></asp:TextBox>
	<asp:TextBox ID="txtCauHoiID" Runat="server" Enabled="False"></asp:TextBox>
	<asp:TextBox ID="txtUserName" Runat="server"></asp:TextBox>
</div>
