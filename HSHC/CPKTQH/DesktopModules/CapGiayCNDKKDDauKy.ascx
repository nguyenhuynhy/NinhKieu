<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapGiayCNDKKDDauKy.ascx.vb" Inherits="CPKTQH.CapGiayCNDKKDDauKy" %>
<%@ Register TagPrefix="uc2" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<uc2:combofilter id="ctrlScriptComboFilterPhuong" runat="server"></uc2:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function CheckCapNhat()
{
	if (!CheckNull())
		return false;
	return true
}
function getNganhKinhDoanh(objNganh, objMatHang)
{
	if (objMatHang.value == '')
		objMatHang.value = objNganh.options[objNganh.selectedIndex].text;
	else
		objMatHang.value = objMatHang.value + ', ' + objNganh.options[objNganh.selectedIndex].text;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TBODY>
		<TR>
			<TD width="100%" height="24">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="QH_Khung_TopLeft" width="16" height="24"></td>
						<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" runat="server" Width="100%" CssClass="QH_Label_Title">Thông tin giấy Chứng nhận ĐKKD</asp:label></td>
						<td class="QH_Khung_TopRight" width="16" height="24"></td>
					</tr>
				</table>
			</TD>
		</TR>
		<TR>
			<TD align="center">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
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
							<td align="left" width="*">
								<table width="98%" align="center">
									<!-- add  các user control   -->
									<TBODY>
										<tr vAlign="top">
											<TD align="center" width="100%">
												<table class="QH_Table" id="table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TBODY>
														<tr>
															<td width="15%"></td>
															<td width="35%"></td>
															<td width="15%"></td>
															<td width="35%"></td>
														</tr>
														<tr>
															<td vAlign="top" colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%"><strong><asp:label id="lblSo" runat="server">Số GCN ĐKKD</asp:label><FONT color="#ff0000" size="4">*</FONT></strong></td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoGiayPhep" runat="server" Width="50%" CssClass="QH_Textbox" MaxLength="20"></asp:textbox></td>
																	</tr>
																</table>
															</td>
															<td vAlign="top" colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%"><strong><asp:label id="lblSoGiayPhepTruoc1" runat="server">Số GCN ĐKKD cũ</asp:label></strong></td>
																		<td class="QH_ColControl" width="30%"><asp:textbox id="txtSoGiayPhepTruoc" runat="server" Width="100%" CssClass="QH_Textbox" MaxLength="20"></asp:textbox></td>
																		<td class="QH_ColLabel" width="20%">Ngày cấp</td>
																		<td class="QH_ColControl" width="20%"><asp:textbox id="txtNgayCapGiayPhepTruoc" runat="server" Width="100%" CssClass="QH_Textbox" MaxLength="10"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel" width="30%"><strong><asp:label id="Label4" runat="server">Số GCN ĐKKD gốc</asp:label></strong></td>
																		<td class="QH_ColControl" width="30%"><asp:textbox id="txtSoGiayPhepGoc" runat="server" Width="100%" CssClass="QH_Textbox" MaxLength="20"></asp:textbox></td>
																		<td class="QH_ColLabel" width="20%">Ngày cấp</td>
																		<td class="QH_ColControl" width="20%"><asp:textbox id="txtNgayCapGoc" runat="server" Width="100%" CssClass="QH_Textbox" MaxLength="10"></asp:textbox></td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td width="100%" colSpan="4"><asp:label id="Label3" runat="server" Width="100%" CssClass="QH_LabelLeftBold"><strong>Thông 
																		tin kinh doanh</strong></asp:label></td>
														</tr>
														<tr>
															<td colSpan="4" height="5"></td>
														</tr>
														<tr>
															<td vAlign="top" colSpan="2" height="137">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td width="30%" class="QH_ColLabel">Lĩnh vực CP<FONT color="#ff0000" size="4">*</FONT>
																		</td>
																		<td width="70%" class="QH_ColControl"><asp:dropdownlist id="ddlMaLinhVucCapPhep" runat="server" Width="0" CssClass="QH_Dropdownlist"></asp:dropdownlist><asp:dropdownlist id="ddlMaPhuongThucKinhDoanh" runat="server" Width="100%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Ngành&nbsp;KD <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl"><asp:dropdownlist id="ddlMaNganhKinhDoanh" runat="server" Width="100%" CssClass="QH_DropDownList"
																				EnableViewState="true"></asp:dropdownlist></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel" rowSpan="2">Mặt hàng&nbsp;KD<FONT color="#ff0000" size="4">*</FONT>
																		</td>
																		<td class="QH_ColControl" rowSpan="2"><asp:textbox id="txtMatHangKinhDoanh" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="1000"
																				EnableViewState="true" Height="42px" TextMode="MultiLine" Rows="1"></asp:textbox></td>
																	</tr>
																</table>
															</td>
															<td vAlign="top" colSpan="2" height="137">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%">Bảng hiệu</td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtBangHieu" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel" width="30%">
																		Tổng số lao động
																		<td class="QH_ColControl" width="70%"><asp:textbox style="Z-INDEX: 0" id="txtTongSoLaoDong" runat="server" Width="50%" CssClass="QH_TextRight"
																				MaxLength="15" EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel" width="30%">Vốn kinh doanh <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtVonKinhDoanh" runat="server" Width="50%" CssClass="QH_TextRight" MaxLength="15"
																				EnableViewState="true"></asp:textbox>&nbsp;
																			<asp:Label id="lblLabelDonViTinh" runat="server"></asp:Label></td>
																	</tr>
																	<!--
																	<tr>
																		<td class="QH_ColLabel">Hình thức&nbsp;KD</td>
																		<td class="QH_ColControl"><asp:dropdownlist id="ddlMaHinhThucKinhDoanh" runat="server" Width="50%" CssClass="QH_DropDownList"
																				EnableViewState="true"></asp:dropdownlist></td>
																	</tr>
																	-->
																	<tr>
																		<td class="QH_ColLabel">
																			Ngày cấp <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl"><asp:textbox id="txtNgayCap" runat="server" Width="30%" CssClass="QH_textbox" MaxLength="10"
																				EnableViewState="true"></asp:textbox>&nbsp;<asp:image id="imgNgayCap" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
																				ImageAlign="AbsMiddle" AlternateText="Chọn lịch"></asp:image></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Ngày hết hạn</td>
																		<td class="QH_ColControl"><asp:textbox id="txtNgayHetHan" runat="server" Width="30%" CssClass="QH_textbox" MaxLength="10"
																				EnableViewState="true"></asp:textbox>&nbsp;<asp:image id="imgNgayHetHan" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
																				ImageAlign="AbsMiddle" AlternateText="Chọn lịch"></asp:image></td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td colSpan="4" height="5"></td>
														</tr>
														<tr>
															<td width="100%" colSpan="4"><asp:label id="lblKinhDoanh" runat="server" Width="100%" CssClass="QH_LabelLeftBold"><strong>Địa 
																		chỉ kinh doanh</strong></asp:label></td>
														</tr>
														<tr>
															<td colSpan="4" height="5"></td>
														</tr>
														<tr>
															<td colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%">Số nhà <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoNha" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Phường <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl">
																			<cc1:KeySortDropDownList id="ddlMaPhuong" runat="server" CssClass="QH_DropDownList" Width="100%"></cc1:KeySortDropDownList></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Đường <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl">
																			<cc1:KeySortDropDownList id="ddlMaDuong" runat="server" CssClass="QH_DropDownList" Width="100%"></cc1:KeySortDropDownList></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Địa chỉ cũ</td>
																		<td class="QH_ColControl"><asp:textbox id="txtDiaChiCu" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="500"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																</table>
															</td>
															<td colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%">Điện thoại</td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtDienThoai" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="50"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Fax</td>
																		<td class="QH_ColControl"><asp:textbox id="txtFax" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="50" EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Email</td>
																		<td class="QH_ColControl"><asp:textbox id="txtEmail" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Website</td>
																		<td class="QH_ColControl"><asp:textbox id="txtWebsite" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td colSpan="4" height="5"></td>
														</tr>
														<tr>
															<td width="100%" colSpan="4"><asp:label id="Label1" runat="server" Width="100%" CssClass="QH_LabelLeftBold"><strong>Thông 
																		tin người đại diện</strong></asp:label></td>
														</tr>
														<tr>
															<td colSpan="4" height="5"></td>
														</tr>
														<tr>
															<td colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%">Họ và tên <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoTen" runat="server" Width="75%" CssClass="QH_textbox" MaxLength="100" EnableViewState="true"></asp:textbox>&nbsp;&nbsp;<asp:dropdownlist id="ddlGioiTinh" runat="server" Width="21%" CssClass="QH_DropDownList" EnableViewState="true">
																				<asp:ListItem Value="1">Nam</asp:ListItem>
																				<asp:ListItem Value="0">Nữ</asp:ListItem>
																			</asp:dropdownlist></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Dân tộc</td>
																		<td class="QH_ColControl"><asp:textbox id="txtDanToc" Width="100%" CssClass="QH_TextBox" MaxLength="100" Runat="server"></asp:textbox></td>
																	</tr>
																	<tr>
																		<TD class="QH_ColLabel">Thường trú <FONT color="#ff0000" size="4">*</FONT></TD>
																		<TD class="QH_ColControl"><asp:textbox id="txtThuongTru" Width="100%" CssClass="QH_TextBox" MaxLength="500" Runat="server"></asp:textbox></TD>
																	</tr>
																	<tr>
																		<TD class="QH_ColLabel">Chỗ ở hiện nay</TD>
																		<TD class="QH_ColControl"><asp:textbox id="txtChoOHienNay" Width="100%" CssClass="QH_TextBox" MaxLength="500" Runat="server"></asp:textbox></TD>
																	</tr>
																</table>
															</td>
															<td colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%">Ngày sinh <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtNgaySinh" Width="30%" CssClass="QH_TextBox" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgaySinh" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
																				ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Số CMND <FONT color="#ff0000" size="4">*</FONT></td>
																		<td class="QH_ColControl"><asp:textbox id="txtSoCMND" Width="30%" CssClass="QH_TextBox" MaxLength="20" Runat="server"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Ngày cấp</td>
																		<td class="QH_ColControl"><asp:textbox id="txtNgayCapCMND" Width="30%" CssClass="QH_TextBox" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayCapCMND" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
																				ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Nơi cấp</td>
																		<td class="QH_ColControl"><asp:textbox id="txtNoiCapCMND" Width="100%" CssClass="QH_TextBox" MaxLength="500" Runat="server">C&#244;ng an thành phố Cần Thơ</asp:textbox></td>
																	</tr>
																	<tr>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td colSpan="4" height="5"></td>
														</tr>
														<tr>
															<td width="100%" colSpan="4"><asp:label id="Label2" runat="server" Width="100%" CssClass="QH_LabelLeftBold"><strong>Ghi 
																		chú</strong></asp:label></td>
														</tr>
														<tr>
															<td colSpan="4" height="5"></td>
														</tr>
														<tr>
															<td colSpan="2" valign="top">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td width="30%" class="QH_ColLabel">Người ký</td>
																		<td width="70%" class="QH_ColControl"><asp:dropdownlist id="ddlMaSoLanhDao" runat="server" Width="100%" CssClass="QH_DropDownList"></asp:dropdownlist></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Ghi chú</td>
																		<td class="QH_ColControl"><asp:textbox id="txtGhiChu" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="500"
																				EnableViewState="true" TextMode="MultiLine" Rows="3"></asp:textbox></td>
																	</tr>
																</table>
															</td>
															<td colSpan="2" valign="top">
																<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td class="QH_ColLabel" width="30%">Số lần cấp đổi</td>
																		<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoLanCapDoi" runat="server" Width="30%" CssClass="QH_textright" MaxLength="3"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Số lần thay đổi</td>
																		<td class="QH_ColControl"><asp:textbox id="txtSoLanThayDoi" runat="server" Width="30%" CssClass="QH_textright" MaxLength="3"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td class="QH_ColLabel">Số lần cấp phó bản</td>
																		<td class="QH_ColControl"><asp:textbox id="txtSoLanCapPhoBan" runat="server" Width="30%" CssClass="QH_textright" MaxLength="3"
																				EnableViewState="true"></asp:textbox></td>
																	</tr>
																</table>
															</td>
														</tr>
													</TBODY>
												</table>
											</TD>
										</tr>
										<tr>
											<td colSpan="4" height="10"></td>
										</tr>
										<tr>
											<td align="center">
												<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton><asp:Label id="LableCapNhat" runat="server">&nbsp;&nbsp;</asp:Label>
												<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton><asp:Label id="LabelXoa" runat="server">&nbsp;&nbsp;</asp:Label>
												<asp:linkbutton id="btnCapDoi" runat="server" CssClass="QH_Button">Cấp đổi GCN</asp:linkbutton><asp:Label id="LabelCapDoi" runat="server">&nbsp;&nbsp;</asp:Label>
												<asp:linkbutton id="btnThayDoi" runat="server" CssClass="QH_Button">Thay đổi nội dung kinh doanh</asp:linkbutton><asp:Label id="LabelThayDoi" runat="server">&nbsp;&nbsp;</asp:Label>
												<asp:linkbutton id="btnNgung" runat="server" CssClass="QH_Button">Ngưng kinh doanh</asp:linkbutton><asp:Label id="LabelNgung" runat="server">&nbsp;&nbsp;</asp:Label>
												<asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button">Tr&#7903; v&#7873;</asp:linkbutton>&nbsp;<BR>
											</td>
										</tr>
									</TBODY>
								</table>
								<!-- Content --><INPUT id="cMsg" type="hidden" name="cMsg" runat="server"> <INPUT id="hMsg" type="hidden" name="hMsg" runat="server"><input id="KiemTra" type="hidden" value="0" name="KiemTra" runat="server">
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
					</TBODY>
				</table>
			</TD>
		</TR>
	</TBODY>
</TABLE>
<div style="DISPLAY: none">
	<asp:TextBox ID="txtGiayCNDKKDID" Runat="server" Enabled="False"></asp:TextBox>
	<asp:TextBox ID="txtGiayCNDKKDIDTruoc" Runat="server" Enabled="False"></asp:TextBox>
	<asp:TextBox ID="txtMaSoNguoiSuDung" Runat="server" Enabled="False"></asp:TextBox>
</div>
