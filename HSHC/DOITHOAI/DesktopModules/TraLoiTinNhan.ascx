<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TraLoiTinNhan.ascx.vb" Inherits="DOITHOAI.TraLoiTinNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="main" cellSpacing="0" cellPadding="0" width="80%" border="0" align="center">
	<tr>
		<td colspan="2"><asp:label id="lblTitle" Runat="server" Width="100%" CssClass="QH_Label_Title">GỬI TRẢ LỜI</asp:label></td>
	</tr>
	<tr>
		<td height="10"></td>
	</tr>
	<tr>
		<td class="QH_ColLabel">Lĩnh vực <FONT color="#ff0000" size="2">*</FONT></td>
		<td class="QH_ColControl">
			<asp:TextBox id="txtTenLinhVuc" CssClass="QH_TextBox" runat="server" Width="400px" Enabled="False"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" width="20%">Tiêu đề <FONT color="#ff0000" size="2">*</FONT></td>
		<td class="QH_ColControl" width="*">
			<asp:TextBox id="txtTieuDe" CssClass="QH_TextBox" runat="server" Width="400px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel">Nội dung&nbsp;trả lời&nbsp; <FONT color="#ff0000" size="2">*</FONT></td>
		<td class="QH_ColControl">
			<asp:TextBox id="txtNoiDung" CssClass="QH_TextBox" runat="server" TextMode="MultiLine" Rows="10"
				Width="400px"></asp:TextBox></td>
	</tr>
	<TR>
		<TD class="QH_ColLabel">Người nhận</TD>
		<TD class="QH_ColControl">
			<asp:TextBox id="txtNguoiNhan" CssClass="QH_TextBox" Width="400px" Enabled="False" runat="server"></asp:TextBox></TD>
	</TR>
	<tr>
		<td height="10"></td>
	</tr>
	<tr>
		<td colspan="2" align="center">
			<asp:linkbutton id="btnGui" CssClass="QH_Button" runat="server">Gửi trả lời</asp:linkbutton>&nbsp;
			<asp:LinkButton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:LinkButton>&nbsp;
			<asp:LinkButton id="btnTroVeDanhSach" CssClass="QH_Button" runat="server"> Danh sách câu hỏi</asp:LinkButton></td>
	</tr>
</TABLE>
<div style="DISPLAY:none">
	<asp:TextBox ID="txtTinNhanChiTietID" Runat="server" Enabled="False"></asp:TextBox>
	<asp:TextBox ID="txtNguoiGui" Runat="server" Enabled="False"></asp:TextBox>
	<asp:TextBox ID="txtTinNhanID" Runat="server" Enabled="False"></asp:TextBox>
	<asp:CheckBox id="chkTinNhanDauTien" Enabled="False" runat="server"></asp:CheckBox>
</div>
