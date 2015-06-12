<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LichSuGiayPhep.ascx.vb" Inherits="CPKTQH.LichSuGiayPhep" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" Width="100%" runat="server" CssClass="QH_Label_Title"> Lịch sử cấp giấy chứng nhận ĐKKD</asp:label></td>
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
									<TD height="5"></TD>
								</TR>
								<TR>
									<TD align="center">
									</TD>
								</TR>
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Label id="Label1" CssClass="QH_LabelLeftBold" runat="server" Font-Bold="True">Số giấy phép : 41N.P06.05.0001..TM</asp:Label><BR>
										<BR>
										<asp:DataGrid id="dgdLichSu" runat="server"></asp:DataGrid><BR>
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="90%" border="0">
										</TABLE>
										<BR>
										<asp:linkbutton id="btnInBanSao" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton>
										<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server"> Trở về</asp:linkbutton>
									</TD>
								</TR>
								<TR>
									<TD align="center"></TD>
					</td>
				</tr>
			</table>
			<asp:textbox id="txtReload" runat="server" Width="20px" Visible="False"></asp:textbox>
			<asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox>
			<asp:textbox id="txtGiayCNDKKDID" runat="server" Width="0px"></asp:textbox>
			<asp:textbox id="txtNgungKinhDoanhID" runat="server" Width="20px" Visible="False"></asp:textbox></TD>
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
</TD></TR></TBODY></TABLE>
