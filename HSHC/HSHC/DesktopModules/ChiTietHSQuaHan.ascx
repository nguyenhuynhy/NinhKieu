<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChiTietHSQuaHan.ascx.vb" Inherits="HSHC.ChiTietHSQuaHan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
					<td align="center" width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="10%"></TD>
								<TD width="*">
									<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<br>
										<TR>
											<TD class="QH_ColLabel" width="17%">Số biên nhận:</TD>
											<TD class="QH_ColControl" width="19%"><asp:label id="lblSoBienNhan" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
											<TD class="QH_ColLabel" width="18%">Loại hồ sơ:</TD>
											<TD class="QH_ColControl" width="44%"><asp:label id="lblLoaiHoSo" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
										<TR>
											<TD class="QH_ColLabel">Ngày nhận:</TD>
											<TD class="QH_ColControl"><asp:label id="lblNgayNhan" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
											<TD class="QH_ColLabel">Người nhận:</TD>
											<TD class="QH_ColControl"><asp:label id="lblNguoiNhan" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày hẹn trả:</TD>
											<TD class="QH_ColControl"><asp:label id="lblNgayHenTra" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
											<TD class="QH_ColLabel">Người nộp:</TD>
											<TD class="QH_ColControl"><asp:label id="lblNguoiNop" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày thực trả:</TD>
											<TD class="QH_ColControl"><asp:label id="lblNgayThucTra" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
											<TD class="QH_ColLabel">Địa chỉ:</TD>
											<TD class="QH_ColControl"><asp:label id="lblDiaChi" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
										</TR>
										<TR id="trCPLD" runat="server">
											<TD class="QH_ColLabel">Tổng số lao động:</TD>
											<TD class="QH_ColControl"><asp:label id="lblTongSoLaoDong" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
											<TD class="QH_ColLabel">Số lao động nữ:</TD>
											<TD class="QH_ColControl"><asp:label id="lblTongSoLaoDongNu" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
										</TR>
										<TR id="trCPVH" runat="server">
											<TD class="QH_ColLabel">Ngành kinh doanh:</TD>
											<TD class="QH_ColControl"><asp:label id="lblNganhKinhDoanh" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
											<TD class="QH_ColLabel"></TD>
											<TD class="QH_ColControl"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD class="QH_ColLabel">Tình trạng hồ sơ:</TD>
											<TD class="QH_ColControl"><asp:label id="lblTinhTrang" Width="100%" Runat="server" Font-Size="11px" Font-Names="Arial, Helvetica, sans-serif"
													Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="4">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="4"><asp:label id="Label12" CssClass="QH_Label_Title1" Width="100%" Runat="server">Quá trình giải quyết hồ sơ</asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="4"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" PageSize="20"
													AllowSorting="True" AllowPaging="True" CellPadding="3" AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="STT" ItemStyle-HorizontalAlign="Center">
															<ItemTemplate>
																<asp:Label runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label25">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label27">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Ng&#224;y nhận">
															<ItemTemplate>
																<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label1">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label2">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Tình trạng hiện tại">
															<ItemTemplate>
																<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TinhTrangHienTai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label11">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.TinhTrangHienTai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label13">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Hạn giải quyết (ngày)">
															<ItemTemplate>
																<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label3">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label4">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Ngày thụ lý">
															<ItemTemplate>
																<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NgayThuLy") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label5">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.NgayThuLy") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label6">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Số ngày quá hạn">
															<ItemTemplate>
																<asp:Label runat="server" Text="0" Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label14">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# -1*DataBinder.Eval(Container, "DataItem.DoLech") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label15">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Công việc">
															<ItemTemplate>
																<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CongViec") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label7">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.CongViec") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label8">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Người thực hiện">
															<ItemTemplate>
																<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FullName") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") >= 0,"True","False")%>' ID="Label9">
																</asp:Label>
																<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.FullName") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.DoLech") < 0,"True","False")%>' ID="Label10">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="10%"></TD>
							</TR>
							<TR>
								<TD colSpan="3" height="5"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
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
