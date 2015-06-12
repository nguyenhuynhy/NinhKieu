<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThuLyHoSoMotCuaPhuongXa.ascx.vb" Inherits="HSHC.ThuLyHoSoMotCuaPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuu" Src="ThongTinTraCuuMotCuaPhuongXa.ascx" %>
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
		if (window.document.forms(0).item(i).id.indexOf('chkSelected') != -1)
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
<script language="javascript">
function LaySoBienNhan()
{
	
	var value,j,tenchkChon,ID,PrintID;
	PrintID='';
	for (j=3; j<eval('document.forms[0].all("<%=Me.ClientID%>_dgdHoSoThuLy")').rows.length+1 ; j++)
		{
			tenchkChon = "<%=Me.ClientID%>_dgdHoSoThuLy__ctl" + j + "_" + "chkXoa";
			ID = "<%=Me.ClientID%>_dgdHoSoThuLy";
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

/**** Show report***********************
option = 1: doi voi cac trang user control
       <> 1: binh thuong
**************************************/
function ShowReport(report, sql, param, value, pathreport, option)
{
	width = screen.width - 20;
	height = screen.height - 100;
	l = (screen.width - 10 - width)/2;
	t = (screen.height -  10 - height)/2;	
	if (option == 1)
		opt = '';
	else
		opt = '../';
	
	FileWindow = window.open(opt + pathreport + '/Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','toolbar=0,scrollbars=1, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
	FileWindow.focus();				
}

//In bien nhan ho so
function Form_Print(objID,objMaLinhVuc,objTinhThanh,objCongty,objVanPhong,objProcName,objRptTiepNhan)
{	
	width = screen.width - 20;
	height = screen.height - 100;
	
	report = "InPhieuChuyen.rpt";
	sql = "" + objProcName.value + " '" + objID.value + "','" + objMaLinhVuc.value + "',N'" + objTinhThanh.value + "',N'" + objCongty.value + "',N'" + objVanPhong.value + "'";							
	ShowReport(report, sql, "", "", objRptTiepNhan.value, 1)
}
</script>
<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD height="24" width="100%">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_TopLeft" height="24" width="16"></td>
					<td class="QH_Khung_TopMid"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">&nbsp;</asp:label></td>
					<td class="QH_Khung_TopRight" height="24" width="16"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td>
						<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td align="center">
									<TABLE id="Table11" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr height="2">
											<td></td>
										</tr>
										<TR>
											<TD vAlign="top" width="100%">
												<table id="tblHeader" class="QH_LoaiHS" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD height="50" vAlign="middle" width="231" align="right"><STRONG>Lọai hồ sơ tiếp nhận</STRONG>&nbsp;
														</TD>
														<TD vAlign="middle" width="60%" align="left"><asp:dropdownlist id="ddlLinhVuc" runat="server" Width="95%" CssClass="QH_DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="middle" width="20%" align="left"><asp:linkbutton id="btnThucHien" runat="server" CssClass="QH_Button" Visible="False">Thực hiện</asp:linkbutton></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%">
												<table width="100%">
													<tr>
														<td>
															<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD>
																		<uc1:ThongTinTraCuu id="ThongTinTraCuu1" runat="server"></uc1:ThongTinTraCuu></TD>
																</TR>
																<TR>
																	<TD height="5"></TD>
																</TR>
																<TR>
																	<TD height="63">
																		<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
																			<TR>
																				<TD height="19" align="center"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>&nbsp;
																					<asp:linkbutton id="btnChuyenXuLy" runat="server" CssClass="QH_Button">Chuyển xử lý</asp:linkbutton>&nbsp;
																					<asp:linkbutton id="btnYeuCauBoSung" runat="server" CssClass="QH_Button">Bổ sung hồ sơ</asp:linkbutton>&nbsp;
																					<asp:linkbutton id="btnKhongXuLy" runat="server" CssClass="QH_Button">Không giải quyết</asp:linkbutton></TD>
																			</TR>
																			<tr>
																				<TD align="right"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Width="50px" CssClass="QH_TextRight" AutoPostBack="True" Runat="server"
																						MaxLength="3">10</asp:textbox></TD>
																			</tr>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD><asp:datagrid id="dgdHoSoThuLy" Width="100%" CssClass="QH_DataGrid" Runat="server" CellPadding="3"
																			PagerStyle-Mode="NumericPages" AllowSorting="True" AllowPaging="True" autogeneratecolumns="False">
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="STT">
																					<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# dgdHoSoThuLy.CurrentPageIndex*dgdHoSoThuLy.PageSize + dgdHoSoThuLy.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label25">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# dgdHoSoThuLy.CurrentPageIndex*dgdHoSoThuLy.PageSize + dgdHoSoThuLy.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label26">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# dgdHoSoThuLy.CurrentPageIndex*dgdHoSoThuLy.PageSize + dgdHoSoThuLy.Items.Count+1 %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label27">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="&lt;input type='checkbox' name='chkAll' onClick='checkAll();' id='chkAll' tabIndex='15'&gt;">
																					<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox ID="chkXoa" Runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn Visible="False" DataField="SoBienNhan"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="Số biên nhận">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label4">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label5">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label6">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Họ tên">
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
																				<asp:TemplateColumn HeaderText="Ngày nhận">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label16">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label17">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label18">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Loại hồ sơ">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label28">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label29">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.TenLoaiHoSo") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label30">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Tình trạng">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label19">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label20">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label21">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Hạn giải quyết (ngày)">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label2">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label3">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayGiaiQuyet") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>'>
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Thời gian còn lại">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label7">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label8">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.SoNgayConLai") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label9">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Người thụ lý">
																					<ItemTemplate>
																						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaNguoiNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "Yes" Or DataBinder.Eval(Container, "DataItem.SoNgayConLai") > 1,"True","False")%>' ID="Label22">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Blue" Text='<%# DataBinder.Eval(Container, "DataItem.MaNguoiNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") <= 1 And DataBinder.Eval(Container, "DataItem.SoNgayConLai") >= 0,"True","False")%>' ID="Label23">
																						</asp:Label>
																						<asp:Label runat="server" Font-Bold="True" ForeColor = "Red" Text='<%# DataBinder.Eval(Container, "DataItem.MaNguoiNhan") %>' Visible = '<%# IIf(DataBinder.Eval(Container, "DataItem.HoSoDaGiaiQuyet") = "No" And DataBinder.Eval(Container, "DataItem.SoNgayConLai") < 0,"True","False")%>' ID="Label24">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
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
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
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
