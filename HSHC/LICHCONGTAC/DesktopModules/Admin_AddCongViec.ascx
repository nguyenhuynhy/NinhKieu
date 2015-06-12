<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Admin_AddCongViec.ascx.vb" Inherits="LICHCONGTAC.Admin_AddCongViec" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD width="100%" height="25">
			<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD class="QH_Content_TopLeft" width="9"></TD>
					<TD class="QH_Content_TopMid" width="*">&nbsp;
						<asp:label id="lblTitle" CssClass="QH_Content_Header_Middle" width="100%" runat="server" DESIGNTIMEDRAGDROP="66">DANH SÁCH CÔNG VIỆC</asp:label></TD>
					<TD class="QH_Content_TopRight" width="8"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD width="100%" height="100%">
			<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_Content_Left" width="9">&nbsp;</TD>
					<TD vAlign="top" width="*">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="80%" border="0" DESIGNTIMEDRAGDROP="78">
							<TR>
								<TD vAlign="top">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_ColLabel" width="200">Mã công việc</TD>
														<TD>
															<asp:TextBox id="txtCongViecID" CssClass="QH_Textbox" runat="server" Width="25%"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="200">Công việc</TD>
														<TD>
															<asp:TextBox id="txtCongViec" CssClass="QH_Textbox" runat="server" Width="50%"></asp:TextBox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:ImageButton id="btnCapNhat" CssClass="QH_Button" runat="server" ImageUrl="../../Images/btn_CapNhat.gif"></asp:ImageButton>
									<asp:ImageButton id="btnTroVe" CssClass="QH_Button" runat="server" ImageUrl="../../Images/btn_Trove.gif"></asp:ImageButton>
									<asp:TextBox id="txtID" runat="server" Width="0px"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="QH_Content_Right" width="8">&nbsp;</TD>
				</TR>
			</TABLE>
		</TD>
	</TR> <!--Footer-->
	<TR>
		<TD width="100%">
			<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_Content_BottomLeft" width="8"></TD>
					<TD class="QH_Content_BottomMid" width="*">&nbsp;</TD>
					<TD class="QH_Content_BottomRight" width="8"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
