<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThuLePhi.ascx.vb" Inherits="HSHC.ThuLePhi" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language="javascript">
function getEval(objsrc, objtarget){
	objtarget.value = trim(objsrc.value)
}
function CheckCapNhat()
{
	if (!CheckNull())
		return false;
	return true;
}
</script>
<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD height="24" width="100%">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_TopLeft" height="24" width="16"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">&nbsp;</asp:label></td>
					<td class="QH_Khung_TopRight" height="24" width="16"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td width="*">
						<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD align="center">
									<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="80%">
										<TR>
											<TD height="5" colSpan="4"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="50%" align="right">Số biên nhận&nbsp;&nbsp;&nbsp;</TD>
											<TD class="QH_ColControl" width="50%"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="70%" Enabled="False" runat="server"></asp:textbox><asp:textbox style="Z-INDEX: 0" id="txtHoSoTiepNhanID" CssClass="QH_textbox" Width="36px" runat="server"
													Visible="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="50%" align="right">Họ tên&nbsp;&nbsp;&nbsp;</TD>
											<TD class="QH_ColControl" width="50%"><asp:textbox id="txtHoTenNguoiNop" CssClass="QH_textbox" Width="70%" Enabled="False" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17" align="right">Số tiền nộp <FONT color="#ff0000" size="2">
													*</FONT></TD>
											<TD class="QH_ColControl" height="17"><asp:textbox id="txtSoTienNop" CssClass="QH_textbox" Width="70%" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="15" align="right">Số tiền đăng bộ <FONT color="#ff0000" size="2">
													*</FONT></TD>
											<TD class="QH_ColControl" height="5" colSpan="2"><asp:textbox id="txtSoTienDangBo" CssClass="QH_textbox" Width="70%" runat="server"></asp:textbox></TD>
										<TR>
										<TR>
											<TD class="QH_ColLabel" height="15"></TD>
											<TD class="QH_ColControl" height="5" colSpan="2"></TD>
										<TR>
										<TR>
											<TD height="24" colSpan="2"></TD>
										<TR>
											<TD height="23" vAlign="middle" colSpan="5" align="center"><asp:textbox style="Z-INDEX: 0" id="txtMaLinhVuc" CssClass="QH_textbox" Width="19px" runat="server"
													Visible="False"></asp:textbox><asp:textbox style="Z-INDEX: 0" id="txtTabCode" CssClass="QH_textbox" Width="19px" runat="server"
													Visible="False"></asp:textbox><asp:textbox style="Z-INDEX: 0" id="txtMaNguoiTacNghiep" CssClass="QH_textbox" Width="19px" runat="server"
													Visible="False"></asp:textbox>&nbsp;
												<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;&nbsp;&nbsp;
												<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD height="5" colSpan="2"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr height="*">
								<td height="17"></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
