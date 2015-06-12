<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DeXuat.ascx.vb" Inherits="CPKTQH.DeXuat" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="PhieuKhaoSat" Src="PhieuKhaoSat.ascx" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" runat="server" Width="100%"> Thông tin đề xuất</asp:label></td>
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
							<TBODY>
								<TR>
									<TD vAlign="top" align="center"><BR>
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center" width="100%">
													<!-- content is put here -->
													<TABLE id="Table2" height="240" cellSpacing="0" cellPadding="0" width="95%" align="center"
														border="0">
														<tr>
															<td align="center">
																<DIV align="left">
																	<TABLE class="QH_Table" id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="left"
																		border="0">
																		<tr>
																			<td height="5"></td>
																		</tr>
																		<tr>
																			<td colspan="4" Class="QH_LabelLeftBold"><strong>Thông tin hồ sơ tiếp nhận</strong></td>
																		</tr>
																		<tr>
																			<td height="5"></td>
																		</tr>
																		<TR>
																			<TD class="QH_ColLabel" width="20%" height="20">Số biên nhận</TD>
																			<TD class="QH_ColControl" width="35%" height="20">
																				<asp:Label id="lblSoBienNhan" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																			<TD class="QH_ColLabel" width="15%" height="20">Họ tên</TD>
																			<TD class="QH_ColControl" width="30%" height="20">
																				<asp:Label id="lblHoTen" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																		</TR>
																		<TR>
																			<TD class="QH_ColLabel" height="20">Ngày nhận</TD>
																			<TD class="QH_ColControl" height="20">
																				<asp:Label id="lblNgayNhan" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																			<TD class="QH_ColLabel">Giới tính</TD>
																			<TD class="QH_ColControl">
																				<asp:Label id="lblGioiTinh" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																		</TR>
																		<TR>
																			<TD class="QH_ColLabel" height="20">Loại hồ sơ</TD>
																			<TD class="QH_ColControl" height="20">
																				<asp:Label id="lblTenLoaiHoSo" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																			<TD class="QH_ColLabel">Số CMND</TD>
																			<TD class="QH_ColControl">
																				<asp:Label id="lblSoCMND" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																		</TR>
																		<TR>
																			<TD class="QH_ColLabel" height="20">Địa chỉ kinh doanh</TD>
																			<TD class="QH_ColControl">
																				<asp:Label id="lblDiaChiKinhDoanh" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																			<TD class="QH_ColLabel">Địa chỉ cư trú</TD>
																			<TD class="QH_ColControl">
																				<asp:Label id="lblDiaChi" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
																		</TR>
																		<tr>
																			<td height="5"></td>
																		</tr>
																		<tr>
																			<td colspan="4" Class="QH_LabelLeftBold"><strong>Thông tin đề xuất</strong></td>
																		</tr>
																		<tr>
																			<td height="5"></td>
																		</tr>
																		<TR>
																			<TD class="QH_ColLabel">Số GCN ĐKKD</TD>
																			<TD class="QH_ColControl" colSpan="3">
																				<asp:TextBox id="txtSoGiayPhep" Width="20%" runat="server" CssClass="QH_TextBox" Enabled="False"></asp:TextBox></TD>
																		</TR>
																		<TR>
																			<TD class="QH_ColLabel">Ngành nghề kinh doanh</TD>
																			<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaNganhKinhDoanh" Width="90%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD class="QH_ColLabel">Mặt hàng kinh doanh</TD>
																			<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtMatHangKinhDoanh" Width="90%" CssClass="QH_textbox" EnableViewState="true"
																					runat="server" TextMode="MultiLine" MaxLength="500"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="QH_ColLabel"><asp:label id="lbYkien" runat="server">Ý kiến đề xuất</asp:label></TD>
																			<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtNoiDung" Width="90%" CssClass="QH_textbox" EnableViewState="true" runat="server"
																					TextMode="MultiLine" Rows="6" MaxLength="2000"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="QH_ColLabel">Người ký <FONT color="#ff0000" size="4">*</FONT></TD>
																			<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaSoLanhDao" Width="40%" CssClass="QH_Dropdownlist" runat="server"></asp:dropdownlist></TD>
																		<TR>
																			<TD class="QH_ColLabel"></TD>
																			<TD class="QH_ColControl" colSpan="3"></TD>
																		</TR>
																	</TABLE>
																</DIV>
															</td>
														</tr>
														<tr>
															<td>&nbsp;</td>
														</tr>
														<TR>
															<TD align="center" colSpan="4" height="17"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>
																<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>
																<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton>
																<asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;</TD>
														</TR>
														<tr>
															<td>
																<asp:textbox id="Textbox1" Width="20px" runat="server" Visible="false"></asp:textbox>
																<asp:textbox id="txtDeXuatID" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox>
																<asp:textbox id="txtTabCode" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox>
																<asp:textbox id="txtMaLinhVuc" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox>
																<asp:textbox id="txtMaNguoiTacNghiep" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox>
																<asp:textbox id="txtNguoiNhan" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox>
																<asp:textbox id="txtMaCanBoDeXuat" Width="0px" runat="server"></asp:textbox>
															</td>
														</tr>
													</TABLE>
													<!-- content is put here -->
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center"></TD>
					</td>
				</tr>
			</table>
			<asp:textbox id="txtReload" runat="server" Width="20px" Visible="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtGiayCNDKKDID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtNgungKinhDoanhID" runat="server" Width="20px" Visible="False"></asp:textbox></TD>
		<TD class="QH_Khung_Right" width="16">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="*">
					<TD></TD>
				</TR>
				<TR height="141">
					<TD class="QH_Khung_Right1"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE> <INPUT id="hMsg" type="hidden" name="hMsg" runat="server">
<script>
		if (document.all("<%=hMsg.ClientID%>").value != ''){
			alert(document.all("<%=hMsg.ClientID%>").value);
			document.all("<%=hMsg.ClientID%>").value='';
		}

</script>
