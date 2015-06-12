<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<LINK href="inc/portal.css" type=text/css rel=stylesheet>	
<script language="javascript">
	function Thoat(){
		if (confirm('Ban co chac chan khong?')){
			frmHeader.action = 'COMM_CheckLogin.asp';
			frmHeader.hAction.value = 'THOAT'
			frmHeader.submit();
		}
	}
	function ViewOneDay(){
		FileWindow = window.open('CAL_WEEK_ONEDAY.ASP','Recipient','resizable,toolbar=0,scrollbars=1, alwaysRaised=Yes, width=700, height=540,top=0,left=0');
		FileWindow.focus();
	}  	
</script>
</head>
<%
If request.QueryString("Sp")="1" then'neu la trang bat dau
	If request.QueryString("UID")<>"" then
		Session("UserID")=request.QueryString("UID")
	else
		Session("UserID")=""
	end if
else
	If request.QueryString("UID")<>"" then
		Session("UserID")=request.QueryString("UID")
	end if
end if
%>
<body>
<center>
<table cellspacing="0" cellpadding="0" width ="100%">
<form name="frmHeader" method="post">
<input type="hidden" name="hAction" value="">
	<tr height="25" valign="middle">
		<td width="100%">
			<table cellspacing="0" cellpadding="0" width ="100%">
				<!--<tr>									
					<td width="15%" class="QH_Label"><a href="javascript:ViewOneDay();"><img src="images\calendr.gif" width="20" height="20" border="0" align="absmiddle"><b>Trong ngày</a></td>
					<td width="13%" class="QH_Label"><a href="CV_CAL_WEEK_ADDNEW2.ASP"><img src="images\DangKy.gif" border="0" align="absmiddle"><b>Đăng ký</a></td>					
					<td width="16%" class="QH_Label"><a href="CAL_WEEK_LIST.ASP"><img src="images\DangKy.gif" border="0" align="absmiddle"><b>Lịch dự kiến</a></td>
					<td width="14%" class="QH_Label"><a href="CAL_WEEK_WaitApprove.ASP"><img src="images\source.gif" border="0" align="absmiddle"><b>Duyệt lịch</a></td>
					<td width="18%" class="QH_Label"><a href="CAL_WEEK_APPROVED.ASP"><img src="images\calendr.gif" width="20" height="20" border="0" align="absmiddle"><b>Lịch chính thức</a></td>
					<td width="20%" class="QH_Label"><a href="LICHTRUCLE_LIST.ASP"><img src="images\T7CN.gif" border="0" align="absmiddle"><b>Lịch trực lễ</a></td>
				</tr>-->
				<tr style="BACKGROUND-IMAGE: url('images\Template1\Header1.jpg');">
					<td width="100%" colspan="6"><img src="images\Template1\Header1.jpg" border="0" align="absmiddle"></td>
				</tr>
				<tr  style="BACKGROUND-IMAGE: url('images\Template1\bgHeader.jpg');">									
					<td width="15%" align="Left"><a href="javascript:ViewOneDay();"><img src="images\Template1\Header21.jpg" border="0" align="absmiddle"><b></a></td>
					<td width="13%" align="Left"><a href="CV_CAL_WEEK_ADDNEW2.ASP"><img src="images\Template1\Header22.jpg" border="0" align="absmiddle"><b></a></td>					
					<td width="16%" align="Left"><a href="CAL_WEEK_LIST.ASP"><img src="images\Template1\Header23.jpg" border="0" align="absmiddle"><b></a></td>
					<td width="14%" align="Left"><a href="CAL_WEEK_WaitApprove.ASP"><img src="images\Template1\Header24.jpg" border="0" align="absmiddle"><b></a></td>
					<td width="18%" align="Left"><a href="CAL_WEEK_APPROVED.ASP"><img src="images\Template1\Header25.jpg" border="0" align="absmiddle"><b></a></td>
					<td width="20%" align="Left"><a href="LICHTRUCLE_LIST.ASP"><img src="images\Template1\Header26.jpg" border="0" align="absmiddle"><b></a></td>
				</tr>
			</table>			
		</td>		
	</tr>
</form>
</table>
</center>
</body>
</html>