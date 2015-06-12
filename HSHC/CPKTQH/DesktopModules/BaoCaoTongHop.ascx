<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BaoCaoTongHop.ascx.vb" Inherits="CPKTQH.BaoCaoTongHop" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">


function GetParamReport(str)
{		
		var lst,txt;
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			if (obj.id.indexOf('lstReports') != -1 && obj.checked == true)
			{					
				lst = obj;
			}
			if (obj.id.indexOf('txtLoai') != -1)
			{
				txt = obj;
			}
		}
		txt.value = lst.value;
		
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			if (str.indexOf(obj.id) != -1 && obj.id!='')
			{					
				//str=str.replace(obj.id,'N' + obj.value);
				str=str.replace(obj.id,'N[' + obj.value);
			}
		}
		while (str.indexOf('"')!=-1)
		{
			str=str.replace('"',"'");
			//str=str.replace("'N","N'");
			str=str.replace("'N[","N'");
		}
		return str;
}			
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server"></asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<br>
							<TR>
								<TD vAlign="top" width="100%">
									<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="90%" align="center"
										border="0">
										<TR>
											<TD class="QH_ColLabel" width="10%" height="31"><asp:label id="lblMaNganhKinhDoanh" runat="server">Ngành nghề</asp:label></TD>
											<TD class="QH_ColControl" width="25%" height="31"><asp:dropdownlist id="ddlMaNganhKinhDoanh" Width="80%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist><asp:dropdownlist id="ddlMaPhuongThucKinhDoanh" Width="80%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="10%" height="31"><asp:label id="lblGioiTinh" runat="server">Giới tính</asp:label></TD>
											<TD class="QH_ColControl" width="25%" height="31"><asp:dropdownlist id="ddlGioiTinh" Width="20%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblMaPhuong" runat="server">Phường</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:dropdownlist id="ddlMaPhuong" Width="55%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblMaDuong" runat="server">Đường</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:dropdownlist id="ddlMaDuong" Width="55%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblMatHangKinhDoanh" runat="server">Mặt hàng KD</asp:label></TD>
											<TD class="QH_ColControl" colspan="3" width="75%"><asp:textbox id="txtMatHangKinhDoanh" Runat="server" CssClass="QH_TextBox" Width="80%" TextMode="MultiLine"></asp:textbox></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblTuNgay" runat="server">Từ ngày</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:textbox id="txtMaNguoiTacNghiep" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox><asp:textbox id="txtTuNgay" Width="35%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
													<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblDenNgay" runat="server">Đến ngày</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:textbox id="txtDenNgay" Width="35%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
													<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblVonKinhDoanh" runat="server">Vốn Kinh Doanh Từ</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:textbox id="txtVonTu" Width="40%" CssClass="QH_TextBox" Runat="server"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblVonDen" runat="server">Đến</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:textbox id="txtVonDen" Width="40%" CssClass="QH_TextBox" Runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblThang" runat="server">Tháng báo cáo</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:dropdownlist id="ddlThang" Width="40%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist><asp:dropdownlist id="ddlNam" Width="40%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="10%"></TD>
											<TD class="QH_ColControl" width="25%"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="10%"><asp:label id="lblNguoiKy" runat="server">Người ký</asp:label></TD>
											<TD class="QH_ColControl" width="25%"><asp:dropdownlist id="ddlMaNguoiKy" Width="80%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="10%"></TD>
											<TD class="QH_ColControl" width="25%"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<td height="10"></td>
							</TR>
							<tr>
								<TD vAlign="top" align="center"><asp:radiobuttonlist class="QH_LoaiHS" id="lstReports" runat="server" AutoPostBack="True" RepeatColumns="3"></asp:radiobuttonlist></TD>
							</tr>
							<TR>
								<TD colSpan="2">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
										<tr>
											<td align="right" height="20"><asp:linkbutton id="LinkButton1" CssClass="QH_Button" runat="server">Mở file Excel ...</asp:linkbutton></td>
										</tr>
										<TR>
											<TD align="center" width="50%" height="24"><asp:linkbutton id="btnExport" CssClass="QH_Button" runat="server">Xuất ra Excel</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="5" height="10"><asp:textbox id="txtLoai" Width="0px" CssClass="QH_textbox" runat="server"></asp:textbox></TD>
							</TR>
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
