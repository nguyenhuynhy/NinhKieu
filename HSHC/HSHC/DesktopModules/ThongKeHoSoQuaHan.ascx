<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeHoSoQuaHan.ascx.vb" Inherits="HSHC.ThongKeHoSoQuaHan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblLoai" CssClass="QH_Label_Title" Width="100%" Runat="server"></asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
							<TR>
								<TD colSpan="3" height="2"></TD>
							</TR>
							<TR>
								<td width="20%"></td>
								<TD width="*">
									<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="25%"><asp:label id="Label1" Runat="server" Width="100%" CssClass="QH_LabelLeft">Lĩnh vực tiếp nhận</asp:label></TD>
											<TD class="QH_ColLabelLeft" width="5%">:</TD>
											<TD width="*"><asp:label id="lblLinhVuc" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="3" height="5"></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label2" Runat="server" Width="100%" CssClass="QH_LabelLeft">Loại hồ sơ</asp:label></TD>
											<TD class="QH_ColLabelLeft">:</TD>
											<TD><asp:label id="lblLoaiHoSo" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="3" height="5"></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label3" Runat="server" Width="100%" CssClass="QH_LabelLeft">Thời gian tiếp nhận</asp:label></TD>
											<TD class="QH_ColLabelLeft">:</TD>
											<TD><asp:label id="lblThoiGian" Runat="server" Width="100%" CssClass="QH_LabelLeftBold"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<td width="20%"></td>
							</TR>
							<TR>
								<TD colSpan="3" align="right">
									<asp:Label ID="Label4" Runat="server" CssClass="QH_ColLabel1">Số dòng hiển thị</asp:Label>
									<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextRight" Width="50px"
										MaxLength="3"></asp:TextBox>
								</TD>
							</TR>
							<TR>
								<TD colspan="3">
									<asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" autogeneratecolumns="false"
										Runat="server" AllowSorting="True" AllowPaging="True" CellPadding="3">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="STT">
												<ItemStyle Width="3%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblStt" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Số biên nhận">
												<ItemStyle Width="10%" cssclass="QH_MenuLink"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplSoBienNhan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>' NavigateUrl='<%# EditURL("ID", DataBinder.Eval(Container, "DataItem.HoSoTiepNhanID") & "&Malv=" & request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & request.Params("TuNgay") & "&DenNgay=" & request.Params("DenNgay") & "&Loai=CHUAGQQUAHAN","CHITIETHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="HoTenNguoiNop" HeaderText="Người nộp" HeaderStyle-Width="17%" />
											<asp:BoundColumn DataField="DiaChi" HeaderText="Địa chỉ" HeaderStyle-Width="26%" />
											<asp:BoundColumn DataField="NgayNhan" HeaderText="Ngày nhận" HeaderStyle-Width="7%" />
											<asp:BoundColumn DataField="NgayHenTra" HeaderText="Ngày hẹn trả" HeaderStyle-Width="7%" />
											<asp:BoundColumn DataField="SoNgayQuaHan" HeaderText="Số ngày quá hạn" HeaderStyle-Width="5%" />
											<asp:TemplateColumn HeaderText="Tình trạng trễ hạn">
												<ItemStyle Width="15%" cssclass="QH_MenuLink"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplQuaHanTT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' NavigateUrl='<%# EditURL("ID", DataBinder.Eval(Container, "DataItem.HoSoTiepNhanID") & "&Malv=" & request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & request.Params("TuNgay") & "&DenNgay=" & request.Params("DenNgay") & "&ttid=" & DataBinder.Eval(Container, "DataItem.MaTinhTrang") & "&tentt=" & EncryptText(DataBinder.Eval(Container, "DataItem.TenTinhTrang")) & "&Loai=CHUAGQQUAHAN","QUAHANTT") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Cán bộ trễ hạn">
												<ItemStyle Width="10%" cssclass="QH_MenuLink"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplQuaHanUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FullName") %>' NavigateUrl='<%# EditURL("ID", DataBinder.Eval(Container, "DataItem.HoSoTiepNhanID") & "&Malv=" & request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & request.Params("TuNgay") & "&DenNgay=" & request.Params("DenNgay") & "&userid=" & DataBinder.Eval(Container, "DataItem.UserName") & "&tenuser=" & EncryptText(DataBinder.Eval(Container, "DataItem.FullName")) & "&Loai=CHUAGQQUAHAN","QUAHANUSER") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
								</TD>
							</TR>
							<TR>
								<TD colspan="3" align="center">
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
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
