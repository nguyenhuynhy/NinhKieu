<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="QLHT_ThongKeHoSo.ascx.vb" Inherits="THTT.QLHT_ThongKeHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TBODY>
		<TR>
			<TD colSpan="6"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Tình hình quản lý hộ tịch</asp:label></TD>
		</TR>
		<TR>
			<TD colSpan="6" height="10"></TD>
		</TR>
		<TR>
			<TD width="15%"></TD>
			<TD class="QH_ColLabel" width="10%">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
			<TD class="QH_ColControl" width="22%"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="80%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
					<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
				</asp:hyperlink>
			</TD>
			<TD class="QH_ColLabel" width="10%">Ðến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
			<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="80%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
					<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
				</asp:hyperlink>
			</TD>
			<TD align="right" width="15%"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Thực hiện</asp:linkbutton></TD>
			<TD width="10%"></TD>
		</TR>
		<TR>
			<TD align="right" colSpan="6" height="5"></TD>
		</TR>
		<TR>
			<TD align="right" colSpan="6"><asp:label id="Label4" CssClass="QH_Label" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextBox" Width="25px" Runat="server" MaxLength="2" AutoPostBack="True"></asp:textbox></TD>
		</TR>
		<TR>
			<TD colSpan="6"><asp:datagrid id="dgdDanhSach" CssClass="QH_Datagrid" Width="100%" Runat="server" AllowSorting="True"
					AllowPaging="True" CellPadding="3" AutoGenerateColumns="False" ShowHeader="true" ShowFooter="True">
					<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
					<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
					<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="STT">
							<ItemStyle width="5%"></ItemStyle>
							<ItemTemplate>
								<asp:Label Width=100% id="lblStt" runat="server" cssclass= "QH_ColLabelMiddle" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>">
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn FooterText="TỔNG CỘNG" HeaderText="Loại hồ sơ">
							<ItemStyle width="25%"></ItemStyle>
							<ItemTemplate>
								<asp:Label Width=100% ID="lblTenLoaiHoSo" Runat="server" cssclass="QH_ColLabelLeft" Text='<%# DataBinder.Eval(Container.DataItem,"TenKhuVuc") %>' >
								</asp:Label>
							</ItemTemplate>
							<FooterStyle CssClass="QH_LabelRightBold"></FooterStyle>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemStyle width="5%" BackColor="#eaffff" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplKhaiSinh" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KhaiSinh") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=KHAISINH", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongKhaiSinh" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplKhaiSinh",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplKhaiSinh_BS" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KhaiSinh_BS") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=KHAISINH_BS", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongKhaiSinh_BS" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplKhaiSinh_BS",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemStyle width="5%" HorizontalAlign="Right" BackColor="#eaffff"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplKhaiTu" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KhaiTu") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=KHAITU", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongKhaiTu" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplKhaiTu",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplKhaiTu_BS" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KhaiTu_BS") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=KhaiTu_BS", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongKhaiTu_BS" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplKhaiTu_BS",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right" BackColor="#eaffff"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplKetHon" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KetHon") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=KETHON", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongKetHon" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplKetHon",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplKetHon_BS" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KetHon_BS") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=KetHon_BS", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongKetHon_BS" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplKetHon_BS",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right" BackColor="#eaffff"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplNCN" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NhanNuoiConNuoi") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=NHANNUOICONNUOI", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="hplTongNCN" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplNCN",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplNCN_BS" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NhanNuoiConNuoi_BS") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=NhanNuoiConNuoi_BS", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="hplTongNCN_BS" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplNCN_BS",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right" BackColor="#eaffff"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplCMC" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NhanChaMeCon") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=NHANCHAMECON", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongCMC" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplCMC",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplCMC_BS" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NhanChaMeCon_BS") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=NhanChaMeCon_BS", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongCMC_BS" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplCMC_BS",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Nhận giám hộ">
							<ItemStyle width="5%" HorizontalAlign="Right" BackColor="#eaffff"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplNGH" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NhanGiamHo") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=NHANGIAMHO", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongNGH" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplNGH",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplNGH_BS" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NhanGiamHo_BS") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=NhanGiamHo_BS", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongNGH_BS" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplNGH_BS",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Chấm dứt giám hộ">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplChamDutGiamHo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChamDutGiamHo") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=CHAMDUTGIAMHO", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongChamDutGiamHo" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplChamDutGiamHo",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Giấy chứng nhận">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplChungNhan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChungNhan") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=CHUNGNHAN", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongChungNhan" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplChungNhan",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Chứng nhận mất bộ">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplChungNhanMB" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChungNhanMB") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=CHUNGNHANMB", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongChungNhanMB" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplChungNhanMB",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Thông báo sót bộ">
							<ItemStyle width="5%" HorizontalAlign="Right"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplThongBaoSotBo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ThongBaoSotBo") %>' NavigateUrl='<%# GetMidURL("MaKhuVuc",DataBinder.Eval(Container, "DataItem.MaKhuVuc") & "&Loai=THONGBAOSOTBO", "QLHT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label Width=100% ID="lblTongThongBaoSotBo" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplThongBaoSotBo",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid></TD>
		</TR>
		<TR>
			<TD colSpan="6" height="5"></TD>
		</TR>
		<TR>
			<TD align="center" colSpan="6"><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server" Visible="False">Trở về</asp:linkbutton><asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton></TD>
		</TR>
	</TBODY></TABLE>
</TR></TBODY></TABLE>
