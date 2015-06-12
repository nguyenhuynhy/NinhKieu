<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NXHS_NhanXet.ascx.vb" Inherits="CPXD.NXHS_NhanXet" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" >
	<TR>
		<TD><asp:label id="Label1" runat="server" CssClass="QH_LabelLeftBold">Nhận xét tổng hợp và kiến nghị giải quyết( nêu rõ quan điểm và đề xuất cụ thể)</asp:label></TD>
	</TR>
	<TR>
		<TD>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD align="center" width="100%" colSpan="4"><asp:textbox id="txtNhanXet" runat="server" CssClass="QH_Textbox" TextMode="MultiLine" Width="98%"
							Height="100" tabIndex="14">Giấy tờ hợp lệ, ph&#249; hợp qui định đề xuất cấp ph&#233;p x&#226;y dựng theo biểu đ&#237;nh k&#232;m</asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4" height="5px">
					</TD>
				</TR>
				<TR>
					<TD width="20%"></TD>
					<TD width="30%"></TD>
					<TD class="QH_ColLabel" width="20%">Cán bộ thụ lý</TD>
					<TD class="QH_ColControl" width="30%"><asp:textbox id="txtMaSoNguoiSuDung" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="15"></asp:textbox></TD>
				<TR>
					<TD width="20%"></TD>
					<TD width="30%"></TD>
					<TD class="QH_ColLabel" width="20%">Lãnh đạo</TD>
					<TD class="QH_ColControl" width="30%">
						<asp:DropDownList id="ddlMaSoLanhDao" runat="server" CssClass="QH_Dropdownlist" Width="98%" tabIndex="16"></asp:DropDownList></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
