// ********************
// Begin Popup Calendar
// ********************
var popCalDstFld;
var temp;
var popCalWin;
var popCalDays;
var popCalMonths;
var thisDay;

function popupCal()
{
	//debugger;			//remove slashes to activate debugging in Visual Studio
	var tmpDate         = new Date();
	var tmpString       = "";
	var tmpNum          = 0;
	var popCalDateVal;
	var dstWindowName   = "";

	//Initialize the window to an empty object.
	popCalWin = new Object();
	
	//Check for the right number of arguments
	if (arguments.length < 2)
	{
		alert("popupCal(): Wrong number of arguments.");
		return void(0);
	}
	//Get the command line arguments -- Localization is optional
	dstWindowName = popupCal.arguments[0];
	popCalDstFld = popupCal.arguments[1];
	temp = popupCal.arguments[1];
	popCalDstFmt = popupCal.arguments[2];  //Localized Short Date Format String
	popCalMonths = popupCal.arguments[3];  //Localized Month Names String
	popCalDays = popupCal.arguments[4];  //Localized Day Names String
	
	//check destination field name
	if (popCalDstFld != "")
		popCalDstFld = document.getElementById(popCalDstFld);

	//default localized short date format if not provided
	if (popCalDstFmt == "") {
		alert("False 1");
		popCalDstFmt = "m/d/yyyy";
	}

	//default localized months string if not provided
	if (popCalMonths == "")
		popCalMonths = "Tháng 1,Tháng 2,Tháng 3,Tháng 4,Tháng 5,Tháng 6,Tháng 7,Tháng 8,Tháng 9,Tháng 10,Tháng 11,Tháng 12";
		//popCalMonths = "January,February,March,April,May,June,July,August,September,October,November,December";
 
	//default localized months string if not provided
	if (popCalDays == "")
		popCalDays = "CN,Thứ 2,Thứ 3,Thứ 4,Thứ 5,Thứ 6,Thứ 7";
		//popCalDays = "Sun,Mon,Tue,Wed,Thu,Fri,Sat";
 
	tmpString = new String(popCalDstFld.value);  
	//If tmpString is empty (meaning that the field is empty) 
	//use todays date as the starting point
	if(tmpString == "")
		popCalDateVal = new Date()
	else
	{
		//Make sure the century is included, if it isn't, add this 
		//century to the value that was in the field
		tmpNum = tmpString.lastIndexOf( "/" );
		if ( (tmpString.length - tmpNum) == 3 )
		{
			tmpString = tmpString.substring(0,tmpNum + 1)+"20"+tmpString.substr(tmpNum+1);
			popCalDateVal = new Date(tmpString);
		}
		else
		{
			//localized date support:
			//If we got to this point, it means the field that was passed 
			//in has no slashes in it. Use an extra function to build the date 
			//according to supplied date formatstring.
			popCalDateVal = getDateFromFormat(tmpString,popCalDstFmt);
		}
	}
	
	//Make sure the date is a valid date.  Set it to today if it is invalid
	//"NaN" is the return value for an invalid date
	if( popCalDateVal.toString() == "NaN" )
	{
		popCalDateVal = new Date();
		popCalDstFld.value = "";
	}
			
	//Set the base date to midnight of the first day of the specified month, 
	//this makes things easier?
 	var dateString = String(popCalDateVal.getMonth()+1) + "/" + String(popCalDateVal.getDate()) + "/" + String(popCalDateVal.getFullYear());

	//Call the routine to draw the initial calendar
	reloadCalPopup(dateString, dstWindowName);
	
	return void(0);
}
 
function closeCalPopup()
{
	//Can't tell the child window to close itself, the parent window has to 
	//tell it to close.
	popCalWin.close();
	return void(0);
}
 
function reloadCalPopup() //[0]dateString, [1]dstWindowName
{
	//Set the window's features here

	var windowFeatures = "toolbar=no, titlebar=yes, location=no, status=no, menubar=no, scrollbars=no, address=yes, directories=0, resizable=no, height=165, width=252, top=" + ((screen.height - 270)/2).toString()+",left="+((screen.width - 270)/2).toString();
	var tmpDate = new Date( reloadCalPopup.arguments[0] );
	
	if (tmpDate.toString() == "Invalid Date")
	    tmpDate = new Date();
	    
	thisDay = tmpDate.getDate();
	
	tmpDate.setDate(1);
	
	//Get the calendar data
	var popCalData = calPopupSetData(tmpDate,reloadCalPopup.arguments[1]);
 
	//Check to see if the window has been initialized, create it if it hasn't been
	if( popCalWin.toString() == "[object Object]" )
	{
		popCalWin = window.open("",reloadCalPopup.arguments[1],windowFeatures);
		popCalWin.opener = self;
		// Window im Vordergrund
		popCalWin.focus();
	}
	else 
	{
		popCalWin.document.close();
		popCalWin.document.clear();
  }
	
	//this is the line with the big problem
	popCalWin.document.write(popCalData);
	return void(1);
}
 
function calPopupSetData(firstDay,dstWindowName)
{
	var popCalData = "";
    var lastDate = 0;
	var fnt = new Array( "<FONT style=\"font-size:11px;\">", "<B><FONT SIZE=\"1\">", "<FONT SIZE=\"1\" COLOR=\"#0000FF\"><B>", "<FONT style=\"font-size:11px;\" COLOR=\"#FF0000\">" );
	var dtToday = new Date();
	var thisMonth = firstDay.getMonth();
	var thisYear = firstDay.getFullYear();
	var nPrevMonth = (thisMonth == 0 ) ? 11 : (thisMonth - 1);
	var nNextMonth = (thisMonth == 11 ) ? 0 : (thisMonth + 1);
	var nPrevMonthYear = (nPrevMonth == 11) ? (thisYear - 1): thisYear;
	var nNextMonthYear = (nNextMonth == 0) ? (thisYear + 1): thisYear;
	var sToday = String((dtToday.getMonth()+1) + "/01/" + dtToday.getFullYear());
	var sPrevMonth = String((nPrevMonth+1) + "/01/" + nPrevMonthYear);
	var sNextMonth = String((nNextMonth+1) + "/01/" + nNextMonthYear);
	var sPrevYear1 = String((thisMonth+1) + "/01/" + (thisYear - 1));
	var sNextYear1 = String((thisMonth+1) + "/01/" + (thisYear + 1));
 	var tmpDate = new Date( sNextMonth );
	//var TenThang = new Array("Tháng 1","February","March","April","May","June","July","August","September","October","November","December");;
	
	tmpDate = new Date( tmpDate.valueOf() - 1001 );
	lastDate = tmpDate.getDate();

	//if (this.popCalMonths.split) // javascript 1.1 defensive code
	//{
	//	var monthNames = this.popCalMonths.split(",");
	//	var dayNames = this.popCalDays.split(",");
	//}
	//else  // Need to build a js 1.0 split algorithm, default English for now
	//{
		//var monthNames = new Array("January","February","March","April","May","June","July","August","September","October","November","December");		
		//var dayNames = new Array("Sun","Mon","Tue","Wed","Thu","Fri","Sat")
		var monthNames = new Array("Tháng 1","Tháng 2","Tháng 3","Tháng 4","Tháng 5","Tháng 6","Tháng 7","Tháng 8","Tháng 9","Tháng 10","Tháng 11","Tháng 12");		
		var dayNames = new Array("CN","Thứ 2","Thứ 3","Thứ 4","Thứ 5","Thứ 6","Thứ 7")
	//}

	//BGCOLOR:#F5F5F5
 	//var styles = "<style><!-- body{font-family:Arial,Helvetica,sans-serif, tahoma;font-size:8pt}; td {  font-family: Arial, Helvetica, sans-serif, tahoma; font-size: 8pt; color: #666666;}; A { text-decoration: none; };TD.day { } --></style>"
 	
 	/*-****************************STYLE******************************-*/
 	
 	var styles = "<style><!-- table {font-size: 11px; color: #000; cursor: default; background: #c8d0d4; font-family: tahoma, verdana,sans-serif; }; A { text-decoration: none; }; --></style>"
 	
 	var styleTitle = "style=\"font-weight: bold; padding: 1px; border: 1px solid #000; background: #484628; color: #FFF; text-align: center;\""; //5EAAF7
 	
 	var styleButton = "style=\"text-align: center; padding: 1px; background: #EBEADB; \"";   //EBEADB
 	
 	var styleDayName = "style=\"padding: 2px; text-align: center; background: #FFFFFF; \"";
 	
 	var styleSelectedDate = "style=\"font-weight: bold; padding: 2px 2px 0px 2px;  border: 1px solid; border-color: #000 #fff #fff #000; background: #d8e0e4; \"";
 	
 	/*-**************************END STYLE****************************-*/
 	
 	/*-**************************JAVASCRIPT****************************-*/
 	
 	var script = "<script language=\"Javascript\">";
 		script += "function mouseOverButton(obj) {";
 		script += "obj.style.backgroundColor='#FAF9F4';";
 		script += "}";
 		script += "function mousePressButton(obj) {";
 		script += "obj.style.padding='2px 0px 0px 2px';";
 		script += "obj.style.backgroundColor='#EBEADB';";
 		script += "}";
 		script += "function mouseOutButton(obj) {";
 		script += "obj.style.backgroundColor='#EBEADB';";
 		script += "}";
 		script += "function mouseOverDay(row, obj) {";
 		script += "eval('document.all.tr' + row).style.backgroundColor='#DDEEFF';";
		//script += "obj.style.backgroundColor='#DDEEFF';";
		script += "obj.style.fontWeight='bold';";
 		script += "}";
 		script += "function mouseOutDay(row, obj) {";
 		script += "eval('document.all.tr' + row).style.backgroundColor='#FFFFFF';";
		//script += "obj.style.backgroundColor='#FFFFFF';";
		script += "obj.style.fontWeight='normal';";
 		script += "}";
 		script += "</script>";
 		
 	/*-************************END JAVASCRIPT**************************-*/
 	
	//var cellAttribs = "align=\"center\" class=\"day\" BGCOLOR=\"#FFFFFF\"onMouseOver=\"temp=this.style.backgroundColor;this.style.backgroundColor='#DDEEFF';\" onMouseOut=\"this.style.backgroundColor=temp;\""
	
	var cellAttribs2 = "align=\"center\" BGCOLOR=\"#FFFFFF\" onMouseOver=\"temp=this.style.backgroundColor;this.style.backgroundColor='#DDEEFF';\" onMouseOut=\"this.style.backgroundColor=temp;\""
	
	var htmlHead = "<HTML><HEAD><TITLE>.:: Lịch ::.</TITLE>" + styles + script + "</HEAD><BODY BGCOLOR=\"#FFFFFF\" TEXT=\"#000000\" LINK=\"#000000\" ALINK=\"#000000\" VLINK=\"#000000\" BOTTOMMARGIN=\"0\" LEFTMARGIN=\"0\" TOPMARGIN=\"0\" RIGHTMARGIN=\"0\" MARGINWIDTH=\"0\" MARGINHEIGHT=\"0\">";
	var htmlTail = "</BODY></HTML>";
	
	//var closeAnchor = "<CENTER><input type=button value=\"Close\" onClick=\"javascript:window.opener.closeCalPopup()\"></CENTER>";            
	var todayAnchor = "<A>" + "Hôm nay" + "</A>";
	var prevMonthAnchor = "<A style='font-size:8px;'>" + "<" + "</A>";
	var nextMonthAnchor = "<A style='font-size:8px;'>" + ">" + "</A>";
	var prevYear1Anchor = "<A style='font-size:8px;'>" + "<<<" + "</A>";
	var nextYear1Anchor = "<A style='font-size:8px;'>" + ">>>" + "</A>";
		
	popCalData += (htmlHead + fnt[1]);
	popCalData += ("<DIV align=\"center\" >");
	/************************Header Now Month, Year************************/
	popCalData += ("<TABLE BORDER=\"0\" cellspacing=\"0\" callpadding=\"0\" width=\"250\">");
	popCalData += ("<TR " + styleTitle + ">");
	
	popCalData += ("<TD width=\"100%\" align=\"center\" height=\"18\">");
	popCalData += ("&nbsp;&nbsp;" + monthNames[thisMonth] + ", " + thisYear + "&nbsp;&nbsp;</TD>");
	
	popCalData += ("</TR></TABLE>");
	/*****************************Header Today*****************************/
	popCalData += ("<TABLE BORDER=\"0\" cellspacing=\"0\" callpadding=\"0\" width=\"250\"><TR height=\"20\">");
	popCalData += ("<TD " + styleButton + " width=\"25\" align=\"center\" ");
	popCalData += (" onmouseover=\"mouseOverButton(this);\" onmouseout=\"mouseOutButton(this);\" onmousedown=\"mousePressButton(this)\" onClick=\"javascript:window.opener.reloadCalPopup('"+sPrevYear1+"','"+dstWindowName+"');\">");
	popCalData += (prevYear1Anchor+"</TD>");
	
	popCalData += ("<TD " + styleButton + " width=\"25\" align=\"center\" ");
	popCalData += (" onmouseover=\"mouseOverButton(this);\" onmouseout=\"mouseOutButton(this);\" onmousedown=\"mousePressButton(this)\" onClick=\"javascript:window.opener.reloadCalPopup('"+sPrevMonth+"','"+dstWindowName+"');\">");
	popCalData += (prevMonthAnchor + "</TD>");
	
	popCalData += ("<TD " + styleButton + " width=\"150\"  align=\"center\" ");
	popCalData += (" onmouseover=\"mouseOverButton(this);\" onmouseout=\"mouseOutButton(this);\" onmousedown=\"mousePressButton(this)\" onclick=\"javascript:window.opener.reloadCalPopup('"+sToday+"','"+dstWindowName+"');\">");
	popCalData += (todayAnchor+"</TD>");
	
	popCalData += ("<TD " + styleButton + " width=\"25\" align=\"center\" ");
	popCalData += (" onmouseover=\"mouseOverButton(this);\" onmouseout=\"mouseOutButton(this);\" onmousedown=\"mousePressButton(this)\" onclick=\"javascript:window.opener.reloadCalPopup('"+sNextMonth+"','"+dstWindowName+"');\">");
	popCalData += (nextMonthAnchor+"</TD>");
	
	popCalData += ("<TD " + styleButton + " width=\"25\" align=\"center\" ");
	popCalData += (" onmouseover=\"mouseOverButton(this);\" onmouseout=\"mouseOutButton(this);\" onmousedown=\"mousePressButton(this)\" onClick=\"javascript:window.opener.reloadCalPopup('"+sNextYear1+"','"+dstWindowName+"');\">");
	popCalData += (nextYear1Anchor+"</TD>");
	
	popCalData += ("</TR></TABLE>");
	/*****************************end header today*************************/
	/*******************************Days Name***************************/
	popCalData += ("<TABLE " + styleDayName + " cellspacing=\"0\" cellpadding=\"0\"  width=\"250\" >" );
	popCalData += ("");
	popCalData += ("<TR height='20' style='border-bottom: 1px solid #000;'>");
	popCalData += ("<TD width=\"35\" align=\"center\">"+fnt[1]+"<FONT COLOR=\"#FF0000\">"+dayNames[0]+"</FONT></TD><TD width=\"35\" align=\"center\">");
	popCalData += (fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[1]+"</FONT></TD><TD width=\"35\"align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[2]+"</FONT></TD><TD width=\"35\"align=\"center\">");
	popCalData += (fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[3]+"</FONT></TD><TD width=\"35\"align=\"center\">"+fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[4]+"</FONT></TD><TD width=\"35\"align=\"center\">");
	popCalData += (fnt[1]+"<FONT COLOR=\"#000000\">"+dayNames[5]+"</FONT></TD><TD width=\"35\"align=\"center\">"+fnt[1]+"<FONT COLOR=\"#FF0000\">"+dayNames[6]+"</FONT></TD></TR>");
	/*****************************End Days Name*************************/
 
	var calDay = 0;
	var monthDate = 1;
	var weekDay = firstDay.getDay();
	var countRow = 0;
	var countCol = 0;
	
	//TuanNH update 17/08/2006
	//Thay doi dinh dang ngay thang nam thanh dd/MM/yyyy doi voi anchorVal
	var tmpMonth, tmpDate;
	
	
	if (thisMonth < 10) {tmpMonth = "0" + (thisMonth + 1);}
	else {tmpMonth = thisMonth + 1;}
	
	do
	{
		countRow += 1;
		popCalData += ("<TR id='tr" + countRow +"'>");
		for (calDay = 0; calDay < 7; calDay++ )
		{
			if((weekDay != calDay) || (monthDate > lastDate))
			{
				popCalData += ("<TD width=\"35\">"+fnt[1]+"&nbsp;</FONT></TD>");
				continue;
			}
			else
			{
				anchorVal = "<A HREF=\"javascript:window.opener.calPopupSetDate(window.opener.popCalDstFld,'" + monthDate + "/" + (tmpMonth) + "/" + thisYear + "');window.opener.closeCalPopup()\">";
				jsVal = "javascript:window.opener.calPopupSetDate(window.opener.popCalDstFld,'" + constructDate(monthDate,(thisMonth+1),thisYear) + "');window.opener.closeCalPopup()";

				popCalData += ("<TD width=\"35\" align='center' style='BGCOLOR:#FFFFFF' onClick=\""+jsVal+"\" onMouseOver='mouseOverDay(" + countRow + ", this);' onMouseOut='mouseOutDay(" + countRow + ", this);' >");
				
				if ((firstDay.getMonth() == dtToday.getMonth()) && (monthDate == dtToday.getDate()) && (thisYear == dtToday.getFullYear()) ) {
					if (calDay==0 || calDay==6) {
						popCalData += (anchorVal+fnt[3]+monthDate+"</A></FONT></TD>");
					}
					else {
						popCalData += (anchorVal+fnt[2]+monthDate+"</A></FONT></TD>");
					}
				}
				else {
					if (calDay==0 || calDay==6) {
						popCalData += (anchorVal+fnt[3]+monthDate+"</A></FONT></TD>");
					}
					else {
						popCalData += (anchorVal+fnt[0]+monthDate+"</A></FONT></TD>");
					}
				}
				
				weekDay++;
				monthDate++;
			}
		}
		weekDay = 0;
		countCol = 0;
	} while( monthDate <= lastDate );
	
	popCalData += ("</TABLE></DIV><BR>");
 
	//popCalData += (closeAnchor+"</FONT>"+htmlTail);
	return( popCalData );
}


function calPopupSetDate()
{
	var sDay, sMonth, sYear, sDate;
	sDate = calPopupSetDate.arguments[1];
	//get day return
	sDay = sDate.substring(0,sDate.indexOf("/"));
	sDate = sDate.substring(sDate.indexOf("/")+1, sDate.length);
	//get month return
	sMonth = sDate.substring(0,sDate.indexOf("/"));
	//get year return
	sYear = sDate.substring(sDate.indexOf("/")+1, sDate.length);
	
	//process day
	if (sDay.length<2) {sDay = "0" + sDay;}
	if (sDay.length>2) {sDay = sDay.substring(1,sDay.length);}
	//process month
	if (sMonth.length<2) {sMonth = "0" + sMonth;}
	if (sMonth.length>2) {sMonth = sMonth.substring(1,sMonth.length);}
	
	//return the date
	sDate = sDay + "/" + sMonth + "/" + sYear;
		
	//calPopupSetDate.arguments[0].value = calPopupSetDate.arguments[1];
	calPopupSetDate.arguments[0].value = sDate;
}

// utility function
function padZero(num)
{
  return ((num <= 9) ? ("0" + num) : num);
}

// Format short date
function constructDate(d,m,y)
{
  var fmtDate = this.popCalDstFmt
  fmtDate = fmtDate.replace ('dd', padZero(d))
  fmtDate = fmtDate.replace ('d', d)
  fmtDate = fmtDate.replace ('MM', padZero(m))
  fmtDate = fmtDate.replace ('M', m)
  fmtDate = fmtDate.replace ('yyyy', y)
  fmtDate = fmtDate.replace ('yy', padZero(y%100))
  return fmtDate;
}

// ------------------------------------------------------------------
// Utility functions for parsing in getDateFromFormat()
// ------------------------------------------------------------------
function _isInteger(val) {
	var digits="1234567890";
	for (var i=0; i < val.length; i++) {
		if (digits.indexOf(val.charAt(i))==-1) { return false; }
		}
	return true;
	}
function _getInt(str,i,minlength,maxlength) {
	for (var x=maxlength; x>=minlength; x--) {
		var token=str.substring(i,i+x);
		if (token.length < minlength) { return null; }
		if (_isInteger(token)) { return token; }
		}
	return null;
	}
	
// ------------------------------------------------------------------
// getDateFromFormat( date_string , format_string )
//
// This function takes a date string and a format string. It matches
// If the date string matches the format string, it returns the 
// getTime() of the date. If it does not match, it returns 0.
// ------------------------------------------------------------------
function getDateFromFormat(val,format) {
	val=val+"";
	format=format+"";
	var i_val=0;
	var i_format=0;
	var c="";
	var token="";
	var x,y;
	var now=new Date();
	var year=now.getYear();
	var month=now.getMonth()+1;
	var date=1;
		
	while (i_format < format.length) {
		// Get next token from format string
		c=format.charAt(i_format);
		token="";
		while ((format.charAt(i_format)==c) && (i_format < format.length)) {
			token += format.charAt(i_format++);
			}
		// Extract contents of value based on format token
		if (token=="yyyy" || token=="yy" || token=="y") {
			if (token=="yyyy") { x=4;y=4; }
			if (token=="yy")   { x=2;y=2; }
			if (token=="y")    { x=2;y=4; }
			year=_getInt(val,i_val,x,y);
			if (year==null) { return 0; }
			i_val += year.length;
			if (year.length==2) {
				if (year > 70) { year=1900+(year-0); }
				else { year=2000+(year-0); }
				}
			}
		else if (token=="MM"||token=="M") {
			month=_getInt(val,i_val,token.length,2);
			if(month==null||(month<1)||(month>12)){return 0;}
			i_val+=month.length;}
		else if (token=="dd"||token=="d") {
			date=_getInt(val,i_val,token.length,2);
			if(date==null||(date<1)||(date>31)){return 0;}
			i_val+=date.length;}
		else {
			if (val.substring(i_val,i_val+token.length)!=token) {return 0;}
			else {i_val+=token.length;}
			}
		}
	// If there are any trailing characters left in the value, it doesn't match
	if (i_val != val.length) { return 0; }
	// Is date valid for month?
	if (month==2) {
		// Check for leap year
		if ( ( (year%4==0)&&(year%100 != 0) ) || (year%400==0) ) { // leap year
			if (date > 29){ return 0; }
			}
		else { if (date > 28) { return 0; } }
		}
	if ((month==4)||(month==6)||(month==9)||(month==11)) {
		if (date > 30) { return 0; }
		}
	var newdate=new Date(year,month-1,date);
	return newdate;
	}

// ******************
// End Popup Calendar
// ******************


