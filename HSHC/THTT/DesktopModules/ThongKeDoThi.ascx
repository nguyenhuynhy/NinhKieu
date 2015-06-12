<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeDoThi.ascx.vb" Inherits="THTT.ThongKeDoThi" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/Common.js")%>'></script>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/popcalendar.js")%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
	<TR>
		<TD colspan="6"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Thống kê đô thị</asp:label></TD>
	</TR>
	<TR>
		<TD width="15%" height="30"></TD>
		<TD class="QH_ColLabel" width="10%">Từ ngày<font color="#ff0000" size="2">*</font></TD>
		<TD width="22%"><asp:textbox id="txtTuNgay" Runat="server" Width="80%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="btnTuNgay" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/Images/calendar.gif"></asp:image>
		</TD>
		<TD class="QH_ColLabel" width="10%">Đến ngày<font color="#ff0000" size="2">*</font></TD>
		<TD width="20%"><asp:textbox id="txtDenNgay" Runat="server" Width="80%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="btnDenNgay" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/Images/calendar.gif"></asp:image>
		</TD>
		<TD align="right" width="25%"><asp:imagebutton id="btnTimKiem" CssClass="QH_Button" ImageUrl="../../Images/btn_ThucHien.gif" runat="server"></asp:imagebutton></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="3" height="5"></TD>
	</TR>
	<TR>
		<TD colSpan="6"><asp:datagrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_Datagrid" PageSize="50"
				AutoGenerateColumns="False" CellPadding="3" AllowSorting="True">
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
							<asp:label ID="lblTen" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"Ten") %>' >
							</asp:label>
						</ItemTemplate>
						<FooterStyle CssClass="QH_LabelRightBold"></FooterStyle>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplKienCo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KienCo")%>' NavigateUrl='<%# replace(EditURL("SelectID",request.Params("SelectID") & "&Val=" & rtrim(DataBinder.Eval(Container.DataItem,"MaSoPH")) & "&SelectTitle=" & request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text  ,"DSDOTHI") & "&SelectIndex=" & request.params("SelectIndex").tostring() & "&Type=" & "" & "&Group=" & "12" ,"-1", Session("MidOfStartPage").tostring() & "&SelectChildIndex=" & request.params("SelectChildIndex").tostring() & "&SelectChildID=" & request.params("SelectChildID").tostring()) %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongKienCo" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplKienCo",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id=hplHCKienCo runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HCKienCo") %>' NavigateUrl='<%# replace(EditURL("SelectID",request.Params("SelectID") & "&Val=" & rtrim(DataBinder.Eval(Container.DataItem,"MaSoPH")) & "&SelectTitle=" & request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text  ,"DSDOTHI") & "&SelectIndex=" & request.params("SelectIndex").tostring() & "&Type=" & "HOANCONG" & "&Group=" & "12" ,"-1", Session("MidOfStartPage").tostring() & "&SelectChildIndex=" & request.params("SelectChildIndex").tostring() & "&SelectChildID=" & request.params("SelectChildID").tostring()) %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id=lblTongHCKienCo CssClass="QH_LabelRightBold" Width="100%" Runat="server" Text='<%#GetTotal(dgdDanhSach,"hplHCKienCo",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplBanKienCo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BanKienCo")%>' NavigateUrl='<%# replace(EditURL("SelectID",request.Params("SelectID") & "&Val=" & rtrim(DataBinder.Eval(Container.DataItem,"MaSoPH")) & "&SelectTitle=" & request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text  ,"DSDOTHI") & "&SelectIndex=" & request.params("SelectIndex").tostring() & "&Type=" & "" & "&Group=" & "11" ,"-1", Session("MidOfStartPage").tostring() & "&SelectChildIndex=" & request.params("SelectChildIndex").tostring() & "&SelectChildID=" & request.params("SelectChildID").tostring()) %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label ID="lblTongBanKienCo" Width="100%" Runat="server" CssClass="QH_LabelRightBold" Text='<%#GetTotal(dgdDanhSach,"hplBanKienCo",False)%>'>
							</asp:Label>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="9%" CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplHCBanKienCo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HCBanKienCo") %>' NavigateUrl='<%# replace(EditURL("SelectID",request.Params("SelectID") & "&Val=" & rtrim(DataBinder.Eval(Container.DataItem,"MaSoPH")) & "&SelectTitle=" & request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.text & "&DenNgay=" & txtDenNgay.Text  ,"DSDOTHI") & "&SelectIndex=" & request.params("SelectIndex").tostring() & "&Type=" & "HOANCONG" & "&Group=" & "11" ,"-1", Session("MidOfStartPage").tostring() & "&SelectChildIndex=" & request.params("SelectChildIndex").tostring() & "&SelectChildID=" & request.params("SelectChildID").tostring()) %>'>
							</asp:Hyperlink>
						</ItemTemplate>
						<FooterTemplate>
							<asp:Label id="lblTongHCBanKienCo" CssClass="QH_LabelRightBold" Width="100%" Runat="server" Text='<%#GetTotal(dgdDanhSach,"hplHCBanKienCo",False)%>'>
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
	<TR>
		<TD align="center" colSpan="6">
			<asp:ImageButton id="btnIn" CssClass="QH_Button" ImageUrl="../../Images/btn_In.gif" runat="server"
				Visible="True"></asp:ImageButton>
		</TD>
	</TR>
</TABLE>
