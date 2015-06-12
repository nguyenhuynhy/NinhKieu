<%@ Control Language="vb" AutoEventWireup="false" Codebehind="QLHT_DanhSachHoSo.ascx.vb" Inherits="THTT.QLHT_DanhSachHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD colSpan="3">
			<asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server"> Danh sách hồ sơ</asp:label></TD>
	</TR>
	<TR>
		<TD colSpan="3" height="15"></TD>
	</TR>
	<TR>
		<TD width="20%"></TD>
		<TD width="*">
			<TABLE id="Table2" class="QH_menu" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD width="25%">
						<asp:label id="Label1" CssClass="QH_Labelright" Width="100%" Runat="server">Khu vực</asp:label></TD>
					<TD class="QH_ColLabelLeft" width="5%">:</TD>
					<TD width="*">
						<asp:label id="lblLinhVuc" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label2" CssClass="QH_Labelright" Width="100%" Runat="server">Loạii hồ sơ</asp:label></TD>
					<TD class="QH_ColLabelLeft">:</TD>
					<TD>
						<asp:label id="lblLoai" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label3" CssClass="QH_Labelright" Width="100%" Runat="server">Thời gian đăng ký</asp:label></TD>
					<TD class="QH_ColLabelLeft">:</TD>
					<TD>
						<asp:label id="lblThoiGian" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="20%"></TD>
	</TR>
	<TR>
		<TD height="15"></TD>
	</TR>
	<TR>
		<TD colSpan="3"></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="3">
			<asp:Label id="Label4" CssClass="QH_Label" Runat="server">Số dòng hiển thị</asp:Label>
			<asp:TextBox id="txtSoDong" CssClass="QH_TextBox" Width="25px" Runat="server" AutoPostBack="True"
				MaxLength="2"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD colSpan="3">
			<asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" autogeneratecolumns="False"
				AllowSorting="True" AllowPaging="True" CellPadding="3">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
					BackColor="#5486DD"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
	<TR>
		<TD colSpan="3" height="5"></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="3">
			<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
			<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
		</TD>
	</TR>
</TABLE>
