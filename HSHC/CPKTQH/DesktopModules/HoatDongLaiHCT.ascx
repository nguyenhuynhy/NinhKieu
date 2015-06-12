<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HoatDongLaiHCT.ascx.vb" Inherits="CPKTQH.HoatDongLaiHCT" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript"> 
function select_deselect (chk) 
{ 
	var frm = document.forms[0];
	var i;
	var objchk;
	var obj;
	var txt, txtVon;
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chk) != -1)
		{
			objchk = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtSoGiayPhep') != -1)
		{
			txt = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtTienBangChu') != -1)
		{
			txtVon = window.document.forms(0).item(i);	
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
	if (objchk.checked == true) 
	{
		settxtSoBienNhanChon(objchk,txt,txtVon);
	}
	
	
}
function settxtSoBienNhanChon(chk,txt,txtVon)
{

var j;
var tenchkChon;

for (j=3; j<eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdDanhSach")').rows.length+1; j++)
				{
				
					tenchkChon = "_ctl0__ctl0__ctl0_dgdDanhSach__ctl" + j + "_chkXoa";
					
					if(tenchkChon==chk.id){
					txt.value = eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdDanhSach")').rows(j-2).cells(2).innerText
					txtVon.value = eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdDanhSach")').rows(j-2).cells(8).innerText + " đồng"
					}
				}
}				
function btnCapNhat_click()
{
	var i;
	var objchk;
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf('chkHoatDongLai') != -1)
		{
			objchk = window.document.forms(0).item(i);	
			if (objchk.checked) return true;
		}
	}
	alert('Ban chua chon Giay CNDKKD');
	return false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" CssClass="QH_Label_Title" Width="100%">Danh sách giấy chứng nhận đăng ký kinh doanh</asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<TR>
								<TD colSpan="5" height="5"></TD>
							</TR>
							<TR>
								<TD width="100%">
									<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center"
										border="0">
										<tr>
											<td width="50%">
												<table id="Table20" cellpadding="0" cellspacing="0" border="0" width="100%">
													<tr>
														<TD class="QH_ColLabel" width="30%">Loại hình</TD>
														<TD class="QH_ColControl" width="70%"><asp:dropdownlist id="ddlLoaiHinh" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Tình trạng</TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlTinhTrangHienTai" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Số GCN ĐKKD</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtSoGiayPhep" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="50"></asp:textbox></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Từ ngày</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>
															<asp:image id="imgTuNgay" CssClass="QH_IMAGEBUTTON" runat="server" AlternateText="Chọn ngày tháng nam"
																ImageUrl="~/images/calendar.gif"></asp:image></TD>
													</tr>
													<tr>
														<td class="QH_ColLabel">Ðến ngày</td>
														<td class="QH_ColControl"><asp:textbox id="txtDenNgay" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>
															<asp:image id="imgDenNgay" CssClass="QH_IMAGEBUTTON" runat="server" AlternateText="Chọn ngày tháng nam"
																ImageUrl="~/images/calendar.gif"></asp:image></td>
													</tr>
												</table>
											</td>
											<td width="50%">
												<table id="Table21" cellpadding="0" cellspacing="0" border="0" width="100%">
													<tr>
														<TD class="QH_ColLabel" width="30%">Họ tên</TD>
														<TD class="QH_ColControl" width="70%"><asp:textbox id="txtHoTen" Width="90%" CssClass="QH_Textbox" runat="server" MaxLength="50"></asp:textbox></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Số nhà</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtSoNha" Width="90%" CssClass="QH_TextBox" Runat="server" MaxLength="50"></asp:textbox></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Ðường</TD>
														<TD class="QH_ColControl">
															<asp:dropdownlist id="ddlDuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Phường</TD>
														<TD class="QH_ColControl">
															<asp:dropdownlist id="ddlPhuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Mặt hàng kinh doanh</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtMatHang" Width="90%" CssClass="QH_TextBox" Runat="server" MaxLength="100"></asp:textbox></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Bảng hiệu</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtBangHieu" Width="90%" CssClass="QH_TextBox" Runat="server" MaxLength="100"></asp:textbox></TD>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="5" height="5"></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<TD align="center" width="50%" colSpan="2"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>
												<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>
												<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In danh sách</asp:linkbutton>&nbsp;
											</TD>
										</tr>
										<TR>
											<td class="QH_LabelLeft"><asp:label id="Label2" Runat="server">Tổng số GCN ĐKKD: </asp:label><strong><asp:label id="lblTongSoHoSo" Runat="server"></asp:label></strong></td>
											<TD align="right" width="*"><asp:label id="Label1" Runat="server" CssClass="QH_ColLabel1">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Runat="server" CssClass="QH_TextRight" Width="50px" MaxLength="3"
													AutoPostBack="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="2" align="center"><asp:datagrid id="dgdDanhSach" Runat="server" CssClass="QH_DataGridBottom" Width="100%" AllowPaging="True"
													autogeneratecolumns="False" CellPadding="3">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="STT">
															<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="GiayCNDKKDID" HeaderText="GiayCNDKKDID"></asp:BoundColumn>
														<asp:BoundColumn DataField="TinhTrangHienTai" HeaderText="MaTinhTrang" Visible="False"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="HĐ lại">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkHoatDongLai" Runat="server"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="SoGiayPhep" HeaderText="Số GCN ĐKKD">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="HoTen" HeaderText="Họ t&#234;n">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DiaChi" HeaderText="Địa chỉ kinh doanh">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="BangHieu" HeaderText="Bảng hiệu">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TinhTrang" HeaderText="T&#236;nh trạng">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
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
<DIV style="DISPLAY:none">
	<asp:TextBox ID="txtTabCode" Runat="server" Enabled="False"></asp:TextBox>
	<asp:TextBox ID="txtNguoiTacNghiep" Runat="server" Enabled="False"></asp:TextBox>
</DIV>
