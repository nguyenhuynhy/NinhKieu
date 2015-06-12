<%@ Control language="vb" Inherits="PortalQH.ChangePassword" CodeBehind="ChangePassword.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<link href='<%=Request.ApplicationPath + "/portals/_default\Skins\BLUEFOX SKIN\Bluefox.css" %>' type=text/css rel=stylesheet>
	<table align="center" cellspacing="0" cellpadding="0" border="0" width="300">
		<TR>
			<TD height="45"></TD>
		</TR>
		<TR>
			<TD valign="top">
				<table cellspacing="0" cellpadding="0" border="0" class="QH_DataGrid" width=380 height=160 bgcolor="#F4F8FD">
					<tr>
						<td align="center" colspan="2" valign=top>
							<table width="100%" cellpadding=0 cellspacing=0 >
								<tr class="QH_THead" height="20">
									<td width="30%" class="QH_BoxTitleLeft">&nbsp;</td>
									<td class="QH_BoxTitleBG"><span>THAY ĐỔI MẬT KHẨU</span></td>
									<td width="30%" class="QH_BoxTitleRight">&nbsp;</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="QH_RowTitle">Mật khẩu cũ</td>
						<td class="QH_ColLabelValue">
							<asp:TextBox id="txtOldPassword" textmode="password" cssclass="QH_ColControlDate"
								runat="server" />
						</td>
					</tr>
					<tr>
						<td class="QH_RowTitle">Mật khẩu mới</td>
						<td class="QH_ColLabelValue">
							<asp:TextBox id="txtNewPassword" textmode="password" cssclass="QH_ColControlDate"
								runat="server" />
						</td>
					</tr>
					<tr>
						<td class="QH_RowTitle">Nhập lại mật khẩu mới</td>
						<td class="QH_ColLabelValue">
							<asp:TextBox id="txtConfirm" textmode="password" cssclass="QH_ColControlDate"
								runat="server" />
						</td>
					</tr>
					<tr id="rowVerification1" runat="server" visible="false">
						<td align="center" colspan="2">
							<label Class="NormalBold" for="<%=txtVerification.ClientID%>">Verification Code:</label>
						</td>
					</tr>
					<tr id="rowVerification2" runat="server" visible="false">
						<td align="center" colspan="2">
							<asp:TextBox id="txtVerification" columns="9" width="130" cssclass="QH_NormalTextBox" runat="server" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<asp:checkbox id="chkCookie" class="Normal" Text="Remember Login" runat="server" visible="false" />
						</td>
					</tr>
					<tr>
						<td colspan="2" align=center >
							<asp:ImageButton id="btnCapNhat_Tmp" runat="server" Width="0px"></asp:ImageButton>
							<asp:linkbutton class="QH_Button" id="btnCapNhat" runat="server" Text="Update">Cập nhật</asp:linkbutton>&nbsp; 
							<!--<a href="javascript:resetform();"><img src=".\images\btn_boqua.gif" border="0"></a>-->
						</td>
					</tr>
				</table>
			</TD>
		</TR>
		<tr>
			<td colspan="3">
				<asp:ImageButton id="cmdSendPassword" ImageUrl="~/images/password.gif" Visible="False" AlternateText="Password Reminder"
					runat="server" />
			</td>
		</tr>
		<tr>
			<td colspan="3">
				<asp:label id="lblLogin" Cssclass="Normal" runat="server" Visible="False" />
			</td>
		</tr>
		<tr>
			<td colspan="3" height="15"></td>
			</TD>
		</tr>
		<tr>
			<td align="center" colspan="3">&nbsp;<asp:TextBox id="txtUserName" columns="9" width="130" cssclass="QH_TextBox" runat="server" Visible="False" /></td>
		</tr>
	</table>
	<script language="javascript">
	function resetform()
	{
		document.forms[0].reset();
		document.getElementById('<%=txtOldPassword.ClientID%>').focus()
	}
	function checkSamePassword()
	{
		str1 = document.getElementById('<%=txtNewPassword.ClientID%>').value;
		str2 = document.getElementById('<%=txtConfirm.ClientID%>').value;
		if(str1==str2)
			return true;
		else
		{
			alert('Nhap lai Password moi!');
			document.getElementById('<%=txtConfirm.ClientID%>').focus();
			return false;
		}
	}
	</script>
