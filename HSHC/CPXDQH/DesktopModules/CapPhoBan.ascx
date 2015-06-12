<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapPhoBan.ascx.vb" Inherits="CPXD.CapPhoBan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<P>
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD align="center">
				<TABLE class="QH_Table" id="Table3" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<TR>
						<TD>
							<asp:Label id="lblTitle" Width="100%" runat="server" CssClass="QH_Label_Title">Thông tin giấy phó bản ĐKKD</asp:Label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="QH_ColLabel" width="20%"><asp:LinkButton cssclass="QH_ColLabel" id="btnDanhSach" runat="server" ToolTip="Chọn hồ sơ cấp phép">Số biên nhận</asp:LinkButton>
													<asp:Label id="lblSoBN" CssClass="QH_ColLabel" runat="server">Số biên nhận</asp:Label>
												</TD>
												<TD width="30%">
													<asp:textbox id="txtSoBienNhan" Width="70%" runat="server" CssClass="QH_textbox" ReadOnly="True"></asp:textbox>
												</TD>
												<TD class="QH_ColLabel" width="15%">Họ tên</TD>
												<TD>
													<asp:textbox id="txtHoTen" Width="70%" runat="server" CssClass="QH_textbox" ReadOnly="True" EnableViewState="true"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%"><asp:LinkButton cssclass="QH_ColLabel" id="btnDanhSachGP" runat="server" ToolTip="Lấy thông tin giấp phép">Số giấy phép</asp:LinkButton>
													<asp:Label cssclass="QH_ColLabel" id="lblSoGP" runat="server">Số giấy phép</asp:Label></TD>
												<TD width="30%" colSpan="1" rowSpan="1">
													<asp:textbox id="txtSoGiayPhep" Width="70%" runat="server" CssClass="QH_textbox" ReadOnly="True"
														EnableViewState="true"></asp:textbox>
												</TD>
												<TD class="QH_ColLabel" width="15%" colSpan="1" rowSpan="1">Ngày sinh</TD>
												<TD>
													<asp:textbox id="txtNgaySinh" Width="70%" runat="server" CssClass="QH_textbox" ReadOnly="True"
														EnableViewState="true"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">Ngày cấp</TD>
												<TD width="30%">
													<asp:textbox id="txtNgayCap" Width="70%" runat="server" CssClass="QH_textbox" ReadOnly="True"
														EnableViewState="true"></asp:textbox></TD>
												<TD class="QH_ColLabel" width="15%">Số CMND</TD>
												<TD>
													<asp:textbox id="txtSoCMND" Width="70%" runat="server" CssClass="QH_textbox" ReadOnly="True"
														EnableViewState="true"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">
													Bảng hiệu</TD>
												<TD width="30%">
													<asp:textbox id="txtBangHieu" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
														EnableViewState="true" TextMode="MultiLine"></asp:textbox></TD>
												<TD class="QH_ColLabel" width="15%">Địa chỉ kinh doanh</TD>
												<TD>
													<asp:textbox id="txtDiaChiKinhDoanh" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
														EnableViewState="true" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">Mặt hàng kinh doanh</TD>
												<TD width="30%">
													<asp:textbox id="txtMatHangKinhDoanh" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
														EnableViewState="true" TextMode="MultiLine"></asp:textbox></TD>
												<TD class="QH_ColLabel" width="15%">Địa chỉ thường trú</TD>
												<TD>
													<asp:textbox id="txtDiaChiThuongTru" CssClass="QH_textbox" runat="server" Width="90%" ReadOnly="True"
														EnableViewState="true" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">
													Hình thức kinh doanh</TD>
												<TD width="30%" valign="middle">
													<asp:dropdownlist id="ddlMaHinhThucKinhDoanh" CssClass="QH_DropDownList" runat="server" Width="90%"
														EnableViewState="true" Enabled="False"></asp:dropdownlist></TD>
												<TD class="QH_ColLabel" width="15%" rowspan="2">Ghi chú</TD>
												<TD rowspan="2">
													<asp:textbox id="txtGhiChu" CssClass="QH_textbox" runat="server" Width="90%" EnableViewState="true"
														TextMode="MultiLine" Rows="2"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="20%">Phương thức kinh doanh</TD>
												<TD width="30%">
													<asp:dropdownlist id="ddlMaPhuongThucKinhDoanh" CssClass="QH_DropDownList" runat="server" Width="90%"
														EnableViewState="true" Enabled="False"></asp:dropdownlist></TD>
												<TD class="QH_ColLabel" width="15%"></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="15%">Vốn kinh doanh</TD>
												<TD valign="top">
													<asp:textbox id="txtVonKinhDoanh" CssClass="QH_TextRight" runat="server" Width="90%" EnableViewState="true"
														MaxLength="15"></asp:textbox>
													<asp:textbox id="txtTienBangChu" Width="0px" Runat="server"></asp:textbox></TD>
												<TD class="QH_ColLabel" width="20%">Ngày cấp phó bản</TD>
												<TD width="30%" valign="top">
													<asp:textbox id="txtNgayCapPhoBan" Width="50%" runat="server" CssClass="QH_textbox"></asp:textbox>&nbsp;
													<asp:image id="imgNgayCapPhoBan" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
														ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD height="5"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:imagebutton id="btnCapNhat" runat="server" ImageUrl="../../images/btn_CapNhat.gif"></asp:imagebutton>
										<asp:imagebutton id="btnXoa" runat="server" ImageUrl="../../images/btn_Xoa.gif"></asp:imagebutton>
										<asp:image id="btnIn" runat="server" ImageUrl="../../images/btn_In.gif"></asp:image>
										<asp:imagebutton id="btnBoQua" runat="server" ImageUrl="../../images/btn_TroVe.gif"></asp:imagebutton></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:TextBox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:TextBox>
							<asp:TextBox id="txtMaLinhVuc" Width="0px" runat="server"></asp:TextBox>
							<asp:TextBox id="txtTabCode" Width="0px" runat="server"></asp:TextBox>
							<asp:TextBox id="txtMaNguoiTacNghiep" Width="0px" runat="server"></asp:TextBox>
							<asp:TextBox id="txtReload" Width="0px" runat="server"></asp:TextBox>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
	<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
	<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
</P>
