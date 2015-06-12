<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CP_ThongKeTongHop.ascx.vb" Inherits="THTT.CP_ThongKeTongHop" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/Common.js")%>'></script>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/popcalendar.js")%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="15%"></TD>
		<TD class="QH_ColLabel" width="10%">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
		<TD width="22%"><asp:textbox id="txtTuNgay" Runat="server" Width="65%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="btnTuNgay" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
		<TD class="QH_ColLabel" width="10%">Đến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
		<TD width="20%"><asp:textbox id="txtDenNgay" Runat="server" Width="65%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="btnDenNgay" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
		<TD align="right" width="25%"><asp:imagebutton id="btnTimKiem" CssClass="QH_Button" ImageUrl="../../Images/btn_ThucHien.gif" runat="server"></asp:imagebutton></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="6" height="5"></TD>
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
					<asp:TemplateColumn>
						<ItemStyle Width="30%"></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink ID="moreLink" Runat="server" cssclass="QH_MenuLink" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TENLOAICP") %>' NavigateUrl='<%# GetMidURL("LinhVuc",DataBinder.Eval(Container.DataItem,"DB"),"CP") %>'>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblTonTruoc" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TonTruoc") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label1" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.MoiNhan") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label2" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGiaiQuyet") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label3" runat="server" cssclass= "QH_ColLabelMiddle" ForeColor="Red" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DaGQQuaHan") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label5" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.PTDAGQ") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label6" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ChuaGQ") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label7" runat="server" cssclass= "QH_ColLabelMiddle" ForeColor="Red" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.QuaHan") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label8" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.PTChuaGQ") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label9" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DATRA") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label10" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.CHUATRA") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemStyle Width="7%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="Label11" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.PTTRA") %>'>
							</asp:Label>
						</ItemTemplate>
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
