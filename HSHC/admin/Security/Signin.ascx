<%@ Control language="vb" Inherits="PortalQH.Signin" CodeBehind="Signin.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<link href='<%=Request.ApplicationPath + "/portals/_default\Skins\BLUEFOX SKIN\Bluefox.css" %>' type=text/css rel=stylesheet>
	<table align="center" cellspacing="0" cellpadding="0" border="0" width="300">
		<TR>
			<TD height="45"></TD>
		</TR>
		<TR>
			<TD>
				<table cellpadding=0 cellspacing=0 border=0 class="QH_DataGrid" width="320" height=130 bgcolor="#F4F8FD" >
					<tr>
						<td align="center" colspan="3" valign=top>
							<table width="100%" cellpadding=0 cellspacing=0 >
								<tr class="QH_THead" height="20">
									<td width="30%" class="QH_BoxTitleLeft">&nbsp;</td>
									<td class="QH_BoxTitleBG"><span>TRUY CẬP HỆ THỐNG</span></td>
									<td width="30%" class="QH_BoxTitleRight">&nbsp;</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="QH_RowTitle">Tên truy cập</td>
						<td class="QH_ColLabelValue" colspan="2">
							<asp:TextBox id="txtUsername" cssclass="QH_ColControlDate" runat="server" />
						</td>
					</tr>
					<tr>
						<td class="QH_RowTitle">Mật khẩu</td>
						<td class="QH_ColLabelValue" colspan="2">
							<asp:TextBox id="txtPassword" textmode="password" cssclass="QH_ColControlDate"
								runat="server" />
						</td>
					</tr>
					<tr>
						<td height="2" colspan="3">
						</td>
					</tr>
					<tr>
						<td align=center colspan="3">
							<asp:ImageButton id="cmdLogin_Temp" runat="server" Width="0px"></asp:ImageButton>
							<asp:linkbutton class="QH_Button" id="cmdLogin" runat="server" Text="Truy cập">Truy cập</asp:linkbutton>&nbsp;
							<asp:linkbutton class="QH_Button" id="cmdTroVe" runat="server" Text="Trở về">Trở về</asp:linkbutton>
						</td>
					</tr>
				</table>
			</TD>
		</TR>
		<tr id="rowVerification1" runat="server" visible="false">
			<td align="center">
				<label Class="NormalBold" for="<%=txtVerification.ClientID%>">Verification Code:</label>
			</td>
		</tr>
		<tr id="rowVerification2" runat="server" visible="false">
			<td align="center">
				<asp:TextBox id="txtVerification" columns="9" width="130" cssclass="NormalTextBox" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:checkbox id="chkCookie" class="Normal" Text="Remember Login" runat="server" visible="false" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:ImageButton id="cmdSendPassword" ImageUrl="~/images/password.gif" Visible="False" AlternateText="Password Reminder"
					runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:label id="lblLogin" Cssclass="Normal" runat="server" Visible="False" />
			</td>
		</tr>
	</table>
