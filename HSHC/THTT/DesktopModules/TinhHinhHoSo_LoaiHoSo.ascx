<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TinhHinhHoSo_LoaiHoSo.ascx.vb" Inherits="THTT.TinhHinhHoSo_LoaiHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/Common.js")%>'></script>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/popcalendar.js")%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
	<TR>
		<TD colspan="6"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Tình hình giải quyết hồ sơ hành chính</asp:label></TD>
	</TR>
	<TR>
		<TD colspan="6"><asp:label id="Label1" Runat="server" Width="100%" CssClass="QH_Label"></asp:label></TD>
	</TR>
	<TR>
		<TD width="15%"></TD>
		<TD class="QH_ColLabel" width="10%">Từ ngày<font size="2" color="#ff0000">*</font></TD>
		<TD width="22%"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="65%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:image id="btnTuNgay" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
		</TD>
		<TD class="QH_ColLabel" width="10%">Ðến ngày<font size="2" color="#ff0000">*</font></TD>
		<TD width="20%"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="65%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:image id="btnDenNgay" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
		</TD>
		<TD width="25%" align="right">
			<asp:ImageButton id="btnTimKiem" CssClass="QH_Button" ImageUrl="../../Images/btn_ThucHien.gif" runat="server"></asp:ImageButton></TD>
	</TR>
	<TR>
		<TD height="3" colspan="6"></TD>
	</TR>
	<TR>
		<TD colSpan="6" align="right">
			<asp:Label ID="Label4" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:Label>
			<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextBox" Width="25px"
				MaxLength="3"></asp:TextBox>
		</TD>
	</TR>
	<TR>
		<TD colspan="6">
			<asp:DataGrid ID="dgdDanhSach" Runat="server" CssClass="QH_Datagrid" AllowSorting="True" Width="100%"
				CellPadding="3" AutoGenerateColumns="False" ShowFooter="True" AllowPaging="True">
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
							<asp:label ID="lblTenLoaiHoSo" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLoaiCP") %>' >
							</asp:label>
						</ItemTemplate>
						<FooterStyle CssClass="QH_LabelRightBold"></FooterStyle>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id=hplTonTruoc runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TonTruoc") %>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=TONTRUOC" ,"DSHOSO") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id="lblTongTonTruoc" Runat="server" Width="100%" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplTonTruoc",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplMoiNhan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MoiNhan")%>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=MOINHAN" ,"DSHOSO")  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongMoiNhan" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplMoiNhan",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplDaGQDungHan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaGiaiQuyet")%>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DAGIAIQUYET" ,"DSHOSO")  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongDaGQDungHan" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplDaGQDungHan",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id=hplDaGQQuaHan runat="server" ForeColor="Red" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DAGQQUAHAN" ,"DSHOSO")  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id="lblTongDaGQQuaHan" Runat="server" Width="100%" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplDaGQQuaHan",False)%>' ForeColor="Red">
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplPTDaGQ" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PTDAGQ") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongPTDAGQ" Width="100%" Runat="server" CssClass="QH_LabelRightBold"></asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplChuaGQTrongHan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQ") %>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=CHUAGQ" ,"DSHOSO")  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongChuaGQTrongHan" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplChuaGQTrongHan",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id=hplChuaGQQuaHan runat="server" ForeColor="Red" Text='<%# DataBinder.Eval(Container, "DataItem.QuaHan") %>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=QUAHAN" ,"DSHOSO")  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id="lblTongChuaGQQuaHan" Runat="server" Width="100%" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplChuaGQQuaHan",False)%>' ForeColor="Red">
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplPTCHUAGQ" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PTCHUAGQ") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongPTCHUAGQ" Width="100%" Runat="server" CssClass="QH_LabelRightBold"></asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplDaTra" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DaTra") %>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=DATRA" ,"DSHOSO")  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongDaTra" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplDaTra",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplChuaTra" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaTra") %>' NavigateUrl='<%# GetMidURL("SelectTitle", request.Params("SelectTitle") & "&MaSoLHCP=" & DataBinder.Eval(Container.DataItem,"MaSoLHCP") & "&TenLoaiCP=" & DataBinder.Eval(Container.DataItem,"TenLoaiCP") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text & "&Loai=CHUATRA" ,"DSHOSO")  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongChuaTra" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplChuaTra",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplPTTRA" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PTTRA") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblPTTRA" Width="100%" Runat="server" CssClass="QH_LabelRightBold"></asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</TD>
	</TR>
	<TR>
		<TD align="center" colSpan="6">
			<asp:ImageButton id="btnTroVe" CssClass="QH_Button" ImageUrl="../../Images/btn_TroVe.gif" runat="server"
				Visible="False"></asp:ImageButton>
			<asp:ImageButton id="btnIn" CssClass="QH_Button" ImageUrl="../../Images/btn_In.gif" runat="server"
				Visible="True"></asp:ImageButton>
		</TD>
	</TR>
</TABLE>
