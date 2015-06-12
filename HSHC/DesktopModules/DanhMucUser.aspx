<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DanhMucUser.aspx.vb" Inherits="PortalQH.DanhMucUser"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Nhập Danh Mục</title>
			<script language=javascript>   
				function SetValue(strText)
				{
					var objset,i;
					var lst;
					var strValue;
					var obj1;
					strOldvalue='';
					strValue='';
					obj1 = window.opener.document.getElementsByTagName("ComboBox").item("_ctl0__ctl0__ctl0_ddlMaDuong");
					var opt=window.opener.document.createElement("OPTION");
					obj1.options.add(opt);
					opt.selected=true;
					opt.value = "TDT";
					window.close();	
					//return;
					for (i=0;i<window.opener.document.forms(0).length;i++)
					{	//if (window.opener.document.forms(0).item(i).id.indexOf(strText) != -1)
						if (window.opener.document.forms(0).item(i).id==strText)
						{			
							objset = window.opener.document.forms(0).item(i);	
							//alert(objset.id);
							//return;
						}
					}
						
						objset = window.opener.document.forms(0).item(10);;	
						//objset.options[1]=newoption;
						window.document  
						alert(objset.options[10].text);
						
						if (strValue!='')
						{
							objset.value=strValue;
						}
						window.close();						
				}
				

		</script>
		<LINK href="~/Portal.css" type="text/css" rel="stylesheet">
			<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
			<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
			<meta content="JavaScript" name="vs_defaultClientScript">
			<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form" method="post" runat="server">
			<TABLE id="TblMain" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%" height="24">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="QH_Khung_TopLeft" width="16" height="24"></td>
								<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Label_Title"></asp:label></td>
								<td class="QH_Khung_TopRight" width="16" height="24"></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD width="100%">
						<TABLE id="TblInput" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
						</TABLE>
					</TD>
				</TR>
				<TR vAlign="middle">
				</TR>
			</TABLE>
			<TABLE id="TblControl" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center" width="100%" colSpan="2"><asp:imagebutton id="btnCapNhat" runat="server" ImageUrl="~/images/btn_CapNhat.gif"></asp:imagebutton>
						<asp:imagebutton id="btnCancel" runat="server" ImageUrl="~/images/btn_BoQua.gif"></asp:imagebutton></TD>
				</TR>
			</TABLE>
			</TR></TR></TABLE></form>
	</body>
</HTML>
