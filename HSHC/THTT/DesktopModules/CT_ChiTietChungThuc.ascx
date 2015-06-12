<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CT_ChiTietChungThuc.ascx.vb" Inherits="THTT.CT_ChiTietChungThuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE align="center" class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%"
	border="0">
	<TR>
		<TD colspan="3"><asp:label id="Label1" Runat="server" Width="100%" CssClass="QH_Label_Title">Thông tin chi tiết hồ sơ chứng thực</asp:label></TD>
	</TR>
	<TR>
		<TD height="10"></TD>
	</TR>
	<tr>
		<td width="100%" bgColor="#b6cbeb" colSpan="3">&nbsp; Số chứng thực:
			<asp:label cssclass="QH_LabelLeft" id="lblSoChungThuc" runat="server" ForeColor="Navy" Font-Bold="True"></asp:label></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Loại chứng thực:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblTenLoaiCT" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Ngày chứng thực:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblNgayGD" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td noWrap width="10%" colSpan="1" rowSpan="1"></td>
		<td width="25%" class="QH_ColLabel">Quyển số:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblQuyenSo" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Nội dung chứng thực:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblViecChungThuc" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Số bản chính:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblSoBC" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Số tờ:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblSoTo" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Số trang:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblSoTrang" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Người ký:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblTenNGuoiKy" runat="server"></asp:label>&nbsp;</td>
	</tr>
	<tr>
		<td width="10%"></td>
		<td width="25%" class="QH_ColLabel">Ghi chú:&nbsp;</td>
		<td><asp:label cssclass="QH_LabelLeft" ForeColor="#0000C0" id="lblGhiChu" runat="server"></asp:label></td>
	</tr>
	<TR>
		<TD width="10%" colSpan="3">&nbsp;</TD>
	</TR>
	<TR>
		<TD width="10%" colSpan="3" align="center">
			<asp:datagrid ID="datagrid1" CssClass="QH_Datagrid" Width="100%" Runat="server" ShowHeader="True"
				AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" AllowSorting="True">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
					BackColor="#5486DD"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="DOITUONG" HeaderText="Đối tượng"></asp:BoundColumn>
					<asp:BoundColumn DataField="HOTEN" HeaderText="Họ tên"></asp:BoundColumn>
					<asp:BoundColumn DataField="DIACHI" HeaderText="Địa chỉ"></asp:BoundColumn>
					<asp:BoundColumn DataField="CMND" HeaderText="Số CMND"></asp:BoundColumn>
					<asp:BoundColumn DataField="NGAYCAP" HeaderText="Ngày cấp"></asp:BoundColumn>
					<asp:BoundColumn DataField="NOICAP" HeaderText="Nơi cấp"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
	<tr>
		<td align="center" colspan="6"><asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></td>
		</TD></tr>
</TABLE>
</TR></TABLE>
