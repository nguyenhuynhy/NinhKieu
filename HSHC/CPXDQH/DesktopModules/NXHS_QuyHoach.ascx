<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NXHS_QuyHoach.ascx.vb" Inherits="CPXD.NXHS_QuyHoach" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="60%">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD width="100%" colSpan="2"><asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Yêu cầu về quy hoạch kiến trúc (theo quy hoạch và pháp luật)</asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Vị trí quy hoạch</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtViTriQuyHoach" tabIndex="91" CssClass="QH_Textbox" runat="server" Width="85%"></asp:textbox>&nbsp;<asp:linkbutton id="LinkViTriQuiHoach" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Lộ giới
					</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtLoGioi" tabIndex="93" CssClass="QH_Textbox" runat="server" Width="85%"></asp:textbox>&nbsp;
						<asp:linkbutton id="LinkLoGioi" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Đường dự phòng</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtDuongDuPhong" tabIndex="95" CssClass="QH_Textbox" runat="server" Width="98%">Kh&#244;ng</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Khoảng lùi</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtKhoangLui" tabIndex="97" CssClass="QH_Textbox" runat="server" Width="98%">/</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Kiến trúc khu vực</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtKienTrucKhuVuc" tabIndex="99" CssClass="QH_Textbox" runat="server" Width="98%">/</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Các vấn đề khác</TD>
					<TD class="QH_ColControl" width="70%"><asp:textbox id="txtVanDeKhac2" tabIndex="101" CssClass="QH_Textbox" runat="server" Width="98%">/</asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="40%">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD><asp:label id="Label2" CssClass="QH_LabelLeftBold" runat="server">Phần nhận xét</asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtViTriQuyHoachNhanXet" tabIndex="92" CssClass="QH_Textbox" runat="server"
							Width="98%">Đạt</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtLoGioiNhanXet" tabIndex="94" CssClass="QH_Textbox" runat="server" Width="98%">Đạt</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtDuongDuPhongNhanXet" tabIndex="96" CssClass="QH_Textbox" runat="server" Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtKhoangLuiNhanXet" tabIndex="98" CssClass="QH_Textbox" runat="server" Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtKienTrucKhuVucNhanXet" tabIndex="100" CssClass="QH_Textbox" runat="server"
							Width="98%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" align="center" width="100%"><asp:textbox id="txtVanDeKhacNhanXet2" tabIndex="102" CssClass="QH_Textbox" runat="server" Width="98%"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
