<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChiTieuLinhVuc.ascx.vb" Inherits="HSHC.ChiTieuLinhVuc" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript" src="inc/suycCalendar.js"></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function AllCheck(){
var obj;
for (i=0;i<window.document.forms(0).length;i++)
	{
		obj = window.document.forms(0).item(i);
		
		if (window.document.forms(0).item(i).id.indexOf('chkChon') != -1)
		{
					obj.checked = true;		
		}
	}
	return false;
}
function AllNoCheck(){
var obj;
for (i=0;i<window.document.forms(0).length;i++)
	{
		obj = window.document.forms(0).item(i);
		
		if (window.document.forms(0).item(i).id.indexOf('chkChon') != -1)
		{
					obj.checked = false;		
		}
	}
	
	return false;	
}
function checkParent(chkCon)	
{
	var obj1;
	var obj2;
	var chkCha;
	var flag;
	//alert(chkCon);
	if (chkCon!=null)
	{
		flag = eval('document.forms[0].all("' + chkCon + '")').checked;	
	}
	if (flag == true)
	{
		chkCha=findParent(chkCon);
		if (chkCha!=null)
		{
			eval('document.forms[0].all("' + chkCha + '")').checked=true;			
			checkParent(chkCha);
		}
	}	
}

function findParent(chkCon)
{
	var obj;
	var i;
	var index;
	var rowEnd;
	var gridID;
	var Macha;
	var IsSum;
	var IsData;
	var objCha;
	
	gridID = "<%=dgdDanhSach.ClientID%>";
	rowEnd = eval('document.forms[0].all("<%=dgdDanhSach.ClientID%>")').rows.length;
	var NameOfTextMaCha;
	var NameOfAllChk;
	var value;
	
	for(i=rowEnd;i>0;i--)
	{
				//Lay vi tri cua chkCon
				NameOfAllChk = gridID + "__ctl" + i + "_" + "chkChon";
				//alert(NameOfAllChk);
				if (NameOfAllChk == chkCon) 
				{
					//Ten cua txtMacha
					var NameOfTxtMaCha;
					NameOfTxtMaCha=gridID + "__ctl" + i + "_" + "txtMaCha";
					//alert(NameOfTxtMaCha);
					//lay cac gia tri: Macha
					Macha = eval('document.forms[0].all("' + NameOfTxtMaCha + '")').value;
					//alert(Macha);					
					for(j=i-1;j>=3;j--)	
					{							
							var NameOfTxtMaCT;
							var valueOfMaCT;
							//Dung label
							
							NameOfTxtMaCT=gridID + "__ctl" + j + "_" + "txtMaCT";
							
							valueOfMaCT = eval('document.forms[0].all("' + NameOfTxtMaCT + '")').value;
							if (valueOfMaCT==Macha)
							{
								// lay cac gia tri IsSum 
								var NameOfTxtIsSum;
								var ValueOfTxtIsSum;
								NameOfTxtIsSum=gridID + "__ctl" + j + "_" + "txtIsSum";
								ValueOfTxtIsSum = eval('document.forms[0].all("' + NameOfTxtIsSum + '")').value;
								
								// Lay gia tri cua txt IsData
								var NameOfTxtIsData;
								var ValueOfTxtIsData;
								NameOfTxtIsData=gridID + "__ctl" + j + "_" + "txtIsData";
								ValueOfTxtIsData = eval('document.forms[0].all("' + NameOfTxtIsData + '")').value;
								
								// Kiem tra gia cac gia tri ISSum va IsData
									if (ValueOfTxtIsSum=='1' && ValueOfTxtIsData=='1')
									{
										// Tra lai ID cua chkCha
									
										var NameOfChkCha;
										NameOfChkCha=gridID + "__ctl" + j + "_" + "chkChon";
										objCha = NameOfChkCha;
										
									}
							}
					
					}
				
			}
					
	}
	return objCha;
	
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
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">CẬP NHẬT CHỈ TIÊU CHO ĐƠN VỊ</asp:label>
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
						<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
							<tr>
								<td align="center">
									<table class="QH_table" cellSpacing="0" cellPadding="0" border="0" width="90%" align="center">
										<tr>
											<td height="5"></td>
										</tr>
										<tr>
											<td width="60%" align="center">
												<table id="table1" class="QH_Content_Filter" width="90%" align="center" runat="server">
													<tr>
														<td height="5"></td>
													</tr>
													<tr>
														<td width="90%" align="center"><asp:Label Width="20%" Runat="server" id="Label1">Chọn đơn vị báo cáo</asp:Label>&nbsp;&nbsp;<asp:dropdownlist id="ddlDonVi" CssClass="QH_DropDownList" Width="30%" Runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;
															<asp:Label Width="15%" Runat="server" id="Label2">Chọn chỉ tiêu</asp:Label><asp:dropdownlist id="ddlMaChiTieu" CssClass="QH_dropdownlist" Runat="server" Width="30%"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;
														</td>
														<td width="10%"><asp:imagebutton id="btnLoc" CssClass="QH_Button" Runat="server" ImageUrl="../../images/btn_ThemMoi.gif "></asp:imagebutton></td>
													</tr>
													<tr>
														<td height="3"></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center">
												<table width="98%">
													<tr>
														<td align="left" width="50%"><asp:linkbutton CssClass="QH_Link_Button" id="btnChonTatCa" Runat="server">Chọn tất cả</asp:linkbutton>&nbsp; 
															::&nbsp;<asp:linkbutton CssClass="QH_Link_Button" id="btnBoChon" Runat="server">Bỏ chọn</asp:linkbutton></td>
														<td align="right" width="50%"><asp:label id="label7" CssClass="QH_ColLabel" Runat="server">Số dòng hiển thị&nbsp;</asp:label><asp:textbox id="txtSoDongHienThi" CssClass="QH_TextRight" Runat="server" AutoPostBack="True"
																Width="50px" MaxLength="3"></asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Runat="server" Width="98%" autogeneratecolumns="false"
													AllowSorting="True" AllowPaging="True" CellPadding="3">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Chọn" HeaderStyle-HorizontalAlign="Left">
															<ItemStyle Width="3%"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkChon" runat="server" Enabled="True"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="STT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
															<ItemStyle Width="3%"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="Label3" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
																<asp:TextBox ID="txtMaCT" Width=0px Runat=server CssClass="QH_Labelb" Text='<%# DataBinder.Eval(Container,"DataItem.Ma") %>'>
																</asp:TextBox>
																<asp:TextBox ID="txtMaCha" Width="0px" Runat=server CssClass="QH_TextBox" Text='<%#DataBinder.Eval(container,"DataItem.MaCha")%>'>
																</asp:TextBox>
																<asp:TextBox ID="txtIsSum" Width=0px Runat=server CssClass="QH_TextBox" Text='<%#DataBinder.Eval(container,"DataItem.IsSum")%>'>
																</asp:TextBox>
																<asp:TextBox ID="txtIsDaTa" Width="0px" Runat=server CssClass="QH_TextBox" Text='<%#DataBinder.Eval(container,"DataItem.IsDaTa")%>'>
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Ten" HeaderText="Tên" Visible="True" HeaderStyle-HorizontalAlign="Left">
															<HeaderStyle Width="30%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TenDonViTinh" HeaderText="Đơn vị tính" Visible="True" HeaderStyle-HorizontalAlign="Left">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Cấp" Visible="False">
															<ItemStyle Width="0%"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox ID="txtCap" Runat=server CssClass="QH_TextBox" Text='<%#DataBinder.Eval(container,"DataItem.Cap")%>'>
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Mã gốc" Visible="False">
															<ItemStyle Width="0%"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox ID="txtMaGoc" Runat=server CssClass="QH_TextBox" Text='<%#DataBinder.Eval(container,"DataItem.MaGoc")%>'>
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td height="5"></td>
										</tr>
										<tr>
											<td align="center"><asp:imagebutton id="btnThemMoi" CssClass="QH_Button" runat="server" ImageUrl="../../Images/btn_CapNhat.gif"></asp:imagebutton></td>
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
