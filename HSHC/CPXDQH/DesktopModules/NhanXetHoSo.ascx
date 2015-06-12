<%@ Register TagPrefix="uc1" TagName="ChuDauTuList" Src="ChuDauTuList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_HienTrang" Src="NXHS_HienTrang.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_DoHoaThietKe" Src="NXHS_DoHoaThietKe.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_HangMucXDTruoc" Src="NXHS_HangMucXDTruoc.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_NoiDungGP" Src="NXHS_NoiDungGP.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NhanXetHoSo.ascx.vb" Inherits="CPXD.NhanXetHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_HangMucXDSau" Src="NXHS_HangMucXDSau.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_NhanXet" Src="NXHS_NhanXet.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_QuyHoach" Src="NXHS_QuyHoach.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_PhapLy" Src="NXHS_PhapLy.ascx" %>
<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">
function checkRequire(id){
	var obj;
	obj = document.getElementById(id);
	if(obj.value == "")
	{
		alert('Ban chua dien du thong tin!')    
		obj.focus();
		return false;
	}		
	return true;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="title" runat="server" CssClass="QH_Label_Title" Width="100%">Nhận Xét Hồ Sơ</asp:label></td>
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
						<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<br>
							<TR>
								<TD width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<TR>
											<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
											<TD class="QH_ColControl" width="35%" colSpan="2"><asp:textbox id="txtSoBienNhan" runat="server" CssClass="QH_Textbox" Width="80%" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Họ tên người nộp</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTenNguoiNop" runat="server" CssClass="QH_Textbox" Width="80%" tabIndex="8"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ngày nhận xét<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl" width="35%" colspan="2"><asp:textbox id="txtNgayNhanXet" runat="server" CssClass="QH_Textbox" Width="35%" tabIndex="1"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayNhanXet" CssClass="CommandButton" Runat="server">
													<asp:image id="btnNgayNhanXet" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
											<TD class="QH_ColLabel" width="15%">Thường trú</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTru" runat="server" CssClass="QH_Textbox" Width="80%" tabIndex="9"></asp:textbox></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel" width="15%">Ký hiệu TK</TD>
											<TD class="QH_ColControl" width="35%" colSpan="2"><asp:textbox id="txtKyHieuThietKe" runat="server" CssClass="QH_Textbox" Width="80%" tabIndex="2"></asp:textbox></TD>
											<TD width="100%" colSpan="2"><asp:label id="Label2" runat="server" CssClass="QH_LabelLeftBold">Địa chỉ công trình xây dựng</asp:label></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Loại công trình</TD>
											<TD class="QH_ColControl" width="35%" colSpan="2"><asp:textbox id="txtCongTrinhXayDung" runat="server" CssClass="QH_Textbox" Width="80%" tabIndex="3"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Số nhà</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" runat="server" CssClass="QH_Textbox" Width="35%" tabIndex="10"></asp:textbox></TD>
										</TR>
										<tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Phân loại xây dựng<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl" width="25%"><asp:dropdownlist id="ddlMaPhanLoaiXayDung" CssClass="QH_Dropdownlist" Width="100%" Runat="server"
													tabIndex="4"></asp:dropdownlist></TD>
											<TD class="QH_ColControl" width="10%"><asp:dropdownlist id="ddlMaCapNha" CssClass="QH_Dropdownlist" Width="90%" Runat="server" tabIndex="5"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Đường</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuong" CssClass="QH_Dropdownlist" Width="80%" Runat="server" tabIndex="11"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel" width="15%">Đơn vị thiết kế</TD>
											<TD class="QH_ColControl" width="35%" colSpan="2"><asp:textbox id="txtDonViThietKe" CssClass="QH_Textbox" Width="80%" Runat="server" tabIndex="6"></asp:textbox>&nbsp;<asp:linkbutton id="LinkChonDonViThietKe" runat="server">Chọn...</asp:linkbutton></TD>
											<TD class="QH_ColLabel" width="15%">Phường</TD>
											<TD class="QH_ColControl" width="35%" height="17"><asp:dropdownlist id="ddlMaPhuong" CssClass="QH_Dropdownlist" Width="80%" Runat="server" tabIndex="12"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel" width="15%">Trên lô đất</TD>
											<TD class="QH_ColControl" width="35%" colSpan="2"><asp:textbox id="txtLodat" CssClass="QH_Textbox" Width="80%" Runat="server" tabIndex="7"></asp:textbox>&nbsp;<asp:linkbutton id="LinkChonLoDat" runat="server">Chọn...</asp:linkbutton></TD>
											<TD class="QH_ColLabel" width="15%">Địa chỉ cũ</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCu" runat="server" CssClass="QH_Textbox" Width="80%" tabIndex="13"></asp:textbox></TD>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
										<TR>
											<TD>
												<ie:tabstrip id="TabStrip1" runat="server" TabSelectedStyle="color:white;background-color:steelblue;"
													TabHoverStyle="color:blue;text-decoration:none; " TabDefaultStyle="color:steelblue;background-color:white;border-color:steelblue;border-style:solid;border-width:1px;font-family:verdana;font-weight:bold;font-size:8pt;width:93;height:21;text-align:center;"
													SepDefaultStyle="background-color:white;border-color:steelblue;border-width:1px;border-style:solid;border-top:none;border-left:none;border-right:none;border-bottom:none;"
													TargetID="tsNXHS" tabIndex="14">
													<ie:Tab Text="Nhận x&#233;t"></ie:Tab>
													<ie:Tab Text="Hạng mục xd(trước)"></ie:Tab>
													<ie:Tab Text="Hạng mục xd(sau)"></ie:Tab>
													<ie:Tab Text="Nội dung gp"></ie:Tab>
													<ie:Tab Text="HS Ph&#225;p l&#253;"></ie:Tab>
													<ie:Tab Text="Hiện trạng nh&#224; đất"></ie:Tab>
													<ie:Tab Text="Q.Hoạch kiến tr&#250;c"></ie:Tab>
													<ie:Tab Text="Vẽ họa đồ tk"></ie:Tab>
												</ie:tabstrip>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td>
									<ie:multipage id="tsNXHS" runat="server">
										<ie:PageView>
											<table width="98%" align="center">
												<tr>
													<td>
														<uc1:NXHS_NhanXet id="objNhanXet" runat="server"></uc1:NXHS_NhanXet>
													</td>
												</tr>
											</table>
										</ie:PageView>
										<ie:PageView>
											<table width="98%" align="center" >
												<tr>
													<td>
														<uc1:NXHS_HangMucXDTruoc id="objHangMucXDTruoc" runat="server"></uc1:NXHS_HangMucXDTruoc>
													</td>
												</tr>
											</table>
										</ie:PageView>
										<ie:PageView>
											<table width="98%" align="center">
												<tr>
													<td>
														<uc1:NXHS_HangMucXDSau id="objHangMucXDSau" runat="server"></uc1:NXHS_HangMucXDSau>
													</td>
												</tr>
											</table>
										</ie:PageView>
										<ie:PageView>
											<table width="98%" align="center">
												<tr>
													<td>
														<uc1:NXHS_NoiDungGP id="objNoiDungGP" runat="server"></uc1:NXHS_NoiDungGP>
													</td>
												</tr>
												<tr>
													<td>
														<asp:label id="Label1" runat="server" CssClass="QH_LabelLeftBold">Chủ đầu tư</asp:label>
													</td>
												</tr>
												<tr>
													<td>
														<uc1:ChuDauTuList id="ctrlChuDauTuList" runat="server"></uc1:ChuDauTuList>
													</td>
												</tr>
											</table>
										</ie:PageView>
										<ie:PageView>
											<table width="98%" align="center" >
												<tr>
													<td>
														<uc1:NXHS_PhapLy id="objphaply" runat="server"></uc1:NXHS_PhapLy>
													</td>
												</tr>
											</table>
										</ie:PageView>
										<ie:PageView>
											<table width="98%" align="center">
												<tr>
													<td>
														<uc1:NXHS_HienTrang id="objHienTrang" runat="server"></uc1:NXHS_HienTrang></td>
												</tr>
											</table>
										</ie:PageView>
										<ie:PageView>
											<table width="98%" align="center">
												<tr>
													<td>
														<uc1:NXHS_QuyHoach id="objQuyHoach" runat="server"></uc1:NXHS_QuyHoach></td>
												</tr>
											</table>
										</ie:PageView>
										<ie:PageView>
											<table width="98%" align="center">
												<tr>
													<td>
														<uc1:NXHS_DoHoaThietKe id="DoHoaThietKe" runat="server"></uc1:NXHS_DoHoaThietKe></td>
												</tr>
											</table>
										</ie:PageView>
									</ie:multipage>
								</td>
							</tr>
							<tr>
								<TD align="center" colSpan="2">
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In nhận xét</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnInGiayPhep" runat="server" CssClass="QH_Button">In giấy phép</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;
									<asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox>
								</TD>
							</tr>
							<TR>
								<TD align="center" colSpan="2">
									<asp:textbox id="txtHoTen" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtNhanXetHoSoID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtHangMucTruoc" runat="server" Width="0px" Visible="False" TextMode="MultiLine"
										MaxLength="40000"></asp:textbox>
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
