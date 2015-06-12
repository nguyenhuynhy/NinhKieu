<!--#include file = "inc/lib.asp" -->
<html>
<head>
<meta name="GENERATOR" content="Microsoft FrontPage 6.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Lich lam viec trong ngay</title>
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
<script language = "javascript" src="inc/common.js"></script>
<script language = "javascript" src="inc/popcalendar.js"></script>
<script language="javascript">
function testpopUpCalendar(ctrl,ctrl2,format){
	//alert(ctrl);
	//alert(ctrl2);
	//alert(format);
	popUpCalendar(ctrl,ctrl2,format);
}
function isValidDate(strDate)   
	{   
	  var retval = 0   
	  var aDDMMCCYY   
	  var dtest   
	  // Kiem tra dung format   
	  if (/^(\d\d?-\d\d?-\d{4})|(\d\d?\/\d\d?\/\d{4})|(\d{8})$/.test(strDate))   
	  {   
	    if (/\//.test(strDate))   
	    {   
	      aDDMMCCYY = strDate.split("/");   
	    }   
	    else   
	    if (/-/.test(strDate))   
	    {   
	      aDDMMCCYY = strDate.split("-");   
	    }   
	    else   
	    {   
	      aDDMMCCYY = Array(strDate.substr(0,2), strDate.substr(2,2), strDate.substr(4,4))   
	    }       
		dtest = new Date(aDDMMCCYY[1] + "/" + aDDMMCCYY[0] + "/" + aDDMMCCYY[2]);         
	    if (dtest.getDate() != aDDMMCCYY[0] || dtest.getMonth() +1 != aDDMMCCYY[1] || dtest.getFullYear() != aDDMMCCYY[2])   
	    {   
	      retval = 2   
	    }   
	  }   
	  else   
	  {   
		retval = 1   
	  }   
	  return retval   
	}   

function CheckTuNgayHopLe()
{
		
			if (isValidDate(checkform.txtTuNgay.value)!=0){
				alert("Ngay " + checkform.txtTuNgay.value + " khong hop le!");
				//checkform.txtTuNgay.focus();    
				return false;  
			}
			return true;  
		
}
function CheckDenNgayHopLe()
{
			
		if (isValidDate(checkform.txtDenNgay.value)!=0){
			alert("Ngay " + checkform.txtDenNgay.value + " khong hop le!");
			//checkform.txtDenNgay.focus();    
			return false; 
		}
		
		return true;
}
function CheckNull()
{
if (checkform.txtDenNgay.value == '')
		{
			alert ("Nhap vao den ngay ") ;     	
			//checkform.txtDenNgay.focus();	
			return false;  
		}
if (checkform.txtTuNgay.value == '')
		{
			alert ("Nhap vao tu ngay ") ;     	
			//checkform.txtTuNgay.focus();	
			return false;  
		}		
		return true;
}
function ShowReport(report, sql, param,value)//, subreport, subsql, subparam, subvalue)
{
	width = screen.width;// - 20;
	height = screen.height;// - 100;
	l = 0;//(screen.width - 10 - width)/2;
	t = 0;//(screen.height -  10 - height)/2;	
	
	//alert(opt);
	//FileWindow = window.open('Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value + '&subreport=' + subreport + '&sqlSub=' + subsql + '&subformula=' + subparam + '&subValue=' + subvalue + '&IsIncludeSub=yes','_blank','location=yes,toolbar=no,resizable,scrollbars=yes, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
	FileWindow = window.open('Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','status=yes,location=no,toolbar=no,resizable,scrollbars=yes, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
	FileWindow.focus();				
	return true;
}
function inLichKhac(strFromDay,strDenNgay){
		var report = "rpt_InLichKhac.rpt";
		var strSQL = "Rpt_InLichKhac " +
				"@pTuNgay	= '" + strFromDay + "'," +			
				"@pDenNgay	= '" + strDenNgay + "'";
		ShowReport(report, strSQL, "", "");
	}

</script>
</head>
<%
		Dim Conn
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING

		SelectDay = date()
		
%>
<body text="#000000"  topmargin=0 leftmargin=0   background=Images/bg.gif>
<center>
<form name="checkform" action="CAL_WEEK_APPROVED.ASP" method="POST">
<table border="0" cellspacing="1" style="border-collapse: collapse" bordercolor="#111111" width="95%" id="AutoNumber1">
  <tr> 
    <td width="100%">
		<img src="images\Text_LichLamViecNgay.gif">			
    </td>
  </tr>  
  <tr>
	<td width="100%">
	<table cellspacing="1" width="100%">				
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">Từ ngày</td>
					<td width=*" class="QH_LabelLeft"><input type="text" name="txtTuNgay" size="13" class="QH_Textbox" onblur="javascript:return CheckTuNgayHopLe();">&nbsp<img id="imgdate1"  class="QH_IMAGEBUTTON1" src="images\calendar.gif" onclick="javascript:testpopUpCalendar(this,txtTuNgay,'dd/mm/yyyy')" border="0">
					<td class="QH_ColLabel" width="25%" align="right">Đến ngày</td>
					<td width=*" class="QH_LabelLeft"><input type="text" name="txtDenNgay" size="13" class="QH_Textbox" onblur="javascript:return CheckDenNgayHopLe();">&nbsp<img id="imgdate2" class="QH_IMAGEBUTTON1" src="images\calendar.gif" onclick="javascript:testpopUpCalendar(this,txtDenNgay,'dd/mm/yyyy')" border="0">
					
				</tr>
				
				<tr>
				<td >&nbsp;</td>
				<td  align=center colspan=2 width="20%" valign="absmiddle" style="font: 11px Arial, Helvetica, sans-serif;color: Black;text-align: center;vertical-align:text-middle;text-decoration: none;padding-right: 5;"><a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:inLichKhac(document.all.txtTuNgay.value,document.all.txtDenNgay.value)"><img alt="In lich lam viec" src="images/print.gif" onclick="javascript:return CheckNull()" border="0" align="absmiddle">&nbsp;In</a></td>
				
				<td>&nbsp;</td>
				</tr>		
	</table>
		
				
</table>
</td>    
  </tr>		      
</table>
</form>
</center>
</body>
</html>
