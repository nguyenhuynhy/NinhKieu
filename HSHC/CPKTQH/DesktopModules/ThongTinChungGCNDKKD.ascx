<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinChungGCNDKKD.ascx.vb" Inherits="CPKTQH.ThongTinChungGCNDKKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE class="QH_LoaiHS" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD colSpan="6"><asp:label id="Label6" CssClass="QH_LabelLeftBold" Runat="server"><strong>Thông 
					tin chung</strong></asp:label></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="20%">Ngày cấp CN ĐKKD:</TD>
		<TD class="QH_ColControl" width="30%"><asp:label id="lblNgayCap" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
		<TD class="QH_ColLabel" width="20%">Mặt hàng KD:</TD>
		<TD class="QH_ColControl" colSpan="3" width="200"><asp:label id="lblMatHangKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="20%">Ngày hết hạn:</TD>
		<TD class="QH_ColControl" width="30%"><asp:label id="lblNgayHetHan" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
		<TD class="QH_ColLabel" width="20%">Tên bảng hiệu:</TD>
		<TD class="QH_ColControl" width="30%" colSpan="3"><asp:label id="lblBangHieu" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Địa chỉ KD:</TD>
		<TD class="QH_ColControl" width="200"><asp:label id="lblDiaChiKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
		<TD class="QH_ColLabel">Tổng vốn KD:</TD>
		<TD class="QH_ColControl" colSpan="3"><asp:label id="lblVonKinhDoanh" CssClass="QH_LabelLeft" Runat="server"></asp:label>&nbsp;
			<asp:label id="lblLabelDonViTinh" Runat="server" CssClass="QH_LabelLeft"></asp:label></TD>
	</TR>
	<TR>
		<TD class="QH_ColControl" colSpan="6"><asp:label id="Label7" CssClass="QH_LabelLeftBold" Runat="server"><strong>Thông 
					tin cá nhân</strong></asp:label></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Họ tên:</TD>
		<TD class="QH_ColControl" width="200"><asp:label id="lblHoTen" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
		<TD class="QH_ColLabel">Ngày sinh:</TD>
		<TD class="QH_ColControl" width="15%"><asp:label id="lblNgaySinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
		<TD class="QH_ColLabel" width="10%">Giới tính:</TD>
		<TD class="QH_ColControl" width="*"><asp:label id="lblTenGioiTinh" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Địa chỉ thường trú:</TD>
		<TD class="QH_ColControl" width="200"><asp:label id="lblDiaChiThuongTru" Width="100%" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
		<TD class="QH_ColLabel">Số CMND:</TD>
		<TD class="QH_ColControl" colSpan="3"><asp:label id="lblSoCMND" CssClass="QH_LabelLeft" Runat="server"></asp:label></TD>
	</TR>
</TABLE>
