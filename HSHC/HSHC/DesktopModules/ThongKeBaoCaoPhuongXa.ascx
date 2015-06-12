<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeBaoCaoPhuongXa.ascx.vb" Inherits="HSHC.ThongKeBaoCaoPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="MenuList" Src="../../DesktopModules/MenuList.ascx" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" Width="100%" CssClass="QH_Label_Title" runat="server"></asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" align="left" width="150"><uc1:menulist id="MenuList1" runat="server"></uc1:menulist></TD>
								<TD vAlign="top" align="left" width="*">
									<table width="100%">
										<TR>
											<TD>
												<TABLE class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="25%" height="50"><STRONG>Lĩnh vực tiếp 
																nhận&nbsp;&nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="35%"><asp:dropdownlist id="ddlLinhVuc" Width="200px" runat="server" AutoPostBack="True" Height="23px"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="left" width="5%">
															<asp:Label id="lblPhuong" runat="server" Font-Bold="True">Phường</asp:Label></TD>
														<TD vAlign="middle" align="left" width="25%">
															<asp:dropdownlist style="Z-INDEX: 0" id="ddlMaPhuong" runat="server" Width="192px" AutoPostBack="True"
																Height="23px"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td id="getUserControl" runat="Server"></td>
										</tr>
										<tr>
											<td align="right">&nbsp;<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In báo cáo</asp:linkbutton>&nbsp;
												<asp:textbox id="txtMaLinhVuc" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtTabID" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtUserID" Width="0px" runat="server"></asp:textbox></td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
						<asp:TextBox style="Z-INDEX: 0" id="txtUserName" runat="server" Width="0px" Height="0px"></asp:TextBox>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1">
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
