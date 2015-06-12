<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TimKiemDonViTrucThuoc.ascx.vb" Inherits="CPKTQH.TimKiemDonViTrucThuoc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td height="5"><uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter></td>
	</tr>
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label3" runat="server" CssClass="QH_Label_Title" Width="100%">Tìm kiếm đơn vị trực thuộc</asp:label></td>
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
					<td vAlign="top" align="center" width="*">
						<!-----Thong tin tiem kiem------->
						<table id="table1" cellSpacing="0" cellPadding="0" width="98%" border="0">
							<tr>
								<td class="QH_ColLabel" width="15%">Người đại diện</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtNguoiDungDau" runat="server" CssClass="QH_Textbox" Width="90%" MaxLength="100"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Số GCN ĐKKD</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" runat="server" CssClass="QH_Textbox" Width="90%" MaxLength="100"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Số nhà</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" runat="server" CssClass="QH_Textbox" Width="90%" MaxLength="100"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Tên doanh nghiệp</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtTenDoanhNghiep" runat="server" CssClass="QH_Textbox" Width="90%" MaxLength="100"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Đường</td>
								<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></td>
								<td class="QH_ColLabel" width="15%">
									Loại hình DN</td>
								<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaLoaiHinhDoanhNghiep" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%" height="15">Phường</td>
								<td class="QH_ColControl" width="35%" height="15"><asp:dropdownlist id="ddlMaPhuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></td>
								<td class="QH_ColLabel" width="15%" height="15">Tình trạng</td>
								<td class="QH_ColControl" width="35%" height="15"><asp:dropdownlist id="ddlHoatDong" CssClass="QH_DropDownList" Width="90%" Runat="server">
										<asp:ListItem Selected="True"></asp:ListItem>
										<asp:ListItem Value="1">Đang hoạt động</asp:ListItem>
										<asp:ListItem Value="0">Kh&#244;ng hoạt động</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">
									Từ ngày</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtTuNgay" runat="server" CssClass="QH_Textbox" Width="100px" MaxLength="100"></asp:textbox>&nbsp;
									<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></td>
								<td class="QH_ColLabel" vAlign="top" width="15%" rowSpan="2">
									<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 0px">Mặt hàng KD</p>
								</td>
								<td class="QH_ColControl" vAlign="top" width="35%" rowSpan="2"><asp:textbox id="txtMatHangKinhDoanh" runat="server" CssClass="QH_Textbox" Width="90%" TextMode="MultiLine"
										Rows="2" Height="45px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">
									Đến ngày</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtDenNgay" runat="server" CssClass="QH_Textbox" Width="100px" MaxLength="100"></asp:textbox>&nbsp;
									<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></td>
							</tr>
						</table>
						<!-------------------------------------------><BR>
						<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton><BR>
						<!--So doanh nghiep - so dong hien thi + grid-->
						<table cellSpacing="0" cellPadding="0" width="98%" border="0">
							<tr>
								<td align="left" width="50%" class='QH_LabelLeft'></STRONG><asp:label id="Label2" Runat="server">Tổng số GCN ĐKKD: </asp:label><asp:label id="lblTongSoHoSo" Runat="server" Font-Bold="True"></asp:label></td>
								<td align="right" width="50%"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" Runat="server" MaxLength="3"
										AutoPostBack="True"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" width="100%" colSpan="2"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" CellPadding="3"
										autogeneratecolumns="False" AllowPaging="True">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<!-----------------------------------------><BR>
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
