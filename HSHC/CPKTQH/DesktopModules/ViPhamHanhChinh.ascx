<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ViPhamHanhChinh.ascx.vb" Inherits="CPKTQH.ViPhamHanhChinh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function form_empty()
{
	var i;
	var obj;
	for (i=0; i<window.document.forms(0).length; i++)
	{
		obj = window.document.forms(0).item(i);
		if (obj.id.indexOf('txtSoQuyetDinh') != -1)
		{
			obj.value='';
			obj.disabled = false;
			obj.focus();
		}
		if (obj.id.indexOf('txtNgayQuyetDinh') != -1)
		{
			obj.value='';
		}
		if (obj.id.indexOf('txtDonViRaQuyetDinh') != -1)
		{
			obj.value='';
		}
		if (obj.id.indexOf('txtNoiDung') != -1)
		{
			obj.value='';
		}
		if (obj.id.indexOf('txtSoGiayPhep') != -1)
		{
			obj.value='';
			obj.disabled=false;
		}
		if (obj.id.indexOf('txtSoCMND') != -1)
		{
			obj.value='';
			obj.disabled=false;
		}
		if (obj.id.indexOf('txtSoNha') != -1)
		{
			obj.value='';
			obj.disabled=false;
		}
		if (obj.id.indexOf('ddlDuong') != -1)
		{
			obj.value='';
			obj.disabled=false;
		}
		if (obj.id.indexOf('ddlPhuong') != -1)
		{
			obj.value='';
			obj.disabled=false;
		}
		if (obj.id.indexOf('txtViPhamHanhChinhID') != -1)
		{
			obj.value='';
		}
	}
	return false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblHeader" CssClass="QH_Label_Title" runat="server" Width="100%">Quyết định vi phạm hành chính</asp:label>
					</td>
					<td width="16" height="24" class="QH_Khung_TopRight">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" class="QH_Khung_Left">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="15%"></TD>
								<TD width="*">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<br>
										<TR>
											<TD class="QH_ColLabel" width="25%">Số quyết định(<font color="#ff0000">*</font>)</TD>
											<td class="QH_ColControl" width="*"><asp:textbox id="txtSoQuyetDinh" width="30%" CssClass="QH_TextBox" runat="server"></asp:textbox></td>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày ra quyết định(<font color="#ff0000">*</font>)</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayQuyetDinh" width="30%" CssClass="QH_TextBox" runat="server" MaxLength="10"></asp:textbox>&nbsp;
												<asp:image id="imgNgayQuyetDinh" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn lịch"
													ImageUrl="~\images\calendar.gif"></asp:image></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Công ty ra quyết định</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDonViRaQuyetDinh" CssClass="QH_TextBox" runat="server" Width="95%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Nội dung</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNoiDung" CssClass="QH_TextBox" runat="server" Width="95%" Rows="3" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ðơn vị vi phạm(<font color="#ff0000">*</font>)</TD>
											<TD class="QH_ColControl"><asp:label id="Label4" CssClass="QH_LabelLeftItalic" runat="server">(Bạn phải điền thông tin ít nhất 1 trong 3 nội dung sau)</asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD>
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
													<TR>
														<TD class="QH_LabelLeftBold" width="40%">Số GCN ĐKKD</TD>
														<TD class="QH_ColControl" width="*"><asp:textbox id="txtSoGiayPhep" width="91%" CssClass="QH_TextBox" runat="server"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_LabelLeftBold">Số chứng minh nhân dân</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" width="91%" CssClass="QH_TextBox" runat="server" MaxLength="9"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_LabelLeftBold">Địa chỉ kinh doanh</TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Số nhà</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" runat="server" Width="91%"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Đường</TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlDuong" CssClass="QH_DropDownList" runat="server" Width="91%"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Phường</TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" CssClass="QH_DropDownList" runat="server" Width="91%"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="15%"></TD>
							</TR>
							<TR>
								<TD height="5" colspan="3"></TD>
							</TR>
							<TR>
								<TD align="center" colspan="3">
									<asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
								</TD>
							</TR>
						</TABLE>
						<asp:TextBox id="txtViPhamHanhChinhID" Width="0px" runat="server"></asp:TextBox>
					</td>
					<td width="16" class="QH_Khung_Right">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1">
								</td>
							</tr>
						</Table>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
