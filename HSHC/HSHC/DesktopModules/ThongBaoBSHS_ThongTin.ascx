<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongBaoBSHS_ThongTin.ascx.vb" Inherits="PortalQH.ThongBaoBSHS_ThongTin" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="10%"></TD>
		<TD width="70%">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0" width="100%">
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" width="100%">
							<TR>
								<TD width="25%" class="QH_ColLabel">Số biên nhận</TD>
								<TD width="75%">
									<asp:TextBox id="txtSoBienNhan" runat="server" CssClass="QH_TextBox" Width="30%"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Họ tên</TD>
								<TD>
									<asp:TextBox id="txtHoTen" runat="server" CssClass="QH_TextBox" Width="100%"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Địa chỉ</TD>
								<TD>
									<asp:TextBox id="txtDiaChi" runat="server" CssClass="QH_TextBox" Width="100%"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="10px"></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="25%" class="QH_ColLabel">Ngày yêu cầu</TD>
								<TD width="75%">
									<asp:TextBox id="txtNgayYeuCau" runat="server" CssClass="QH_TextBox" Width="30%"></asp:TextBox>
									<asp:ImageButton id="btnNgayYeuCau" runat="server" CssClass="QH_Button" ImageUrl="../../Images/calendar.gif"></asp:ImageButton></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Ngày phải nộp hồ sơ</TD>
								<TD>
									<asp:TextBox id="txtNgayNop" runat="server" CssClass="QH_TextBox" Width="30%"></asp:TextBox>
									<asp:ImageButton id="btnNgayNop" runat="server" CssClass="QH_Button" ImageUrl="../../Images/calendar.gif"></asp:ImageButton></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Nội dung yêu cầu</TD>
								<TD>
									<asp:TextBox id="txtNoiDung" runat="server" CssClass="QH_TextBox" Width="100%" TextMode="MultiLine"
										Rows="3"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<td height="5px"></td>
				</tr>
				<tr>
					<td valign="bottom" align="center">
						<asp:ImageButton id="btnCapNhat" runat="server" CssClass="QH_Button" ImageUrl="../../Images/btn_CapNhat.gif"></asp:ImageButton>
						<asp:ImageButton id="btnInThu" runat="server" CssClass="QH_Button" ImageUrl="../../Images/btn_InRaGiay.gif"></asp:ImageButton>
						<asp:ImageButton id="btnTroVe" runat="server" CssClass="QH_Button" ImageUrl="../../Images/btn_TroVe.gif"></asp:ImageButton>
					</td>
				</tr>
			</table>
		</TD>
		<TD width="20%"></TD>
	</TR>
</TABLE>
