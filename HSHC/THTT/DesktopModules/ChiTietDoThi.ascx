<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChiTietDoThi.ascx.vb" Inherits="THTT.ChiTietDoThi" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table width="100%">
	<tr>
		<td align="center">
			<table id="Table1" width="90%" class="QH_Table">
				<TR>
					<TD vAlign="top">
						<asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Chi tiết hồ sơ xây dựng</asp:label>
					</TD>
				</TR>
				<tr>
					<td vAlign="top">
						<table id="Table2" width="100%">
							<tr>
								<td vAlign="top" colSpan="1" rowSpan="1" width="22"></td>
								<td vAlign="top" align="right" colSpan="1" rowSpan="1" width="25%">Số&nbsp;giấy 
									phép:&nbsp;</td>
								<td vAlign="top"><asp:label id="lblSOGP" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
								<td vAlign="top" align="right">Ngày cấp:&nbsp;</td>
								<td vAlign="top"><asp:label id="lblNgayCap" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
							<tr>
								<td width="22"></td>
								<td vAlign="top" align="right">Họ tên chủ đầu tư:&nbsp;</td>
								<td vAlign="top" colSpan="3">
									<asp:label id="lblHoTen" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
							<tr>
								<td width="22"></td>
								<td vAlign="top" align="right">Địa chỉ thường trú:&nbsp;</td>
								<td vAlign="top" colSpan="3">
									<asp:label id="lblThuongTru" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
							<tr>
								<td width="22"></td>
								<td vAlign="top" align="right">Địa chỉ công trình XD:&nbsp;</td>
								<td vAlign="top" colSpan="3"><asp:label id="lblDiaChiXD" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
							<tr>
								<td width="22"></td>
								<td vAlign="top" align="right">Nội dung xây dựng:&nbsp;</td>
								<td vAlign="top" colSpan="3"><asp:label id="lblNoiDungXD" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
							<tr>
								<td width="22"></td>
								<td vAlign="top" align="right">Diện tích:&nbsp;</td>
								<td vAlign="top" colSpan="3"><asp:label id="lblDienTich" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
							<tr>
								<td width="22"></td>
								<td vAlign="top" align="right">Tên&nbsp;cấp nhà:&nbsp;</td>
								<td vAlign="top" colSpan="3"><asp:label id="lblTenCapNha" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
							<tr>
								<td width="22"></td>
								<td vAlign="top" align="right">Ngày hoàn công:&nbsp;</td>
								<td vAlign="top" colSpan="3"><asp:label id="lblNgayHoanCong" runat="server" CssClass="QH_LabelDisplay"></asp:label></td>
							</tr>
						</table>
						<table id="Table3" cellSpacing="1" cellPadding="1" width="100%">
							<tr>
								<td align="center" colSpan="4"></td>
							</tr>
							<tr>
								<td align="left" colSpan="4"><asp:label id="lblSOLAN" runat="server"></asp:label>&nbsp;lần
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<TD align="center" colSpan="3"><asp:imagebutton id="btnTroVe" CssClass="QH_Button" runat="server" ImageUrl="../../Images/btn_TroVe.gif"></asp:imagebutton></TD>
				</TR>
			</table>
		</td>
	</tr>
</table>
