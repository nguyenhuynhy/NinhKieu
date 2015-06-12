<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachSoLieuDuyet.ascx.vb" Inherits="DanhSachSoLieuDuyet" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">TẠO BÁO CÁO</asp:label>
					</td>
					<td width="8" height="25" class="QH_Content_TopRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="9" class="QH_Content_Left">&nbsp;
					</td>
					<td width="*" valign="top">
						<!--End bound-->
						<table id="Table1" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
							<tr>
								<td width="100%" align="center">
									<TABLE class="QH_Content_Filter" cellSpacing="0" cellPadding="0" border="0" width="70%">
										<tr>
											<td height="5"></td>
										</tr>
										<TR>
											<TD align="right" width="40%"><asp:label id="lblDonVi" CssClass="QH_ColLabel" Text="Đơn vị báo cáo" runat="server"></asp:label></TD>
											<TD width="60%" colSpan="2"><asp:dropdownlist id="ddlDonVi" CssClass="QH_DropDownList" Runat="server" Width="60%"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD align="right"><asp:label id="lblKyBaoCao" CssClass="QH_ColLabel" Text="Kỳ báo cáo" runat="server"></asp:label></TD>
											<TD colSpan="2"><asp:dropdownlist id="ddlKyBaoCao" CssClass="QH_DropDownList" Runat="server" Width="60%"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD align="right"><asp:label id="lblNam" CssClass="QH_ColLabel" Text="Năm" runat="server"></asp:label></TD>
											<TD width="20%"><asp:dropdownlist id="ddlNam" CssClass="QH_DropDownList" Runat="server" Width="90%"></asp:dropdownlist></TD>
											<td align="left"><asp:image id="btnTimKiem" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/images/search.gif"></asp:image><asp:linkbutton id="lnkbtnChon" runat="server">
													<asp:label id="Label12" Runat="server" CssClass="QH_Link_Button">Tìm kiếm</asp:label>
												</asp:linkbutton></td>
										</TR>
										<tr>
											<td height="8"></td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td>
									<table width="99%">
										<tr>
											<td align="right"><asp:label id="label7" Runat="server">Số dòng hiển thị : &nbsp;</asp:label><asp:textbox id="txtSoDongHienThi" CssClass="QH_TextRight" Runat="server" MaxLength="3" Width="50px"
													AutoPostBack="True"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Runat="server" Width="99%" CellPadding="3"
										autogeneratecolumns="False" AllowPaging="True">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="STT" HeaderStyle-Font-Bold="True">
												<ItemStyle Width="5%" HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label width="100%" id="lblSTT" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Kỳ báo cáo" HeaderStyle-Font-Bold="True">
												<ItemStyle Width="15%" HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink ID ="hplKyBaoCao" Runat=server NavigateUrl='<%# EditURL("MaDonVi",DataBinder.Eval(Container.DataItem,"MaDonVi") & "&MaKyBaoCao=" & DataBinder.Eval(Container.DataItem,"MaKyBaoCao") & "&Nam="& Ctype(DataBinder.Eval(Container.DataItem,"Nam"),string) &"&Loai=" & DataBinder.Eval(Container.DataItem,"LoaiSL") ,"SLBC") %>' Text ='<%#DataBinder.Eval(Container.DataItem,"KyBaoCao")%>'>
													</asp:Hyperlink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Đơn vị báo cáo" HeaderStyle-Font-Bold="True">
												<ItemStyle Width="30%" HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink ID="hplDonViBaoCao" Runat=server text='<%#DataBinder.Eval(Container,"DataItem.TenDV")%>'>
													</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Loại số liệu" HeaderStyle-Font-Bold="True">
												<ItemStyle Width="15%" HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink ID="hplLoaiSoLieu" Runat=server text='<%#DataBinder.Eval(Container,"DataItem.LoaiSoLieu")%>'>
													</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td align="center">
									<asp:imagebutton CssClass="QH_Button" id="btnIn" ImageUrl="../../IMAGES/btn_In.gif" runat="server"
										Visible="true"></asp:imagebutton></td>
							</tr>
						</table>
						<!--start bound-->
					</td>
					<td width="8" class="QH_Content_Right">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colspan="3" height="12">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="128" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
					</td>
					<td width="130" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
