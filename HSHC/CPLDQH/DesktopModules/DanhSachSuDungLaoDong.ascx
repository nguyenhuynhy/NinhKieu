<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuuLD" Src="ThongTinTraCuuLD.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachSuDungLaoDong.ascx.vb" Inherits=".DanhSachSuDungLaoDong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
							
					if (window.document.forms(0).item(i).id.indexOf('txtChuoiID') != -1)
					{
							
						objSoBienNhan = window.document.forms(0).item(i);	
						objSoBienNhan.value= PrintID;
					}
							
				}
		}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server"></asp:label></td>
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
							<TR>
								<TD align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="5" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="100%">
												<TABLE class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại hồ sơ tiếp nhận 
																&nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="60%"><asp:dropdownlist id="ddlLinhVuc" Width="95%" runat="server"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1"><asp:linkbutton id="btnThucHien" CssClass="QH_Button" runat="server">Thực hiện</asp:linkbutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%">
												<TABLE id="Table3" width="100%">
													<TR>
														<TD>
															<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD height="5"></TD>
																</TR>
																<TR>
																	<TD><uc1:thongtintracuuld id="ThongTinTraCuuLD1" runat="server"></uc1:thongtintracuuld></TD>
																</TR>
																<TR>
																	<TD height="5"><asp:textbox id="txtChuoiID" Width="0px" runat="server"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD align="center" width="100%" height="16"><asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>&nbsp;
																					<asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server">In danh sách</asp:linkbutton></TD>
																			</TR>
																			<tr>
																				<TD align="right"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" Runat="server" MaxLength="3"
																						AutoPostBack="True"></asp:textbox></TD>
																			</tr>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" CellPadding="3"
																			autogeneratecolumns="False" AllowPaging="True">
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																			<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<asp:textbox id="txtChuoiSoBienNhan" Width="0%" runat="server"></asp:textbox></TD>
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
