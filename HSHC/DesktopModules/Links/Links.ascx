<%@ Control language="vb" Inherits="PortalQH.Links" CodeBehind="Links.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<asp:panel id="pnlList" Visible="False" Runat="server" Width="158px">
	<TABLE cellSpacing="0" cellPadding="0" width="158" border="0">
		<TR>
			<TD class="QH_MenuRight_Header"></TD>
		</TR>
		<TR>
			<TD class="QH_MenuRight_Middle" align="center">
				<asp:DataList id="lstLinks" Width="94%" runat="server" CellPadding="0" ItemStyle-VerticalAlign="Top"
					summary="Links Design Table">
					<ItemTemplate>
						<table border="0" cellspacing="0" cellPadding="1" width="100%">
							<tr>
								<td width="100%">
									<table border="0" width="100%" cellpadding="0" cellspacing="0">
										<tr>
											<td width="100%" runat="server" id="tdnoidung">
												<asp:HyperLink CssClass="QH_MenuRight_Item" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' NavigateUrl='<%# FormatURL(DataBinder.Eval(Container.DataItem,"Url"),DataBinder.Eval(Container.DataItem,"ItemID")) %>' ToolTip='<%# DisplayToolTip(DataBinder.Eval(Container.DataItem,"Description")) %>' Target= '<%# IIF(DataBinder.Eval(Container.DataItem,"NewWindow"),"_blank","_self") %>' runat="server" ID="Hyperlink1"/>
												<asp:linkbutton CssClass="CommandButton" Runat="server" Width="100%" Text='' CommandName="Select" Visible='<%# DisplayInfo() %>' ID="Linkbutton1" />
											</td>
											<td width="5%" runat="server" id="tdedit" visible="true">
												<asp:HyperLink Width="5%" id="editLink" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' Visible="<%# IsEditable %>" runat="server" >
													<asp:Image id="editLinkImage" ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%# IsEditable %>" Runat="server" />
												</asp:HyperLink>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Panel id="pnlDescription" visible="false" runat="server">
										<asp:Label runat="server" Width="100%" CssClass="Normal" Text='<%# HtmlDecode(DataBinder.Eval(Container.DataItem, "Description")) %>' ID="Label1"/>
									</asp:Panel>
								</td>
							</tr>
						</table>
					</ItemTemplate>
				</asp:DataList></TD>
		</TR>
		<TR>
			<TD class="QH_MenuRight_Footer" height="25"></TD>
		</TR>
	</TABLE>
</asp:panel><asp:panel id="pnlDropdown" Visible="False" Runat="server" Width="158px">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD class="QH_MenuRight_Header"></TD>
		</TR>
		<TR>
			<TD class="QH_MenuRight_Middle">
				<TABLE cellSpacing="0" cellPadding="0" summary="Links Design Table" border="0">
					<TR>
						<TD class="QH_MenuRight_Middle" align="center">&nbsp;
							<asp:ImageButton id="cmdEdit" Runat="server" AlternateText="Edit" ImageUrl="~/images/edit.gif"></asp:ImageButton><LABEL 
            style="DISPLAY: none" for="<%=cboLinks.ClientID%>"></LABEL>
							<asp:DropDownList id="cboLinks" Runat="server" CssClass="QH_DropdownList" DataValueField="ItemID"
								DataTextField="Title"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:LinkButton id="cmdGo" Runat="server" CssClass="CommandButton" Text="<< Go >>"></asp:LinkButton>
							<asp:LinkButton id="cmdInfo" Runat="server" CssClass="CommandButton" Text=""></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblDescription" Runat="server" CssClass="Normal"></asp:Label></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD class="QH_MenuRight_Footer" height="25"></TD>
		</TR>
	</TABLE>
</asp:panel>
