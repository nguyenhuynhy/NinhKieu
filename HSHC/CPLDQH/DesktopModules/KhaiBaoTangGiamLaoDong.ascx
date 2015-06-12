<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="KhaiBaoTangGiamLaoDong.ascx.vb" Inherits="CPLDQH.KhaiBaoTangGiamLaoDong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">

function btnCapNhat_clicked()
{
	var txtSuDungLaoDongID = document.all("<%=txtSuDungLaoDongID.clientID%>")
	if (txtSuDungLaoDongID.value=="")
	{
		alert("Chua chon Doanh nghiep");
		return false;
	}

	return true;
	
} 
function SetStatus(CheckID,ThayDoiID)
{
		var i;
		var objCheck,objThayDoi;
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			if (window.document.forms(0).item(i).id == CheckID)
			{
				objCheck=window.document.forms(0).item(i);
			}
			if (window.document.forms(0).item(i).id == ThayDoiID)
			{
				objThayDoi=window.document.forms(0).item(i);
			}
			
		}
		objThayDoi.disabled = !objCheck.checked;
	
}
function CallNganhNghe(strURL,Parent,chk)
{		
		if (chk.checked==false)
		{	
			return;
		}
		strURL = GetParams(strURL);
		showWindow1(strURL,Parent);		
}
function showWindow1(obj1,Parent)
{
		//t = screen.height - 30;
		t = 300;
		w = screen.width - 10;
		window.open(obj1,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}

</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
	<tr>
		<td colSpan="2">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">Khai báo tăng giảm lao động</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD vAlign="top" width="50%">
			<table class="QH_Table" width="100%">
				<tr>
					<td class="QH_ColLabel" width="30%">Số biên nhận</td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtSoBienNhan" runat="server" Width="90%" CssClass="QH_Textbox" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%" height="18">Ngày nhận<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtNgayNhan" runat="server" Width="50%" CssClass="QH_Textbox" MaxLength="10"
							tabIndex="1"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayNhan" CssClass="CommandButton" Runat="server">
							<asp:image id="imgNgayNhan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%"><asp:linkbutton id="btnDanhSachDV" runat="server" Visible="False">Tên đơn vị</asp:linkbutton><asp:label id="lblDanhSachDV" runat="server" Visible="False">Tên đơn vị</asp:label><font color="#ff0000" size="2">&nbsp;*</font><asp:textbox id="txtSuDungLaoDongID" CssClass="QH_TextBox" Width="0" Runat="server" AutoPostBack="True"></asp:textbox></td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtHoTen" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="2" Enabled="False"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Tên chủ đơn vị</td>
					<td class="QH_ColControl" colSpan="3"><asp:textbox id="txtTenChuDonVi" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="3"
							Enabled="False"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%" height="20"><asp:label id="Label5" runat="server">Loại hình DN</asp:label></td>
					<td class="QH_ColControl" colSpan="3" height="20"><asp:dropdownlist id="ddlMaLoaiHinhDoanhNghiep" runat="server" Width="90%" CssClass="QH_DropDownList"
							tabIndex="4" Enabled="False"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Tổng số LĐ</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtTongSoLaoDong" runat="server" Width="70%" CssClass="QH_TextRight" MaxLength="5"
							tabIndex="5" Enabled="False"></asp:textbox></td>
					<td class="QH_ColLabel" width="15%">LĐ nữ
					</td>
					<td class="QH_ColControl" width="25%"><asp:textbox id="txtTongSoLaoDongNu" runat="server" Width="70%" CssClass="QH_TextRight" MaxLength="5"
							tabIndex="6" Enabled="False"></asp:textbox></td>
				</tr>
			</table>
		</TD>
		<!-- Start dia chi co quan -->
		<TD vAlign="top" width="50%">
			<table class="QH_Table" width="100%">
				<tr>
					<td colSpan="2" height="23"><asp:label id="Label7" runat="server" CssClass="QH_LabelLeftBold">Địa chỉ cơ quan</asp:label></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Số nhà<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoNha" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="7" Enabled="False"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Phường<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="70%">
						<cc1:KeySortDropDownList id="ddlMaPhuong" CssClass="QH_DropDownList" Width="90%" runat="server" Enabled="False"
							tabIndex="8"></cc1:KeySortDropDownList></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Đường<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="70%">
						<cc1:KeySortDropDownList id="ddlMaDuong" CssClass="QH_DropDownList" Width="90%" runat="server" Enabled="False"
							tabIndex="9"></cc1:KeySortDropDownList></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">Điện thoại</td>
					<td class="QH_ColControl" width="70%"><asp:textbox id="txtDienThoai" runat="server" Width="90%" CssClass="QH_Textbox" tabIndex="10"
							Enabled="False"></asp:textbox></td>
				</tr>
			</table>
		</TD>
	</TR>
	<!-- End dia chi co quan -->
	<TR>
		<!--Start left DANG KI MOI -->
		<TD vAlign="top" width="50%">
			<table class="QH_Table" width="100%">
				<tr>
					<td colSpan="2"><asp:label id="Label12" runat="server" CssClass="QH_LabelLeftBold">Đăng ký mới</asp:label></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="30%">HĐLĐ ký mới</td>
					<td class="QH_ColControl" width="70%"><asp:textbox id="txtHopDongLaoDongKyMoi" runat="server" Width="50%" CssClass="QH_TextRight" MaxLength="5"
							tabIndex="11"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Trong đó nữ</td>
					<td class="QH_ColControl"><asp:textbox id="txtHopDongLaoDongKyMoiNu" runat="server" Width="50%" CssClass="QH_TextRight"
							MaxLength="5" tabIndex="12"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="QH_ColLabel">HĐLĐ gia hạn</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtHopDongLaoDongGiaHan" runat="server" Width="50%" CssClass="QH_TextRight"
							MaxLength="5" tabIndex="13"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Trong đó nữ</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtHopDongLaoDongGiaHanNu" runat="server" Width="50%" CssClass="QH_TextRight"
							MaxLength="5" tabIndex="14"></asp:textbox></TD>
				</TR>
				<tr>
					<td class="QH_ColLabel">Ngày HĐLĐ</td>
					<td class="QH_ColControl"><asp:textbox id="txtNgayHopDongLaoDong" runat="server" Width="50%" CssClass="QH_Textbox" MaxLength="10"
							tabIndex="15"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayHopDong" CssClass="CommandButton" Runat="server">
							<asp:image id="imgNgayHopDong" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Tổng thu nhập</td>
					<td class="QH_ColControl"><asp:textbox id="txtTongThuNhap" runat="server" Width="50%" CssClass="QH_TextRight" MaxLength="15"
							tabIndex="16"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Lương chính</td>
					<td class="QH_ColControl" vAlign="top" height="32"><asp:textbox id="txtLuongChinh" runat="server" Width="50%" CssClass="QH_TextRight" MaxLength="15"
							tabIndex="17"></asp:textbox></td>
				</tr>
			</table>
		</TD>
		<!--End left DANG KI MOI -->
		<!--Start Right DANG KI MOI -->
		<TD align="center" width="50%" valign="top">
			<table class="QH_Table" width="100%">
				<tr>
					<td width="50%"><asp:label id="Label18" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Hộ khẩu thành phố</asp:label></td>
					<td width="50%"><asp:label id="Label21" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Hộ khẩu tỉnh</asp:label></td>
				</tr>
				<tr>
					<!-- start HO KHAU THANH PHO -->
					<td width="50%">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="30%">Nam</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauThanhPhoNam" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="18"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Nữ</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauThanhPhoNu" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="19"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<!-- End HO KHAU THANH PHO -->
					<!-- start HO KHAU TINH -->
					<td width="50%" colSpan="2">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="30%">Nam</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTinhNam" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="20"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Nữ</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTinhNu" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="21"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- End HO KHAU TINH -->
				<tr>
					<td colSpan="2">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="35%">Số HĐLĐ không xác định</td>
								<td class="QH_ColControl" width="18%"><asp:textbox id="txtSoLaoDongKhongXacDinh" tabIndex="22" runat="server" CssClass="QH_TextRight"
										Width="88%" MaxLength="5"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Thời hạn</td>
								<td class="QH_ColControl"><asp:textbox id="txtThoiHanHDKXD" tabIndex="22" runat="server" CssClass="QH_TextRight" Width="50%"
										MaxLength="5"></asp:textbox>
									<span class="QH_LabelNote">(tháng)</span></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Số HĐLĐ từ 12 đến 36 tháng</td>
								<td class="QH_ColControl"><asp:textbox id="txtSoLaoDongXacDinh" tabIndex="23" runat="server" CssClass="QH_TextRight" Width="88%"
										MaxLength="5"></asp:textbox></td>
								<td class="QH_ColLabel">Thời hạn</td>
								<td class="QH_ColControl"><asp:textbox id="txtThoiHanHDXD" tabIndex="23" runat="server" CssClass="QH_TextRight" Width="50%"
										MaxLength="5"></asp:textbox>
									<span class="QH_LabelNote">(tháng)</span></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Số HĐLĐ dưới 12 tháng</td>
								<td class="QH_ColControl"><asp:textbox id="txtSoLaoDongThoiVu" tabIndex="24" runat="server" CssClass="QH_TextRight" Width="88%"
										MaxLength="5"></asp:textbox></td>
								<td class="QH_ColLabel">Thời hạn</td>
								<td class="QH_ColControl"><asp:textbox id="txtThoiHanHDTV" tabIndex="24" runat="server" CssClass="QH_TextRight" Width="50%"
										MaxLength="5"></asp:textbox>
									<span class="QH_LabelNote">(tháng)</span></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</TD>
		<!--End Right DANG KI MOI --></TR>
	<TR>
		<!--Start left DANG KI GIAM -->
		<TD vAlign="top" width="50%">
			<table class="QH_Table" width="100%">
				<tr>
					<td colSpan="4"><asp:label id="lblDangKyGiam" runat="server" CssClass="QH_LabelLeftBold">Đăng ký giảm</asp:label></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="15%">HĐLĐ giảm</td>
					<td class="QH_ColControl" width="25%"><asp:textbox id="txtHopDongLaoDongGiam" runat="server" Width="90%" CssClass="QH_TextRight" MaxLength="5"
							tabIndex="25"></asp:textbox></td>
					<td class="QH_ColLabel" width="15%">Trong đó nữ</td>
					<td class="QH_ColControl"><asp:textbox id="txtHopDongLaoDongGiamNu" runat="server" Width="90%" CssClass="QH_TextRight"
							MaxLength="5" tabIndex="26"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="15%">Nghĩ hưu</td>
					<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamNghiHuu" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
							tabIndex="8"></asp:textbox></td>
					<td class="QH_ColLabel" width="15%">Thôi việc</td>
					<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamThoiViec" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
							tabIndex="9"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="15%">Sa thải</td>
					<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamSaThai" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
							tabIndex="10"></asp:textbox></td>
					<td class="QH_ColLabel" width="15%">Khác</td>
					<td class="QH_ColControl" width="25%"><asp:textbox id="txtSoLDGiamKhac" CssClass="QH_TextRight" Width="90%" runat="server" MaxLength="5"
							tabIndex="11"></asp:textbox></td>
				</tr>
			</table>
		</TD>
		<!--End left DANG KI GIAM -->
		<!--Start Right DANG KI GIAM -->
		<TD align="center" width="50%" valign="top">
			<table class="QH_Table" width="100%">
				<tr>
					<td width="50%"><asp:label id="lblHoKhauTP" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Hộ khẩu thành phố</asp:label></td>
					<td width="50%"><asp:label id="lblHoKhauTinh" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Hộ khẩu tỉnh</asp:label></td>
				</tr>
				<tr>
					<!-- start HO KHAU THANH PHO -->
					<td width="50%">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="30%">Nam</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTPGiamNam" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="27"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Nữ</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTPGiamNu" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="28"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<!-- End HO KHAU THANH PHO -->
					<!-- start HO KHAU TINH -->
					<td width="50%" colSpan="2">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="30%">Nam</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTinhGiamNam" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="29"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="30%">Nữ</td>
								<td class="QH_ColControl" width="70%"><asp:textbox id="txtHoKhauTinhGiamNu" runat="server" Width="82%" CssClass="QH_TextRight" MaxLength="5"
										tabIndex="30"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- End HO KHAU TINH -->
				<tr>
					<td colSpan="2">
						<table class="QH_Table" width="100%">
							<tr>
								<td class="QH_ColLabel" width="35%">Số HĐLĐ không xác định</td>
								<td class="QH_ColControl" width="18%"><asp:textbox id="txtHopDongKXDGiam" tabIndex="35" runat="server" CssClass="QH_TextRight" Width="88%"
										MaxLength="5"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Thời hạn</td>
								<td class="QH_ColControl"><asp:textbox id="txtThoiHanHDKXDGiam" tabIndex="35" runat="server" CssClass="QH_TextRight" Width="50%"
										MaxLength="5"></asp:textbox>
									<span class="QH_LabelNote">(tháng)</span></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Số HĐLĐ từ 12 đến 36 tháng</td>
								<td class="QH_ColControl"><asp:textbox id="txtHopDongXDGiam" tabIndex="36" runat="server" CssClass="QH_TextRight" Width="88%"
										MaxLength="5"></asp:textbox></td>
								<td class="QH_ColLabel">Thời hạn</td>
								<td class="QH_ColControl"><asp:textbox id="txtThoiHanHDXDGiam" tabIndex="36" runat="server" CssClass="QH_TextRight" Width="50%"
										MaxLength="5"></asp:textbox>
									<span class="QH_LabelNote">(tháng)</span></td>
							</tr>
							<tr>
								<td class="QH_ColLabel">Số HĐLĐ dưới 12 tháng</td>
								<td class="QH_ColControl"><asp:textbox id="txtHopDongTVGiam" tabIndex="37" runat="server" CssClass="QH_TextRight" Width="88%"
										MaxLength="5"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Thời hạn</td>
								<td class="QH_ColControl"><asp:textbox id="txtThoiHanHDTVGiam" tabIndex="37" runat="server" CssClass="QH_TextRight" Width="50%"
										MaxLength="5"></asp:textbox>
									<span class="QH_LabelNote">(tháng)</span></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</TD>
		<!--End Right DANG KI GIAM --></TR>
	<TR>
		<TD vAlign="top" width="100%" colSpan="2" height="5"></TD>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" width="100%" colSpan="2"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server" tabIndex="34">C&#7853;p nh&#7853;t</asp:linkbutton> <asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server" tabIndex="35">B&#7893; sung h&#7891; s&#417;</asp:linkbutton> <asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server" tabIndex="36">H&#7891; s&#417; không gi&#7843;i quy&#7871;t</asp:linkbutton> <asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server" Visible="False" tabIndex="37">Xóa</asp:linkbutton> <asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server" tabIndex="38">Tr&#7903; v&#7873;</asp:linkbutton></TD>
	</TR>
	<tr>
		<td colspan="2">
			<table cellpadding="0" cellspacing="0" width="100%">
				<TR>
					<TD colSpan="5">
						<!--SET WIDTH=0-->
						<asp:textbox id="txtGiayCNDKKDID" CssClass="QH_TextBox" Width="0px" Runat="server" Visible="TRUE"></asp:textbox>
						<asp:textbox id="txtHoSoTiepNhanID" CssClass="QH_TextBox" Width="0px" Runat="server"></asp:textbox>
						<asp:textbox id="txtSoGiayPhepGoc" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox>
						<asp:textbox id="txtNgayCapGiayPhepGoc" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox>
						<asp:textbox id="txtReload" CssClass="QH_textbox" Width="0px" runat="server" Visible="False"></asp:textbox>
						<asp:image id="imgNgayDKBS" CssClass="QH_ImageButton" runat="server" Visible="False" AlternateText="Chọn lịch"
							ImageUrl="~\images\calendar.gif"></asp:image>
						<asp:textbox id="txtNgayDangKyBoSung" CssClass="QH_TextBox" Width="30%" Runat="server" Visible="False"></asp:textbox>
						<asp:textbox id="txtBienDongLaoDongID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaSoNguoiSuDung" runat="server" Visible="False"></asp:textbox>
						<!--SET WIDTH=0-->
					</TD>
				</TR>
			</table>
		</td>
	</tr>
</TABLE>
