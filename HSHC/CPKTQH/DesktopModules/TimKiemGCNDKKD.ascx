<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TimKiemGCNDKKD.ascx.vb" Inherits="CPKTQH.TimKiemGCNDKKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter><link 
href='<%= Request.ApplicationPath + "/Portals/_default/Skins/LIGHTBLUESKIN/LightBlueskin.css" %>' 
type=text/css rel=stylesheet>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
	<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
	<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
	<script language="javascript"> 
function select_deselect (chk) 
{ 
	var frm = document.forms[0];
	var i;
	var objchk;
	var obj;
	var txt;
	for (i=0;i<window.document.forms(0).length;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chk) != -1)
		{
			objchk = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtSoGiayPhepChon') != -1)
		{
			txt = window.document.forms(0).item(i);	
		}
	}
	for (i=0;i<window.document.forms(0).length;i++)
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
	settxtSoBienNhanChon(objchk,txt);
}
function settxtSoBienNhanChon(chk,txt)
{

var j;
var tenchkChon;
for (j=3; j<eval('document.forms[0].all("dgdDanhSach")').rows.length+2 ; j++)
				{
					tenchkChon = "dgdDanhSach__ctl" + j + "_chkXoa";
					if(tenchkChon==chk.id){
					txt.value = eval('document.forms[0].all("dgdDanhSach")').rows(j-2).cells(2).innerText
					
					}
				}
}				
	</script>
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td height="5"></td>
		</tr>
		<TR>
			<TD width="100%" height="24">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="QH_Khung_TopLeft" width="16" height="24"></td>
						<td class="QH_Khung_TopMid" width="*">&nbsp;
							<asp:label id="Label3" runat="server" CssClass="QH_Label_Title" Width="100%">Danh sách hộ cá thể trên địa bàn</asp:label></td>
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
								<tr>
									<td height="5"></td>
								</tr>
								<tr>
									<TD vAlign="top" align="center" width="50%">
										<TABLE class="QH_Table" id="Table21" cellSpacing="0" cellPadding="0" width="100%" align="center"
											border="0">
											<tr>
												<TD class="QH_ColLabel" width="30%">Tình trạng giấy phép</TD>
												<TD class="QH_ColControl" width="70%"><asp:dropdownlist id="ddlTinhTrangHienTai" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Lĩnh vực cấp phép</TD>
												<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaPhuongThucKinhDoanh" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist>
													<asp:dropdownlist id="ddlLinhVucCapPhep" CssClass="QH_DropDownList" Width="0%" Runat="server"></asp:dropdownlist></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Ngành kinh doanh</TD>
												<TD class="QH_ColControl"><asp:dropdownlist id="ddlNganhKinhDoanh" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Mặt hàng kinh doanh</TD>
												<TD class="QH_ColControl"><asp:textbox id="txtMatHang" runat="server" CssClass="QH_Textbox" Width="90%" TextMode="MultiLine"
														Rows="2" Height="60px"></asp:textbox></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Bảng hiệu</TD>
												<TD class="QH_ColControl"><asp:textbox id="txtBangHieu" runat="server" CssClass="QH_Textbox" Width="90%" MaxLength="100"></asp:textbox></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Số CNMD</TD>
												<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" runat="server" CssClass="QH_Textbox" Width="90%" MaxLength="100"></asp:textbox></TD>
											</tr>
										</TABLE>
									</TD>
									<TD vAlign="top" align="center" width="50%">
										<TABLE class="QH_Table" id="Table22" cellSpacing="0" cellPadding="0" width="100%" align="center"
											border="0">
											<tr>
												<TD class="QH_ColLabel" width="30%">Họ tên</TD>
												<TD class="QH_ColControl" width="70%"><asp:textbox id="txtHoTen" runat="server" CssClass="QH_Textbox" Width="90%" MaxLength="100"></asp:textbox></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel" width="30%">Số nhà</TD>
												<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Width="90%" Runat="server" MaxLength="100"></asp:textbox></TD>
											<tr>
												<TD class="QH_ColLabel">Phường</TD>
												<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel" height="15">Ðường</TD>
												<TD class="QH_ColControl" height="15"><asp:dropdownlist id="ddlDuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Số GCN ĐKKD</TD>
												<TD class="QH_ColControl"><asp:textbox id="txtSoGiayPhep" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="20"></asp:textbox></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Từ ngày</TD>
												<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
													<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
														<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
													</asp:hyperlink></TD>
											</tr>
											<tr>
												<TD class="QH_ColLabel">Ðến ngày</TD>
												<TD class="QH_ColControl"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
													<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
														<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
													</asp:hyperlink></TD>
											</tr>
										</TABLE>
									</TD>
								</tr>
								<TR>
									<TD colSpan="5" height="10"></TD>
								</TR>
								<tr>
									<td align="center" colSpan="2"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>&nbsp;
										<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In danh sách</asp:linkbutton></td>
								</tr>
								<TR>
									<td class="QH_LabelLeft" align="left" width="50%"><asp:label id="Label2" Runat="server">Tổng số GCN ĐKKD: </asp:label><strong><asp:label id="lblTongSoHoSo" Runat="server"></asp:label></strong></td>
									<td align="right" width="50%"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="30px" Runat="server" MaxLength="3"
											AutoPostBack="True"></asp:textbox></td>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGridBottom" Width="100%" Runat="server" CellPadding="3"
											autogeneratecolumns="False" AllowPaging="True">
											<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
											<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
											<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="STT">
													<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn HeaderText="GiayCNDKKDID" DataField="GiayCNDKKDID" Visible="False"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Số GCN ĐKKD" HeaderStyle-HorizontalAlign="Center">
													<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink ID="hplSoGiayPhep" Runat="server" text='<%#DataBinder.Eval(Container,"DataItem.SoGiayPhep")%>' NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.URL")%>'>
														</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn HeaderText="Họ tên" HeaderStyle-HorizontalAlign="Center" DataField="HoTen">
													<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="Địa chỉ kinh doanh" HeaderStyle-HorizontalAlign="Center" DataField="DiaChi">
													<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="Bảng hiệu" HeaderStyle-HorizontalAlign="Center" DataField="BangHieu">
													<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="Tình trạng" HeaderStyle-HorizontalAlign="Center" DataField="TinhTrang">
													<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
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
