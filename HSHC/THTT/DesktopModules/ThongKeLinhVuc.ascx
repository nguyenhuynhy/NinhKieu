<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeLinhVuc.ascx.vb" Inherits="THTT.ThongKeLinhVuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid">
						<asp:label id="lblTieuDe" Runat="server" CssClass="QH_Label_Title" Width="100%">Tình hình gi?i quy?t h? so hành chính</asp:label>
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
							<tr>
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="15%"></TD>
								<TD class="QH_ColLabel" width="12%">T? ngày<font size="2" color="#ff0000">*</font></TD>
								<TD width="22%" class="QH_ColControl"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="60%" Runat="server"></asp:textbox>
									&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD class="QH_ColLabel" width="12%">Ð?n ngày<font size="2" color="#ff0000">*</font></TD>
								<TD width="20%" class="QH_ColControl"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="60%" Runat="server"></asp:textbox>
									&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD align="right" width="15%">
									<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Th?c hi?n</asp:linkbutton></TD>
								<TD width="10%"></TD>
							</TR>
							<tr>
								<td colspan="7">&nbsp;</td>
							</tr>
							<TR>
								<TD colSpan="7"><asp:datagrid id="dgdDanhSach" CssClass="QH_Datagrid" Width="100%" Runat="server" ShowHeader="True"
										AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" AllowSorting="True" ShowFooter="True">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<EditItemStyle CssClass="QH_DatagridHeader1"></EditItemStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle Width="50px"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblStt Width="100%" runat="server" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>" cssclass="QH_ColLabelMiddle">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn FooterText="T?NG C?NG">
												<ItemStyle Width="260px"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink ID="moreLink" Runat="server" cssclass="QH_MenuLink" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLinhVuc") %>' NavigateUrl='<%# GetMidURL("Malv",DataBinder.Eval(Container.DataItem,"MaLinhVuc") & "&Tenlv=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLinhVuc")) ,"LOAIHOSO") %>'>
													</asp:HyperLink>
												</ItemTemplate>
												<FooterStyle CssClass="QH_ColLabelMiddle"></FooterStyle>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblTongNhan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TongNhan") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongTongNhan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblTongNhan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblNgayThuBay" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NgayThuBay") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongNgayThuBay" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblNgayThuBay",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblTongDaGiaiQuyet" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TongDaGiaiQuyet") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongTongDaGiaiQuyet" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblTongDaGiaiQuyet",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblDaGQTruocHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQTruocHan") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongDaGiaiQuyetDungHan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblDaGQTruocHan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblTyLeTruocHan Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TyLeTruocHan") %>' cssclass="QH_ColLabelMiddle">
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongTyLeTruocHan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%# Math.Round(100*GetTotal(dgdDanhSach,"lblDaGQTruocHan",False)/GetTotal(dgdDanhSach,"lblTongDaGiaiQuyet",False),2) %>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblDaGQDungHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQDungHan") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongDaGQDungHan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblDaGQDungHan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblTyLeDungHan Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TyLeDungHan") %>' cssclass="QH_ColLabelMiddle">
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongTyLeDungHan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%# Math.Round(100*GetTotal(dgdDanhSach,"lblDaGQDungHan",False)/GetTotal(dgdDanhSach,"lblTongDaGiaiQuyet",False),2)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblDaGQQuaHan" cssclass= "QH_ColLabelMiddle" Width="100%" ForeColor="red" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="Label7" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblDaGQQuaHan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblTyLeQuaHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TyLeQuaHan") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="Label8" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%# Math.Round(100*(GetTotal(dgdDanhSach,"lblTongDaGiaiQuyet",False)-GetTotal(dgdDanhSach,"lblDaGQTruocHan",False)-GetTotal(dgdDanhSach,"lblDaGQDungHan",False))/GetTotal(dgdDanhSach,"lblTongDaGiaiQuyet",False),2) %>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblChuaGQTrongHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQTrongHan") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="Label9" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblChuaGQTrongHan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblGhiChu" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.GhiChu") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="Label11" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text=''></asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</table>
					</td>
					<td width="16" class="QH_Khung_Right">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr>
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
