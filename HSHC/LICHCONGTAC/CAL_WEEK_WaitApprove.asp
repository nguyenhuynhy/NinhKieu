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
	//alert(ctrl);
	//alert(ctrl2);
	//alert(format);
	popUpCalendar(ctrl,ctrl2,format);
}
function ShowReport(report, sql, param,value)//, subreport, subsql, subparam, subvalue)
{
	width = screen.width;// - 20;
	height = screen.height;// - 100;
	l = 0;//(screen.width - 10 - width)/2;
	t = 0;//(screen.height -  10 - height)/2;	
	
	//alert(opt);
	//FileWindow = window.open('Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value + '&subreport=' + subreport + '&sqlSub=' + subsql + '&subformula=' + subparam + '&subValue=' + subvalue + '&IsIncludeSub=yes','_blank','location=yes,toolbar=no,resizable,scrollbars=yes, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
	FileWindow = window.open('Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','location=no,toolbar=no,resizable,scrollbars=yes, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
	FileWindow.focus();				
	return true;
}

function Form_Print(WeekFrom, Location, Chairman, Type)
{
	var report = "rpt_LichCongTac.rpt";;
	var strSQL = "Rpt_Lichlamviec " +
			"@FromDay	= '" + WeekFrom + "'," +
			"@Location	= '" + Location + "'," +
			"@ChairMan	= '" + Chairman + "'";
	if(Type == '1'){
		report = "rpt_LichCongTac.rpt";
		strSQL = "Rpt_Lichlamviec " +
			"@FromDay	= '" + WeekFrom + "'," +
			"@Location	= '" + Location + "'," +
			"@ChairMan	= '" + Chairman + "'";
	}
	else{
		//report = "rpt_inlichlamviecTD.rpt";
		//strSQL = "CreateDateWeek " +
		//	"@FromDay	  = '" + WeekFrom  + "'";
	}

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
function setOrder(BookID, curPos, orderType){
	checkform.hAction.value = 'updorder';
	checkform.hBookID.value = BookID;
	checkform.txtStt.value = curPos;
	checkform.OrderAction.value = orderType;
	checkform.action = 'CAL_WEEK_PROCESS.ASP';
	checkform.submit();
}
	function AddNew(pNgay, pType){
		checkform.hAction.value = 'approved_addnew';
		checkform.hAddnewDate.value = pNgay;
		checkform.hAddnewType.value = pType;
		checkform.action = 'CAL_WEEK_ADDNEW.ASP';
		checkform.submit();
	}
	function Edit(pBookID){
		checkform.hAction.value = 'approved_update';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'CAL_WEEK_ADDNEW.ASP';
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
	function Approve(pBookID){
		checkform.hAction.value = 'approve';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'CAL_WEEK_PROCESS.ASP';
		checkform.submit();
	}
	function NotApprove(pBookID){
		checkform.hAction.value = 'notapprove';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'CAL_WEEK_PROCESS.ASP';
		checkform.submit();
	}
	function Postponse(pBookID){
		checkform.hAction.value = 'postponse';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'CAL_WEEK_PROCESS.ASP';
		checkform.submit();
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
		
		strLich			= request("cboLich")		
		strType			= request("hType")
		strSelectedDate = request("SelectDay")
		strLocationID	= request("cboLocation")
		strChairManID	= request("cboChairMan")
		
		if strLich = "" then strLich = "1"
		
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
		strQuery = strQuery & "cboLocation=" & strLocationID & "&"
		strQuery = strQuery & "cboLich=" & strLich

		
		'Response.Write Weekday(date())
		'Response.End
		IF strType <> "A" then strType= "R" 'Approve as Registry
	%>
<!--#include file = "IncBeginSub.asp"-->
<body text="#000000"  topmargin=0 leftmargin=0   background=Images/bg.gif onload="dynAnimation()">
<center>
<form name="checkform" action="CAL_WEEK_Waitapprove.ASP" method="POST">
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
    <input type="hidden" name="OrderAction" ID="Hidden1">
    <input type="hidden" name="txtStt" ID="Hidden2">
    <input type="hidden" name="hBack" value="CAL_WEEK_Waitapprove.asp"> 
    
    <input type="hidden" name=txtNgay size = 7 value="<%=Datevaluevn(SelectDay)%>">
<table cellspacing="1"width="100%">
  <tr> 
    <td width="100%">
		<table cellpadding="0" cellspacing="2" width = 100% align = center>
			<tr>
				<td width="*" rowspan="2" align="left"><img src="images\text_DuyetLich.gif"></td> 
				<td width="10%" class="QH_ColLabel" align = right nowrap>Địa điểm&nbsp;&nbsp;</td>
				<td width="200"><%call MakeCbo("cboLocation","COMM_GetLocation",strLocationID,"ID","LocationName","210","1"," onchange='javascript:filter();'")%></td>						
			</tr>
			
			<tr> 
				<td width="10%" class="QH_ColLabel" align = right nowrap>Người chủ trì&nbsp;&nbsp;</td>
				<td><%call MakeCbo("cboChairMan","COMM_GetChairMan",strChairManID,"UserID","FullName","210","1"," onchange='javascript:filter();'")%>
				<!--<a href="javascript:filter();"><img align="absMiddle" src="images/Button_ThucHien.gif" border="0"></a>--></td>
			</tr> 		
		
			
		</table>	
    </td>
  </tr>  
 <!-- <tr>
	<td width="100%">&nbsp;</td>    
	</tr>		-->
	<tr>
		<td align=left>
			<table cellpadding="0" cellspacing="0" width=100% align=center>
				<tr>
					<td width="*" align=left><%call ShowToolBar()%></td>
					<td width="35%" align=left><%call ShowTimeBar()%></td>
				</tr>				
			</table>
		</td>
	</tr> 
	<tr>
	  <td width="100%"><%call Show_Lich(WeekFrom,SelectDay, strLich)%></td>
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
</table>
</form>
</center>
</body>
</html>
<!--#include file = "IncEndSub.asp"-->
<%
	SET Conn=nothing
%>
<%sub Show_Lich(p_FromDate, p_SelectedDate, p_Lich)
	dim i
	dim curDate
	dim arrThu	
	dim rs 
	dim lich 
	
	if p_Lich = "1" then
		lich = "('UB','QU')"
	else
		lich = "('DT')"
	end if

	
	arrThu = split("Th&#7913; hai,Th&#7913; ba,Th&#7913; t&#432;,Th&#7913; n&#259;m,Th&#7913; s&#225;u,Th&#7913; b&#7843;y,Ch&#7911; nh&#7853;t",",")
	curDate =  p_FromDate
	
	set rs = server.CreateObject("ADODB.Recordset")
	
	
	'rs.open "SELECT BookType_ID, BookType, VietTat FROM BookTypes WHERE SHOW='1' BookType_ID IN " & lich & " ORDER BY STT", conn,3,3
	
	strSQL = "SELECT BookType_ID, BookType, VietTat FROM BookTypes WHERE SHOW='1' AND BookType_ID IN " & lich & " ORDER BY STT"
	'Response.Write strSQL
	'Response.End
	rs.open strSQL, conn,3,3		

	
	'Redim arrType(rs.RecordCount)
	'Response.Write rs.RecordCount
	'i=0
	'WHILE not rs.eof
	'	arrType(i) = rs("BookType_ID")
	'	i=i + 1	
	'	rs.movenext
	'wend 
%>
	<table cellSpacing="0"	class="QH_TableMain" cellPadding="0" width="100%"  background="Images/bg.gif">
		<tr valign="middle" height="25">
			<td width="10%" class="QH_DataGridHeader" align="center">Thứ/Ngày</td>
			<td width="45%" class="QH_DataGridHeader" align="center">Sáng</td>
			<td width="1"></td>
			<td width=*" class="QH_DataGridHeader" align="center">Chiều</td>
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
		<%j=0
		while not rs.eof%>
			<tr>
				<td align="center" class="QH_LabelBold"  valign="top" bgcolor="<%=ColorNgay%>">					
						<%if j=0 then%><%=arrThu(i)%><br>
						<%=left(DateValueVN(curDate),5)%><br><%end if%>
						<%=rs("VietTat")%><br><!--<HR color=Brown width="80%" size=1>-->
						<a href = "javascript:AddNew('<%=DateValueVN(curDate)%>','<%=rs("BookType_ID")%>');"><img src="images\Template1\Book.gif" border="0" alt="Dang ky lich hop"></a>
				</td>
				<td class="QH_Label"  align="center" valign="top"><%call ShowOneDay(DateValueVN(curDate),"S",rs("BookType_ID"),strLocationID, strChairManID)%>&nbsp;</td>
				<td width="1" bgcolor="<%=ColorNgay%>"></td>
				<td class="QH_Label"  align="center" valign="top"><%call ShowOneDay(DateValueVN(curDate),"C",rs("BookType_ID"),strLocationID, strChairManID)%>&nbsp;</td>
			</tr>
			<tr>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
				<td height="1px" bgcolor="<%=ColorNgay%>"></td>
			</tr>
		<%
			rs.movenext
			j=j+1
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
	strSQL = strSQL & "@p_Time = '" & p_AMPM & "'"
	'response.Write(strSQL)
	'response.end

	rs.open strSQL, conn, 3,3
	
	IF NOT rs.eof Then
		iOrder = 0
		while not rs.eof
		%>
			<table cellpadding="0" cellspacing="2" width="95%">
				<tr>
					<%if rs("ChucTho")="" then %>
						<td width="13%" align="center" valign="top" class="QH_LabelDisplay">
							<%
							'response.Write(rs("Trung"))
							if rs("Trung") = "0" then
								Response.Write(rs("Gio") & ":" & rs("Phut"))
								'Response.Write("khong trung")
							  else
								Response.Write("<font color='red'>" & rs("Gio") & ":" & rs("Phut") & "</font><br><img src='images\warning.gif'>")
								'Response.Write("trung")
							  end if
							%>
						</td>
						<td width="*" class="QH_LabelDisplay"><p align="justify">
							<b>Nội dung:</b>&nbsp;<%=ReplaceEnterChar(rs("Content"))%><br>
							<%if rs("ChairMan") <> "" then%>
								<b>Người chủ trì:</b>&nbsp;<font color='red'><%=rs("ChairMan")%></font><br>
							<%end if%>
							<%if rs("Location") <> "" then%>
								<b>Địa điểm:</b>&nbsp;<%=rs("Location")%><br>
							<%end if%>
							<%if rs("JoinMember") <> "" then%>
								<b>Thành phần:</b>&nbsp;<%=rs("JoinMember")%><br>
							<%end if%>
							<%if rs("NguoiDangKy") <> "" then%>
								<b>Người đăng ký:</b>&nbsp;<%=rs("NguoiDangKy")%><br>
							<%end if%>
							<%if rs("Note") <> "" then%>
								<b>Chuẩn bị:</b>&nbsp;<%=rs("Note")%><br>
							<%end if%>
							<b>Loại lịch:</b>&nbsp;<font color='red'><%=rs("NgoaiLich")%></font><br>
							<b>Tình trạng:</b>&nbsp;<%=rs("TrangThai")%>&nbsp;&nbsp;<%=rs("TinhTrang")%> <br>
								<%if date() <= (WeekFrom + MaxNgay -1) then Call ShowAction_1(rs("Book_ID"),rs("STT"),rs("TopBottom"))%><br>
							<br></p>
							
						</td>	
					<%else%>											
						<td width="100%" class="QH_LabelDisplay">	
							<b><%=rs("CongViec")%></b><%Call ShowEditAction(rs("Book_ID"))%><br>
							<%=ReplaceEnterChar(rs("Content"))%><br><br>
						</td>
					<%end if%>	
				</tr>
			</table>

		<%		rs.movenext
			iOrder = iOrder + 1
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
	 <table cellpadding="0"  align=left cellspacing="2" width="100%" border=0>
		<tr valign="absmiddle">			
			<!--<td width="20%" valign="absmiddle" class="QH_Label"><a href="javascript:location.href='../Home.asp';" ><img alt="Tro ve trang chu" src="images/home.gif" border="0" align="absmiddle">&nbsp;Trang chủ</a></td>-->
			<td width="30%" align=left	class="QH_Label"><a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a></td>
			<!--<td width="32%" valign="absmiddle"><font class="title"><a href="CAL_WEEK_APPROVED.ASP" ><img alt="Xem lich chinh thuc" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Lịch làm việc</a></font></td>-->
			<td width="20%" align=left class="QH_Label"><a href="javascript:inbaocao('<%=DateValueVN(WeekFrom)%>','<%=lich%>','<%=strLocationID%>','<%=strChairManID%>')" ><img alt="In lich lam viec" src="images/print.gif" border="0" align="absmiddle">&nbsp;In lịch</a></td>
			<!--<td width="22%" valign="absmiddle"><font class="title"><a href="Javascript:ViewOneDay();" ><img alt="Xem lich lam viec trong ngay" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Trong ngày</a></font></td>-->
			<!--td width="*" valign="absmiddle" class="QH_Label"><a href="LICHTRUC_APPROVED.ASP" ><img alt="Xem lich chinh thuc" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Lịch trực</a></td> -->
			<!--<td width="*" valign="absmiddle"><font class="title"><a href="javascript:alert('Under contruction.');" ><img alt="Phan tich" src="images/search.gif" border="0" align="absmiddle">&nbsp;Phân tích</a></font></td>-->
			<td width="*">&nbsp;</td>
		</tr>
	</table>
<%END sub%>

<%sub ShowTimeBar()%>
	 <table cellpadding="0" cellspacing="2" width="100%">
		<tr>
			<td width="100%" align="right" >
				<table border="0" cellpadding="0" cellspacing="0"><tr valign = middle><td>
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
<%sub ShowEditAction(p_BookID)%>
	&nbsp;&nbsp;&nbsp;&nbsp;
	<a href="javascript:Edit('<%=p_BookID%>');"><img  src="images\edit.gif" border="0" alt="sua noi dung lich lam viec"></a>
	<a href="javascript:Delete('<%=p_BookID%>');"><img  src="images\del.gif" border="0" alt="Xoa lich lam viec"></a>
<%END sub%>
<%sub ShowAction_1(p_BookID, p_curPos, p_PosType)'*, stt, topbottom%>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<a href="javascript:Edit('<%=p_BookID%>');"><img  src="images\edit.gif" border="0" alt="sua noi dung lich hop"></a>
	<a href="javascript:Delete('<%=p_BookID%>');"><img  src="images\del.gif" border="0" alt="Xoa lich hop"></a>&nbsp;&nbsp;&nbsp;&nbsp;
	<a href="javascript:Approve('<%=p_BookID%>');"><img  src="images\Duyet.gif" border="0" alt="Duyet lich"></a>
	<a href="javascript:NotApprove('<%=p_BookID%>');"><img  src="images\KhongDuyet.gif" border="0" alt="Khong duyet lich"></a>
	<a href="javascript:Postponse('<%=p_BookID%>');"><img  src="images\DoiHop.gif" border="0" alt="Doi hop"></a>
	<%if p_PosType <> 0 and p_PosType <> 3 then'Not Top%>
	<a href="javascript:setOrder('<%=p_BookID%>','<%=p_curPos%>','up');"><img  src="images\order_up.gif" border="0" alt="chuyen len"></a>
	<%end if%>
	<%if p_PosType <> 2 and p_PosType <> 3 then'Not Bottom%>
	<a href="javascript:setOrder('<%=p_BookID%>','<%=p_curPos%>','down');"><img  src="images\order_down.gif" border="0" alt="chuyen xuong"></a>
	<%end if%>
<%END sub%>
<!--<%
	sub MakeCboLich(p_Name, p_value, p_width)
		dim sel1
		dim sel2	
		
		select case p_value 
			case "1"
				sel1 = "selected"
			case "2"
				sel2 = "selected"		
		end select
		
		Response.Write "<SELECT class='QH_DatagridHeader' Name='" & p_Name & "' class='text' style=width:" & p_width & "' onchange='javascript:filter();'>" & vbCrLf
		Response.Write "<option value='1' " & sel1 & ">L&#7883;ch l&#224;m vi&#7879;c c&#7911;a BTV/QU - TT/H&#272;ND v&#224; UBND Qu&#7853;n</option>" & vbCrLf
		Response.Write "<option value='2' " & sel2 & ">Ho&#7841;t &#273;&#7897;ng c&#7911;a c&#225;c Ban, Ng&#224;nh, &#272;o&#224;n th&#7875; v&#224; 20 Ph&#432;&#7901;ng</option>" & vbCrLf		
		Response.Write "</SELECT>" & vbCrLf
	End sub
%>
-->
<%
	sub MakeCboLich(p_Name, p_value, p_width)
		dim sel1
		dim sel2	
		
		select case p_value 
			case "1"
				sel1 = "selected"
			case "2"
				sel2 = "selected"		
		end select
		
		Response.Write "<SELECT Name='" & p_Name & "' class='QH_DropDownList' style=width:" & p_width & "' onchange='javascript:filter();'>" & vbCrLf
		Response.Write "<option value='1' " & sel1 & ">L&#7883;ch l&#224;m vi&#7879;c c&#7911;a BTV/QU - TT/H&#272;ND v&#224; UBND Qu&#7853;n</option>" & vbCrLf
		Response.Write "<option value='2' " & sel2 & ">Ho&#7841;t &#273;&#7897;ng c&#7911;a c&#225;c Ban, Ng&#224;nh, &#272;o&#224;n th&#7875; v&#224;  Ph&#432;&#7901;ng</option>" & vbCrLf		
		Response.Write "</SELECT>" & vbCrLf
	End sub
%>