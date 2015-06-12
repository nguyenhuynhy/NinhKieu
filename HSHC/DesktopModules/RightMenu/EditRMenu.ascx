<%@ Control Language="vb" AutoEventWireup="false" Codebehind="EditRMenu.ascx.vb" Inherits="PortalQH.EditRMenu" Explicit="True" %>
<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">.:: Cấu hình hiển thị Menu phải ::.</asp:label>
					</td>
					<td width="8" height="25" class="QH_Content_TopRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="9" class="QH_Content_Left">&nbsp;
					</td>
					<td width="*" valign="top" align="center">
						<!--End bound-->
						<table cellSpacing="0" cellPadding="0" width="70%" align="center">
							<tr>
								<td colSpan="2" height="10"></td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" align="center">
										<tr>
											<td align="left" width="20%">&nbsp;&nbsp;&nbsp;
												<asp:label id="Label1" Runat="server" CssClass="QH_ColLabel" Text="Tiêu đề"></asp:label></td>
											<td width="*"><asp:textbox id="txtTieuDe" Runat="server" Width="70%" CssClass="QH_TextBox"></asp:textbox></td>
										</tr>
										<tr>
											<td align="left" width="10%">&nbsp;
												<asp:label id="Label4" Runat="server" CssClass="QH_ColLabel" Text="Hình ảnh"></asp:label></td>
											<td>
												<asp:TextBox ID="txtFile" Runat="server" Width="70%" CssClass="QH_TextBox"></asp:TextBox></td>
										</tr>
										<tr>
											<td width="10%" align="left">&nbsp;
												<asp:Label CssClass="QH_ColLabel" Runat="server" Text="Hình mới" ID="Label2"></asp:Label></td>
											<td>
												<INPUT id="txtUpLoadFile" Class="QH_TextBox" type="file" name="txtUpLoadFile" size="38" runat="server">
												<asp:Label ID="lblMessage" Runat="server" CssClass="QH_ColLabel"></asp:Label>
											</td>
										</tr>
										<tr>
											<td align="left">
												<asp:Label ID="lblRong" Runat="server" CssClass="QH_ColLabel">Chiều rộng</asp:Label></td>
											<td>
												<asp:TextBox ID="txtWidth" Width="20%" Runat="server" CssClass="QH_TextRight"></asp:TextBox></td>
										</tr>
										<tr>
											<td align="left">
												<asp:Label Runat="server" ID="lblCao" CssClass="QH_ColLabel">Chiều cao</asp:Label></td>
											<td>
												<asp:TextBox ID="txtHeight" Width="20%" Runat="server" CssClass="QH_TextRight"></asp:TextBox></td>
										</tr>
										<tr>
											<td width="10%" align="left">&nbsp;&nbsp;&nbsp;
												<asp:Label CssClass="QH_ColLabel" Runat="server" Text="Nội dung" ID="Label3"></asp:Label></td>
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
								<td align="center"><asp:imagebutton id="btnLuu" Runat="server" ImageUrl="~/images/btnLuu.gif"></asp:imagebutton><asp:imagebutton id="btnBoQua" Runat="server" ImageUrl="~/images/btn_Boqua.gif"></asp:imagebutton><asp:imagebutton id="btnTroVe" runat="server" ImageUrl="~/images/btn_TroVe.gif"></asp:imagebutton></td>
							</tr>
						</table>
<!--start bound-->
					</td>
					<td width="8" class="QH_Content_Right">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colspan="3" height="12">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="128" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
					</td>
					<td width="130" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->