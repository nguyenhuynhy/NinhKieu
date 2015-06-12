<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CT_ThongKeChungThuc.ascx.vb" Inherits="THTT.CT_ThongKeChungThuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
	<TBODY>
		<TR>
			<TD colSpan="7" height="19"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Danh sách hồ sơ chứng thực</asp:label></TD>
		</TR>
		<TR>
			<TD colSpan="7" height="10"></TD>
		</TR>
		<TR>
			<TD width="15%"></TD>
			<TD class="QH_ColLabel" width="12%">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
			<TD width="22%" class="QH_ColControl"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="65%" Runat="server" MaxLength="10"></asp:textbox>
				&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
					<asp:image id="btnTuNgay" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
				</asp:hyperlink>
			</TD>
			<TD class="QH_ColLabel" width="12%">Ðến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
			<TD width="20%" class="QH_ColControl"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="65%" Runat="server" MaxLength="10"></asp:textbox>
				&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
					<asp:image id="btnDenNgay" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
				</asp:hyperlink>
			</TD>
			<TD align="right" width="15%"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Thực hiện</asp:linkbutton></TD>
			<TD width="10%"></TD>
		</TR>
		<TR>
			<TD colSpan="7" height="10"></TD>
		</TR>
		<tr>
			<TD colspan="7" align="center">
				<table width="95%">
					<tr>
						<td align="right"><asp:Label ID="Label4" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:Label>
				<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextBox" Width="25px"
					MaxLength="3"></asp:TextBox></td>
					</tr>
				</table>
			</TD>
		</tr>
		<TR>
			<TD align="center" colSpan="7"><asp:datagrid id="dgdDanhSach" CssClass="QH_Datagrid" Width="95%" Runat="server" AutoGenerateColumns="False"
					CellPadding="3" AllowPaging="True" AllowSorting="True">
					<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
					<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="STT">
							<ItemStyle Width="7%"></ItemStyle>
							<ItemTemplate>
								<asp:Label id="lblStt" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>">
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Việc chứng thực">
							<ItemStyle Width="30%"></ItemStyle>
							<ItemTemplate>
								<asp:label ID="lblTenLoaiHoSo" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"TenLoaiCT") %>' >
								</asp:label>
							</ItemTemplate>
							<FooterStyle CssClass="QH_LabelRightBold"></FooterStyle>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Số lượng">
							<ItemStyle Width="10%" CssClass="QH_LabelRight"></ItemStyle>
							<ItemTemplate>
								<asp:Hyperlink id="hplTonTruoc" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoLuong") %>' NavigateUrl='<%# GetMidURL("DocCode",DataBinder.Eval(Container.DataItem,"MaLoaiCT"),"CT_DSHOSO") %>'>
								</asp:Hyperlink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Số bản chứng">
							<ItemStyle Width="20%"></ItemStyle>
							<ItemTemplate>
								<asp:label ID="Label1" Runat="server" cssclass="QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"SoBC") %>' >
								</asp:label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></TD>
		<tr>
			<td align="center" colSpan="7">
				<asp:imagebutton id="btnTroVe" CssClass="QH_Button" ImageUrl="../../Images/btn_TroVe.gif" runat="server"
					Visible="False" DESIGNTIMEDRAGDROP="30"></asp:imagebutton>
				<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
			</td>
		</tr>
	</TBODY>
</TABLE>
</TR></TBODY></TABLE>
