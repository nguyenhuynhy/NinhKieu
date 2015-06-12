<!--#include file = "Security.asp"-->
<html>
<head>
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Dang ky lich cong tac tuan</title>
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
<script language="JavaScript1.2" fptype="dynamicanimation" src="inc/animate.js"></script>
<script language = "javascript" src="inc/common.js"></script>
<script language = "javascript" src="inc/popcalendar.js"></script>
<script language="javascript">
function testpopUpCalendar(ctrl,ctrl2,format){
	//alert(ctrl);
	//alert(ctrl2);
	//alert(format);
	popUpCalendar(ctrl,ctrl2,format);
}
function ShowReport(report, sql, param,value)
{
	width = screen.width;
	height = screen.height;
	l = 0;
	t = 0;
	
	//alert(opt);
	FileWindow = window.open('Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','location=no,toolbar=no,resizable,scrollbars=yes, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
	FileWindow.focus();				
	return true;
}

function Form_Print(WeekFrom, Location, Chairman, Type)
{
	report = "rpt_LichCongTac.rpt";
	//alert('1' + WeekFrom + '2' + Location + '3' + Chairman);
	strSQL = "Rpt_Lichlamviec_DuKien " +
		"@FromDay	= '" + WeekFrom + "'," +
		"@Location	= '" + Location + "'," +
		"@ChairMan	= '" + Chairman + "'";
	ShowReport(report, strSQL, "", "");
}

function inbaocao(strFromDay, strType, strLocation, strChairMan)
{//,'top=0,left=0,width=800,height=600'
	//if (strType == '1')
	//	FileWindow = window.open('Comm_rptInLichlamviecUB_QU.asp?FromDay=' + strFromDay + '&Location=' + strLocation + '&ChairMan=' + strChairMan,null);
	//else
	//	FileWindow = window.open('Comm_rptInLichlamviecDT.asp?FromDay=' + strFromDay + '&Location=' + strLocation + '&ChairMan=' + strChairMan,null);
	//FileWindow.focus();
	Form_Print(strFromDay, strLocation, strChairMan, strType);
}
	function AddNew(pNgay, pType){
		checkform.hAction.value = 'addnew';
		checkform.hAddnewDate.value = pNgay;
		checkform.hAddnewType.value = pType;
		checkform.hBookID.value = '';
		checkform.action = 'CV_CAL_WEEK_ADDNEW.ASP';
		checkform.submit();
	}
	
	function Edit(pBookID){
		checkform.hAction.value = 'update';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'CV_CAL_WEEK_ADDNEW.ASP';
		checkform.submit();
	}
	function Delete(pBookID){
		if (confirm('Ban co chac chan khong?')){
			checkform.hAction.value = 'delete';
			checkform.hBookID.value = pBookID;		
			checkform.action = 'CAL_WEEK_PROCESS.ASP';
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
		strLocationID	= request("cboLocation")
		strChairManID	= request("cboChairMan")
		
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
		strQuery = strQuery & "SelectDay=" & SelectDay & "&"
		strQuery = strQuery & "cboChairMan=" & strChairManID & "&"
		strQuery = strQuery & "cboLocation=" & strLocationID
		
		'Response.Write Weekday(date())
		'Response.End
		IF strType <> "A" then strType= "R" 'Approve as Registry
	%>
<!--#include file = "IncBeginSub.asp"-->
<body text="#000000" topmargin=0 leftmargin=0 background=Images/bg.gif>
<center>
<form name="checkform" action="CAL_WEEK_LIST.ASP" method="POST">
	<input type="hidden" name="hAddnewDate" value="">
	<input type="hidden" name="hAddnewType" value="">
	<input type="hidden" name="hAction" value="">
	<input type="hidden" name="hBookID" value="">
	
	<input type="hidden" name="ActType" value="">
    <input type="hidden" name="WhichOne" value="">
    
    <input type="hidden" name="hQuery" value="<%=strQuery%>">
    
    <input type="hidden" name="BeginDay" value="<%=WeekFrom%>">
    <input type="hidden" name="SelectDay" value="<%=SelectDay%>">                                              
    <input type="hidden" name="MonthOnCalendar" value="<%=CalCurrent%>">                                              
    <input type="hidden" name="ContentID" value="<%=ContentID%>">                                              
    <input type="hidden" name="hBack" value="CAL_WEEK_LIST.asp"> 
    <input type="hidden" name=txtNgay size = 7 value="<%=Datevaluevn(SelectDay)%>">
<table cellspacing="1" width="100%">  
  <tr> 
    <td width="100%">
		<table cellpadding="0" cellspacing="2" width = 100% align=center>						
			<tr>
				<td width="*" rowspan="2" align="left"><img src="images\text_DangKyLichTuan.gif"></td> 
				<td width="10%" class="QH_ColLabel" align = right nowrap>Địa điểm</td>
				<td width="200"><%call MakeCbo("cboLocation","COMM_GetLocation",strLocationID,"ID","LocationName","200","1"," onchange='javascript:filter();'")%></td>						
			</tr>
			
			<tr> 
				<td width="10%" class="QH_ColLabel" align = right nowrap>Người chủ trì</font></td>
				<td><%call MakeCbo("cboChairMan","COMM_GetChairMan",strChairManID,"UserID","FullName","200","1"," onchange='javascript:filter();'")%>
			</tr> 					
		</table>	
    </td>
  </tr>  
	<tr>
		<td>
			<table border="0" cellpadding="0" cellspacing="0" width = 100% align = center>
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
	<tr>
		<td>
			<table cellpadding="0" cellspacing="0" width = 100% align = center>
				<tr>
					<td width="*"><%call ShowToolBar()%></td>
					<td width="35%" align="right"><%call ShowTimeBar()%></td>
				</tr>				
			</table>
		</td>
	</tr>   
</table>
</form>
</center>
</body>
</html>
<%
	SET Conn=nothing
%>
<!--#include file = "IncEndSub.asp"-->
<%sub Show_Lich(p_FromDate, p_SelectedDate)
	dim i
	dim j
	dim curDate
	dim arrThu	
	dim rs 
	
	arrThu = split("hai,ba,t&#432;,n&#259;m,s&#225;u,b&#7843;y,ch&#7911; nh&#7853;t",",")
	curDate =  p_FromDate
	
	set rs = server.CreateObject("ADODB.Recordset")
	
	
	rs.open "SELECT BookType_ID, BookType, VietTat FROM BookTypes WHERE SHOW='1' AND BookType_ID IN ('QU','UB') ORDER BY STT", conn,3,3
	'Redim arrType(rs.RecordCount)
	'Response.Write rs.RecordCount
	'i=0
	'WHILE not rs.eof
	'	arrType(i) = rs("BookType_ID")
	'	i=i + 1	
	'	rs.movenext
	'wend 
%>
	<table cellSpacing="0" class="QH_TableMain"	cellPadding="0" width="100%" background="Images/bg.gif">
		<tr valign="middle" height="25">
			<td width="10%" class="QH_DataGridHeader" align="center">Thứ/Ngày</td>
			<td width="45%" class="QH_DataGridHeader" align="center">Sáng</td>
			<td width="1"></td>
			<td width=*" class="QH_DataGridHeader" align="center">Chiều</td>
		</tr>			
	<%for i=0 to MaxNgay -1
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
		<%j = 0
		while not rs.eof%>
			<tr>
				<td align="center" class="QH_LabelBold"  valign="top" bgcolor="<%=ColorNgay%>">					
						<%if j=0 then%>Thứ <%=arrThu(i)%><br>
						<%=left(DateValueVN(curDate),5)%><br><%end if%>
						<%=rs("VietTat")%><br><!--<HR color=Brown width="80%" size=1>-->
						<%if rs("BookType_ID")="UB" then%><a href = "javascript:AddNew('<%=DateValueVN(curDate)%>','<%=rs("BookType_ID")%>');"><img src="images\Template1\Book.gif" border="0" alt="Dang ky lich hop"></a><%end if%>
				</td>
				<td class="QH_Label" align="center" valign="top"><%call ShowOneDay(DateValueVN(curDate),"S",rs("BookType_ID"),strLocationID, strChairManID)%></td>
				<td width="1" bgcolor="<%=ColorNgay%>"></td>
				<td class="QH_Label" align="center" valign="top"><%call ShowOneDay(DateValueVN(curDate),"C",rs("BookType_ID"),strLocationID, strChairManID)%></td>
			</tr>
			<tr>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
			</tr>
		<%
			rs.movenext
			j = j + 1
		wend		
		rs.movefirst()
		%>
	<%next%>
	</table>
<%	set rs=nothing
	end sub%>

<%sub ShowOneDay(p_Day, p_AMPM, p_Type, p_LocationID, p_ChairManID) 'Type=1:TT/QU;2:UBND
	dim strSQL 
	dim rs
	
	
	set rs=server.CreateObject("ADODB.Recordset")
	
	strSQL = "Book_GetOneDay "
	strSQL = strSQL & "@p_Date = '" & p_Day & "',"
	strSQL = strSQL & "@p_Type = '" & p_Type & "',"
	strSQL = strSQL & "@p_LocationID = '" & p_LocationID & "',"
	strSQL = strSQL & "@p_ChairManID = '" & p_ChairManID & "',"
	strSQL = strSQL & "@p_Time = '" & p_AMPM & "',"
	strSQL = strSQL & "@p_MaBoPhan = '" & Session("MaBoPhan") & "'"
	
	'Response.Write strSQL
	'Response.End
	rs.open strSQL, conn, 3,3
	
	IF NOT rs.eof Then
		while not rs.eof
		%>
			<table cellpadding="0" cellspacing="2"width="95%">
				<tr>
					<td width="13%" align="left" valign="top" class="QH_LabelDisplay">
						<%=rs("Gio") & ":" & rs("Phut")%><br><br>
						<%if rs("BookBy")=Session("UserID") And rs("Approved")="N" then%><a href="javascript:Edit('<%=rs("Book_ID")%>');"><img src="images\edit.gif" border="0" alt="sua noi dung lich hop"></a>&nbsp;<a href="javascript:Delete('<%=rs("Book_ID")%>');"><img src="images\del.gif" border="0" alt="Xoa lich hop"></a><%end if%>
					</td>
					<td width="*" class="QH_LabelDisplay"><p align="justify">
						<b>Nội dung:</b>&nbsp;<%=rs("Content")%><br>
						<%if rs("ChairMan") <> "" then%>
							<b>Người chủ trì:</b>&nbsp;<font color='red'><%=rs("ChairMan")%></font><br>
						<%end if%>
						<%if rs("Location") <> "" then%>
							<b>Địa điểm:</b>&nbsp;<%=rs("Location")%><br>
						<%end if%>
						<%if rs("JoinMember") <> "" then%>
							<b>TP:</b>&nbsp;<%=rs("JoinMember")%><br>
						<%end if%>
						<%if rs("NguoiDangKy") <> "" then%>
							<b>Người đăng ký:</b>&nbsp;<%=rs("NguoiDangKy")%> <br>
						<%end if%>
						<%if rs("Note") <> "" then%>
							<b>Chuẩn bị:</b>&nbsp;<%=rs("Note")%> <br>
						<%end if%>
						<b>Loại lịch:</b>&nbsp;<font color='red'><%=rs("NgoaiLich")%></font><br>
						<b>Tình trạng:&nbsp;<%=rs("TrangThai")%></b><br><br>
					</p></td>
				</tr>
			</table>

		<%		rs.movenext
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
			<!--<td class="QH_Label"  width="20%" valign="absmiddle"><a href="javascript:location.href='../Home.asp';" ><img alt="Tro ve trang chu" src="images/home.gif" border="0" align="absmiddle">&nbsp;Trang chủ</a></td>-->
			<td class="QH_Label"  width="22%" valign="absmiddle"><a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a></td>
			<td width="25%" class="QH_Label" valign="absmiddle"><a href="javascript:inbaocao('<%=DateValueVN(WeekFrom)%>','<%=strType%>','<%=strLocationID%>','<%=strChairManID%>')" ><img alt="In lich lam viec" src="images/print.gif" border="0" align="absmiddle">&nbsp;In lịch</a></td>
			<!--td class="QH_Label" width="20%" valign="absmiddle"><a href="LICHTRUC_APPROVED.ASP" ><img alt="Xem lich truc" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Lịch trực</a></td>-->
			<td class="QH_Label" width="*" ></td>
		</tr>
	</table>
<%END sub%>

<%sub ShowTimeBar()%>
	 <table cellpadding="0" cellspacing="2"width="100%">
		<tr>
			<td width="100%" align="right" >
				<table cellpadding="0" cellspacing="0"><tr valign = middle><td>
				<a onmouseover="document['fpAnimswapImgFP1'].imgRolln=document['fpAnimswapImgFP1'].src;document['fpAnimswapImgFP1'].src=document['fpAnimswapImgFP1'].lowsrc;" onmouseout="document['fpAnimswapImgFP1'].src=document['fpAnimswapImgFP1'].imgRolln" href="javascript:scrollWeek(-1)">
				<img border="0" align="absMiddle" src="images/Prev_Button.gif" id="fpAnimswapImgFP1" name="fpAnimswapImgFP1" dynamicanimation="fpAnimswapImgFP1" lowsrc="images/Prev_Button_Over.jpg" alt="Xem lich tuan truoc"></a>				
				</td>
				<td class="QH_Label">
				<nobr><b><%=" T&#7915; ng&#224;y " & DateValueVN(WeekFrom) & " &#273;&#7871;n " & DateValueVN(WeekFrom + MaxNgay -1) & " "%></b></nobr>
				</td>
				<td>
				<a onmouseover="document['fpAnimswapImgFP2'].imgRolln=document['fpAnimswapImgFP2'].src;document['fpAnimswapImgFP2'].src=document['fpAnimswapImgFP2'].lowsrc;" onmouseout="document['fpAnimswapImgFP2'].src=document['fpAnimswapImgFP2'].imgRolln" href="javascript:scrollWeek(1)">				
				<img border="0" align="absMiddle" src="images/Next_Button.gif" id="fpAnimswapImgFP2" name="fpAnimswapImgFP2" dynamicanimation="fpAnimswapImgFP2" lowsrc="images/Next_Button_Over.jpg" alt="Xem lich tuan sau"></a>
				</TD>
				<td>
			
				&nbsp<img id="imgdate" src="images\button_calendar.gif" onclick="javascript:testpopUpCalendar(this,txtNgay,'dd/mm/yyyy')" border="0">
				</td></tr></table>
				<!--<input type=button name=cmdNgayKy  onclick="javascript:DispDate(frm.txtNgayTruc);" value=">>" style="FONT-SIZE: 12px; BACKGROUND-COLOR: lightskyblue">-->
			</td>
			</tr>
	</table>
<%END sub%>
