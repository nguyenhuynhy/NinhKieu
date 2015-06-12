<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CT_DSChungThuc.ascx.vb" Inherits="THTT.CT_DSChungThuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Danh sách hồ sơ chứng thực</asp:label></TD>
	</TR>
	<TR>
		<TD height="10"></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="3">
			<asp:Label id="Label4" CssClass="QH_Label" Runat="server">Số dòng hiển thị</asp:Label>
			<asp:TextBox id="txtSoDong" CssClass="QH_TextBox" Width="25px" Runat="server" AutoPostBack="True"
				MaxLength="2"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD>
			<asp:DataGrid ID="DataGrid1" Runat="server" CssClass="QH_Datagrid" AllowSorting="True" AllowPaging="True"
				Width="100%" CellPadding="3" AutoGenerateColumns="False" ShowFooter="True">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#EDF2FF"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
					BackColor="#5486DD"></HeaderStyle>
				<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="STT">
						<HeaderStyle Width="5%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink runat="server" Text="<%# DataGrid1.CurrentPageIndex*DataGrid1.PageSize + DataGrid1.Items.Count+1 %>" ID="Hyperlink1" NAME="Hyperlink1">
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="SOCHUNGTHUC" HeaderText="Số chứng thực">
						<HeaderStyle Width="20%"></HeaderStyle>
						<ItemTemplate>
							<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SOCHUNGTHUC") %>' NavigateUrl='<%# GetMidURL("ML",DataBinder.Eval(Container.DataItem,"MaLoaiCT") & "&ID=" & DataBinder.Eval(Container.DataItem,"ChungThucID") ,"CT_CHITIETHOSO") %>'> ID="Hyperlink2" NAME="Hyperlink2">
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="VIECCHUNGTHUC" HeaderText="Việc chứng thực">
						<HeaderStyle Width="35%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VIECCHUNGTHUC") %>' ID="Label1" NAME="Label1">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="QUYENSO" HeaderText="Quyển số">
						<HeaderStyle Width="20%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QUYENSO") %>' ID="Label2" NAME="Label2">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="NGAYGD" HeaderText="Ng&#224;y chứng thực">
						<HeaderStyle Width="20%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# SetVNDateString(DataBinder.Eval(Container, "DataItem.NGAYGD").tostring) %>' ID="Label3" NAME="Label3">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="MALOAICT"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</TD>
	</TR>
	<TR>
		<TD height="10"></TD>
	</TR>
	<tr>
		<td align="center" colspan="6">
			<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
			<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
		</td>
	</tr>
</TABLE>
