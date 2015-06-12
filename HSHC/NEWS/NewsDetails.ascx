<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NewsDetails.ascx.vb" Inherits="NewsDetails" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function viewImage(ImageName){
	var url = "<%=Request.ApplicationPath & "/news/upload/"%>" + ImageName;
	//lert(url);
	window.open(url,"Image","toolbar=no,location=no,resizable=yes,scrollbars=yes");
	return false;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">TIN TỨC - SỰ KIỆN&nbsp;</asp:label></td>
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
						<table width="100%">
							<tr>
								<td vAlign="top">
									<asp:panel id="pnlNewsInfo" Runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="100%">
													<TABLE class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="QH_ColLabel" width="15%">Tiêu đề <FONT color="#ff3300">*</FONT></TD>
															<TD class="QH_ColControl" width="35%">
																<asp:TextBox id="txtTieude" CssClass="QH_TextBox" Width="95%" runat="server"></asp:TextBox></TD>
															<TD class="QH_ColLabel" width="17%">Ngày đưa tin<FONT color="#ff3300">*</FONT></TD>
															<TD class="QH_ColControl" width="33%">
																<asp:TextBox id="txtPublishDate" CssClass="QH_TextBox" Width="30%" Runat="server" MaxLength="10"></asp:TextBox>
																<asp:image id="imgDate" CssClass="QH_ImageButton" Runat="server" ImageUrl="~/images/calendar.gif"></asp:image></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Loại tin <FONT color="#ff3300">*</FONT></TD>
															<TD class="QH_ColControl">
																<asp:DropDownList id="ddlLoaitin" Width="95%" runat="server"></asp:DropDownList></TD>
															<TD class="QH_ColLabel">Nguồn</TD>
															<TD class="QH_ColControl">
																<asp:TextBox id="txtSource" CssClass="QH_TextBox" Width="60%" runat="server"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Hình minh họa</TD>
															<TD class="QH_ColControl"><INPUT class="QH_Textbox" id="imgupdImage" type="file" size="25" name="imgupdImage" runat="server">
																<asp:Label id="lblUpload" runat="server" Visible="False" ForeColor="Red"></asp:Label>
																<asp:LinkButton id="lnkbtnXemhinh" runat="server" Visible="False" CausesValidation="true">&nbsp;Xem</asp:LinkButton></TD>
															<TD class="QH_ColControl" align="left">
																<asp:CheckBox id="chkHotnews" runat="server" Text="Hiển thị tại trang chủ"></asp:CheckBox></TD>
															<TD class="QH_ColControl" align="left">
																<asp:RadioButton id="rdoChuaDuyet" runat="server" Text="Chưa duyệt" GroupName="grpDuyet" Checked="True"></asp:RadioButton>
																<asp:RadioButton id="rdoDuyet" runat="server" Text="Duyệt" GroupName="grpDuyet"></asp:RadioButton>
																<asp:RadioButton id="rdoTraLai" runat="server" Text="Trả lại" GroupName="grpDuyet"></asp:RadioButton></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Quy trình duyệt tin<FONT color="#ff3300">*</FONT></TD>
															<TD class="QH_ColControl" colSpan="3">
																<asp:DropDownList id="ddlQuytrinh" Width="39%" runat="server"></asp:DropDownList></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="QH_ColLabel" width="15%">Nội dung tóm tắt<FONT color="#ff3300">*</FONT></TD>
															<TD class="QH_ColControl">
																<asp:TextBox id="txtTomtat" CssClass="QH_TextBox" Width="85%" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="5"></TD>
											</TR>
											<TR>
												<TD class="QH_LabelMiddleBold">.:: NỘI DUNG<FONT color="#ff3300">*</FONT> ::.</TD>
											</TR>
											<TR>
												<TD height="5"></TD>
											</TR>
											<TR>
												<TD align="center">
													<FTB:FreeTextBox id="ftbNoidung" runat="server" width="98%" height="180" SupportFolder="~/Inc/FreeTextBox/"
														JavaScriptLocation="ExternalFile" backcolor="#E1EBFB">
														<TOOLBARS>
															<FTB:TOOLBAR>
																<FTB:INSERTIMAGEFROMGALLERY />
																<FTB:INSERTTABLE />
																<FTB:EDITTABLE />
															</FTB:TOOLBAR>
														</TOOLBARS>
													</FTB:FreeTextBox></TD>
											</TR>
											<TR>
												<TD align="center">
													<TABLE>
														<TR>
															<TD>
																<asp:ImageButton id="imgbtnSave" Runat="server" ImageUrl="~/images/save.gif"></asp:ImageButton>
																<asp:LinkButton id="lnkbtnSave" Runat="server">Lưu</asp:LinkButton>&nbsp;&nbsp;
															</TD>
															<TD>
																<asp:ImageButton id="imgbtnCancel" Runat="server" ImageUrl="~/images/cancel.gif"></asp:ImageButton>
																<asp:LinkButton id="lnkbtnCancel" Runat="server">Trở về</asp:LinkButton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:panel>
								</td>
							</tr>
						</table>
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
