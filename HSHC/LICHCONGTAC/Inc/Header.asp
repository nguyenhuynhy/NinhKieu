﻿<html>
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
<!-- Navbar def -->
<script language="JavaScript" type="text/javascript">
<!-- Dummy comment to hide code from non-JavaScript browsers.

if (document.images) {
lich_truc_b1_off = new Image(); lich_truc_b1_off.src = "images/lich_truc_b1.gif"
lich_truc_b1_over = new Image(); lich_truc_b1_over.src = "images/lich_truc_b1_over.gif"
lich_truc_b2_off = new Image(); lich_truc_b2_off.src = "images/lich_truc_b2.gif"
lich_truc_b2_over = new Image(); lich_truc_b2_over.src = "images/lich_truc_b2_over.gif"
lich_truc_b3_off = new Image(); lich_truc_b3_off.src = "images/lich_truc_b3.gif"
lich_truc_b3_over = new Image(); lich_truc_b3_over.src = "images/lich_truc_b3_over.gif"
lich_truc_b4_off = new Image(); lich_truc_b4_off.src = "images/lich_truc_b4.gif"
lich_truc_b4_over = new Image(); lich_truc_b4_over.src = "images/lich_truc_b4_over.gif"
lich_truc_b5_off = new Image(); lich_truc_b5_off.src = "images/lich_truc_b5.gif"
lich_truc_b5_over = new Image(); lich_truc_b5_over.src = "images/lich_truc_b5_over.gif"
lich_truc_b6_off = new Image(); lich_truc_b6_off.src = "images/lich_truc_b6.gif"
lich_truc_b6_over = new Image(); lich_truc_b6_over.src = "images/lich_truc_b6_over.gif"
}

function turn_off(ImageName) {
	if (document.images != null) {
		document[ImageName].src = eval(ImageName + "_off.src");
	}
}

function turn_over(ImageName) {
	if (document.images != null) {
		document[ImageName].src = eval(ImageName + "_over.src");
	}
}

// End of dummy comment -->
</script>
<!-- Navbar def end -->
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
				<tr>
					<td width="100%" colspan="6"></td>
				</tr>
				<tr>									
					<td width="16%" class="QH_Label"><a href="javascript:ViewOneDay();" onmouseout="turn_off('lich_truc_b1')" onmouseover="turn_over('lich_truc_b1')"><img name="lich_truc_b1" src="images/lich_truc_b1.gif" alt="Lịch trong ngày" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="CV_CAL_WEEK_ADDNEW2.ASP" onmouseout="turn_off('lich_truc_b2')" onmouseover="turn_over('lich_truc_b2')"><img name="lich_truc_b2" src="images/lich_truc_b2.gif" alt="Đăng ký" width="110" height="22" border="0"><b></a></td>					
					<td width="16%" class="QH_Label"><a href="CAL_WEEK_LIST.ASP" onmouseout="turn_off('lich_truc_b3')" onmouseover="turn_over('lich_truc_b3')"><img name="lich_truc_b3" src="images/lich_truc_b3.gif" alt="Lịch dự kiến" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="CAL_WEEK_WaitApprove.ASP" onmouseout="turn_off('lich_truc_b4')" onmouseover="turn_over('lich_truc_b4')"><img name="lich_truc_b4" src="images\lich_truc_b4.gif" alt="Duyệt lịch" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="CAL_WEEK_APPROVED.ASP" onmouseout="turn_off('lich_truc_b5')" onmouseover="turn_over('lich_truc_b5')"><img name="lich_truc_b5" src="images/lich_truc_b5.gif" alt="Lịch chính thức" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="LICHTRUCLE_LIST.ASP" onmouseout="turn_off('lich_truc_b6')" onmouseover="turn_over('lich_truc_b6')"><img name="lich_truc_b6" src="images/lich_truc_b6.gif" alt="Lịch trực lễ" width="110" height="22" border="0"><b></a></td>
				</tr>
			</table>			
		</td>		
	</tr>
</form>
</table>
</center>
</body>
</html>