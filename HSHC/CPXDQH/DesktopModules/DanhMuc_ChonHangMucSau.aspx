<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DanhMuc_ChonHangMucSau.aspx.vb" Inherits="CPXD.DanhMuc_ChonHangMucSau"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Chọn từ danh sách gợi ý</title>
		<script language="javascript">
				function SetValue(strText)
				{
					var objset,i;
					var lst;
					var strValue;
					var strOldvalue;
					strOldvalue='';
					strValue='';
					for (i=0;i<window.document.forms(0).length-1;i++)
					{
						obj=window.document.forms(0).item(i);
						if (obj.id.indexOf('lstDanhMuc') != -1 && obj.checked == true)
						{					
							lst = obj;
							strValue = lst.value;
						}
						
					}
		
					for (i=0;i<window.opener.document.forms(0).length;i++)
					{
						//if (window.opener.document.forms(0).item(i).id.indexOf(strText) != -1)
						if (window.opener.document.forms(0).item(i).id==strText)
						{		
						
							objset = window.opener.document.forms(0).item(i);	
							//alert(objset.id);
							//return;
							strOldvalue=objset.value;
						}
					}
						if (strValue!='')
						{
							objset.value=strOldvalue+'\n'+strValue;
						}
						window.close();						
				}
				

		</script>
		<link href='<%= Request.ApplicationPath + "/Portals/0/Portal.css" %>' 
type=text/css rel=stylesheet>
			<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
			<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
			<meta name="vs_defaultClientScript" content="JavaScript">
			<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td align="center">
						<asp:RadioButtonList id="lstDanhMuc" CssClass="QH_DropDownList" Runat="server" RepeatDirection="Vertical"
							RepeatColumns="2" RepeatLayout="Table" Width="90%"></asp:RadioButtonList>
						<INPUT id="txtValue" type="hidden" name="txtValue" runat="server"> <INPUT id="txtDanhMuc" type="hidden" name="txtDanhMuc" runat="server"></td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td align="center">
						<asp:imagebutton id="btnTroVe" runat="server" ImageUrl="../../images/btn_TroVe.gif"></asp:imagebutton>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
