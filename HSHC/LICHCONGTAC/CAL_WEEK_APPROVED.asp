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
	FileWindow = window.open('Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','status=yes,location=no,toolbar=no,resizable,scrollbars=yes, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
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
	function AddNew(pNgay, pType){
		checkform.hAction.value = 'addnew';
		checkform.hAddnewDate.value = pNgay;
		checkform.hAddnewType.value = pType;
		checkform.action = 'CAL_WEEK_ADDNEW.ASP';
		checkform.submit();
	}
	function Edit(pBookID){
		checkform.hAction.value = 'update';
		checkform.hBookID.value = pBookID;		
		checkform.action = 'CAL_WEEK_ADDNEW.ASP';
		checkform.submit();
	}
	function Delete(pBookID){
		checkform.hAction.value = 'delete';
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
</script>
</head>
<%
		Dim Conn
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING
		
		strLich			= request("cboLich")		
		strSelectedDate = request("SelectDay")
		strLocationID	= request("cboLocation")
		strChairManID	= request("cboChairMan")
		
		if strLich = "" then strLich = "1"
		
		if Request("SelectDay")="" then
			SelectDay = DateValue(Now() - Weekday(Now() ) + 2 )
		else			
			SelectDay = DateValue(Request("SelectDay"))
		end if

		if Weekday(SelectDay) = 1 then
			WeekFrom = DateValue(SelectDay + 1)
		else
			WeekFrom = DateValue(SelectDay - Weekday(SelectDay) + 2)
		end if
		
		Select Case Request("ActType")
			Case "ChangeDay"
				if Weekday(SelectDay) = 1 then
					WeekFrom = SelectDay +1'DateValue(SelectDay - 6)
				else
					WeekFrom = SelectDay - Weekday(SelectDay) + 2'DateValue(SelectDay - Weekday(SelectDay) + 2)
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
		
		strQuery = "BeginDay=" & WeekFrom 
		strQuery = strQuery & "&SelectDay=" & SelectDay
		strQuery = strQuery & "&cboChairMan=" & strChairManID
		strQuery = strQuery & "&cboLocation=" & strLocationID
		strQuery = strQuery & "&cboLich=" & strLich
		
	%>
<!--#include file = "IncBeginSub.asp"--> 
<body text="#000000"  topmargin=0 leftmargin=0 background=Images/bg.gif>
<center>
<form name="checkform" action="CAL_WEEK_APPROVED.ASP" method="POST" ID="Form1">
	<input type="hidden" name="hAddnewDate" value="" ID="Hidden1">
	<input type="hidden" name="hAddnewType" value="" ID="Hidden2">
	<input type="hidden" name="hAction" value="" ID="Hidden3">
	<input type="hidden" name="hBookID" value="" ID="Hidden4">
	
	<input type="hidden" name="ActType" value="" ID="Hidden5">
    <input type="hidden" name="WhichOne" value="" ID="Hidden6">
    
    <input type="hidden" name="hQuery" value="<%=strQuery%>" ID="Hidden7">
    
    <input type="hidden" name="BeginDay" value="<%=WeekFrom%>" ID="Hidden8">
    <input type="hidden" name="SelectDay" value="<%=SelectDay%>" ID="Hidden9">                                              
    <input type="hidden" name="MonthOnCalendar" value="<%=CalCurrent%>" ID="Hidden10">                                              
    <input type="hidden" name="ContentID" value="<%=ContentID%>" ID="Hidden11">                                              
    <input type="hidden" name="hBack" value="CAL_WEEK_APPROVED.asp" ID="Hidden12"> 
    
    <input type="hidden" name=txtNgay size = 7 value="<%=Datevaluevn(SelectDay)%>" ID="Hidden13">

<table cellspacing="1"width="100%" ID="Table1">
	<tr>
		<td width="100%">
			<table cellspacing="1"width="100%" ID="Table2">
				<tr> 
					<td width="100%">
						<table cellpadding="0" cellspacing="2" width = 100% ID="Table3">						
							<tr>
								<td width="*" rowspan="2" align="left"><img src="images\text_LichLamViec.gif"></td> 
								<td width="12%" class="QH_ColLabel" align="right" nowrap>Địa điểm</td>
								<td align="right" width="215"><%call MakeCbo("cboLocation","COMM_GetLocation",strLocationID,"ID","LocationName","200","1"," onchange='javascript:filter();'")%>&nbsp;</td>						
							</tr>			
							<tr> 
								<td width="10%" class="QH_ColLabel"  align = right nowrap>Người chủ trì</td>
								<td align="right"><%call MakeCbo("cboChairMan","COMM_GetChairMan",strChairManID,"UserID","FullName","200","1"," onchange='javascript:filter();'")%>&nbsp;</td>
							</tr> 	
						</table>
					</td>
				</tr>  
				<tr>
						<td>
							<table cellpadding="0" cellspacing="0" width = 100% align = center ID="Table4">
								<tr>
									<td width="*"><%call ShowToolBar()%></td>
									<td width="50%" align="right"><%call ShowTimeBar()%></td>
								</tr>				
							</table>
						</td>
				</tr>
			</table>
		</td>
	</tr>
  <tr>
	<td width="100%"><%call Show_Lich(WeekFrom,SelectDay, strLich)%></td>
  </tr> 
  <tr>
    <td>
		<table cellpadding="0" cellspacing="0" width = 100% align = center ID="Table5">
			<tr>
				<td width="*"><%call ShowToolBar()%></td>
				<td width="50%" align="right"><%call ShowTimeBar()%></td>
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
	dim strSQL
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
	
	strSQL = "SELECT BookType_ID, BookType, VietTat FROM BookTypes WHERE SHOW='1' AND BookType_ID IN " & lich & " ORDER BY STT"
	'Response.Write strSQL
	'Response.End
	rs.open strSQL, conn,3,3		
%>
	<table cellSpacing="0" class="QH_TableMain" cellPadding="0" width="100%"   background=Images/bg.gif ID="Table6">
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
		<%j = 0
		while not rs.eof
		%>
			 
			<tr>
				<td class="QH_LabelBold" align="center" valign="top" bgcolor="<%=ColorNgay%>">					
						<%if j=0 then%><%=arrThu(i)%><br>
						<%=left(DateValueVN(curDate),5)%><br><%end if%>
						<%=rs("VietTat")%>
				</td>
				<td class="QH_Label" align="center" valign="top" ><%call ShowOneDay(DateValueVN(curDate),"S",rs("BookType_ID"),strLocationID, strChairManID)%></td>
				<td width="1" bgcolor="<%=ColorNgay%>"></td>
				<td class="QH_Label" valign="top" ><%call ShowOneDay(DateValueVN(curDate),"C",rs("BookType_ID"),strLocationID, strChairManID)%></td>
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
	strSQL = strSQL & "@p_Approved = 'Y',"
	strSQL = strSQL & "@p_LocationID = '" & p_LocationID & "',"
	strSQL = strSQL & "@p_ChairManID = '" & p_ChairManID & "',"
	strSQL = strSQL & "@p_Time = '" & p_AMPM & "'"
	
	
	'Response.Write strSQL
	'Response.End
	rs.open strSQL, conn, 3,3
	
	IF NOT rs.eof Then
		while not rs.eof
		%>
			<table cellpadding="0" cellspacing="2" width="95%" ID="Table7">
				<tr>
					<%if rs("ChucTho")="" then %>
						<td width="13%" align="left" valign="top" class="QH_LabelDisplay">
							<%Response.Write(rs("Gio") & ":" & rs("Phut"))%><br>
							<%Response.Write(rs("TinhTrang"))%>
						</td>
						<td width="*" class="QH_LabelDisplay"><p align="justify">
							<b>Nội dung:</b>&nbsp;<%=ReplaceEnterChar(rs("Content"))%><br>
							<%if rs("ChairMan") <> "" then%>
								<b>Người chủ trì:</b>&nbsp;<font color='red'><%=rs("ChairMan")%></font><br>
							<%end if%>
							<%if rs("Location") <> "" then%><br>
								<b>Địa điểm:</b>&nbsp;<%=rs("Location")%><br>
							<%end if%>
							<%if rs("JoinMember") <> "" then%>
								<b>Thành phần:</b>&nbsp;<%=rs("JoinMember")%><br>
							<%end if%>							
							<%if rs("Note") <> "" then%>
								<b>Chuẩn bị:</b>&nbsp;<%=rs("Note")%><br>
							<%end if%>	
							<b>Loại lịch:</b>&nbsp;<font color='red'><%=rs("NgoaiLich")%></font><br>
						<br></p>						
						</td>	
					<%else%>											
						<td width="100%" class="QH_LabelDisplay">	
							<b><%=rs("CongViec")%></b><br>
							<%=ReplaceEnterChar(rs("Content"))%><br><br>
						</td>
					<%end if%>	
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
	 <table border="0" cellpadding="0" cellspacing="2" width="100%" ID="Table8">
		<tr valign="absmiddle">			
			<!--<td width="25%" class="QH_Label" valign="absmiddle"><a href="javascript:location.href='../DesktopDefault.aspx';" ><img alt="Tro ve trang chu" src="images/home.gif" border="0" align="absmiddle">&nbsp;Trang chủ</a></td>-->
			<td width="35%" class="QH_Label" valign="absmiddle"><a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a></td>
			<td width="25%" class="QH_Label" valign="absmiddle"><a href="javascript:inbaocao('<%=DateValueVN(WeekFrom)%>','<%=strLich%>','<%=strLocationID%>','<%=strChairManID%>')" ><img alt="In lich lam viec" src="images/print.gif" border="0" align="absmiddle">&nbsp;In lịch</a></td>
			<!--td width="25%" class="QH_Label" valign="absmiddle"><a href="LICHTRUC_APPROVED.ASP" ><img alt="Xem lich truc" src="images/approved.gif" border="0" align="absmiddle">&nbsp;Lịch trực</a></td>			-->
			<td width="*">&nbsp;</td>
		</tr>
	</table>
<%END sub%>

<%sub ShowTimeBar()%>
	 <table cellpadding="0" cellspacing="2" width="100%" ID="Table9">
		<tr>
			<td width="100%" align="right" >
				<table cellpadding="0" cellspacing="0" ID="Table10"><tr valign = middle><td>
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
		Response.Write "<option value='2' " & sel2 & ">Ho&#7841;t &#273;&#7897;ng c&#7911;a c&#225;c Ban, Ng&#224;nh, &#272;o&#224;n th&#7875; v&#224; Ph&#432;&#7901;ng</option>" & vbCrLf		
		Response.Write "</SELECT>" & vbCrLf
	End sub
%>
