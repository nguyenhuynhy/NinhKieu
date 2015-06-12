<!--#include file = "Security.asp"-->
<html>
<head>
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Dang ky lich cong tac tuan</title>
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
<script language = "javascript" src="inc/common.js"></script>
<script language="JavaScript1.2" fptype="dynamicanimation" src="inc/animate.js"></script>
<script language="javascript">
	function AddNew(pNgay, pType){
		checkform.hAction.value = 'addnew';
		checkform.hAddnewDate.value = pNgay;
		checkform.hBookID.value = '';		
		checkform.action = 'LichTrucLe_ADDNEW.ASP';
		checkform.submit();
	}
	function Edit(pBookID){
		checkform.hAction.value = 'update';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'LichTruc_ADDNEW.ASP';
		checkform.submit();
	}
	function Delete(pBookID){
		if (confirm('Ban co chac chan khong?')){
			checkform.hAction.value = 'delete';
			checkform.hBookID.value = pBookID;		
			checkform.action = 'LichTruc_PROCESS.ASP';
			checkform.submit();
		}
	}
	function scrollWeek(n)                                              
	{                                              
		if (n==1) document.checkform.ActType.value = "NextWeek";                                              
		if (n==-1) document.checkform.ActType.value = "PrevWeek";                                              
		document.checkform.submit();                                              
	}  
	function SelectDate(oneDay)                                              
	{                                              
		document.checkform.ActType.value = "ChangeDay";                                              
		document.checkform.SelectDay.value = oneDay;                                              
		document.checkform.submit();                                              
	}   
	function filter()
	{
		document.checkform.submit();
	}  
	function ViewOneDay(){
		FileWindow = window.open('CAL_WEEK_ONEDAY.ASP','Recipient','toolbar=0,scrollbars=1, alwaysRaised=Yes, width=700, height=540,1 ,align=center');
		FileWindow.focus();
	}  
</script>
</head>
<%
		Dim Conn
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING
		
		strType			= request("hType")
		strSelectedDate = request("SelectDay")		
		strNguoiTrucID	= request("cboNguoiTruc")
		
		if Request("SelectDay")="" then
			SelectDay = DateValue(Now() + 7 - Weekday(Now() + 7) + 7)
			'Response.Write weekday(selectDay) & "," & selectday
		else			
			SelectDay = DateValue(Request("SelectDay"))
			'Response.Write weekday(selectDay) & "," & selectday
		end if

		if Weekday(SelectDay) = 1 then
			'Response.Write SelectDay & "1"
			WeekFrom = DateValue(SelectDay - 1)
		else
			'Response.Write SelectDay & "2"
			WeekFrom = DateValue(SelectDay - Weekday(SelectDay) + 7)
		end if
		
		Select Case Request("ActType")
			Case "ChangeDay"
				if Weekday(SelectDay) = 1 then
					WeekFrom = DateValue(SelectDay - Weekday(SelectDay))
				else
					WeekFrom = DateValue(SelectDay - Weekday(SelectDay) + 7)
				end if
			Case "PrevWeek"
				WeekFrom = WeekFrom - 7
				SelectDay = SelectDay - 7
			Case "NextWeek"
				WeekFrom = WeekFrom + 7
				SelectDay = SelectDay + 7		
			Case "ContentCancel"
				'nothing to do
		End Select
		
		strQuery = "BeginDay=" & WeekFrom & "&"
		strQuery = strQuery & "SelectDay=" & SelectDay
		
		'Response.Write Weekday(date())
		'Response.End
		IF strType <> "A" then strType= "R" 'Approve as Registry
	%>
<!--#include file = "IncBeginSub.asp"-->
<body text="#000000"  topmargin=0 leftmargin=0   background="Images/bg.gif">
<form name="checkform" action="LichTruc_List.ASP" method="POST">
	<input type="hidden" name="hAddnewDate" value="">	
	<input type="hidden" name="hAction" value="">
	<input type="hidden" name="hBookID" value="">
	
	<input type="hidden" name="ActType" value="">
    <input type="hidden" name="WhichOne" value="">
    
    <input type="hidden" name="hQuery" value="<%=strQuery%>">
    
    <input type="hidden" name="BeginDay" value="<%=WeekFrom%>">
    <input type="hidden" name="SelectDay" value="<%=SelectDay%>">                                              
    <input type="hidden" name="MonthOnCalendar" value="<%=CalCurrent%>">                                              
    <input type="hidden" name="ContentID" value="<%=ContentID%>">                                              
    <input type="hidden" name="hBack" value="LichTruc_List.asp"> 
    <input type="hidden" name=txtNgay size = 7 value="<%=Datevaluevn(SelectDay)%>">
<table width="760">
	<tr>
		<td width="100%" align="left"><img src="images\text_LichT7CN.gif" border="0"></td>
	</tr>
	<tr>
		<td width="100%">
			<table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
				<tr>
					<td width="*"><%call ShowToolBar()%></td>
					<td width="35%" align="right"><%call ShowTimeBar()%></td>
				</tr>				
			</table>
		</td>    
	</tr>
	<tr>
	  <td width="100%"><%call Show_Lich(WeekFrom,SelectDay)%></td>
	</tr>   
</table>
</form>
</body>
</html>
<!--#include file = "IncEndSub.asp"-->
<%
	SET Conn=nothing
%>
<%sub Show_Lich(p_FromDate, p_SelectedDate)
	dim i
	dim curDate
	dim arrThu	
	dim rs 
	
	arrThu = split("Th&#7913; b&#7843;y,Ch&#7911; nh&#7853;t",",")
	curDate =  p_FromDate
	
	set rs = server.CreateObject("ADODB.Recordset")
	
	
	rs.open "SELECT BookType_ID, BookType, VietTat FROM BookTypes WHERE  BookType_ID ='LT' ORDER BY STT", conn,3,3
%>
	<table cellSpacing="0" cellPadding="0" width="100%" class="QH_TableMain"  background="Images/bg.gif">
		<tr valign="middle" height="25">
			<td width="10%"  class="QH_DataGridHeader"  align="center">Thứ/Ngày</td>			
			<td width="45%"  class="QH_DataGridHeader"  align="center">Sáng</td>
			<td width="1"></td>
			<td width="*"  class="QH_DataGridHeader"  align="center">Tối</td>
		</tr>			
	<%for i=0 to 1
		curDate = p_FromDate + i
		if curDate = p_SelectedDate then 
			ColorNgay = Col_Color1
		else
			ColorNgay = Col_Color2
		end if
	IF Not rs.eof then%>	
		<%while not rs.eof%>
			<tr>
				<td align="center" class="QH_LabelBold"   valign="top" bgcolor="<%=ColorNgay%>">					
						<%=arrThu(i)%><br><!--<a href="javascript:SelectDate('<%=curDate%>')">--><%=left(DateValueVN(curDate),5)%><!--</a>--><br>
						<%=rs("VietTat")%><br><!--<HR color=Brown width="80%" size=1>-->
					<a href = "javascript:AddNew('<%=DateValueVN(curDate)%>','<%=rs("BookType_ID")%>');"><img width="32" height="32" src="images\CAL_Week_New.gif" border="0" alt="Dang ky lich truc"></a>
				</td>
				<td class="QH_Label" align="center" valign="top">am<%call ShowOneDay(DateValueVN(curDate),"S", strNguoiTrucID)%>&nbsp;</td>				
				<td width="1" bgcolor="<%=ColorNgay%>"></td>
				<td class="QH_Label" align="center" valign="top">pm<%call ShowOneDay(DateValueVN(curDate),"T", strNguoiTrucID)%>&nbsp;</td>
			</tr>
			<tr>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
			</tr>
		<%
			rs.movenext
		wend		
		rs.movefirst()
		End if%>
	<%next%>
	</table>
<%	set rs=nothing
	end sub%>

<%sub ShowOneDay(p_Day, p_Buoi, p_NguoiTrucIDID) 'Type=1:TT/QU;2:UBND
	dim strSQL 
	dim rs
	
	
	set rs=server.CreateObject("ADODB.Recordset")
	
	strSQL = "LichTruc_GetOneDay "
	strSQL = strSQL & "@p_Date = '" & p_Day & "',"
	strSQL = strSQL & "@p_Buoi = '" & p_Buoi & "',"
	strSQL = strSQL & "@p_NguoiTrucID = '" & p_NguoiTrucIDID & "'"
	
	
	
	'Response.Write strSQL
	'Response.End
	rs.open strSQL, conn, 3,3
	
	if not rs.eof then
		while not rs.eof 
%>
	<table cellspacing="2" width="100%">
		<tr>
			<td width="100%" class="QH_LabelDisplay"><p align="justify">
				<b>Người trực:</b>&nbsp;<%=rs("NguoiTruc")%><br>
				<b>Đơn vị:</b>&nbsp;<%=rs("BoPhan")%><br>
				<b>Chức vụ:</b>&nbsp;<%=rs("ChucVu")%>&nbsp;&nbsp;&nbsp;
				<a href="javascript:Edit('<%=rs("Book_ID")%>');"><img src="images\edit.gif" border="0" alt="sua noi dung lich truc"></a>&nbsp;<a href="javascript:Delete('<%=rs("Book_ID")%>');"><img src="images\del.gif" border="0" alt="Xoa lich truc"></a><br><br>
			</p></td>
		</tr>
	</table>	
<%
			rs.movenext
		wend
	else
		Response.Write "&nbsp;"
	end if
%>
	
<%end sub%>

<%
	Function DateValueVN(conDate)
	if Day(conDate)<10 then
		p1 = "0" & Day(conDate)
	else
		p1 = Day(conDate)
	end if
	if Month(conDate)<10 then
		p2 = "0" & Month(conDate)
	else
		p2 = Month(conDate)
	end if

	DateValueVN =  p1 & "/" & p2 & "/" & Year(conDate)
End Function
%>
<%sub ShowToolBar()%>
	 <table cellpadding="0" cellspacing="2" width="100%">
		<tr valign="absmiddle">			
			<td width="30%" class="QH_Label" valign="absmiddle"><a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a></td>
			<td width="30%" class="QH_Label" valign="absmiddle"><a href="LICHTRUC_APPROVED.ASP" ><img alt="Xem lich chinh thuc" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Lịch trực</a></td>
			<td width="*">&nbsp;</td>
		</tr>
	</table>
<%END sub%>

<%sub ShowTimeBar()%>
	 <table cellpadding="0" cellspacing="2" width="100%" >
		<tr>
			<td width="100%" align="right" >
				<table border="0" cellpadding="0" cellspacing="0"><tr valign = middle><td>
				<a onmouseover="document['fpAnimswapImgFP1'].imgRolln=document['fpAnimswapImgFP1'].src;document['fpAnimswapImgFP1'].src=document['fpAnimswapImgFP1'].lowsrc;" onmouseout="document['fpAnimswapImgFP1'].src=document['fpAnimswapImgFP1'].imgRolln" href="javascript:scrollWeek(-1)">
				<img border="0" align="absMiddle" src="images/Prev_Button.gif" id="fpAnimswapImgFP1" name="fpAnimswapImgFP1" dynamicanimation="fpAnimswapImgFP1" lowsrc="images/Prev_Button_Over.jpg" alt="Xem lich tuan truoc"></a>				
				</td>
				<td class="QH_Label">
				<nobr><b><%=" T&#7915; ng&#224;y " & DateValueVN(WeekFrom) & " &#273;&#7871;n " & DateValueVN(WeekFrom + 1) & " "%></b></nobr>
				</td>
				<td>
				<a onmouseover="document['fpAnimswapImgFP2'].imgRolln=document['fpAnimswapImgFP2'].src;document['fpAnimswapImgFP2'].src=document['fpAnimswapImgFP2'].lowsrc;" onmouseout="document['fpAnimswapImgFP2'].src=document['fpAnimswapImgFP2'].imgRolln" href="javascript:scrollWeek(1)">				
				<img border="0" align="absMiddle" src="images/Next_Button.gif" id="fpAnimswapImgFP2" name="fpAnimswapImgFP2" dynamicanimation="fpAnimswapImgFP2" lowsrc="images/Next_Button_Over.jpg" alt="Xem lich tuan sau"></a>
				</TD>
				<td>
				&nbsp<a href="javascript:DispDate2(checkform.txtNgay);"><img src="images\button_calendar.gif" border="0"></a>
				</td></tr></table>
			</td>
			</tr>
	</table>
<%END sub%>