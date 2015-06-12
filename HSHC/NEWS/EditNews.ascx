<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="EditNews.ascx.vb" Inherits="EditNews" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function confirmDel(NewsID){
	var ans = window.confirm("Bạn có chắc chắn không ?");
	document.forms["Form"].hBookID.value = NewsID;
	//alert(document.forms["Form"].hBookID.value);
	if(ans == true){
		var theform;
		theform = document.forms["Form"];
		theform.submit();
		document.forms["Form"].hBookID.value = "";
	}
	else{
		document.forms["Form"].hBookID.value = "";
	}
}
</script>
<input type=hidden name=hBookID>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">TIN TỨC - SỰ KIỆN&nbsp;</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td align="center" width="*">
						<table width="100%">	
							<TR>
								<TD align="center" width="100%"></TD>
							</TR>
							<tr>
								<td vAlign="top"><asp:panel id="pnlList" Runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center" width="100%" colSpan="2">
													<TABLE class="QH_Table" cellSpacing="0" cellPadding="0" width="60%" border="0">
														<TR>
															<TD class="QH_ColLabel" width="25%">
																<asp:label id="Label2" Runat="server">Loại tin tức</asp:label></TD>
															<TD width="75%">
																<asp:dropdownlist id="ddlCategories" Width="50%" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">
																<asp:label id="Label3" Runat="server">Tiêu đề</asp:label></TD>
															<TD>
																<asp:textbox id="txtTitle" CssClass="QH_TextBox" Width="75%" runat="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD align="center" colSpan="2" height="25">
																<asp:Image id="Imagebutton1" Runat="server" ImageUrl="~/images/search.gif"></asp:Image>
																<asp:linkbutton id="lnkbtnChon" runat="server">
																	<asp:label id="Label12" Runat="server" CssClass="QH_LNK_BTN">Tìm kiếm</asp:label>
																</asp:linkbutton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="right" width="95%">
													<asp:label id="lblSoDong" CssClass="QH_ColLabel1" Runat="server">Số dòng / trang&nbsp;&nbsp;&nbsp;</asp:label>
													<asp:textbox id="txtSoDong" CssClass="QH_TextRight" Runat="server" Width="50px" MaxLength="3" AutoPostBack="True"></asp:textbox></TD>
												<TD align="right" width="5%"></TD>
											</TR>
											<TR>
												<TD align="center" width="100%" colSpan="2">
													<asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Runat="server" Width="90%" autogeneratecolumns="False"
														AllowSorting="True" AllowPaging="True" CellPadding="3">
														<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
														<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="STT" HeaderText="STT" ItemStyle-Width="50">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="News_ID"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Ti&#234;u đề" ItemStyle-Width="300">
																<ItemTemplate>
																	<asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' CommandName="editNews" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.News_ID") %>' CausesValidation="false" ID="lnkbtnTitle">
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="PublishDate" HeaderText="Ng&#224;y đưa tin" ItemStyle-Width="70">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="StateName" HeaderText="T&#236;nh trạng" ItemStyle-Width="100"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Duyệt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40">
																<ItemTemplate>
																	<asp:CheckBox ID="chkDuyet" Runat=server AutoPostBack=False Enabled='<%# not (DataBinder.Eval(Container, "DataItem.State_ID")).Equals("PUBLISHED") %>'>
																	</asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40">
																<ItemTemplate>
																	<asp:ImageButton ID=imgbtnEdit Runat=server CausesValidation=False CommandName="editNews" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.News_ID") %>' ImageUrl="~/images/edit.gif">
																	</asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="X&#243;a" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40">
																<ItemTemplate>
																	<a href="javascript:confirmDel('<%# DataBinder.Eval(Container, "DataItem.News_ID") %>');">
																		<img src="<%=Request.ApplicationPath%>/images/delete.gif" border=0>
																	</a>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
											<TR>
												<TD align="center">
													<TABLE>
														<TR>
															<TD>
																<asp:ImageButton id="imgbtnAdd" Runat="server" ImageUrl="~/images/add.gif"></asp:ImageButton>
																<asp:LinkButton id="lnkbtnAdd" Runat="server">
																	<asp:Label Runat=server CssClass="QH_LNK_BTN">Thêm mới</asp:Label>
																</asp:LinkButton>&nbsp;
															</TD>
															<TD>
																<asp:ImageButton id="imgbtnDuyet" Runat="server" ImageUrl="~/images/edit_pen.gif"></asp:ImageButton>
																<asp:LinkButton id="lnkbtnDuyet" Runat="server">
																	<asp:Label Runat=server CssClass="QH_LNK_BTN" ID="Label15">Duyệt</asp:Label>
																</asp:LinkButton>&nbsp;</TD>
															<TD>
																<asp:ImageButton id="imgbtnBack" Runat="server" ImageUrl="~/images/cancel.gif"></asp:ImageButton>
																<asp:LinkButton id="lnkbtnBack" Runat="server">
																	<asp:Label Runat=server CssClass="QH_LNK_BTN" ID="Label17">Trở về</asp:Label>
																</asp:LinkButton>&nbsp;</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
						</table>
					</td>
					<td width="16" class="QH_Khung_Right">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1">
								</td>
							</tr>
						</Table>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
