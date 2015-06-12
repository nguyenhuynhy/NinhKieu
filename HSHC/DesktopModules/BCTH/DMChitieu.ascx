<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DMChitieu.ascx.vb" Inherits="HSHC.DMChitieu" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript" src="inc/suycCalendar.js"></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function delconfirm(){
	result = confirm("Bạn có chắc chắn không ?");
	return result;
}
//---------- Check Chon 
function checkParent(txtMaCT)
{	
	var strURLNganhKD = 'DesktopModules/BCTH/DanhMuc_Chon.aspx';
	if (txtMaCT.value==null||txtMaCT.value=='')
		{
			CallWindow(strURLNganhKD,'Application',Width=700);
			return ;
		}
	if (isParent(txtMaCT)==true)
		{
			alert('Không được đổi cha của chỉ tiêu cha.');
			return false;
		}else
		{		
			CallWindow(strURLNganhKD,'Application',Width=700);
		}
	
}
//- Ham xoa chi tieu cha
function isParent(obj)
{
	var grid,rowend,valueObj;	
	valueObj =obj.value;
	//alert('MaCT :'+value);
	grid = "<%=dgdDanhSach.ClientID%>";
	rowend = eval('document.forms[0].all("<%=dgdDanhSach.ClientID%>")').rows.length;
	for (var i =3;i<rowend +1 ;i++)
		{
			NameOfTextgridMaCha=grid + "__ctl" + i + "_" + "txtgridMaCha";			
			ValueOfTxtgridMaCha = eval('document.forms[0].all("' + NameOfTextgridMaCha + '")').value;			
			//alert('Ma : '+valueObj + '.Value Text: '+ValueOfTxtgridMaCha);
			if (valueObj==ValueOfTxtgridMaCha)
			{				
				return true;
			}
		}
	return false;	
}
//-----------------------------------
function checkStatus(chkTT,txtMaCT)
{
	var grid,rowend,valueMaCT;
	
	valueMaCT = txtMaCT.value;
	//alert('MaCT :'+valueMaCT);
	grid = "<%=dgdDanhSach.ClientID%>";
	rowend = eval('document.forms[0].all("<%=dgdDanhSach.ClientID%>")').rows.length;
	
	if (chkTT.checked==false)
	{		
		for (var i =3;i<rowend +1 ;i++)
		{
			NameOfTextgridMaCha=grid + "__ctl" + i + "_" + "txtgridMaCha";
			
			ValueOfTxtgridMaCha = eval('document.forms[0].all("' + NameOfTextgridMaCha + '")').value;
			//alert(ValueOfTxtgridMaCha);
			if (valueMaCT==ValueOfTxtgridMaCha)
			{
				alert('Không thể xoá chỉ tiêu cha!');
				chkTT.checked=true;				
				return false;
			}
		}
		return true;	
	}	
}

function checkIsSum(chkIsSum,chkIsData)
{
	if (chkIsSum.checked==true)
	{
		chkIsData.checked=true;		
	}
	if (chkIsData.checked==false)
	{
		chkIsSum.checked=false;		
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
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">DANH MỤC CHỈ TIÊU</asp:label>
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
						<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td align="center">
									<table cellSpacing="0" cellPadding="0" width="90%" align="center">
										<tr>
											<td height="5"></td>
										</tr>
										<tr>
											<td align="center">
												<table class="QH_Content_Filter" id="table0" cellSpacing="0" cellPadding="0" width="100%"
													runat="server">
													<tr>
														<td height="10"></td>
													</tr>
													<tr>
														<td vAlign="top" width="55%">
															<table cellSpacing="0" cellPadding="0" width="100%">
																<tr>
																	<td class="QH_Collabel" width="30%">Lọc theo nhóm chỉ tiêu</td>
																	<td width="70%"><asp:dropdownlist id="ddlNhomChiTieu" CssClass="QH_DropDownList" Runat="server" Width="70%" AutoPostBack="True"></asp:dropdownlist></td>
																</tr>
																<tr>
																	<td class="QH_Collabel" width="30%">Tên chỉ tiêu</td>
																	<td width="70%"><asp:textbox id="txtTenChiTieu" CssClass="QH_textBox" Runat="server" Width="70%"></asp:textbox></td>
																</tr>
																<tr>
																	<td class="QH_Collabel" width="30%">Thuộc chỉ tiêu</td>
																	<td width="70%"><asp:textbox id="txtTen" CssClass="QH_TextBox" Runat="server" Width="70%" ReadOnly="True"></asp:textbox><asp:textbox id="txtMaCha" CssClass="QH_TextBox" Runat="server" Width="0px" Visible="true"></asp:textbox>&nbsp;<asp:linkbutton id="btnChonCT" CssClass="QH_Link_Button" Runat="server">Chọn</asp:linkbutton></td>
																</tr>
																<tr id="trDVT" runat="server">
																	<td class="QH_Collabel">Ðơn vị tính</td>
																	<td><asp:dropdownlist id="ddlMaDonViTinh" CssClass="QH_Dropdownlist" Runat="server" Width="30%"></asp:dropdownlist></td>
																</tr>
															</table>
														</td>
														<td vAlign="top" width="45%">
															<table class="QH_LoaiHS" cellSpacing="0" cellPadding="0" width="92%">
																<tr>
																	<td width="70%"><asp:label id="Label3" CssClass="QH_label" Runat="server">Là chỉ tiêu có số liệu</asp:label></td>
																	<td><asp:checkbox id="chkIsData" CssClass="QH_ChkBox" Runat="server" Checked="True"></asp:checkbox></td>
																</tr>
																<tr id="trCongCon" runat="server">
																	<td><asp:label id="Label4" CssClass="QH_label" Runat="server">Cộng các chỉ tiêu con</asp:label></td>
																	<td><asp:checkbox id="chkIsSum" CssClass="QH_ChkBox" Runat="server"></asp:checkbox></td>
																</tr>
																<tr>
																	<td><asp:label id="Label8" Runat="server" cssclass="QH_label">Tình trạng</asp:label></td>
																	<td><asp:checkbox id="chkTinhTrang" CssClass="QH_ChkBox" Runat="server" Checked="True"></asp:checkbox></td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td vAlign="top" width="60%">
															<table cellSpacing="0" cellPadding="0" width="100%">
																<tr>
																	<td class="QH_Collabel" width="30%">Diễn giải
																	</td>
																	<td width="70%"><asp:textbox id="txtDienGiai" width="70%" CssClass="QH_TextBox" Runat="server" Rows="2" TextMode="MultiLine"></asp:textbox></td>
																</tr>
															</table>
														</td>
														<td vAlign="middle" align="center" width="30%"><asp:imagebutton id="btnThemMoi" CssClass="QH_Button" runat="server" AlternateText="Lưu chỉ tiêu"
																ImageUrl="../../Images/btn_CapNhat.gif"></asp:imagebutton><asp:imagebutton id="btnBoqua" CssClass="QH_Button" runat="server" AlternateText="Nhấn vào đây để nhập một chỉ tiêu mới"
																ImageUrl="../../IMAGES/btn_Themmoi.gif"></asp:imagebutton><asp:imagebutton id="btnIn" CssClass="QH_button" Runat="server" ImageUrl="../../Images/btn_XuatExcel.gif"></asp:imagebutton><asp:imagebutton id="hplXem" CssClass="QH_Button" Runat="server" AlternateText="Open file...." ImageUrl="../../Images/btn_MoFile.gif"></asp:imagebutton>
															<!--Text box an--><asp:textbox id="txtCap" Runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaChiTieu" Runat="server" Width="0px"></asp:textbox><asp:textbox id="txtReLoad" Runat="server" Width="0px"></asp:textbox>
															<!--End text box an--></td>
													</tr>
													<tr>
														<td height="10"></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td width="100%">
												<table width="99%">
													<tr>
														<td align="right" width="97%"><asp:label id="label7" CssClass="QH_ColLabel" Runat="server">Số dòng hiển thị&nbsp;</asp:label><asp:textbox id="txtSoDongHienThi" CssClass="QH_TextRight" Runat="server" Width="50px" AutoPostBack="True"
																MaxLength="3"></asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center"><asp:datagrid id="dgdDanhSach" Runat="server" CssClass="QH_DataGrid" Width="98%" CellPadding="3"
													AllowPaging="True" AllowSorting="True" autogeneratecolumns="false">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Lên" ItemStyle-Wrap="False">
															<ItemStyle Width="5%"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton ID="btnMoveUp" Runat="server" CommandName="MoveUp" ImageUrl="../../images/btn_upicon.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Xuống">
															<ItemStyle Width="5%"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton ID="btnMoveDown" Runat="server" CommandName="MoveDown" ImageUrl="../../images/save.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Ma" HeaderText="Mã " Visible="false">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Ten" HeaderText="Tên chỉ tiêu " Visible="True">
															<HeaderStyle Width="30%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TenDonViTinh" HeaderText="Ðơn vị tính" Visible="True">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Cộng chỉ tiêu con">
															<ItemStyle Width="10%"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="Checkbox2" runat=server Checked='<%# CBool(DataBinder.Eval(Container.DataItem,"IsSum")) %>' Enabled=False>
																</asp:CheckBox>
																<asp:TextBox ID="txtgridMaCha" Width=0px Runat=server Text='<%#DataBinder.Eval(Container,"DataItem.MaCha")%>'>
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Có số liệu">
															<ItemStyle Width="10%"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox ID="chk3" Runat=server Checked='<%# CBool(Databinder.Eval(Container.DataItem,"IsData"))%>' Enabled=False>
																</asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Chọn">
															<ItemStyle Width="5%"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton ID="btnChon" Runat="server" CommandName="Chon" ImageUrl="../../images/btn_update.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="5"></td>
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
