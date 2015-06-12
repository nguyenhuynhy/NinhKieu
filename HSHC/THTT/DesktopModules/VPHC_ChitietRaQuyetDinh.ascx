<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_ChitietRaQuyetDinh.ascx.vb" Inherits="THTT.VPHC_ChitietRaQuyetDinh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
					<TD class="QH_ColLabel" colSpan="1" rowSpan="1" width="25%">Số quyết định:&nbsp;</TD>
					<TD width="25%"><asp:label id="lblSoQD" runat="server" ForeColor="#0000C0"></asp:label></TD>
					<TD align="right" width="20%">Ngày quyết định:&nbsp;</TD>
					<TD width="30%"><asp:label id="lblNgayQD" runat="server" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Số biên bản:&nbsp;</TD>
					<TD width="168"><asp:label id="lblSoBB" runat="server" ForeColor="#0000C0"></asp:label></TD>
					<TD class="QH_ColLabel">&nbsp;Ngày lập&nbsp;biên bản:&nbsp;</TD>
					<TD><asp:label id="lblNgayBB" runat="server" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Số giấy&nbsp;phép:&nbsp;</TD>
					<TD>
						<asp:hyperlink id="hyperlinkSoGP" runat="server" Visible="False"></asp:hyperlink>
						<asp:label id="lblSoGP" ForeColor="#0000C0" runat="server"></asp:label></TD>
					<TD class="QH_ColLabel">Ngày cấp phép:&nbsp;</TD>
					<TD>
						<asp:label id="lblNgayCP" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Họ tên:&nbsp;&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblNguoiDaiDien" runat="server" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Nơi thường trú:&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblNoiThuongtru" runat="server" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Địa chỉ vi phạm:&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblDiaChi" runat="server" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Nội dung vi phạm:&nbsp;</TD>
					<TD colSpan="3"><asp:label id="lblNoiDungVP" runat="server" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Tình trạng hiện tại:&nbsp;</TD>
					<TD colSpan="3">
						<asp:label id="lblTTrang" runat="server" cssclass="QH_LabelLeft" ForeColor="#0000C0"></asp:label></TD>
				</TR>
				<TR>
					<TD colspan="4" height="10"></TD>
				</TR>
			</TABLE>
			<!--
			<TABLE align="center" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
