<%@ Control Language="vb" AutoEventWireup="false" Codebehind="WebLanhDao.ascx.vb" Inherits=".WebLanhDao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%'@ Imports System.Configuration%>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<!--Menu Left-->
		<TD vAlign="top" align="left" width="150">
			<!--Tin tuc-->
			<TABLE id="Table0" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_MenuLeft_Header">Bản tin nội bộ</TD>
				</TR>
				<TR>
					<TD class="QH_MenuLeft_Middle" align="center">
						<TABLE height="100%" cellSpacing="0" cellPadding="0" width="158" border="0">
							<TR>
								<TD class="QH_MenuLeft_Image"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="QH_MenuLeft_Middle"><asp:datalist id="DltTinTuc" runat="server" EnableViewState="False" Width="94%">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:HyperLink id="Hyperlink10" CssClass="QH_MenuLeft_Item" Width="100%" runat="server" Text='' NavigateUrl='<%# GetLink() & "&SelectIndex=" & Cstr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma") & "&Cat=TT" %>'>
									<asp:Label CssClass="QH_MenuLeft_ItemText" Runat="server" Width="100%" ID="Label1">
										<%# DataBinder.Eval(Container.DataItem, "TenTT") %>
									</asp:Label>
								</asp:HyperLink>
							</ItemTemplate>
							<SelectedItemStyle CssClass="QH_MenuLeft_Item_Selected"></SelectedItemStyle>
							<SeparatorStyle CssClass="QH_MenuSeparator"></SeparatorStyle>
						</asp:datalist></TD>
				</TR>
				<TR>
					<TD class="QH_MenuLeft_Footer" height="25"></TD>
				</TR>
			</TABLE>
			<!--Tin tuc-->
			<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="158" border="0">
				<TR>
					<TD class="QH_MenuLeft_Header">Tìm tin</TD>
				</TR>
				<TR>
					<TD class="QH_MenuLeft_Middle" align="center"><asp:textbox id="txtNoiDungTim" runat="server" Width="70%" MaxLength="100" CssClass="QH_Textbox"
							Rows="1"></asp:textbox>&nbsp;
						<asp:imagebutton id="btnTimNoiDung" runat="server" CssClass="QH_ImageButton" ImageUrl="~/images/search.gif"
							AlternateText="Tìm nội dung tin tức" max></asp:imagebutton></TD>
				</TR>
				<TR>
					<TD class="QH_MenuLeft_Footer" height="25"></TD>
				</TR>
			</TABLE>
			<!--Lich cong tac trong ngay-->
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="158">
				<TR>
					<TD class="QH_MenuLeft_Header">Lịch trong ngày</TD>
				</TR>
				<TR>
					<TD class="QH_MenuLeft_Middle" align="center">
						<asp:datalist id="DltLich" runat="server" EnableViewState="False" Width="100%">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<SelectedItemStyle CssClass="QH_MenuLeft_Item_Selected"></SelectedItemStyle>
							<SeparatorStyle CssClass="QH_MenuSeparator"></SeparatorStyle>
							<ItemTemplate>
								<asp:HyperLink CssClass="QH_MenuLeft_Item" id="Hyperlink6" runat="server" Text='' NavigateUrl='<%# GetLink() & "&SelectIndex=" & Cstr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma") & "&Cat=LCT" %>'>
									<asp:Label CssClass="QH_MenuLeft_ItemText" Runat="server" Width="100%" ID="Label2">
										<%# DataBinder.Eval(Container.DataItem, "TenL") %>
									</asp:Label>
								</asp:HyperLink>
							</ItemTemplate>
						</asp:datalist></TD>
				</TR>
				<TR>
					<TD class="QH_MenuLeft_Footer" height="25"></TD>
				</TR>
			</TABLE>
		</TD>
		<!--Khoang cach giua-->
		<TD width="3"></TD>
		<TD vAlign="top" align="left">
			<table id="tblNews" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<!--Khung tin tuc-->
				<!--Header-->
				<tr>
					<td align="left" width="100%" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Content_TopLeft" width="9" height="25"></td>
								<td class="QH_Content_TopMid" align="center" width="*" height="25"><asp:label id="lblTitle" runat="server" CssClass="QH_Content_Header_Middle">Lịch trong ngày</asp:label></td>
								<td class="QH_Content_TopRight" width="8" height="25"></td>
							</tr>
						</table>
					</td>
				</tr>
				<!--Content-->
				<tr>
					<td align="left" width="100%" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Content_Left" width="9">&nbsp;</td>
								<td id="tdControl" vAlign="top" align="left" width="*" runat="server">&nbsp;</td>
								<td class="QH_Content_Right" width="8">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<!--Footer-->
				<tr>
					<td width="100%" colSpan="3" height="12">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Content_BottomLeft" width="9" height="100%"></td>
								<td class="QH_Content_BottomMid" width="*" height="100%">&nbsp;
								</td>
								<td class="QH_Content_BottomRight" width="8" height="100%"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
