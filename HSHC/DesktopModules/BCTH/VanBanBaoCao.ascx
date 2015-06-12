<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VanBanBaoCao.ascx.vb" Inherits=".VanBanBaoCao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function checkKyBaoCao(strKybaocao)
{
	
	//	alert(strKybaocao);	
	var ddl = document.all(strKybaocao);
	var cap=ddl.options[ddl.selectedIndex].value;
	//alert(cap);
	cap = (cap).substring(0,1);
	if (cap=="1")
	{
		return true;
	}
	else
	{
		if (cap=="0")
		{
		alert("Bạn phải chọn một kỳ báo cáo cụ thể");
		ddl.focus();
		return false;
		}
	}
return true;
}
</script>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="Label2" runat="server" width="100%" CssClass="QH_Content_Header_Middle">TẠO BÁO CÁO</asp:label>
					</td>
					<td width="8" height="25" class="QH_Content_TopRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="9" class="QH_Content_Left">&nbsp;
					</td>
					<td width="*" valign="top">
						<!--End bound-->
						<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
							<tr>
								<td height="5">
								</td>
							</tr>
							<tr>
								<td align="center" width="100%" colSpan="2">
									<TABLE class="QH_Content_Filter" cellSpacing="0" cellPadding="0" width="80%" align="center"
										border="0">
										<tr>
											<td colspan="3" height="5"></td>
										</tr>
										<TR>
											<TD align="right" width="40%"><asp:label id="lblDonVi" CssClass="QH_ColLabel" Text="Đơn vị báo cáo" runat="server"></asp:label></TD>
											<TD width="60%" colSpan="2"><asp:dropdownlist id="ddlDonVi" CssClass="QH_DropDownList" Runat="server" Width="60%"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<TD align="right" width="40%"><asp:label id="lblLinhVucBC" CssClass="QH_ColLabel" Text="Lĩnh vực báo cáo" runat="server"></asp:label></TD>
											<TD width="60%" colSpan="2"><asp:dropdownlist id="ddlLinhVuc" CssClass="QH_DropDownList" Runat="server" Width="60%"></asp:dropdownlist></TD>
										</tr>
										<TR>
											<TD align="right"><asp:label id="lblKyBaoCao" CssClass="QH_ColLabel" Text="Kỳ báo cáo" runat="server"></asp:label></TD>
											<TD colSpan="2"><asp:dropdownlist id="ddlKyBaoCao" CssClass="QH_DropDownList" Runat="server" Width="60%"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD align="right"><asp:label id="lblNam" CssClass="QH_ColLabel" Text="Năm" runat="server"></asp:label></TD>
											<TD width="18%"><asp:dropdownlist id="ddlNam" CssClass="QH_DropDownList" Runat="server" Width="100%"></asp:dropdownlist></TD>
											<td align="left"><asp:image id="btnTimKiem" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/images/search.gif"></asp:image><asp:linkbutton id="lnkbtnChon" runat="server">
													<asp:label id="Label12" Runat="server" CssClass="QH_Link_Button">Tìm kiếm</asp:label>
												</asp:linkbutton>&nbsp;<asp:imagebutton CssClass="QH_ImageButton" id="btnThem" Runat="server" ImageUrl="~/images/add.gif"></asp:imagebutton><asp:linkbutton id="lnkbtnAdd" Runat="server">
													<asp:Label Runat="server" CssClass="QH_Link_Button" ID="Label7">Thêm mới</asp:Label>
												</asp:linkbutton>&nbsp;</td>
										</TR>
										<tr>
											<td height="5"></td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<TD align="right" width="100%" colSpan="2"><asp:label id="lblSoDong" CssClass="QH_ColLabel" Runat="server">Số dòng hiển thị &nbsp;</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Runat="server" Width="50px" AutoPostBack="True"
										MaxLength="3"></asp:textbox></TD>
							</tr>
							<tr>
								<td align="center" width="100%" colSpan="2"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Runat="server" Width="100%" CellPadding="3"
										AllowPaging="True" AllowSorting="True" autogeneratecolumns="false">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="STT">
												<ItemStyle Width="3%" HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label width="100%" id="Label1" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Tiêu đề">
												<ItemStyle Width="20%"></ItemStyle>
												<ItemTemplate>
													<asp:Image ID="imgImage" Runat=server ImageUrl="~/images/FileAttach.gif" AlternateText="Có đính kèm file" Visible='<%#IIf(DataBinder.Eval(Container,"DataItem.FileDinhKem")="" ,False,True) %>'>
													</asp:Image>
													<asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TieuDe") %>' CommandName="EditVBBC" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.VanBanBCID") %>' CausesValidation="false" ID="lnkbtnTitle">
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Đơn vị báo cáo">
												<ItemStyle Width="10%"></ItemStyle>
												<ItemTemplate>
													<asp:Label ID="lblTenDonVi" CssClass="QH_Label" Runat=server Text='<%#DataBinder.Eval(Container,"DataItem.DonVi")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Kỳ báo cáo">
												<ItemStyle Width="10%"></ItemStyle>
												<ItemTemplate>
													<asp:Label ID="Label4" CssClass="QH_Label" Runat=server Text='<%#DataBinder.Eval(Container,"DataItem.KyBaoCao")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Lĩnh vực">
												<ItemStyle Width="10%"></ItemStyle>
												<ItemTemplate>
													<asp:Label ID="Label6" CssClass="QH_Label" Runat=server Text='<%#DataBinder.Eval(Container,"DataItem.LinhVuc")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Người lập">
												<ItemStyle Width="5%"></ItemStyle>
												<ItemTemplate>
													<asp:Label ID="Label5" CssClass="QH_Label" Runat=server Text='<%#DataBinder.Eval(Container,"DataItem.NguoiLap")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Ngày lập">
												<ItemStyle Width="5%"></ItemStyle>
												<ItemTemplate>
													<asp:Label Runat=server text='<%#DataBinder.Eval(Container,"DataItem.NgayTaoLap")%>' CssClass="QH_label" ID="Label3" NAME="Label3">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Tình trạng">
												<ItemStyle Width="5%"></ItemStyle>
												<ItemTemplate>
													<asp:CheckBox Runat=server Checked='<%#DataBinder.Eval(Container,"DataItem.TinhTrang")%>' Enabled=False CssClass="QH_CheckBox" ID="chkChon">
													</asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td height="5px"></td>
							</tr>
						</table>
						<!--start bound-->
					</td>
					<td width="8" class="QH_Content_Right">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colspan="3" height="12">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="128" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
					</td>
					<td width="130" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
