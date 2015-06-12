<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_ThongKeLinhVuc.ascx.vb" Inherits="THTT.VPHC_ThongKeLinhVuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<DIV align="center">
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
		<TR>
			<TD colSpan="6"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server">Tình hình giải quyết hồ sơ vi phạm hành chính</asp:label></TD>
		</TR>
		<TR>
			<TD colSpan="6" height="10"></TD>
		</TR>
		<TR>
			<TD align="center" width="90%" colSpan="5">
				<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="80%" border="0">
					<TR>
						<TD class="QH_ColLabel" width="10%">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
						<TD class="QH_ColControl" width="22%"><asp:textbox id="txtTuNgay" Width="80px" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;
							<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
								<asp:image id="btnTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
							</asp:hyperlink></TD>
						<TD class="QH_ColLabel" width="10%">Ðến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
						<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDenNgay" Width="80px" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;
							<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
								<asp:image id="btnDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
							</asp:hyperlink></TD>
					</TR>
				</TABLE>
			</TD>
			<TD align="left" width="10%"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Thực hiện</asp:linkbutton></TD>
		</TR>
		<TR>
			<TD colSpan="6" height="10"></TD>
		</TR>
		<TR>
			<TD colSpan="6" align=center><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" runat="server" AllowSorting="True" CellPadding="3"
					AutoGenerateColumns="False" ShowFooter="True" width="95%">
					<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
					<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="STT">
							<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
							<ItemTemplate>
								<asp:Label width="100%" align="center" id="Label1" runat="server" Text='     <%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Ph&#242;ng ban" FooterText="TỔNG CỘNG">
							<ItemStyle Width="20%"></ItemStyle>
							<ItemTemplate>
								<asp:Label id="Label2" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TenDonVi") %>'>
								</asp:Label>
							</ItemTemplate>
							<FooterStyle CssClass="QH_LabelRightBold"></FooterStyle>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Số bi&#234;n bản">
							<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplLapBienBan" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SoBienBan")%>' NavigateUrl='<%# GetMidURL("MaDonVi",DataBinder.Eval(Container.DataItem,"MaDonVi")&"&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&LoaiHoSo=SOBIENBAN" &"&TenDonVi="&DataBinder.Eval(Container, "DataItem.TenDonVi") ,"VPHC_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label ID="ttTongLapBienBan" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplLapBienBan",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Số QĐ soạn thảo">
							<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplSoQuyetDinhSoanThao" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SoQuyetDinh")%>' NavigateUrl='<%# GetMidURL("MaDonVi",DataBinder.Eval(Container.DataItem,"MaDonVi")&"&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&LoaiHoSo=SOQUYETDINH" &"&TenDonVi="&DataBinder.Eval(Container, "DataItem.TenDonVi") ,"VPHC_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label ID="lblTongRaQuyetDinh" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplSoQuyetDinh",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Số QĐ đ&#227; thi h&#224;nh">
							<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplSoQuyetDinhThiHanh" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SoQuyetDinhDaThiHanh")%>' NavigateUrl='<%# GetMidURL("MaDonVi",DataBinder.Eval(Container.DataItem,"MaDonVi")&"&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&LoaiHoSo=SOQUYETDINH" &"&TenDonVi="&DataBinder.Eval(Container, "DataItem.TenDonVi") ,"VPHC_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label ID="lblTongThiHanhQuyetDinh" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplSoQuyetDinhThiHanh",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Số QĐ cưỡng chế">
							<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplSoQuyetDinhCuongChe" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SoQuyetDinhCuongChe")%>' NavigateUrl='<%# GetMidURL("MaDonVi",DataBinder.Eval(Container.DataItem,"MaDonVi")&"&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&LoaiHoSo=SOQUYETDINHCUONGCHE" &"&TenDonVi="&DataBinder.Eval(Container, "DataItem.TenDonVi") ,"VPHC_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
							<FooterTemplate>
								<asp:Label ID="lblTongQuyetDinhCuongChe" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplQuyetDinhCuongChe",False)%>'>
								</asp:Label>
							</FooterTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<P align="center">&nbsp;</P>
			</TD>
		</TR>
	</TABLE>
</DIV>
