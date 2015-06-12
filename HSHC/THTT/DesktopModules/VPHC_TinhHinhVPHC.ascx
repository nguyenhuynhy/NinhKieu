<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_TinhHinhVPHC.ascx.vb" Inherits="THTT.VPHC_TinhHinhVPHC" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/Common.js")%>'></script>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/popcalendar.js")%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
	<TR>
		<TD colSpan="7" height="19">
			<asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Tình hình xử lý vi phạm hành chính</asp:label></TD>
	</TR>
	<TR>
		<TD colSpan="7" height="10"></TD>
	</TR>
	<TR>
		<TD width="10%"></TD>
		<TD class="QH_ColLabel" width="10%">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
		<TD width="20%">
			<asp:textbox id="txtTuNgay" Runat="server" Width="80%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>
			<asp:image id="btnTuNgay" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
		<TD class="QH_ColLabel" width="10%">Ðến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
		<TD width="20%">
			<asp:textbox id="txtDenNgay" Runat="server" Width="80%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>
			<asp:image id="btnDenNgay" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
		<TD align="right" width="20%" colspan="2">
			<asp:imagebutton id="btnTimKiem" CssClass="QH_Button" ImageUrl="../../Images/btn_ThucHien.gif" runat="server"></asp:imagebutton></TD>
	</TR>
	<TR>
		<TD colSpan="7" height="10"></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="7">
			<asp:Label id="Label4" CssClass="QH_Label" Runat="server">Số dòng hiển thị</asp:Label>
			<asp:TextBox id="txtSoDong" CssClass="QH_TextBox" Width="25px" Runat="server" AutoPostBack="True"
				MaxLength="2"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="7">
			<asp:DataGrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_Datagrid" AllowSorting="True"
				AllowPaging="True" CellPadding="3" AutoGenerateColumns="False" ShowFooter="True">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="STT">
						<ItemStyle Width="5%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblStt" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Loại hồ sơ">
						<ItemStyle Width="20%"></ItemStyle>
						<ItemTemplate>
							<asp:label ID="lblTenLoaiHoSo" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"LoaiHoSo") %>' >
							</asp:label>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="Label3" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='Tổng cộng'></asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Lập biên bản">
						<ItemStyle Width="10%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="Hyperlink3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LapBB") %>' NavigateUrl='<%# GetMidURL("DB",DataBinder.Eval(Container.DataItem,"DB") & "&Loai=LAPBB" ,"VPHC_DSHOSO") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="Label2" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"Hyperlink3",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Ra quyết định">
						<ItemStyle Width="10%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RaQD") %>' NavigateUrl='<%# GetMidURL("DB",DataBinder.Eval(Container.DataItem,"DB") & "&Loai=RAQD" ,"VPHC_DSHOSO") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="Label1" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"Hyperlink1",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Thi hành quyết định">
						<ItemStyle Width="10%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ThiHanh") %>' NavigateUrl='<%# GetMidURL("DB",DataBinder.Eval(Container.DataItem,"DB") & "&Loai=THIHANH" ,"VPHC_DSHOSO") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblThiHanh" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"Hyperlink2",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Số tiền">
						<ItemStyle Width="10%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblSoTien" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoTien") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongTien" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"lblSoTien",true)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid></TD>
	<TR>
		<TD align="center" colSpan="7">
			<asp:ImageButton id="btnTroVe" CssClass="QH_Button" ImageUrl="../../Images/btn_TroVe.gif" runat="server"
				Visible="False"></asp:ImageButton>
			<asp:ImageButton id="btnIn" CssClass="QH_Button" ImageUrl="../../Images/btn_In.gif" runat="server"
				Visible="True"></asp:ImageButton>
		</TD>
	</TR>
</TABLE>
