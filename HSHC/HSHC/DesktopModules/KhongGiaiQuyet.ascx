<%@ Control Language="vb" AutoEventWireup="false" Codebehind="KhongGiaiQuyet.ascx.vb" Inherits="HSHC.KhongGiaiQuyet" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">
function SelectLyDo(){
	document.getElementById("<%= ddlMalyDo.ClientID%>").disabled = false;
	document.getElementById("<%= txtLyDoKhac.ClientID%>").disabled = true;
}
function InputLyDo(){
	document.getElementById("<%= ddlMalyDo.ClientID%>").disabled = true;
	document.getElementById("<%= txtLyDoKhac.ClientID%>").disabled = false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">&nbsp;</asp:label>
					</td>
					<td width="16" height="24" class="QH_Khung_TopRight">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" class="QH_Khung_Left">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD colSpan="5" height="5"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Số biên nhận</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoBienNhan" Width="50%" CssClass="QH_textbox" runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" Width="36px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Họ tên</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtHoTen" Width="90%" CssClass="QH_textbox" runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Thường trú</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTru" Width="90%" CssClass="QH_textbox" runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="14">Loại hồ sơ</TD>
											<TD class="QH_ColControl" height="14"><asp:dropdownlist id="ddlMaLoaiHoSo" Width="90%" CssClass="QH_DropDownList" runat="server" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="22">Tại địa chỉ</TD>
											<TD class="QH_ColControl" height="22"><asp:textbox id="txtDiaChi" Width="90%" CssClass="QH_textbox" runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Nội dung xử lý</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNoiDungXuLy" Width="90%" CssClass="QH_textbox" runat="server" Rows="2" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ghi chú</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtGhiChu" Width="90%" CssClass="QH_textbox" runat="server" Rows="2" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17">Tình trạng</TD>
											<TD class="QH_ColControl" height="17"><asp:dropdownlist id="ddlMaTinhTrangXuLy" Width="90%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17"><asp:RadioButton ID="rdoReason" Runat="server" Text="Lý do" GroupName="grpLyDo" Checked="True" CssClass="QH_RadioButtonList"
													TextAlign="Left"></asp:RadioButton></TD>
											<TD class="QH_ColControl" height="17"><asp:dropdownlist id="ddlMalyDo" Width="90%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17"><asp:RadioButton ID="rdoOtherReason" Runat="server" Text="Lý do khác" GroupName="grpLyDo" CssClass="QH_RadioButtonList"
													TextAlign="Left"></asp:RadioButton></TD>
											<TD class="QH_ColControl" height="17"><asp:TextBox ID="txtLyDoKhac" Runat="server" Width="90%" CssClass="QH_textbox" TextMode="MultiLine"
													Rows="3"></asp:TextBox>
											</TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="13">Lãnh đạo duyệt</TD>
											<TD class="QH_ColControl" height="13"><asp:dropdownlist id="ddlMaNguoiSuDung" Width="90%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày xử lý</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayXuLy" Width="70px" CssClass="QH_textbox" runat="server"></asp:textbox>
												&nbsp;<asp:hyperlink id="cmdNgayXuLy" CssClass="CommandButton" Runat="server">
													<asp:image id="imgNgayXuLy" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD colSpan="2" height="5">
												<asp:textbox id="txtHoSoKhongGiaiQuyetID" runat="server" CssClass="QH_textbox" Width="19px" Visible="False"></asp:textbox>
												<asp:textbox id="txtMaLinhVuc" runat="server" CssClass="QH_textbox" Width="19px" Visible="False"></asp:textbox>
												<asp:textbox id="txtTabCode" runat="server" CssClass="QH_textbox" Width="19px" Visible="False"></asp:textbox>
												<asp:textbox id="txtMaNguoiTacNghiep" runat="server" CssClass="QH_textbox" Width="19px" Visible="False"></asp:textbox></TD>
										<TR>
											<TD vAlign="middle" align="center" colSpan="5" height="20">
												<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>
												<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
												<asp:linkbutton id="btnInVB" runat="server" CssClass="QH_Button">In văn bản</asp:linkbutton>
												<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2" height="5"></TD>
										<TR>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td width="16" class="QH_Khung_Right">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1">
								</td>
							</tr>
						</Table>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
