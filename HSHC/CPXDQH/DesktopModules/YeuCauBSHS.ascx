<%@ Control Language="vb" AutoEventWireup="false" Codebehind="YeuCauBSHS.ascx.vb" Inherits="CPXD.YeuCauBSHS" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language="javascript">
function CheckSoNgay(obj) {	
	var so;
	so=(obj.value);
	if(so=='')
	{
		alert('So ngay khong duoc bo trong');
		return false;			
	}
	if(so<=0)
	{
		alert('So ngay bo sung phai lon hon > 0 !');
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title"></asp:label></td>
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
					<td align="center" width="*"><br>
						<TABLE class="QH_Table" cellSpacing="0" cellPadding="0" width="80%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="20%">Số biên nhận</TD>
								<TD class="QH_ColControl" width="30%" colSpan="1" rowSpan="1"><asp:textbox id="txtSoBienNhan" Width="80%" CssClass="QH_textbox" Enabled="False" runat="server"></asp:textbox></TD>
								<TD width="10%"></TD>
								<TD width="20%"><asp:textbox id="txtHoSoTiepNhanID" Width="0px" CssClass="QH_textbox" runat="server" Visible="True"></asp:textbox></TD>
								<TD width="30%" colSpan="1" rowSpan="1"></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Ngày thông báo</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtNgayYeuCau" Width="80%" CssClass="QH_textbox" runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayYeuCau" CssClass="QH_ImageButton" runat="server" ImageUrl="../../Images/calendar.gif"></asp:image></TD>
								<td></td>
								<TD class="QH_ColLabel">Số ngày bổ sung<FONT color="#ff0000" size="2">*</FONT></TD>
								<TD class="QH_ColControl"><asp:textbox id="txtSoNgayBoSung" Width="60%" CssClass="QH_TextRight" runat="server" MaxLength="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="17">Tình trạng</TD>
								<TD class="QH_ColControl" colSpan="2" height="17"><asp:dropdownlist id="ddlMaTinhTrangXuLy" Width="61%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Về việc</TD>
								<TD class="QH_ColControl" colSpan="4"><asp:textbox id="txtGhiChu" Width="90%" CssClass="QH_textbox" runat="server" TextMode="MultiLine"
										Rows="3"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Nội dung yêu cầu</TD>
								<TD class="QH_ColControl" colSpan="4"><asp:textbox id="txtNoiDungYeuCau" Width="90%" CssClass="QH_textbox" runat="server" TextMode="MultiLine"
										Rows="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="1">Lãnh đạo phòng ký</TD>
								<TD class="QH_ColControl" colSpan="4" height="1"><asp:dropdownlist id="ddlMaNguoiSuDung" Width="50%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD colSpan="5" height="5"><asp:textbox id="txtHoSoBoSungID" Width="19px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" Width="19px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" Width="19px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" Width="19px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox></TD>
							<TR>
								<TD vAlign="middle" align="center" colSpan="5"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnInXacMinh" CssClass="QH_Button" runat="server">In thông báo hẹn xác minh</asp:linkbutton><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD colSpan="5" height="5"></TD>
							<TR>
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
