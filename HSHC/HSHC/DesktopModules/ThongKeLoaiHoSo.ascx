<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeLoaiHoSo.ascx.vb" Inherits="HSHC.ThongKeLoaiHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
								<TD class="QH_ColControl" width="22%"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="70px" Runat="server"></asp:textbox>
									&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink>
								</TD>
								<TD class="QH_ColLabel" width="10%">Đến ngày<font size="2" color="#ff0000">*</font></TD>
								<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="70px" Runat="server"></asp:textbox>
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
										Width="100%" CellPadding="3" AutoGenerateColumns="False" ShowHeader="true" ShowFooter="True">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle Width="7%"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblStt" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn FooterText="TỔNG CỘNG">
												<ItemStyle Width="30%"></ItemStyle>
												<ItemTemplate>
													<asp:label ID="lblTenLoaiHoSo" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLoaiHoSo") %>' >
													</asp:label>
												</ItemTemplate>
												<FooterStyle CssClass="QH_ColLabelMiddle"></FooterStyle>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplTonTruoc" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TonTruoc") %>' NavigateUrl='<%# EditURL("Malv", request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TONTRUOC" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongTonTruoc" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplTonTruoc",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplMoiNhan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MoiNhan") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=MOINHAN" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongMoiNhan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplMoiNhan",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplDaHuy" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaHuy") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DAHUY" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongDaHuy" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplDaHuy",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplDaGQDungHan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQDungHan") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DAGQDUNGHAN" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongDaGQDungHan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplDaGQDungHan",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id=hplDaGQQuaHan runat="server" ForeColor="Red" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") &amp; "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DAGQQUAHAN" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label id=lblTongDaGQQuaHan Runat="server" Width="100%" CssClass="QH_ColLabelMiddle" ForeColor="Red" Text='<%#GetTotal(dgdDanhSach,"hplDaGQQuaHan",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplChuaGQTrongHan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQTrongHan") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=CHUAGQTRONGHAN" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongChuaGQTrongHan" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplChuaGQTrongHan",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id=hplChuaGQQuaHan runat="server" ForeColor="Red" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQQuaHan") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=CHUAGQQUAHAN" ,"DSHOSOQUAHAN") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label id=lblTongChuaGQQuaHan Runat="server" Width="100%" CssClass="QH_ColLabelMiddle" ForeColor="Red" Text='<%#GetTotal(dgdDanhSach,"hplChuaGQQuaHan",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplBoTucHoSo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BoTucHoSo") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=BOTUCHOSO" ,"DSHOSO") %>' >
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongChoBS" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplBoTucHoSo",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplDaTra" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaTra") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DATRA" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongDaTra" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplDaTra",False)%>'>
													</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="7%" cssclass="QH_ColLabelMiddle"></ItemStyle>
												<ItemTemplate>
													<asp:Hyperlink id="hplChuaTra" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaTra") %>' NavigateUrl='<%# EditURL("Malv",request.Params("Malv") & "&Tenlv=" & request.Params("Tenlv") & "&MaLHS=" & DataBinder.Eval(Container.DataItem,"MaLoaiHoSo") & "&TenLHS=" & EncryptText(DataBinder.Eval(Container.DataItem,"TenLoaiHoSo")) & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=CHUATRA" ,"DSHOSO") %>'>
													</asp:Hyperlink>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label ID="lblTongChuaTra" Width="100%" Runat="server" CssClass="QH_ColLabelMiddle" Text='<%#GetTotal(dgdDanhSach,"hplChuaTra",False)%>'>
													</asp:Label>
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
