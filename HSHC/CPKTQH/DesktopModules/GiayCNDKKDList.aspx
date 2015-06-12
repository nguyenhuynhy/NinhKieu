<%@ Import Namespace="PortalQH" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GiayCNDKKDList.aspx.vb" Inherits="CPKTQH.GiayCNDKKDList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>NhapGoiThau</title>
		<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
		<script language="javascript">
function startUp()
{

	if(document.all("MsgBox_Hidden").value != '')
		{
		alert(document.all("MsgBox_Hidden").value) ;
		document.all("MsgBox_Hidden").value = ''		
		};
}

function UnCheckAll(opt)
			{
				var value,j,tenoptTrungThau;	
				for (j=3; j<eval('document.forms[0].all("grdNhaThau")').rows.length+1 ; j++)
					{
						tenoptTrungThau = "grdNhaThau:_ctl" + j + ":" + "optTrungThau" ;
						if (opt == tenoptTrungThau)
						{							
							tenoptTrungThau = "grdNhaThau:_ctl" + j + ":grdNhaThau:_ctl" + j + ":" + "optTrungThau" ;
							eval('document.forms[0].all("' + tenoptTrungThau + '")').checked= true;
						}
						else
						{
							tenoptTrungThau = "grdNhaThau:_ctl" + j + ":grdNhaThau:_ctl" + j + ":" + "optTrungThau" ;
							eval('document.forms[0].all("' + tenoptTrungThau + '")').checked = false;
						}
					}
			}
	function CheckSave()
		{
		var i;
		var str;		
		var strControls;
		strControls ='txtTenGoiThau,ddlMaDonViTuVan,ddlMaDonViThamDinh,ddlLoaiDauThau,ddlMaHinhThuc,ddlMaPhuongThuc,txtNgayMoThau,txtNoiMoThau,txtGiaGoiThau,txtSoQuyetDinh,txtNgayDuyet,ddlMaDonViDuyet'
		for (i=0; i<document.forms[0].length-1; i++)
		{
			str=window.document.forms[0].item(i).id;
			if (strControls.indexOf(str, 0) > -1)
			{	
				if (document.forms[0].item(i).value=='' && document.forms[0].item(i).id!='')
				
				{
					
					alert('Ban chua dien du thong tin!');    
					document.forms[0].item(i).focus();
					return false;
				}
			}
		}
				
			return true;
		}			

		</script>
		<link href='<%= Request.ApplicationPath + "/Portals/0/Portal.css" %>' 
type=text/css rel=stylesheet>
			<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
			</script>
			<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
			<script language="javascript">
				function form1_onsubmit()
				{
					window.close()
					window.opener.document.all("Form").submit();
				}
			</script>
			<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
			<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
			<meta content="JavaScript" name="vs_defaultClientScript">
			<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	</HEAD>
	<body onload="javascript:startUp();" MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="5"><asp:label id="lblTieuDe" Runat="server" CssClass="QH_Label_Title" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="5" height="10"></TD>
				</TR>
				<TR>
					<TD width="50%" colSpan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="15%">Họ tên</TD>
								<TD><asp:textbox id="txtHoTen" runat="server" CssClass="QH_Textbox" Width="96%"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD width="50%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="30%">Số nhà</TD>
								<TD width="70%"><asp:textbox id="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="90%"></asp:textbox>
								<TD></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Đường</TD>
								<TD><asp:dropdownlist id="ddlDuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Phường</TD>
								<TD><asp:dropdownlist id="ddlPhuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="50%">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="30%">Tình trạng</TD>
								<TD width="70%"><asp:dropdownlist id="ddlTinhTrangHienTai" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Số giấy phép</TD>
								<TD><asp:textbox id="txtSoGiayPhep" Runat="server" CssClass="QH_TextBox" Width="50%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Từ ngày</TD>
								<TD><asp:textbox id="txtTuNgay" Runat="server" CssClass="QH_TextBox" Width="50%" MaxLength="10"></asp:textbox>&nbsp;
									<asp:hyperlink id="cmdTuNgay" runat="server" CssClass="commandbutton">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Đến ngày</TD>
								<TD><asp:textbox id="txtDenNgay" Runat="server" CssClass="QH_TextBox" Width="50%" MaxLength="10"></asp:textbox>&nbsp;
									<asp:hyperlink id="cmdDenNgay" runat="server" CssClass="commandbutton">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="right" width="50%"><asp:imagebutton id="btnTimKiem" runat="server" CssClass="QH_Button" ImageUrl="../../images/btn_Timkiem.gif"></asp:imagebutton></TD>
								<TD align="right" width="*"><asp:label id="Label1" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Runat="server" CssClass="QH_TextBox" Width="25px" MaxLength="2" AutoPostBack="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2"><asp:datagrid id="dgdDanhSach" Runat="server" CssClass="QH_DataGrid" Width="100%" CellPadding="3"
										autogeneratecolumns="False" AllowPaging="True">
										<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
										<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
