<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChiTietTinhHinhThuLyHoSo.ascx.vb" Inherits="THTT.ChiTietTinhHinhThuLyHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="10%"></TD>
		<TD width="*">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="6"><asp:label id="Label1" Runat="server" Width="100%" CssClass="QH_Label_Title">Chi tiết quá trình xử lý hồ sơ</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6" height="10"></TD>
				</TR>
				<tr>
					<td colSpan="6">
						<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="17%">Số&nbsp;hồ sơ:</TD>
								<TD width="1%"></TD>
								<TD width="19%"><asp:label id="lblSoBienBan" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
								<TD class="QH_ColLabel" width="18%">Loại lĩnh vực:</TD>
								<TD width="1%"></TD>
								<TD width="44%"><asp:label id="lblTenLinhVuc" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
							<TR>
								<TD class="QH_ColLabel">Ngày lập:</TD>
								<TD></TD>
								<TD><asp:label id="lblNgayNhan" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
								<TD class="QH_ColLabel">Người nhập:</TD>
								<TD></TD>
								<TD><asp:label id="lblFullName" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Ngày quyết định:</TD>
								<TD></TD>
								<TD><asp:label id="lblNgayQuyetDinh" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
								<TD class="QH_ColLabel">Người vi phạm:</TD>
								<TD></TD>
								<TD><asp:label id="lblHoTen" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Ngày thi hành:</TD>
								<TD></TD>
								<TD><asp:label id="lblNgayThiHanh" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
								<TD class="QH_ColLabel">Địa chỉ:</TD>
								<TD></TD>
								<TD><asp:label id="lblDiaChiViPham" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD class="QH_ColLabel">Tình trạng hồ sơ:</TD>
								<TD></TD>
								<TD><asp:label id="lblTenTinhTrang" Runat="server" Width="100%" ForeColor="Red" Font-Italic="True"
										Font-Bold="True" Font-Names="Arial, Helvetica, sans-serif" Font-Size="11px"></asp:label></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<TD colSpan="6" height="10"></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="Label12" Runat="server" Width="100%" CssClass="QH_Label_Title">Quá trình giải quyết hồ sơ</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6" height="5"></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_DataGrid" CellPadding="3"
							AllowPaging="True" AllowSorting="True" PageSize="20">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6" height="5"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="10%"></TD>
	</TR>
</TABLE>
