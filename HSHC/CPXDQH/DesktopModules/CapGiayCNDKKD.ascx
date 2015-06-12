<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapGiayCNDKKD.ascx.vb" Inherits="CPXD.CapGiayCNDKKD" %>
<%@ Import Namespace="PortalQH" %>
<script language="javascript">
function CallNganhNghe(strURL,Parent)
{		
		strURL = GetParams(strURL);
		showWindow1(strURL,Parent);		
}
function showWindow1(obj1,Parent)
{
		//t = screen.height - 30;
		t = 300;
		w = screen.width - 10;
		window.open(obj1,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="center">
			<TABLE class="QH_Table" id="Table7" cellSpacing="0" cellPadding="0" width="90%" border="0">
				<TR>
					<TD>
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<asp:label id="Label3" Runat="server" CssClass="QH_Label_Title" Width="100%">Thông tin giấy CN ĐKKD</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="50%">
												<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_ColLabel" width="30%" height="9">
															<asp:LinkButton CssClass="QH_ColLabel" id="btnDanhSach" runat="server" ToolTip="Chọn hồ sơ cấp phép">Số biên nhận</asp:LinkButton>
															<asp:Label id="lblSoBN" CssClass="QH_ColLabel" runat="server">Số biên nhận</asp:Label>
														</TD>
														<TD height="10">
															<asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="45%" ReadOnly="True" runat="server"></asp:textbox>
														</TD>
													</TR>
													<TR>
														<TD Class="QH_ColLabel" height="8"><asp:LinkButton CssClass="QH_ColLabel" id="btnDanhSachGP" runat="server" ToolTip="Lấy thông tin giấy phép">Số giấy phép cũ</asp:LinkButton>
															<asp:Label CssClass="QH_ColLabel" id="lblSoGP" runat="server">Số giấy phép cũ</asp:Label></TD>
														<TD height="8">
															<asp:textbox id="txtSoGiayPhepTruoc" CssClass="QH_textbox" Width="70%" runat="server" EnableViewState="true"
																ReadOnly="True"></asp:textbox>
														</TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Số giấy CN ĐKKD</TD>
														<TD>
															<asp:textbox id="txtSoGiayPhep" CssClass="QH_textbox" Width="70%" runat="server" EnableViewState="true"
																ReadOnly="True"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Ngày cấp</TD>
														<TD>
															<asp:textbox id="txtNgayCap" CssClass="QH_textbox" Width="45%" runat="server" EnableViewState="true"></asp:textbox>&nbsp;
															<asp:image id="imgNgayCap" CssClass="QH_Button" runat="server" ImageUrl="~\images\calendar.gif"
																ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="top">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_ColLabel" width="30%">Tên bảng hiệu</TD>
														<TD>
															<asp:textbox id="txtBangHieu" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																MaxLength="100"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" height="19">Hình thức KD</TD>
														<TD height="19">
															<asp:dropdownlist id="ddlMaHinhThucKinhDoanh" CssClass="QH_DropDownList" Width="90%" runat="server"
																EnableViewState="true"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Phương thức KD</TD>
														<TD>
															<asp:dropdownlist id="ddlMaPhuongThucKinhDoanh" CssClass="QH_DropDownList" Width="90%" runat="server"
																EnableViewState="true"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Mặt hàng KD</TD>
														<TD>
															<asp:textbox id="txtMatHangKinhDoanh" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" width="50%">
									<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<asp:label id="Label2" Runat="server" CssClass="QH_LabelLeftBold" Width="100%">Nguồn vốn</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_ColLabel" width="30%">Vốn cố định</TD>
														<TD>
															<asp:textbox id="txtVonCoDinh" CssClass="QH_TextRight" Width="45%" runat="server" EnableViewState="true"
																MaxLength="14"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Vốn lưu động</TD>
														<TD>
															<asp:textbox id="txtVonLuuDong" CssClass="QH_TextRight" Width="45%" runat="server" EnableViewState="true"
																MaxLength="14"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Vốn kinh doanh</TD>
														<TD>
															<asp:textbox id="txtVonKinhDoanh" CssClass="QH_TextRight" Width="45%" runat="server" EnableViewState="true"
																MaxLength="15"></asp:textbox>
															<asp:textbox id="txtTienBangChu" Width="0px" Runat="server"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top" colSpan="1" rowSpan="1">
									<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<asp:label id="Label6" Runat="server" CssClass="QH_LabelLeftBold" Width="100%">Người ký</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_ColLabel" width="30%">Người ký</TD>
														<TD>
															<asp:dropdownlist id="ddlMaSoLanhDao" CssClass="QH_DropDownList" Width="90%" runat="server"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" vAlign="top" width="30%">Ghi chú</TD>
														<TD>
															<asp:textbox id="txtGhiChu" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																TextMode="MultiLine" Rows="3" MaxLength="500"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="15%"><asp:LinkButton cssclass="QH_ColLabel" id="blkNganhKinhDoanh" runat="server">Ngành kinh doanh</asp:LinkButton></TD>
								<TD>
									<asp:TextBox id="txtTenNganh" Width="37%" CssClass="QH_Textbox" runat="server" ReadOnly="True"
										Rows="2" TextMode="MultiLine"></asp:TextBox>
									<asp:TextBox id="txtMaNganh" Width="0px" runat="server"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table22" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<TABLE id="Table23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="50%">
															<asp:Label id="Label1" CssClass="QH_LabelLeftBold" Width="100%" runat="server">Người đại diện</asp:Label></TD>
														<TD>
															<asp:Label id="Label4" CssClass="QH_LabelLeftBold" Width="100%" runat="server">Địa chỉ kinh doanh</asp:Label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" colSpan="1" rowSpan="1">
												<TABLE id="Table24" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="50%">
															<TABLE id="Table25" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="30%">Họ và tên</TD>
																	<TD>
																		<asp:textbox id="txtHoTen" Width="70%" CssClass="QH_textbox" runat="server" EnableViewState="true"
																			MaxLength="50"></asp:textbox>
																		<asp:DropDownList id="ddlGioiTinh" CssClass="QH_DropDownList" runat="server">
																			<asp:ListItem Selected="True"></asp:ListItem>
																			<asp:ListItem Value="1">Nam</asp:ListItem>
																			<asp:ListItem Value="0">Nữ</asp:ListItem>
																		</asp:DropDownList></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Số CMND</TD>
																	<TD>
																		<asp:textbox id="txtSoCMND" Width="45%" CssClass="QH_textbox" runat="server" EnableViewState="true"
																			MaxLength="9"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Ngày cấp</TD>
																	<TD>
																		<asp:textbox id="txtNgayCapCMND" Width="45%" CssClass="QH_textbox" runat="server" EnableViewState="true"
																			MaxLength="20"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Nơi cấp</TD>
																	<TD>
																		<asp:textbox id="txtNoiCapCMND" Width="70%" CssClass="QH_textbox" runat="server" EnableViewState="true"
																			MaxLength="50"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Ngày sinh</TD>
																	<TD>
																		<asp:textbox id="txtNgaySinh" CssClass="QH_textbox" Width="45%" runat="server" EnableViewState="true"
																			MaxLength="20"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Dân tộc</TD>
																	<TD>
																		<asp:textbox id="txtDanToc" CssClass="QH_textbox" Width="45%" runat="server" EnableViewState="true"
																			MaxLength="20"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Thường trú</TD>
																	<TD>
																		<asp:textbox id="txtDiaChiThuongTru" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																			MaxLength="500" Rows="2" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Chỗ ở hiện nay</TD>
																	<TD>
																		<asp:textbox id="txtChoOHienNay" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																			MaxLength="500" Rows="2" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
														<TD vAlign="top">
															<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="30%">Số nhà</TD>
																	<TD>
																		<asp:textbox id="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="90%" MaxLength="50"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Đường</TD>
																	<TD>
																		<asp:dropdownlist id="ddlMaDuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Phường</TD>
																	<TD>
																		<asp:dropdownlist id="ddlMaPhuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Địa chỉ cũ</TD>
																	<TD>
																		<asp:textbox id="txtDiaChiCu" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																			MaxLength="500" Rows="2" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Điện thoại</TD>
																	<TD>
																		<asp:textbox id="txtPhone" CssClass="QH_textbox" Width="45%" runat="server" EnableViewState="true"
																			MaxLength="20"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Fax</TD>
																	<TD>
																		<asp:textbox id="txtFax" CssClass="QH_textbox" Width="45%" runat="server" EnableViewState="true"
																			MaxLength="20"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Email</TD>
																	<TD>
																		<asp:textbox id="txtEmail" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																			MaxLength="50"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Website</TD>
																	<TD>
																		<asp:textbox id="txtWebsite" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
																			MaxLength="50"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				<TR>
					<TD height="25">
						<asp:TextBox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:TextBox>
						<asp:TextBox id="txtMaLinhVuc" Width="0px" runat="server"></asp:TextBox>
						<asp:TextBox id="txtTabCode" Width="0px" runat="server"></asp:TextBox>
						<asp:TextBox id="txtMaNguoiTacNghiep" Width="0px" runat="server"></asp:TextBox>
						<asp:TextBox id="txtReload" Width="0px" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:imagebutton id="btnCapNhat" runat="server" ImageUrl="../../images/btn_CapNhat.gif"></asp:imagebutton>
						<asp:imagebutton id="btnXoa" runat="server" ImageUrl="../../images/btn_Xoa.gif"></asp:imagebutton>
						<asp:image id="btnIn" runat="server" ImageUrl="../../images/btn_InGiayPhep.gif"></asp:image>
						<asp:image id="btnInThongBao" runat="server" ImageUrl="../../images/btn_InThongBao.gif"></asp:image>
						<asp:imagebutton id="btnBoQua" runat="server" ImageUrl="../../images/btn_TroVe.gif"></asp:imagebutton></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
</TD></TR></TABLE>
