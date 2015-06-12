<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DonViTrucThuoc_DVTT.ascx.vb" Inherits="CPKTQH.DonViTrucThuoc_DVTT" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="portal" Namespace="CPKTQH" Assembly="PortalQH" %>
<table class="QH_Table" id="table1" width="96%">
	<tr>
		<td class="QH_ColLabel" width="20%">
			Loại đơn vị</td>
		<td width="30%" QH_ColControl>
			<asp:dropdownlist id="ddlLoaiDonVi" CssClass="QH_DropDownList" runat="server" Width="191px" EnableViewState="true"></asp:dropdownlist></td>
		<td class="QH_ColLabel" width="20%">
			Cửa hàng</td>
		<td width="30%" QH_ColControl><asp:textbox id="txtCuaHang" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" width="20%">Người quản lý</td>
		<td width="30%" QH_ColControl><asp:textbox id="txtNguoiQuanLy" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
		<td class="QH_ColLabel" width="20%">Số nhà&nbsp;</td>
		<td width="30%" QH_ColControl><asp:textbox id="txtSoNha" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" width="20%">Số quyết định</td>
		<td width="30%" QH_ColControl><asp:textbox id="txtSoQuyetDinh" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
		<td class="QH_ColLabel" width="20%">
			Đường</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtDuong" CssClass="QH_textbox" runat="server" Width="190px" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Ngày quyết định</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtNgayQuyetDinh" CssClass="QH_textbox" runat="server" Width="96px" EnableViewState="true"></asp:textbox>
			<asp:image id="imgNgayQuyetDinh" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch"
				ImageAlign="Middle" ImageUrl="~\images\calendar.gif"></asp:image></td>
		<td width="20%" class="QH_ColLabel">
			Phường</td>
		<td width="30%" QH_ColControl>
			<asp:dropdownlist id="ddlPhuong" CssClass="QH_DropDownList" runat="server" Width="191px" EnableViewState="true"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Nơi ra quyết định</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtNoiRaQuyetDinh" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
		<td width="20%" class="QH_ColLabel">Thông tin liên lạc</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtThongTinLienLac" CssClass="QH_textbox" runat="server" Width="190px" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Tình trạng</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="Textbox2" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
		<td width="20%" class="QH_ColLabel">
			Ngành kinh doanh</td>
		<td width="30%" QH_ColControl>
			<asp:dropdownlist id="ddlNganh" CssClass="QH_DropDownList" runat="server" Width="191px" EnableViewState="true"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Ghi chú</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtGhiChu" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
		<td width="20%" class="QH_ColLabel">Mặt hàng kinh doanh</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtMatHang" CssClass="QH_textbox" runat="server" Width="190px" EnableViewState="true"></asp:textbox></td>
	</tr>
</table>
