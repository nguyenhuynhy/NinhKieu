<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HuyGiayCNDKKD.ascx.vb" Inherits="CPKTQH.HuyGiayCNDKKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblHeader" Width="100%" CssClass="QH_Label_Title" runat="server"> Thông tin hủy giấy CN ĐKKD</asp:label>
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
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="90%" border="0">
										<TR>
											<TD height="5"></TD>
										</TR>
										<TR>
											<TD align="center"><asp:Label ID="lblTieuDe" Runat="server"></asp:Label></TD>
										</TR>
										<tr>
											<td>
												<TABLE id="tblNoiDung" runat="server" cellSpacing="0" cellPadding="0" width="100%" border="0"
													class="QH_Table">
													<TR>
														<TD class="QH_ColLabel" width="20%"><asp:label id="lblDanhSachGP" runat="server">Số GCN ĐKKD</asp:label></TD>
														<TD class="QH_ColControl" width="*"><asp:textbox id="txtSoGiayPhep" Width="40%" CssClass="QH_TextBox" ReadOnly="True" Runat="server"
																Enabled="False"></asp:textbox>&nbsp;</TD>
														<TD class="QH_ColLabel" width="15%">Ngày ÐKKD</TD>
														<TD class="QH_ColControl" width="25%"><asp:textbox id="txtNgayCapCNDKKD" Width="50%" CssClass="QH_TextBox" Runat="server" Enabled="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Họ tên</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtHoTen" Width="100%" CssClass="QH_TextBox" runat="server" Enabled="False"></asp:textbox></TD>
														<TD class="QH_ColLabel">Số CMND</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" Width="50%" CssClass="QH_TextBox" Runat="server" Enabled="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Địa chỉ kinh doanh</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtDiaChi" Width="100%" CssClass="QH_TextBox" runat="server" Enabled="False"></asp:textbox></TD>
														<td class="QH_ColLabel">Số biên nhận</td>
														<td class="QH_ColControl"><asp:textbox id="txtSoBienNhan" Width="70%" CssClass="QH_TextBox" runat="server" Enabled="False"></asp:textbox></td>
													</TR>
													<tr>
														<td colspan="4" height="20"></td>
													</tr>
													<TR>
														<TD class="QH_ColLabel" height="16">Lý do hủy<font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlLyDoHuy" Width="100%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
														<td></td>
														<td></td>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Người duyệt<font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlNguoiDuyet" Width="100%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
														<TD class="QH_ColLabel">Ngày duyệt<font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl"><asp:textbox id="txtNgayDuyet" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayDuyet" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch"
																ImageAlign="Middle" ImageUrl="~\images\calendar.gif"></asp:image></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Người hủy<font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlNguoiHuy" Width="100%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
														<TD class="QH_ColLabel">Ngày hủy<font size="2" color="#ff0000">*</font></TD>
														<TD class="QH_ColControl"><asp:textbox id="txtNgayHuy" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayHuy" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch" ImageAlign="Middle"
																ImageUrl="~\images\calendar.gif"></asp:image></TD>
													</TR>
													<tr>
														<td class="QH_ColLabel">Ghi chú</td>
														<td><asp:TextBox ID="txtGhiChu" Runat="server" CssClass="QH_TextBox" Width="100%" TextMode="MultiLine"
																Rows="3" MaxLength="2000"></asp:TextBox></td>
														<td colspan="2"></td>
													</tr>
												</TABLE>
											</td>
										</tr>
										<TR>
											<TD height="5"></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>
												<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>
												<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
												<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td><div style="DISPLAY:none">
										<asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtLinhVuc" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtNguoiTacNghiep" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtReload" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox>
										<asp:TextBox ID="txtHuyGiayCNDKKDID" Runat="server" Enabled="False"></asp:TextBox><asp:TextBox ID="txtGiayCNDKKDID" Runat="server" Enabled="False"></asp:TextBox>
									</div>
								</td>
							</tr>
						</TABLE>
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
function KiemTraCapNhat()
{
	if (!CheckNull())
		return false;
	//trường hợp mới cập nhật lần đầu: alert thông báo
	if (document.forms[0].all("<%=txtHuyGiayCNDKKDID.ClientID%>").value == '')
		return confirm('Ban co chac chan muon huy giay CN DKKD nay khong?');
	else
		return true;
}
</script>
