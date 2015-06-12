<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GiaHanGPXD.ascx.vb" Inherits="CPXD.GiaHanGPXD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript"> 
function CheckDateOnBlurWithCompare(obj,obj1)    
{   
	
	if (!isBlank(obj))    
	{    
		
		if (isValidDate(obj.value)!=0)    
		{	
			
			alert('Ngay ' + obj.value + ' khong hop le. Nhap ngay theo dang dd/MM/yyyy.')    
			obj.focus();
			return false;
			
		}   
		
		if (compareDates(obj.value, obj1.value)!=1){
				alert('Ngày gia hạn đến phải sau ngày gia hạn!');
				obj.focus();
				return false;
		} 
	}
	
	return true;
}    
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label2" Width="100%" CssClass="QH_Label_Title" Runat="server">Gia hạn giấy phép xây dựng</asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<tr>
								<td height="5"></td>
							</tr>
							<TR vAlign="top">
								<TD vAlign="top" align="left" width="50%">
									<TABLE class="QH_Table" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="25%"><asp:linkbutton id="btnSoBN" Runat="server">Số biên nhận</asp:linkbutton><asp:label id="lblSoBN" CssClass="QH_ColLabel" runat="server">Số biên nhận<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl" height="10"><asp:textbox id="txtSoBienNhan" Width="50%" CssClass="QH_textbox" runat="server" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="25%"><asp:linkbutton id="btnSoGP" Runat="server">Số Giấp Phép</asp:linkbutton><asp:label id="lblSoGP" CssClass="QH_ColLabel" runat="server">Số giấy phép<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl" height="8"><asp:textbox id="txtSoGiayPhep" Width="50%" CssClass="QH_textbox" runat="server" ReadOnly="True"
													EnableViewState="true"></asp:textbox></TD>
										</TR>
										<tr>
											<TD class="QH_ColLabel" width="30%"><asp:label id="lblTuNgay" runat="server">Ngày cấp</asp:label></TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtNgayCap" Width="30%" CssClass="QH_TextBox" Runat="server" ReadOnly="True"
													MaxLength="10"></asp:textbox>&nbsp;</TD>
										</tr>
										<tr>
											<TD class="QH_ColLabel" width="30%"><asp:label id="lblDenNgay" runat="server">Ngày gia hạn<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtNgayGiaHan" Width="30%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
												<asp:hyperlink id="cmdStartCalendar" CssClass="CommandButton" Runat="server">
													<asp:image id="btnNgayGiaHan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="30%"><asp:label id="Label3" runat="server">Gia hạn đến<font color="Red">*</font></asp:label></TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtGiaHanDen" Width="30%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
												<asp:hyperlink id="cmdEndCalendar" CssClass="CommandButton" Runat="server">
													<asp:image id="btnGiaHanDen" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" width="25%">Ghi Chú</td>
											<td class="QH_ColControl"><asp:textbox id="txtGhiChu" Width="80%" CssClass="QH_TextBox" Runat="server" MaxLength="500"
													TextMode="MultiLine" Rows="4"></asp:textbox></td>
										</tr>
									</TABLE>
								</TD>
								<TD vAlign="top" width="50%">
									<TABLE class="QH_Table" id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="30%">Họ tên</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtHoten" Width="80%" CssClass="QH_textbox" runat="server" ReadOnly="True" EnableViewState="true"
													MaxLength="100"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="30%">Thường trú</TD>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtDiaChiThuongTru" Width="80%" CssClass="QH_textbox" runat="server" ReadOnly="True"
													EnableViewState="true" TextMode="MultiLine" Rows="1"></asp:textbox></TD>
										</TR>
										<tr>
											<td align="left" width="100%" colSpan="2">
												<TABLE class="QH_Table" id="Table23" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD colSpan="2" height="21"><asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Địa chỉ xây dựng</asp:label></TD>
													</tr>
													<TR>
														<TD class="QH_ColLabel" width="30%">Số nhà</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtSoNha" Width="40%" CssClass="QH_TextBox" Runat="server" ReadOnly="True" MaxLength="50"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="30%">Đường</TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaDuong" Width="80%" CssClass="QH_DropDownList" Runat="server" Enabled="False"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="30%">Phường</TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaPhuong" Width="80%" CssClass="QH_DropDownList" Runat="server" Enabled="False"></asp:dropdownlist></TD>
													</TR>
													<tr>
														<td height="15"></td>
													</tr>
													<tr>
														<td class="QH_ColLabel" width="25%">Lãnh đạo duyệt<font color="red">*</font>
														</td>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaSoLanhDao" Width="80%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist><asp:textbox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaLinhVuc" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtGiaHanGPXDID" Width="0px" runat="server"></asp:textbox></TD>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td height="10"></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In đề xuất</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnYeuCauBoSung" CssClass="QH_Button" runat="server">Bổ sung HS</asp:linkbutton>
									<asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server">Hồ sơ không</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton>&nbsp;
								</td>
							</tr>
							<tr>
								<td height="10"></td>
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
