<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NXHS_HangMucXDTruoc.ascx.vb" Inherits="CPXD.NXHS_HangMucXDTruoc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript">
/*function TinhDienTichSan(obj1,obj2)
{
var obj
	obj=document.all("_ctl0:_ctl0:_ctl0:DX_HoSoPhapLy1:txtHSPL_DienTichKhuonVienHienHuuTru");
	obj1.value=obj.value-obj2.value;
}*/	
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD></TD>
	</TR>
	<TR>
		<TD></TD>
	</TR>
	<TR>
		<TD>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%">Bản vẽ thiết kế số</TD>
					<TD class="QH_ColControl" width="80%">
						<asp:Textbox id="txtGP_KyHieuThietKe" tabIndex="26" runat="server" Width="87%" CssClass="QH_Textbox"
							MaxLength="500"></asp:Textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%">Ðon vi thiết kế</TD>
					<TD class="QH_ColControl" width="80%">
						<asp:TextBox id="txtGP_DonViThietKe" tabIndex="28" runat="server" Width="98%" CssClass="QH_Textbox"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%">Quy mô</TD>
					<TD class="QH_ColControl" width="80%">
						<asp:TextBox id="txtGP_QuyMo" tabIndex="30" runat="server" Width="87%" CssClass="QH_Textbox"
							MaxLength="100"></asp:TextBox>&nbsp;
						<asp:LinkButton id="LnkQuyMo" runat="server">Chọn </asp:LinkButton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%">Kết cấu</TD>
					<TD class="QH_ColControl" width="80%">
						<asp:TextBox id="txtGP_KetCau" tabIndex="32" runat="server" Width="87%" CssClass="QH_Textbox"
							MaxLength="100"></asp:TextBox>&nbsp;
						<asp:LinkButton id="LnkKetCau" runat="server">Chọn </asp:LinkButton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%"></TD>
					<TD class="QH_ColControl" width="80%">
						<asp:TextBox id="txtGP_ChieuCaoTungTang" tabIndex="34" runat="server" Width="98%" CssClass="QH_Textbox"
							MaxLength="100" Rows="3" Visible="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%"></TD>
					<TD class="QH_ColControl" width="80%">
						<asp:TextBox id="txtGP_ChieuCaoToanCongTrinh" tabIndex="32" MaxLength="100" CssClass="QH_Textbox"
							Width="98%" runat="server" Visible="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%"></TD>
					<TD class="QH_ColControl" width="80%"></TD>
				</TR>
				<TR>
					<td colspan="2" width="100%"></td>
				</TR>
				<TR>
					<td colspan="2" width="100%"></td>
				</TR>
				<tr>
					<td colspan="2" width="100%">
						<asp:label id="Label4" CssClass="QH_LabelLeftBold" Width="100%" runat="server">Thông tin hạng mục xây dựng</asp:label></td>
				</tr>
				<TR>
					<TD align="center" width="100%" colSpan="3"><asp:datagrid id="dgdNoiDungHangMuc" CssClass="QH_DataGrid" runat="server" HorizontalAlign="Left"
							PagerStyle-Position="Bottom" PagerStyle-HorizontalAlign="Left" PagerStyle-Mode="NumericPages" AllowSorting="True" AllowPaging="True"
							ShowFooter="True" PageSize="4" AutoGenerateColumns="False" OnPageIndexChanged="dgdNoiDungHangMuc_PageIndexChanged" OnSortCommand="dgdNoiDungHangMuc_SortCommand"
							OnDeleteCommand="dgdNoiDungHangMuc_DeleteCommand" OnEditCommand="dgdNoiDungHangMuc_EditCommand" OnUpdateCommand="dgdNoiDungHangMuc_UpdateCommand"
							 OnCancelCommand="dgdNoiDungHangMuc_CancelCommand"  tabIndex="17">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<Columns>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img alt=&quot;Luu&quot; align=middle border=0 src=./Images/save.gif&gt;"
									HeaderText="Chọn" CancelText="&lt;img alt=&quot;B? qua&quot; align=middle border=0 src=./Images/cancel.gif&gt;"
									EditText="&lt;img alt=&quot;sửa&quot; align=middle border=0 src=./Images/edit.gif&gt;">
									<HeaderStyle Width="4%"></HeaderStyle>
									<ItemStyle Width="4%"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Text="&lt;img alt=&quot;Xo&#225;&quot; align=middle border= 0 src= ./Images/delete.gif&gt;"
									CommandName="Delete">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle Width="3%"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="MaHangMuc" HeaderText="MaHangMuc"></asp:BoundColumn>
								<asp:TemplateColumn SortExpression="HangMuc" HeaderText="Hạng Mục">
									<HeaderStyle Width="7%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label id="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenHangMuc")%>'>
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="Linkbutton2" onclick="AddNewRow" runat="server" Text="Thêm dòng mới..." Enabled="<%# IsLastPage() %>">
										</asp:LinkButton>
									</FooterTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="ddlHangMuc" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.MaHangMuc") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="ChieuCao" HeaderText="Chiều cao">
									<HeaderStyle Width="8%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" ID="Label2" Text='<%# DataBinder.Eval(Container, "DataItem.ChieuCao") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtChieuCao" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ChieuCao") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="NoiDung" HeaderText="Nội dung">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" ID="Label6" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDung") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtNoiDung" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDung") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="DienTich" HeaderText="Diện tích">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" ID="Label7" Text='<%# DataBinder.Eval(Container, "DataItem.DienTich") %>' >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="HangMucXayDungID" HeaderText="HangMucXayDungID"></asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Giữ nguyên" HeaderText="Giữ nguyên">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="chkGiuNguyen" CssClass="QH_Checkbox" Checked='<%# DataBinder.Eval(Container, "DataItem.GiuNguyen") %>' Enabled=<%# SetStatus(dgdNoiDungHangMuc.CurrentPageIndex*dgdNoiDungHangMuc.PageSize + dgdNoiDungHangMuc.Items.Count+1) %>   >
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="HangMucXayDungID" HeaderText="HangMucXayDungID"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" CssClass="ActivePage"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<P align="left">
						</P>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%">Diện tích xây dựng</TD>
					<TD class="QH_ColControl" width="80%"><asp:TextBox id="txtGP_DienTichXayDung" tabIndex="32" MaxLength="100" CssClass="QH_Textbox" Width="98%"
							runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" align="center" width="20%">Diện tích sân</TD>
					<TD class="QH_ColControl" width="80%">
						<asp:TextBox id="txtGP_DienTichSan" tabIndex="34" runat="server" Width="98%" CssClass="QH_Textbox"
							MaxLength="100">/</asp:TextBox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD height="9">
			<asp:label id="Label3" CssClass="QH_LabelLeftBold" runat="server">Chiều cao toàn công trình: </asp:label>
			<asp:label id="lblTongChieuCao" CssClass="QH_LabelLeftBold" runat="server">0</asp:label>&nbsp;m</TD>
	</TR>
	<TR>
		<TD height="9">
			<asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Tổng diện tích sàn xây dựng:</asp:label>
			<asp:label CssClass="QH_LabelLeftBold" id="lblDienTichSanXayDung" runat="server">0</asp:label>
		</TD>
	</TR>
	<TR>
		<TD width="100%">
			<TABLE id="TblGhiChu" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0"
				class="QH_Table">
				<TBODY>
					<TR>
						<TD width="5%" class="QH_ColLabel" align="center">Ghi chú</TD>
		</TD>
		<TD class="QH_ColControl" width="95%"><asp:textbox id="txtGP_GhiChu" TextMode="MultiLine" CssClass="QH_Textbox" Width="98%" runat="server"
				Height="50" tabIndex="18"></asp:textbox></TD>
	</TR>
</TABLE>
<asp:TextBox id="txtDienTichSanXayDung" Width="0px" runat="server"></asp:TextBox></TD></TR></TBODY></TABLE>
