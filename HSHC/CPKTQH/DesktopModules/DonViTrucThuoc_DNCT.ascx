<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DonViTrucThuoc_DNCT.ascx.vb" Inherits="CPKTQH.DonViTrucThuoc_DNCT" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="portal" Namespace="CPKTQH" Assembly="PortalQH" %>
<table class="QH_Table" id="table1" width="96%">
	<tr>
		<td width="134" class="QH_ColLabel">
			<asp:LinkButton id="btnSoGiayPhep" runat="server">Số GCN ĐKKD</asp:LinkButton></td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtSoGiayPhep" CssClass="QH_textbox" runat="server" Width="190px" EnableViewState="true"></asp:textbox></td>
		<td width="101" class="QH_ColLabel">
			Tình trạng</td>
		<td width="30%" QH_ColControl>
			<asp:dropdownlist id="ddlTinhTrang" EnableViewState="true" Width="191px" runat="server" CssClass="QH_DropDownList"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Ngày cấp</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtNgayCap" CssClass="QH_textbox" runat="server" Width="96px" EnableViewState="true"></asp:textbox>
			<asp:image id="imgNgayCap" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch" ImageAlign="Middle"
				ImageUrl="~\images\calendar.gif"></asp:image></td>
		<td width="101" class="QH_ColLabel">Loại doanh nghiệp</td>
		<td width="30%" QH_ColControl>
			<asp:dropdownlist id="ddlLoaiDoanhNghiep" EnableViewState="true" Width="191px" runat="server" CssClass="QH_DropDownList"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Nơi cấp</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtNoiCap" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
		<td width="101" class="QH_ColLabel">Tên doanh nghiệp</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtTenDoanhNghiep" CssClass="QH_textbox" runat="server" Width="190px" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Lĩnh vực cấp phép</td>
		<td width="30%" QH_ColControl>
			<asp:dropdownlist id="ddlLinhVuc" EnableViewState="true" Width="191px" runat="server" CssClass="QH_DropDownList"></asp:dropdownlist></td>
		<td width="101" class="QH_ColLabel">Trụ sở</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtTruSo" CssClass="QH_textbox" runat="server" Width="190px" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Ngành nghề kinh doanh</td>
		<td width="30%" QH_ColControl>
			<asp:dropdownlist id="ddlNganhNghe" EnableViewState="true" Width="191px" runat="server" CssClass="QH_DropDownList"
				DESIGNTIMEDRAGDROP="61"></asp:dropdownlist></td>
		<td width="105" class="QH_ColLabel">Thông tin liên lạc</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtThongTinLienLac" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
	</tr>
	<tr>
		<td width="20%" class="QH_ColLabel">Mặt hàng kinh doanh</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtMatHang" CssClass="QH_textbox" runat="server" Width="190px" EnableViewState="true"></asp:textbox></td>
		<td width="105" class="QH_ColLabel">Vốn kinh doanh</td>
		<td width="30%" QH_ColControl>
			<asp:textbox id="txtVon" EnableViewState="true" Width="190px" runat="server" CssClass="QH_textbox"></asp:textbox></td>
	</tr>
</table>
