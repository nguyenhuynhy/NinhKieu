<%@ Register TagPrefix="uc1" TagName="DX_HienTrangNhaDat" Src="DX_HienTrangNhaDat.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DX_NoiDungGiayPhep" Src="DX_NoiDungGiayPhep.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NXHS_HangMucXDTruoc" Src="NXHS_HangMucXDTruoc.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DeXuat.ascx.vb" Inherits="CPXD.DeXuat" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="DX_QuyHoach" Src="DX_QuyHoach.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DX_HoSoPhapLy" Src="DX_HoSoPhapLy.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc1" TagName="ChuDauTuList" Src="ChuDauTuList.ascx" %>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Báo cáo đề xuất</asp:label></td>
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
									<TABLE class="QH_Table" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TBODY>
											<TR>
												<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
												<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="20%" runat="server" EnableViewState="true"
														Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" height="4">Loại hồ so</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:dropdownlist id="ddlMaLoaiHoSo" CssClass="QH_DropDownList" Width="90%" runat="server" EnableViewState="true"
														Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<tr>
											<TR>
												<TD class="QH_ColLabel" width="15%">Họ tên</TD>
												<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"></asp:textbox></TD>
												<TD class="QH_ColLabel" width="10%">Giới tính</TD>
												<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinh" CssClass="QH_DropDownList" Width="20%" runat="server" EnableViewState="true"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Ðịa chỉ cư trú</TD>
												<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtDiaChi" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel">Ðịa chỉ xây dựng</TD>
												<TD class="QH_ColControl" vAlign="top" colSpan="3">
													<table>
														<tr>
															<td width="10%">
																<asp:textbox id="txtSoNha" CssClass="QH_Textbox" Width="100%" runat="server"></asp:textbox></td>
															<TD>Ðường</TD>
															<td><cc1:combobox id="ddlMaDuong" CssClass="QH_DropDownList" runat="server" autoValidate="true" null="false"
																	listsize="190" SIZE="27"></cc1:combobox></td>
															<td>
																Phường
															</td>
															<td>
																<cc1:combobox id="ddlMaPhuong" CssClass="QH_DropDownList" runat="server" autoValidate="true" null="false"
																	listsize="190" SIZE="30"></cc1:combobox></td>
														</tr>
													</table>
												</TD>
											<TR>
												<TD class="QH_ColLabel">Lô dất</TD>
												<TD class="QH_ColControl" colSpan="3" width="*">
													<asp:TextBox id="txtLoDat" CssClass="QH_Textbox" Width="90%" runat="server"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="QH_ColLabel" width="15%">Loại công trình</TD>
												<td class="QH_ColControl" colSpan="3" width="*">
													<cc1:combobox id="ddlMaLoaiCongTrinh" CssClass="QH_DropDownList" runat="server" SIZE="30" listsize="190"
														null="false" autoValidate="true"></cc1:combobox></td>
											<TR>
												<TD class="QH_ColLabel" width="15%">Người ký</TD>
												<TD class="QH_ColControl" colSpan="3"><cc1:combobox id="ddlMaSoLanhDao" CssClass="QH_DropDownList" runat="server" autoValidate="true"
														null="false" listsize="190" SIZE="30"></cc1:combobox></TD>
											</TR>
							</tr>
							</TBODY></TABLE>
						<asp:textbox id="txtBaoCaoDeXuatID" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" CssClass="QH_textbox" Width="21px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtLoai" CssClass="QH_textbox" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaCanBoDeXuat" Width="0px" runat="server"></asp:textbox>
					</td>
				</tr>
				<TR>
					<TD width="100%">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<TR>
								<TD><ie:tabstrip id="TabStrip1" tabIndex="14" runat="server" TargetID="tsNXHS" SepDefaultStyle="background-color:white;border-color:steelblue;border-width:1px;border-style:solid;border-top:none;border-left:none;border-right:none;border-bottom:none;"
										TabDefaultStyle="color:steelblue;background-color:white;border-color:steelblue;border-style:solid;border-width:1px;font-family:verdana;font-weight:bold;font-size:8pt;width:135;height:21;text-align:center;"
										TabHoverStyle="color:blue;text-decoration:none; " TabSelectedStyle="color:white;background-color:steelblue;">
										<ie:Tab Text="Hồ sơ pháp lý"></ie:Tab>
										<ie:Tab Text="Hiện trạng nhà đất"></ie:Tab>
										<ie:Tab Text="Quy hoạch kiến trúc"></ie:Tab>
										<ie:Tab Text="Các yếu tố khác"></ie:Tab>
										<ie:Tab Text="Nội dung giấy phép"></ie:Tab>
									</ie:tabstrip></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td><ie:multipage id="tsNXHS" runat="server">
							<ie:PageView>
								<table width="100%" align="center">
									<tr>
										<td>
											<uc1:DX_HoSoPhapLy id="DX_HoSoPhapLy1" runat="server"></uc1:DX_HoSoPhapLy>
										</td>
									</tr>
								</table>
							</ie:PageView>
							<ie:PageView>
								<table width="100%" align="center">
									<tr>
										<td>
											<uc1:DX_HienTrangNhaDat id="DX_HienTrangNhaDat1" runat="server"></uc1:DX_HienTrangNhaDat></td>
									</tr>
								</table>
							</ie:PageView>
							<ie:PageView>
								<table width="100%" align="center">
									<tr>
										<td>
											<uc1:DX_QuyHoach id="DX_QuyHoach1" runat="server"></uc1:DX_QuyHoach></td>
									</tr>
								</table>
							</ie:PageView>
							<ie:PageView>
								<table width="100%" align="center" height="306">
									<tr>
										<td valign="top">
											<TABLE id="Table1" class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr valign="top">
													<TD class="QH_ColLabel" height="15" colspan="4">
													</TD>
												</tr>
												<tr valign="top">
													<td class="QH_ColLabel" width="20%">
														<asp:linkbutton id="LinkChon" runat="server">Chọn...</asp:linkbutton></td>
													<TD class="QH_ColControl" width="*">
														<asp:textbox id="txtYeuToKhac" CssClass="QH_textbox" Width="100%" runat="server" EnableViewState="true"
															TextMode="MultiLine" Rows="10"></asp:textbox></TD>
													<td class="QH_ColLabel" width="2%"></td>
												</tr>
												<tr valign="top">
													<TD class="QH_ColLabel" height="15" colspan="4">
													</TD>
												</tr>
											</TABLE>
										</td>
									</tr>
								</table>
							</ie:PageView>
							<ie:PageView>
								<table width="100%" align="center">
									<tr>
										<td>
											<uc1:NXHS_HangMucXDTruoc id="NoiDungGiayPhep" runat="server"></uc1:NXHS_HangMucXDTruoc>
										</td>
									</tr>
								</table>
							</ie:PageView>
						</ie:multipage></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<TR>
					<TD align="center" colSpan="4"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
						<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>&nbsp;
						<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In đề xuất</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;
						<asp:TextBox id="txtGP_DienTichSanXayDung" Width="0px" runat="server"></asp:TextBox></TD>
				</TR>
			</table>
		</TD>
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
	</TR>
</TABLE>
</TD></TR></TABLE>
