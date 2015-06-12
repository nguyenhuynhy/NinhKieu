<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuu" Src="ThongTinTraCuuDauKy.ascx" %>
<%@ Register TagPrefix="uc1" TagName="KTThongTinTraCuu" Src="KTThongTinTraCuu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NhapDauKyHTXList.ascx.vb" Inherits="CPKTQH.NhapDauKyHTXList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" CssClass="QH_Label_Title" Width="100%"> Thông tin ĐKKD Hợp tác xã</asp:label>
					</td>
					<td width="16" height="24" class="QH_Khung_TopRight">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" class="QH_Khung_Left">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%">
										<tr>
											<td><uc1:KTThongTinTraCuu id="KTThongTinTraCuu1" runat="server"></uc1:KTThongTinTraCuu></td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="100%">
												<table width="100%">
													<TR>
														<TD align="center" colspan="2">
															<asp:LinkButton CssClass="QH_Button" id="btnTimKiem" runat="server">Tìm kiếm</asp:LinkButton>&nbsp;
															<asp:LinkButton CssClass="QH_Button" id="btnThemMoi" runat="server">Thêm mới</asp:LinkButton>&nbsp;
															<asp:LinkButton id="btnInDanhSach" CssClass="QH_Button" runat="server" Visible="False">In Danh Sách</asp:LinkButton>
														</TD>
													</TR>
													<TR>
														<td align="left" width="50%">
															<asp:label id="Label2" Runat="server" ForeColor="Navy" BorderColor="Blue">Tổng số giấy phép:</asp:label>
															<asp:label id="lblTongSoHoSo" Runat="server" ForeColor="Navy" Font-Bold="True"></asp:label>
														</td>
														<TD align="right">
															<asp:Label ID="Label1" Runat="server" cssClass="QH_ColLabel1">Số dòng hiển thị</asp:Label>
															<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextRight" Width="30px"
																MaxLength="3"></asp:TextBox>
														</TD>
													</TR>
													<TR>
														<TD colspan="2">
															<asp:datagrid id="dgdDanhSach" CssClass="QH_DataGridBottom" Width="100%" Runat="server" CellPadding="3"
																autogeneratecolumns="False" AllowPaging="True">
																<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="STT">
																		<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn Visible="False" DataField="GiayCNDKKDID" HeaderText="GiayCNDKKDID"></asp:BoundColumn>
																	<asp:BoundColumn DataField="SoGiayPhep" HeaderText="Số GCN ĐKKD">
																		<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="HoTen" HeaderText="Họ t&#234;n chủ nhiệm">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="DiaChi" HeaderText="Địa chỉ kinh doanh">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="TinhTrang" HeaderText="T&#236;nh trạng">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="Cập nhật">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
																		<ItemTemplate>
																			<asp:HyperLink id=hplCapNhat Runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.URL")%>' ImageUrl="~/images/H_CapNhat.gif">
																			</asp:HyperLink>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Cấp đổi">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
																		<ItemTemplate>
																			<asp:HyperLink id=hplCapDoi Runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.URLCapDoi")%>' ImageUrl="~/images/H_CapDoi.gif">
																			</asp:HyperLink>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Thay đổi">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
																		<ItemTemplate>
																			<asp:HyperLink id=hplThayDoi Runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.URLThayDoi")%>' ImageUrl="~/images/H_ThayDoi.gif">
																			</asp:HyperLink>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Ngưng">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
																		<ItemTemplate>
																			<asp:HyperLink id=hplNgung Runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.URLNgung")%>' ImageUrl="~/images/H_Ngung.gif">
																			</asp:HyperLink>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
															</asp:datagrid>
														</TD>
													</TR>
												</table>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
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
