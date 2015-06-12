<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Admin_AddLocation.ascx.vb" Inherits="HSHC.Admin_AddLocation" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">DANH SÁCH ĐỊA ĐIỂM HỌP</asp:label>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table2" class="QH_Table" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD valign="top">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="200">Tên địa điểm</TD>
																	<TD>
																		<asp:TextBox id="txtLocationName" Width="50%" CssClass="QH_Textbox" runat="server"></asp:TextBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td height="5">
											</td>
										</tr>
										<TR>
											<TD align="center"><asp:ImageButton id="btnCapNhat" runat="server" ImageUrl="../../Images/btn_CapNhat.gif" CssClass="QH_Button"></asp:ImageButton>
												<asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_Trove.gif" CssClass="QH_Button"></asp:ImageButton>
												<asp:TextBox id="txtID" Width="0px" runat="server"></asp:TextBox>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
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