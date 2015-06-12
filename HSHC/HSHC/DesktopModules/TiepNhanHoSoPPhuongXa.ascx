<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TiepNhanHoSoPPhuongXa.ascx.vb" Inherits="HSHC.TiepNhanHoSoPPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc2" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/amlich.js"%>'></script>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript" src='http://code.jquery.com/jquery-1.9.0.js'></script>
<script language="javascript">
function checkHS(obj,chk)
{
	
	if(obj.value>=1&& chk.checked==false)
		{
			chk.checked=true;
		}		
}
function checkHSKemTheo(chk,obj1,obj2)
{
	
	if(chk.checked==true)
		{
			obj1.disabled=false;
			obj2.disabled=false;
		}
	else
		{
			obj1.disabled=true;
			obj2.disabled=true;
		}	
}
function checkNgayThucDia(chk,obj)
{
	if(chk.checked==false)
	{
		obj.value='';
	}
}
function FillDiaChi(obj1,obj2,objDuong,objPhuong)
{
		var strDuong;
		var strPhuong;
		var index;
		
		if ((objDuong.selectedIndex >= 0)&&(objPhuong.selectedIndex >=0))
		{
			strDuong=objDuong.options[objDuong.selectedIndex].text;
			if(strDuong == null)
				strDuong = "";
			strPhuong=objPhuong.options[objPhuong.selectedIndex].text;
			if(strPhuong == null)
				strPhuong = "";						
			index=strDuong.indexOf("-");
			strDuong=strDuong.slice(index+1,strDuong.length);
			index=strPhuong.indexOf("-");
			strPhuong=strPhuong.slice(index+1,strPhuong.length);
			//if(obj2.value=='')
				obj2.value=obj1.value+' '+strDuong+', '+strPhuong
			//+'//, Quận Tân Bình , TPHCM'
		}
}


function CheckNull()
{
	var i;
	var str;
	var obj;
	var obj1;
				
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		obj = window.document.forms(0).item(i);
		
			if (obj.ISNULL == 'NOTNULL' && obj.value == '')
			{
				alert('Ban chua dien du thong tin!')    
				obj.focus();
				return false;
			}
		
	}
	
	//Kiem tra duong	
	obj1 = document.all('<%=ddlMaDuong.ClientID%>');
	if (obj1.value == '') {
		alert('Ten duong khong duoc bo trong!');
		return false;
	}
	//Kiem tra phuong	
	//obj1 = document.getElementsByTagName("ComboBox").item("_ctl0__ctl0__ctl0_ddlMaPhuong");
	obj1 = document.all('<%=ddlMaPhuong.ClientID%>');
	if (obj1.value == '') {
		alert('Ten phuong khong duoc bo trong!');
		return false;
	}
	
	return true;
}
function btnKiemTra_Click()
{
	var objSoCMND = document.all('<%=txtSoCMND.ClientID%>');
	var objSoNha = document.all('<%=txtSoNha.ClientID%>');
	var objMaDuong = document.all('<%=ddlMaDuong.ClientID%>');
	var objMaPhuong = document.all('<%=ddlMaPhuong.ClientID%>');
	
	objSoCMND.value = trim(objSoCMND.value);
	objSoNha.value = trim(objSoNha.value);
	
	//kiểm tra đã nhập thông tin cần thiết để thực hiện kiểm tra chưa
	if (objSoCMND.value=='' && (objSoNha.value == '' || objMaDuong.value == '' || objMaPhuong.value ==''))
	{
		if (objSoNha.value != '' || objMaDuong.value != '' || objMaPhuong.value != '')
		{
			if (objMaPhuong.value == '')	objMaPhuong.focus();
			if (objMaDuong.value == '')		objMaDuong.focus();
			if (objSoNha.value == '')		objSoNha.focus();
		}
		else
			objSoCMND.focus();
		
		alert('Bạn phải nhập số CMND người đăng ký hoặc địa chỉ đăng ký để thực hiện kiểm tra!');
		return false;
	}
	//Open testing window
	
	CallWindowKiemTra('<%=ResolveUrl("~/CPKTQH/DesktopModules/ThongTinGiayCNDKKD.aspx")%>?SoCMND=' + objSoCMND.value + '&SoNha=' + objSoNha.value + '&Duong=' + objMaDuong.value + '&Phuong=' + objMaPhuong.value ,'Application',500,200);
	//return true;
	return false;
}
function isNumber(obj, isnotblank) //ki?m tra d? li?u nh?p vào ch? là ch? s?, không có ký t? d?c bi?t nào
{
	var so;
	so=(obj.value);
		if(isnotblank=='1')//1: khong cho trong <> duoc quyen bo trong
		if(so==''){
			alert('Không được bỏ trường này này!'); 
			obj.select();
			obj.focus();	
			return false;
		}
				
	if ( !(isInteger(so)) || (so.indexOf('-') >= 0) || (so.indexOf('+') >= 0) )
	{
		alert('Dữ liệu nhập phải là số nguyên dương'); 
		obj.select();
		obj.focus();	
		return false;
	}	
	else
	{
		return true;
	}
}
function CheckFile()
			{
				var file = document.all('<%=txt_OriginalName.ClientID%>');
				var extArray=new Array(".jpg",".jpeg",".gift",".tif",".doc",".xls",".docx",".xlsx",".pdf");
				if(file.value=='')
				{
					alert("Bạn hãy chọn tập tin.");					
					return false;
				}
				var filename=file.value;
				while(filename.indexOf("\\")!=-1)
				filename=filename.slice(filename.indexOf("\\")+1);
				//getting file extension
				var ext=filename.slice(filename.indexOf(".")).toLowerCase();
				
				//matching extension
				for(var i=0;i<extArray.length;i++)
				{
					if(extArray[i]==ext)
					{
						return true;
					}	
				}
				alert("Bạn chỉ được upload những tập tin có định dạng:" + (extArray.join("")));
				return false;
			}

</script>
<script language="javascript">
$(document).ready(function(){
	//var x=document.getElementById("");
	//alert(x.innerHTML);
	var e = document.getElementById("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo");
	var strUser = e.options[e.selectedIndex].text;
	//alert(strUser);
	
	document.getElementById("noidungloaihoso").innerHTML = strUser;
});
</script>
<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD height="24" width="100%">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_TopLeft" height="24" width="16"></td>
					<td class="QH_Khung_TopMid"><asp:label id="lblTieuDe" Width="100%" runat="server" cssclass="QH_Label_Title"></asp:label></td>
					<td class="QH_Khung_TopRight" height="24" width="16"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="98%">
							<TR>
								<TD height="5"><asp:label id="Label1" Width="100%" runat="server" CssClass="QH_LabelLeftBold">Thông tin hồ sơ</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD align="center">
												<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD vAlign="top" width="50%">
															<TABLE id="Table4" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD class="QH_ColLabel" width="35%">Loại hồ sơ<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaLoaiHoSo" Width="97%" runat="server" CssClass="QH_DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="35%">&nbsp;Loại hồ sơ<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><span id="noidungloaihoso" style="font-size: 11pt;"></span></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Họ tên người nộp<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtHoTenNguoiNop" Width="98%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
														<TD>
															<TABLE id="Table5" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD class="QH_ColLabel" width="25%">Số biên nhận</TD>
																	<TD class="QH_ColControl" width="75%" colSpan="4"><asp:label id="txtSoBienNhan" runat="server" ForeColor="Navy" Font-Bold="True"></asp:label></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="25%">Giới tính</TD>
																	<!--<TD class="QH_ColControl">
																		<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>-->
																	<TD class="QH_ColControl" width="18%"><asp:dropdownlist id="ddlGioiTinh" runat="server" CssClass="QH_DropDownList">
																			<asp:ListItem Selected="True"></asp:ListItem>
																			<asp:ListItem Value="1">Nam</asp:ListItem>
																			<asp:ListItem Value="0">Nữ</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD class="QH_ColLabel" width="29%">Số CMND(Hộ chiếu)</TD>
																	<TD class="QH_ColControl" colSpan="2"><asp:textbox id="txtSoCMND" Width="93%" runat="server" CssClass="QH_Textbox" MaxLength="20"></asp:textbox></TD>
																	<!--<TD width="8%"></TD> <!--
																			</TR>
																		</TABLE>
																	</TD>--></TR>
																<TR>
																	<TD class="QH_ColLabel">Thông tin liên lạc</TD>
																	<TD class="QH_ColControl" colSpan="4"><asp:textbox id="txtThongTinLienLac" Width="97%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
																	<!--<td></td>
																	<td></td>-->
																	<!--<td width="5%"></td>--></TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="center">
												<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD vAlign="top" width="50%">
															<TABLE id="Table7" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD height="5"><asp:label id="Label2" Width="100%" runat="server" cssclass="QH_LabelLeftBold">Địa chỉ đăng ký</asp:label></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="35%">Số nhà<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtSoNha" Width="98%" runat="server" CssClass="QH_Textbox" MaxLength="50"></asp:textbox></TD>
																</TR>
																<tr>
																	<TD class="QH_ColLabel">Tên phường<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><cc2:keysortdropdownlist id="ddlMaPhuong" Width="98%" runat="server" CssClass="QH_DropDownList"></cc2:keysortdropdownlist></TD>
																</tr>
																<tr>
																	<TD class="QH_ColLabel">Tên đường<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><cc2:keysortdropdownlist id="ddlMaDuong" Width="98%" runat="server" CssClass="QH_DropDownList"></cc2:keysortdropdownlist></TD>
																</tr>
																<TR>
																	<TD class="QH_ColLabel">Thường trú tại<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTru" Width="98%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
														<TD width="75%">
															<TABLE id="Table8" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD width="25%"></TD>
																	<TD>
																		<TABLE id="Table13" border="0" cellSpacing="0" cellPadding="0" width="100%">
																			<TR>
																				<TD class="QH_LabelLeftBold">Nội dung hồ sơ</TD>
																			</TR>
																			<TR>
																				<TD height="67"><asp:textbox id="txtNoiDungTrichYeu" Width="97%" runat="server" CssClass="QH_Textbox" TextMode="MultiLine"
																						Rows="4"></asp:textbox></TD>
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
											<TD height="5"><asp:label id="Label3" Width="100%" runat="server" cssclass="QH_LabelLeftBold">Thông tin nhận</asp:label></TD>
										</TR>
										<TR>
											<TD align="center">
												<TABLE id="Table14" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD vAlign="top" width="50%">
															<TABLE id="Table15" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD class="QH_ColLabel" width="35%">Ngày nhận<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtNgayNhan" Width="70px" runat="server" CssClass="QH_Textbox" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayNhan" CssClass="CommandButton" Runat="server">
																			<asp:image id="imgNgayNhan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
																		</asp:hyperlink></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Ngày hợp lệ<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtNgayHopLe" Width="70px" runat="server" CssClass="QH_Textbox" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayHopLe" CssClass="CommandButton" Runat="server">
																			<asp:image id="imgNgayHopLe" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
																		</asp:hyperlink></TD>
																</TR>
															</TABLE>
														</TD>
														<TD vAlign="top">
															<TABLE id="Table16" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD class="QH_ColLabel" width="22%">Số ngày GQ<FONT color="#ff0000" size="2">*</FONT></TD>
																	<TD class="QH_ColControl" width="22%"><asp:textbox id="txtSoNgayGiaiQuyet" Width="30px" runat="server" CssClass="QH_TextRight" MaxLength="4"></asp:textbox>&nbsp;<span class="QH_LabelNote">( Ngày 
                                )</span></TD>
																	<TD width="25%"></TD>
																	<TD width="22%"></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel" width="22%">Ngày hẹn trả</TD>
																	<TD class="QH_ColControl" width="22%"><asp:textbox id="txtNgayHenTra" Width="70px" runat="server" CssClass="QH_Textbox" ReadOnly="True"></asp:textbox></TD>
																	<TD class="QH_ColLabel" width="25%"><asp:checkbox id="chkNTD" runat="server"></asp:checkbox>Ngày 
																		thực địa</TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtNgayThucDia" Width="70px" runat="server" CssClass="QH_Textbox"></asp:textbox><asp:textbox id="txtSoNgayThucDia" Width="0" runat="server" CssClass="QH_TextRight" MaxLength="4"
																			ReadOnly="true"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table9" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD vAlign="top" width="60%">
															<!--datagrid-->
															<TABLE id="Table100" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD><asp:label id="Label4" Width="100%" runat="server" CssClass="QH_LabelLeftBold">Các loại chứng từ đã có trong hồ sơ</asp:label></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE id="Table99" class="QH_Table" cellSpacing="0" cellPadding="0" width="100%">
																			<TR>
																				<TD class="QH_DataGridHeader" width="31">Stt</TD>
																				<TD class="QH_DataGridHeader">Tên hồ sơ</TD>
																				<TD class="QH_DataGridHeader" width="61">B.chính</TD>
																				<TD class="QH_DataGridHeader" width="61">B.sao</TD>
																				<TD class="QH_DataGridHeader" width="51"><asp:checkbox id="chkAll" runat="server" BorderStyle="None" Height="2px"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																				</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD width="98%">
																		<DIV style="TABLE-LAYOUT: fixed; HEIGHT: 160px; OVERFLOW: scroll"><asp:datagrid id="dgdHoSo" Width="100%" runat="server" CssClass="QH_DataGridTopBottom" ShowHeader="false"
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
																<tr>
																<tr>
																	<td class="QH_LabelLeftBold">Chọn tập tin đính kèm&nbsp; <INPUT id="txt_OriginalName" size="30" type="file" name="Upload" runat="server">
																		<asp:button id="cmdOK" runat="server" Text=" Chọn "></asp:button></td>
																</tr>
																<tr>
																	<td>&nbsp;&nbsp;</td>
																</tr>
																<tr>
																	<td class="QH_LabelLeftBold">Danh sách file đính kèm</td>
																</tr>
																<tr>
																	<td><asp:datagrid id="dgdUpload" Width="100%" runat="server" CssClass="QH_DataGrid" BorderStyle="Solid"
																			OnItemCommand="ItemCommand" AutoGenerateColumns="False" BorderColor="#D3E0FA">
																			<HeaderStyle CssClass="QH_DatagridHeader" ForeColor="#00008B"></HeaderStyle>
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<Columns>
																				<asp:BoundColumn visible="False" DataField="AttachFileID" HeaderText="ItemID"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="STT">
																					<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Center" width="5%"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="Label5" Enabled="True" runat="server" Text='<%# dgdUpload.CurrentPageIndex*dgdUpload.PageSize + dgdUpload.Items.Count+1  %>' />
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="FileName" HeaderText="Tên tập tin">
																					<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="Toàn văn">
																					<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Center" width="15%"></ItemStyle>
																					<ItemTemplate>
																						<asp:HyperLink ImageURL="../../images/clip.gif" NavigateUrl=<%# "javascript:ShowAttachedFile('" & Request.ApplicationPath & DataBinder.Eval(Container.DataItem, "FilePath") & "','" & DataBinder.Eval(Container.DataItem, "FileName") & "')" %> id="HyperLink1" runat="server" />
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Xóa">
																					<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Center" width="5%"></ItemStyle>
																					<ItemTemplate>
																						<asp:imagebutton ID="ImgDelete" ImageUrl="../../images/delete.gif" Runat="server" CommandName="DeleteFileAttached" />
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></td>
																</tr>
													</TR>
												</TABLE>
												<!--end datagrid--></TD>
											<TD width="75%">
												<TABLE id="Table11" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD width="6%"></TD>
														<TD vAlign="top">
															<TABLE id="Table12" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD class="QH_LabelLeftBold">Nội dung khác</TD>
																</TR>
																<TR>
																	<TD><asp:textbox id="txtNoiDungKhac" Width="97%" runat="server" CssClass="QH_Textbox" TextMode="MultiLine"
																			Rows="7"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" width="4" align="center"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="center"><asp:label id="lblBarcode" runat="server" Font-Names="Free 3 of 9 Extended" Font-Size="33pt"></asp:label></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="center"><br>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td height="5" colSpan="2"></td>
										</tr>
										<TR>
											<TD vAlign="middle" width="100%" colSpan="2" align="center">
												<table>
													<tr>
														<td><asp:linkbutton id="btnKiemTra" runat="server" CssClass="QH_Button" Visible="False">Kiểm tra</asp:linkbutton></td>
														<td><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton></td>
														<td><asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton></td>
														<td id="tdInBienNhan" runat="server"><asp:linkbutton id="btnInBienNhan" runat="server" CssClass="QH_Button">In biên nhận</asp:linkbutton></td>
														
														<td><asp:linkbutton id="btnTraHoSo" runat="server" CssClass="QH_Button" >In phiếu chuyển</asp:linkbutton></td>
														<td><asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></td>
													</tr>
												</table>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<EM>Chú ý:&nbsp;
							<asp:hyperlink id="lnkDownloadFont" runat="server" ToolTip="Chọn nơi lưu font là C:\Windows\Fonts hoặc C:\WinNT\Fonts"
								NavigateUrl="~/BARCODE/FRE3OF9X.TTF">download font barcode</asp:hyperlink></EM></td>
				</tr>
			</table>
			<asp:textbox id="txtHoSoTiepNhanID" Width="0px" runat="server" CssClass="QH_Textbox" Visible="true"></asp:textbox>
			<asp:textbox id="txtMaNguoiNhan" Width="0px" runat="server" CssClass="QH_Textbox" Visible="true"></asp:textbox>
			<asp:textbox id="txtMaLinhVuc" Width="0px" runat="server" CssClass="QH_Textbox" Visible="true"></asp:textbox></TD>
		<td class="QH_Khung_Right" width="16">
			<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td></td>
				</tr>
				<tr height="141">
					<td class="QH_Khung_Right1"></td>
				</tr>
			</TABLE>
		</td>
	</TR>
</TABLE>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter></TD></TR></TABLE>
<asp:textbox id="txtHoSoTiepNhanID_Temp" Width="0px" runat="server" CssClass="QH_Textbox" Visible="False"></asp:textbox>
<asp:textbox id="txtAttachFileID" Width="0px" runat="server" CssClass="QH_Textbox" Visible="False"></asp:textbox>
