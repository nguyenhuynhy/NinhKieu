<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GiaHanGPKD.ascx.vb" Inherits="CPKTQH.GiaHanGPKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="ThongTinChungGCNDKKD" Src="ThongTinChungGCNDKKD.ascx" %>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label2" Runat="server" CssClass="QH_Label_Title" Width="100%">Gia hạn Giấy chứng nhận ĐKKD</asp:label></td>
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
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
							<tr>
								<td height="5"></td>
							</tr>
							<TR>
								<TD align="center" width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="95%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="20%">
												<asp:label id="lblSoBN" runat="server">Số biên nhận<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl" width="30%">
												<asp:textbox id="txtSoBienNhan" Width="50%" CssClass="QH_textbox" runat="server" ReadOnly="True"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="20%">
												<asp:linkbutton id="btnSoGP" Runat="server" Visible="False">Số GCN ĐKKD</asp:linkbutton>
												<asp:label id="lblSoGP" runat="server">Số GCN ĐKKD<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl" width="30%">
												<asp:textbox id="txtSoGiayPhep" Width="50%" CssClass="QH_textbox" runat="server" ReadOnly="True"
													EnableViewState="true" Enabled="False" AutoPostBack="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="10"></TD>
							</TR>
							<tr>
								<td align="center">
									<table cellpadding="0" cellspacing="0" border="0" width="95%">
										<tr>
											<td>
												<uc1:ThongTinChungGCNDKKD id="ThongTinChungGCNDKKD1" runat="server"></uc1:ThongTinChungGCNDKKD></td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD height="10"></TD>
							</TR>
							<tr>
								<td align="center">
									<table cellpadding="0" cellspacing="0" border="0" width="95%">
										<tr>
											<td width="20%"></td>
											<td width="30%"></td>
											<td width="20%"></td>
											<td width="*"></td>
										</tr>
										<tr>
											<td class="QH_ColLabel">Lãnh đạo duyệt<font color="red">*</font>
											</td>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaSoLanhDaoGiaHan" CssClass="QH_DropDownList" Width="100%" runat="server"></asp:dropdownlist>
											</TD>
											<td class="QH_ColLabel" rowspan="3">Ghi Chú</td>
											<td class="QH_ColControl" rowspan="3"><asp:textbox id="txtGhiChuGiaHan" Runat="server" CssClass="QH_TextBox" Width="100%" MaxLength="500"
													Rows="5" TextMode="MultiLine"></asp:textbox></td>
										</tr>
										<tr>
											<TD class="QH_ColLabel"><asp:label id="lblDenNgay" runat="server">Ngày gia hạn<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayGiaHan" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="btnNgayGiaHan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel"><asp:label id="Label3" runat="server">Gia hạn đến<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtGiaHanDen" Runat="server" CssClass="QH_TextBox" Width="40%" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="btnGiaHanDen" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
											</TD>
										</TR>
									</table>
								</td>
							</tr>
							<TR>
								<TD height="5"></TD>
							</TR>
							<tr>
								<td align="center">
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button" Visible="False">Cập nhật</asp:linkbutton>
									<asp:linkbutton id="btnDeXuat" CssClass="QH_Button" runat="server" Visible="False">Đề xuất</asp:linkbutton>
									<asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server" Visible="False">Bổ sung hồ sơ</asp:linkbutton>
									<asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server" Visible="False"> Không giải quyết</asp:linkbutton>
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button" Visible="False">Xóa</asp:linkbutton>
									<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server" Visible="False">In GCN ĐKKD</asp:linkbutton>
									<asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
								</td>
							</tr>
							<tr>
								<td height="10"></td>
							</tr>
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
<input id="KiemTra" type="hidden" value="0" name="KiemTra" runat="server">
<div style="DISPLAY:none">
	<asp:textbox id="txtHoSoTiepNhanID" Enabled="False" runat="server"></asp:textbox>
	<asp:TextBox ID="txtGiayCNDKKDID" Enabled="False" Runat="server"></asp:TextBox>
	<asp:TextBox ID="txtGiaHanGPKDID" Enabled="False" Runat="server"></asp:TextBox>
	<asp:textbox id="txtMaLinhVuc" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtGiaHanGPXDID" Width="0px" runat="server"></asp:textbox>
</div>
<script language="javascript">
function CheckCapNhat()
{
	if (!CheckNull())
		return false;
}
</script>
