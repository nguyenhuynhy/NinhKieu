<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuuChuyenNhan" Src="ThongTinTraCuuChuyenNhan.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChuyenHoSo.ascx.vb" Inherits="HSHC.ChuyenHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuu" Src="ThongTinTraCuu.ascx" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">

function LaySoBienNhan()
		{
			var value,j,tenchkChon,ID,PrintID;
			PrintID='';
			for (j=3; j<eval('document.forms[0].all("<%=Me.ClientID%>_dgdDanhSach")').rows.length+1 ; j++)
				{
					tenchkChon = "<%=Me.ClientID%>_dgdDanhSach__ctl" + j + "_" + "chkXoa";
					ID = "<%=Me.ClientID%>_dgdDanhSach";
					if(eval('document.forms[0].all("' + tenchkChon + '")').checked==1){
						if (PrintID!='')
						{
							PrintID=PrintID+','
						}
						PrintID=PrintID+eval('document.forms[0].all("' + ID + '")').rows(j-2).cells(2).innerText
					}
				}
				for (i=0;i<window.document.forms(0).length-1;i++)
				{
							
					if (window.document.forms(0).item(i).id.indexOf('txtChuoiSoBienNhan') != -1)
					{
							
						objSoBienNhan = window.document.forms(0).item(i);	
						objSoBienNhan.value= PrintID;
					}
							
				}
	
		}

function KiemTraThongTinCapNhat()
{
	var i;
	var obj;
	
	for (i=0; i<window.document.forms(0).length-1; i++)
	{
		obj = window.document.forms(0).item(i);
		if (obj.id.indexOf('ddlNguoiChuyen') != -1)
		{
			if (obj.value == '')
			{
				alert ('Bạn phải chọn người chuyển hồ sơ!');
				obj.focus();
				return false;
			}
		}
		if (obj.id.indexOf('ddlNguoiNhan') != -1)
		{
			if (obj.value == '')
			{
				alert ('Bạn phải chọn người nhận hồ sơ!');
				obj.focus();
				return false;
			}
		}
		if (obj.id.indexOf('chkXoa') != -1)
		{
			if (obj.checked == true)
			{
				return true;
			}
		}
	}
	alert('Bạn phải chọn hồ sơ để cập nhật');
	return false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">&nbsp;</asp:label></td>
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
							<tr>
								<td align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr height="2">
											<td></td>
										</tr>
										<TR>
											<TD vAlign="top" width="100%">
												<table class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại hồ sơ tiếp nhận</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="60%"><asp:dropdownlist id="ddlLinhVuc" CssClass="QH_DropDownList" Width="95%" runat="server"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1"><asp:linkbutton id="btnThucHien" CssClass="QH_Button" runat="server">Thực hiện</asp:linkbutton></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%">
												<table width="100%">
													<tr>
														<td>
															<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD><uc1:thongtintracuu id="ThongTinTraCuu1" runat="server"></uc1:thongtintracuu></TD>
																</TR>
																<TR>
																	<TD height="3"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD align="center" width="70%"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>&nbsp;&nbsp;&nbsp;
																					<asp:linkbutton id="btnInPhieu" CssClass="QH_Button" runat="server" Visible="False">In phiếu</asp:linkbutton>&nbsp;
																					<asp:linkbutton id="btnInRaGiay" CssClass="QH_Button" runat="server">In ra giấy</asp:linkbutton></TD>
																			</TR>
																			<tr>
																				<TD align="right" width="30%"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" Runat="server" MaxLength="3"
																						AutoPostBack="True"></asp:textbox></TD>
																			</tr>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" autogeneratecolumns="False"
																			AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages" CellPadding="3">
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																			<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD height="47"><input id="txtChuoiSoBienNhan" type="hidden" size="1" name="txtChuoiSoBienNhan" runat="server">
																		<input id="txtMaLinhVuc" type="hidden" size="1" name="txtMaLinhVuc" runat="server">
																		<INPUT id="txtMaNguoiTacNghiep" type="hidden" size="1" name="txtMaNguoiTacNghiep" runat="server">
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
