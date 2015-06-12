<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuu" Src="../../HSHC/DesktopModules/ThongTinTraCuu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThuLyHoSo.ascx.vb" Inherits="CPVHQH.ThuLyHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language="javascript"> 
function select_deselect (chk) 
{ 
	var frm = document.forms[0];
	var i;
	var objchk;
	var obj;
	
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chk) != -1)
		{
			objchk = window.document.forms(0).item(i);	
		}
	}
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		obj = window.document.forms(0).item(i);
		if (window.document.forms(0).item(i).id.indexOf('chkXoa') != -1)
		{
			if (objchk.checked == true)
			{
				if (obj.id != objchk.id)
				obj.checked = false;
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
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server"></asp:label></td>
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
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td height="2"></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="100%">
												<TABLE class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại hồ sơ tiếp nhận 
																&nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="60%"><asp:dropdownlist id="ddlLinhVuc" Width="95%" runat="server"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1"><asp:linkbutton id="btnThucHien" CssClass="QH_Button" runat="server">Thực hiện</asp:linkbutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%">
												<TABLE id="Table3" width="100%">
													<TR>
														<TD>
															<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD height="2"></TD>
																</TR>
																<TR>
																	<TD><uc1:thongtintracuu id="ThongTinTraCuu1" runat="server"></uc1:thongtintracuu></TD>
																</TR>
																<TR>
																	<TD height="2"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr>
																				<td height="2"></td>
																			</tr>
																			<TR>
																				<TD align="center"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																				</TD>
																			</TR>
																			<tr>
																				<TD align="right" width="*" height="18"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Sô dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" Runat="server" MaxLength="3"
																						AutoPostBack="True"></asp:textbox></TD>
																			</tr>
																			<tr>
																				<td height="2"></td>
																			</tr>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" autogeneratecolumns="False"
																			AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages" CellPadding="3">
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="STT">
																					<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label25">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label26">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label27">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn Visible="False" DataField="SoBienNhan"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="Số bi&#234;n nhận">
																					<ItemTemplate>
																						<asp:HyperLink id=HyperLink1 runat="server" Visible='<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.URL") %>'>
																							<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>
																						</asp:HyperLink>
																						<asp:HyperLink id=Hyperlink2 runat="server" Visible='<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.URL") %>'>
																							<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>
																						</asp:HyperLink>
																						<asp:HyperLink id=Hyperlink3 runat="server" Visible='<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.URL") %>'>
																							<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>
																						</asp:HyperLink>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Họ t&#234;n">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HoTenNguoiNop") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label10">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.HoTenNguoiNop") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label11">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.HoTenNguoiNop") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label12">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Địa chỉ">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChi") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label13">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChi") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label14">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChi") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label15">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Loại hồ sơ">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label4">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label5">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label6">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Ng&#224;y nhận">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label16">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label17">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label18">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="T&#236;nh trạng">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label19">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label20">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label21">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Hạn GQ (ng&#224;y)">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label3">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label7">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label8" NAME="Label8">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="C&#242;n lại(Ngày)">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label9">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label22">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label23">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Số CMND">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoCMND") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label24">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoCMND") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label28">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoCMND") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label29">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
