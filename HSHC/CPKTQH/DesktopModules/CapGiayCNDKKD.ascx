<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="uc2" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapGiayCNDKKD.ascx.vb" Inherits="CPKTQH.CapGiayCNDKKD" %>
<%@ Register TagPrefix="cc2" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter><uc2:combofilter id="ctrlScriptComboFilterPhuong" runat="server"></uc2:combofilter>
<script language=javascript src='<%= ResolveUrl("~/Inc/Common.js")%>'></script>
<script language=javascript src='<%= ResolveUrl("~/Inc/popcalendar.js")%>'></script>
<script language=javascript src='<%= ResolveUrl("~/Inc/Popupcalendar.js")%>'></script>
<script language="javascript">
function showWindow1(obj1,Parent)
{
		//t = screen.height - 30;
		t = 300;
		w = screen.width - 10;
		window.open(obj1,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}
function KiemTraHinhThucKinhDoanh(){
		
		if (document.getElementById("<%=ddlMaHinhThucKinhDoanh.ClientID%>").options(document.getElementById("<%=ddlMaHinhThucKinhDoanh.ClientID%>").selectedIndex).value=='TV') {
			document.all("<%=txtNgayHetHan.ClientID%>").disabled=false;
			document.all("<%=imgNgayHetHan.ClientID%>").disabled=false;
			document.all("<%=txtNgayHetHan.ClientID%>").focus();
		}
		else {
			document.all("<%=txtNgayHetHan.ClientID%>").disabled=true;
			document.all("<%=imgNgayHetHan.ClientID%>").disabled=true;
			document.all("<%=txtNgayHetHan.ClientID%>").value='';
		}
	
}
function CheckCapNhat()
{
	if (!CheckNull())
		return false;
		
	var objNgayCap = document.all("<%=txtNgayCap.ClientID%>");
	var objNgayHetHan = document.all("<%=txtNgayHetHan.ClientID%>");
	if (objNgayHetHan.value != "")
	{
		if (compareDates(objNgayCap.value, objNgayHetHan.value) == 1)
		{
			alert('Ngay het han khong duoc nho hon ngay cap GCN DKKD!');
			objNgayHetHan.select();
			objNgayHetHan.focus();
			return false;
		}
	}
	return true;
}
function upper(obj)
{
	obj.value = trim(obj.value.toUpperCase());
}
function cboPhuongThucKinhDoanh_onChanged(id, MatHangID){
	switch(id)
	{
		case "TM":
			document.getElementById(MatHangID).value = "Bán l? ";
			break;
		case "DV":
			document.getElementById(MatHangID).value = "D?ch v? ";
			break;
		case "SX":
			document.getElementById(MatHangID).value = "S?n xu?t - Gia công ";
			break;
		default:
			document.getElementById(MatHangID).value = "";
	}
}

function GiayCNDKKDInfo()
{
	var objSoCMND = document.all('<%=txtSoCMND.ClientID%>');
	
	objSoCMND.value = trim(objSoCMND.value);
	
	//Open testing window
	
	CallWindow('<%=ResolveUrl("~/CPKTQH/DesktopModules/ThongTinGiayCNDKKD.aspx")%>?SoCMND=' + objSoCMND.value,'Application',500,200);
	//return false;
}

function checkGiayToCaNhan() {
	var objNgayCap			= document.all("<%=txtNgayCapCMND.ClientID%>");
	var cmdNgayCap			= document.all("<%=imgNgayCapCMND.ClientID%>");
	var objNoiCap			= document.all("<%=txtNoiCapCMND.ClientID%>");
	var objGiayToCTK		= document.all("<%=txtTenGiayChungThuc.ClientID%>");
	var objSoGiayToCTK		= document.all("<%=txtSoGiayChungThuc.ClientID%>");
	var objNgayCapGiayToCTK = document.all("<%=txtNgayCapGiayChungThuc.ClientID%>");
	var objNoiCapGiayToCTK	= document.all("<%=txtNoiCapGiayChungThuc.ClientID%>");
	var cmdNgayCapGiayToCTK = document.all("<%=imgNgayCapChungThuc.ClientID%>");	
	var obj					= document.all("<%=txtSoCMND.ClientID%>");
	
	//Neu co nhap So CMND thi se disable cac controls chung tu khac
	if (obj.value != "" && obj.value.length == 9) {		
		objGiayToCTK.disabled					= true;
		objSoGiayToCTK.disabled					= true;
		objNgayCapGiayToCTK.disabled			= true;
		objNoiCapGiayToCTK.disabled				= true;
		cmdNgayCapGiayToCTK.style.visibility	= "hidden";
	}
	else {
		objGiayToCTK.disabled					= false;
		objSoGiayToCTK.disabled					= false;
		objNgayCapGiayToCTK.disabled			= false;
		objNoiCapGiayToCTK.disabled				= false;
		cmdNgayCapGiayToCTK.style.visibility	= "visible";
	}
	
	//Neu co nhap Giay to chung tu khac thi se disable So CMND
	if (objGiayToCTK.value != "") {
		obj.disabled					= true;
		objNgayCap.disabled				= true;
		objNoiCap.disabled				= true;
		cmdNgayCap.style.visibility		= "hidden";
	}
	else {
		obj.disabled					= false;
		objNgayCap.disabled				= false;
		objNoiCap.disabled				= false;
		cmdNgayCap.style.visibility		= "visible";
	}
}
</script>
<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD height="24" width="100%">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_TopLeft" height="24" width="16"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" runat="server" CssClass="QH_Label_Title" Width="100%">Thông tin giấy chứng nhận ÐKKD</asp:label></td>
					<td class="QH_Khung_TopRight" height="24" width="16"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD align="center">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td width="*" align="left">
						<table width="98%" align="center">
							<!-- add  các user control   -->
							<tr vAlign="top">
								<TD width="100%" align="center">
									<table id="table12" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="QH_ColLabel" width="15%"><strong><asp:label id="lblDanhSach" runat="server">S&#7889; biên nh&#7853;n</asp:label></strong></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" runat="server" CssClass="QH_Textbox" Width="50%" ReadOnly="True"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%"><strong><asp:linkbutton id="btnSoGiayPhep" runat="server">Số GCN ÐKKD cũ <FONT color="#ff0000" size="4">*</FONT></asp:linkbutton></strong></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" runat="server" Width="50%" Font-Bold="True" ForeColor="Navy"
													AutoPostBack="True" MaxLength="20"></asp:textbox>&nbsp;</td>
										</tr>
										<tr>
											<td class="QH_ColLabel" height="20" align="right"><strong><asp:label id="lblSo" runat="server">Số GCN ÐKKD</asp:label></strong></td>
											<td>&nbsp;&nbsp;<asp:label id="lblLabelSoGiayPhepMoi" runat="server" Font-Bold="True" ForeColor="Navy"></asp:label></td>
											<td></td>
											<td></td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td width="100%" colSpan="4"><asp:label id="Label1" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><strong>Thông 
														tin người đại diện</strong></asp:label></td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel" width="30%">Họ và tên <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoTen" runat="server" CssClass="QH_textbox" Width="75%" MaxLength="100" EnableViewState="true"></asp:textbox>&nbsp;&nbsp;<asp:dropdownlist id="ddlGioiTinh" runat="server" CssClass="QH_DropDownList" Width="21%" EnableViewState="true">
																<asp:ListItem Value="1">Nam</asp:ListItem>
																<asp:ListItem Value="0">Nữ</asp:ListItem>
															</asp:dropdownlist></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="30%">Ngày sinh <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtNgaySinh" CssClass="QH_TextBox" Width="70px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgaySinh" CssClass="CommandButton" Runat="server">
																<asp:image id="imgNgaySinh" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
															</asp:hyperlink></td>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Quốc tịch</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtQuocTich" CssClass="QH_TextBox" Width="100%" MaxLength="100" Runat="server"
																value="Việt Nam"></asp:textbox></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Dân tộc</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtDanToc" CssClass="QH_TextBox" Width="100%" MaxLength="100" Runat="server"
																value="Kinh"></asp:textbox></TD>
													</tr>
													<tr>
														<TD class="QH_ColLabel">Số CMND <FONT color="#ff0000" size="4">*</FONT></TD>
														<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" CssClass="QH_TextBox" Width="30%" MaxLength="20" Runat="server"></asp:textbox></TD>
													</tr>
												</table>
											</td>
											<td vAlign="top" colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel">Ngày cấp</td>
														<td class="QH_ColControl"><asp:textbox id="txtNgayCapCMND" CssClass="QH_TextBox" Width="70px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayCapCMND" CssClass="CommandButton" Runat="server">
																<asp:image id="imgNgayCapCMND" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
															</asp:hyperlink></td>
													</tr>
													<TR>
														<td class="QH_ColLabel" height="25">Nơi&nbsp;cấp</td>
														<td class="QH_ColControl" height="25"><asp:textbox id="txtNoiCapCMND" CssClass="QH_TextBox" Width="100%" MaxLength="500" Runat="server"
																value="Công an thành phố Cần Thơ"></asp:textbox></td>
													</TR>
													<tr>
														<td class="QH_ColLabel">Thường trú <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl"><asp:textbox id="txtThuongTru" CssClass="QH_TextBox" Width="100%" MaxLength="500" Runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Chỗ&nbsp;ở&nbsp;&nbsp;hiện nay</td>
														<td class="QH_ColControl"><asp:textbox id="txtChoOHienNay" CssClass="QH_TextBox" Width="100%" MaxLength="500" Runat="server"></asp:textbox></td>
													</tr>
													<tr>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td width="100%" colSpan="4"><asp:label id="Label4" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><strong>Thông 
														tin chứng thực cá nhân khác</strong></asp:label></td>
										</tr>
										<tr>
											<td height="20" colSpan="4"></td>
										</tr>
										<tr>
											<td colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel" width="30%">Tên giấy tờ</td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtTenGiayChungThuc" runat="server" CssClass="QH_textbox" Width="75%" MaxLength="100"
																EnableViewState="true"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Số giấy chứng thực</td>
														<td class="QH_ColControl"><asp:textbox id="txtSoGiayChungThuc" CssClass="QH_TextBox" Width="30%" MaxLength="50" Runat="server"></asp:textbox></td>
													</tr>
												</table>
											</td>
											<td colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel" width="30%">Ngày cấp chứng thực</td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtNgayCapGiayChungThuc" CssClass="QH_TextBox" Width="70px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayCapGiayChungThuc" CssClass="CommandButton" Runat="server">
																<asp:image id="imgNgayCapChungThuc" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
															</asp:hyperlink></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Nơi cấp chứng thực</td>
														<td class="QH_ColControl"><asp:textbox id="txtNoiCapGiayChungThuc" CssClass="QH_TextBox" Width="100%" MaxLength="500" Runat="server"></asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td width="100%" colSpan="4"><asp:label id="lblKinhDoanh" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><strong>Ðịa 
														chỉ kinh doanh</strong></asp:label></td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td vAlign="top" colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel" width="30%">Bảng hiệu</td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtBangHieu" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
																EnableViewState="true"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Số nhà
														</td>
														<td class="QH_ColControl"><asp:textbox id="txtSoNha" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
																EnableViewState="true"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Phường <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl"><cc2:keysortdropdownlist id="ddlMaPhuong" runat="server" CssClass="QH_DropDownList" Width="100%"></cc2:keysortdropdownlist></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Ðường <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl"><cc2:keysortdropdownlist id="ddlMaDuong" runat="server" CssClass="QH_DropDownList" Width="100%"></cc2:keysortdropdownlist></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Ðịa chỉ</td>
														<td class="QH_ColControl"><asp:textbox id="txtDiaChiCu" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="500"
																EnableViewState="true"></asp:textbox></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel" width="30%">Ðiện thoại</td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtDienThoai" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="50"
																EnableViewState="true"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Fax</td>
														<td class="QH_ColControl"><asp:textbox id="txtFax" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="50" EnableViewState="true"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Email</td>
														<td class="QH_ColControl"><asp:textbox id="txtEmail" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
																EnableViewState="true"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Website</td>
														<td class="QH_ColControl"><asp:textbox id="txtWebsite" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
																EnableViewState="true"></asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td width="100%" colSpan="4"><asp:label id="Label3" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><strong>Thông 
														tin kinh doanh</strong></asp:label></td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel" width="30%">Lĩnh vực&nbsp;CP<FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl" width="70%"><asp:dropdownlist id="ddlMaPhuongThucKinhDoanh" runat="server" CssClass="QH_Dropdownlist" Width="100%"
																AutoPostBack="True"></asp:dropdownlist></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" height="22">Ngành&nbsp;KD <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl" height="22"><asp:dropdownlist id="ddlMaNganh" runat="server" CssClass="QH_DropDownList" Width="100%" EnableViewState="true"
																AutoPostBack="True"></asp:dropdownlist></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" rowSpan="2">Mặt hàng&nbsp;KD<FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl"><asp:textbox id="txtMatHangKinhDoanh" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="1000"
																EnableViewState="true" Rows="2" TextMode="MultiLine"></asp:textbox></td>
													</tr>
												</table>
											</td>
											<td colSpan="2">
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="QH_ColLabel" width="30%">Tổng số lao động</td>
														<td class="QH_ColControl" width="70%"><asp:textbox style="Z-INDEX: 0" id="txtTongSoLaoDong" runat="server" CssClass="QH_TextRight"
																Width="50%" MaxLength="15" EnableViewState="true"></asp:textbox></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="30%">Vốn kinh doanh <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtVonKinhDoanh" runat="server" CssClass="QH_TextRight" Width="50%" MaxLength="15"
																EnableViewState="true"></asp:textbox>&nbsp;
															<asp:label id="lblLabelDonViTinh" runat="server"></asp:label></td>
													</tr>
													<!--
													<tr>
														<td class="QH_ColLabel">Hình th?c&nbsp;KD</td>
														<td class="QH_ColControl"><asp:dropdownlist id="ddlMaHinhThucKinhDoanh" runat="server" Width="50%" CssClass="QH_DropDownList"
																EnableViewState="true"></asp:dropdownlist></td>
													</tr>
													-->
													<tr>
														<td class="QH_ColLabel">Ngày cấp <FONT color="#ff0000" size="4">*</FONT></td>
														<td class="QH_ColControl"><asp:textbox id="txtNgayCap" CssClass="QH_TextBox" Width="70px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayCap" CssClass="CommandButton" Runat="server">
																<asp:image id="imgNgayCap" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
															</asp:hyperlink></td>
													</tr>
													<tr>
														<td class="QH_ColLabel">Ngày hết hạn</td>
														<td class="QH_ColControl"><asp:textbox id="txtNgayHetHan" CssClass="QH_TextBox" Width="70px" MaxLength="10" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayHetHan" CssClass="CommandButton" Runat="server">
																<asp:image id="imgNgayHetHan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
															</asp:hyperlink></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td width="100%" colSpan="4"><asp:label id="Label6" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><strong>Danh 
														sách cá nhân góp vốn thành lập hộ kinh doanh</strong></asp:label></td>
										</tr>
										<tr>
											<td colSpan="4">
												<table border="0" cellSpacing="0" cellPadding="0" width="80%" align="center">
													<tr>
														<td align="center"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="90%" Runat="server" CellPadding="3"
																AllowSorting="True" AutoGenerateColumns="False">
																<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
																	<asp:BoundColumn DataField="STT" HeaderText="STT">
																		<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="T&#234;n th&#224;nh vi&#234;n">
																		<ItemStyle Width="10%"></ItemStyle>
																		<ItemTemplate>
																			<input type="text" runat="server" id="txtTenThanhVien" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.TenThanhVien")%>' NAME="txtTenThanhVien">
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Thường trú">
																		<ItemStyle Width="15%"></ItemStyle>
																		<ItemTemplate>
																			<input type="text" runat=server id="txtThanhVienThuongTru" style="width:200" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.ThanhVienThuongTru")%>' NAME="txtThanhVienThuongTru">
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Giá trị góp vốn">
																		<ItemStyle Width="10%"></ItemStyle>
																		<ItemTemplate>
																			<input type="text" runat=server id="txtGiaTriGopVon" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.GiaTriGopVon")%>' NAME="txtGiaTriGopVon">
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Tỉ lệ góp vốn (%)">
																		<ItemStyle Width="5%"></ItemStyle>
																		<ItemTemplate>
																			<input type="text" runat=server id="txtTyLeGopVon" style="width:50" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.TyLeGopVon")%>' NAME="txtTyLeGopVon">
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Số CMND (hoặc giấy tờ khác)">
																		<ItemStyle Width="35%"></ItemStyle>
																		<ItemTemplate>
																			<input type="text" runat=server id="txtThanhVienCMND" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.ThanhVienCMND")%>' NAME="txtThanhVienCMND">
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Ghi chú">
																		<ItemStyle Width="180px"></ItemStyle>
																		<ItemTemplate>
																			<input type="text" runat="server" id="txtThanhVienGhiChu" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.ThanhVienGhiChu")%>' NAME="txtThanhVienGhiChu">
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Text="Lưu" CommandName="Update">
																		<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Text="Xóa" CommandName="Delete">
																		<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
																	</asp:ButtonColumn>
																</Columns>
															</asp:datagrid></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td width="100%" colSpan="4"><asp:label id="Label2" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><strong>Ghi 
														chú</strong></asp:label></td>
										</tr>
										<tr>
											<td height="5" colSpan="4"></td>
										</tr>
										<tr>
											<td class="QH_ColLabel">Người ký</td>
											<td class="QH_ColControl"><asp:dropdownlist id="ddlMaSoLanhDao" runat="server" CssClass="QH_DropDownList" Width="100%"></asp:dropdownlist></td>
											<td vAlign="top" rowSpan="2" colSpan="2" align="center">
												<table border="0" cellSpacing="0" cellPadding="0" width="85%">
													<tr>
														<td height="37"><asp:label id="lblKetQuaKiemTraBangHieu" runat="server" Font-Bold="True" ForeColor="#ff0000"
																Font-Italic="True"></asp:label><asp:linkbutton id="hplDanhSachBangHieu" runat="server" CausesValidation="False"><br>Click vào đây để xem danh sách trùng bảng hiệu</asp:linkbutton></td>
													</tr>
													<tr>
														<td><A href="javascript:call GiayCNDKKDInfo();"><asp:label id="lblKetQuaKiemTraSoCMND" runat="server" Font-Bold="True" ForeColor="#ff0000"
																	Font-Italic="True"></asp:label></A></td>
													</tr>
													<tr>
														<td height="37"><asp:label id="lblKetQuaKiemTraDiaChiDKKD" runat="server" Font-Bold="True" ForeColor="#ff0000"
																Font-Italic="True"></asp:label><asp:linkbutton id="hplDanhSachDiaChi" runat="server" CausesValidation="False"><br>Click vào đây để xem danh sách trùng địa chỉ</asp:linkbutton></td>
													</tr>
													<tr>
														<td><asp:label id="lblKetQuaThongTin" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="lblKetQuaVPHC" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="lblKetQuaNganhCam" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="lblKetQuaNganhDieuKien" runat="server" Font-Bold="True" ForeColor="#ff0000"
																Font-Italic="True"></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td class="QH_ColLabel">Ghi chú</td>
											<td class="QH_ColControl"><asp:textbox id="txtGhiChu" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="1000"
													EnableViewState="true" Rows="3" TextMode="MultiLine"></asp:textbox></td>
										</tr>
									</table>
								</TD>
							</tr>
							<tr>
								<td align="center"><asp:checkbox id="chkDoiSo" runat="server" Visible="False" Text="Đổi số giấy phép đối với giấy chứng nhận cũ"
										Font-Bold="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td height="10" colSpan="4"></td>
							</tr>
							<tr>
								<td align="center"><asp:linkbutton id="btnKiemTra" runat="server" CssClass="QH_Button"> Ki&#7875;m tra h&#7891; s&#417;</asp:linkbutton>&nbsp;<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">C&#7853;p nh&#7853;t</asp:linkbutton>&nbsp;<asp:linkbutton id="btnDeXuat" runat="server" CssClass="QH_Button">&#272;&#7873; xu&#7845;t</asp:linkbutton>&nbsp;<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In GCN ÐKKD</asp:linkbutton>&nbsp;<asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button">Tr&#7903; v&#7873;</asp:linkbutton>&nbsp;<asp:linkbutton id="btnYCBS" runat="server" CssClass="QH_Button">B&#7893; sung h&#7891; s&#417;</asp:linkbutton>
									<asp:linkbutton id="btnHoSoKhong" runat="server" CssClass="QH_Button"> Không gi&#7843;i quy&#7871;t</asp:linkbutton><BR>
								</td>
							</tr>
						</table>
						<!-- Content --><INPUT id="cMsg" type="hidden" name="cMsg" runat="server"> <INPUT id="hMsg" type="hidden" name="hMsg" runat="server"><input id="KiemTra" value="0" type="hidden" name="KiemTra" runat="server">
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
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
<asp:dropdownlist id="ddlMaLinhVucCapPhep" runat="server" CssClass="QH_Dropdownlist" Width="0px"></asp:dropdownlist><asp:textbox id="txtThanhVienIDXoa" runat="server" CssClass="QH_textbox" Width="0px" Visible="False"></asp:textbox>
<div style="DISPLAY: none"><asp:textbox id="txtMaSoNguoiSuDung" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtGiayCNDKKDIDMoi" Width="40px" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="lblSoGiayPhepMoi" Runat="server" Enabled="False"></asp:textbox></div>
<asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaLoaiDoanhNghiep" runat="server" Width="20px" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Width="20px" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Width="20px" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Width="20px" Visible="False"></asp:textbox><asp:textbox id="txtGiayCNDKKDID" runat="server" Width="0px"></asp:textbox><asp:textbox style="Z-INDEX: 0" id="txtGiayCNDKKDID1" runat="server" Width="0px"></asp:textbox>
<script>
		if (document.all("<%=hMsg.ClientID%>").value != ''){
			alert(document.all("<%=hMsg.ClientID%>").value);
			document.all("<%=hMsg.ClientID%>").value='';
		}
		//m?c d?nh vi?t hoa
		upper(document.all("<%=txtBangHieu.ClientID%>"));
		upper(document.all("<%=txtHoTen.ClientID%>"));

</script>
