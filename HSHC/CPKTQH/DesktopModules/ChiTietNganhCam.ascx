<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChiTietNganhCam.ascx.vb" Inherits="CPKTQH.NganhCam_CoDieuKien" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function ShowWindow1(obj1,Parent,l,t,w,h)
{
		window.open(obj1,Parent,"width=" + w + ", height=" + h + ", left=" + l + ", top=" + t + ", scrollbars=yes");
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
						<asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">Thông tin chi tiết ngành cấm</asp:label>
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
					<td width="*" align="Center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" border="0">
							<TR>
								<TD width="*">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<br>
										<TR>
											<TD class="QH_ColLabel" width="30%">Ngành cấp trên</TD>
											<TD class="QH_ColControl" colSpan="2"><asp:dropdownlist id="ddlNganhCapTren" CssClass="QH_TextBox" Width="100%" AutoPostBack="True" Runat="server"></asp:dropdownlist></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngành kinh doanh</TD>
											<TD class="QH_ColControl" colSpan="2"><asp:dropdownlist id="ddlNganhKD" CssClass="QH_TextBox" Width="100%" AutoPostBack="True" Runat="server"></asp:dropdownlist></TD>
											<TD>
												<asp:CheckBox id="chkCamKD" runat="server" CssClass="QH_Option" AutoPostBack="True" Text="Cấm kinh doanh"></asp:CheckBox></TD>
										</TR>
										<TR>
											<TD colSpan="4" height="5"></TD>
										</TR>
										<TR>
											<TD class="QH_LabelRightBold">Thời gian hiệu lực&nbsp;&nbsp;&nbsp;</TD>
											<TD class="QH_ColLabel" width="10%">Từ ngày</TD>
											<TD class="QH_ColControl" width="40%"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="50%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="imgTuNgay" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn lịch" ImageUrl="~\images\calendar.gif"></asp:image></TD>
											<TD width="20%"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD class="QH_ColLabel">Đến ngày</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="50%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="imgDenNgay" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn lịch" ImageUrl="~\images\calendar.gif"></asp:image></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="QH_LabelRightBold">Phạm vi hiệu lực&nbsp;&nbsp;&nbsp;</TD>
											<TD class="QH_ColControl" colSpan="3"><asp:radiobuttonlist id="rdlPhamVi" CssClass="QH_LoaiHS" runat="server" AutoPostBack="True" CellSpacing="3"
													CellPadding="7" RepeatDirection="Horizontal">
													<asp:ListItem Value="Q" Selected="True">Cấm to&#224;n quận</asp:ListItem>
													<asp:ListItem Value="P">Cấm theo phường</asp:ListItem>
													<asp:ListItem Value="D">Cấm theo đường</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD colSpan="4" height="5"></TD>
										</TR>
										<TR>
											<TD colSpan="4">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_DataGridHeader" width="40px">STT</TD>
														<TD class="QH_DataGridHeader" width="50px"><asp:checkbox id="chkAll" runat="server" BorderStyle="None"></asp:checkbox></TD>
														<TD class="QH_DataGridHeader" width="237px"><asp:label id="lblMain" Width="100%" Runat="server">ds</asp:label></TD>
														<TD class="QH_DataGridHeader" width="*"><asp:label id="lblSub" Width="100%" Runat="server">das</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										<TR>
											<TD vAlign="top" colSpan="4">
												<DIV style="TABLE-LAYOUT: fixed; OVERFLOW: scroll; HEIGHT: 200px"><asp:datagrid id="dgdDuongPhuong" CssClass="QH_DataGrid" Width="100%" runat="server" CellPadding="3"
														AllowSorting="True" AutoGenerateColumns="False" ShowHeader="false">
														<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
														<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemStyle Width="40px"></ItemStyle>
																<ItemTemplate>
																	<asp:Label id="lblStt" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# dgdDuongPhuong.CurrentPageIndex*dgdDuongPhuong.PageSize + dgdDuongPhuong.Items.Count+1 %>">
																	</asp:Label>
																	<asp:Label id="lblMa" Visible="False" cssclass="QH_ColLabelMiddle" runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataItem.Ma") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center" Width="42px"></ItemStyle>
																<ItemTemplate>
																	<asp:checkbox id="chkXoa" runat="server" enabled="true" Checked='<%# DataBinder.Eval(Container,"DataItem.Chon") %>'>
																	</asp:checkbox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle Width="237px"></ItemStyle>
																<ItemTemplate>
																	<asp:hyperlink id="hplTen" Enabled=<%# dgdDuongPhuong.Enabled %> cssclass="QH_LabelLeft" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ten") %>'
																		NavigateUrl=<%#"javascript:ShowWindow1('CPKTQH/DesktopModules/ChiTietDuongPhuongCam.aspx?Loai=" & rdlPhamVi.SelectedValue & "&Ma=" & DataBinder.Eval(Container.DataItem,"Ma") & "&Ten=" & DataBinder.Eval(Container.DataItem,"Ten") & "&MaNganhKD=" & ddlNganhKD.SelectedItem.Value & "&NganhKD=" & ddlNganhKD.SelectedItem.Text & "&NganhCT=" & ddlNganhCapTren.SelectedItem.Text & "&TuNgay=" & txtTuNgay.Text & "&DenNgay=" & txtDenNgay.Text & "','Application',150,10,450,500);"%> >
																	</asp:hyperlink>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle></ItemStyle>
																<ItemTemplate>
																	<asp:label id="lblGhiChu" cssclass="QH_LabelLeft" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GhiChu") %>' Width="100%">
																	</asp:label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></DIV>
											</TD>
										</TR>
										
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
								</TD>
							</TR>
						</TABLE>
						<asp:TextBox ID="txtReLoad" Runat="server" Width="0px"></asp:TextBox>
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
