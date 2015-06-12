<%@ Control CodeBehind="PhanQuyenTimKiem.ascx.vb" Language="vb" AutoEventWireup="false" Inherits="PortalQH.PhanQuyenTimKiem" %>
<%@ Register TagPrefix="uc1" TagName="MenuList" Src="../../DesktopModules/MenuList.ascx" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language="javascript">
function DefaultChange(chkB)
{
      var ID = chkB.id;     
      for (i = 0; i <= document.forms(0).length-1; i++)
      {
		if(document.forms(0).item(i).id!=ID && document.forms(0).item(i).id.indexOf('radDefault', 0) > -1)
		{
			document.forms(0).item(i).checked=false;
		
		}
		
      }
      chkB.checked=true;
      for (i = 0; i <= document.forms(0).length-1; i++)
      {
		if (document.forms(0).item(i).id == ID.replace("radDefault","chkChon"))
		{
			document.forms(0).item(i).checked = true
		}
      }
      
}function ChonChange(chkB)
{
    var ID = chkB.id;     
	var id = ID.replace('chkChon','radDefault');
	for (i = 0; i <= document.forms(0).length-1; i++)
      {
		if (document.forms(0).item(i).id == id)
		{
			if (document.forms(0).item(i).checked == true)
			{
				chkB.checked = true;
			}
		}
      }			    
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblMenu" runat="server" Width="100%" CssClass="QH_Label_Title"></asp:label>
					</td>
					<td width="16" height="24" class="QH_Khung_TopRight">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" class="QH_Khung_Left">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td height="5">
								</td>
							</tr>
							<TR>
								<TD vAlign="top" width="100%">
									<table width="100%">
										<tr>
											<td vAlign="top" width="30%"><uc1:menulist id="MenuList_User" runat="server"></uc1:menulist></td>
											<td vAlign="top" width="70%">
												<table width="100%">
													<tr>
														<td><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title1"></asp:label></td>
													</tr>
													<tr>
														<td vAlign="top" width="100%"><asp:datagrid id="grdPhanQuyen" runat="server" CssClass="QH_DataGridbottom" PageSize="3" autogeneratecolumns="False"
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
														<TD vAlign="top" align="right"><asp:LinkButton CssClass="QH_Button" id="btnCapNhat" runat="server">Cập nhật</asp:LinkButton></TD>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
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
