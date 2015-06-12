<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NgungKinhDoanhDauKi.ascx.vb" Inherits="CPKTQH.NgungKinhDoanhDauKi" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
	var txtNgayKetThuc =document.all("<%=txtNgayKetThuc.clientID%>");
	var chkNgayKetThuc = document.all("chkNgayKetThuc");
	
	if (!CheckNull())
		return false;
		
	if ((chkNgayKetThuc.checked)&&(txtNgayKetThuc.value==""))
	{
		alert("Ban chua dien du thong tin!");
		txtNgayKetThuc.focus();
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" CssClass="QH_Label_Title" runat="server" Width="100%">Thông tin Ngưng kinh doanh</asp:label></td>
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
															<TD class="QH_ColLabel" width="20%">Số GCN ĐKKD:</TD>
															<TD class="QH_ColControl" width="30%"><asp:label id="lblSoGiayPhep" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="20%">Mặt hàng KD:</TD>
															<TD class="QH_ColControl" width="270" colSpan="4"><asp:label id="lblMatHangKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="20%">Ngày cấp CN ĐKKD:</TD>
															<TD class="QH_ColControl" width="30%"><asp:label id="lblNgayCap" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel" width="20%">Tên bảng hiệu:</TD>
															<TD class="QH_ColControl" width="30%" colSpan="4"><asp:label id="lblBangHieu" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ KD:</TD>
															<TD class="QH_ColControl" width="270"><asp:label id="lblDiaChiKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
															<TD class="QH_ColLabel">Tổng vốn KD:</TD>
															<TD class="QH_ColControl" width="270" colSpan="4"><asp:label id="lblVonKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label>&nbsp;<asp:label id="lblLabelDonViTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
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
															<TD class="QH_ColControl" width="*"><asp:label id="lblChuoiGioiTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ thường trú:</TD>
															<TD class="QH_ColControl" width="150"><asp:label id="lblThuongTru" CssClass="QH_LabelLeft" Width="100%" Runat="server"></asp:label></TD>
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
												<TD class="QH_ColControl" width="*%" colSpan="3"><asp:dropdownlist id="ddlMaLyDo" CssClass="QH_DropDownList" Width="100%" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">Ngày bắt đầu ngưng<font color="#ff0000">*</font></TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayBatDau" CssClass="QH_TextBox" Width="120px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayNgungKD" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
												<TD class="QH_ColLabel" width="20%"><INPUT id="chkNgayKetThuc" onclick="chkNgayKetThuc_clicked(this)" type="checkbox">Ngày&nbsp;kết 
													thúc&nbsp;ngưng<FONT color="#ff0000">*</FONT></TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayKetThuc" CssClass="QH_TextBox" Width="120px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayKetThuc" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">Ngày hoạt động lại</TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayHoatDongLai" CssClass="QH_TextBox" Width="120px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayHoatDongLai" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
												<TD></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Ghi chú</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtGhiChu" CssClass="QH_Textbox" Width="100%" MaxLength="1000" Runat="server"
														Rows="3" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD height="5"></TD>
								</TR>
								<TR>
									<TD align="center"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton><asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton><asp:linkbutton id="btnTrove" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;</TD>
					</td>
				</tr>
			</table>
		</TD>
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
<div	style="DISPLAY: none" ><asp:textbox id="txtNgungKinhDoanhID" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtSoGiayPhep" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtGiayCNDKKDID" Runat="server" Enabled="False"></asp:textbox></div>
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
