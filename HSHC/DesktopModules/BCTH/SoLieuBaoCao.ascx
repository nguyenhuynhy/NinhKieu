<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SoLieuBaoCao.ascx.vb" Inherits="SoLieuBaoCao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language="javascript">	

function sumChiTieu(txtSL)
{
	// Cong toi chi tieu cha.
	// - Lap tu cuoi grid len dau
	// - Neu la cha va thoa dieu kien issum==1 va isdata==1 
	//	va co chi tieu con thi:
	//	- Di tu i len tren dau. 	
	var txtCha,txtCon,objCha,objCon,kq;	
	valueCon = eval('document.forms[0].all("' + txtSL + '")').value;	
	objCon=document.getElementById(txtSL);
	//Kiem tra so lieu nhap vao phai la so	
	
	//CheckData(objCon.value);
	
	//alert(objCon.value);
		
	if(!CheckData(objCon))
	{
		objCon.value=0;
		objCon.focus;
		//alert('SumChiTieu')
		return false;		
	}	
	txtCha = findParent(txtSL);
	objCha = document.getElementById(txtCha);
	if (objCha!=null)	
	{		
		
		//CheckDataSum(objCon,objCha,objCha);
		
		objCha.value =convertSoVN(sumAllChild(txtSL));				
		
		//CheckData(objCha);
		txtSL=txtCha;		
		sumChiTieu(txtSL);		
	}
	return true;	
}
//==========================
// Cong tat ca cac chi tieu con cua  txtSL
function sumAllChild(txtSL)
{
	var i,rowEnd,j,NameOfTxtCurrMaCha,CurrMacha;
	var NameOfTxtMaCha,Macha;
	var gridID;
	var total;
	total=0;
	
	gridID = "<%=dgdDanhSach.ClientID%>";
	rowEnd = eval('document.forms[0].all("<%=dgdDanhSach.ClientID%>")').rows.length;
	//alert(rowEnd);
	for (i=3;i<rowEnd+1;i++)
	{			
		NameOfTextSLCurr = gridID + "__ctl" + i + "_" + "txtSoLieu";
		//alert(NameOfTextSLCurr);
		if (NameOfTextSLCurr == txtSL) 
		{
				
				NameOfTxtCurrMaCha=gridID + "__ctl" + i + "_" + "txtMaCha";
				CurrMacha = eval('document.forms[0].all("' + NameOfTxtCurrMaCha + '")').value;
				//alert("Ma cha hien tai i = " + i + ". " +CurrMacha);
				for (j=3;j<rowEnd+1;j++)
				{
					if (j!=i)
					{
						NameOfTxtMaCha=	gridID + "__ctl" + j + "_" + "txtMaCha";
						Macha =	eval('document.forms[0].all("' + NameOfTxtMaCha + '")').value;
						//alert('cha: ');
						//alert("Ma cha tim thay j= " + j + Macha);						
						if (CurrMacha == Macha)
						{								
								var NameOfTextSL,objSL,ValueOfTextSL;
								
								NameOfTextSL=gridID + "__ctl" + j + "_" + "txtSoLieu";
								
								ValueOfTextSL = eval('document.forms[0].all("' + NameOfTextSL + '")').value;
								//alert(" ValueOfTextSL " + ValueOfTextSL);
								objSL = document.getElementById(NameOfTextSL);
								//alert(" objSL " + objSL);								
								var so;
								so=objSL.value;
								if (so==""|| so==null){
									so=0;
								 }else
								 {							 
									//alert(" so " + so);
									so=convertSo(so);									
									total+= Number(so);																
									//alert("Total chua cong :" + total);
								}
						}
					}
				}
		}	
	}
	
	var objSLCurr=0;
	var sohientai=0;
	var t = 0;
	//alert("id current"+ txtSL);
	objSLCurr = document.getElementById(txtSL);
	if (objSLCurr.value=="" || objSLCurr.value ==null)
	{
		objSLCurr.value=0;
	}
		
	
	sohientai=objSLCurr.value;
	//	alert('so hien tai: '+sohientai);
	sohientai=convertSo(sohientai);		
	t= total+(1*parseFloat(sohientai));		
	//alert(t);
	
	//t= total+(1*parseFloat(objSLCurr.value));		
	var rlength = 5;//number of decimal	
	// Dung để né trường hợp lỗi he thống javascript
	
	t= Math.round(t*Math.pow(10,rlength))/Math.pow(10,rlength);		
	//alert(t*Math.pow(10,rlength));
	
	// Dùng để kiểm tra giá trị khi cộng trở nên qúa lớn
	if (t*1>999999999){   
		alert('Tổng khi cộng phải nhỏ hơn 999.999.999, kiểm tra lại giá trị vừa nhập!'); 
		objSLCurr.value=0;
		objSLCurr.focus();			
		return total+'';
	}	
	else
	{
		return t+'';
	}	
}

//Ham tim cha 
//Tra ve mot doi tuong cha cua txtSL hien tai
function findParent(txtSL)
{
	var i;
	//var index;
	var rowEnd;
	var gridID;
	var Macha;
	var IsSum;
	var IsData;
	var objCha;
	var NameOfTextMaCha;
	var NameOfTextSL;
	var value;
	
	gridID = "<%=dgdDanhSach.ClientID%>";
	rowEnd = eval('document.forms[0].all("<%=dgdDanhSach.ClientID%>")').rows.length;
	
	for(i=rowEnd;i>0;i--)
	{
				//Lay vi tri cua chkCon
	
				NameOfTextSL = gridID + "__ctl" + i + "_" + "txtSoLieu";
				if (NameOfTextSL == txtSL) 
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
							//alert(valueOfMaCT)
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
										var NameOfTextSLCha;
										NameOfTextSLCha=gridID + "__ctl" + j + "_" + "txtSoLieu";
										objCha = NameOfTextSLCha;
										//objCha = document.getElementById(NameOfTextSLCha);
									//	alert(objCha);
									}
							}
					}
			}
	}
	return objCha;	
}
//Hoan thanh :D
// Hàm convert to soVN
function convertSo(so)
{	
	while (so.indexOf('.')!=-1)
	{
		so=so.replace('.','');
	}
		so=(so).replace(',','.');												
return so;
}

// Kiem tra ky bao cao
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
		alert("Bạn phải chọn một kỳ báo cáo cụ thể");
		ddl.focus();
		return false;
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
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">SỐ LIỆU ƯỚC THỰC HIỆN</asp:label>
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
						<table id="Table1" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
							<tr>
								<td align="center">
									<table class="QH_table" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<td align="left">
												<table id="tblTable1" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<tr>
														<td height="6"></td>
													</tr>
													<tr>
														<td align="center" width="100%">
															<table class="QH_Content_Filter" width="90%">
																<tr>
																	<td colSpan="4" height="10"></td>
																</tr>
																<tr>
																	<td align="center" width="50%"><asp:label id="lbl1" Runat="server" CssClass="QH_Collabel" Width="25%">Đơn vị</asp:label><asp:label id="lblDonViSL" Runat="server" CssClass="QH_LabelLeftBold" Visible="False"></asp:label><asp:dropdownlist id="ddlDonVi" Runat="server" CssClass="QH_dropdownlist" Width="60%" Visible="True"></asp:dropdownlist></td>
																	<td align="center" width="25%"><asp:label id="Label1" Runat="server" CssClass="QH_Collabel">Kỳ báo cáo</asp:label><asp:label id="lblKyBaoCaoSL" Runat="server" CssClass="QH_LabelLeftBold" Visible="False"></asp:label><asp:dropdownlist id="ddlMaKyBaoCao" Runat="server" CssClass="QH_DropDownList" Width="50%" Visible="True"></asp:dropdownlist></td>
																	<td align="center" width="15%"><asp:label id="Label3" Runat="server" CssClass="QH_Collabel">Năm</asp:label><asp:label id="lblNamSL" Runat="server" CssClass="QH_LabelLeftBold" Visible="False"></asp:label><asp:dropdownlist id="ddlNam" Runat="server" CssClass="QH_DropDownList" Width="60%" Visible="True"></asp:dropdownlist></td>
																	<td align="right"><asp:imagebutton id="btnLocDuLieu" Runat="server" Visible="True" ImageUrl="../../IMAGES/btn_ThucHien.gif"></asp:imagebutton></td>
																</tr>
																<tr>
																	<td colSpan="4" height="10"></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table width="99%">
													<tr>
														<td width="50%"><asp:label id="lblTrangThaiDuyet" Runat="server" CssClass="QH_label" Visible="False" Font-Italic="True"
																ForeColor="OrangeRed"></asp:label></td>
														<td align="right"><asp:label id="label7" Runat="server">Số dòng hiển thị:&nbsp; </asp:label><asp:textbox id="txtSoDongHienThi" Runat="server" CssClass="QH_TextRight" Width="50px" MaxLength="3"
																AutoPostBack="True"></asp:textbox></td>
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
														<asp:TemplateColumn HeaderText="STT" >
															<ItemStyle Width="3%"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="Label2" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Tên chỉ tiêu" >
															<ItemStyle Width="30%"></ItemStyle>
															<ItemTemplate>
																<asp:Label ID="txtTenChiTieu" Runat=server CssClass="QH_Label" Text='<%# DataBinder.Eval(Container,"DataItem.TenChiTieu")%>'>
																</asp:Label>
																<asp:TextBox ID="txtMaCT" Width=0px Runat=server CssClass="QH_Label" Text='<%# DataBinder.Eval(Container,"DataItem.MaChiTieu")%>'>
																</asp:TextBox>
																<asp:TextBox ID="txtMaCha" Width=0px Runat=server CssClass="QH_TextBox" TabIndex=100 Text='<%# DataBinder.Eval(Container,"DataItem.MaCha")%>'>
																</asp:TextBox>
																<asp:TextBox ID="txtIsSum" Width=0px Runat=server CssClass="QH_TextBox" TabIndex=101 Text='<%# DataBinder.Eval(Container,"DataItem.IsSum")%>'>
																</asp:TextBox>
																<asp:TextBox ID="txtIsData" Runat=server Width=0px CssClass="QH_TextBox" TabIndex=102 Text='<%# DataBinder.Eval(Container,"DataItem.IsData")%>'>
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="TenDonViTinh" HeaderText="Đơn vị tính" >
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Số liệu" >
															<ItemStyle Width="10%"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox ID="txtSoLieu" Runat="server" Width=100% CssClass="QH_TextRight" Text='<%# DataBinder.Eval(Container, "DataItem.SoLieu") %>' >
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Ý kiến" >
															<ItemStyle Width="25%"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox ID="txtYKien" Runat=server Width=100% CssClass="QH_TextBox" Text='<%# DataBinder.Eval(Container, "DataItem.YKien") %>' >
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
											<td align="center"><asp:imagebutton id="btnChoDuyet" Runat="server" CssClass="QH_Button" Visible="False" ImageUrl="../../Images/btn_BoDuyet.gif"></asp:imagebutton><asp:imagebutton id="btnDuyetSoLieu" Runat="server" Visible="False" ImageUrl="../../IMAGES/Duyet.gif"></asp:imagebutton><asp:imagebutton id="btnTrove" Runat="server" Visible="False" ImageUrl="../../IMAGES/btn_Trove.gif"></asp:imagebutton><asp:imagebutton id="btnCapNhat" Runat="server" ImageUrl="../../IMAGES/btn_CapNhat.gif"></asp:imagebutton><asp:imagebutton id="btnXoa" Runat="server" ImageUrl="../../IMAGES/btn_Xoa.gif"></asp:imagebutton><asp:imagebutton id="btnIn" Runat="server" ImageUrl="../../IMAGES/btn_XuatExcel.gif"></asp:imagebutton></td>
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
