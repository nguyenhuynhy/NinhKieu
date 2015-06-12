<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CPXD_CHITIETHOSO.ascx.vb" Inherits="THTT.CPXD_CHITIETHOSO" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
					<TD vAlign="top">
						<asp:label id="Label1" Runat="server" Width="100%" CssClass="QH_Label_Title">Chi tiết hồ sơ xây dựng</asp:label>
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
						<TABLE width="100%">
							<tr>
								<td align="center">
									<table class="QH_Table" id="Table1" width="90%">
										<TR>
											<TD vAlign="top"><asp:label id="lblTieuDe" Runat="server" Width="100%" cssclass="QH_LabelMiddleBold"></asp:label></TD>
										</TR>
										<tr>
											<td vAlign="top">
												<table id="Table2" width="100%">
													<tr>
														<td vAlign="top" width="10%" colSpan="1" rowSpan="1"></td>
														<td class="QH_ColLabel" vAlign="top" align="right" width="20%" colSpan="1" rowSpan="1">Số 
															giấy phép:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top" width="25%"><asp:label id="lblSOGP" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
														<td class="QH_ColLabel" vAlign="top" align="right" width="20%">Ngày cấp:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top" width="25%"><asp:label id="lblNgayCap" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="22"></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Chủ đầu tư:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblHoTen" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Địa chỉ thường trú:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblThuongTru" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="22"></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Địa chỉ công trình XD:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblDiaChiXD" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Ký hiệu thiết kế:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblKYHIEUTHIETKE" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="22"></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Diện tích xây dựng:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblDienTich" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Phân loại xây dựng:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblLoaiXayDung" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="22"></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Diện tích sàn&nbsp;xây 
															dựng:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblDienTichSuDung" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
														<td class="QH_ColLabel" vAlign="top" align="right">Cấp nhà:&nbsp;</td>
														<td class="QH_ColLabelLeft" vAlign="top"><asp:label id="lblCapNha" CssClass="QH_LabelDisplay" runat="server"></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
										<TR>
											<TD align="center" colSpan="3"><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
										</TR>
									</table>
								</td>
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
