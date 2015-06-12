<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ND_ThongKeTongHop.ascx.vb" Inherits="THTT.ND_ThongKeTongHop" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popupcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD colSpan="6"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Tổng hợp kết quả đăng ký biến động về sử dụng đất</asp:label></TD>
	</TR>
	<TR>
		<TD colSpan="6" height="10"></TD>
	</TR>
	<TR>
		<TD align="center" width="90%" colSpan="5">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="80%" border="0">
				<TR>
					<TD class="QH_ColLabel" width="10%">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
					<TD class="QH_ColControl" width="22%"><asp:textbox id="txtTuNgay" Runat="server" Width="80px" CssClass="QH_TextBox"></asp:textbox>&nbsp;
						<asp:hyperlink id="cmdTuNgay" Runat="server" CssClass="CommandButton">
							<asp:image id="btnTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
					<TD class="QH_ColLabel" width="10%">Ðến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
					<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDenNgay" Runat="server" Width="80px" CssClass="QH_TextBox"></asp:textbox>&nbsp;
						<asp:hyperlink id="cmdDenNgay" Runat="server" CssClass="CommandButton">
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
		<TD colSpan="6"><asp:datagrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_Datagrid" PageSize="50"
				AutoGenerateColumns="False" CellPadding="3" AllowSorting="True" ShowFooter="True">
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
						<ItemStyle Width="40%"></ItemStyle>
						<ItemTemplate>
							<asp:label ID="lblTenLoaiHoSo" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLoaiHoSo") %>' >
							</asp:label>
						</ItemTemplate>
						<FooterStyle CssClass="QH_LabelRightBold"></FooterStyle>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplSLDaNhan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SLDaNhan")%>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongSLDaNhan" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplSLDaNhan",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblDIENTICHDANHAN" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIENTICHDANHAN")%>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongDienTichDaNhan" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"lblDIENTICHDANHAN",True)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id=hplSLDaChinhLy runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SLDaChinhLy") %>' >
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id=lblSLTongDaChinhLy CssClass="QH_LabelRightBold" Width="100%" Runat="server" Text='<%#GetTotal(dgdDanhSach,"hplSLDaChinhLy",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblDienTichDaChinhLy" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIENTICHDACHINHLY")%>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongDienDaChinhLy" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"lblDienTichDaChinhLy",True)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
	<TR>
		<TD colSpan="6" height="5"></TD>
	</TR>
</TABLE>
