<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TimKiemHoSo.ascx.vb" Inherits="CPKTQH.TimKiemHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>਍ഀ
<script language=javascript ਍ഀ
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>਍ഀ
<script language=javascript ਍ഀ
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>਍ഀ
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
	<TR>਍ഀ
		<TD width="100%" height="24">਍ഀ
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
				<tr>਍ഀ
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>਍ഀ
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" Width="100%" runat="server" CssClass="QH_Label_Title">Tìm kiếm hồ sơ tiếp nhận</asp:label></td>਍ഀ
					<td class="QH_Khung_TopRight" width="16" height="24"></td>਍ഀ
				</tr>਍ഀ
			</table>਍ഀ
		</TD>਍ഀ
	</TR>਍ഀ
	<TR>਍ഀ
		<TD>਍ഀ
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
				<tr>਍ഀ
					<td class="QH_Khung_Left" width="16">਍ഀ
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
							<tr height="*">਍ഀ
								<td></td>਍ഀ
							</tr>਍ഀ
							<tr height="141">਍ഀ
								<td class="QH_Khung_Left1"></td>਍ഀ
							</tr>਍ഀ
						</TABLE>਍ഀ
					</td>਍ഀ
					<td width="*">਍ഀ
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
							<TR>਍ഀ
								<TD height="5"></TD>਍ഀ
							</TR>਍ഀ
							<tr>਍ഀ
								<td width="2%"></td>਍ഀ
								<td width="48%" valign="top">਍ഀ
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
										<tr>਍ഀ
											<TD width="30%" class="QH_ColLabel">Loại tìm kiếm</TD>਍ഀ
											<TD width="70%" class="QH_ColControl"><asp:dropdownlist id="ddlLoaiTimKiem" runat="server" Width="90%" EnableViewState="true" CssClass="QH_DropDownList">਍ഀ
													<asp:ListItem Value="MOINHAN">Nhận trong kỳ</asp:ListItem>਍ഀ
													<asp:ListItem Value="TONTRUOC">Tồn trước</asp:ListItem>਍ഀ
													<asp:ListItem Value="DAHUY">Hồ sơ đ&#227; hủy</asp:ListItem>਍ഀ
													<asp:ListItem Value="DAGQDUNGHAN">Đ&#227; giải quyết đ&#250;ng hạn</asp:ListItem>਍ഀ
													<asp:ListItem Value="DAGQQUAHAN">Đ&#227; giải quyết qu&#225; hạn</asp:ListItem>਍ഀ
													<asp:ListItem Value="CHUAGQTRONGHAN">Chưa giải quyết trong hạn</asp:ListItem>਍ഀ
													<asp:ListItem Value="CHUAGQQUAHAN">Chưa giải quyết qu&#225; hạn</asp:ListItem>਍ഀ
													<asp:ListItem Value="BOTUCHOSO">Hồ sơ chờ bổ t&#250;c</asp:ListItem>਍ഀ
													<asp:ListItem Value="CHOXACMINH">Hồ sơ chờ x&#225;c minh</asp:ListItem>਍ഀ
													<asp:ListItem Value="DATRA">Hồ sơ đ&#227; trả d&#226;n</asp:ListItem>਍ഀ
													<asp:ListItem Value="CHUATRA">Đ&#227; giải quyết xong nhưng chưa trả d&#226;n</asp:ListItem>਍ഀ
												</asp:dropdownlist></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Loại hồ sơ</TD>਍ഀ
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaLoaiHoSo" runat="server" Width="90%" EnableViewState="true" CssClass="QH_DropDownList"></asp:dropdownlist></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Tình trạng hồ sơ</TD>਍ഀ
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaTinhTrang" runat="server" Width="90%" EnableViewState="true" CssClass="QH_DropDownList"></asp:dropdownlist></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Người thụ lý</TD>਍ഀ
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlNguoiThuLy" runat="server" Width="90%" EnableViewState="true" CssClass="QH_DropDownList"></asp:dropdownlist></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Từ ngày</TD>਍ഀ
											<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" Width="30%" EnableViewState="true" CssClass="QH_textbox" Runat="server"਍ഀ
													MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgTuNgay" runat="server" CssClass="QH_Button" AlternateText="Chọn lịch" ImageAlign="AbsMiddle"਍ഀ
													ImageUrl="~\images\calendar.gif"></asp:image></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Đến ngày</TD>਍ഀ
											<td class="QH_ColControl"><asp:textbox id="txtDenNgay" Width="30%" EnableViewState="true" CssClass="QH_textbox" Runat="server"਍ഀ
													MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgDenNgay" runat="server" CssClass="QH_Button" AlternateText="Chọn lịch" ImageAlign="AbsMiddle"਍ഀ
													ImageUrl="~\images\calendar.gif"></asp:image></td>਍ഀ
										</tr>਍ഀ
									</TABLE>਍ഀ
								</td>਍ഀ
								<td width="48%" valign="top">਍ഀ
									<TABLE id="Table112" cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel" width="30%">Số biên nhận</TD>਍ഀ
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoBienNhan" Width="50%" EnableViewState="true" CssClass="QH_textbox" Runat="server"਍ഀ
													MaxLength="20"></asp:textbox></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel" width="30%">Số GCN ĐKKD</TD>਍ഀ
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoGiayPhep" Width="50%" EnableViewState="true" CssClass="QH_textbox" Runat="server"਍ഀ
													MaxLength="20"></asp:textbox></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Họ tên</TD>਍ഀ
											<TD class="QH_ColControl"><asp:textbox id="txtHoTen" Width="90%" EnableViewState="true" CssClass="QH_textbox" Runat="server"਍ഀ
													MaxLength="50"></asp:textbox></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Số nhà</TD>਍ഀ
											<TD class="QH_ColControl"><asp:textbox id="txtSoNha" Width="90%" EnableViewState="true" CssClass="QH_textbox" Runat="server"਍ഀ
													MaxLength="50"></asp:textbox></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Đường</TD>਍ഀ
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlDuong" runat="server" Width="90%" EnableViewState="true" CssClass="QH_DropDownList"></asp:dropdownlist></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel">Phường</TD>਍ഀ
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" runat="server" Width="90%" EnableViewState="true" CssClass="QH_DropDownList"></asp:dropdownlist></TD>਍ഀ
										</tr>਍ഀ
										<tr>਍ഀ
											<TD class="QH_ColLabel"><asp:Label id="lblTieuDeLoaiTiepNhan" runat="server">Loại tiếp nhận</asp:Label></TD>਍ഀ
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlLoaiTiepNhanHoSo" runat="server" Width="90%" EnableViewState="true" CssClass="QH_DropDownList">਍ഀ
													<asp:ListItem></asp:ListItem>਍ഀ
													<asp:ListItem Value="0">Hồ sơ tiếp nhận tại chỗ</asp:ListItem>਍ഀ
													<asp:ListItem Value="1">Hồ sơ tiếp nhận qua mạng</asp:ListItem>਍ഀ
												</asp:dropdownlist></TD>਍ഀ
										</tr>਍ഀ
									</TABLE>਍ഀ
								</td>਍ഀ
								<td width="2%"></td>਍ഀ
							</tr>਍ഀ
							<TR>਍ഀ
								<TD height="5"></TD>਍ഀ
							</TR>਍ഀ
							<TR>਍ഀ
								<TD height="5"></TD>਍ഀ
							</TR>਍ഀ
							<tr>਍ഀ
								<td colspan="4" align="center">਍ഀ
									<asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>਍ഀ
									<asp:linkbutton id="btnInRaGiay" CssClass="QH_Button" runat="server">In danh sách</asp:linkbutton>਍ഀ
								</td>਍ഀ
							</tr>਍ഀ
							<TR>਍ഀ
								<TD align="left" colspan="2" class="QH_LabelLeft"><asp:label id="Label2" Runat="server">Tổng số hồ sơ: </asp:label><strong><asp:label id="lblTongSoHoSo" Runat="server"></asp:label></strong></TD>਍ഀ
								<TD align="right" colspan="4"><asp:label id="Label1" Runat="server" CssClass="QH_ColLabel1">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Runat="server" CssClass="QH_TextRight" Width="30px" AutoPostBack="True"਍ഀ
										MaxLength="3"></asp:textbox></TD>਍ഀ
							</TR>਍ഀ
							<TR>਍ഀ
								<TD colspan="4"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Runat="server" Width="100%" CellPadding="3"਍ഀ
										AllowPaging="True" AllowSorting="True" autogeneratecolumns="False">਍ഀ
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>਍ഀ
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>਍ഀ
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>਍ഀ
									</asp:datagrid></TD>਍ഀ
							</TR>਍ഀ
						</TABLE>਍ഀ
					</td>਍ഀ
					<td class="QH_Khung_Right" width="16">਍ഀ
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">਍ഀ
							<tr height="*">਍ഀ
								<td></td>਍ഀ
							</tr>਍ഀ
							<tr height="141">਍ഀ
								<td class="QH_Khung_Right1"></td>਍ഀ
							</tr>਍ഀ
						</TABLE>਍ഀ
					</td>਍ഀ
				</tr>਍ഀ
			</table>਍ഀ
		</TD>਍ഀ
	</TR>਍ഀ
</TABLE>਍ഀ
