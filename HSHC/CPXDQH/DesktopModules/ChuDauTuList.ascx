<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChuDauTuList.ascx.vb" Inherits="CPXD.ChuDauTuList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript">
function delconfirm(){
	result = confirm("Bạn có chắc chắn không ?");
	return result;
}
</script>
<DIV style="OVERFLOW: scroll; WIDTH: 700px; HEIGHT: 160px">
	<table width="100%">
		<tr>
			<td>
				<asp:datagrid id="dgdChuDautuList" runat="server" CssClass="QH_DataGrid" AutoGenerateColumns="False"
					PageSize="5" ShowFooter="True" AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages"
					PagerStyle-HorizontalAlign="Left" PagerStyle-Position="Bottom" OnPageIndexChanged="dgdChuDautuList_PageIndexChanged"
					OnSortCommand="dgdChuDautuList_SortCommand" OnDeleteCommand="dgdChuDautuList_DeleteCommand"
					OnUpdateCommand="dgdChuDautuList_UpdateCommand" OnCancelCommand="dgdChuDautuList_CancelCommand"
					OnEditCommand="dgdChuDautuList_EditCommand" HorizontalAlign="Left" Width="1137px">
					<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
					<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img alt=&quot;Lưu&quot; align=middle border=0 src=./Images/save.gif&gt;"
							HeaderText="Chọn" CancelText="&lt;img alt=&quot;Bỏ qua&quot; align=middle border=0 src=./Images/cancel.gif&gt;"
							EditText="&lt;img alt=&quot;sửa&quot; align=middle border=0 src=./Images/edit.gif&gt;">
							<HeaderStyle Width="35"></HeaderStyle>
							<ItemStyle Width="35"></ItemStyle>
						</asp:EditCommandColumn>
						<asp:ButtonColumn ButtonType="LinkButton" Text="&lt;img alt=&quot;Xo&#225;&quot; align=middle border=0 src= ./Images/delete.gif onclick='javascript:return delconfirm();'&gt;"
							CommandName="Delete">
							<HeaderStyle Width="32"></HeaderStyle>
							<ItemStyle Width="32" HorizontalAlign="Center"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn Visible="False" DataField="MaChuDauTu" SortExpression="MaChuDauTu" HeaderText="MaChuDauTu"></asp:BoundColumn>
						<asp:TemplateColumn SortExpression="HoTen" HeaderText="Họ t&#234;n">
							<HeaderStyle Width="150"></HeaderStyle>
							<ItemTemplate>
								<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HoTen") %>'>
								</asp:Label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:LinkButton id=Linkbutton2 onclick=AddNewRow runat="server" Text="Thêm dòng mới..." Visible="<%# IsLastPage() %>">
								</asp:LinkButton>
							</FooterTemplate>
							<EditItemTemplate>
								<asp:TextBox id=dgdHoTen cssclass="QH_TextBox" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.HoTen") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="NgaySinh" HeaderText="Ng&#224;y sinh">
							<HeaderStyle Width="70"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NgaySinh") %>' ID="Label6">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="dgdNgaySinh" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NgaySinh") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="GioiTinh" HeaderText="Giới t&#237;nh">
							<HeaderStyle Width="70"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# GetGender(CStr(DataBinder.Eval(Container, "DataItem.GioiTinh")))%>' ID="Label7">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList id="dgdGioiTinh" CssClass="QH_DropDownList" Width="100%" runat="server" SelectedIndex='<%# GetSelectedIndex(DataBinder.Eval(Container, "DataItem.GioiTinh")) %>'>
									<asp:ListItem Value=""></asp:ListItem>
									<asp:ListItem Value="1">Nam</asp:ListItem>
									<asp:ListItem Value="0">Nữ</asp:ListItem>
								</asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="SoCMND" HeaderText="CMND">
							<HeaderStyle Width="70"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoCMND") %>' ID="Label8">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="dgdSoCMND" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.SoCMND") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="NoiCapCMND" HeaderText="Nơi cấp CMND">
							<HeaderStyle Width="150"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoiCapCMND") %>' ID="Label9">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="dgdNoiCapCMND" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NoiCapCMND") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="NgayCapCMND" HeaderText="Ng&#224;y cấp CMND">
							<HeaderStyle Width="70"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NgayCapCMND") %>' ID="Label10">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="dgdNgayCapCMND" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NgayCapCMND") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="NoiDKTT" HeaderText="Địa chỉ">
							<HeaderStyle Width="200"></HeaderStyle>
							<ItemTemplate>
								<asp:Label id=Label14 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDKTT") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox id=dgdNoiDKTT cssclass="QH_TextBox" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDKTT") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="DienThoai" HeaderText="Điện thoại">
							<HeaderStyle Width="70"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DienThoai") %>' ID="Label11">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="dgdDienThoai" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DienThoai") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="Fax" HeaderText="Fax">
							<HeaderStyle Width="70"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Fax") %>' ID="Label12">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="dgdFax" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Fax") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="Email" HeaderText="Email">
							<HeaderStyle Width="150"></HeaderStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>' ID="Label13">
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="dgdEmail" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" CssClass="ActivePage"
						Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</td>
		</tr>
	</table>
</DIV>
