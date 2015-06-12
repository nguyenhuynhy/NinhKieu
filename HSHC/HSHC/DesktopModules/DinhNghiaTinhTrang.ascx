<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DinhNghiaTinhTrang.ascx.vb" Inherits="CPKTQH.DinhNghiaTinhTrang" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD>
			<TABLE class="QH_Table" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR vAlign="middle">
					<TD vAlign="middle" CssClass="QH_LabelLeftBold" width="30%" height="50">Danh 
							sách tab
					</TD>
					<TD vAlign="middle" width="70%"><asp:dropdownlist id="ddlTab" CssClass="QH_Dropdownlist" runat="server" Width="70%"></asp:dropdownlist>
						<asp:imagebutton id="btnThucHien" runat="server" CssClass="QH_Button" ImageUrl="~\IMAGES\btn_thucHien.gif"></asp:imagebutton></TD>
				</TR>
				<tr>
					<td>
						<asp:CheckBoxList id="CheckBoxList1" runat="server"></asp:CheckBoxList>
					</td>
					<td>
						<asp:CheckBoxList id="CheckBoxList2" runat="server"></asp:CheckBoxList>
					</td>
				</tr>
				<TR>
					<TD colSpan="2"><asp:label id="Label3" CssClass="QH_LabelLeftBold" Runat="server">Đường đi tình trạng</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%" colspan="3"><asp:datagrid id="grdPhanQuyen" runat="server" CssClass="QH_DataGridbottom" PageSize="3" autogeneratecolumns="False"
							width="100%">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="STT">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="txtSTT" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# grdPhanQuyen.CurrentPageIndex*grdPhanQuyen.PageSize + grdPhanQuyen.Items.Count+1 %>">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Loại hồ sơ">
									<ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblMa" Visible="False" runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataItem.MenuID") %>'>
										</asp:Label>
										<asp:Label id="lblItemCode" Visible="False" runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataItem.ItemCode") %>'>
										</asp:Label>
										<asp:Label id="lblTen" runat="server" cssclass= "QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chọn">
									<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="chkChon" Runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"IsChecked")) %>'>
										</asp:CheckBox>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Center"></FooterStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mặc định">
									<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton ID="radDefault" Runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(container.dataitem,"IsDefault")) %>'>
										</asp:RadioButton>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Center"></FooterStyle>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<TD vAlign="top" align="center" colspan="3"><asp:imagebutton id="btnCapNhat" runat="server" CssClass="QH_Button" ImageUrl="../../Images/btn_CapNhat.gif"></asp:imagebutton></TD>
				</tr>
			</TABLE>
		</TD>
	</TR>
</TABLE>
