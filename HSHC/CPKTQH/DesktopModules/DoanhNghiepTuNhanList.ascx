<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DoanhNghiepTuNhanList.ascx.vb" Inherits="CPKTQH.DoanhNghiepTuNhanList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" CssClass="QH_Label_Title" Width="100%">Danh sách hộ kinh doanh cá thể</asp:label></td>
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
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" CssClass="QH_Textbox" Width="80%" runat="server"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%" height="23">Tình trạng</TD>
											<TD class="QH_ColControl" width="35%" height="23"><asp:dropdownlist id="ddlTinhTrangHienTai" Runat="server" CssClass="QH_DropDownList" Width="60%" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Số nhà</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="80%"></asp:textbox>
											<TD class="QH_ColLabel" width="15%">Số GCN ĐKKD</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" Runat="server" CssClass="QH_TextBox" Width="40%"></asp:textbox><asp:textbox id="txtTienBangChu" Runat="server" Width="0px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ðường</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlDuong" Runat="server" CssClass="QH_DropDownList" Width="80%"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTuNgay" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="imgTuNgay" CssClass="QH_IMAGEBUTTON" runat="server" AlternateText="Chọn ngày tháng nam"
													ImageUrl="~/images/calendar.gif"></asp:image></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Phường</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlPhuong" Runat="server" CssClass="QH_DropDownList" Width="80%"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Ðến ngày</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDenNgay" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="imgDenNgay" CssClass="QH_IMAGEBUTTON" runat="server" AlternateText="Chọn ngày tháng nam"
													ImageUrl="~/images/calendar.gif"></asp:image></TD>
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
											<TD align="center" width="50%" colSpan="5"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>
												<asp:linkbutton id="btnThemMoi" CssClass="QH_Button" runat="server"> Thêm mới</asp:linkbutton>
												<asp:linkbutton id="btntroVe" CssClass="QH_Button" runat="server" Visible="False">Trở về</asp:linkbutton>&nbsp;
											</TD>
										</tr>
										<TR>
											<TD align="right" width="*" colSpan="5"><asp:label id="Label1" Runat="server" CssClass="QH_ColLabel1">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Runat="server" CssClass="QH_TextRight" Width="50px" MaxLength="3"
													AutoPostBack="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="2"><asp:datagrid id="dgdDanhSach" Runat="server" CssClass="QH_DataGrid" Width="100%" AllowPaging="True"
													autogeneratecolumns="False" CellPadding="3">
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
