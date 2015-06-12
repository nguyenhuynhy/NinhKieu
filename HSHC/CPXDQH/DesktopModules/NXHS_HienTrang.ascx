<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NXHS_HienTrang.ascx.vb" Inherits="CPXD.NXHS_HienTrang" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="60%">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD width="100%" colSpan="2"><asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Xem xét hiện trạng nhà đất</asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Diện tích đất (m2)</TD>
					<TD class="QH_ColControl" width="85%"><asp:textbox id="txtDienTichDat" tabIndex="44" CssClass="QH_Textbox" runat="server" Width="60%"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Diện tích xây dựng (m2)</TD>
					<TD class="QH_ColControl" width="85%"><asp:textbox id="txtDienTichXayDung" tabIndex="46" CssClass="QH_Textbox" runat="server" Width="60%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Kết cấu</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtKetCau" tabIndex="48" CssClass="QH_Textbox" runat="server" Width="85%"></asp:textbox>&nbsp;<asp:linkbutton id="LinkKetCau" tabIndex="15" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Số tầng</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtSoTang" tabIndex="50" CssClass="QH_Textbox" runat="server" Width="85%"></asp:textbox>&nbsp;<asp:linkbutton id="LinkSoTang" tabIndex="16" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Cách tim đường</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtCachTimDuongNhaDat" tabIndex="52" CssClass="QH_Textbox" runat="server" Width="98%">Mặt tiền c&#225;ch tim đường hiện hữu: xm</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Kiến trúc kế cận</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtKienTrucKeCan" tabIndex="54" CssClass="QH_Textbox" runat="server" Width="98%">/</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Các vấn đề khác</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtVanDeKhac" tabIndex="56" CssClass="QH_Textbox" runat="server" Width="98%">/</asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="40%">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD><asp:label id="Label2" CssClass="QH_LabelLeftBold" runat="server">Phần nhận xét</asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtDienTichDatNhanXet" tabIndex="45" CssClass="QH_Textbox" runat="server" Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtDienTichXayDungNhanXet" tabIndex="47" CssClass="QH_Textbox" runat="server"
							Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtKetCauNhanXet" tabIndex="49" CssClass="QH_Textbox" runat="server" Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtSoTangNhanXet" tabIndex="51" CssClass="QH_Textbox" runat="server" Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtCachTimDuongNhaDatNhanXet" tabIndex="53" CssClass="QH_Textbox" runat="server"
							Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtKienTrucKeCanNhanXet" tabIndex="55" CssClass="QH_Textbox" runat="server"
							Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtVanDeKhacNhanXet" tabIndex="57" CssClass="QH_Textbox" runat="server" Width="98%"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
