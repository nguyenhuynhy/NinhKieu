<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_ChitietLapBienBan.ascx.vb" Inherits="THTT.VPHC_ChitietLapBienBan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="90%" align="center"
	border="0">
	<tr>
		<td>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="4"><asp:label id="Label1" CssClass="QH_Label_Title" Width="100%" Runat="server">Chi tiết hồ sơ vi phạm</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4" height="10"></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="173" colSpan="1" height="22" rowSpan="1">Số quyết 
						định:&nbsp;</TD>
					<TD>
						<asp:label id="lblSoQD" runat="server" ForeColor="#0000C0"></asp:label></TD>
					<TD class="QH_ColLabel" height="22">Ngày quyết định:&nbsp;</TD>
					<TD height="22"><asp:label id="lblNgayQD" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Số biên bản:&nbsp;</TD>
					<TD width="168"><asp:label id="lblSoBB" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
					<TD class="QH_ColLabel">&nbsp;Ngày biên bản:&nbsp;</TD>
					<TD><asp:label id="lblNgayBB" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="173">Số giấy&nbsp;phép:&nbsp;</TD>
					<TD><asp:hyperlink id="hyperlinkSoGP" runat="server" Font-Size="10pt" Font-Names="Arial" Visible="False"></asp:hyperlink><asp:label id="lblSoGP" runat="server" ForeColor="#0000C0"></asp:label></TD>
					<TD class="QH_ColLabel">Ngày cấp phép:&nbsp;</TD>
					<TD><asp:label id="lblNgayCP" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="173" height="22">Họ tên:&nbsp;&nbsp;</TD>
					<TD colSpan="3" height="22"><asp:label id="lblNguoiDaiDien" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="173" height="22">Nơi thường trú:&nbsp;</TD>
					<TD colSpan="3" height="22"><asp:label id="lblNoiThuongtru" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="173">Địa chỉ vi phạm:&nbsp;
					</TD>
					<TD colSpan="3"><asp:label id="lblDiaChi" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="173">Nội dung vi phạm:&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblNoiDungVP" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="173">Tình trạng hiện tại:&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblTTrang" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
			</TABLE>
		</td>
	</tr>
	<TR>
		<TD colSpan="4" height="10"></TD>
	</TR>
	<!--
	<tr>
		<td>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR bgColor="#5486dd">
					<TD align="center" colSpan="4"><STRONG><FONT color="white">Quá trình xử lý</FONT></STRONG></TD>
				</TR>
				<TR class="StormyWeatherColumnTD">
					<TD width="15%">Ngày&nbsp;</TD>
					<TD width="25%">Nơi giải quyết&nbsp;</TD>
					<TD width="25%">Người thụ lý&nbsp;</TD>
					<TD width="35%">Công việc&nbsp;</TD>
				</TR>
				<%=getTTrangXLy()%>
			</TABLE>
		</td>
	</tr>
	-->
	<TR>
		<TD colSpan="4" height="10"></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="3"><asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_TroVe.gif" CssClass="QH_Button"></asp:ImageButton></TD>
	</TR>
</TABLE>
