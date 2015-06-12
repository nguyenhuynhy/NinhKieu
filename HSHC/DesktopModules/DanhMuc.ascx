<%@ Register TagPrefix="uc1" TagName="MenuList" Src="MenuList.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhMuc.ascx.vb" Inherits="PortalQH.DanhMuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD vAlign="top" width="158"><uc1:menulist id="MenuList1" runat="server"></uc1:menulist></TD>
		<TD>
			<TABLE id="Table0" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<!--<TR>
					<TD vAlign="top" colSpan="2"><asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Label_Title"></asp:label></TD>
				</TR>-->
				<TR vAlign="top">
					<TD vAlign="top">
						<TABLE class="QH_ControlDanhMuc" id="Table2" cellSpacing="0" cellPadding="0" width="90%"
							align="center" runat="server">
						</TABLE>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="600" align="center" runat="server">
							<TR vAlign="middle">
								<TD align="center" width="60%" colSpan="2"><asp:linkbutton id="btnSearch" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton><asp:linkbutton id="btnUpdate" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton><asp:linkbutton id="btnCancel" runat="server" CssClass="QH_Button">Bỏ qua</asp:linkbutton></TD>
							</TR>
							<TR>
								<td width="50"></td>
								<TD align="right" width="50%"><asp:label id="lblSoDong" cssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Runat="server" Width="50px" MaxLength="3"
										AutoPostBack="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				<TR>
					<TD align="center"><asp:datagrid id="grdList" runat="server" CssClass="QH_DataGrid" Width="600" AllowPaging="True"
							CellPadding="0" AllowSorting="True">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
