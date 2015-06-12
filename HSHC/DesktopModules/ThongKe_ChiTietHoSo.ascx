<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKe_ChiTietHoSo.ascx.vb" Inherits="ThongKe_ChiTietHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblLoai" CssClass="QH_Label_Title" Width="100%" Runat="server">Chi tiết tiếp nhận hồ sơ</asp:label></td>
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
					<td width="*" align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="10%"></TD>
								<TD width="*">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<br>
										<TR>
											<TD width="17%" class="QH_ColLabel">Số biên nhận:</TD>
											<TD class="QH_ColControl" width="19%"><asp:label ID="lblSoBienNhan" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:label></TD>
											<TD width="18%" class="QH_ColLabel">Loại hồ sơ:</TD>
											<TD class="QH_ColControl" width="44%"><asp:Label ID="lblLoaiHoSo" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:Label></TD>
										<TR>
											<TD class="QH_ColLabel">Ngày nhận:</TD>
											<TD class="QH_ColControl"><asp:Label ID="lblNgayNhan" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:Label></TD>
											<TD class="QH_ColLabel">Người nhận:</TD>
											<TD class="QH_ColControl"><asp:Label ID="lblNguoiNhan" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày hẹn trả:</TD>
											<TD class="QH_ColControl"><asp:Label ID="lblNgayHenTra" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:Label></TD>
											<TD class="QH_ColLabel">Người nộp:</TD>
											<TD class="QH_ColControl"><asp:Label ID="lblNguoiNop" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày thực trả:</TD>
											<TD class="QH_ColControl"><asp:Label ID="lblNgayThucTra" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:Label></TD>
											<TD class="QH_ColLabel">Địa chỉ:</TD>
											<TD class="QH_ColControl"><asp:Label ID="lblDiaChi" CssClass="QH_LabelLeftBold" Runat="server" Width="100%"></asp:Label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD class="QH_ColLabel">Tình trạng hồ sơ:</TD>
											<TD class="QH_ColControl"><asp:Label ID="lblTinhTrang" Font-Size="11px" Font-Names="Arial, Helvetica, sans-serif" Font-Bold="True"
													Font-Italic="True" ForeColor="Red" Runat="server" Width="100%"></asp:Label></TD>
										</TR>
										<TR>
											<TD colspan="4"><asp:label id="Label12" CssClass="QH_Label_Title1" Width="100%" Runat="server">Quá trình giải quyết hồ sơ</asp:label></TD>
										</TR>
										<TR>
											<TD colspan="4">
												<asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" PageSize="20" Runat="server"
													AllowSorting="True" AllowPaging="True" CellPadding="3">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="10%"></TD>
							</TR>
							<TR>
								<TD colspan="3" height="5">
								</TD>
							</TR>
							<TR>
								<TD colspan="3" align="center">
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td width="16" class="QH_Khung_Right">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1">
								</td>
							</tr>
						</Table>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
