<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NXHS_DoHoaThietKe.ascx.vb" Inherits="CPXD.NXHS_DoHoaThietKe" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" height="233" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="60%">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD width="100%" colSpan="2"><asp:label id="Label1" runat="server" CssClass="QH_LabelLeftBold">Nhận xét về đồ họa thiết kế</asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">DT đất đang sd (m2)</TD>
					<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtDienTichDangSuDung" runat="server" CssClass="QH_Textbox" Width="97%" tabIndex="70"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">DT khuôn viên xd (m2)</TD>
					<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtDienTichKhuonVienXayDung" runat="server" CssClass="QH_Textbox" Width="97%"
							tabIndex="72"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Trong đó: Có QSDĐ(m2)</TD>
					<TD class="QH_ColControl" width="20%"><asp:textbox id="txtQuyenSuDungDat" runat="server" CssClass="QH_Textbox" Width="100%" tabIndex="74"></asp:textbox></TD>
					<td width="20%" class="QH_ColLabel">
						Chưa có (m2)</td>
					<td class="QH_ColControl" width="30%"><asp:textbox id="txtQuyenSuDungDatChuaCo" runat="server" CssClass="QH_Textbox" Width="93%" tabIndex="75"></asp:textbox></td>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Mật độ xây dựng (%)</TD>
					<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtMatDoXayDung" runat="server" CssClass="QH_Textbox" Width="97%" tabIndex="77"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Tổng DT sàn XD (m2)</TD>
					<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtTongDienTichSanXayDung" runat="server" CssClass="QH_Textbox" Width="97%"
							tabIndex="79"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Cách tim đường (m)</TD>
					<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtCachTimDuongThietKe" runat="server" CssClass="QH_Textbox" Width="97%" tabIndex="81"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Công trình kế cận</TD>
					<TD class="QH_ColControl" width="70%" colSpan="3"><asp:textbox id="txtCongTrinhKeCan" runat="server" CssClass="QH_Textbox" Width="97%" tabIndex="83"></asp:textbox></TD>
				</TR>
				<TR>
					<TD width="100%" colSpan="4"><asp:label id="Label4" runat="server" CssClass="QH_LabelLeftBold">Các vấn đề khác</asp:label>
						<hr>
					</TD>
				</TR>
				<TR>
					<TD width="100%" colSpan="4">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="30%">Điện</TD>
								<TD class="QH_ColControl" width="20%"><asp:textbox id="txtDien" runat="server" CssClass="QH_Textbox" Width="90%" tabIndex="85"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="20%">Thoát nước</TD>
								<TD class="QH_ColControl" width="30%"><asp:textbox id="txtThoatNuoc" runat="server" CssClass="QH_Textbox" Width="90%" tabIndex="86"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="30%">Cấp nước</TD>
								<TD class="QH_ColControl" width="20%"><asp:textbox id="TxtCapNuoc" runat="server" CssClass="QH_Textbox" Width="90%" tabIndex="88"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="30%">Khác</TD>
								<TD class="QH_ColControl" width="20%"><asp:textbox id="txtKhacThietKe" runat="server" CssClass="QH_Textbox" Width="90%" tabIndex="89"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="40%">
			<TABLE id="TblNhanXet" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" class="QH_Table">
				<TR>
					<TD><asp:label id="Label2" runat="server" CssClass="QH_LabelLeftBold">Phần nhận xét</asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtDienTichDangSuDungNhanXet" runat="server" CssClass="QH_Textbox" Width="98%"
							tabIndex="71"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtDienTichKhuonVienXayDungNhanXet" runat="server" CssClass="QH_Textbox" Width="98%"
							tabIndex="73"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtQuyenSuDungDatNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="76"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtMatDoXayDungNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="78"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtTongDienTichSanXayDungNhanXet" runat="server" CssClass="QH_Textbox" Width="98%"
							tabIndex="80"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtCachTimDuongThietKeNhanXet" runat="server" CssClass="QH_Textbox" Width="98%"
							tabIndex="82"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtCongTrinhKeCanNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="84"></asp:textbox></TD>
				</TR>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<TR>
					<td>
						<hr>
					</td>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtKhacThietKeNhanXet1" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="87"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtKhacThietKeNhanXet2" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="90"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
