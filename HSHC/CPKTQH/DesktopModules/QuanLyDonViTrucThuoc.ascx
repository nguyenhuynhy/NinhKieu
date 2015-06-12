<%@ Control Language="vb" AutoEventWireup="false" Codebehind="QuanLyDonViTrucThuoc.ascx.vb" Inherits="CPKTQH.QuanLyDonViTrucThuoc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
	function ValidateNumeric() 
	 { 
		 var keyCode = window.event.keyCode; 
		 if (keyCode > 57 || keyCode < 48) 
		 window.event.returnValue = false; 
	 }
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server">Danh sách giấy chứng nhận đăng ký kinh doanh</asp:label></td>
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
					<td vAlign="top" align="center" width="*">
						<!--Thong tin kinh doanh-->
						<table id="table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
							<tr>
								<td class="QH_ColLabel" width="20%">Số GCN ĐKKD</td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtSoGiayPhep" runat="server" Width="100%" CssClass="QH_Textbox" MaxLength="20"
										Enabled="False"></asp:textbox></td>
								<td class="QH_ColLabel" width="20%">Tên doanh nghiệp</td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtTenDoanhNghiep" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
										EnableViewState="true" Enabled="False"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="20%">Ngày cấp</td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtNgayCap" runat="server" Width="50%" CssClass="QH_TextBox" MaxLength="10"
										Enabled="False"></asp:textbox></td>
								<td class="QH_ColLabel" width="20%">Vốn kinh doanh
								</td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtVonKinhDoanh" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="14"
										EnableViewState="true" Enabled="False"></asp:textbox></td>
							</tr>
							<TR>
								<TD class="QH_ColLabel" width="20%">Người đại diện</TD>
								<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNguoiDungDau" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
										EnableViewState="true" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="20%">Tên loại doanh nghiệp</TD>
								<TD class="QH_ColControl" width="30%"><asp:textbox id="txtTenLoaiDoanhNghiep" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="14"
										EnableViewState="true" Enabled="False"></asp:textbox></TD>
							</TR>
							<tr>
								<td class="QH_ColLabel" vAlign="top" width="20%">
									<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 0px">Địa chỉ</p>
								</td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtDiaChi" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
										EnableViewState="true" TextMode="MultiLine" Rows="3" Height="45px" Enabled="False"></asp:textbox></td>
								<td class="QH_ColLabel" vAlign="top" width="20%">
									<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 0px">Mặt&nbsp;hàng kinh doanh</p>
								</td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtMatHangKinhDoanh" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="100"
										EnableViewState="true" TextMode="MultiLine" Rows="3" Height="45px" Enabled="False"></asp:textbox></td>
							</tr>
						</table>
						<!----------------->
						<br>
						<!--Thong tin quan ly--><BR>
						<table id="Table2" cellSpacing="0" cellPadding="0" width="90%" border="0" runat="server">
							<tr>
								<td width="100%" colSpan="4"><strong><strong><asp:label id="Label2" CssClass="QH_LabelLeftBold" Runat="server">
												<strong>Thông tin quản lý</strong></asp:label></strong></strong></td>
							</tr>
							<tr>
								<td align="left" width="20%" class="QH_ColLabel">
									Tình trạng
								</td>
								<td width="30%" class="QH_ColControl">
									<asp:CheckBox id="chkHoatDong" runat="server" Text="Hoạt động"></asp:CheckBox>
								</td>
								<td width="20%">
								</td>
								<td width="30%">
								</td>
							</tr>
						</table>
						<table id="tblThongTinQuanLy" cellSpacing="0" cellPadding="0" width="90%" border="0" runat="server">
							<tr>
								<td class="QH_ColLabel" width="20%">Số nhà<FONT color="#ff0000" size="4">*</FONT></td>
								<td class="QH_ColControl" width="30%"><asp:textbox id="txtSoNha" runat="server" Width="50%" CssClass="QH_textbox" MaxLength="100" EnableViewState="true"></asp:textbox></td>
								<td class="QH_ColLabel" width="20%">Loại hình doanh nghiệp <FONT color="#ff0000" size="4">
										*</FONT></td>
								<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaLoaiHinhDoanhNghiep" runat="server" Width="100%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="20%">Đường</td>
								<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaDuong" runat="server" Width="100%" CssClass="QH_DropDownList"></asp:dropdownlist></td>
								<td class="QH_ColLabel" width="20%">Lĩnh&nbsp;vực cấp phép<FONT color="#ff0000" size="4">*</FONT></td>
								<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaLinhVucCapPhep" runat="server" Width="100%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="20%">Phường<FONT color="#ff0000" size="4">*</FONT></td>
								<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaPhuong" runat="server" Width="100%" CssClass="QH_DropDownList"></asp:dropdownlist></td>
								<td class="QH_ColLabel" width="20%">Ngành kinh&nbsp;doanh<FONT color="#ff0000" size="4">*</FONT></td>
								<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaNganhKinhDoanh" runat="server" Width="100%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
							</tr>
						</table>
						<BR>
						<!------------------><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">C&#7853;p nh&#7853;t</asp:linkbutton><asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Tr&#7903; v&#7873;</asp:linkbutton></td>
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
<asp:textbox id="txtDonViTrucThuocID" runat="server" Width="20px" Visible="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="20px" Visible="false"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Width="21px" CssClass="QH_textbox" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Width="21px" CssClass="QH_textbox" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Width="0px" CssClass="QH_textbox"></asp:textbox>
<script>
		if (document.all("<%=hMsg.ClientID%>").value != ''){
			alert(document.all("<%=hMsg.ClientID%>").value);
			document.all("<%=hMsg.ClientID%>").value='';
		}

</script>
