<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeLinhVucPhuong.ascx.vb" Inherits="THTT.ThongKeLinhVucPhuong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="cc2" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD height="24" width="100%">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_TopLeft" height="24" width="16"></td>
					<td class="QH_Khung_TopMid"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server">TÌNH HÌNH GI?I QUY?T H? SO HÀNH CHÍNH PHU?NG</asp:label></td>
					<td class="QH_Khung_TopRight" height="24" width="16"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td>
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD height="44" width="15%"></TD>
								<TD class="QH_ColLabel" height="44" width="12%">T? ngày<font color="#ff0000" size="2">*</font></TD>
								<TD class="QH_ColControl" height="44" width="22%"><asp:textbox id="txtTuNgay" Width="60%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD class="QH_ColLabel" height="44" width="12%">Ð?n ngày<font color="#ff0000" size="2">*</font></TD>
								<TD class="QH_ColControl" height="44" width="20%"><asp:textbox id="txtDenNgay" Width="60%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD height="44" width="15%" align="right"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Th?c hi?n</asp:linkbutton></TD>
								<TD height="44" width="10%"><asp:textbox style="Z-INDEX: 0" id="txtNguoiXemBaoCao" Width="0px" CssClass="QH_TextBox" Runat="server"
										Height="0px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="15%"></TD>
								<TD class="QH_ColLabel" width="12%">Tên phu?ng<font color="#ff0000" size="2">*</font></TD>
								<TD class="QH_ColControl" width="22%"><cc2:keysortdropdownlist id="ddlMaPhuong" Width="98%" CssClass="QH_DropDownList" runat="server"></cc2:keysortdropdownlist></TD>
								<td class="QH_ColLabel" colspan="2"></td>
								<TD></TD>
								<TD></TD>
							</TR>
							<tr>
								<td colSpan="7">&nbsp;</td>
							</tr>
							<TR>
								<TD colSpan="7"><asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_Datagrid" Runat="server" ShowFooter="True"
										AllowSorting="True" AllowPaging="True" CellPadding="3" AutoGenerateColumns="False" ShowHeader="True">
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
													<asp:HyperLink ID="moreLink" Runat="server" cssclass="QH_MenuLink" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLinhVuc") %>' NavigateUrl='<%# GetMidURL("Malv",DataBinder.Eval(Container.DataItem,"MaLinhVuc") & "&Tenlv=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLinhVuc")) & "&MaPhuong=" & (DataBinder.Eval(Container.DataItem,"MaPhuong")) ,"LOAIHOSOPHUONG") %>'>
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
													<asp:Label id="lblDaGQQuaHan" cssclass= "QH_ColLabelMiddle" style="color:red;" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>'>
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
					<td class="QH_Khung_Right" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
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
	<tr>
		<td>
			<asp:textbox id="txtMaPhuong" Width="0px" AutoPostBack="False" runat="server" Visible="False"
				CssClass="QH_Textbox"></asp:textbox>
		</td>
	</tr>
</TABLE>
