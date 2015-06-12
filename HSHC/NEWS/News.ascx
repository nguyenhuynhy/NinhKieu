<%@ Control language="vb" Inherits="News" CodeBehind="News.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<script language="javascript" src="inc/suycCalendar.js"></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td vAlign="top" width="100%">
			<table id="tblNews" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td vAlign="top"><asp:datagrid id="dgdNewsSummary" ShowHeader="False" AutoGenerateColumns="False" Width="100%"
							runat="server">
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<table width="100%" cellpadding="0" cellspacing="0" border="0">
											<tr id="rowCatName" runat="server">
												<td id="colCatName" runat="server" colspan="2">
													<asp:LinkButton ID=lnkbtnCatName Visible='<%# (CInt(DataBinder.Eval(Container.DataItem,"Flag")) >= 6) %>' Runat=server CommandName="getByCat" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Category_ID") %>'>
														<asp:Label id="lbllnkbtnCatName" Width="100%" CssClass="QH_News_Category" runat="server">
															<%#DataBinder.Eval(Container.DataItem,"Category_Name") %>
														</asp:Label>
													</asp:LinkButton>
												</td>
											</tr>
											<tr id="rowTitle" runat="server">
												<td id="colTitle" align="left" runat="server">
													<asp:LinkButton ID="lnkbtnTitle" Visible='<%# (CInt(DataBinder.Eval(Container.DataItem,"Flag")) >= 6) %>' Runat=server CommandName="viewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
														<asp:Label id="lbllnkbtnTitle" CssClass="QH_News_Title" runat="server">
															<%#DataBinder.Eval(Container.DataItem,"Title") %>
														</asp:Label>
													</asp:LinkButton>
													<asp:LinkButton ID="lnkbtnTitleMore" Visible='<%# (CInt(DataBinder.Eval(Container.DataItem,"Flag")) <= 1) %>' Runat=server CommandName="viewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
														<asp:Label id="lbllnkbtnTitleMore" CssClass="QH_News_Title_More" runat="server">
															<%#DataBinder.Eval(Container.DataItem,"Title") %>
														</asp:Label>
													</asp:LinkButton>
												</td>
											</tr>
											<tr id=rowSummary runat=server Visible='<%# (CInt(DataBinder.Eval(Container.DataItem,"Flag")) >= 6) %>'>
												<td id="colSummary" colspan="2" runat="server" class="QH_News_Content_Margin">
													<table border="0" width="100%">
														<TR>
															<TD valign="top">
															</TD>
															<td valign="top" class="QH_News_Content">
																<table align="left" border="0" cellpadding="0" cellspacing="0">
																	<TR vAlign="bottom">
																		<TD>
																			<asp:LinkButton ID="lnkbtnImage" Runat=server CommandName="viewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
																				<asp:Image id=imgSummary Runat="server" Width="80" Height=100 ImageUrl='<%#Request.ApplicationPath + "/NEWS/Upload/" + DataBinder.Eval( Container.DataItem,"ImageSave")%>' Visible='<%#(Not DataBinder.Eval( Container.DataItem,"ImageSave") Is DBNull.Value AND DataBinder.Eval( Container.DataItem,"VerHor").Equals("0"))%>'>
																				</asp:Image>
																				<asp:Image id="Image3" Runat="server" Width="130" Height=100 ImageUrl='<%#Request.ApplicationPath + "/NEWS/Upload/" + DataBinder.Eval( Container.DataItem,"ImageSave")%>' Visible='<%#(Not DataBinder.Eval( Container.DataItem,"ImageSave") Is DBNull.Value AND DataBinder.Eval( Container.DataItem,"VerHor").Equals("1"))%>'>
																				</asp:Image>
																			</asp:LinkButton>
																		</TD>
																	</TR>
																</table>
																<asp:Label id="lblSummary" Runat="server">
																	<%# DataBinder.Eval(Container.DataItem,"Summarize") %>
																</asp:Label>
															</td>
														</TR>
													</table>
												</td>
											</tr>
											<tr id=rowMore runat=server Visible='<%# (CInt(DataBinder.Eval(Container.DataItem,"Flag")) = 7) or (CInt(DataBinder.Eval(Container.DataItem,"Flag")) = 1)%>'>
												<td align="right" colspan="2" height="15">
													<table width="100%" cellpadding="0" cellspacing="0">
														<tr>
															<td width="*" Class="QH_News_Content_Others">&nbsp;</td>
															<td width="9" height="15" class="QH_News_Content_Others1">&nbsp;
															</td>
															<td width="180" height="15" Class="QH_News_Content_Others">
																<asp:LinkButton ID="lnkbtnMore" Width="100%" Runat=server CommandName="getByCat" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Category_ID") %>'>
																	<asp:Label id="lbllnkbtnMore" Width="100%" CssClass="QH_News_Others" runat="server">
																		<%# "Các tin " + Cstr(DataBinder.Eval(Container.DataItem,"Category_Name")).ToLower() + " khác ..."%>
																	</asp:Label>
																</asp:LinkButton>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid><asp:datagrid id="dgdNewsByCat" ShowHeader="False" AutoGenerateColumns="False" Width="100%" runat="server">
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<TR>
											<TD class="QH_News_Title_Margin">
												<asp:LinkButton ID="Linkbutton1" Runat=server CommandName="viewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
													<asp:Label id="Label11" CssClass="QH_News_Title" runat="server">
														<%#"&nbsp;" & DataBinder.Eval(Container.DataItem,"Title") %>
													</asp:Label>
												</asp:LinkButton>
											</TD>
										</TR>
										<TR>
											<TD class="QH_News_Content_Margin">
												<table width="100%">
													<tr>
														<td>
														</td>
														<td valign="top" Class="QH_News_Content">
															<table align="left" border="0" cellpadding="0" cellspacing="0">
																<TR vAlign="bottom">
																	<TD>
																		<asp:LinkButton ID="Linkbutton2" Runat=server CommandName="viewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
																			<asp:Image id="Image1" Runat="server" Width="80" Height=100 ImageUrl='<%#Request.ApplicationPath + "/News/Upload/" + DataBinder.Eval( Container.DataItem,"ImageSave")%>' Visible='<%#(Not DataBinder.Eval( Container.DataItem,"ImageSave") Is DBNull.Value AND DataBinder.Eval( Container.DataItem,"VerHor").Equals("0"))%>'>
																			</asp:Image>
																			<asp:Image id="Image6" Runat="server" Width="130" Height=100 ImageUrl='<%#Request.ApplicationPath + "/News/Upload/" + DataBinder.Eval( Container.DataItem,"ImageSave")%>' Visible='<%#(Not DataBinder.Eval( Container.DataItem,"ImageSave") Is DBNull.Value AND DataBinder.Eval( Container.DataItem,"VerHor").Equals("1"))%>'>
																			</asp:Image>
																		</asp:LinkButton>
																	</TD>
																</TR>
															</table>
															<asp:Label id="Label2" Runat="server">
																<%# DataBinder.Eval(Container.DataItem,"Summarize") %>
															</asp:Label>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
										<TR>
											<TD align="right" height="15" class="QH_News_Content_Detail">
												<asp:LinkButton ID="lnkbtnNewsDetail" Runat=server CommandName="viewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
													<asp:Label height="100%" id="lbllnkbtnNewsDetail" CssClass="QH_News_Detail" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label>
												</asp:LinkButton>
											</TD>
										</TR>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid><asp:datagrid id="dgdDetail" ShowHeader="False" AutoGenerateColumns="False" Width="100%" runat="server">
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<TR>
											<TD>
												<asp:Label id="Label1" Runat="server" CssClass="QH_News_Detail_Title">
													<%# DataBinder.Eval(Container.DataItem,"TieuDe") %>
												</asp:Label>
											</TD>
										</TR>
										<TR>
											<TD>
												<table border="0" cellpadding="0" cellspacing="0">
													<TR class="QH_News_Content_Margin">
														<TD>
														</TD>
														<td valign="top" Class="QH_News_Summary">
															<table align="left" border="0" cellpadding="0" cellspacing="0">
																<TR vAlign="bottom">
																	<TD>
																		<asp:Image id="Image2" Runat="server" Width="80" Height=100 ImageUrl='<%#Request.ApplicationPath + "/NEWS/Upload/" + DataBinder.Eval( Container.DataItem,"ImageSave")%>' Visible='<%#(Not DataBinder.Eval( Container.DataItem,"ImageSave") Is DBNull.Value AND DataBinder.Eval( Container.DataItem,"VerHor").Equals("0"))%>'>
																		</asp:Image>
																		<asp:Image id="Image7" Runat="server" Width="130" Height=100 ImageUrl='<%#Request.ApplicationPath + "/NEWS/Upload/" + DataBinder.Eval( Container.DataItem,"ImageSave")%>' Visible='<%#(Not DataBinder.Eval( Container.DataItem,"ImageSave") Is DBNull.Value AND DataBinder.Eval( Container.DataItem,"VerHor").Equals("1"))%>'>
																		</asp:Image>
																	</TD>
																</TR>
															</table>
															<asp:Label id="Label3" Runat="server">
																<%# DataBinder.Eval(Container.DataItem,"TomTat") %>
															</asp:Label>
														</td>
													</TR>
												</table>
											</TD>
										</TR>
										<TR>
											<TD class="QH_News_Content_Margin">
												<asp:Label id="Label4" Runat="server" CssClass="QH_News_Content">
													<%# DataBinder.Eval(Container.DataItem,"NoiDung") %>
												</asp:Label>
											</TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="Label9" Width="100%" Runat="server" CssClass="QH_News_PublicDate">
													Ngày <%# DataBinder.Eval(Container.DataItem,"PublishDate") %>
												</asp:Label>
											</TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="Label5" Width="100%" Runat="server" CssClass="QH_News_Source">
													<%# DataBinder.Eval(Container.DataItem,"Source") %>
												</asp:Label>
											</TD>
										</TR>
										<TR>
											<TD align="right">
												<asp:LinkButton ID="lnkbtnBack" Runat=server CommandName="goBack" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
													<asp:Label id="lbllnkbtnBack" CssClass="QH_Link_Button" Runat="server">Trở về... 
													</asp:Label>
												</asp:LinkButton>
											</TD>
										</TR>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr id="rowNewsPosted" runat="server">
					<td>
						<table width="100%">
							<tr>
								<td align="right" height="22">
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="QH_News_Content_Posted_1" width="6">&nbsp;
											</td>
											<td class="QH_News_Content_Posted_2" width="87">&nbsp;
											</td>
											<td class="QH_News_Content_Posted_3" width="35">&nbsp;
											</td>
											<td class="QH_News_Content_Posted" width="*">&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgdNewsPosted" ShowHeader="false" AutoGenerateColumns="False" Width="100%" runat="server">
										<Columns>
											<asp:TemplateColumn>
												<ItemTemplate>
													<TR>
														<TD>
															<asp:LinkButton ID="Linkbutton5" Runat=server CssClass="QH_News_Title_More" CommandName="viewDetail" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"News_ID") %>'>
																<asp:Label id="lbllnkbtnDetailMoreTitle">
																	<%# DataBinder.Eval(Container.DataItem,"Title") %>
																</asp:Label>
															</asp:LinkButton>
															(
															<asp:label id="Label7" Runat="server">
																<%# CStr(DataBinder.Eval(Container.DataItem,"PublishDate")).SubString(0,CStr(DataBinder.Eval(Container.DataItem,"PublishDate")).LastIndexOf("/")) %>
															</asp:label>)
														</TD>
													</TR>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
							<tr id="rowViewNext" runat="server">
								<td align="right"><asp:linkbutton id="lnkbtnViewNext" Runat="server">
										<asp:label id="Label12" CssClass="QH_Link_Button" Runat="server">Xem tiếp...
										</asp:label>
									</asp:linkbutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="rowNewsByDate" runat="server">
					<td align="center" width="100%" height="25">
						<table cellSpacing="0" cellPadding="0" width="60%" border="0">
							<tr>
								<td width="100"><STRONG>Chọn từ ngày</STRONG></td>
								<td width="100"><asp:textbox id="txtFromDate" Width="100%" Runat="server" MaxLength="10" CssClass="QH_TextBox"></asp:textbox></td>
								<td width="20">&nbsp;<asp:image id="imgFromDate" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/images/calendar.gif"></asp:image></td>
								<td width="80">&nbsp;<STRONG>đến ngày</STRONG></td>
								<td width="100"><asp:textbox id="txtToDate" Width="100%" Runat="server" MaxLength="10" CssClass="QH_TextBox"></asp:textbox></td>
								<td width="20">&nbsp;<asp:image id="imgToDate" Runat="server" CssClass="QH_ImageButton" ImageUrl="~/images/calendar.gif"></asp:image></td>
								<td width="*">&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lnkbtnViewByDate" Runat="server">
										<asp:label id="Label13" CssClass="QH_Link_Button" Runat="server">Xem</asp:label>
									</asp:linkbutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
