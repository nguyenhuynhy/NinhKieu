<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LanhDaoKhongDuyet.ascx.vb" Inherits="HSHC.LanhDaoKhongDuyet" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/Common.js")%>'>
</script>
<script language=javascript 
src='<%= Page.ResolveURL("~/Inc/popcalendar.js")%>'>
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title" text="Chuyển trả lại bộ phận thụ lý">&nbsp;</asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD colSpan="5" height="5"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Số biên nhận</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoBienNhan" Width="50%" CssClass="QH_textbox" Enabled="False" runat="server"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" Width="36px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Họ tên</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtHoTen" Width="90%" CssClass="QH_textbox" Enabled="False" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Thường trú</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTru" Width="90%" CssClass="QH_textbox" Enabled="False" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="14">Loại hồ sơ</TD>
											<TD class="QH_ColControl" height="14"><asp:dropdownlist id="ddlMaLoaiHoSo" Width="90%" CssClass="QH_DropDownList" Enabled="False" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="22">Tại địa chỉ</TD>
											<TD class="QH_ColControl" height="22"><asp:textbox id="txtDiaChi" Width="90%" CssClass="QH_textbox" Enabled="False" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17">Lý do</TD>
											<TD class="QH_ColControl" height="17"><asp:TextBox id="txtLyDo" Runat="server" Width="90%" CssClass="QH_TextBox" TextMode="MultiLine"
													Rows="2"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17">Người nhận</TD>
											<TD class="QH_ColControl" height="17"><asp:DropDownList ID="ddlMaNguoiNhan" Runat="server" Width="90%" CssClass="QH_DropDownList"></asp:DropDownList></TD>
										</TR>
										<TR>
											<TD colSpan="2" height="5"><asp:textbox id="txtHoSoKhongGiaiQuyetID" Width="0px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox>
												<asp:textbox id="txtMaLinhVuc" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox>
												<asp:textbox id="txtTabCode" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox>
												<asp:textbox id="txtMaNguoiTacNghiep" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox>
												<asp:textbox id="txtMaNguoiChuyen" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox>
											</TD>
										<TR>
											<TD vAlign="middle" align="center" colSpan="5" height="20"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnIn" CssClass="QH_Button" Visible="False" runat="server">In ra giấy</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
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
