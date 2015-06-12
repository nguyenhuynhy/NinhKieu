<%@ Control Language="vb" AutoEventWireup="false" Codebehind="YeuCauBSHS.ascx.vb" Inherits="HSHC.YeuCauBSHS" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
</SCRIPT>
<script language="javascript">
function CheckSoNgay(obj) {	
	var so;
	so=(obj.value);
	if(so=='')
	{
		return false;			
	}
	
	if (isNaN(so)){   
		alert('So ngay bo sung ho so khong hop le!'); 
		obj.focus();	
		return false;
	}	
	else
	{
		return true;
	}
}	
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server"></asp:label></td>
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
							<tr>
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE class="QH_Table" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<br>
										<TR>
											<TD class="QH_ColLabel" width="20%">Số biên nhận <FONT color="#ff0000"><STRONG>*</STRONG></FONT></TD>
											<TD class="QH_ColControl" colSpan="4"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="35%" runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" CssClass="QH_textbox" Width="0px" runat="server" Visible="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="20%">Ngày yêu cầu <FONT color="#ff0000"><STRONG>*</STRONG></FONT></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayYeuCau" CssClass="QH_textbox" Width="70px" runat="server"></asp:textbox>
												&nbsp;<asp:hyperlink id="cmdNgayYeuCau" CssClass="CommandButton" Runat="server">
													<asp:image id="imgNgayYeuCau" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
											<TD class="QH_ColLabel" width="20%">Số ngày bổ sung <FONT color="#ff0000"><STRONG>*</STRONG></FONT></TD>
											<TD class="QH_ColControl" colSpan="2"><asp:textbox id="txtSoNgayBoSung" CssClass="QH_TextRight" Width="30px" runat="server" MaxLength="4"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Tình trạng <FONT color="#ff0000"><STRONG>*</STRONG></FONT></TD>
											<TD class="QH_ColControl" colSpan="4"><asp:dropdownlist id="ddlMaTinhTrangXuLy" CssClass="QH_DropDownList" Width="35%" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Về việc</TD>
											<TD class="QH_ColControl" colSpan="4"><asp:textbox id="txtGhiChu" CssClass="QH_textbox" Width="75%" runat="server" Rows="3" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Nội dung yêu cầu <FONT color="#ff0000"><STRONG>*</STRONG></FONT></TD>
											<TD class="QH_ColControl" colSpan="4"><asp:textbox id="txtNoiDungYeuCau" CssClass="QH_textbox" Width="75%" runat="server" Rows="5"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="1">Lãnh đạo phòng ký</TD>
											<TD class="QH_ColControl" colSpan="4"><asp:dropdownlist id="ddlMaNguoiSuDung" CssClass="QH_DropDownList" Width="35%" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD colSpan="5" height="5"><asp:textbox id="txtHoSoBoSungID" CssClass="QH_textbox" Width="19px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" CssClass="QH_textbox" Width="0px" runat="server" Visible="True"></asp:textbox><asp:textbox id="txtTabCode" CssClass="QH_textbox" Width="19px" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" CssClass="QH_textbox" Width="0px" runat="server" Visible="True"></asp:textbox></TD>
										<TR>
											<TD vAlign="middle" align="center" colSpan="5">
												<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>
												<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnInXacMinh" CssClass="QH_Button" runat="server">In hẹn xác minh</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
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
