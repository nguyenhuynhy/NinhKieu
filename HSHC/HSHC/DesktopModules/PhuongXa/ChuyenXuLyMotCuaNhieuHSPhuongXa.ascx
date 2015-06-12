<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChuyenXuLyMotCuaNhieuHSPhuongXa.ascx.vb" Inherits="HSHC.ChuyenXuLyMotCuaNhieuHSPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid">
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
							<tr>
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD colSpan="4" height="5"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Số biên nhận</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoBienNhan" Enabled="False" runat="server" CssClass="QH_textbox" Width="50%"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" CssClass="QH_textbox" Width="36px" Visible="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17">Người chuyển</TD>
											<TD class="QH_ColControl" height="17"><asp:dropdownlist id="ddlMaNguoiDen" runat="server" CssClass="QH_DropDownList" Width="50%"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="17">Người nhận</TD>
											<TD class="QH_ColControl" height="17"><asp:dropdownlist id="ddlMaNguoiNhan" runat="server" CssClass="QH_DropDownList" Width="50%"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="15">Tình trạng hồ sơ</TD>
											<TD class="QH_ColControl" height="15"><asp:dropdownlist id="ddlMaTinhTrangXuLy" runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="15">Nội dung thụ lý</TD>
											<TD class="QH_ColControl" colSpan="2" height="5"><asp:textbox id="txtnoiDungThuLy" runat="server" CssClass="QH_textbox" Width="90%" TextMode="MultiLine"
													Rows="5"></asp:textbox></TD>
										<TR>
										<TR>
											<TD colSpan="2" height="5"><asp:textbox id="txtMaLinhVuc" runat="server" CssClass="QH_textbox" Width="19px" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" runat="server" CssClass="QH_textbox" Width="19px" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" CssClass="QH_textbox" Width="19px" Visible="False"></asp:textbox></TD>
										<TR>
											<TD vAlign="middle" align="center" colSpan="5">
												<asp:linkbutton id="btnUndo" runat="server" CssClass="QH_Button">Undo</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button" Visible="False">In ra giấy</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2" height="5"></TD>
										</TR>
									</TABLE>
									<asp:Label id="lblResult" runat="server" ForeColor="Red" Font-Bold="True" Visible="False">Cập nhật thành công</asp:Label>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td width="16" class="QH_Khung_Right">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr>
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
