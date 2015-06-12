<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="EditRMenu.ascx.vb" Inherits="PortalQH.EditRMenu" Explicit="True" %>
<table class="QH_Table" cellSpacing="0" cellPadding="0" width="600" align="center">
	<tr>
		<td colSpan="2"><asp:label id="lblLable1" Runat="server" Width="100%" CssClass="QH_label_title">.:: Cấu hình hiển thị Menu phải</asp:label></td>
	</tr>
	<tr>
		<td colSpan="2" height="10"></td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td align="left" width="10%">&nbsp;&nbsp;&nbsp;
						<asp:label id="Label1" Runat="server" CssClass="QH_label" Text="Tiêu đề"></asp:label></td>
					<td width="*"><asp:textbox id="txtTieuDe" Runat="server" Width="70%" CssClass="QH_textBox"></asp:textbox></td>
				</tr>
				<tr>
					<td align="left" width="10%">&nbsp;&nbsp;&nbsp;
						<asp:label id="Label4" Runat="server" CssClass="QH_label" Text="Hình ảnh"></asp:label></td>
					<td>
						<asp:TextBox ID="txtFile" Runat="server" CssClass="QH_TextBox"></asp:TextBox></td>
				</tr>
				<tr>
					<td width="10%" align="left">&nbsp;&nbsp;&nbsp;
						<asp:Label CssClass="QH_label" Runat="server" Text="Hình mới" ID="Label2"></asp:Label></td>
					<td>
						<INPUT id="txtUpLoadFile" type="file" name="txtUpLoadFile" size="15" runat="server">
						<asp:Label ID="lblMessage" Runat="server" CssClass="QH_label"></asp:Label>
					</td>
				</tr>
				<tr>
					<td align="left">
						<asp:Label ID="lblRong" Runat="server" CssClass="QH_Label">Chiều rộng</asp:Label></td>
					<td>
						<asp:TextBox ID="txtWidth" Width="40%" Runat="server" CssClass="QH_TextBox"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="left">
						<asp:Label Runat="server" ID="lblCao" CssClass="QH_Label">Chiều cao</asp:Label></td>
					<td>
						<asp:TextBox ID="txtHeight" Width="40%" Runat="server" CssClass="QH_TextBox"></asp:TextBox></td>
				</tr>
				<tr>
					<td width="10%" align="left">&nbsp;&nbsp;&nbsp;
						<asp:Label CssClass="QH_label" Runat="server" Text="Nội dung" ID="Label3"></asp:Label></td>
					<td>
						<asp:TextBox Runat="server" TextMode="MultiLine" Width="70%" MaxLength="300" Rows="3" CssClass="QH_textBox"
							ID="txtNoiDung"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" height="10"></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
	<tr>
		<td align="center">
			<asp:linkbutton id="btnLuu" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>
			<asp:linkbutton id="btnBoqua" runat="server" CssClass="QH_Button">Bỏ qua</asp:linkbutton>
			<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
		</td>
	</tr>
</table>
