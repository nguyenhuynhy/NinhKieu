<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DonViTrucThuoc.ascx.vb" Inherits="CPKTQH.DonViTrucThuoc" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
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
					<td width="*" vAlign="top" align="center">
						<table align="center" width="98%" cellpadding="0" cellspacing="0" border="0">
							<!-- add  các user control   -->
							<tr>
								<td colspan="2" height="5"></td>
							</tr>
							<tr>
								<TD width="50%" valign="top">
									<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="QH_ColLabel" vAlign="top" width="35%">Số&nbsp;GCN&nbsp;ĐKKD&nbsp; <FONT color="#ff0000" size="4">
													*</FONT></td>
											<td class="QH_ColControl" width="65%"><asp:textbox id="txtSoGiayPhep" runat="server" CssClass="QH_Textbox" Width="50%" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" vAlign="top" width="415">Ngày cấp <FONT color="#ff0000" size="4">
													*</FONT></td>
											<td class="QH_ColControl" width="691"><asp:textbox id="txtNgayCap" runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgNgayCap" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
													ImageAlign="AbsMiddle" AlternateText="Chọn lịch"></asp:image></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" vAlign="top" width="384">Số nhà <FONT color="#ff0000" size="4">*</FONT></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
													EnableViewState="true"></asp:textbox></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" vAlign="top" width="384">Đường
											</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuong" runat="server" CssClass="QH_DropDownList" Width="100%"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel" vAlign="top" width="384">Phường <FONT color="#ff0000" size="4">*</FONT></TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuong" runat="server" CssClass="QH_DropDownList" Width="100%"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<td class="QH_ColLabel">Tên doanh nghiệp <FONT color="#ff0000" size="4">*</FONT></td>
											<td class="QH_ColControl"><asp:textbox id="txtTenDoanhNghiep" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
													EnableViewState="true"></asp:textbox></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" vAlign="top" width="415">Vốn kinh doanh <FONT color="#ff0000" size="4">
													*</FONT></TD>
											<TD class="QH_ColControl" width="691"><asp:textbox id="txtVonKinhDoanh" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="14"
													EnableViewState="true"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
								<TD align="center" width="50%" valign="top">
									<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<TD class="QH_ColLabel" vAlign="top" width="35%">Loại hình <FONT color="#ff0000" size="4">
													*</FONT></TD>
											<TD class="QH_ColControl" width="65%"><asp:dropdownlist id="ddlMaLoaiHinhDoanhNghiep" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Lĩnh&nbsp;vực cấp phép<FONT color="#ff0000" size="4">*</FONT></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaLinhVucCapPhep" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Ngành kinh&nbsp;doanh&nbsp; <FONT color="#ff0000" size="4">*</FONT></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaNganhKinhDoanh" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Mặt hàng&nbsp;kinh doanh <FONT color="#ff0000" size="4">*</FONT></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtMatHangKinhDoanh" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
													EnableViewState="true" Rows="2" TextMode="MultiLine" Height="40px"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Người đại diện&nbsp; <FONT color="#ff0000" size="4">*</FONT></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNguoiDungDau" runat="server" CssClass="QH_textbox" Width="100%" MaxLength="100"
													EnableViewState="true"></asp:textbox></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Số CMND<FONT color="#ff0000" size="4"> *</FONT></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" runat="server" CssClass="QH_textbox" Width="50%" MaxLength="20" EnableViewState="true"></asp:textbox></TD>
										</tr>
									</table>
								</TD>
							</tr>
							<!-- /Kiem tra GPKD-->
							<tr>
								<td colspan="2" align="center"><BR>
									&nbsp;
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">C&#7853;p nh&#7853;t</asp:linkbutton><asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button" Visible="False">Xóa</asp:linkbutton><asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button">Tr&#7903; v&#7873;</asp:linkbutton>&nbsp;
									<BR>
								</td>
							</tr>
						</table>
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
<INPUT id="cMsg" type="hidden" name="cMsg" runat="server"> <INPUT id="hMsg" type="hidden" name="hMsg" runat="server">
<asp:textbox id="txtDonViTrucThuocID" runat="server" Width="100px" Visible="False"></asp:textbox>
<asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="20px" Visible="False"></asp:textbox>
<asp:textbox id="txtTabCode" runat="server" CssClass="QH_textbox" Width="21px" Visible="False"></asp:textbox>
<asp:textbox id="txtMaLinhVuc" runat="server" CssClass="QH_textbox" Width="21px" Visible="False"></asp:textbox>
<asp:textbox id="txtMaNguoiTacNghiep" runat="server" CssClass="QH_textbox" Width="0px"></asp:textbox>
<script>
		if (document.all("<%=hMsg.ClientID%>").value != ''){
			alert(document.all("<%=hMsg.ClientID%>").value);
			document.all("<%=hMsg.ClientID%>").value='';
		}

</script>
<script language="javascript">
function getNganhKinhDoanh(objNganh, objMatHang)
{
	if (objMatHang.value == '')
		objMatHang.value = objNganh.options[objNganh.selectedIndex].text;
	else
		objMatHang.value = objMatHang.value + ', ' + objNganh.options[objNganh.selectedIndex].text;
}
</script>
