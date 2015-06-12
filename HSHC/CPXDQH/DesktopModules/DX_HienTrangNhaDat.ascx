<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DX_HienTrangNhaDat.ascx.vb" Inherits="CPXD.DX_HienTrangNhaDat" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD vAlign="top" width="60%" height="300">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" width="100%" colSpan="2" height="15"></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%" height="23">Hiện trạng nhà đất</TD>
					<TD class="QH_ColControl" width="*" height="23"><asp:textbox id="txtHTND_Noidung" tabIndex="26" MaxLength="500" Width="87%" runat="server" CssClass="QH_Textbox"></asp:textbox>&nbsp;<asp:linkbutton id="LinkKetCau" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%" height="23">Hiện trạng, kiến trúc kế cận</TD>
					<TD class="QH_ColControl" width="*" height="23"><asp:textbox id="txtHTND_KienTrucKeCan" tabIndex="28" MaxLength="100" Width="87%" runat="server"
							CssClass="QH_Textbox"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%" height="23">Tường chung, riêng</TD>
					<TD class="QH_ColControl" width="*" height="23"><asp:textbox id="txtHTND_Tuong" tabIndex="30" MaxLength="100" Width="87%" runat="server" CssClass="QH_Textbox"></asp:textbox>&nbsp;
						<asp:LinkButton id="LnkTuong" runat="server">Chọn </asp:LinkButton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Đường dây điện cách công trình</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtHTND_Dien" tabIndex="32" MaxLength="100" Width="87%" runat="server" CssClass="QH_Textbox">/</asp:textbox>&nbsp;
						<asp:linkbutton id="LnkDien" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Đường cấp thoát nước, cáp ngầm cách công trình</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtHTND_Nuoc" tabIndex="34" MaxLength="100" Width="87%" runat="server" CssClass="QH_Textbox">/</asp:textbox>&nbsp;
						<asp:linkbutton id="LnkNuoc" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="100%" colSpan="2" height="15"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
