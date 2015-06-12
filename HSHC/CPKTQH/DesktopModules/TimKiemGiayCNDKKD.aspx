<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TimKiemGiayCNDKKD.aspx.vb" Inherits="CPKTQH.TimKiemGiayCNDKKD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DANH SACH HO CA THE</title>
		<link 
href='<%= Request.ApplicationPath + "/Portals/_default/Skins/LIGHTBLUESKIN/LightBlueskin.css" %>' 
type=text/css rel=stylesheet>
			<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
			<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
			<meta content="JavaScript" name="vs_defaultClientScript">
			<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
			<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
			<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
			<script language="javascript">
				function form1_onsubmit()
				{
					
					var objset,objget,i;
					for (i=0;i<window.opener.document.forms(0).length;i++)
					{
						if (window.opener.document.forms(0).item(i).id.indexOf('txtSoGiayPhep') != -1)
						{		
							objset = window.opener.document.forms(0).item(i);	
						}
						if (window.opener.document.forms(0).item(i).id.indexOf('KiemTra') != -1)
						{		
							window.opener.document.forms(0).item(i).value='1';	
						}
						if (window.opener.document.forms(0).item(i).id.indexOf('txtReload') != -1)
						{		
							window.opener.document.forms(0).item(i).value ='1';
						}
					}
					
					for (i=0;i<window.document.forms(0).length;i++)
					{
						if (window.document.forms(0).item(i).id.indexOf('txtSoGiayPhepChon') != -1)
						{
						
							objget = window.document.forms(0).item(i);	
						}
					}
					
						objset.value=objget.value;
					
						window.close();
						window.opener.document.forms(0).submit();						
				}
			</script>
			<script language="javascript"> 
function select_deselect (chk) 
{ 
	var frm = document.forms[0];
	var i;
	var objchk;
	var obj;
	var txt;
	for (i=0;i<window.document.forms(0).length;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chk) != -1)
		{
			objchk = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtSoGiayPhepChon') != -1)
		{
			txt = window.document.forms(0).item(i);	
		}
	}
	for (i=0;i<window.document.forms(0).length;i++)
	{
		obj = window.document.forms(0).item(i);
		if (window.document.forms(0).item(i).id.indexOf('chkXoa') != -1)
		{
			if (objchk.checked == true)
			{
				if (obj.id != objchk.id)
				obj.checked = false;
		}
			
		}
	}	
	settxtSoBienNhanChon(objchk,txt);
	}
function settxtSoBienNhanChon(chk,txt)
{

var j;
var tenchkChon;
for (j=3; j<eval('document.forms[0].all("dgdDanhSach")').rows.length+2 ; j++)
				{
					tenchkChon = "dgdDanhSach__ctl" + j + "_chkXoa";
					if(tenchkChon==chk.id){
					txt.value = eval('document.forms[0].all("dgdDanhSach")').rows(j-2).cells(2).innerText
					
					}
				}
}				
			</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td height="5"></td>
				</tr>
				<TR>
					<TD width="100%" height="24">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Khung_TopLeft" width="16" height="24"></td>
								<td class="QH_Khung_TopMid" width="*">&nbsp;
									<asp:label id="Label3" runat="server" Width="100%" CssClass="QH_Label_Title">Tìm kiếm Giấy CN ĐKKD</asp:label></td>
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
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
										<BR>
										<TR>
											<TD align="center" width="100%">
												<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="90%" align="center"
													border="0">
													<TR>
														<TD class="QH_ColLabel" width="15%">Họ tên</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" runat="server" Width="80%" CssClass="QH_Textbox"></asp:textbox></TD>
														<TD class="QH_ColLabel" width="15%">Tình trạng</TD>
														<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlTinhTrangHienTai" Width="60%" CssClass="QH_DropDownList" Runat="server" Enabled="False"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="15%">Số nhà</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" Width="80%" CssClass="QH_TextBox" Runat="server"></asp:textbox>
														<TD class="QH_ColLabel" width="15%">Số GCN ĐKKD</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" Width="60%" CssClass="QH_TextBox" Runat="server"></asp:textbox><asp:textbox id="txtSoGiayPhepChon" Width="0px" CssClass="QH_TextBox" Runat="server"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="15%">Phường</TD>
														<TD class="QH_ColControl" width="35%">
															<cc1:KeySortDropDownList id="ddlPhuong" runat="server" CssClass="QH_DropDownList" Width="80%"></cc1:KeySortDropDownList></TD>
														<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTuNgay" Width="40%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
															<asp:image id="imgTuNgay" runat="server" CssClass="QH_IMAGEBUTTON" ImageUrl="~/images/calendar.gif"
																AlternateText="Chọn ngày tháng nam"></asp:image></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="15%" height="16">Đường</TD>
														<TD class="QH_ColControl" width="35%" height="16">
															<cc1:KeySortDropDownList id="ddlDuong" runat="server" CssClass="QH_DropDownList" Width="80%"></cc1:KeySortDropDownList></TD>
														<TD class="QH_ColLabel" width="15%" height="16">Ðến ngày</TD>
														<TD class="QH_ColControl" width="35%" height="16"><asp:textbox id="txtDenNgay" Width="40%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
															<asp:image id="imgDenNgay" runat="server" CssClass="QH_IMAGEBUTTON" ImageUrl="~/images/calendar.gif"
																AlternateText="Chọn ngày tháng nam"></asp:image></TD>
													</TR>
												</TABLE>
												<P><asp:textbox id="txtIsHuy" runat="server" Width="30px" CssClass="QH_Textbox" Visible="False"></asp:textbox></P>
											</TD>
										</TR>
										<TR>
											<TD colSpan="5" height="10"></TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<TR>
														<TD align="center" width="50%"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>&nbsp;
															<asp:linkbutton id="btnChon" runat="server" CssClass="QH_Button">Chọn</asp:linkbutton>&nbsp;
															<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;
														</TD>
													</TR>
													<tr>
														<TD align="center" width="*">
															<table cellSpacing="0" cellPadding="0" width="90%" border="0">
																<tr>
																	<td align="right"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Width="50px" CssClass="QH_TextRight" Runat="server" MaxLength="3"
																			AutoPostBack="True"></asp:textbox></td>
																</tr>
															</table>
														</TD>
													</tr>
													<TR>
														<TD align="center" colSpan="2"><asp:datagrid id="dgdDanhSach" Width="90%" CssClass="QH_DataGrid" Runat="server" CellPadding="3"
																autogeneratecolumns="False" AllowPaging="True">
																<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
								<td class="QH_Khung_Right" width="16">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr height="*">
											<td></td>
										</tr>
										<tr height="141">
											<td class="QH_Khung_Right1"></td>
										</tr>
									</TABLE>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
