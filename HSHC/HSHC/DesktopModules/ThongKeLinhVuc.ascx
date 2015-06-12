<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeLinhVuc.ascx.vb" Inherits="HSHC.ThongKeLinhVuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblTieuDe" Runat="server" CssClass="QH_Label_Title" Width="100%">Tình hình giải quyết hồ sơ hành chính</asp:label>
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
						<table cellSpacing="0" cellPadding="5" width="100%" border="0">
							<TR class="QH_Filter_Bg">
								<TD width="15%"></TD>
								<TD class="QH_ColLabel1" width="12%">Từ ngày<font size="2" color="#ff0000">*</font></TD>
								<TD width="22%"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="70px" Runat="server"></asp:textbox>
									&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD class="QH_ColLabel1" width="12%">Ðến ngày<font size="2" color="#ff0000">*</font></TD>
								<TD width="20%"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="70px" Runat="server"></asp:textbox>
									&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD align="right" width="15%">
									<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton></TD>
								<TD width="10%"></TD>
							</TR>
							<TR>
								<TD colSpan="7"><asp:datagrid id="dgdDanhSach" CssClass="QH_Datagrid" Width="100%" Runat="server" AutoGenerateColumns="False"
										CellPadding="3" AllowPaging="True" AllowSorting="True" PageSize="20">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblStt Width="100%" runat="server" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>" cssclass="QH_ColLabelMiddle">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="30%"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink ID="moreLink" Runat="server" cssclass="QH_MenuLink" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLinhVuc") %>' NavigateUrl='<%# EditURL("Malv",DataBinder.Eval(Container.DataItem,"MaLinhVuc") & "&Tenlv=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLinhVuc")) & "&TuNgay=" & txtTuNgay.Text & "&DenNgay=" & txtDenNgay.Text,"LOAIHOSO") %>'>
													</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblTonTruoc" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TonTruoc") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblMoiNhan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.MoiNhan") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblDaHuy" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaHuy") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblDaGQDungHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQDungHan") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblDaGQQuaHan Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>' cssclass="QH_ColLabelMiddle" ForeColor="Red">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblChuaGQTrongHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQTrongHan") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblChuaGQQuaHan Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQQuaHan") %>' cssclass="QH_ColLabelMiddle" ForeColor="Red">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblBoTucHoSo" cssclass= "QH_ColLabelMiddle" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BoTucHoSo") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblDaTra" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaTra") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblChuaTra" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaTra") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Visible="False" BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</table>
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
