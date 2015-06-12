<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TinhHinhHoSo_HoSo.ascx.vb" Inherits="THTT.TinhHinhHoSo_HoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD colspan="3" width="100%"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Tình hình giải quyết hồ sơ hành chính</asp:label></TD>
	</TR>
	<TR>
		<TD colspan="3" height="15"></TD>
	</TR>
	<TR>
		<td width="20%"></td>
		<TD width="*">
			<TABLE id="Table2" class="QH_Menu" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colspan="3" height="5"></TD>
				</TR>
				<!--<TR>
					<TD width="35%"><asp:label id="Label1" CssClass="QH_Labelright" Width="100%" Runat="server">Linh v?c ti?p nh?n</asp:label></TD>
					<TD width="5%" class="QH_ColLabelLeft">:</TD>
					<TD width="*"><asp:label id="lblLinhVuc" CssClass="QH_LabelDisplay" Width="100%" Runat="server"></asp:label></TD>
				</TR>-->
				<TR>
					<TD colspan="3" height="5"></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label2" CssClass="QH_Labelright" Width="100%" Runat="server">Loại hồ sơ</asp:label></TD>
					<TD class="QH_ColLabelLeft">:</TD>
					<TD><asp:label id="lblLoaiHoSo" CssClass="QH_LabelDisplay" Width="100%" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colspan="3" height="5"></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label3" CssClass="QH_Labelright" Width="100%" Runat="server">Thời gian tiếp nhận</asp:label></TD>
					<TD class="QH_ColLabelLeft">:</TD>
					<TD><asp:label id="lblThoiGian" CssClass="QH_LabelDisplay" Width="100%" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colspan="3" height="5"></TD>
				</TR>
			</TABLE>
		</TD>
		<td width="20%"></td>
	</TR>
	<TR>
		<TD height="15" colspan="3"></TD>
	</TR>
	<TR>
		<TD colspan="3"><asp:label id="lblLoai" CssClass="QH_LabelMiddleBold" Width="100%" Runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD colSpan="3" align="right">
			<asp:Label ID="Label4" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:Label>
			<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextBox" Width="25px"
				MaxLength="3"></asp:TextBox>
		</TD>
	</TR>
	<TR>
		<TD colspan="3" width="100%">
			<asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" autogeneratecolumns="False"
				Runat="server" AllowSorting="True" AllowPaging="True" CellPadding="3">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</TR>
	<TR>
		<TD colspan="3" height="5"></TD>
	</TR>
	<TR>
		<TD colspan="3" align="center">
			<asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_TroVe.gif" CssClass="QH_Button"></asp:ImageButton>
			<asp:ImageButton id="btnIn" CssClass="QH_Button" ImageUrl="../../Images/btn_In.gif" runat="server"
				Visible="True"></asp:ImageButton>
		</TD>
	</TR>
</TABLE>
