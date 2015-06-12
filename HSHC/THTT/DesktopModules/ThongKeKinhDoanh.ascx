<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeKinhDoanh.ascx.vb" Inherits="THTT.ThongKeKinhDoanh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
	<TR>
		<TD colspan="7"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Thống kê tình hình đăng ký kinh doanh</asp:label></TD>
	</TR>
	<TR id="trFilter1" runat="Server">
		<TD colspan="7" height="3"></TD>
	</TR>
	<TR id="trFilter" runat="Server">
		<TD width="15%"></TD>
		<TD class="QH_ColLabel" width="10%">Từ ngày<font color="#ff0000" size="2">*</font></TD>
		<TD width="22%" class="QH_ColControl"><asp:textbox id="txtTuNgay" Runat="server" Width="80%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>
			&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink>
		</TD>
		<TD class="QH_ColLabel" width="10%">Đến ngày<font color="#ff0000" size="2">*</font></TD>
		<TD width="20%" class="QH_ColControl"><asp:textbox id="txtDenNgay" Runat="server" Width="80%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>
			&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink>
		</TD>
		<TD align="right" width="15%"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Thực hiện</asp:linkbutton>
		</TD>
		<TD width="10%"></TD>
	</TR>
	<TR id="trFilter2" runat="Server">
		<TD align="right" colSpan="7" height="5"></TD>
	</TR>
	<TR>
		<TD colSpan="7" align=center><asp:datagrid id="dgdDanhSach" Runat="server" Width="95%" CssClass="QH_Datagrid" PageSize="50"
				AutoGenerateColumns="False" CellPadding="3" ShowFooter="True" AllowSorting="True">
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
						<ItemStyle Width="20%"></ItemStyle>
						<ItemTemplate>
							<asp:label ID="lblTen" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"Ten") %>' >
							</asp:label>
						</ItemTemplate>
						<FooterStyle CssClass="QH_LabelRightBold"></FooterStyle>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplSoLuongKD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SL08")%>' NavigateUrl='<%# GetMidURL("SelectID",request.Params("SelectID") & "&Val=" & rtrim(DataBinder.Eval(Container.DataItem,"Ma")) & "&SelectTitle=" & request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text  ,"DSHOKD") & "&Group=" & "SL08"  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongSoLuongKD" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplSoLuongKD",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id=hplVonKD runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VON08") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id=lblTongVonKD CssClass="QH_LabelRightBold" Width="100%" Runat="server" Text='<%# replace(Format(CDbl(GetTotal(dgdDanhSach,"hplVonKD",False)),"##,##0.00"),glbTHOUSANDS_SEPERATOR,glbDECIMAL_SEPERATOR)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplSoLuongHD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SLHOATDONG") %>' NavigateUrl='<%# GetMidURL("SelectID",request.Params("SelectID") & "&Val=" & rtrim(DataBinder.Eval(Container.DataItem,"Ma")) & "&SelectTitle=" & request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text  ,"DSHOKD") & "&Group=" & "SLHD" %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongSoLuongHD" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplSoLuongHD",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id=hplVonHD runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VONHOATDONG") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id=lblTongVonHD CssClass="QH_LabelRightBold" Width="100%" Runat="server" Text='<%#replace(Format(CDbl(GetTotal(dgdDanhSach,"hplVonHD",False)),"##,##0.00"),glbTHOUSANDS_SEPERATOR,glbDECIMAL_SEPERATOR)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplSoLuongNKD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SLNGUNG") %>' NavigateUrl='<%# GetMidURL("SelectID",request.Params("SelectID") & "&Val=" & rtrim(DataBinder.Eval(Container.DataItem,"Ma")) & "&SelectTitle=" & request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text  ,"DSHOKD") & "&Group=" & "NGUNG"  %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongSoLuongNKD" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplSoLuongNKD",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplVonNKD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VONNGUNG") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongVonNKD" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#replace(Format(CDbl(GetTotal(dgdDanhSach,"hplVonNKD",False)),"##,##0.00"),glbTHOUSANDS_SEPERATOR,glbDECIMAL_SEPERATOR)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
	<TR>
		<TD colSpan="7" height="5"></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="7">
			<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
		</TD>
	</TR>
</TABLE>
