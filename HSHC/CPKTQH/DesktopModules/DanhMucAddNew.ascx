<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhMucAddNew.ascx.vb" Inherits="PortalQH.DanhMucAddNew" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE class="QH_table" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
	align="center" bgColor="white" border="0">
	<TR vAlign="top">
		<td><asp:panel id="Panel" runat="server" Height="688px" Width="696px">
				<asp:DataGrid id="grdList" runat="server" AllowPaging="True">
					<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<asp:ImageButton id="btnUpdate" runat="server" Text="Update" CssClass="QH_Button"></asp:ImageButton>
				<asp:imageButton id="btnCancel" runat="server" Text="Cancel" CssClass="QH_Button"></asp:imageButton>
				<asp:imageButton id="btnDelete" runat="server" Text="Delete" CssClass="QH_Button"></asp:imageButton>
			</asp:panel></td>
		<td></td>
	</TR>
</TABLE>
