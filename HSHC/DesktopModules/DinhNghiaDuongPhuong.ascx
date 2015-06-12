<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DinhNghiaDuongPhuong.ascx.vb" Inherits="PortalQH.DinhNghiaDuongPhuong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td align="center"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server">.: Định nghĩa tuyến đường thuộc phường :.</asp:label></td>
	</tr>
	<TR>
		<TD>
			<TABLE class="QH_Table" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD vAlign="top" width="10%" height="18"><asp:label id="Label2" CssClass="QH_LabelLeftBold" Runat="server">Phường</asp:label></TD>
					<td vAlign="top" colSpan="3" height="18"><asp:dropdownlist id="ddlMaPhuong" runat="server" AutoPostBack="True" Width="50%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
				</tr>
				<tr>
					<TD vAlign="top"><asp:label id="Label4" CssClass="QH_LabelLeftBold" Runat="server">Đường</asp:label></TD>
					<td vAlign="top" colSpan="3"><asp:checkboxlist id="lstDuong" Width="90%" CssClass="QH_LoaiHS" Runat="server" RepeatLayout="Table"
							RepeatColumns="2" RepeatDirection="Vertical"></asp:checkboxlist></td>
				</tr>
				<tr>
					<TD vAlign="top" align="center" colSpan="4"><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton></TD>
				</tr>
			</TABLE>
		</TD>
	</TR>
</TABLE>
