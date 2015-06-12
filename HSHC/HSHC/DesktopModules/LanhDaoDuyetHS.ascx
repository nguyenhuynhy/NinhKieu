<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuuChuyenNhan" Src="ThongTinTraCuuChuyenNhan.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LanhDaoDuyetHS.ascx.vb" Inherits="HSHC.LanhDaoDuyetHS" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function LaySoBienNhan()
		{
			var value,j,tenchkChon,ID,PrintID;
			PrintID='';
			for (j=3; j<eval('document.forms[0].all("<%=Me.ClientID%>_grdDanhSach")').rows.length+1 ; j++)
				{
					tenchkChon = "<%=Me.ClientID%>_grdDanhSach__ctl" + j + "_" + "chkXoa";
					ID = "<%=Me.ClientID%>_grdDanhSach";
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
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*" align="center">
						<asp:label id="lblHeader" runat="server" CssClass="QH_Label_Title" Width="100%"></asp:label>
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
							<tr>
								<td align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr height="2">
											<td>
											</td>
										</tr>
										<TR>
											<TD vAlign="top" width="100%">
												<table id="tblHeader" width="100%" Class="QH_LoaiHS" align="center" runat="server">
													<TR valign="middle">
														<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại&nbsp;hồ sơ 
																tiếp&nbsp;nhận&nbsp;&nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="60%">
															<asp:DropDownList CssClass="QH_DropDownList" id="ddlLinhVuc" runat="server" Width="95%" AutoPostBack="True"></asp:DropDownList>
														</TD>
														<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1">
															<asp:linkbutton id="btnThucHien" runat="server" CssClass="QH_Button" Visible="False">Thực hiện</asp:linkbutton></TD>
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
																	<TD>
																		<uc1:ThongTinTraCuuChuyenNhan id="ThongTinTraCuuChuyenNhan1" runat="server"></uc1:ThongTinTraCuuChuyenNhan></TD>
																</TR>
																<TR>
																	<TD height="3"></TD>
																</TR>
																<tr>
																	<td align="center">
																		<asp:RadioButtonList cssclass="QH_LoaiHS" id="rblDuyet" runat="server" Width="312px" RepeatDirection="Horizontal">
																			<asp:ListItem Value="1" Selected="True">L&#227;nh đạo duyệt</asp:ListItem>
																			<asp:ListItem Value="2">L&#227;nh đạo kh&#244;ng duyệt</asp:ListItem>
																		</asp:RadioButtonList>
																	</td>
																</tr>
																<TR>
																	<TD height="3"></TD>
																</TR>
																<TR>
																	<TD align="center">
																		<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>&nbsp;
																		<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
																		<asp:linkbutton id="btnInRaGiay" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
																	</TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD align="right" width="15%" colSpan="1" rowSpan="1">
																					<asp:Label ID="Label1" Runat="server" CssClass="QH_ColLabel1">Số dòng hiển thị</asp:Label>
																					<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextRight" Width="50px"
																						MaxLength="3"></asp:TextBox>
																				</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD>
																		<asp:datagrid id="grdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" autogeneratecolumns="False"
																			AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages" CellPadding="3">
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
												<INPUT id="txtChuoiSoBienNhan" type="hidden" size="1" name="txtChuoiSoBienNhan" runat="server"><INPUT id="txtMaLinhVuc" type="hidden" size="1" name="txtMaLinhVuc" runat="server"><INPUT id="txtMaNguoiTacNghiep" type="hidden" size="1" name="txtMaNguoiTacNghiep" runat="server">
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
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
