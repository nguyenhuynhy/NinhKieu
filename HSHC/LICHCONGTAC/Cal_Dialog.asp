<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<link rel=stylesheet href="inc/default.css" type=text/css>
<TITLE>-------- Lich Thang --------</TITLE>
<SCRIPT LANGUAGE=javascript>
<!--xu ly tren lich.

var fl_now   = new Date();
var fl_day   = fl_now.getDate();
var fl_month = fl_now.getMonth();
var fl_year  = fl_now.getYear();
var iDay;
if ((navigator.appName == "Microsoft Internet Explorer") && (fl_year < 2000))
	fl_year = "19" + fl_year;
if (navigator.appName == "Netscape")
	fl_year = 1900 + fl_year;

var fl_curRow, fl_curCol

function fl_ColorSelected(Row, Col)	{
	fl_tblCalendar.rows(Row).cells(Col).style.color = "880000"
	fl_tblCalendar.rows(Row).cells(Col).style.fontWeight = "bold"
	fl_tblCalendar.rows(Row).cells(Col).style.backgroundColor = "white"	
	fl_tblCalendar.rows(Row).cells(Col).style.fontfamily = "arial"	
	fl_day = fl_tblCalendar.rows(Row).cells(Col).innerText
	dd = parseInt(fl_day,10)
	if (dd < 10) dd = "0" + dd
	mm = parseInt(fl_month,10) + 1
	if (mm < 10) mm = "0" + mm
	fl_tdDate.innerText = dd + "/" + mm + "/" + fl_year;
}

function fl_ColorNormal(Row, Col)	{
	//oCell=fl_tblCalendar.rows(Row).cells(Col);	
	if (Col == 0) 
		fl_tblCalendar.rows(Row).cells(Col).style.color = "Red"		
	else
		fl_tblCalendar.rows(Row).cells(Col).style.color = ""	
		
	fl_tblCalendar.rows(Row).cells(Col).style.backgroundColor = ""
	fl_tblCalendar.rows(Row).cells(Col).style.fontWeight = ""
	fl_tblCalendar.rows(Row).cells(Col).style.fontfamily = "Arial"
}

function fl_lblCancel_onclick(){
	window.close();
}		

function fl_lblOK_onclick() {
	dd = parseInt(fl_day, 10);
	mm = parseInt(fl_month, 10) + 1;
	if (dd < 10) dd = "0" + dd;
	if (mm < 10) mm = "0" + mm	
	
	fnGetInfo();
	window.close();
}

function fl_tblCalendar_ondblclick() {
	fl_lblOK_onclick()
}

function fl_tblCalendar_onclick() {
	oCell = window.event.srcElement;
	// chon Cell ?
	if (oCell.tagName == "TD") {
		oRow = oCell.parentElement
		
		if (! isNaN(parseInt(oCell.innerText))) {
			fl_ColorNormal(fl_curRow, fl_curCol)
			fl_curRow = oRow.rowIndex
			fl_curCol = oCell.cellIndex
			fl_day=oCell.innerText	
			fl_ColorSelected(fl_curRow, fl_curCol)
		}
	}
}


function fl_setToday() {
	fl_now   = new Date();
	fl_day   = fl_now.getDate();
	fl_month = fl_now.getMonth();
	fl_year  = fl_now.getYear();
	if ((navigator.appName == "Microsoft Internet Explorer") && (fl_year < 2000))
		fl_year = "19" + fl_year;
	if (navigator.appName == "Netscape")
		fl_year = 1900 + fl_year;
	this.focusDay = fl_day;		
	fl_ColorNormal(fl_curRow, fl_curCol)	 
	fl_displayCalendar();
	fl_ColorSelected(fl_curRow, fl_curCol)	
}

function fl_setPreviousMonth() {
	if (fl_month == 0) {
		fl_month = 11;
		fl_year--;
	}
	else fl_month--; 
	fl_ColorNormal(fl_curRow, fl_curCol)	 
	fl_displayCalendar();
	fl_ColorSelected(fl_curRow, fl_curCol)	
}

function fl_setNextMonth() {
	if (fl_month == 11) {
		fl_month = 0;
		fl_year++;
	}
	else fl_month++;
	fl_ColorNormal(fl_curRow, fl_curCol)	 
	fl_displayCalendar();  
	fl_ColorSelected(fl_curRow, fl_curCol)	
}

function fl_displayCalendar() {       
	fl_month = parseInt(fl_month);// 0..11
	fl_year = parseInt(fl_year);// 4number
	var i = 0;
	var fl_days = fl_getDaysInMonth(fl_month+1,fl_year);
	var firstOfMonth = new Date (fl_year, fl_month, 1);
	var startingPos = firstOfMonth.getDay();
	fl_days += startingPos;
	
	var DayOfWeek = new Array("CN", "T2", "T3", "T4", "T5", "T6", "T7");
	r=0
	for(c = 0; c < 7; c++){//first row.				
		window.fl_tblCalendar.rows(r).cells(c).innerText = DayOfWeek[c]
	}	
	//cac khoang trang dau tien cua lich.	
	for (c = 0; c < startingPos; c++) {
		if ( c%7 == 0 ) r += 1 
		window.fl_tblCalendar.rows(r).cells(c%7).innerText=" "
	}
	// in cac ngay trong thang.
	for	(c = startingPos; c < fl_days; c++) {
		if ( c%7 == 0 ) r += 1 
		iDay = c - startingPos + 1
		window.fl_tblCalendar.rows(r).cells(c%7).innerText = iDay;
		if (iDay == fl_day){			
			fl_curRow = r
			fl_curCol = c%7			
		}			
	}
	if (iDay < fl_day){
			fl_curRow = r
			fl_curCol = (c-1)%7			
		}
	//cac khoang trang con lai cua lich.
	for (c = fl_days; c < 42; c++)  {
		if ( c%7 == 0 ) r += 1
		window.fl_tblCalendar.rows(r).cells(c%7).innerText = "";
	}
	
}//fl_displayCalendar()

function fl_getDaysInMonth(month,year)  {
	var days;
	if (month==1 || month==3 || month==5 || month==7 || month==8 || month==10 || month==12)  days=31;
	else if (month==4 || month==6 || month==9 || month==11) days=30;
	else if (month==2)  {
		if (fl_isLeapYear(year)) { days=29; }
		else { days=28; }
	}
	return (days);
}

function fl_isLeapYear (Year) {
	if (((Year % 4)==0) && ((Year % 100)!=0) || ((Year % 400)==0)) {
		return (true);
	} 
	else { return (false); }
}

function fnGetDate(){
	var sData = dialogArguments;
	dtCurrent = sData.sDate;
	if (dtCurrent != ''){ 
		arr = dtCurrent.split("/")	
		fl_day = arr[0]
		fl_month = arr[1] - 1;
		fl_year = arr[2] 
	}
	else {
		fl_setToday();
	}
}

function fnGetInfo()
{  
  
  
  var sData = dialogArguments;
  sData.sDate = fl_tdDate.innerText; 
  sData.fnUpdate();
  //sData.location = "style.htm";
}

//-->
</SCRIPT>
</HEAD>
<BODY onload="fnGetDate(); fl_displayCalendar(); fl_ColorSelected(fl_curRow, fl_curCol);" bgcolor = "#D3DEED">
<center>

<TABLE border=2 cellPadding=1 cellSpacing=1 id=fl_border align = center width = 100% height = 100%>
<TR>
	<TD align=middle COLSPAN=3 class="text">
	<INPUT TYPE=button NAME="fl_btnPreviousMonth" VALUE="<<"    onClick="fl_setPreviousMonth()">
	<INPUT TYPE=button NAME="fl_btnPreviousMonth" VALUE="Hom nay"    onClick="fl_setToday()">
	<INPUT TYPE=button NAME="fl_btnPreviousMonth" VALUE=">>"    onClick="fl_setNextMonth()">
	</TD>
</TR>
<TR>
	<TD align=middle ><LABEL class="text" id=fl_lblCancel onclick="fl_lblCancel_onclick()" 
      style="BACKGROUND-COLOR: cornsilk">Huy</LABEL></TD>
	<TD align=middle class="text" id=fl_tdDate style = "color:003366; FONT-WEIGHT: bold"></TD>
	<TD align=middle ><LABEL class="text" id=fl_lblOK onclick="return fl_lblOK_onclick()" 
      style="BACKGROUND-COLOR: antiquewhite">Chon</LABEL></TD>
</TR>
<TR>
	<TD id=fl_tdCal COLSPAN=3>
	
<TABLE id=fl_tblCalendar cellSpacing=1 cellPadding=1 width="100%" border=1 onclick="fl_tblCalendar_onclick()"  ondblclick = "fl_tblCalendar_ondblclick()">
  <tbody align=center>
  <TR  style = "color:003366; " class="text">
    <TD class="text"></TD>
    <TD class="text"></TD>
    <TD class="text"></TD>
    <TD class="text"></TD>
    <TD class="text"></TD>
    <TD class="text"></TD>
    <TD class="text"></TD></TR>
  <TR>
    <TD style = "color:red;"></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD></TR>
  <TR>
    <TD style = "color:red;"></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD></TR>
  <TR>
    <TD style = "color:red;"></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD></TR>
  <TR>
    <TD style = "color:red; "></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD></TR>
  <TR>
    <TD style = "color:red; "></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD></TR>
  <TR>
    <TD style = "color:red;"></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD></TR>
   </Tbody> 
   </TABLE>
</TD>
</TR>
</TABLE>
</center>
</BODY>
</HTML>
