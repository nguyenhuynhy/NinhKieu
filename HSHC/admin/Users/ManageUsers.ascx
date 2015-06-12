<%@ Control language="vb" CodeBehind="ManageUsers.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.ManageUsers" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="Portal" TagName="Address" Src="~/controls/Address.ascx"%>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						&nbsp;
					</td>
					<td width="16" height="24" class="QH_Khung_TopRight">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" class="QH_Khung_Left">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td width="*">
						<portal:title id="Title1" runat="server"></portal:title>
						<br>
						<table width="100%">
							<tr>
								<td align="center">
									<table class="QH_Table" width="50%" cellSpacing="0" cellPadding="0" summary="Manage Users Design Table">
										<TR>
											<TD colSpan="4">
												<asp:label id="Label1" runat="server" Width="100%" Cssclass="QH_Header_Login">THÔNG TIN NGƯỜI SỬ DỤNG</asp:label></TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" width="150"><label for="<%=txtFullName.ClientID%>">Tên đầy đủ</label></td>
											<td class="QH_ColControl"><asp:textbox id="txtFullName" tabIndex="1" runat="server" size="25" MaxLength="50" cssclass="QH_Textbox"
													Width="250px"></asp:textbox><asp:requiredfieldvalidator id="valFirstName" runat="server" Display="Dynamic" ErrorMessage="<br>Full Name Is Required."
													ControlToValidate="txtFullName" CssClass="NormalRed"></asp:requiredfieldvalidator></td>
											<td vAlign="top" rowSpan="7"></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="150" colSpan="1" rowSpan="1">Chức danh</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlChucDanh" runat="server" CssClass="QH_DropdownList" Width="250px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="150" colSpan="1" rowSpan="1">Phòng ban</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhongBan" runat="server" CssClass="QH_DropdownList" Width="250px"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" width="150"><label for="<%=txtUsername.ClientID%>">Tên truy cập</label></td>
											<td class="QH_ColControl"><asp:textbox id="txtUsername" tabIndex="3" runat="server" size="25" MaxLength="100" cssclass="QH_Textbox"
													Width="250px"></asp:textbox><asp:requiredfieldvalidator id="valUsername" runat="server" Display="Dynamic" ErrorMessage="<br>Username Is Required."
													ControlToValidate="txtUsername" CssClass="NormalRed"></asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="150"><label for="<%=txtPassword.ClientID%>">Mật khẩu</label></td>
											<td class="QH_ColControl"><asp:textbox id="txtPassword" tabIndex="4" runat="server" size="25" MaxLength="20" cssclass="QH_Textbox"
													TextMode="Password" Width="250px"></asp:textbox><asp:requiredfieldvalidator id="valPassword" runat="server" Display="Dynamic" ErrorMessage="<br>Password Is Required."
													ControlToValidate="txtPassword" CssClass="NormalRed"></asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="150"><label for="<%=txtConfirm.ClientID%>">Xác nhận mật khẩu</label></td>
											<td class="QH_ColControl"><asp:textbox id="txtConfirm" tabIndex="5" runat="server" size="25" MaxLength="20" cssclass="QH_Textbox"
													TextMode="Password" Width="250px"></asp:textbox><asp:requiredfieldvalidator id="valConfirm1" runat="server" Display="Dynamic" ErrorMessage="<br>Password Confirmation Is Required."
													ControlToValidate="txtConfirm" CssClass="NormalRed"></asp:requiredfieldvalidator><asp:comparevalidator id="valConfirm2" runat="server" Display="Dynamic" ErrorMessage="<br>Password Values Entered Do Not Match."
													ControlToValidate="txtConfirm" CssClass="NormalRed" ControlToCompare="txtPassword"></asp:comparevalidator></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="150"><label for="<%=txtEmail.ClientID%>">Địa chỉ email</label></td>
											<td class="QH_ColControl"><asp:textbox id="txtEmail" tabIndex="6" runat="server" size="25" MaxLength="100" cssclass="QH_Textbox"
													Width="250px"></asp:textbox>
												<asp:regularexpressionvalidator id="valEmail2" runat="server" CssClass="NormalRed" ControlToValidate="txtEmail"
													ErrorMessage="<br>Email Must be Valid." Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"></asp:regularexpressionvalidator>
											</td>
										</tr>
										<tr id="rowAuthorized" runat="server">
											<td class="QH_ColLabel" width="150"><label for="<%=chkAuthorized.ClientID%>">Quyền truy cập</label></td>
											<td class="QH_ColControl"><asp:checkbox id="chkAuthorized" tabIndex="7" Runat="server"></asp:checkbox></td>
										</tr>
										<TR>
											<TD colspan="2" height="3"></TD>
										</TR>
										<TR>
											<TD colspan="2" align="right"><asp:linkbutton class="QH_Button" id="cmdUpdate" runat="server" Text="Update">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton class="QH_Button" id="cmdCancel" runat="server" Text="Cancel" CausesValidation="False">Bỏ qua</asp:linkbutton>&nbsp;
												<asp:linkbutton class="QH_Button" id="cmdDelete" runat="server" Text="Delete" CausesValidation="False">Xóa</asp:linkbutton>&nbsp;
												<asp:linkbutton class="QH_Button" id="cmdManage" runat="server" Text="Manage Security Roles" CausesValidation="False">Quản lý Vai trò bảo mật</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD width="150"></TD>
											<TD><asp:panel id="pnlAudit" Runat="server">
													<TABLE summary="Manage Users Design Table" border="0">
														<TR>
															<TD class="SubHead">Ngày tạo:
															</TD>
															<TD>
																<asp:label id="lblCreatedDate" runat="server" cssclass="Normal"></asp:label></TD>
														</TR>
														<TR>
															<TD class="SubHead">Ngày đăng nhập sau cùng:
															</TD>
															<TD>
																<asp:label id="lblLastLoginDate" runat="server" cssclass="Normal"></asp:label></TD>
														</TR>
													</TABLE>
												</asp:panel></TD>
										</TR>
										<TR>
											<TD class="SubHead" width="150"></TD>
											<TD><asp:label id="Message" runat="server" CssClass="NormalRed"></asp:label></TD>
										</TR>
									</table>
								</td>
							</tr>
						</table>
						<P><portal:address id="Address1" runat="server" Visible="False"></portal:address></P>
					</td>
					<td width="16" class="QH_Khung_Right">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1">
								</td>
							</tr>
						</Table>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
<script language="javascript">
function ThongBao()
{
	alert('Chức năng này tạm ngưng sử dụng!');
	return false;
}
</script>
