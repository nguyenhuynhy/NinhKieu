<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapPhoBan.ascx.vb" Inherits="CPKTQH.CapPhoBan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript">
function btnCapNhat_clicked()
{
	var txtNgayCapPhoBan = document.all("<%=txtNgayCapPhoBan.clientID%>");
	var txtSoGiayPhep = document.all("<%=txtSoGiayPhep.clientID%>");
	if (txtSoGiayPhep.value=="")
	{
		alert("Ban chua chon So giay CNDKKD");
		return false;
	}
	if (txtNgayCapPhoBan.value=="")
	{
		alert("Ban chua nhap ngay cap pho ban");
		return false;
	}
	
	return true;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTitle" CssClass="QH_Label_Title" runat="server" Width="100%">Thông tin giấy phó bản ĐKKD</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="90%" border="0">
										<TR>
											<TD height="5"></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE class="QH_Table" id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="20%">Số biên nhận</TD>
																	<TD class="QH_ColControl" width="30%"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="15%">Họ tên</TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtHoTen" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True" EnableViewState="true"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="20%" height="39"><asp:linkbutton id="btnDanhSachGP" runat="server" ToolTip="Lấy thông tin giấp phép" cssclass="QH_ColLabel">Số GCN ĐKKD</asp:linkbutton><asp:label id="lblDanhSachGP" runat="server" cssclass="QH_ColLabel">Số GCN ĐKKD</asp:label></TD>
																	<TD class="QH_ColControl" width="30%" colSpan="1" rowSpan="1" height="39"><asp:textbox id="txtSoGiayPhep" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true" AutoPostBack="True"></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="15%" colSpan="1" rowSpan="1" height="39">Ngày sinh</TD>
																	<TD class="QH_ColControl" height="39"><asp:textbox id="txtNgaySinh" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="20%">Lĩnh vực cấp phép</TD>
																	<TD class="QH_ColControl" width="30%"><asp:textbox id="txtTenLinhVucCapPhep" CssClass="QH_textbox" runat="server" Width="0px" ReadOnly="True"
																			EnableViewState="true"></asp:textbox><asp:textbox id="txtTenPhuongThucKinhDoanh" Width="90%" runat="server" CssClass="QH_textbox"
																			ReadOnly="True" EnableViewState="true"></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="15%">Số CMND</TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="20%">Ngày cấp</TD>
																	<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayCap" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true"></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="15%">Địa chỉ kinh doanh</TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtDiaChiKinhDoanh" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="20%">Bảng hiệu</TD>
																	<TD class="QH_ColControl" width="30%"><asp:textbox id="txtBangHieu" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true" TextMode="MultiLine"></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="15%">Địa chỉ thường trú</TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTru" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="20%">Mặt hàng kinh doanh</TD>
																	<TD class="QH_ColControl" vAlign="middle" width="30%"><asp:textbox id="txtMatHangKinhDoanh" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true" TextMode="MultiLine" Rows="3" ></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="15%" >Ghi chú</TD>
																	<TD class="QH_ColControl" ><asp:textbox id="txtGhiChu" CssClass="QH_textbox" runat="server" Width="90%" EnableViewState="true"
																			TextMode="MultiLine" Rows="3"  MaxLength="1000"></asp:textbox></TD>
																</TR>
																<!--
																<TR>
																	<TD class="QH_ColLabel" width="20%">Hình thức kinh doanh</TD>
																	<TD class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaHinhThucKinhDoanh" CssClass="QH_DropDownList" runat="server" Width="90%"
																			EnableViewState="true" Enabled="False"></asp:dropdownlist></TD>
																</TR>
																-->
																
																<TR>
																	<TD class="QH_ColLabel" width="15%">Vốn kinh doanh</TD>
																	<TD class="QH_ColControl" vAlign="top"><asp:textbox id="txtTienBangChu" Width="0px" Runat="server"></asp:textbox><asp:textbox id="txtVonKinhDoanh" CssClass="QH_TextRight" runat="server" Width="90%" ReadOnly="True"
																			EnableViewState="true" MaxLength="15"></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="20%">Ngày cấp phó bản <FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl" vAlign="top" width="30%"><asp:textbox id="txtNgayCapPhoBan" CssClass="QH_textbox" runat="server" Width="50%" MaxLength="10"></asp:textbox>&nbsp;
																		<asp:image id="imgNgayCapPhoBan" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch"
																			ImageAlign="Middle" ImageUrl="~\images\calendar.gif"></asp:image>&nbsp;Lần 
																		cấp
																		<asp:textbox id="txtSoLanCapPhoBan" CssClass="QH_textbox" runat="server" Width="15%" ReadOnly="True"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="15%"></TD>
																	<TD class="QH_ColControl" vAlign="top"></TD>
																	<TD width="20%"></TD>
																	<TD vAlign="top" width="30%"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD align="center" height="5"></TD>
													<TR>
														<TD align="center"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton><asp:linkbutton id="btnDeXuat" CssClass="QH_Button" runat="server">Đề xuất</asp:linkbutton><asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server">Bổ sung hồ sơ</asp:linkbutton><asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server"> không giải quyết</asp:linkbutton><asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton><asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In GCN ĐKKD</asp:linkbutton><asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtReload" runat="server" Width="0px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
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
<div style="DISPLAY:none"><asp:TextBox ID="txtGiayCNDKKDID" Runat="server"></asp:TextBox></div>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
