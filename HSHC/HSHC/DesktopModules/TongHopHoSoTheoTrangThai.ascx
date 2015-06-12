<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TongHopHoSoTheoTrangThai.ascx.vb" Inherits="HSHC.TongHopHoSoTheoTrangThai" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server">Tổng hợp số hồ sơ theo trạng thái</asp:label></td>
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
					<td width="*">
						<table cellSpacing="0" cellPadding="5" width="100%" border="0">
							<TBODY>
								<TR class="QH_Filter_Bg">
									<TD width="15%"></TD>
									<TD class="QH_ColLabel1" width="12%">Lĩnh vực</TD>
									<TD colSpan="4"><cc1:keysortdropdownlist id="ddlMaLinhVuc" Width="380" CssClass="QH_DropDownList" runat="server"></cc1:keysortdropdownlist></TD>
									<TD width="10%"></TD>
								</TR>
								<TR class="QH_Filter_Bg">
									<TD width="15%"></TD>
									<TD class="QH_ColLabel1" width="12%">Loại hồ sơ</TD>
									<TD colSpan="4"><cc1:keysortdropdownlist id="ddlMaLoaiHoSo" Width="380" CssClass="QH_DropDownList" runat="server"></cc1:keysortdropdownlist></TD>
									<TD width="10%"></TD>
								</TR>
								<TR class="QH_Filter_Bg">
									<TD align="center" colspan="7">
										<div>
											<div id="divTuNgayLabel" style="DISPLAY:inline">Từ ngày<font color="#ff0000" size="2">*</font>
											</div>
											<div id="divTuNgayControl" style="DISPLAY:inline">
												<asp:textbox id="txtTuNgay" Width="70px" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
													<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink>
											</div>
											<div style="DISPLAY:inline;WIDTH:50px"></div>
											<div style="DISPLAY:inline">
												Ðến ngày<font color="#ff0000" size="2">*</font>
											</div>
											<div style="DISPLAY:inline"><asp:textbox id="txtDenNgay" Width="70px" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
													<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink>
											</div>
											<div style="DISPLAY:inline;WIDTH:50px"></div>
											<div style="DISPLAY:inline">
												<asp:linkbutton id="btnTimKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>
											</div>
										</div>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="7"><asp:datagrid id="dgdDanhSach" Width="50%" CssClass="QH_Datagrid" Runat="server" PageSize="20"
											AllowSorting="True" AllowPaging="True" CellPadding="3" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
											<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<ItemStyle Width="7%"></ItemStyle>
													<ItemTemplate>
														<asp:Label id=lblSTT Width="100%" runat="server" Text="<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>" cssclass="QH_ColLabelMiddle">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<ItemStyle Width="30%"></ItemStyle>
													<ItemTemplate>
														<asp:Label id="lblTrangThai" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TrangThai") %>'>
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
													<ItemStyle Width="7%"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink ID="moreLink" Runat="server" cssclass="QH_MenuLink" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"SoHoSo") %>' NavigateUrl='<%# IIF( DataBinder.Eval(Container.DataItem,"SoHoSo") = 0, "", EditURL("Malv",DataBinder.Eval(Container.DataItem,"MaLinhVuc") & "&TuNgay=" & txtTuNgay.Text & "&DenNgay=" & txtDenNgay.Text & "&MaLHS=" & ddlMaLoaiHoSo.SelectedValue & "&MaTT=" & DataBinder.Eval(Container.DataItem,"MaTinhTrang"), "DSHOSO") ) %>'>
														</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<ItemStyle Width="7%"></ItemStyle>
													<ItemTemplate>
														<asp:Label id="lblTongLuyKe" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TongLuyKe") %>'>
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Visible="False" BorderWidth="0px" HorizontalAlign="Right" CssClass="QH_ActivePage"
												Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TBODY>
						</table>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1"><asp:textbox id="txtFirstLoad" Width="0" CssClass="QH_TextBox" Runat="server"></asp:textbox></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
<script language="javascript">
	
	/***
	* TuanNH added 27/09/2007.
	* Thay the ham loc Loai ho so theo Linh Vuc cua control combofilter
	***/
	function AutoFilterLoaiHoSoByLinhVuc(allRecords, flagChange){
	
		var all            = document.all("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo").length; 
		var objResult      = document.all("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo"); 
		var objFirstFilter = document.all("_ctl0__ctl0__ctl0_txtFirstLoad");
		
		var MaDieuKien;
		var lenResultFilter = ResultctrlScriptComboFilter.length;
		var MaLoaiHoSo;
		
		//Lay gia tri Ma linh vuc da chon
		MaDieuKien = document.all("_ctl0__ctl0__ctl0_ddlMaLinhVuc").value;
		MaLoaiHoSo = objResult.value;
		
		if (objFirstFilter != undefined && objFirstFilter.value != "1" && flagChange == "0") return;
		//if (flagChange == "0") return;
		//if (objResult.value != '') return;
		
		//clear dropdownlist loai ho so
		for (i = 0; i < all; i++) document.all("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo").remove(0);
		
		//add new empty option to dropdownlist Loai ho so
		document.all("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo").add(new Option('', ''));
		
		//if not select linh vuc
		if (MaDieuKien == '' && allRecords == '1') {
			var j, flag;
			
			for (i = 0; i < lenResultFilter; i++){ 
				flag = 0;
				for (j = i + 1; j < lenResultFilter; j++)
					if (ResultctrlScriptComboFilter[0][i] == ResultctrlScriptComboFilter[0][j])
					{ flag=1; break; } 
					if (flag == 0) 
						document.all("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo").add(new Option(ResultctrlScriptComboFilter[1][i], ResultctrlScriptComboFilter[0][i]));
			}
		}
		else {
			
			for (i = 0; i < lenResultFilter; i++) 
				if (ResultctrlScriptComboFilter[2][i] == MaDieuKien) 
					document.all("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo").add(new Option(ResultctrlScriptComboFilter[1][i], ResultctrlScriptComboFilter[0][i]));
					
			if (MaLoaiHoSo != null && MaLoaiHoSo != "")
				//lua chon. gia' tri. mac dinh cho list Loai ho so
				document.all("_ctl0__ctl0__ctl0_ddlMaLoaiHoSo").value = MaLoaiHoSo;
		}
	}
	
	//auto filter Loai ho so By Linh vuc after set default Linh vuc
	AutoFilterLoaiHoSoByLinhVuc("1", "1");
	
</script>
