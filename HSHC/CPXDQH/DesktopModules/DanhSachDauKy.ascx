<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachDauKy.ascx.vb" Inherits="CPXD.DanhSachDauKy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server"> Danh sách giấy phép xây dựng</asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<TR>
								<TD colSpan="5" height="5"></TD>
							</TR>
							<TR>
								<TD width="100%">
									<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center"
										border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%">Họ tên</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" Width="80%" CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%" height="23">Tình trạng</TD>
											<TD class="QH_ColControl" width="35%" height="23"><asp:dropdownlist id="ddlTinhTrangHienTai" Width="60%" CssClass="QH_DropDownList" Runat="server" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Số nhà</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" Width="30%" CssClass="QH_TextBox" Runat="server"></asp:textbox>
											<TD class="QH_ColLabel" width="15%">Số giấy phép</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" Width="40%" CssClass="QH_TextBox" Runat="server"></asp:textbox><asp:textbox id="txtTienBangChu" Width="0px" Runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ðường</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlDuong" Width="80%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTuNgay" Width="40%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="imgTuNgay" CssClass="QH_IMAGEBUTTON" runat="server" ImageUrl="~/images/calendar.gif"
													AlternateText="Chọn ngày tháng nam"></asp:image></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Phường</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlPhuong" Width="80%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Ðến ngày</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDenNgay" Width="40%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="imgDenNgay" CssClass="QH_IMAGEBUTTON" runat="server" ImageUrl="~/images/calendar.gif"
													AlternateText="Chọn ngày tháng nam"></asp:image></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="5" height="5"></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<TD align="center" width="50%" colSpan="5"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnThemMoi" CssClass="QH_Button" runat="server"> Thêm mới</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btntroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;
											</TD>
										</tr>
										<TR>
											<TD align="right" width="*" colSpan="5"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Width="50px" CssClass="QH_TextRight" Runat="server" MaxLength="3"
													AutoPostBack="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="2"><asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" Runat="server" CellPadding="3"
													autogeneratecolumns="False" AllowPaging="True">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
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
