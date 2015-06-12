<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NXHS_PhapLy.ascx.vb" Inherits="CPXD.NXHS_PhapLy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="60%">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD colSpan="2" width="100%"><asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Xem xét hồ sơ pháp lý</asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Giấy phép sử dụng đất</TD>
					<TD class="QH_ColControl" width="70%"><asp:Textbox id="txtGiaySuDungDat" runat="server" Width="87%" CssClass="QH_Textbox" tabIndex="26"
							MaxLength="500"></asp:Textbox>
						<asp:LinkButton id="LinkGiaySuDungDat" runat="server">Chọn...</asp:LinkButton>
					</TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Về PCCC</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtPhongChayChuaChay" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="28"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Về môi trường</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtMoiTruong" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="30"
							MaxLength="100">/</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Thoả thuận kiến trúc</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtKienTruc" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="32"
							MaxLength="100">/</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Khác</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtKhacPhapLy" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="34"
							MaxLength="100">/</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Ý kiến UBND Q/P</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtYkienUBND" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="36"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Hiện trạng</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtHienTrang" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="38"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Bản đồ vị trí</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtViTriDat" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="40"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Giấy tờ CQ Nhà</TD>
					<TD class="QH_ColControl" width="70%"><asp:TextBox id="txtGiayChuQuyenNha" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="42"
							Rows="100"></asp:TextBox></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="40%">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<asp:Label id="Label2" CssClass="QH_LabelLeftBold" runat="server">Phần nhận xét</asp:Label></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtGiaySuDungDatNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="27"
							MaxLength="100">Đạt</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtPhongChayChuaChayNhanXet" runat="server" CssClass="QH_Textbox" Width="98%"
							tabIndex="29" MaxLength="100">Đạt</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtMoiTruongNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="31"
							MaxLength="100">Đạt</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtKienTrucNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="33"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtKhacPhapLyNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="35"
							MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtYKienUBNDNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="37"
							MaxLength="100">Đạt</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtHienTrangNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="39"
							MaxLength="100">Đạt</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtViTriDatNhanXet" runat="server" CssClass="QH_Textbox" Width="98%" tabIndex="41"
							Rows="100">Đạt</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColControl" width="100%" align="center"><asp:TextBox id="txtGiayChuQuyenNhaNhanXet" runat="server" CssClass="QH_Textbox" Width="98%"
							tabIndex="43" Rows="100">Đạt</asp:TextBox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
