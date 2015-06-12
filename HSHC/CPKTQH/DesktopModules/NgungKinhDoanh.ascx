<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NgungKinhDoanh.ascx.vb" Inherits="CPKTQH.NgungKinhDoanh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function chkNgayKetThuc_clicked(chk)
{
	var txtNgayKetThuc=document.all("<%=txtNgayKetThuc.clientID%>");
	var imgNgayKetThuc=document.all("<%=imgNgayKetThuc.clientID%>");
	
	if (chk.checked)
	{
		txtNgayKetThuc.disabled=false;
		imgNgayKetThuc.style.visibility="visible";
	}
	else
	{
		txtNgayKetThuc.disabled=true;
		imgNgayKetThuc.style.visibility="hidden";
	}
}
function btnCapNhat_clicked()
{
	var txtSoGiayPhep = document.all("<%=txtSoGiayPhep.clientID%>"); 
	var ddlMaLyDo = document.all("<%=ddlMaLyDo.clientID%>");
	var txtNgayBatDau =document.all("<%=txtNgayBatDau.clientID%>");

	var chkNgayKetThuc = document.all("chkNgayKetThuc");
	
	if (txtSoGiayPhep.value=="")
	{
		alert("Chua nhap So giay phep");
		return false;
	}
	if (ddlMaLyDo.value=="")
	{
		alert("Chua nhap Ly do");
		return false;
	}
	if (txtNgayBatDau.value=="")
	{
		alert("Chua nhap Ngay bat dau");
		return false;
	}
	if ((chkNgayKetThuc.checked)&&(txtNgayKetThuc.value==""))
	{
		alert("Chua nhap Ngay ket thuc");
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" Width="100%" runat="server" CssClass="QH_Label_Title">Thông tin Ngưng kinh doanh</asp:label></td>
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
									<TD align="center" width="100%">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="90%" border="0">
											<TR>
												<TD class="QH_ColLabel" width="20%"><asp:label id="lblDanhSach" runat="server">Số biên nhận</asp:label></TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtSoBienNhan" Width="80%" runat="server" CssClass="QH_textbox" EnableViewState="true"
														ReadOnly="True"></asp:textbox></TD>
												<TD class="QH_ColLabel" width="20%"><asp:linkbutton id="btnDanhSachGP" runat="server">Số giấy CN ÐKKD</asp:linkbutton><asp:label id="lblDanhSachGP" runat="server">Số giấy CNDKKD</asp:label></TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtSoGiayPhep" Width="80%" CssClass="QH_TextBox" ReadOnly="True" Runat="server"
														AutoPostBack="True" MaxLength="50"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
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
															<TD class="QH_ColLabel" width="20%">Ngày cấp CN ĐKKD:</TD>
															<TD class="QH_ColControl" width="30%"><asp:label id="lblNgayCap" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="20%">Mặt hàng KD:</TD>
															<TD class="QH_ColControl" width="270" colSpan="4"><asp:label id="lblMatHangKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="20%">Ngày hết hạn:</TD>
															<TD class="QH_ColControl" width="30%"><asp:label id="lblNgayHetHan" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="20%">Tên bảng hiệu:</TD>
															<TD class="QH_ColControl" width="30%" colSpan="4"><asp:label id="lblBangHieu" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ KD:</TD>
															<TD class="QH_ColControl" width="270"><asp:label id="lblDiaChiKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Tổng vốn KD:</TD>
															<TD class="QH_ColControl" width="270" colSpan="4"><asp:label id="lblVonKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label>&nbsp;
																<asp:label id="Label1" CssClass="QH_LabelLeft" Runat="server">&nbsp;đồng</asp:label></TD>
														</TR>
														<TR>
															<TD colSpan="11" height="4"></TD>
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
															<TD class="QH_ColControl" width="*"><asp:label id="lblTenGioiTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ thường trú:</TD>
															<TD class="QH_ColControl" width="150"><asp:label id="lblDiaChiThuongTru" Width="100%" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Số CMND:</TD>
															<TD class="QH_ColControl" colSpan="4"><asp:label id="lblSoCMND" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
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
											<TR>
												<TD class="QH_ColLabel" width="20%">Lý do ngưng kinh doanh<font color="#ff0000">*</font></TD>
												<TD class="QH_ColControl" width="*%" colSpan="3"><asp:dropdownlist id="ddlMaLyDo" Width="100%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">Ngày bắt đầu ngưng<font color="#ff0000">*</font></TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayBatDau" Width="120px" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgNgayNgungKD" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
												<TD class="QH_ColLabel" width="20%"><INPUT id="chkNgayKetThuc" onclick="chkNgayKetThuc_clicked(this)" type="checkbox">Ngày&nbsp;kết 
													thúc&nbsp;ngưng<FONT color="#ff0000">*</FONT></TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayKetThuc" Width="120px" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgNgayKetThuc" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Ghi chú</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtGhiChu" Width="100%" CssClass="QH_Textbox" Runat="server" MaxLength="1000"
														TextMode="MultiLine" Rows="3"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD height="5"></TD>
								</TR>
								<TR>
									<TD align="center"><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton><asp:linkbutton id="btnDeXuat" runat="server" CssClass="QH_Button">Đề xuất</asp:linkbutton><asp:linkbutton id="btnYCBS" runat="server" CssClass="QH_Button">Bổ sung hồ sơ</asp:linkbutton><asp:linkbutton id="btnHoSoKhong" runat="server" CssClass="QH_Button"> Không giải quyết</asp:linkbutton><asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton><asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton><asp:linkbutton id="btnTrove" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;</TD>
					</td>
				</tr>
			</table>
			<asp:textbox id="txtReload" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtGiayCNDKKDID" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtNgungKinhDoanhID" Width="0px" runat="server"></asp:textbox></TD>
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
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
<script language="javascript">
	var txtNgayKetThuc=document.all("<%=txtNgayKetThuc.clientID%>");
	var imgNgayKetThuc=document.all("<%=imgNgayKetThuc.clientID%>");
	var chkNgayKetThuc = document.all("chkNgayKetThuc");
	
	if (txtNgayKetThuc.value=="")
	{
		txtNgayKetThuc.disabled=true;
		imgNgayKetThuc.style.visibility="hidden";
		chkNgayKetThuc.checked =false
	}
	else
	{
		txtNgayKetThuc.disabled=false;
		imgNgayKetThuc.style.visibility="visible";
		chkNgayKetThuc.checked =true
	}

</script>
