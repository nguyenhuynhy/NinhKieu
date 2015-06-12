<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CreateVanBanBaoCao.ascx.vb" Inherits=".CreateVanBanBaoCao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function viewFile(FileName){
	var url = "<%=Request.ApplicationPath & "/DESKTOPMODULES/BCTH/Upload/"%>" + FileName;
	//lert(url);
	alert(url);
	window.open(url,"Image","toolbar=yes,location=no,resizable=yes,scrollbars=yes");
	return false;
}
function checkKyBaoCao(strKybaocao)
{
	
	//	alert(strKybaocao);	
	var ddl = document.all(strKybaocao);
	var cap=ddl.options[ddl.selectedIndex].value;
	//alert(cap);
	cap = (cap).substring(0,1);
	if (cap=="1")
	{
		return true;
	}
	else
	{
		if (cap=="0")
		{
		alert("Bạn phải chọn một kỳ báo cáo cụ thể");
		ddl.focus();
		return false;
		}
	}
}
</script>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="Label6" runat="server" width="100%" CssClass="QH_Content_Header_Middle">SOẠN THẢO BÁO CÁO</asp:label>
					</td>
					<td width="8" height="25" class="QH_Content_TopRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="9" class="QH_Content_Left">&nbsp;
					</td>
					<td width="*" valign="top">
						<!--End bound-->
						<table cellSpacing="0" cellPadding="0" width="100%" align="center">
							<tr>
								<td align="center">
									<table cellSpacing="0" cellPadding="0" width="100%" align="center">
										<tr>
											<td height="5">
											</td>
										</tr>
										<tr valign="top">
											<td width="100%">
												<table Class="QH_Content_Filter" cellSpacing="0" cellPadding="0" width="90%" align="center">
													<tr>
														<td height="5px"></td>
													</tr>
													<tr>
														<td width="15%"><asp:label id="Label1" CssClass="QH_ColLabel" runat="server">Đơn vị báo cáo</asp:label><font color="red">*</font></td>
														<td width="35%"><asp:dropdownlist id="ddlDonVi" CssClass="QH_TextBox" runat="server" Width="90%"></asp:dropdownlist></td>
														<td width="15%"><asp:Label ID="lbl10" Runat="server" CssClass="QH_ColLabel" Text="Lĩnh vực báo cáo"></asp:Label><font color="red">*</font></td>
														<td width="35%"><asp:DropDownList ID="ddlLinhVuc" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></td>
													</tr>
													<tr>
														<td width="15%"><asp:label id="Label2" CssClass="QH_ColLabel" runat="server">Kỳ báo cáo</asp:label><font color="red">*</font></td>
														<td width="35%"><asp:dropdownlist id="ddlKyBaoCao" CssClass="QH_textBox" runat="server" Width="60%"></asp:dropdownlist></td>
														<td width="15%"><asp:label id="Label3" CssClass="QH_ColLabel" runat="server">Năm</asp:label><font color="red">*</font></td>
														<td width="15%"><asp:dropdownlist id="ddlNam" CssClass="QH_DropDownList" runat="server" Width="50%"></asp:dropdownlist></td>
													</tr>
													<tr>
														<td width="15%"><asp:label id="Label5" Runat="server" CssClass="QH_ColLabel" Text="File đính kèm"></asp:label></td>
														<td width="35%"><INPUT id="txtUpLoadFile" class="QH_Textbox" type="file" name="txtUpLoadFile" runat="server"></td>
														<td width="15%"><asp:label id="Label4" CssClass="QH_ColLabel" runat="server">Ngày tạo lập</asp:label></td>
														<td width="35%"><asp:textbox id="txtNgayLap" CssClass="QH_textBox" runat="server" Width="40%"></asp:textbox>
															<asp:image id="imgDate" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/images/calendar.gif"></asp:image></td>
													<tr>
														<td align="left" width="15%">
															<asp:label id="lblTinhTrangHD" Runat="server" CssClass="QH_ColLabel" Text="Tình trạng"></asp:label></td>
														<td width="85%" colspan="3"><asp:checkbox id="chkTinhTrang" Runat="server" Checked="True"></asp:checkbox></td>
													</tr>
													<tr>
														<td align="left" width="15%"><asp:label id="lbl1" Runat="server" CssClass="QH_ColLabel" Text="Tiêu đề"></asp:label><FONT color="#ff3300">*</FONT>
														</td>
														<td width="85%" colspan="3"><asp:textbox id="txtTieuDe" Runat="server" CssClass="QH_TextBox" Width="95%" Rows="3" TextMode="MultiLine"></asp:textbox></td>
													</tr>
													<tr>
														<td height="5">
														</td>
													</tr>
													<tr>
														<td width="15%">
															<asp:label id="lblXemFile" Runat="server" CssClass="QH_ColLabel" Visible="False">File đính kèm :</asp:label>
														</td>
														<td width="*" colspan="3"><asp:hyperlink id="hplFileName" Runat="server" Visible="False"></asp:hyperlink><asp:linkbutton id=butFileName Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileName") %>' Visible="False">
															</asp:linkbutton>
														</td>
													</tr>
													<tr>
														<td height="5">
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table width="100%" align="center" cellSpacing="0" cellPadding="0">
													<tr>
														<TD width="100%"><asp:label id="lbl3" Width="100%" Runat="server" CssClass="QH_Content_Header_Middle">Nội dung</asp:label><FONT color="#ff3300"></FONT></TD>
													</tr>
													<tr>
														<TD><FTB:FREETEXTBOX id="ftbNoidung" width="100%" runat="server" JavaScriptLocation="ExternalFile" SupportFolder="~/Inc/FreeTextBox/"
																height="300"></FTB:FREETEXTBOX><TOOLBARS><FTB:TOOLBAR><FTB:INSERTIMAGEFROMGALLERY />
																	<FTB:INSERTTABLE />
																	<FTB:EDITTABLE />
																</FTB:TOOLBAR>
															</TOOLBARS></TD>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<TD align="center"><asp:imagebutton id="btnSave" Runat="server" ImageUrl="../../images/btn_CapNhat.gif"></asp:imagebutton>&nbsp;&nbsp;
												<asp:imagebutton id="btnTrove" Runat="server" ImageUrl="../../images/btn_TroVe.gif"></asp:imagebutton></TD>
										</tr>
									</table>
								</td>
							</tr>
							
						</table>
						<!--start bound-->
					</td>
					<td width="8" class="QH_Content_Right">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colspan="3" height="12">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="128" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
					</td>
					<td width="130" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
