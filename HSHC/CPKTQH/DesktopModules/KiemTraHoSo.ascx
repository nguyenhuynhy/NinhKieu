<%@ Control Language="vb" AutoEventWireup="false" Codebehind="KiemTraHoSo.ascx.vb" Inherits="CPKTQH.KiemTraHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">&nbsp;</asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
							<TR vAlign="top">
								<TD width="50%">
									<TABLE class="QH_Table" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="30%">Số GCN ĐKKD</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoGiayPhep" runat="server" CssClass="QH_TextBox" height="20" width="50%"
													MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Bảng hiệu</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtBangHieu" runat="server" CssClass="QH_TextBox" height="20" width="90%" MaxLength="500"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Họ tên</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtHoTen" runat="server" Width="90%" CssClass="QH_Textbox" MaxLength="100"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Số CMND</TD>
											<td class="QH_ColControl"><asp:textbox id="txtSoCMND" runat="server" CssClass="QH_TextBox" width="50%" MaxLength="9"></asp:textbox></td>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Số nhà</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoNha" Width="50%" CssClass="QH_TextBox" Runat="server" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Ðường</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaDuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Phường</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaPhuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngành kinh doanh</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlNganh" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="50%">
									<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>
												<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td colSpan="2"><asp:label id="Label4" Width="100%" CssClass="QH_Label_Title1" Runat="server">Thông tin kiểm tra</asp:label></td>
													</tr>
													<tr>
														<td width="20%"></td>
														<td width="80%"><asp:checkbox id="chkViPham" runat="server" cssclass="QH_Option"></asp:checkbox><asp:label id="Label1" runat="server" CssClass="QH_LabelLeftBold">
																<strong>Kiểm tra vi phạm hành chính</strong></asp:label></td>
													</tr>
													<tr>
														<td width="20%"></td>
														<td width="80%"><asp:checkbox id="chkNganhCam" runat="server" cssclass="QH_Option"></asp:checkbox><asp:label id="Label2" runat="server" CssClass="QH_LabelLeftBold">
																<strong>Kiểm tra đường phường cấm</strong></asp:label></td>
													</tr>
													<tr>
														<td width="20%"></td>
														<td width="80%"><asp:checkbox id="chkNganhDieuKien" runat="server" cssclass="QH_Option"></asp:checkbox><asp:label id="Label3" runat="server" CssClass="QH_LabelLeftBold">
																<strong>Kiểm tra ngành kinh doanh có điều kiện</strong></asp:label></td>
													</tr>
													<tr>
														<td width="20%"></td>
														<td width="80%"><asp:checkbox id="chkThongTinDKKD" runat="server" cssclass="QH_Option"></asp:checkbox><asp:label id="Label5" runat="server" CssClass="QH_LabelLeftBold">
																<strong>Kiểm tra bảng hiệu, người đứng tên</strong></asp:label></td>
													</tr>
													<tr>
														<td width="20%"></td>
														<td width="80%"><asp:checkbox id="chkSoCMND" runat="server" cssclass="QH_Option"></asp:checkbox><asp:label id="Label7" runat="server" CssClass="QH_LabelLeftBold">
																<strong>Kiểm tra số CMND</strong></asp:label></td>
													</tr>
													<tr>
														<td colSpan="2" height="5"></td>
													</tr>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td height="10"></td>
										</tr>
										<tr>
											<td align="center"><asp:linkbutton id="btnKiemTra" runat="server" CssClass="QH_Button">Kiểm tra</asp:linkbutton></td>
										</tr>
										<tr>
											<td><asp:label id="lblViPham" runat="server" Visible="False" Font-Bold="True" Font-Italic="True"
													ForeColor="#ff0000">- Không có trường hợp nào vi phạm hành chính</asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblDuongPhuongCam" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#ff0000">- Không thuộc đường phường, ngành cấm</asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblNganhDK" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#ff0000">- Không thuộc ngành kinh doanh có điều kiện</asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblThongTinDKKD" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#ff0000">- Không tồn tại bảng hiệu, người đứng tên</asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblSoCMND" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#ff0000">- Không tồn tại số CMND</asp:label></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<TD align="center" colSpan="4"><asp:label id="lblDanhSachViPham" runat="server" CssClass="QH_Label_Title1" Visible="False">Thông tin vi phạm hành chính</asp:label></TD>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:datagrid id="dgdDanhSachViPham" Width="100%" CssClass="QH_DataGridBottom" Runat="server"
										CellPadding="3" AllowPaging="True" autogeneratecolumns="False" PageSize="2">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="STT">
												<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSachViPham.CurrentPageIndex*dgdDanhSachViPham.PageSize + dgdDanhSachViPham.Items.Count+1 %>' />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="SoQuyetDinh" HeaderText="Số quyết định">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SoGiayPhep" HeaderText="Số GCN ĐKKD">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SoCMND" HeaderText="Số CMND">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DiaChi" HeaderText="Địa chỉ">
												<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NoiDung" HeaderText="Nội dung vi phạm">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
							<tr>
								<TD align="center" colSpan="4"><asp:label id="lblDanhSachNganhCam" runat="server" CssClass="QH_Label_Title1" Visible="False">Thông tin đường phường cấm</asp:label></TD>
							</tr>
							<TR>
								<TD align="center" colSpan="4"><asp:datagrid id="dgdDanhSachNganhCam" Width="100%" CssClass="QH_DataGridBottom" Runat="server"
										CellPadding="3" AllowPaging="True" autogeneratecolumns="False">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="STT">
												<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label align=center id="Label6" Enabled="True" runat="server" Text='<%# dgdDanhSachNganhCam.CurrentPageIndex*dgdDanhSachNganhCam.PageSize + dgdDanhSachNganhCam.Items.Count+1 %>' />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="Ngành kinh doanh" DataField="TenNganh">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Cấm từ ngày" DataField="CamTuNgay">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Cấm đến ngày" DataField="CamDenNgay">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Loại cấm" DataField="Loai">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Đường/Phường cấm" DataField="ChuoiDuongPhuongCam">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<tr>
								<TD align="center" colSpan="4"><asp:label id="lblDanhSachNganhDK" runat="server" CssClass="QH_Label_Title1" Visible="False">Thông tin ngành kinh doanh có điều kiện</asp:label></TD>
							</tr>
							<TR>
								<TD align="center" colSpan="4"><asp:datagrid id="dgdDanhSachNganhDK" Width="100%" CssClass="QH_DataGridBottom" Runat="server"
										CellPadding="3" AllowPaging="True" autogeneratecolumns="False">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="STT">
												<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label align=center id="Label8" Enabled="True" runat="server" Text='<%# dgdDanhSachNganhDK.CurrentPageIndex*dgdDanhSachNganhDK.PageSize + dgdDanhSachNganhDK.Items.Count+1 %>' />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="Ngành kinh doanh" DataField="TenNganh">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Có chứng chỉ" DataField="CoChungChi">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Có vốn tối thiểu" DataField="CoVonToiThieu">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Số vốn tối thiểu" DataField="SoVonToiThieu">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Nội dung" DataField="NoiDung">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<tr>
								<TD align="center" colSpan="4"><asp:label id="lblDanhSachThongTinDKKD" runat="server" CssClass="QH_Label_Title1" Visible="False">Thông tin đăng ký kinh doanh</asp:label></TD>
							</tr>
							<TR>
								<TD align="center" colSpan="4"><asp:datagrid id="dgdDanhSachThongTinDKKD" Width="100%" CssClass="QH_DataGridBottom" Runat="server"
										CellPadding="3" AllowPaging="True" autogeneratecolumns="False">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="STT">
												<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label align=center id="Label9" Enabled="True" runat="server" Text='<%# dgdDanhSachThongTinDKKD.CurrentPageIndex*dgdDanhSachThongTinDKKD.PageSize + dgdDanhSachThongTinDKKD.Items.Count+1 %>' />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="SoGiayPhep" HeaderText="Số GCN ĐKKD">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NgayCap" HeaderText="Ng&#224;y cấp">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SoCMND" HeaderText="Số CMND"></asp:BoundColumn>
											<asp:BoundColumn DataField="HoTen" HeaderText="Họ t&#234;n">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DiaChi" HeaderText="Địa chỉ">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BangHieu" HeaderText="Bảng hiệu">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TenLinhVucCapPhep" HeaderText="Lĩnh vực cấp ph&#233;p">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
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
<script language="javascript">
function CheckKiemTra()
{
	var objChkViPham = document.forms[0].all("<%=me.chkViPham.ClientID%>");
	var objChkNganhCam = document.forms[0].all("<%=me.chkNganhCam.ClientID%>");
	var objChkNganhDK = document.forms[0].all("<%=me.chkNganhDieuKien.ClientID%>");
	var objChkThongTinDKKD = document.forms[0].all("<%=me.chkThongTinDKKD.ClientID%>");
	
	var objSoGiayPhep = document.forms[0].all("<%=Me.txtSoGiayPhep.ClientID%>");
	var objBangHieu = document.forms[0].all("<%=Me.txtBangHieu.ClientID%>");
	var objHoTen = document.forms[0].all("<%=Me.txtHoTen.ClientID%>");
	var objSoCMND = document.forms[0].all("<%=Me.txtSoCMND.ClientID%>");
	var objSoNha = document.forms[0].all("<%=Me.txtSoNha.ClientID%>");
	var objDuong = document.forms[0].all("<%=Me.ddlMaDuong.ClientID%>");
	var objPhuong = document.forms[0].all("<%=Me.ddlMaPhuong.ClientID%>");
	var objNganh = document.forms[0].all("<%=Me.ddlNganh.ClientID%>");
	
	//kiểm tra có chọn loại kiểm tra chưa?
	if ( !(objChkViPham.checked) && !(objChkNganhCam.checked) &&
			!(objChkNganhDK.checked) && !(objChkThongTinDKKD.checked) && !(objChkSoCMND.checked) )
	{
		alert('Ban phai chon loai thong tin kiem tra!');
		return false;
	}
	//kiểm tra có nhập thông tin để kiểm tra vi phạm hành chính
	if (objChkViPham.checked)
	{
		if (trim(objSoGiayPhep.value) == '' && trim(objSoCMND.value) == ''
				&& trim(objSoNha.value) == '' && objDuong.value == '' && objPhuong.value == '')
		{
			alert('Ban phai nhap mot trong cac thong tin sau de kiem tra vi pham hanh chinh:\n	- So giay phep\n	- So CMND\n	- Dia chi(so nha, duong, phuong)');
			objSoGiayPhep.focus();
			return false;
		}
	}
	//kiểm tra có nhập thông tin kiểm tra đường phường cấm
	if (objChkNganhCam.checked)
	{
		if (objDuong.value == '' && objPhuong.value == '' && objNganh.value == '')
		{
			alert('Ban phai nhap mot trong cac thong tin sau de kiem tra duong phuong cam:\n	- Nganh cam kinh doanh\n	- Duong, phuong cam');
			objDuong.focus();
			return false;
		}
	}
	//kiểm tra có nhập thông tin ngành kinh doanh có điều kiện
	if (objChkNganhDK.checked)
	{
		if (objNganh.value == '')
		{
			alert('Ban phai chon nganh kinh doanh de kiem tra nganh kinh doanh co dieu kien');
			objNganh.focus();
			return false;
		}
	}
	//kiểm tra thông tin đăng ký kinh doanh
	if (objChkThongTinDKKD.checked)
	{
		if (trim(objBangHieu.value) == '' && trim(objHoTen.value) == '')
		{
			alert('Ban phai nhap mot trong cac thong tin sau de kiem tra bang hieu, nguoi dung ten:\n	- Bang hieu\n	- Nguoi dung ten');
			objBangHieu.focus();
			return false;
		}
	}
	//kiểm tra thông tin số cmnd
	if (objChkSoCMND.checked)
	{
		if (trim(objSoCMND.value) == '')
		{
			alert('Ban phai nhap so cmnd');
			objSoCMND.focus();
			return false;
		}
	}
	return true;
}
</script>
