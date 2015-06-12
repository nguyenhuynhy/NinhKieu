<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThayDoiNoiDungGPXD.ascx.vb" Inherits="CPXD.ThayDoiKinhDoanh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
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
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td height="5"></td>
	</tr>
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Điều chỉnh nội dung</asp:label></td>
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
					<td align="center" width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" border="0">
							<TR>
								<TD colSpan="5" height="5"></TD>
							</TR>
							<tr vAlign="top">
								<td vAlign="top" width="50%">
									<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="30%"><asp:linkbutton id="btnDanhSach" runat="server" Visible="False">Số biên nhận</asp:linkbutton><asp:label id="lblDanhSach" runat="server">Số biên nhận</asp:label><font color="#ff0000" size="4">*</font></TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="45%" runat="server" EnableViewState="true"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel"><asp:linkbutton id="btnDanhSachGP" runat="server">Số giấy phép</asp:linkbutton><asp:label id="lblDanhSachGP" runat="server" Visible="False">Số giấy phép</asp:label><font color="#ff0000" size="4">*</font></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoGiayPhep" CssClass="QH_TextBox" Width="45%" Runat="server" AutoPostBack="True"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Ngày cấp</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayCap" CssClass="QH_TextBox" Width="30%" Runat="server"></asp:textbox><asp:image id="imgNgayCapDKKD" CssClass="QH_ImageButton" runat="server" Visible="False" AlternateText="Chọn lịch"
													ImageUrl="~\images\calendar.gif"></asp:image></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ghi chú</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtGhiChu" CssClass="QH_TextBox" Width="90%" Runat="server" TextMode="MultiLine"
													Rows="1"></asp:textbox></TD>
										</TR>
									</TABLE>
								</td>
								<td vAlign="top" width="50%">
									<TABLE class="QH_Table" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="30%">Họ tên</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtHoTen" CssClass="QH_TextBox" Width="90%" Runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày ÐKTÐ<font color="#ff0000" size="4">*</font></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayThayDoi" CssClass="QH_TextBox" Width="30%" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayDKTD" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn lịch"
													ImageUrl="~\images\calendar.gif"></asp:image></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel">Ngày ÐKBS</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayDangKyBoSung" CssClass="QH_TextBox" Width="30%" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayDKBS" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn lịch"
													ImageUrl="~\images\calendar.gif"></asp:image></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Lãnh đạo ký</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaSoLanhDao" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD height="10"></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" CssClass="QH_LabelLeftBold" Runat="server">Nội dung cũ</asp:label></TD>
								<TD><asp:label id="Label1" CssClass="QH_LabelLeftBold" Runat="server">Nội dung thay đổi</asp:label></TD>
							</TR>
							<TR>
								<td vAlign="top">
									<TABLE class="QH_Table" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel">Chủ đầu tư</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtHoTenCu" CssClass="QH_TextBox" Width="90%" Runat="server" Rows="3" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Thường trú</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTruCu" CssClass="QH_TextBox" Width="90%" Runat="server" TextMode="MultiLine"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Công trình XD</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtCongTrinhXayDungCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ký hiệu thiết kế</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtKyHieuThietKeCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Đơn vị thiết kế</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDonViThietKeCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Kết cấu</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtKetCauCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">CC từng tầng</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtChieuCaoTungTangCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">CC toàn công trình</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtChieuCaoToanCongTrinhCu" CssClass="QH_TextBox" Width="90%" Runat="server"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Diện tích XD</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDienTichXayDungCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Tổng DT sàn XD</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDienTichSanXayDungCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ghi chú hạng mục</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtGhiChuHangMucCu" CssClass="QH_TextBox" Width="90%" Runat="server" TextMode="MultiLine"
													Rows="3" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Lô đất</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtLoDatCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel">Cao độ nền</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtCaoDoNenCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel" height="18">Chỉ giới</TD>
											<TD class="QH_ColControl" height="18"><asp:textbox id="txtChiGioiCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Số nhà xây dựng</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoNhaCu" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Đường</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaDuongCu" CssClass="QH_DropDownList" Width="90%" Runat="server" Enabled="False"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Phường</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaPhuongCu" CssClass="QH_DropDownList" Width="90%" Runat="server" Enabled="False"></asp:dropdownlist></TD>
										</tr>
									</TABLE>
								</td>
								<td vAlign="top">
									<TABLE class="QH_Table" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR vAlign="top">
											<TD class="QH_ColLabel" width="35%" colSpan="2">Chủ đầu tư<asp:checkbox id="chkHoTen" CssClass="" Runat="server"></asp:checkbox></TD>
											<TD class="QH_ColControl" width="*"><asp:textbox id="txtHoTenMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Rows="3" Enabled="False"></asp:textbox><asp:textbox id="txtMaNganhMoi" CssClass="QH_TextBox" Width="0px" Runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Thường trú<asp:checkbox id="chkDiaChiThuongTru" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTruMoi" CssClass="QH_TextBox" Width="90%" Runat="server" TextMode="MultiLine"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Công trình XD<asp:checkbox id="chkCongTrinhXayDung" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtCongTrinhXayDungMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Ký hiệu thiết kế<asp:checkbox id="chkKyHieuThietKe" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtKyHieuThietKeMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Đơn vị thiết kế<asp:checkbox id="chkDonViThietKe" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDonViThietKeMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Kết cấu<asp:checkbox id="chkKetCau" CssClass="" Runat="server"></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtKetCauMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">CC từng tầng<asp:checkbox id="chkChieuCaoTungTang" CssClass="" Runat="server"></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtChieuCaoTungTangMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">CC toàn công trình<asp:checkbox id="chkChieuCaoToanCongTrinh" CssClass="" Runat="server"></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtChieuCaoToanCongTrinhMoi" CssClass="QH_TextBox" Width="90%" Runat="server"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Diện tích XD<asp:checkbox id="chkDienTichXayDung" CssClass="" Runat="server"></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDienTichXayDungMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Tổng DT sàn XD<asp:checkbox id="chkDienTichSanXayDung" CssClass="" Runat="server"></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDienTichSanXayDungMoi" CssClass="QH_TextBox" Width="90%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Ghi chú hạng mục<asp:checkbox id="chkGhiChuHangMuc" CssClass="" Runat="server"></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtGhiChuHangMucMoi" CssClass="QH_TextBox" Width="90%" Runat="server" TextMode="MultiLine"
													Rows="3" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" colSpan="2">Lô đất<asp:checkbox id="chkLoDat" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtLoDatMoi" CssClass="QH_TextBox" Width="50%" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtTienBangChu" Width="0px" Runat="server" cssclass="QH_Textbox"></asp:textbox></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel" colSpan="2">Cao độ nền<asp:checkbox id="chkCaoDoNen" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtCaoDoNenMoi" CssClass="QH_TextBox" Width="50%" Runat="server" Enabled="False"
													MaxLength="9"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel" colSpan="2">Chỉ giới<asp:checkbox id="chkChiGioi" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtChiGioiMoi" CssClass="QH_TextBox" Width="50%" Runat="server" Enabled="False"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel" colSpan="2">Số nhà xây dựng<asp:checkbox id="chkSoNha" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoNhaMoi" CssClass="QH_TextBox" Width="50%" Runat="server" Enabled="False"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel" colSpan="2">Đường<asp:checkbox id="chkMaDuong" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaDuongMoi" CssClass="QH_DropDownList" Width="90%" Runat="server" Enabled="False"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel" colSpan="2">Phường<asp:checkbox id="chkMaPhuong" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaPhuongMoi" CssClass="QH_DropDownList" Width="90%" Runat="server" Enabled="False"></asp:dropdownlist></TD>
										</tr>
									</TABLE>
								</td>
							</TR>
							<TR>
								<TD colSpan="5" height="10"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2" height="20"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnInDeXuat" CssClass="QH_Button" runat="server">In đề xuất</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In xác nhận</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnYeuCauBoSung" CssClass="QH_Button" runat="server">Bổ sung HS</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server">Hồ sơ không giải quyết</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Bỏ qua</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="5"></TD>
							</TR>
							<TR>
								<TD colSpan="5" height="22"><asp:textbox id="txtGiayCNDKKDID" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox><asp:textbox id="txtSoGiayPhepGoc" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox><asp:textbox id="txtNgayCapGiayPhepGoc" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox><asp:textbox id="txtReload" CssClass="QH_textbox" Width="0px" runat="server" Visible="False"></asp:textbox></TD>
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
