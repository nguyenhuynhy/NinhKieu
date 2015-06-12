<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DX_QuyHoach.ascx.vb" Inherits="CPXD.DX_QuyHoach" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="60%" height="300" valign="top">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" colspan="2" height="15"></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">
						Thuộc khu quy hoạch</TD>
					<TD class="QH_ColControl" width="*">
						<asp:Textbox id="txtQH_LoaiKhuQuyHoach" tabIndex="26" CssClass="QH_Textbox" runat="server" Width="87%"
							MaxLength="500">ĐẤT Ở</asp:Textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Lộ giới</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtQH_LoGioi" tabIndex="28" CssClass="QH_Textbox" runat="server" Width="98%"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Chỉ giới xây dựng</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtQH_ChiGioi" tabIndex="30" CssClass="QH_Textbox" runat="server" Width="98%"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Đường dự phóng</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtQH_DuongDuPhong" tabIndex="32" CssClass="QH_Textbox" runat="server" Width="98%"
							MaxLength="100">/</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Khoảng lùi</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtQH_KhoangLui" tabIndex="34" CssClass="QH_Textbox" runat="server" Width="98%"
							MaxLength="100">/</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Mật độ XD</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtQH_MatDo" tabIndex="34" CssClass="QH_Textbox" runat="server" Width="90%"
							MaxLength="100"></asp:TextBox>
						(%)</TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Mối quan hệ với các kiến trúc kế cận</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtQH_QuanHeKienTrucKeCan" tabIndex="34" CssClass="QH_Textbox" runat="server"
							Width="98%" MaxLength="100">/</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" colspan="2" height="15"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
