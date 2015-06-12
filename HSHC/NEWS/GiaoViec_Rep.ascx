<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GiaoViec_Rep.ascx.vb" Inherits="PortalQH.GiaoViec_Rep" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lbltTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">GIAO VIỆC</asp:label>
					</td>
					<td width="8" height="25" class="QH_Content_TopRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="9" class="QH_Content_Left">&nbsp;
					</td>
					<td width="*" valign="top">
						<!--End bound-->
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td align="center">
									<table width="90%" align="center" cellpadding="0" cellspacing="0">
										<tr>
											<td align="center">
												<table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td width="7%"><asp:label id="label1" CssClass="QH_Label" Runat="server">Công việc</asp:label>
															<asp:label id="Label6" CssClass="QH_Label" Runat="server" ForeColor="Red">*</asp:label></td>
														<td colSpan="3"><asp:textbox id="txtTieuDe" Width="72%" CssClass="QH_TextBox" Runat="server"></asp:textbox>
															<asp:label id="Label7" CssClass="QH_Label" Runat="server" ForeColor="Red"></asp:label></td>
													</tr>
													<tr>
														<td width="7%"><asp:label id="lbl3" CssClass="QH_Label" Runat="server">Ngày giao việc</asp:label>
															<asp:label id="Label3" CssClass="QH_Label" Runat="server" ForeColor="Red">*</asp:label></td>
														<td width="10%"><asp:textbox id="txtNgayGiaoViec" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
															<asp:Image id="imgNgayGiao" CssClass="QH_IMAGEBUTTON" AlternateText="Chọn ngày tháng năm" ImageUrl="~/images/calendar.gif"
																runat="server"></asp:Image></td>
														<td width="7%"><asp:label id="lbl4" CssClass="QH_label" Runat="server"> Người giao</asp:label></td>
														<td width="20%">
															<asp:TextBox id="txtNguoiGiaoViec" CssClass="QH_Textbox" runat="server" Width="48%" ReadOnly="True"></asp:TextBox>
															<asp:label id="Label8" CssClass="QH_Label" Runat="server" ForeColor="Red"></asp:label></td>
													</tr>
													<tr>
														<td width="7%"><asp:label id="lbl5" CssClass="QH_label" Runat="server">Ngày hoàn thành</asp:label>
															<asp:label id="Label4" CssClass="QH_Label" Runat="server" ForeColor="Red">*</asp:label></td>
														<td colSpan="3"><asp:textbox id="txtNgayHoanThanh" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
															<asp:Image id="imgNgayXong" CssClass="QH_IMAGEBUTTON" AlternateText="Chọn ngày tháng năm" ImageUrl="~/images/calendar.gif"
																runat="server"></asp:Image>
															<asp:label id="Label9" CssClass="QH_Label" Runat="server" ForeColor="Red"></asp:label></td>
													</tr>
													<tr>
														<td vAlign="top" width="7%">
															<asp:label id="Label5" CssClass="QH_Label" Runat="server">Nội dung công việc</asp:label></td>
														<td colSpan="3"><asp:textbox id="txtNoiDung" Width="80%" CssClass="QH_TextBox" Runat="server" Rows="4" TextMode="MultiLine"></asp:textbox>
														</td>
													</tr>
													<tr>
														<td vAlign="top" width="7%"><asp:label id="lblNTH" CssClass="QH_Label" Runat="server">Người thực hiện</asp:label></td>
														<td width="*" colSpan="3">
															<asp:checkboxlist id="CklDsNguoiThucHien" CssClass="QH_LoaiHS" Width="80%" runat="server" RepeatColumns="3"></asp:checkboxlist></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center">
												<table id="tblHienThi" width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td width="16%"><asp:label CssClass="QH_Label" id="lbl16" Runat="server">Tình trạng</asp:label></td>
														<td><asp:dropdownlist id="ddlTinhTrang" Width="25%" CssClass="QH_Dropdownlist" Runat="server">
																<asp:ListItem></asp:ListItem>
																<asp:ListItem Value="0">Đang thực hiện</asp:ListItem>
																<asp:ListItem Value="1">Đ&#227; ho&#224;n th&#224;nh</asp:ListItem>
															</asp:dropdownlist></td>
													</tr>
													<tr>
														<td vAlign="top"><asp:label CssClass="QH_Label" id="Label2" Runat="server">Diễn giải</asp:label></td>
														<td><asp:TextBox id="txtDienGiai" CssClass="QH_TextBox" Width="80%" TextMode="MultiLine" Rows="4"
																Runat="server"></asp:TextBox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td height="5"></td>
										</tr>
										<tr>
											<td align="center">
												<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnDuyet" CssClass="QH_Button" runat="server">Duyệt</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>
											</td>
										</tr>
										<tr>
											<td>
												<asp:TextBox ID="txtNguoiThucHien" Runat="server" Width="0px"></asp:TextBox>
												<asp:TextBox ID="txtCongViecID" Runat="server" Width="0px"></asp:TextBox>
												<asp:TextBox ID="txtDuyet" Runat="server" Width="0px"></asp:TextBox>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<!--start bound-->
					</td>
					<td width="8" class="QH_Content_Right">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colspan="3" height="38">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="8" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
						<table width="258" height="100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td Width="100%" height="100%">
								</td>
							</tr>
						</table>
					</td>
					<td width="8" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
