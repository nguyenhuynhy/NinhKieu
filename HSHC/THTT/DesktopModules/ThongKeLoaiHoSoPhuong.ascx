<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeLoaiHoSoPhuong.ascx.vb" Inherits="THTT.ThongKeLoaiHoSoPhuong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD height="24" width="100%">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_TopLeft" height="24" width="16"></td>
					<td class="QH_Khung_TopMid"><asp:label id="lblLinhVuc" Runat="server" Width="100%" cssclass="QH_Label_Title"></asp:label></td>
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
						<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="5" width="100%">
							<tr>
								<td height="2"></td>
							</tr>
							<TR>
								<TD width="15%"></TD>
								<TD class="QH_ColLabel" width="10%">Từ ngày<font color="#ff0000" size="2">*</font></TD>
								<TD class="QH_ColControl" width="22%"><asp:textbox id="txtTuNgay" Runat="server" Width="80%" CssClass="QH_TextBox"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" Runat="server" CssClass="CommandButton">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD class="QH_ColLabel" width="10%">Ðến ngày<font color="#ff0000" size="2">*</font></TD>
								<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDenNgay" Runat="server" Width="80%" CssClass="QH_TextBox"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" Runat="server" CssClass="CommandButton">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD width="25%" align="right"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD height="5" colSpan="6" align="right"></TD>
							</TR>
							<TR>
								<TD colSpan="6"><asp:datagrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_Datagrid" PageSize="30"
										ShowFooter="True" ShowHeader="true" AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" AllowSorting="True">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle Width="50px"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblStt Width="100%" runat="server" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>" cssclass="QH_ColLabelMiddle">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn FooterText="TỔNG CỘNG">
												<ItemStyle Width="260px"></ItemStyle>
												<ItemTemplate>
													<asp:label ID="lblTenLoaiHoSo" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLoaiHoSo") %>' >
													</asp:label>
												</ItemTemplate>
												<FooterStyle CssClass="QH_ColLabelMiddle"></FooterStyle>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="lblTongNhan" CssClass="QH_ColLabelMiddle" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TongNhan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") &  "&MaPhuong=" & request.Params("MaPhuong") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TONGNHAN" ,"DSHOSOPHUONG") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongTongNhan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblTongNhan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="lblNgayThuBay" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NgayThuBay") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaPhuong=" & request.Params("MaPhuong") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=THUBAY" ,"DSHOSOPHUONG") %>'>
													</asp:Hyperlink>
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
													<asp:Hyperlink id="lblDaGQTruocHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQTruocHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaPhuong=" & request.Params("MaPhuong") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TRUOCHAN" ,"DSHOSOPHUONG") %>'>
													</asp:Hyperlink>
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
													<asp:Hyperlink id="lblDaGQDungHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQDungHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaPhuong=" & request.Params("MaPhuong") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DUNGHAN" ,"DSHOSOPHUONG") %>'>
													</asp:Hyperlink>
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
													<asp:Hyperlink id="lblDaGQQuaHan" cssclass= "QH_ColLabelMiddle" Width="100%" ForeColor="red" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaPhuong=" & request.Params("MaPhuong") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TREHEN" ,"DSHOSOPHUONG") %>'>
													</asp:Hyperlink>
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
													<asp:Hyperlink id="lblChuaGQTrongHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQTrongHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaPhuong=" & request.Params("MaPhuong") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DANGGIAIQUYET" ,"DSHOSOPHUONG") %>'>
													</asp:Hyperlink>
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
									</asp:datagrid><asp:textbox style="Z-INDEX: 0" id="txtNguoiXemBaoCao" Runat="server" Width="0px" CssClass="QH_TextBox"
										Height="0px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD height="5" colSpan="6"></TD>
							</TR>
							<TR>
								<TD colSpan="6" align="center"><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
							</TR>
						</TABLE>
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
</TABLE>
