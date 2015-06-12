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
<script language = "javascript" src="inc/popcalendar.js"></script>
<script language="javascript">
function testpopUpCalendar(ctrl,ctrl2,format){
	popUpCalendar(ctrl,ctrl2,format);
}
function setOrder(BookID, curPos, orderType){
	checkform.hAction.value = 'updorder';
	checkform.hBookID.value = BookID;
	checkform.txtStt.value = curPos;
	checkform.OrderAction.value = orderType;
	checkform.action = 'LichTrucLe_PROCESS.ASP';
	checkform.submit();
}
	function AddNew(selectedDate){
		checkform.hAction.value = 'addnew';
		checkform.hBookID.value = '';
		checkform.SelectDay.value = selectedDate;
		checkform.action = 'LichTrucLe_ADDNEW.ASP';
		checkform.submit();
	}
	function Edit(pBookID){
		checkform.hAction.value = 'update';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'LichTrucLe_ADDNEW.ASP';
		checkform.submit();
	}
	function Delete(pBookID){
		if (confirm('Ban co chac chan khong?')){
			checkform.hAction.value = 'delete';
			checkform.hBookID.value = pBookID;		
			checkform.action = 'LichTrucLe_PROCESS.ASP';
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
	function printPreview(){
		checkform.action = 'LICHTRUCLE_APPROVED.ASP';
		checkform.submit();
	}
</script>
</head>
<%
		Dim Conn
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING
		
		strType			= request("hType")
		
		if Request("SelectDay")="" then
			SelectDay = DateValue(Now() + 7 - Weekday(Now() + 7) + 2 )
		else			
			SelectDay = DateValue(Request("SelectDay"))
		end if

		if Weekday(SelectDay) = 1 then
			WeekFrom = DateValue(SelectDay + 1)
		else
			WeekFrom = DateValue(SelectDay - Weekday(SelectDay) + 2 )
		end if
		
		Select Case Request("ActType")
			Case "ChangeDay"
				if Weekday(SelectDay) = 1 then
					WeekFrom = DateValue(SelectDay - 6)
				else
					WeekFrom = DateValue(SelectDay - Weekday(SelectDay) + 2)
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
<form name="checkform" action="LichTrucLe_List.ASP" method="POST">
	<input type="hidden" name="hAddnewDate" value="">	
	<input type="hidden" name="hAction" value="">
	<input type="hidden" name="hBookID" value="">
	
	<input type="hidden" name="ActType" value="">
    <input type="hidden" name="hQuery" value="<%=strQuery%>">
    
    <input type="hidden" name="BeginDay" value="<%=WeekFrom%>">
    <input type="hidden" name="SelectDay" value="<%=SelectDay%>">                                              
    <input type="hidden" name="MonthOnCalendar" value="<%=CalCurrent%>">                                              
    <input type="hidden" name="ContentID" value="<%=ContentID%>">                                              
    <input type="hidden" name="hBack" value="LichTrucLe_List.asp"> 
    <input type="hidden" name=txtNgay size = 7 value="<%=Datevaluevn(SelectDay)%>">
    <input type="hidden" name="OrderAction" ID="Hidden1">
    <input type="hidden" name="txtStt" ID="Hidden2">
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
	'dim rs 
	
	arrThu = split("Th&#7913; hai,Th&#7913; ba,Th&#7913; t&#432;,Th&#7913; n&#259;m,Th&#7913; s&#225;u,Th&#7913; b&#7843;y,Ch&#7911; nh&#7853;t",",")
	curDate =  p_FromDate
	
	'set rs = server.CreateObject("ADODB.Recordset")
	
	
	'rs.open "SELECT * FROM LICHTRUCLE ORDER BY Ngay DESC, Gio DESC", conn,3,3
%>
	<table cellSpacing="0" cellPadding="0" width="100%" class="QH_TableMain"  background="Images/bg.gif">
		<tr valign="middle" height="25">
			<td width="10%"  class="QH_DataGridHeader"  align="center">Thứ/Ngày</td>			
			<td width="*"  class="QH_DataGridHeader"  align="center">Chi tiết</td>
		</tr>			
	<%for i=0 to 6
		curDate = p_FromDate + i
		'if curDate = p_SelectedDate then 			
			ColorNgay = Col_SelectedColor 'Mau selected
		'else
			if i mod 2= 0 then 
				ColorNgay = Col_Color1 'mau dam
			else 
				ColorNgay = Col_Color2 'mau lot
			end if
		'end if
	%>	
			<tr>
				<td class="QH_LabelBold" align="center" valign="top" bgcolor="<%=ColorNgay%>">					
						<%=arrThu(i)%><br>
						<%=left(DateValueVN(curDate),5)%><br>
						<a href = "javascript:AddNew('<%=DateValueVN(curDate)%>');"><img width="32" height="32" src="images\CAL_Week_New.gif" border="0" alt="Dang ky lich hop"></a>
				</td>
				<td class="QH_Label" align="center" valign="top">
					<%call ShowOneDay(DateValueVN(curDate))%>
				</td>
			</tr>
			<tr>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
			</tr>
	<%next%>
	</table>
<%	set rs=nothing
	end sub%>

<%sub ShowOneDay(p_Day) 'Type=1:TT/QU;2:UBND
	dim strSQL 
	dim rs
	
	
	set rs=server.CreateObject("ADODB.Recordset")
	
	strSQL = "LichTrucLe_GetOneDay "
	strSQL = strSQL & "@p_Date = '" & p_Day & "'"
	
	'Response.Write strSQL
	'Response.End
	rs.open strSQL, conn, 3,3

	IF NOT rs.eof Then
		while not rs.eof
		%>
			<table cellpadding="0" cellspacing="2" width="95%" ID="Table1">
				<tr>
					<td width="13%" align="left" valign="top" class="QH_LabelDisplay">
						<%if rs("TieuDe") <> "" then%>
							<b>Lịch trực :</b><br>
						<%end if%>
					</td>
					<td width="*" class="QH_LabelDisplay">	
						<%if rs("TieuDe") <> "" then%>
							<b><%=rs("TieuDe")%></b><br>
						<%end if%>
					</td>
				</tr>
				<tr>
					<td width="13%" align="left" valign="top" class="QH_LabelDisplay">
						<%=rs("Gio")%><br>
						<%=rs("TinhTrang")%>
					</td>
					<td width="*" class="QH_LabelDisplay">
						<%if rs("TenDV") <> "" then%>
							<b>Đơn vị:</b>&nbsp;<%=rs("TenDV")%><br>
						<%end if%>
						
						<%if rs("LanhDao") <> "" then%>
							<b>Lãnh đạo:</b>&nbsp;<font color='red'><%=rs("LanhDao")%></font><br>
						<%end if%>
						
						<%if rs("CanBo") <> "" then%>
							<b>Cán bộ trực:</b>&nbsp;<font color='red'><%=rs("CanBo")%></font><br>
						<%end if%>
						
						<%if rs("TaiXe") <> "" then%>
							<b>Tài xế:</b>&nbsp;<%=rs("TaiXe")%><br>
						<%end if%>
						
						<%if rs("PhucVu") <> "" then%>
							<b>Phục vụ:</b>&nbsp;<%=rs("PhucVu")%><br>
						<%end if%>
						
						<%if rs("BaoVe") <> "" then%>
							<b>Bảo vệ:</b>&nbsp;<%=rs("BaoVe")%><br>
						<%end if%>
					</td>	
				</tr>
				<tr>
					<td></td>
					<td>
						<%if date() <= (WeekFrom + MaxNgay -1) then 
							Call ShowEditAction(rs("Book_ID"), rs("STT"), rs("TopBottom"))
						end if
						%>
					</td>
				</tr>
				<tr><td>&nbsp;</td><td></td></tr>
			</table>
		<%	rs.movenext
			wend 
	else
		Response.Write "&nbsp;"
	end if
	set rs=nothing
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
			<td width="30%" class="QH_Label" valign="absmiddle"><img alt="Them ngay nghi le" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Ngày nghỉ lễ</td>
			<td width="30%" class="QH_Label" valign="absmiddle"><a href="javascript:printPreview();" ><img alt="Xem lich chinh thuc" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Lịch trực</a></td>
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
				<nobr><b><%=" T&#7915; ng&#224;y " & DateValueVN(WeekFrom) & " &#273;&#7871;n " & DateValueVN(WeekFrom + 6) & " "%></b></nobr>
				</td>
				<td>
				<a onmouseover="document['fpAnimswapImgFP2'].imgRolln=document['fpAnimswapImgFP2'].src;document['fpAnimswapImgFP2'].src=document['fpAnimswapImgFP2'].lowsrc;" onmouseout="document['fpAnimswapImgFP2'].src=document['fpAnimswapImgFP2'].imgRolln" href="javascript:scrollWeek(1)">				
				<img border="0" align="absMiddle" src="images/Next_Button.gif" id="fpAnimswapImgFP2" name="fpAnimswapImgFP2" dynamicanimation="fpAnimswapImgFP2" lowsrc="images/Next_Button_Over.jpg" alt="Xem lich tuan sau"></a>
				</TD>
				<td>
				&nbsp <img id="imgdate" src="images\button_calendar.gif" onclick="javascript:testpopUpCalendar(this,txtNgay,'dd/mm/yyyy')" border="0">
				</td></tr></table>
			</td>
			</tr>
	</table>
<%END sub%>

<%sub ShowEditAction(p_BookID, p_curPos, p_PosType)%>
	&nbsp;&nbsp;&nbsp;&nbsp;
	<a href="javascript:Edit('<%=p_BookID%>');"><img  src="images\edit.gif" border="0" alt="Sua lich truc"></a>
	<a href="javascript:Delete('<%=p_BookID%>');"><img  src="images\del.gif" border="0" alt="Xoa lich truc"></a>
	<%if p_PosType <> 0 and p_PosType <> 3 then'Not Top%>
	<a href="javascript:setOrder('<%=p_BookID%>','<%=p_curPos%>','up');"><img  src="images\order_up.gif" border="0" alt="chuyen len"></a>
	<%end if%>
	<%if p_PosType <> 2 and p_PosType <> 3 then'Not Bottom%>
	<a href="javascript:setOrder('<%=p_BookID%>','<%=p_curPos%>','down');"><img  src="images\order_down.gif" border="0" alt="chuyen xuong"></a>
	<%end if%>
<%END sub%>