<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="PhieuTraHoSo.ascx.vb" Inherits="HSHC.PhieuTraHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc2" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function FillDiaChi(obj1,obj2,objDuong,objPhuong)
{
		var strDuong;
		var strPhuong;
		var index;
		if ((objDuong.selectedIndex >= 0)&&(objPhuong.selectedIndex >=0))
		{
			strDuong=objDuong.options[objDuong.selectedIndex].text;
			strPhuong=objPhuong.options[objPhuong.selectedIndex].text;						
			index=strDuong.indexOf("-");
			strDuong=strDuong.slice(index+1,strDuong.length);
			index=strPhuong.indexOf("-");
			strPhuong=strPhuong.slice(index+1,strPhuong.length);
			obj2.value=obj1.value+' '+strDuong+', '+strPhuong
			//+'//, Quận Tân Bình , TPHCM'
		}
}

</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Width="100%" runat="server" cssclass="QH_Label_Title">Phiếu trả hồ sơ</asp:label></td>
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
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="98%" border="0">
							<TR>
								<TD vAlign="top" width="50%">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD height="15"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="26%">Loại cấp giấy CN<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl" width="*"><asp:dropdownlist id="ddlMaLoaiHoSo" Width="98%" runat="server" CssClass="QH_DropDownList"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Họ tên người nộp<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtHoTenNguoiNop" Width="98%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="18%" colSpan="1" rowSpan="1">Giới tính</TD>
											<TD class="QH_ColControl" colSpan="1"><asp:dropdownlist id="ddlGioiTinh" runat="server" CssClass="QH_DropDownList">
													<asp:ListItem Selected="True"></asp:ListItem>
													<asp:ListItem Value="1">Nam</asp:ListItem>
													<asp:ListItem Value="0">Nữ</asp:ListItem>
												</asp:dropdownlist></TD>
										<tr>
											<TD class="QH_ColLabel">Lý do<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl" width="*">
												<asp:textbox id="txtLyDo" Width="98%" runat="server" CssClass="QH_Textbox" TextMode="MultiLine"
													Rows="5"></asp:textbox>
											</TD>
										</tr>
									</TABLE>
								</TD>
								<TD vAlign="top" width="50%">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD height="38" valign="bottom"><asp:label id="Label2" Width="100%" runat="server" cssclass="QH_LabelLeftBold">Địa chỉ đăng ký</asp:label></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Số nhà<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoNha" Width="50px" runat="server" CssClass="QH_Textbox" MaxLength="50"></asp:textbox></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel">Tên phường<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl">
												<cc2:KeySortDropDownList id="ddlMaPhuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc2:KeySortDropDownList></TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel">Tên đường<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl">
												<cc2:KeySortDropDownList id="ddlMaDuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc2:KeySortDropDownList></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel">Thường trú tại<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTru" runat="server" Width="90%" CssClass="QH_Textbox" TextMode="MultiLine"
													Rows="3"></asp:textbox></TD>
										</TR>
										<TR>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td colspan="2">
									<asp:textbox id="txtPhieuTraHoSoID" runat="server" Width="0px" CssClass="QH_Textbox" MaxLength="50"></asp:textbox>
									<asp:textbox id="txtMaNguoiSuDung" runat="server" Width="0px" CssClass="QH_Textbox" MaxLength="50"></asp:textbox>
									<asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px" CssClass="QH_Textbox" Visible="true"></asp:textbox><asp:textbox id="txtMaNguoiNhan" runat="server" Width="0px" CssClass="QH_Textbox" Visible="true"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Width="0px" CssClass="QH_Textbox" Visible="true"></asp:textbox>
								</td>
							</tr>
							<tr>
								<td height="10" colspan="2"></td>
							</tr>
							<TR>
								<TD vAlign="middle" align="center" colSpan="2"><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton>&nbsp;<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In phiếu</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
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
