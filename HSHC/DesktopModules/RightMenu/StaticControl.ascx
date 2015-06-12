<%@ Control Language="vb" AutoEventWireup="false" Codebehind="StaticControl.ascx.vb" Inherits="PortalQH.StaticControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
	<tr>
		<td width="45%">
			<table cellpadding="0" cellspacing="0" border="0" width="100%" align="center" class="QH_ChildTable">
				<tr>
					<td width="10%" align="left">&nbsp;&nbsp;&nbsp;
						<asp:Label CssClass="QH_label" Runat="server" Text="Tiêu đề" ID="Label1"></asp:Label></td>
					<td width="30%">
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
					<td align="center" colspan=2><asp:imagebutton id="btnLuu" Runat="server" ImageUrl="~/images/btnLuu.gif"></asp:imagebutton><asp:imagebutton id="btnBoQua" Runat="server" ImageUrl="~/images/btn_Boqua.gif"></asp:imagebutton><asp:ImageButton ID="btnTroVe" runat="server" ImageUrl="~/images/btn_TroVe.gif"></asp:ImageButton>
					</td>
				</tr>
			</table>
		</td>
		<td width="5%">
			<asp:ImageButton ID="btnQuaPhai" Runat="server" ImageUrl="~/images/btn_QuaPhai.gif"></asp:ImageButton>
		</td>
		<td runat="server" id="tdDanhSach" width="50%" valign="top">
			<table id="tblDanhSach" runat="server" width="100%">
				<tr class="QH_Khung_TopMid">
					<td>
						<asp:CheckBox ID="chkChon" Runat="server"></asp:CheckBox>
					</td>
					<td>
						<asp:Label ID="lbl1" Runat="server" CssClass="QH_Label">Tiêu đề</asp:Label>
					</td>
					<td>
						<asp:Label ID="Label5" Runat="server" CssClass="QH_Label">Hình ảnh</asp:Label>
					</td>
					<td>
						<asp:Label ID="Label6" Runat="server" CssClass="QH_Label">Nội dung</asp:Label>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
