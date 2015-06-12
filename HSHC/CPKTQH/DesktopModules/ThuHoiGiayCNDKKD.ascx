<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThuHoiGiayCNDKKD.ascx.vb" Inherits="CPKTQH.ThuHoiGiayCNDKKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" CssClass="QH_Label_Title" runat="server" Width="100%">Thu h&#7891;i gi&#7845;y CN &#272;KKD</asp:label></td>
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
							<TBODY>
								<TR>
									<TD height="5"></TD>
								</TR>
								<TR>
									<TD align="center"></TD>
								</TR>
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="90%" border="0">
											<TR>
												<TD width="100%">
													<TABLE class="QH_LoaiHS" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD colSpan="4"><asp:label id="Label6" CssClass="QH_LabelLeftBold" Runat="server"><strong>Thông 
																		tin chung</strong></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="20%">Số GCN ĐKKD</TD>
															<TD class="QH_ColControl" width="30%"><asp:label id="lblSoGiayPhep" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="20%">Lĩnh vực cấp phép</TD>
															<TD class="QH_ColControl" width="30%" colSpan="4"><asp:label id="lblTenLinhVucCapPhep" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Ngày cấp</TD>
															<TD class="QH_ColControl"><asp:label id="lblNgayCap" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Mặt hàng kinh doanh</TD>
															<TD class="QH_ColControl" width="270" colSpan="4"><asp:label id="lblMatHangKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ kinh doanh</TD>
															<TD class="QH_ColControl"><asp:label id="lblDiaChiKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Vốn kinh doanh</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblVonKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label>&nbsp;
																<asp:label id="lblLabelDonViTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Bảng hiệu</TD>
															<TD class="QH_ColControl" width="150"><asp:label id="lblBangHieu" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Ngày hết hạn giấy phép</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblNgayHetHanGiayPhep" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColControl" colSpan="11"><asp:label id="Label7" CssClass="QH_LabelLeftBold" Runat="server"><strong>Thông 
																		tin cá nhân</strong></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Họ tên:</TD>
															<TD class="QH_ColControl"><asp:label id="lblHoTen" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Ngày sinh:</TD>
															<TD class="QH_ColControl" width="15%"><asp:label id="lblNgaySinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="10%">Giới tính:</TD>
															<TD class="QH_ColControl" width="*"><asp:label id="lblChuoiGioiTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ thường trú:</TD>
															<TD class="QH_ColControl" width="150"><asp:label id="lblThuongTru" CssClass="QH_LabelLeft" Width="100%" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Số CMND:</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblSoCMND" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<tr>
															<td colSpan="4">
																<div style="DISPLAY: none">
																	<asp:textbox id="txtSoGiayPhep" Runat="server" Enabled="False"></asp:textbox>
																	<asp:textbox id="txtGiayCNDKKDID" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtThuHoiCNDKKDID" Runat="server" Enabled="False"></asp:textbox></div>
															</td>
														</tr>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="QH_Table" id="Table4" cellSpacing="0" cellPadding="0" width="90%" border="0">
											<tr>
												<TD class="QH_ColLabel" width="20%" height="20">Lần thu hồi</TD>
												<TD class="QH_ColControl" colSpan="3" height="20"><asp:label id="lblLanThuHoi" CssClass="QH_LabelLeft" Runat="server"></asp:label>&nbsp;/<asp:label id="lblTongSoLanThuHoi" CssClass="QH_LabelLeft" Runat="server"></asp:label>&nbsp;<asp:label id="Label1" CssClass="QH_LabelLeft" Runat="server">lần thu hồi</asp:label></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Lý do thu hồi<FONT color="#ff0000" size="2">*</FONT></TD>
												<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaLyDo" CssClass="QH_DropDownList" runat="server" Width="80%" EnableViewState="true"></asp:dropdownlist></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Nội dung<FONT color="#ff0000" size="2">*</FONT></TD>
												<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtNoiDung" CssClass="QH_textbox" runat="server" Width="80%" EnableViewState="true"
														MaxLength="500" Rows="3" TextMode="MultiLine"></asp:textbox></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel" width="20%">Người duyệt<FONT color="#ff0000" size="2">*</FONT></TD>
												<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaSoLanhDao" CssClass="QH_DropDownList" runat="server" Width="100%" EnableViewState="true"></asp:dropdownlist></TD>
												<TD class="QH_ColLabel" width="12%">Ngày duyệt<FONT color="#ff0000" size="2">*</FONT></TD>
												<TD class="QH_ColControl" width="*"><asp:textbox id="txtNgayDuyet" CssClass="QH_textbox" runat="server" Width="50%" EnableViewState="true"></asp:textbox>&nbsp;<asp:image id="imgNgayDuyet" CssClass="QH_Button" runat="server" ImageUrl="~\images\calendar.gif"
														ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></TD>
											</tr>
											<TR>
												<TD class="QH_ColLabel">Người thu hồi<FONT color="#ff0000" size="2">*</FONT></TD>
												<TD class="QH_ColControl"><asp:dropdownlist id="ddlNguoiThuHoi" CssClass="QH_DropDownList" runat="server" Width="100%" EnableViewState="true"></asp:dropdownlist></TD>
												<TD class="QH_ColLabel">Ngày thu<FONT color="#ff0000" size="2"> </FONT>hồi<FONT color="#ff0000" size="2">*</FONT></TD>
												<TD class="QH_ColControl"><asp:textbox id="txtNgayThuHoi" CssClass="QH_textbox" runat="server" Width="50%" EnableViewState="true"></asp:textbox>&nbsp;<asp:image id="imgNgayThuHoi" CssClass="QH_Button" runat="server" ImageUrl="~\images\calendar.gif"
														ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></TD>
											</TR>
											<tr>
												<td colSpan="4" height="10"></td>
											</tr>
											<tr>
												<td class="QH_ColLabel"></td>
												<td class="QH_ColControl" colSpan="3"><asp:checkbox id="chkTraGiayPhep" CssClass="QH_LabelLeft" runat="server" Text="Trả lại GCN ĐKKD"></asp:checkbox></td>
											</tr>
										</TABLE>
									</TD>
								</TR>
								<tr>
									<td align="center">
										<div id="divTraGiayPhep">
											<TABLE class="QH_Table" id="tblTraGiayPhep" cellSpacing="0" cellPadding="0" width="90%"
												border="0">
												<TR>
													<TD class="QH_ColLabel" width="20%">Người trả<FONT color="#ff0000" size="2">*</FONT></TD>
													<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlNguoiTra" CssClass="QH_DropDownList" runat="server" Width="100%" EnableViewState="true"></asp:dropdownlist></TD>
													<TD class="QH_ColLabel" width="12%">Ngày trả<FONT color="#ff0000" size="2">*</FONT></TD>
													<TD class="QH_ColControl" width="*"><asp:textbox id="txtNgayTraGiayPhep" CssClass="QH_textbox" runat="server" Width="50%" EnableViewState="true"></asp:textbox>&nbsp;<asp:image id="imgNgayTra" CssClass="QH_Button" runat="server" ImageUrl="~\images\calendar.gif"
															ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></TD>
												</TR>
												<TR>
													<TD class="QH_ColLabel">Ghi chú</TD>
													<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtGhiChu" CssClass="QH_textbox" runat="server" Width="80%" EnableViewState="true"
															MaxLength="500" Rows="2" TextMode="MultiLine"></asp:textbox></TD>
												</TR>
											</TABLE>
										</div>
									</td>
								</tr>
								<TR>
									<TD height="5"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:linkbutton id="btnThemMoi" CssClass="QH_Button" runat="server">Thêm mới</asp:linkbutton>
										<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">C&#7853;p nh&#7853;t</asp:linkbutton>
										<asp:linkbutton id="btnInTTT" CssClass="QH_Button" runat="server">In thông báo</asp:linkbutton>
										<asp:linkbutton id="btnInQD" CssClass="QH_Button" runat="server">In quyết định</asp:linkbutton>
										<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>
										<asp:linkbutton id="btnTrove" CssClass="QH_Button" runat="server">Tr&#7903; v&#7873;</asp:linkbutton></TD>
					</td>
				</tr>
			</table>
		</TD>
		<TD class="QH_Khung_Right" width="16">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="*">
					<TD></TD>
				</TR>
				<TR height="141">
					<TD class="QH_Khung_Right1"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
<script language="javascript">
function AlterDiv()
{
	var obj = document.forms[0].all("<%=Me.chkTraGiayPhep.ClientID%>");
	if (obj.checked)
		divTraGiayPhep.style.display="";
	else
		divTraGiayPhep.style.display="none"
}
function CheckCapNhat()
{
	if (!CheckNull())
		return false;
		
	var obj = document.forms[0].all("<%=Me.chkTraGiayPhep.ClientID%>");
	if (obj.checked)
	{
		//kiểm tra có nhập đầy đủ thông tin trả không
		var objNguoiTra = document.forms[0].all("<%=Me.ddlNguoiTra.ClientID%>");
		var objNgayTra = document.forms[0].all("<%=Me.txtNgayTraGiayPhep.ClientID%>");
		
		if (objNguoiTra.value == '')
		{
			alert('Ban chua dien du thong tin!');
			objNguoiTra.focus();
			return false;
		}
		if (objNgayTra.value == '')
		{
			alert('Ban chua dien du thong tin!');
			objNgayTra.focus();
			return false;
		}
	}
	return true;
}
</script>
