<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TiepNhanHoSoList.ascx.vb" Inherits="CPXD.TiepNhanHoSoList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuu" Src="ThongTinTraCuu.ascx" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td align="center">
			<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="90%" border="0">
				<TR>
					<TD vAlign="top" width="100%">
						<table id="tblHeader" width="100%" Class="QH_LoaiHS" align="center" runat="server">
							<TR valign="middle">
								<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại hồ sơ tiếp nhận 
										&nbsp;</STRONG>
								</TD>
								<TD vAlign="middle" align="left" width="60%">
									<asp:DropDownList CssClass="QH_DropDownList" id="ddlLinhVuc" runat="server" Width="95%"></asp:DropDownList>
								</TD>
								<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1">
									<asp:imagebutton id="btnThucHien" runat="server" CssClass="QH_Button" ImageUrl="../../images/btn_Thuchien.gif"></asp:imagebutton></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<table width="100%">
							<tr>
								<td><asp:label id="lblHeader" runat="server" CssClass="QH_Label_Title" Width="100%"></asp:label></td>
							</tr>
							<tr>
								<td>
									<TABLE class="QH_Table" id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD height="10"></TD>
										</TR>
										<TR>
											<TD>
												<uc1:ThongTinTraCuu id="ThongTinTraCuu1" runat="server"></uc1:ThongTinTraCuu></TD>
										</TR>
										<TR>
											<TD height="5"></TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="right" width="65%"><asp:imagebutton id="btnTimKiem" runat="server" CssClass="QH_Button" ImageUrl="../../images/btn_Timkiem.gif"></asp:imagebutton><asp:imagebutton id="btnThemMoi" runat="server" CssClass="QH_Button" ImageUrl="../../images/btn_ThemMoi.gif"></asp:imagebutton>
														</TD>
														<TD align="right" width="*">
															<asp:Label ID="Label1" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:Label>
															<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextBox" Width="25px"
																MaxLength="2"></asp:TextBox>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD>
												<asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" autogeneratecolumns="False"
													AllowPaging="True" CellPadding="3">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</td>
	</tr>
</TABLE>
