<%@ Control Language="vb" AutoEventWireup="false" Codebehind="PhuongThucNganhNghe.ascx.vb" Inherits="CPKTQH.PhuongThucNganhNghe" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td align="center"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server">.: Định nghĩa ngành nghề của phương thức kinh doanh :.</asp:label></td>
	</tr>
	<TR>
		<TD>
			<TABLE class="QH_Table" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD vAlign="top" width="10%"><asp:label id="Label2" CssClass="QH_LabelLeftBold" Runat="server">Phương thức KD</asp:label></TD>
					<td vAlign="top" width="*"><asp:dropdownlist id="ddlMaPhuongThucKinhDoanh" runat="server" AutoPostBack="True" Width="50%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
				</tr>
				<tr>
					<TD vAlign="top" width=10%><asp:label id="Label4" CssClass="QH_LabelLeftBold" Runat="server">Ngành nghề KD</asp:label></TD>
					<td vAlign="top" width="*"><asp:checkboxlist id="lstNganhNgheKinhDoanh" Width="800" CssClass="QH_LoaiHS" Runat="server" RepeatLayout="Table"
							RepeatColumns="2" RepeatDirection="Vertical"></asp:checkboxlist></td>
				</tr>
				<tr>
					<TD vAlign="top" align="center" colSpan="4"><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton></TD>
				</tr>
			</TABLE>
		</TD>
	</TR>
</TABLE>
