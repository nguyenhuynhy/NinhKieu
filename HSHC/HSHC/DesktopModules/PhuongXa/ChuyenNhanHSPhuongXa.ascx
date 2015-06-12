<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuuChuyenNhan" Src="ThongTinTraCuuChuyenNhanPhuongXa.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChuyenNhanHSPhuongXa.ascx.vb" Inherits="HSHC.ChuyenNhanHSPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">

function LaySoBienNhan()
		{
			
			var value,j,tenchkChon,ID,PrintID;
			PrintID='';
			for (j=3; j<eval('document.forms[0].all("<%=Me.ClientID%>_grdDanhSach")').rows.length+1 ; j++)
				{
					tenchkChon = "<%=Me.ClientID%>_grdDanhSach__ctl" + j + "_" + "chkXoa";
					ID = "<%=Me.ClientID%>_grdDanhSach";
					if(eval('document.forms[0].all("' + tenchkChon + '")').checked==1){
						if (PrintID!='')
						{
							PrintID=PrintID+','
						}
						PrintID=PrintID+eval('document.forms[0].all("' + ID + '")').rows(j-2).cells(2).innerText
					}
				}
				for (i=0;i<window.document.forms(0).length-1;i++)
				{
							
					if (window.document.forms(0).item(i).id.indexOf('txtChuoiSoBienNhan') != -1)
					{
							
						objSoBienNhan = window.document.forms(0).item(i);	
						objSoBienNhan.value= PrintID;
					}
							
				}
		}

function KiemTraThongTinCapNhat()
{
	var i;
	var obj;
	
	for (i=0; i<window.document.forms(0).length-1; i++)
	{
		obj = window.document.forms(0).item(i);
		if (obj.id.indexOf('ddlNguoiChuyen') != -1)
		{
			if (obj.value == '')
			{
				alert ('Bạn phải chọn người chuyển hồ sơ!');
				obj.focus();
				return false;
			}
		}
		if (obj.id.indexOf('ddlNguoiNhan') != -1)
		{
			if (obj.value == '')
			{
				alert ('Bạn phải chọn người nhận hồ sơ!');
				obj.focus();
				return false;
			}
		}
		if (obj.id.indexOf('chkXoa') != -1)
		{
			if (obj.checked == true)
			{
				return true;
			}
		}
	}
	alert('Bạn phải chọn hồ sơ để cập nhật');
	return false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">&nbsp;</asp:label></td>
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
							<tr>
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr height="2">
											<td></td>
										</tr>
										<TR>
											<TD vAlign="top" width="100%">
												<table class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại hồ sơ tiếp nhận</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="60%"><asp:dropdownlist id="ddlLinhVuc" runat="server" Width="95%" CssClass="QH_DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="left" width="20%"><asp:linkbutton id="btnThucHien" runat="server" CssClass="QH_Button" Visible="False">Thực hiện</asp:linkbutton></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%">
												<table width="100%">
													<tr>
														<td>
															<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD><uc1:thongtintracuuchuyennhan id="ThongTinTraCuuChuyenNhan1" runat="server"></uc1:thongtintracuuchuyennhan></TD>
																</TR>
																<TR>
																	<TD height="3"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD align="center" width="70%"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>
																					<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>
																					<asp:linkbutton id="btnInPhieu" runat="server" CssClass="QH_Button" Visible="False">In Vùng Hạ</asp:linkbutton>
																					<asp:linkbutton id="btnInRaGiay" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton></TD>
																			</TR>
																			<tr>
																				<TD align="right" width="30%"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Width="50px" CssClass="QH_TextRight" Runat="server" AutoPostBack="True"
																						MaxLength="3"></asp:textbox></TD>
																			</tr>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD><asp:datagrid id="grdDanhSach" Width="100%" CssClass="QH_DataGrid" Runat="server" CellPadding="3"
																			PagerStyle-Mode="NumericPages" AllowSorting="True" AllowPaging="True" autogeneratecolumns="False">
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																			<Columns>
																				<asp:BoundColumn Visible="False" DataField="HoSoTiepNhanID" HeaderText="Hồ sơ tiếp nhận"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="STT">
																					<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# grdDanhSach.CurrentPageIndex*grdDanhSach.PageSize + grdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label25">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# grdDanhSach.CurrentPageIndex*grdDanhSach.PageSize + grdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label26">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# grdDanhSach.CurrentPageIndex*grdDanhSach.PageSize + grdDanhSach.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label27">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="&lt;input type='checkbox' name='chkAll' onClick='checkAll();' id='chkAll' tabIndex='15'&gt;">
																					<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox ID="chkXoa" Runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Số bi&#234;n nhận">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label2">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label3">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label4">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Họ t&#234;n">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HoTenNguoiNop") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label5">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.HoTenNguoiNop") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label6">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.HoTenNguoiNop") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label7">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Địa chỉ">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChi") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label8">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChi") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label9">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChi") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label10">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Loại hồ sơ">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label11">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label12">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label13">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Ng&#224;y nhận">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label29">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label30">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label31">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="T&#236;nh trạng">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label14">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label15">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label16">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Hạn giải quyết (ng&#224;y)">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label17">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label18">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label19">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Số ng&#224;y c&#242;n lại">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label20">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label21">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label22">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Người thụ l&#253;">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaNguoiNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label23">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.MaNguoiNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And (DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0),"True","False")%>' ID="Label24">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.MaNguoiNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label28">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD height="47"><input id="txtChuoiSoBienNhan" type="hidden" size="1" name="txtChuoiSoBienNhan" runat="server">
																		<input id="txtMaLinhVuc" type="hidden" size="1" name="txtMaLinhVuc" runat="server">
																		<INPUT id="txtMaNguoiTacNghiep" type="hidden" size="1" name="txtMaNguoiTacNghiep" runat="server">
																	</TD>
																</TR>
															</TABLE>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
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
