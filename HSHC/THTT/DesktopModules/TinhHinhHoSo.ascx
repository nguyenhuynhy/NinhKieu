<%@ Register TagPrefix="uc2" TagName="MenuList" Src="MenuList.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TinhHinhHoSo.ascx.vb" Inherits="THTT.TinhHinhHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="TinhHinhHoSo_ChucNang" Src="TinhHinhHoSo_ChucNang.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuList" Src="../DesktopModules/MenuList.ascx" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD vAlign="top" align="left" width="150">
			<uc2:MenuList id="MenuList1" runat="server"></uc2:MenuList>
		</TD>
		<TD width="2"></TD>
		<TD vAlign="top" width="*">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<TR>
					<TD vAlign="top" width="100%">
						<uc1:TinhHinhHoSo_ChucNang id="TinhHinhHoSo_ChucNang1" runat="server"></uc1:TinhHinhHoSo_ChucNang></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<table width="100%" cellSpacing="0" cellPadding="0">
							<tr>
								<td vAlign="top" width="100%" id="getUserControl" runat="Server"></td>
							</tr>
						</table>
					</TD>
				</TR>
			</table>
		</TD>
	</TR>
</TABLE>
