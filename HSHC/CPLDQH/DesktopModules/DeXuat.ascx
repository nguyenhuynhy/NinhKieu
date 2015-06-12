﻿<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DeXuat.ascx.vb" Inherits="CPLDQH.DeXuat" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">
function GetNoiDung(str,objNoiDung)
{
		var i;
		var obj;
		str=GetParams(str);			
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			
				if (obj.id == objNoiDung)
				{
					obj.value = obj.tag ;
				}
		}
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title"></asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
							<tr>
								<td align="center">
									<DIV align="left">
										<TABLE class="QH_Table" id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD width="100%" colSpan="4">
													<P align="left"><STRONG><asp:label id="lbPhieuChuyenKhaoSat" runat="server">Phiếu chuyển khảo sát</asp:label></STRONG></P>
												</TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
												<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtSoBienNhan" Width="20%" CssClass="QH_textbox" runat="server" Enabled="False"
														EnableViewState="true"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" height="4">Loại hồ sơ</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaLoaiHoSo" Width="63%" CssClass="QH_DropDownList" runat="server" Enabled="False"
														EnableViewState="true"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="15%">Họ tên</TD>
												<TD class="QH_ColControl" width="30%"><asp:textbox id="txtHoTen" Width="100%" CssClass="QH_textbox" runat="server" Enabled="False"
														EnableViewState="true"></asp:textbox></TD>
												<TD class="QH_ColLabel" width="10%">Giới tính</TD>
												<TD class="QH_ColControl" width="40%"><asp:dropdownlist id="ddlGioiTinh" Width="25%" CssClass="QH_DropDownList" runat="server" Enabled="False"
														EnableViewState="true"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Ðịa chỉ cư trú</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtDiaChi" Width="63%" CssClass="QH_textbox" runat="server" Enabled="False"
														EnableViewState="true"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" height="19">Địa chỉ kinh doanh</TD>
												<TD class="QH_ColControl" width="*" colSpan="3"><asp:textbox id="txtDiaChiKinhDoanh" Width="63%" CssClass="QH_Textbox" runat="server" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Ngành nghề kinh doanh</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaNganhKinhDoanh" Width="63%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Mặt hàng kinh doanh</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtMatHangKinhDoanh" Width="90%" CssClass="QH_textbox" runat="server" EnableViewState="true"
														TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel"><asp:label id="lbYkien" runat="server">Ý kiến đề xuất</asp:label></TD>
												<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtNoiDung" Width="90%" CssClass="QH_textbox" runat="server" EnableViewState="true"
														TextMode="MultiLine" Rows="6"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Người ký</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaSoLanhDao" Width="30%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
												<asp:textbox id="txtTabCode" Width="21px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTrinhThamDinhID" Width="21px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox>&nbsp;
												<asp:textbox id="txtMaLinhVuc" Width="21px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox><asp:textbox id="txtLoai" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox><asp:textbox id="txtMaCanBoDeXuat" Width="0px" runat="server"></asp:textbox></TR>
											<TR>
												<TD class="QH_ColLabel"></TD>
												<TD class="QH_ColControl" colSpan="3"></TD>
											</TR>
										</TABLE>
									</DIV>
								</td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE class="QH_Table" id="tblThamDinh" cellSpacing="0" cellPadding="0" width="100%" border="0"
										runat="server">
										<TR>
											<td width="100%" colSpan="4">
												<P align="left"><STRONG>Nội dung phiếu khảo sát</STRONG></P>
											</td>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ðơn vị thẩm định</TD>
											<TD class="QH_ColControl" width="28%"><asp:dropdownlist id="ddlDonViThamDinh" Width="90%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="17%">Người thẩm định</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlNguoiNhan" Width="70%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ngày chuyển</TD>
											<TD class="QH_ColControl" width="28%"><asp:textbox id="txtNgayThamDinh" Width="40%" CssClass="QH_textbox" runat="server" EnableViewState="true"></asp:textbox>
												<asp:HyperLink id="cmdNgayThamDinh" CssClass="commandbutton" runat="server">
													<asp:image id="imgNgayThamDinh" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:HyperLink></TD>
											<TD class="QH_ColLabel" width="17%">Ngày phản hồi</TD>
											<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayPhanHoi" Width="40%" CssClass="QH_textbox" runat="server" EnableViewState="true"></asp:textbox>
												<asp:HyperLink id="cmdNgayPhanHoi" CssClass="commandbutton" runat="server">
													<asp:image id="imgNgayPhanHoi" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:HyperLink></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%"></TD>
											<TD class="QH_ColControl" width="28%"></TD>
											<TD class="QH_ColLabel" width="17%">Ngày phản hồi thực tế</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayPhanHoiThucTe" Width="40%" CssClass="QH_textbox" runat="server" EnableViewState="true"></asp:textbox>
												<asp:HyperLink id="cmdNgayPhanHoiThucTe" CssClass="commandbutton" runat="server">cmdNgayPhanHoiThucTe</asp:HyperLink>
											</TD>
										</TR>
									</TABLE>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%"></TD>
											<TD class="QH_ColControl" colSpan="3"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%"></TD>
											<TD class="QH_ColControl" colSpan="3"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<TR>
								<TD align="center" colSpan="4">
									<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>
									<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>
									<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton>
									<asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
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
