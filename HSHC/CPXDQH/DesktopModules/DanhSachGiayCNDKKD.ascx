<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachGiayCNDKKD.ascx.vb" Inherits="CPXD.DanhSachGiayCNDKKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript"> 
function select_deselect (chk) 
{ 
	var frm = document.forms[0];
	var i;
	var objchk;
	var obj;
	var txt, txtVon;
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chk) != -1)
		{
			objchk = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtSoGiayPhep') != -1)
		{
			txt = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtTienBangChu') != -1)
		{
			txtVon = window.document.forms(0).item(i);	
		}
	}
	for (i=0;i<window.document.forms(0).length-1;i++)
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
	if (objchk.checked == true) 
	{
		settxtSoBienNhanChon(objchk,txt,txtVon);
	}
	
	
}
function settxtSoBienNhanChon(chk,txt,txtVon)
{

var j;
var tenchkChon;

for (j=3; j<eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdDanhSach")').rows.length+1; j++)
				{
				
					tenchkChon = "_ctl0__ctl0__ctl0_dgdDanhSach__ctl" + j + "_chkXoa";
					
					if(tenchkChon==chk.id){
					txt.value = eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdDanhSach")').rows(j-2).cells(2).innerText
					txtVon.value = eval('document.forms[0].all("_ctl0__ctl0__ctl0_dgdDanhSach")').rows(j-2).cells(8).innerText + " đồng"
					}
				}
}				

</script>
<TABLE class="QH_table" id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center"
	border="0">
	<TR>
		<TD colSpan="5" height="19"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD colSpan="5" height="10"></TD>
	</TR>
	<TR>
		<TD width="50%">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TR>
					<TD class="QH_ColLabel" width="15%">Họ tên</TD>
					<TD><asp:textbox id="txtHoTen" Width="80%" CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="30%">Số nhà</TD>
					<TD width="70%"><asp:textbox id="txtSoNha" Width="30%" CssClass="QH_TextBox" Runat="server"></asp:textbox>
					<TD></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Ðường</TD>
					<TD><asp:dropdownlist id="ddlDuong" Width="80%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Phường</TD>
					<TD><asp:dropdownlist id="ddlPhuong" Width="80%" CssClass="QH_DropDownList" Runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel"></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="50%">
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TR>
					<TD class="QH_ColLabel" width="30%" height="23">Tình trạng</TD>
					<TD width="70%" height="23"><asp:dropdownlist id="ddlTinhTrangHienTai" Width="60%" CssClass="QH_DropDownList" Runat="server" Enabled="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Số giấy phép</TD>
					<TD><asp:textbox id="txtSoGiayPhep" Width="40%" CssClass="QH_TextBox" Runat="server"></asp:textbox><asp:textbox id="txtTienBangChu" Width="0px" Runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Từ ngày</TD>
					<TD><asp:textbox id="txtTuNgay" Width="40%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
						<asp:image id="imgTuNgay" CssClass="QH_IMAGEBUTTON" runat="server" ImageUrl="~/images/calendar.gif"
							AlternateText="Chọn ngày tháng nam"></asp:image></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Ðến ngày</TD>
					<TD><asp:textbox id="txtDenNgay" Width="40%" CssClass="QH_TextBox" Runat="server" MaxLength="10"></asp:textbox>&nbsp;
						<asp:image id="imgDenNgay" CssClass="QH_IMAGEBUTTON" runat="server" ImageUrl="~/images/calendar.gif"
							AlternateText="Chọn ngày tháng nam"></asp:image></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD colSpan="5" height="10"></TD>
	</TR>
	<TR>
		<TD width="50%">
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TR>
					<TD class="QH_ColLabel" width="30%" height="23">Nơi lưu bản sao</TD>
					<TD width="70%" height="23">
						<asp:textbox id="txtNoiLuuBanSao" CssClass="QH_Textbox" Width="80%" runat="server"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
		<TD></TD>
	</TR>
	<TR>
		<TD colSpan="5" height="10"></TD>
	</TR>
	<TR>
		<TD colSpan="2">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TR>
					<TD align="right" width="50%" height="24"><asp:imagebutton id="btnTimKiem" CssClass="QH_Button" runat="server" ImageUrl="../../images/btn_Timkiem.gif"></asp:imagebutton><asp:imagebutton id="btnIn" CssClass="QH_Button" runat="server" ImageUrl="../../images/btn_InRaGiay.gif"></asp:imagebutton><asp:imagebutton id="btntroVe" CssClass="QH_Button" runat="server" ImageUrl="../../images/btn_TroVe.gif"></asp:imagebutton></TD>
					<TD align="right" width="*" height="24"><asp:label id="Label1" CssClass="QH_Label" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Width="25px" CssClass="QH_TextBox" Runat="server" MaxLength="2" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="5" height="10"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" Runat="server" CellPadding="3"
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
