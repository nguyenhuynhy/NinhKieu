<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DyNamicControl.ascx.vb" Inherits="PortalQH.DyNamicControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table cellpadding="0" cellspacing="0" width="100%" align="center">
	<tr>
		<td width="10%" align="left">&nbsp;&nbsp;&nbsp;
			<asp:Label CssClass="QH_label" Runat="server" Text="Tiêu đề" ID="Label1"></asp:Label></td>
		<td width="*">
			<asp:TextBox Runat="server" Width="70%" CssClass="QH_textBox" ID="txtTieuDe"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="10%" align="left">&nbsp;&nbsp;&nbsp;
			<asp:Label CssClass="QH_label" Runat="server" Text="Hình ảnh" ID="Label4"></asp:Label></td>
		<td>
			<asp:TextBox ID="txtFile" Runat="server" CssClass="QH_TextBox"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="10%" align="left">&nbsp;&nbsp;&nbsp;
			<asp:Label CssClass="QH_label" Runat="server" Text="Hình mới" ID="Label2"></asp:Label></td>
		<td>
			<INPUT id="txtUpLoadFile" type="file" name="txtUpLoadFile" size="15" runat="server">
			<!--<asp:LinkButton ID="btnUpLoad" Runat="server">Upload hình...</asp:LinkButton></td>--></td>
	<tr>
		<td align="left">
			<asp:Label ID="lblRong" Runat="server" CssClass="QH_Label">Chiều rộng</asp:Label></td>
		<td>
			<asp:TextBox ID="txtWidth" Width="40%" Runat="server" CssClass="QH_TextBox"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left">
			<asp:Label ID="lblCao" Runat="server" CssClass="QH_Label">Chiều cao</asp:Label></td>
		<td>
			<asp:TextBox ID="txtHeight" Width="40%" Runat="server" CssClass="QH_TextBox"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td>
			<asp:CheckBox ID="chkLeftAligh" Runat="server" Text="Canh trái"></asp:CheckBox>
			&nbsp;&nbsp;
			<asp:CheckBox ID="chkTopAlign" Runat="server" Text="Ở trên"></asp:CheckBox>
			&nbsp;&nbsp;
		</td>
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
	<tr>
		<td align="center"><asp:imagebutton id="btnLuu" Runat="server" ImageUrl="~/images/btnLuu.gif"></asp:imagebutton><asp:imagebutton id="btnBoQua" Runat="server" ImageUrl="~/images/btn_Boqua.gif"></asp:imagebutton><asp:ImageButton ID="btnTroVe" runat="server" ImageUrl="~/images/btn_TroVe.gif"></asp:ImageButton>
		</td>
	</tr>
</table>
