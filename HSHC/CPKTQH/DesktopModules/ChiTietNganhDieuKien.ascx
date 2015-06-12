<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChiTietNganhDieuKien.ascx.vb" Inherits="CPKTQH.ChiTietNganhDieuKien" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">Thông tin chi tiết ngành kinh doanh có điều kiện</asp:label></td>
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
					<td align="center" width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" border="0">
							<TR>
								<TD width="*">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<br>
										<TR>
											<td width="10%"></td>
											<TD class="QH_ColLabel" width="20%">Ngành cấp trên <FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlNganhCapTren" Width="100%" CssClass="QH_TextBox" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD width="10%"></TD>
										</TR>
										<TR>
											<td></td>
											<TD class="QH_ColLabel">Ngành kinh doanh <FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaNganh" Width="100%" CssClass="QH_TextBox" Runat="server"></asp:dropdownlist></TD>
											<TD></TD>
										</TR>
										<TR>
											<td></td>
											<TD class="QH_ColLabel">Điều kiện kinh doanh <FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNoiDung" Width="100%" CssClass="QH_textbox" Runat="server" Rows="5" TextMode="MultiLine"></asp:textbox></TD>
											<TD></TD>
										</TR>
										<TR>
											<td></td>
											<TD class="QH_ColLabel">Vốn tối thiểu</TD>
											<TD class="QH_ColControl"><asp:checkbox id="chkCoVonToiThieu" Runat="server"></asp:checkbox>&nbsp;<asp:textbox id="txtSoVonToiThieu" Width="30%" CssClass="QH_textRight" Runat="server"></asp:textbox></TD>
											<TD></TD>
										</TR>
										<TR>
											<td></td>
											<TD class="QH_ColLabel">Cần chứng chỉ kèm theo</TD>
											<TD class="QH_ColControl"><asp:checkbox id="chkCoChungChi" Runat="server"></asp:checkbox></TD>
											<TD></TD>
										</TR>
										<tr>
											<td></td>
											<TD class="QH_ColLabel">Danh sách chứng chỉ</TD>
											<TD class="QH_ColControl"><asp:checkboxlist id="cblChungChi" runat="server"></asp:checkboxlist></TD>
											<td></td>
										</tr>
										<TR>
											<TD colSpan="4" height="5"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button" Visible="False">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
							</TR>
							<tr>
								<td colSpan="4">
									<div style="DISPLAY: none"><asp:textbox id="txtNganhDieuKienID" Runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtUserUpdate" Runat="server" Enabled="False"></asp:textbox></div>
								</td>
							</tr>
						</TABLE>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
