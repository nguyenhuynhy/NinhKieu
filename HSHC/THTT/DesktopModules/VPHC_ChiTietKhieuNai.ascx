<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_ChiTietKhieuNai.ascx.vb" Inherits="THTT.VPHC_ChiTietKhieuNai" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE align="center" class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="90%"
	border="0">
	<tr>
		<td>
			<TABLE align="center" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colspan="4"><asp:label id="Label1" Runat="server" Width="100%" CssClass="QH_Label_Title">Chi tiết hồ sơ vi phạm</asp:label></TD>
				</TR>
				<TR>
					<TD colspan="4" height="10"></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="1" rowSpan="1" width="173" height="22">Số quyết 
						định:&nbsp;</TD>
					<TD height="22">
						<asp:HyperLink id="lblSoQD" runat="server"></asp:HyperLink></TD>
					<TD align="right" height="22">Ngày quyết định:&nbsp;</TD>
					<TD height="22"><asp:label id="lblNgayQD" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">Số công văn:&nbsp;</TD>
					<TD width="168"><asp:label id="lblSocv" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
					<TD align="right">&nbsp;Ra ngày :&nbsp;</TD>
					<TD><asp:label id="lblNgayCV" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="173" height="22">Người khiếu nại:&nbsp;&nbsp;</TD>
					<TD colSpan="3" height="22"><asp:label id="lblNguoiDaiDien" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="173" height="22">Nơi thường trú:&nbsp;</TD>
					<TD colSpan="3" height="22"><asp:label id="lblNoiThuongtru" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="173">Địa chỉ vi phạm:&nbsp;
					</TD>
					<TD colSpan="3"><asp:label id="lblDiaChi" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="173">Nội dung khiếu nại:&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblNoiDungKN" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="173">Nội dung trả lời:&nbsp;
					</TD>
					<TD colSpan="3"><asp:label id="lblTraLoi" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="173">Tình trạng hiện tại:&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblTTrang" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
				</TR>
			</TABLE>
			<!--
			<TABLE align="center" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR bgColor="#5486DD">
		<TD align="center" colSpan="4"><STRONG><FONT Color="White" >Quá trình xử lý</FONT></STRONG></TD>
				</TR>
				<TR class="StormyWeatherColumnTD">
					<TD width="15%">Ngày&nbsp;</TD>
					<TD width="25%">Nơi giải quyết&nbsp;</TD>
					<TD width="25%">Người thụ lý&nbsp;</TD>
					<TD width="35%">Công việc&nbsp;</TD>
				</TR>
				<%=getTTrangXLy()%>
			</TABLE>
			-->
		</td>
	</tr>
	<TR>
		<TD colspan="4" height="10"></TD>
	</TR>
	<TR>
		<TD colspan="3" align="center"><asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_TroVe.gif" CssClass="QH_Button"></asp:ImageButton></TD>
	</TR>
</TABLE>
