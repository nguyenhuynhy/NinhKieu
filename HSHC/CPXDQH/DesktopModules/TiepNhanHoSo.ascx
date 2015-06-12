<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TiepNhanHoSo.ascx.vb" Inherits="CPXD.TiepNhanHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="ChuDauTuList" Src="ChuDauTuList.ascx" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
</SCRIPT>
<script language="javascript">
function checkRequire(id){
	var obj;
	obj = document.getElementById(id);
	if(obj.value == "")
	{
		alert('Ban chua dien du thong tin!')    
		obj.focus();
		return false;
	}		
	return true;
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="center">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="90%" border="0">
				<TR>
					<TD><asp:label id="lblTieuDe" cssclass="QH_Label_Title" runat="server" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD height="5"><asp:label id="Label1" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Thông tin h? so</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" width="50%">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="35%">Lo?i c?p gi?y CN<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD width="*"><asp:dropdownlist id="ddlMaLoaiHoSo" runat="server" Width="90%" CssClass="QH_DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">H? tên ngu?i n?p<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:textbox id="txtHoTenNguoiNop" runat="server" Width="90%" CssClass="QH_Textbox"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Thu?ng trú t?i<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:textbox id="txtDiaChiThuongTru" runat="server" Width="90%" CssClass="QH_Textbox"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="25%">S? biên nh?n</TD>
											<TD width="*"><asp:textbox id="txtSoBienNhan" runat="server" Width="40%" CssClass="QH_Textbox" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="25%">S? CMND</TD>
											<TD>
												<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="left" width="40%" colSpan="1" rowSpan="1"><asp:textbox id="txtSoCMND" runat="server" Width="100%" CssClass="QH_Textbox" MaxLength="9"></asp:textbox></TD>
														<TD class="QH_ColLabel" width="30%" colSpan="1" rowSpan="1">Gi?i tính</TD>
														<TD align="right"><asp:dropdownlist id="ddlGioiTinh" runat="server" CssClass="QH_DropDownList">
																<asp:ListItem Selected="True"></asp:ListItem>
																<asp:ListItem Value="1">Nam</asp:ListItem>
																<asp:ListItem Value="0">N?</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD width="10%"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Thông tin liên l?c</TD>
											<TD><asp:textbox id="txtThongTinLienLac" runat="server" Width="90%" CssClass="QH_Textbox"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td><asp:label id="lblThemChuDauTu" CssClass="QH_LabelLeftBold" Runat="server">Ch? d?u tu</asp:label></td>
				</tr>
				<tr>
					<td>
						<uc1:ChuDauTuList id="ctrlChuDauTuList" runat="server"></uc1:ChuDauTuList>
					</td>
				</tr>
				<TR>
					<TD align="center">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" width="50%">
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD height="5"><asp:label id="Label2" cssclass="QH_LabelLeftBold" runat="server" Width="100%">Ð?a ch? dang ký</asp:label></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="35%">S? nhà<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:textbox id="txtSoNha" runat="server" Width="90%" CssClass="QH_Textbox" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Tên du?ng<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:dropdownlist id="ddlMaDuong" runat="server" Width="90%" CssClass="QH_DropDownList"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Tên phu?ng<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:dropdownlist id="ddlMaPhuong" runat="server" Width="90%" CssClass="QH_DropDownList"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="75%">
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="25%"></TD>
											<TD>
												<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_LabelLeftBold">N?i dung h? so</TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtNoiDungTrichYeu" runat="server" Width="90%" CssClass="QH_Textbox" Rows="4"
																TextMode="MultiLine"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="5"><asp:label id="Label3" cssclass="QH_LabelLeftBold" runat="server" Width="100%">Thông tin nh?n</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" width="50%">
									<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="35%">Ngày nh?n<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:textbox id="txtNgayNhan" runat="server" Width="40%" CssClass="QH_Textbox" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgNgayNhan" runat="server" CssClass="QH_IMAGEBUTTON" ImageUrl="~/images/calendar.gif"
													AlternateText="Ch?n ngày tháng nam"></asp:image></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày h?p l?<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:textbox id="txtNgayHopLe" runat="server" Width="40%" CssClass="QH_Textbox" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgNgayHopLe" runat="server" CssClass="QH_IMAGEBUTTON" ImageUrl="~/images/calendar.gif"
													AlternateText="Ch?n ngày tháng nam"></asp:image></TD>
										</TR>
										<tr>
											<td class="QH_ColLabel">Ð?a ch? cu</td>
											<td><asp:textbox id="txtDiaChiCu" runat="server" Width="90%" CssClass="QH_Textbox" MaxLength="500"></asp:textbox></td>
										</tr>
									</TABLE>
								</TD>
								<TD vAlign="top">
									<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="25%">S? ngày GQ<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD><asp:textbox id="txtSoNgayGiaiQuyet" runat="server" Width="20%" CssClass="QH_TextRight" MaxLength="4"></asp:textbox>&nbsp;( 
												Ngày )</TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày h?n tr?</TD>
											<TD><asp:textbox id="txtNgayHenTra" runat="server" Width="40%" CssClass="QH_Textbox" ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" width="60%">
									<!--datagrid-->
									<TABLE id="Table100" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD><asp:label id="Label4" runat="server" Width="100%" CssClass="QH_LabelLeftBold">Các lo?i ch?ng t? dã có trong h? so</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table99" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_TableCol" width="31">Stt</TD>
														<TD class="QH_TableCol" width="*">Tên h? so</TD>
														<TD class="QH_TableCol" width="61">B.chính</TD>
														<TD class="QH_TableCol" width="61">B.sao</TD>
														<TD class="QH_TableCol" width="51"><asp:checkbox id="chkAll" runat="server" BorderStyle="None" Height="2px"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD width="98%">
												<DIV style="TABLE-LAYOUT: fixed; OVERFLOW: scroll; HEIGHT: 160px"><asp:datagrid id="dgdHoSo" runat="server" Width="100%" CssClass="QH_DataGridTopBottom" ShowHeader="false"
														AutoGenerateColumns="False">
														<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
														<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemStyle Width="33px"></ItemStyle>
																<ItemTemplate>
																	<asp:Label id="lblStt" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# dgdHoSo.CurrentPageIndex*dgdHoSo.PageSize + dgdHoSo.Items.Count+1 %>">
																	</asp:Label>
																	<asp:Label id="lblMaHoSo" Visible="False" cssclass="QH_ColLabelMiddle" runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataItem.MaHoSoKemTheo") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:Label id="lblTenHoSo" cssclass="QH_LabelLeft" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TenHoSoKemTheo") %>' Width="100%">
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle Width="64px"></ItemStyle>
																<ItemTemplate>
																	<asp:textbox id="txtSoBanChinh" cssclass="QH_TextRight" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoBanChinh") %>' Width="100%">
																	</asp:textbox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle Width="64px"></ItemStyle>
																<ItemTemplate>
																	<asp:textbox id="txtSoBanSao" cssclass="QH_TextRight" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoBanSao") %>' Width="100%">
																	</asp:textbox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center" Width="38px"></ItemStyle>
																<ItemTemplate>
																	<asp:checkbox id="chkXoa" runat="server" enabled="true" checked='<%# DataBinder.Eval(Container, "DataItem.Active") %>'>
																	</asp:checkbox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Center" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
											</TD>
										</TR>
									</TABLE>
									<!--end datagrid--></TD>
								<TD width="75%">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="6%"></TD>
											<TD vAlign="top">
												<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="QH_LabelLeftBold">N?i dung khác</TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtNoiDungKhac" runat="server" Width="90%" CssClass="QH_Textbox" Rows="7" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="center" width="4" colSpan="1" rowSpan="1"></TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="center" height="50"></TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="center" height="4"></TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="center"><asp:imagebutton id="btnCapNhat" runat="server" CssClass="QH_Button" ImageUrl="~\images\btn_CapNhat.gif"></asp:imagebutton><asp:imagebutton id="btnThemMoi" runat="server" CssClass="QH_Button" ImageUrl="~\images\btn_ThemMoi.gif"></asp:imagebutton><asp:image id="btnInBienNhan" runat="server" CssClass="QH_Button" ImageUrl="~\images\btn_InBienNhan.gif"></asp:image></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px" CssClass="QH_Textbox" Visible="true"></asp:textbox><asp:textbox id="txtMaNguoiNhan" runat="server" Width="0px" CssClass="QH_Textbox" Visible="true"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Width="0px" CssClass="QH_Textbox" Visible="true"></asp:textbox></TD>
	</TR>
</TABLE>
