<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DanhMuc_Chon.aspx.vb" Inherits="HSHC.DanhMuc_Chon"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Chọn chỉ tiêu cha</title>
		<link href='<%=Request.ApplicationPath + "/portals/_default\Skins\BLUEFOX SKIN\Bluefox.css" %>' type=text/css rel=stylesheet>
			<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
			<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
			<meta content="JavaScript" name="vs_defaultClientScript">
			<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
			<script language="javascript">
				function form1_onsubmit()
				{
					
					var objset1,objget1,objset2,objget2,i;
					for (i=0;i<window.opener.document.forms(0).length;i++)
					{
						if (window.opener.document.forms(0).item(i).id.indexOf('txtMaCha') != -1)
						{		
							objset1 = window.opener.document.forms(0).item(i);	
						}
					
						if (window.opener.document.forms(0).item(i).id.indexOf('txtTen') != -1)
						{		
							objset2 = window.opener.document.forms(0).item(i);	
						}
					}
								
					for (i=0;i<window.document.forms(0).length;i++)
					{
						if (window.document.forms(0).item(i).id.indexOf('txtMaCTCha') != -1)
						{
						
							objget1 = window.document.forms(0).item(i);	
						}
						if (window.document.forms(0).item(i).id.indexOf('txtTenCTCha') != -1)
						{
						
							objget2 = window.document.forms(0).item(i);	
						}
					}
					
						objset1.value=objget1.value;
						objset2.value=objget2.value;
						
						//objset.focus();
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
	var txt1;
	var txt2;
	for (i=0;i<window.document.forms(0).length;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chk) != -1)
		{
			objchk = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtMaCTCha') != -1)
		{
			txt1 = window.document.forms(0).item(i);	
		}
		if (window.document.forms(0).item(i).id.indexOf('txtTenCTCha') != -1)
		{
			txt2 = window.document.forms(0).item(i);	
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
	settxtSoBienNhanChon(objchk,txt1,txt2);
}
function settxtSoBienNhanChon(chk,txt1,txt2)
{

var j;
var tenchkChon;
			
for (j=1; j<eval('document.forms[0].all("dgdDanhSach")').rows.length+1 ; j++)
{
	tenchkChon = "dgdDanhSach__ctl" + j + "_chkXoa";
	if(tenchkChon==chk.id)
	{
			
		txt1.value = eval('document.forms[0].all("dgdDanhSach")').rows(j-2).cells(1).innerText;
		txt2.value = eval('document.forms[0].all("dgdDanhSach")').rows(j-2).cells(2).innerText;
		//'alert('ten' + txt1.value);
	}
}
				
}				
			</script>
</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table class="QH_TableMain" id="Table1" cellSpacing="0" cellPadding="0" width="95%" align="center"
				border="0">
				<tr class="QH_LoaiHS">
					<td width="30%" class="QH_Label">Chọn chỉ tiêu cấp cha</td>
					<td width="70%"><asp:dropdownlist id="ddlNhomChiTieu" Runat="server" CssClass="QH_Dropdownlist" AutoPostBack="True"
							Width="90%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td colSpan="2"><asp:datagrid id="dgdDanhSach" Runat="server" CssClass="QH_DataGrid" Width="100%" autogeneratecolumns="false"
							AllowSorting="True" AllowPaging="True" CellPadding="3">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Chọn">
									<ItemStyle Width="10%"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="chkXoa" Runat="server" Checked="False"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Ma" HeaderText="Mã" Visible=False>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Ten" HeaderText="Tên chỉ tiêu">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td height="2"></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:imagebutton id="btnTroVe" Runat="server" ImageUrl="../../images/btn_TroVe.gif"></asp:imagebutton><asp:imagebutton id="btnChon" Runat="server" ImageUrl="../../images/btn_Chon.gif"></asp:imagebutton></td>
				</tr>
			</table>
			<asp:textbox id="txtMaCTCha" Runat="server" Width="0px" Visible="True"></asp:textbox>
			<asp:textbox id="txtTenCTCha" Runat="server" Width="0px" Visible="True"></asp:textbox>
		</form>
	</body>
</HTML>
