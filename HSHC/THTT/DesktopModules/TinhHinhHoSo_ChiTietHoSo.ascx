<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TinhHinhHoSo_ChiTietHoSo.ascx.vb" Inherits="THTT.TinhHinhHoSo_ChiTietHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="10%"></TD>
		<TD width="*">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="6"><asp:label id="Label1" Runat="server" Width="100%" CssClass="QH_Label_Title">Chi tiết tiếp nhận hồ sơ</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6" height="10"></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="17%">Số biên nhận:</TD>
					<TD width="1%"></TD>
					<TD width="19%"><asp:label id="lblSoBienNhan" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
					<TD class="QH_ColLabel" width="18%">Loại hồ sơ:</TD>
					<TD width="1%"></TD>
					<TD width="44%"><asp:label id="lblLoaiHoSo" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
				<TR>
					<TD class="QH_ColLabel">Ngày nhận:</TD>
					<TD></TD>
					<TD><asp:label id="lblNgayNhan" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
					<TD class="QH_ColLabel">Người nhận:</TD>
					<TD></TD>
					<TD><asp:label id="lblNguoiNhan" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Ngày hẹn trả:</TD>
					<TD></TD>
					<TD><asp:label id="lblNgayHenTra" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
					<TD class="QH_ColLabel">Người nộp:</TD>
					<TD></TD>
					<TD><asp:label id="lblNguoiNop" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Ngày thực trả:</TD>
					<TD></TD>
					<TD><asp:label id="lblNgayThucTra" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
					<TD class="QH_ColLabel">Địa chỉ:</TD>
					<TD></TD>
					<TD><asp:label id="lblDiaChi" Runat="server" Width="100%" CssClass="QH_LabelDisplay"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD class="QH_ColLabel">Tình trạng hồ sơ:</TD>
					<TD></TD>
					<TD><asp:label id="lblTinhTrang" Runat="server" Width="100%" ForeColor="Red" Font-Italic="True"
							Font-Bold="True" Font-Names="Arial, Helvetica, sans-serif" Font-Size="11px"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6" height="10"></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="Label12" Runat="server" Width="100%" CssClass="QH_Label_Title">Quá trình giải quyết hồ sơ</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6" height="5"></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_DataGrid" CellPadding="3"
							AllowPaging="True" AllowSorting="True" PageSize="20">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6" height="5"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:imagebutton id="btnTroVe" Runat="server" CssClass="QH_Button" ImageUrl="../../Images/btn_TroVe.gif"></asp:imagebutton></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="10%"></TD>
	</TR>
</TABLE>
