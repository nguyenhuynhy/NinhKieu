<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachBaoCao.ascx.vb" Inherits="CPLDQH.DanhSachBaoCao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="MenuList" Src="../../DesktopModules/MenuList.ascx" %>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td width="*">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="left" width="150">
						<uc1:MenuList id="MenuList1" runat="server"></uc1:MenuList>
					</TD>
					<TD vAlign="top">
						<table width="100%">
							<tr>
								<td id="getUserControl" runat="Server"></td>
							</tr>
							<tr>
								<td align="right">
									<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In báo cáo</asp:linkbutton>&nbsp;
									<asp:TextBox id="txtMaLinhVuc" runat="server" Width="0px"></asp:TextBox>
									<asp:TextBox id="txtTabID" runat="server" Width="0px"></asp:TextBox>
									<asp:TextBox id="txtUserID" runat="server" Width="0px"></asp:TextBox>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</td>
	</tr>
</table>
