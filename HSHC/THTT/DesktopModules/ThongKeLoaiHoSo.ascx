<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeLoaiHoSo.ascx.vb" Inherits="THTT.ThongKeLoaiHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblLinhVuc" cssclass="QH_Label_Title" Width="100%" Runat="server"></asp:label>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
							<tr>
								<td height="2">
								</td>
							</tr>
							<TR>
								<TD width="15%"></TD>
								<TD class="QH_ColLabel" width="10%">Từ ngày<font size="2" color="#ff0000">*</font></TD>
								<TD class="QH_ColControl" width="22%"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="80%" Runat="server"></asp:textbox>
									&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD class="QH_ColLabel" width="10%">Ðến ngày<font size="2" color="#ff0000">*</font></TD>
								<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="80%" Runat="server"></asp:textbox>
									&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD width="25%" align="right">
									<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD colSpan="6" align="right" height="5">
								</TD>
							</TR>
							<TR>
								<TD colspan="6">
									<asp:DataGrid ID="dgdDanhSach" Runat="server" CssClass="QH_Datagrid" AllowSorting="True" AllowPaging="True"
										Width="100%" CellPadding="3" AutoGenerateColumns="False" ShowHeader="true" ShowFooter="True"
										PageSize="50" HorizontalAlign="Center">
										<EditItemStyle HorizontalAlign="Center"></EditItemStyle>
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
												<ItemStyle Width="7%" HorizontalAlign="Center" ></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="lblTongNhan" CssClass="QH_ColLabelMiddle" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TongNhan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TONGNHAN" ,"DSHOSO") %>'>
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
													<asp:Hyperlink id="lblNgayThuBay" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NgayThuBay") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=THUBAY" ,"DSHOSO") %>'>
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
													<asp:Hyperlink id="lblDaGQTruocHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQTruocHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TRUOCHAN" ,"DSHOSO") %>'>
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
													<asp:Hyperlink id="lblDaGQDungHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQDungHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DUNGHAN" ,"DSHOSO") %>'>
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
													<asp:Hyperlink id="lblDaGQQuaHan" cssclass= "QH_ColLabelMiddle" Width="100%" ForeColor="red" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TREHEN" ,"DSHOSO") %>'>
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
												<ItemStyle Width="6%"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="lblChuaGQTrongHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQTrongHan") %>' NavigateUrl='<%# GetMidURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DANGGIAIQUYET" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="Label9" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblChuaGQTrongHan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="3%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblGQQuaHan" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.GQQuaHan") %>' ForeColor="red">
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="Labe12" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"lblGQQuaHan",False)%>' ForeColor="red">
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="5%"></ItemStyle>
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
									</asp:DataGrid>
								</TD>
							</TR>
							<TR>
								<TD colSpan="6" height="5"></TD>
							</TR>
							<TR>
								<TD colSpan="6" align="center">
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
