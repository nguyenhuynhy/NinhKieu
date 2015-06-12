<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HuyHoSoPhuong.ascx.vb" Inherits="HSHC.HuyHoSoPhuong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">
function KiemTra()
{
	if (!CheckNull() )
	{
		return false;
	}
	return confirm('Hồ sơ sẽ bị hủy khỏi hệ thống! Bạn có chắc chắn muốn hủy hồ sơ này không?');
}
function SelectLyDo(){
	document.getElementById("<%= ddlLyDoHuy.ClientID%>").disabled = false;
	document.getElementById("<%= txtLyDoKhac.ClientID%>").disabled = true;
}
function InputLyDo(){
	document.getElementById("<%= ddlLyDoHuy.ClientID%>").disabled = true;
	document.getElementById("<%= txtLyDoKhac.ClientID%>").disabled = false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">&nbsp;</asp:label>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="15%"></TD>
								<TD width="70%">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="4" height="5"></TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="99%" border="0" class="QH_Table">
													<TR>
														<TD class="QH_ColLabel" width="25%">Số biên nhận</TD>
														<TD class="QH_ColControl" width="40%"><asp:textbox id="txtSoBienNhan" CssClass="QH_Textbox" Width="60%" Enabled="False" runat="server"></asp:textbox></TD>
														<TD class="QH_ColLabel" width="20%">Ngày nhận hồ sơ</TD>
														<TD class="QH_ColControl" width="15%"><asp:textbox id="txtNgayNhan" CssClass="QH_Textbox" Width="70px" Enabled="False" runat="server"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Họ tên người nộp</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtHoTenNguoiNop" CssClass="QH_Textbox" Width="100%" Enabled="False" runat="server"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Địa chỉ</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtDiaChi" CssClass="QH_TextBox" Width="100%" Enabled="False" runat="server"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Loại hồ sơ</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtLoaiHoSo" CssClass="QH_TextBox" Width="100%" Enabled="False" runat="server"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel"><asp:RadioButton ID="rdoReason" Runat="server" Text="Lý do hủy" GroupName="grpLyDo" Checked="True"
																CssClass="QH_RadioButtonList" TextAlign="Left"></asp:RadioButton><font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlLyDoHuy" CssClass="QH_DropDownList" Width="100%" runat="server"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel"><asp:RadioButton ID="rdoOtherReason" Runat="server" Text="Lý do khác" GroupName="grpLyDo" CssClass="QH_RadioButtonList"
																TextAlign="Left"></asp:RadioButton><font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl" colSpan="3"><asp:TextBox ID="txtLyDoKhac" Runat="server" Width="100%" CssClass="QH_textbox" TextMode="MultiLine"
																Rows="3"></asp:TextBox>
														</TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Ngày hủy<font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl"><asp:textbox id="txtNgayHuy" CssClass="QH_TextBox" Width="70px" runat="server"></asp:textbox>
															&nbsp;<asp:hyperlink id="cmdNgayHuy" CssClass="CommandButton" Runat="server">
																<asp:image id="imgNgayHuy" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
															</asp:hyperlink>
														</TD>
														<TD colSpan="2"></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Ghi chú tại sao hủy</TD>
														<TD class="QH_ColLabel" colSpan="3"><asp:textbox id="txtGhiChu" CssClass="QH_TextBox" Width="100%" runat="server" Rows="5" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<td height="5"></td>
										</TR>
										<tr>
											<td vAlign="bottom" align="center">
												<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnInVB" runat="server" CssClass="QH_Button">In văn bản</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
											</td>
										</tr>
									</TABLE>
								</TD>
								<TD width="15%"></TD>
							</TR>
						</TABLE>
						<asp:textbox id="txtHoSoTiepNhanID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtNguoiHuy" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtNgayTacNghiepCuoiCung" runat="server" Visible="False"></asp:textbox>
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
