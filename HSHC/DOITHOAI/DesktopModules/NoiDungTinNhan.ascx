<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NoiDungTinNhan.ascx.vb" Inherits="DOITHOAI.NoiDungTinNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="main" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
	<tr>
		<td><asp:label id="lblTenLinhVuc" runat="server" Width="100%" CssClass="QH_Label_Title"></asp:label></td>
	</tr>
	<tr>
		<td height="10"></td>
	</tr>
	<tr>
		<td>
			<TABLE id="main1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><asp:label id="Label1" runat="server" CssClass="QH_LabelLeftBold">Tiêu đề:</asp:label>&nbsp;
						<asp:label id="lblTieuDe" runat="server" CssClass="QH_LabelLeftBold"></asp:label></td>
				</tr>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
	<tr>
		<td><asp:datagrid id="grdDanhSach" Width="100%" CssClass="QH_DataGrid" CellPadding="3" PagerStyle-Mode="NumericPages"
				AllowSorting="True" AllowPaging="True" autogeneratecolumns="False" Runat="server">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
				<Columns>
					<asp:BoundColumn DataField="TinNhanChiTietID" HeaderText="TinNhanChiTietID" Visible="False"></asp:BoundColumn>
					<asp:BoundColumn DataField="NguoiGui" HeaderText="Người gửi">
						<ItemStyle VerticalAlign="Top" HorizontalAlign="center" Width="75px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NgayGui" HeaderText="Thời gian gửi">
						<ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="100px"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Nội dung">
						<ItemTemplate>
							<asp:Label ID="lblGridNoiDung" Runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDung")%>'>
							</asp:Label>
							<asp:LinkButton id="btnSua" runat="server" CssClass="QH_Button" CommandName="Edit" Visible="false">Sửa nội dung</asp:LinkButton>
							<asp:LinkButton id="btnXoa" runat="server" CssClass="QH_Button" CommandName="Delete" Visible="false">Xóa</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></td>
	</tr>
	<tr>
		<td height="10"></td>
	</tr>
	<tr>
		<td align="center"><asp:linkbutton id="btnTraLoi" runat="server" CssClass="QH_Button">Trả lời</asp:linkbutton><asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></td>
	</tr>
</TABLE>
<div style="DISPLAY: none"><asp:textbox id="txtTinNhanID" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtNguoiGui" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtNguoiNhan" Runat="server" Enabled="False"></asp:textbox>
	<asp:textbox id="txtNguoiGuiViewed" Runat="server" Enabled="False"></asp:textbox>
	<asp:textbox id="txtNguoiNhanViewed" Runat="server" Enabled="False"></asp:textbox>
	<asp:textbox id="txtTinNhanChiTietID" Runat="server" Enabled="False"></asp:textbox></div>
