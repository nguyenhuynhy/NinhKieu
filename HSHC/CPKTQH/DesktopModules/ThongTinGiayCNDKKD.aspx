<%@ Import Namespace="PortalQH" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ThongTinGiayCNDKKD.aspx.vb" Inherits="CPKTQH.ThongTinGiayCNDKKD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kiem tra ho so</title>
		<link href='<%= ResolveUrl("~/Portals/_default/Skins/LIGHTBLUESKIN/") + "LightBlueskin.css" %>' type=text/css rel=stylesheet>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Khung_TopLeft" width="16" height="24"></td>
								<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">Thông tin kiểm tra hồ sơ</asp:label></td>
								<td class="QH_Khung_TopRight" width="16" height="24"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="20%" height="20">Số giấy CN ĐKKD</TD>
								<TD class="QH_ColControl" width="35%" height="20">
									<asp:Label id="lblSoGiayPhep" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
								<TD class="QH_ColLabel" width="15%" height="20">Ngày cấp</TD>
								<TD class="QH_ColControl" width="30%" height="20">
									<asp:Label id="lblNgayCap" CssClass="QH_LabelLeftBold" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="20">Họ tên</TD>
								<TD class="QH_ColControl" height="20">
									<asp:Label id="lblHoTen" CssClass="QH_LabelLeftBold" runat="server"></asp:Label></TD>
								<TD class="QH_ColLabel">Số CMND</TD>
								<TD class="QH_ColControl">
									<asp:Label id="lblSoCMND" CssClass="QH_LabelLeftBold" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="20">Địa chỉ kinh doanh</TD>
								<TD class="QH_ColControl" height="20">
									<asp:Label id="lblDiaChiKinhDoanh" CssClass="QH_LabelLeftBold" runat="server"></asp:Label></TD>
								<TD class="QH_ColLabel">Bảng hiệu</TD>
								<TD class="QH_ColControl">
									<asp:Label id="lblBangHieu" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="20">Mặt hàng kinh doanh</TD>
								<TD class="QH_ColControl">
									<asp:Label id="lblMatHangKinhDoanh" CssClass="QH_LabelLeftBold" runat="server"></asp:Label></TD>
								<TD class="QH_ColLabel">
									Tình trạng</TD>
								<TD class="QH_ColControl">
									<asp:Label id="lblTenTinhTrang" CssClass="QH_LabelLeftBold" runat="server"></asp:Label></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td align="center">
						<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
