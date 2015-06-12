<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Register TagPrefix="uc1" TagName="ChuDauTuList" Src="ChuDauTuList.ascx" %>
<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapMoiGPXD.ascx.vb" Inherits="CPXD.CapMoiGPXD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="Microsoft.Web.UI.WebControls" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="title" runat="server" CssClass="QH_Label_Title" Width="100%">Câp mới giấy phép xây dựng</asp:label></td>
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
					<td align="center" width="*">
						<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td>
									<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<td class="QH_ColLabel" width="15%"><asp:label id="lblSoBN" runat="server" CssClass="QH_ColLabel">Số biên nhận</asp:label><font color="red">*</font></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" runat="server" CssClass="QH_Textbox" Width="60%" ReadOnly="True"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%">Ngày nhận</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtNgayNhan" runat="server" CssClass="QH_Textbox" Width="40%"></asp:textbox><asp:hyperlink id="cmdNgayNhan" CssClass="CommandButton" Visible="False" Runat="server">
													<asp:Image runat="server" BorderWidth="0px" ID="btnNgayNhan" ImageUrl="~/Images/calendar.gif"
														CssClass="QH_imageButton"></asp:Image>
												</asp:hyperlink></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="15%"><asp:linkbutton id="btnDanhSachGP" runat="server" CssClass="QH_ColLabel" Visible="False" ToolTip="L?y thông tin gi?y phép">Sô´ giấy phép cũ</asp:linkbutton><asp:label id="lblSao" Runat="server"><font color="Red">*</font></asp:label><asp:label id="lblSoGP" runat="server" CssClass="QH_ColLabel">Sô´ giấy phép cũ</asp:label></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhepTruoc" runat="server" CssClass="QH_textbox" Width="60%" ReadOnly="True"
													EnableViewState="true"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%">Ngày cấp phép cu</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCapCu" runat="server" CssClass="QH_Textbox" Width="40%" ReadOnly="True"></asp:textbox><asp:hyperlink id="cmdNgayCapCu" CssClass="CommandButton" Visible="False" Runat="server">
													<asp:Image runat="server" BorderWidth="0px" ID="btnNgayCapPhepCu" ImageUrl="~/Images/calendar.gif"
														CssClass="QH_imageButton"></asp:Image>
												</asp:hyperlink></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Số giấy phép</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" runat="server" CssClass="QH_Textbox" Width="60%"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Ngày cấp phép</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCapPhep" runat="server" CssClass="QH_Textbox" Width="40%"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayCapPhep" CssClass="CommandButton" Runat="server">
													<asp:image id="btnNgayCapPhep" BorderWidth="0" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Tên chủ đầu tư</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" runat="server" CssClass="QH_Textbox" Width="60%"></asp:textbox>Giới 
												tính
												<asp:dropdownlist id="ddlGioiTinh" runat="server" CssClass="QH_Dropdownlist" Width="15%"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Thường trú</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTru" runat="server" CssClass="QH_Textbox" Width="80%"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" width="15%"></td>
											<td class="QH_ColControl"></td>
										</tr>
									</table>
									<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<td width="50%">
												<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<tr>
														<td width="100%" colSpan="2"><asp:label id="Label4" runat="server" CssClass="QH_LabelLeftBold">Ðịa điểm xây dựng</asp:label></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="15%">Số nhà</td>
														<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" runat="server" CssClass="QH_Textbox" Width="40%"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="15%">Ðường</td>
														<td class="QH_ColControl" width="35%"><cc1:combobox id="ddlMaDuong" runat="server" CssClass="QH_DropDownList" autoValidate="true" null="false"
																listsize="190" SIZE="33"></cc1:combobox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="15%">Phường</td>
														<td class="QH_ColControl" width="35%"><cc1:combobox id="ddlMaPhuong" runat="server" CssClass="QH_DropDownList" autoValidate="true" null="false"
																listsize="190" SIZE="33"></cc1:combobox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="15%">Trên lô đất</td>
														<td class="QH_ColControl" width="35%"><asp:textbox id="txtLoDat" runat="server" CssClass="QH_Textbox" Width="80%" TextMode="MultiLine"></asp:textbox>&nbsp;
															<asp:linkbutton id="LinkLoDat" runat="server">Chọn...</asp:linkbutton></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="15%">Ðịa chỉ cũ</td>
														<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiachicu" runat="server" CssClass="QH_Textbox" Width="80%"></asp:textbox></td>
													</tr>
												</table>
											</td>
											<td width="50%">
												<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<tr>
														<td width="100%" colSpan="2"><asp:label id="Label3" runat="server" CssClass="QH_LabelLeftBold">Nội dung xây dựng</asp:label></td>
													</tr>
													<TR>
														<td class="QH_ColLabel" width="15%">Phân loại xây dựng</td>
														<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhanLoaiXayDung" runat="server" CssClass="QH_Dropdownlist" Width="80%"></asp:dropdownlist></td>
													<TR>
														<TD class="QH_ColLabel" width="15%">Loại công trình</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtCongTrinhXayDung" runat="server" CssClass="QH_Textbox" Width="0px"></asp:textbox><asp:dropdownlist id="ddlMaCapNha" runat="server" CssClass="QH_Dropdownlist" Width="80%"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="15%">Ðơn vị thiết kế</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDonViThietKe" runat="server" CssClass="QH_Textbox" Width="80%">Công ty</asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="15%">Thời gian hoàn thành</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtThoiHanHoanThanh" runat="server" CssClass="QH_Textbox">____</asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="15%">Giấy về QSH Nhà,SD Đất</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtGiaySuDungDat" runat="server" CssClass="QH_Textbox" Width="80%" TextMode="MultiLine"></asp:textbox>&nbsp;
															<asp:linkbutton id="LinkGiaySuDungDat" runat="server">Chọn...</asp:linkbutton></TD>
													</TR>
													<tr>
													</tr>
												</table>
											</td>
										</TR>
									</table>
								</td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td>
									<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<tr vAlign="top">
											<td class="QH_ColLabel" width="15%">Ghi chú</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtGhiChu" runat="server" CssClass="QH_Textbox" Width="80%"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%">Người duyệt</td>
											<td class="QH_ColControl" vAlign="middle" width="35%"><asp:dropdownlist id="ddlMaSoLanhDao" runat="server" CssClass="QH_Dropdownlist" Width="80%"></asp:dropdownlist></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp;</td>
							</tr>
							<tr>
								<td height="42">
									<table cellSpacing="2" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<td align="center"><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnKiemTraHS" runat="server" CssClass="QH_Button">Kiểm tra HS</asp:linkbutton>&nbsp;&nbsp;&nbsp;
												<asp:linkbutton id="btnYeuCauBoSung" runat="server" CssClass="QH_Button">Bổ sung HS</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnXacMinhThucDia" runat="server" CssClass="QH_Button">Thẩm định</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnHoSoKhong" runat="server" CssClass="QH_Button">Không giải quyết</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnBaoCaoDeXuat" runat="server" CssClass="QH_Button">Ðề xuất</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In giấy phép</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button" Visible="False">Xóa</asp:linkbutton>&nbsp;&nbsp;&nbsp;
												<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtReload" runat="server" Width="0px"></asp:textbox><asp:label id="lblKetQuaVPHC" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></td>
							</tr>
							<TR>
								<TD><asp:label id="lblKetQuaDiaChi" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></TD>
							</TR>
						</table>
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
