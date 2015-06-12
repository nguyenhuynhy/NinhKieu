<%@ Control Language="vb" AutoEventWireup="false" Codebehind="XacMinhThucDia.ascx.vb" Inherits="CPXD.HoSoThamDinh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>

<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_Khung_TopLeft" width="16" height="24"></TD>
					<TD class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server"> Chuyển thẩm định</asp:label></TD>
					<TD class="QH_Khung_TopRight" width="16" height="24"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD>
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_Khung_Left" width="16">
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="*">
								<TD></TD>
							</TR>
							<TR height="141">
								<TD class="QH_Khung_Left1"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
							<TR>
								<TD align="center">
									<TABLE class="QH_Table" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%" height="25">Số biên nhận</TD>
											<TD class="QH_ColControl" width="70%" colSpan="3" height="25"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="20%" runat="server" EnableViewState="true"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="4">Loại hồ sơ</TD>
											<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaLoaiHoSo" CssClass="QH_DropDownList" Width="90%" runat="server" EnableViewState="true"
													Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Họ tên</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="10%">Giới tính</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinh" CssClass="QH_DropDownList" Width="25%" runat="server" EnableViewState="true"
													Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="24">Ðịa chỉ cư trú</TD>
											<TD class="QH_ColControl" colSpan="3" height="24"><asp:textbox id="txtDiaChiThuongTru" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="19">Địa chỉ xây dựng</TD>
											<TD class="QH_ColControl" colSpan="3" height="19"><asp:textbox id="txtDiaChi" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Về việc</TD>
											<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtVeViec" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="39">Nội dung hồ sơ</TD>
											<TD class="QH_ColControl" colSpan="3" height="39"><asp:textbox id="txtNoiDungHoSo" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Nội dung yêu cầu xác minh</TD>
											<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtNoiDung" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"
													TextMode="MultiLine" Rows="2"></asp:textbox></TD>
										</TR>
									</TABLE>
									<asp:textbox id="txtTrinhThamDinhID" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtLoai" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaCanBoDeXuat" Width="0px" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="QH_Table" id="tblThamDinh" cellSpacing="0" cellPadding="0" width="100%" border="0"
										runat="server">
										<TR>
											<TD class="QH_ColLabel" width="15%" height="19">Ðơn vị thẩm định</TD>
											<TD class="QH_ColControl" width="35%" height="19"><asp:dropdownlist id="ddlDonViThamDinh" CssClass="QH_DropDownList" Width="77%" runat="server" EnableViewState="true"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%" height="19">Người ký</TD>
											<TD class="QH_ColControl" width="35%" height="19"><asp:dropdownlist id="ddlMaSoLanhDao" CssClass="QH_DropDownList" Width="60%" runat="server" EnableViewState="true"
													Enabled="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%" height="1">Ngày chuyển</TD>
											<TD class="QH_ColControl" width="35%" height="1"><asp:textbox id="txtNgayThamDinh" CssClass="QH_textbox" Width="40%" runat="server" EnableViewState="true"></asp:textbox>&nbsp;
												<asp:image id="imgNgayThamDinh" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn lịch"
													ImageAlign="Middle" ImageUrl="~\images\calendar.gif"></asp:image></TD>
											<TD class="QH_ColLabel" width="15%" height="1">Ngày phản hồi</TD>
											<TD class="QH_ColControl" width="35%" height="1"><asp:textbox id="txtNgayPhanHoi" CssClass="QH_textbox" Width="40%" runat="server" EnableViewState="true"></asp:textbox><asp:image id="imgNgayPhanHoi" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn lịch"
													ImageAlign="Middle" ImageUrl="~\images\calendar.gif"></asp:image></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%"></TD>
											<TD class="QH_ColControl" width="35%"></TD>
											<TD class="QH_ColLabel" width="15%"></TD>
											<TD class="QH_ColControl" width="35%">&nbsp;</TD>
										</TR>
									</TABLE>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%"></TD>
											<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtHoSoThamDinhID" Width="0px" runat="server"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>&nbsp;&nbsp;&nbsp;
									<asp:linkbutton id="btnInPhieuChuyen" CssClass="QH_Button" runat="server">In Phiếu Chuyển</asp:linkbutton>&nbsp;&nbsp;&nbsp;
									<asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="QH_Khung_Right" width="16">
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
		</TD>
	</TR>
</TABLE>
