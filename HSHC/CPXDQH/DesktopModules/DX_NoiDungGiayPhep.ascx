<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DX_NoiDungGiayPhep.ascx.vb" Inherits="CPXD.DX_NoiDungGiayPhep" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="60%" height="300" valign=top>
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				
				<TR>
					<TD class="QH_ColLabel" width="20%">Bản vẽ thiết kế số</TD>
					<TD class="QH_ColControl" width="*">
						<asp:Textbox id="txtGP_KyHieuThietKe" tabIndex="26" MaxLength="500" Width="87%" runat="server"
							CssClass="QH_Textbox"></asp:Textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Đơn vị thiết kế</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_DonViThietKe" tabIndex="28" MaxLength="100" Width="98%" runat="server"
							CssClass="QH_Textbox"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Quy mô</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_QuyMo" tabIndex="30" MaxLength="100" Width="98%" runat="server" CssClass="QH_Textbox"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Kết cấu</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_KetCau" tabIndex="32" MaxLength="100" Width="98%" runat="server" CssClass="QH_Textbox"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Chiều cao từng tầng</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_ChieuCaoTungTang" tabIndex="34" TextMode="MultiLine" Rows=3 MaxLength="100" Width="98%"
							runat="server" CssClass="QH_Textbox"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Chiều cao toàn công trình</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_ChieuCaoToanCongTrinh" tabIndex="34" MaxLength="100" Width="98%" runat="server"
							CssClass="QH_Textbox"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Diện tích xây dựng</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_DienTichXayDung" tabIndex="34" MaxLength="100" Width="98%" runat="server"
							CssClass="QH_Textbox" TextMode=MultiLine Rows=5></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Diện tích sân</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_DienTichSan" tabIndex="34" MaxLength="100" Width="98%" runat="server"
							CssClass="QH_Textbox">/</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Chi chú</TD>
					<TD class="QH_ColControl" width="*">
						<asp:TextBox id="txtGP_GhiChu" tabIndex="34" TextMode="MultiLine" MaxLength="100" Width="98%"
							runat="server" CssClass="QH_Textbox">/</asp:TextBox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
