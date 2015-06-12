function setDDLToTXT(ddlName,txtName)
{
	var ddl = document.all(ddlName);
	var txt = document.all(txtName);	
	if (ddl.value == '')	
	{		
		txt.disabled = 0 ;		
		txt.value = "";
		txt.focus();
	}
	else
	{				
		txt.disabled = 1;		
		txt.value = ddl.options[ddl.selectedIndex].text;
	}
}

function isInteger(numString) {
	if (isNaN(numString)) {
		return false;
	} else {
		return (numString.indexOf('.') > 0) ? false : true;
	}
}

// This function currently expects valid times in the form of xx:xx:xx,
// using a military (24-hour) clock
function validateTime(time) {

	var iSepPos = time.indexOf(':');
	var sTimeStr = time;
	var sStr1 = new String;
	var sStr2 = new String;
	var sStr3 = new String;

	sStr1 = 'x';
	sStr2 = 'x';
	sStr3 = 'x';

	if (trim(time) == '') {
		return true;
	}

	if (iSepPos > 0) {
	    sStr1 = sTimeStr.substring(0,iSepPos);
	    sTimeStr = sTimeStr.substring(iSepPos + 1, sTimeStr.length);
	}

	iSepPos = sTimeStr.indexOf(':');
	if (iSepPos > 0) {
	    sStr2 = sTimeStr.substring(0,iSepPos);
	    sStr3 = sTimeStr.substring(iSepPos + 1, sTimeStr.length);
	}
	else {
	    sStr2 = sTimeStr;
	    sStr3 = '00';
	}

	var sHour = sStr1;
	var sMinute = sStr2;
	var sSecond = sStr3;

	if (isNaN(sHour)) {
		displayMessage('COMM',1030,time,'00:00:00');
	    return false;
	}
	if (isNaN(sMinute)) {
	    displayMessage('COMM',1030,time,'00:00:00');
	    return false;
	}
	if (isNaN(sSecond)) {
	    displayMessage('COMM',1030,time,'00:00:00');
	    return false;
	}

	if (sValid) {
	    if ((sHour < 0) || (sHour > 24)) {
	        displayMessage('COMM',1030,time,'00:00:00');
	        return false;
	    }
	    if ((sMinute < 0) || (sMinute > 59)) {
	        displayMessage('COMM',1030,time,'00:00:00');
	        return false;
	    }
	    if ((sSecond < 0) || (sSecond > 59)) {
	        displayMessage('COMM',1030,time,'00:00:00');
	        return false;
	    }
	}

	if (sValid) {
	    time = sHour + ':' + sMinute + ':' + sSecond;
	}
	return true;

}


function validateMoney(amt, neg) {

  var cs  = '$';//platform.document.GLOBAL.CURRENCY_SYMBOL.value;    // Currency Symbol
  var ts  = ',';//platform.document.GLOBAL.THOUSANDS_SEPERATOR.value;    // Thousands Seperator
  var ds  = '.';//platform.document.GLOBAL.DECIMAL_SEPERATOR.value;    // Decimal Symbol

  if (trim(amt) == '') {
  	return true;
  }

  var moneyExp = new RegExp("^ *" + (neg ? "(-?) *" : "") + "(\\" + cs + "?) *(\\d{1,3})(\\" + ts + "?\\d{3})*(\\" + ds + "\\d\\d)? *$");

  if (moneyExp.test(amt)) {
    return true;
  } else {
  	//displayMessage('COMM',1039, amt, cs, ts, ds);
  	
    return false;
  }
}


function validateNumber(amt, neg) {

  var cs  = platform.document.GLOBAL.CURRENCY_SYMBOL.value;    // Currency Symbol
  var ts  = platform.document.GLOBAL.THOUSANDS_SEPERATOR.value;    // Thousands Seperator
  var ds  = platform.document.GLOBAL.DECIMAL_SEPERATOR.value;    // Decimal Symbol

  if (trim(amt) == '') {
  	return true;
  }

  var numberExp = new RegExp("^ *" + (neg ? "(-?) *" : "") + "(\\" + cs + "?) *(\\d{1,3})(\\" + ts + "?\\d{3})*(\\" + ds + "\\d\\d)? *$");

  if (numberExp.test(amt)) {
    return true;
  } else {
  	//displayMessage('COMM',1040, amt, ts, ds);
    return false;
  }
}


function validateDate(datestr) {

	var datefmt = platform.document.GLOBAL.DATE_FORMAT.value;    // DATE_FORMAT
	var datesep = platform.document.GLOBAL.DATE_SEPERATOR.value;    // DATE_SEPERATOR
	var dateformatForDisplay = platform.document.GLOBAL.DATE_FORMAT_FOR_DISPLAY.value;    // DATE_SEPERATOR

	var iSepPos = datestr.indexOf(datesep);
	var sDateStr = datestr;
	var sStr1 = new String;
	var sStr2 = new String;
	var sStr3 = new String;
	var IsLeap = false;
	var iYear = 0;

	if (trim(datestr) == '') {
		return true;
	}

	if (datestr.length < 6) {
	    displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}

	if (iSepPos > 0) {
	    sStr1 = sDateStr.substring(0,iSepPos);
	    sDateStr = sDateStr.substring(iSepPos + 1, sDateStr.length);
	}
	else {
	    displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}
	iSepPos = sDateStr.indexOf(datesep);
	if (iSepPos > 0) {
	    sStr2 = sDateStr.substring(0,iSepPos);
	    sStr3 = sDateStr.substring(iSepPos + 1, sDateStr.length);
	}
	else {
	    displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}

	while (datefmt.substr(datefmt.length-1,1)==' ') {
	   datefmt = datefmt.substr(0,datefmt.length-1);
	}

	var sMonth = '';
	var sDay = '';
	var sYear = '';
	if ((datefmt == 'MM/dd/yyyy') || (datefmt == 'M/d/yy') || (datefmt == 'MM/dd/yy') || (datefmt == 'M/d/yyyy')) {
	    sMonth = sStr1;
	    sDay = sStr2;
	    sYear = sStr3;
	}
	if ((datefmt == 'dd/MM/yyyy') || (datefmt == 'd/M/yy') || (datefmt == 'dd/MM/yy') || (datefmt == 'd/M/yyyy')) {
	    sDay = sStr1;
	    sMonth = sStr2;
	    sYear = sStr3;
	}
	if (datefmt == 'yy/MM/dd') {
	    sYear = sStr1;
	    sMonth = sStr2;
	    sDay = sStr3;
	}

	if ((((sYear.length - 0) > 4) || (((sYear.length - 0) < 4) && ((sYear.length - 0) != 2))) || ((sDay.length - 0) > 2) || ((sMonth.length - 0) > 2)    ) {
	    displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}

	if (isNaN(sDay)) {
	    displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}
	if (isNaN(sMonth)) {
	    displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}
	if (isNaN(sYear)) {
	    displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}

	iYear = iYear + sYear;

	if((iYear % 4) == 0) {
	   if((iYear % 100) == 0) {
	      if((iYear % 400) == 0) {
	         IsLeap = true;
	      }
	      else {
	         IsLeap = false;
	      }
	   }
	   else {
	      IsLeap = true;
	   }
	}
	else {
	   IsLeap = false;
	}

	if ((sMonth < 1) || (sMonth > 12)) {
		displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    return false;
	}
	else {
		if ((sMonth == 1) || (sMonth == 3) || (sMonth == 5) || (sMonth == 7) || (sMonth == 8) || (sMonth == 10) || (sMonth == 12)) {
    		if ((sDay < 1) || (sDay > 31)) {
		    	displayMessage('COMM',1019,datestr,dateformatForDisplay);
		    	return false;
	    	}
		}
		if ((sMonth == 4) || (sMonth == 6) || (sMonth == 9) || (sMonth == 11)) {
			if ((sDay < 1) || (sDay > 30)) {
		    	displayMessage('COMM',1019,datestr,dateformatForDisplay);
		    	return false;
			}
		}
		if (sMonth == 2) {
	    	if (IsLeap == true) {
	        	if ((sDay < 1) || (sDay > 29)) {
	            	displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    			return false;
	            }
	        }
	        else {
	        	if ((sDay < 1) || (sDay > 28)) {
	            	displayMessage('COMM',1019,datestr,dateformatForDisplay);
	    			return false;
				}
			}
		}
	}
 	return true;
}

/*function checkDate(obj){
	//alert(obj.value);
	if (!validateDate(obj.value)){
		alert('Ngay ' + obj.value + ' khong hop le.');
		obj.focus();
	}
}*/

// This function removes space from both ends of a string.
function trim(txt) {
    txt = txt.replace(/^(\s)+/, '');
    txt = txt.replace(/(\s)+$/, '');
   	return txt;
}

// This function checks for invalid characters and displays given error message.
function validCharacters(eObject, eMsgArea, eMsgID) {
	var aInvalidChars = new Array('~','!','%','^', '&', '*', '+', '=', '}', '{', '[', ']', '|', '\\', ':', '<', '>');
	var sValue        = eObject.value;
	var sInvalids = '';

	for (var i = 0; i < aInvalidChars.length; i++) {
		if (sValue.indexOf(aInvalidChars[i]) > -1) {
			sInvalids = sInvalids + aInvalidChars[i];
		}
	}

	if (sInvalids.length > 0) {
		displayMessage('COMM', 1106, sValue, sInvalids);
		return false;
	} else {
		return true;
	}
}

function checkBoxOnClick(formName, fieldNum){
	field = eval('document.'+formName+'.UF'+fieldNum);

	if (field.value == 0) {
		field.value = 1;
	} else {
		field.value = 0;
	}
}

function checkUFValues(UFform) {
	var field;
	var fieldName;
	var fieldType;
	var fieldValue;
	var mandatory;

	for (var x = 0; x < UFform.elements.length; x++) {

    	// get the field
    	field = UFform.elements[x];
		//fieldName = field.name.substring(0,3);
		fieldName = field.name;

		// if it's a user field
		if (fieldName.substring(0,2) == 'UF' && fieldName.substring(0,3) != 'UFM' && fieldName.indexOf('_') < 0) {
			fieldType = eval('UFform.' + fieldName + '_TYPE.value');
			mandatory = eval('UFform.' + fieldName + '_MANDATORY.value');
			if (fieldType == '6') {
				continue;
			} else {
				fieldValue = eval('UFform.' + fieldName + '.value');
			}

			// check for required fields
			if (mandatory == 1 && (fieldValue == '' || fieldValue == null) && fieldType != 7) {
				displayMessage('COMM', 1028);
				field.focus();
				return false;
			}

			// validation is only performed on date, numeric, and text area fields
			if (fieldType == '2') { // Date
				if (!(validateDate(fieldValue))) {
					field.focus();
					return false;
				}
			} else if (fieldType == '3') { // Numeric
				if (!(validateNumber(fieldValue, true))) {
					field.focus();
					return false;
				}
			} else if (fieldType == '4') { // text
				if (! validCharacters(field)) {
					field.focus();
					return false;
				}
			}  else if (fieldType == '5') { // TextArea
				if (fieldValue.length > 24000) {
					displayMessage('COMM', 1027);
					field.focus();
					return false;
				} else if (! validCharacters(field)) {
					field.focus();
					return false;
				}
			}
		}
	}

	return true;
}


function clearForm(formObj) {

	formObj.reset();
	var fld;

	for (var i=0; i < formObj.elements.length; i++) {
		fld = formObj.elements[i];

		if (
			(fld.type == 'hidden')		||
			(fld.type == 'text')		||
			(fld.type == 'textarea')	||
			(fld.type == 'password')
		   )
		{
			fld.value = '';
		}
		else if ((fld.type == 'select-one') || (fld.type == 'select-multiple'))
		{
			fld.selectedIndex = -1;
		}
		else if ((fld.type == 'checkbox') || (fld.type == 'radio'))
		{
			fld.checked = false;
		}
	}

}

function formatDateForCompare(datestr) {
 	var datefmt = 'dd/MM/yyyy';//platform.document.GLOBAL.DATE_FORMAT.value;    // DATE_FORMAT
	var datesep = '/';//platform.document.GLOBAL.DATE_SEPERATOR.value;    // DATE_SEPERATOR

  	var iSepPos = datestr.indexOf(datesep);
  	var sDateStr = datestr;
  	var sStr1 = new String;
  	var sStr2 = new String;
  	var sStr3 = new String;

  	if (iSepPos > 0) {
      	sStr1 = sDateStr.substring(0,iSepPos);
      	sDateStr = sDateStr.substring(iSepPos + 1, sDateStr.length);
  	}

  	iSepPos = sDateStr.indexOf(datesep);
  	if (iSepPos > 0) {
      	sStr2 = sDateStr.substring(0,iSepPos);
      	sStr3 = sDateStr.substring(iSepPos + 1, sDateStr.length);
  	}

  	datefmt = trim(datefmt.replace(datesep, '/'));
  	var sMonth = '';
  	var sDay = '';
  	var sYear = '';
  	if ((datefmt == 'MM/dd/yyyy') || (datefmt == 'M/d/yy') || (datefmt == 'MM/dd/yy')) {
      	sMonth = sStr1;
      	sDay = sStr2;
      	sYear = sStr3;
  	}
  	if ((datefmt == 'dd/MM/yyyy') || (datefmt == 'd/M/yy') || (datefmt == 'dd/MM/yy')) {
      	sDay = sStr1;
      	sMonth = sStr2;
      	sYear = sStr3;
  	}
  	if (datefmt == 'yy/MM/dd') {
      	sYear = sStr1;
      	sMonth = sStr2;
      	sDay = sStr3;
  	}

  	if (sYear < 100) {
     	if (sYear < 50) {
        		sYear = '20' + sYear; }
     	else {
        		sYear = '19' + sYear; }
  	}
  	if (sMonth < 10) {
       	if (sMonth.length < 2)
          	sMonth = '0' + sMonth;
       	}
  	if (sDay < 10) {
       	if (sDay.length < 2)
              sDay = '0' + sDay;
   	}
  	return sYear + sMonth + sDay;
}

function compareDateToNow(date1) {
	var now = new Date();
  	var sMonth = (now.getMonth() + 1).toString();
  	var sDay = now.getDate().toString();
  	var sYear = now.getFullYear().toString();
  	var sDateStr = '';

  	if (sMonth < 10) {
       	if (sMonth.length < 2){
          	sMonth = '0' + sMonth;
       	}
     }
  	if (sDay < 10) {
       	if (sDay.length < 2) {
              sDay = '0' + sDay;
          }
   	}

   	sDateStr = sYear + sMonth + sDay;

	if (formatDateForCompare(date1) > sDateStr){
  		return 1;
  	}else if (formatDateForCompare(date1) == sDateStr){
  		return 0;
  	}else{
  		return -1;
  	}
}


//Người tạo : TuanNH
//Ngày tạo  : 09/03/2006
//Lý do		: Kiểm tra số tuổi của người đăng ký kinh doanh phải lớn hơn hoặc bằng 18 tuổi
function kiemTraNgaySinhDKKD(date1) {
	var now = new Date();
  	var sMonth = (now.getMonth() + 1).toString();
  	var sDay = now.getDate().toString();
  	var sYear = now.getFullYear().toString();
  	var sDateStr = '';

  	if (sMonth < 10) {
       	if (sMonth.length < 2){
          	sMonth = '0' + sMonth;
       	}
     }
  	if (sDay < 10) {
       	if (sDay.length < 2) {
              sDay = '0' + sDay;
          }
   	}

   	sDateStr = (sYear - 18) + sMonth + sDay;

	if (formatDateForCompare(date1) > sDateStr){
  		return 1;
  	}else if (formatDateForCompare(date1) == sDateStr){
  		return 0;
  	}else{
  		return -1;
  	}
}


function compareDates(date1, date2){
	if (formatDateForCompare(date1) > formatDateForCompare(date2)) {
		return 1;
	}else if(formatDateForCompare(date1) == formatDateForCompare(date2)) {
  		return 0;
  	}else {
  		return -1;
  	}
}


function checkCompareDates(obj1,obj2)
{
	if ((obj1.value!='') && (obj2.value!='') && isValidDate(obj1.value)==0 && isValidDate(obj2.value)==0)
	{
		if (compareDates(obj1.value,obj2.value)==1)
		{
			alert('Ngày bắt đầu phải nhỏ hơn ngày kết thúc');
			obj1.value = "";
			obj1.focus();
			return false;
		}
	}
	return true;
}


function FirstDateOfWeek(dDate){	
	var offset;
	var dt = dDate;

	offset = dt.getDay() - 1;
   	dt.setDate(dt.getDate() - offset);
	return dt;
}

function LastDateOfWeek(dDate){	
	var offset;
	var dt = dDate;

	offset = 6 - dt.getDay() + 1;
   	dt.setDate(dt.getDate() + offset);
	return dt;
}

function FirstDateOfMonth(dDate){	
	var dt = dDate;
   	dt.setMonth(dt.getMonth());
   	dt.setDate(1);
	return dt;
}

function LastDateOfMonth(dDate){	
	var dt = dDate;
   	dt.setMonth(dt.getMonth() + 1 );
   	dt.setDate(1);
   	dt.setDate( dt.getDate() - 1);
	return dt;
}
function FirstDateOfYear(dDate){	
	var dt = dDate;
   	dt.setMonth(0);
   	dt.setDate(1);
	return dt;
}

function LastDateOfYear(dDate){	
	var dt = dDate;
   	dt.setMonth(11);
   	dt.setDate(31);
	return dt;
}



/*********************************************
****  Kiem tra ngay hop le (dd/mm/yyyy)  *****
*********************************************/
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
	
	if (aDDMMCCYY[2] >= 1900)
	{
		if (dtest.getDate() != aDDMMCCYY[0] || dtest.getMonth() +1 != aDDMMCCYY[1] || dtest.getFullYear() != aDDMMCCYY[2])    
		{    
			retval = 2    			
		}    
	}else{
		retval = 3
	}
  }    
  else    
  {    
	retval = 1    
  }
  if (retval==0)
  {
	var arr = new Array();
	arr=strDate.split("/");
	if (arr.length !=3)
		{
			retval=1;
		}
  }
  return retval    
}    
/*********************************************
**** Neu du lieu NULL se return True *********
*********************************************/
function isBlank(obj)
{
	if (obj.length <1 || obj.value=="")
		return true;
	else
		return false;
}
/********************************
**** Goi ham kiem tra ngay ******
********************************/
function CheckDate(obj)    
{   
	if (!isBlank(obj))    
	{    
		if (isValidDate(obj.value)!=0)    
		{				
			return false;
			
		}    
	}    
	return true;
}    
/***************************************
**** Goi ham kiem tra ngay OnBlur*******
****************************************/
function leapYear (Year) { 
        if (((Year % 4)==0) && ((Year % 100)!=0) || ((Year % 400)==0)) 
              {  return (1);} 
        else 
            {    return (0);} 
} 

//////////////////////////////////////
function CheckDateOnBlur_GetNgayHenTra(objNgayNhan,objNgayHopLe,objSoNgayGiaiQuyet,strNgayNghiLe,objNgayHenTra)

{ 

//kiem tra ngay giai quyet isDate?

var objNgay;

objNgay=objNgayNhan;

if (!isBlank(objNgay)) 

{ 

if (isValidDate(objNgay.value)!=0) 

{ 

alert('Ngay ' + objNgay.value + ' khong hop le. Nhap ngay theo dang dd/MM/yyyy.') 

objNgayHenTra.value='';

objNgay.value='';

objNgay.focus();

return false;

} 

}else{

objNgayHenTra.value='';

return false;

}

//kiem tra so ngay giai quyet isNum?

if (!isBlank(objSoNgayGiaiQuyet)) 

{ 

if (isNaN(objSoNgayGiaiQuyet.value)){ 

alert('So ngay giai quyet khong phai la so.'); 

objSoNgayGiaiQuyet.value='';

objNgayHenTra.value='';

objSoNgayGiaiQuyet.focus(); 

return false;

} 

}else{

alert('So ngay giai quyet khong duoc bo trong.'); 

objNgayHenTra.value='';

objSoNgayGiaiQuyet.focus(); 

return false;

}


/*tinh ngay hen tra

strNgay: chuoi can tim trong chuoi ngay nghi

*/



//////////////////////////////////////////////////////////////////////////


objNgayHenTra.value=GetNgayHenTra(objNgayNhan,strNgayNghiLe,objSoNgayGiaiQuyet);

objNgayHopLe.value=objNgayNhan.value;

} 
    
////////////////////////////////////////
function CheckDateOnBlur_GetNgayBoSung(objNgayHopLe,objSoNgayGiaiQuyet,strNgayNghiLe,objNgayHenTra)
{   
	objNgay=objNgayHopLe;
	var now=new Date();
	var year=now.getYear();

	if (!isBlank(objNgay))    
	{    
		if (objNgay.value.length==6)
		{
			objNgay.value=objNgay.value.substr(0,2) + "/" + objNgay.value.substr(2,2) + "/" + year.toString().substr(0,2) + objNgay.value.substr(4,2)
		}
		if (objNgay.value.length==8)
		{
			objNgay.value=objNgay.value.substr(0,2) + "/" + objNgay.value.substr(2,2) + "/" + objNgay.value.substr(4,4)
		}
		if (isValidDate(objNgay.value)!=0)    
		{	
			alert('Ngay ' + objNgay.value + ' khong hop le. Nhap ngay theo dang dd/MM/yyyy.')    
			objNgayHenTra.value='';
			objNgay.value='';
			objNgay.focus();
			return false;
		}    
	}else{
		objNgayHenTra.value='';
		return false;
	}
	//kiem tra so ngay giai quyet isNum?
	if (!isBlank(objSoNgayGiaiQuyet))    
	{    
		if (isNaN(objSoNgayGiaiQuyet.value)){   
			alert('So ngay giai quyet khong phai la so.'); 
			objSoNgayGiaiQuyet.value='';
			objNgayHenTra.value='';
			objSoNgayGiaiQuyet.focus();	
			return false;
		}	
	}else{
		alert('So ngay giai quyet khong duoc bo trong.'); 
		objNgayHenTra.value='';
		objSoNgayGiaiQuyet.focus();	
		return false;
	}
	
	/*tinh ngay hen tra
	strNgay: chuoi can tim trong chuoi ngay nghi
	*/
	
	var strNgay,iNgay,iDem,iTong,pDate;
	var Leap;
    var daysOfYear = new Object(); 

	var strYMD=formatDateForCompare(objNgay.value)
	
	iTong=objSoNgayGiaiQuyet.value;
	iDem=0;
	
	/////////////////////////////////////////////
	/////////////////////////////////////////////
	var days,months,years;
	years=strYMD.substring(0,4);
	months=strYMD.substring(4,6);
	days=strYMD.substring(6,8);
	
	if (leapYear(years)==1) 
            {  Leap=29;} 
    else 
	        {  Leap=28;} 
	
	 daysOfYear[1] = 31; daysOfYear[2] = Leap; daysOfYear[3] = 31; daysOfYear[4] = 30; 
     daysOfYear[5] = 31; daysOfYear[6] = 30; daysOfYear[7] = 31; daysOfYear[8] = 31; 
     daysOfYear[9] = 30; daysOfYear[10] = 31; daysOfYear[11] = 30; daysOfYear[12] = 31; 
	/////////////////////////////////////////////
	var iday,imonth,iyear;
	iday=eval(days);
	imonth=eval(months-1);
	iyear=eval(years);
	/////////////////////////////////
	while(iDem<iTong){
		pDate=new Date(iyear,imonth,iday);
		if ((pDate.getDay()==0) || (pDate.getDay()==6)){//neu la ngay chu nhat hoac la ngay thu bay
			iTong++;
		}
		iday+=1;
		
		if(iday>daysOfYear[imonth+1]){
			iday-=daysOfYear[imonth+1];
			imonth++;
			if(imonth>11){
				imonth-=12;
				iyear++;
			}
		}
		strNgay = ((iday<10) ? "0" : "") + iday + '/' + ((imonth+1<10) ? "0" : "") + (imonth+1);  
		if(strNgayNghiLe.indexOf(strNgay)!=-1){
			iTong++;
		}
		iDem++;
	}
	//xet truong hop ngay hen tra roi vao ngay thu bay va chu nhat v ngay thu bay or chu nhat la ngay nghi le
	var tmpday=0;
	pDate=new Date(iyear,imonth,iday);
	if (pDate.getDay()==6){
		tmpday+=1;
		strNgay = ((iday<10) ? "0" : "") + iday + '/' + ((imonth+1<10) ? "0" : "") + (imonth+1);
		if(strNgayNghiLe.indexOf(strNgay)!=-1){
			tmpday+=1;
		}
		iday=iday+1;//cong 1 cho thanh ngay chu nhat
	}
	
	if(iday>daysOfYear[imonth+1]){
			iday-=daysOfYear[imonth+1];
			imonth++;
			if(imonth>11){
				imonth-=12;
				iyear++;
			}
	}
	pDate=new Date(iyear,imonth,iday);
	if (pDate.getDay()==0){
		tmpday+=1;
		strNgay = ((iday<10) ? "0" : "") + iday + '/' + ((imonth+1<10) ? "0" : "") + (imonth+1);
		if(strNgayNghiLe.indexOf(strNgay)!=-1){
			tmpday+=1;
		}
	}	
	if(tmpday>0){
		iday=iday+tmpday-1;
	}
/*	
	pDate=new Date(iyear,imonth,iday);
	if (pDate.getDay()==0){
		strNgay = ((iday<10) ? "0" : "") + iday + '/' + ((imonth+1<10) ? "0" : "") + (imonth+1);
		if(strNgayNghiLe.indexOf(strNgay)!=-1){
			iday+=2;
		}else{
			iday+=1;
		}
	}
	strNgay = ((iday<10) ? "0" : "") + iday + '/' + ((imonth+1<10) ? "0" : "") + (imonth+1);
	if(strNgayNghiLe.indexOf(strNgay)!=-1){
		iday+=1;
	}
*/
	if(iday>daysOfYear[imonth+1]){
			iday-=daysOfYear[imonth+1];
			imonth++;
			if(imonth>11){
				imonth-=12;
				iyear++;
			}
	}
	imonth+=1;
	///////////////////////////////////////////////////////////////////////////////////////
	objNgayHenTra.value=((iday<10) ? "0" : "") + iday + '/' + ((imonth<10) ? "0" : "") + imonth + '/' + iyear;
}    
////////////////////////////////////////
function CheckDateOnBlur(obj)    
{
	var now=new Date();
	var year=now.getYear();
	if (!isBlank(obj))
	{
		if (obj.value.length==6)
		{
			//TuanNH update ngay 22/05/2006
			//Xu ly tam. xu co Y2K
			var strYear;
			if (obj.value.substr(4,2)<=30) {
				strYear = year.toString().substr(0,2);
			}
			else {
				strYear = (year.toString().substr(0,2)-1).toString();
			}
			obj.value=obj.value.substr(0,2) + "/" + obj.value.substr(2,2) + "/" + strYear + obj.value.substr(4,2)
			//end TuanNH update
		}
		if (obj.value.length==8)
		{
			obj.value=obj.value.substr(0,2) + "/" + obj.value.substr(2,2) + "/" + obj.value.substr(4,4)
		}
		if (isValidDate(obj.value)==1)
		{
			alert('Ngay ' + obj.value + ' khong hop le. Nhap ngay theo dang dd/MM/yyyy.');
			obj.focus();
			return false;
		}
		else if (isValidDate(obj.value)==2)
		{
			alert('Gia tri ngay ' + obj.value + ' khong ton tai trong he thong ngay.');
			obj.focus();
			return false;
		}
		else if ((obj.id == "_ctl0__ctl0__ctl0_txtNgaySinh" || obj.id == "_ctl0__ctl0__ctl0_txtNgaySinhCNMoi") && isValidDate(obj.value)!=2 && isValidDate(obj.value)!=1 ) {
			if (kiemTraNgaySinhDKKD(obj.value) == 1) {
				alert("Người đăng ký kinh doanh dưới 18 tuổi!");
				obj.focus();
				return false;
			}
		}
	}
	return true;
}    
function CheckDateOnBlurWithCompare(obj,obj1)    
{   
	var now=new Date();
	var year=now.getYear();
	if (!isBlank(obj))    
	{    
		if (obj.value.length==6)
		{
			obj.value=obj.value.substr(0,2) + "/" + obj.value.substr(2,2) + "/" + year.toString().substr(0,2) + obj.value.substr(4,2)
		}
		if (obj.value.length==8)
		{
			obj.value=obj.value.substr(0,2) + "/" + obj.value.substr(2,2) + "/" + obj.value.substr(4,4)
		}
		if (isValidDate(obj.value)!=0)    
		{	
			alert('Ngay ' + obj.value + ' khong hop le. Nhap ngay theo dang dd/MM/yyyy.')    
			obj.focus();
			return false;
			if (compareDates(obj.value, obj1.value)==-1){
				alert('Ngay goi khong duoc nho hon ngay nhan!');
				obj.focus();
				return false;
			}
		}    
	}
	
	return true;
}    

/********************************
**** Auto Rsize the Multiline Textbox  ******
********************************/
function ResizeTextbox(objName){    
	eval('document.forms[0]' + '.all("' + objName + '")').setAttribute('rows',eval('document.forms[0]' + '.all("' + objName + '")').getAttribute('rows') + 1)
}    

/********************************
**** Get Email Address List******
********************************/
function AddAddress(Name, EMail,FullName ,Field1, Field2) {
	if (Field1 != null) eval('address = opener.document.forms[0].' + Field1);
	if (Field2 != null) eval('namelist = opener.document.forms[0].' + Field2);
	
	if (address == null) return;
	if (namelist == null) return;
	
	if (EMail.length == 0) return;
	
	if (address.value.length > 0){
		address.value += '; ';
	}	
	if (namelist.value.length > 0){
		namelist.value += '; ';
	}	

	
	if (EMail.indexOf(',') != -1 || EMail.indexOf(';') != -1)
	{	
		address.value += EMail;
		namelist.value += Name;
	}	
	else{
		address.value += EMail;
		namelist.value += Name;
	}

}
// This function currently expects valid date in the form of dd/mm/yy,


function ValidDate(op, dataType, val,val2) {

	val = eval('document.forms[0]' + '.all("' + val + '")')
	val2 = eval('document.forms[0]' + '.all("' + val2 + '")')
	op  = val.value
	
	if(val2.value != 'Ng?y giao') return;
	if(val.value == '') return;
		
	function GetFullYear(year) {
        return (year + parseInt(val.century)) - ((year < val.cutoffyear) ? 0 : 100);
    }
    var num, cleanInput, m, exp;

    if (dataType == "Integer") {
        exp = /^\s*[-\+]?\d+\s*$/;
        if (op.match(exp) == null) 
            return null;
        num = parseInt(op, 10);
        return (isNaN(num) ? null : num);
    }
    else if(dataType == "Double") {
        exp = new RegExp("^\\s*([-\\+])?(\\d+)?(\\" + val.decimalchar + "(\\d+))?\\s*$");
        m = op.match(exp);
        if (m == null)
            return null;
        cleanInput = m[1] + (m[2].length>0 ? m[2] : "0") + "." + m[4];
        num = parseFloat(cleanInput);
        return (isNaN(num) ? null : num);            
    } 
    else if (dataType == "Currency") {
        exp = new RegExp("^\\s*([-\\+])?(((\\d+)\\" + val.groupchar + ")*)(\\d+)"
                        + ((val.digits > 0) ? "(\\" + val.decimalchar + "(\\d{1," + val.digits + "}))?" : "")
                        + "\\s*$");
        m = op.match(exp);
        if (m == null)
            return null;
        var intermed = m[2] + m[5] ;
        cleanInput = m[1] + intermed.replace(new RegExp("(\\" + val.groupchar + ")", "g"), "") + ((val.digits > 0) ? "." + m[7] : 0);
        num = parseFloat(cleanInput);
        return (isNaN(num) ? null : num);            
    }
    else if (dataType == "Date") {
		
        var yearFirstExp = new RegExp("^\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$");
        m = op.match(yearFirstExp);
        
        var day, month, year;
        if (m != null && (m[2].length == 4 || val.dateorder == "ymd")) {
		    day = m[6];
            month = m[5];
            year = (m[2].length == 4) ? m[2] : GetFullYear(parseInt(m[3], 10))
        
        }
        else {
            if (val.dateorder == "ymd"){
                alert('Ngay khong hop le');
                event.returnValue = false;		
                return;
            }						
            var yearLastExp = new RegExp("^\\s*(\\d{1,2})([-./])(\\d{1,2})\\2((\\d{4})|(\\d{2}))\\s*$");
            m = op.match(yearLastExp);
            if (m == null) {
				alert('Ngay khong hop le');
                event.returnValue = false;		
                return;
            }
            if (val.dateorder == "mdy") {
                day = m[3];
                month = m[1];
            }
            else {
                day = m[1];
                month = m[3];
            }
            year = (m[5].length == 4) ? m[5] : GetFullYear(parseInt(m[6], 10))
        }
        month -= 1;
        var date = new Date(year, month, day);
		
		if (date.getFullYear()>=1900){
			if(typeof(date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate()){
				return date.valueOf()
			}else{
				alert('Ngay khong hop le');
				event.returnValue = false;		
				return;
			}
		}else{
			alert('Ngay khong hop le');
			event.returnValue = false;		
			return;			
        }
        
        //return (typeof(date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate()) ? date.valueOf() : false;
      
    }
    else {
       
        return op.toString();
        
    }
}

// This function currently expects valid times in the form of xx:xx:xx,
// using a military (24-hour) clock

function checkTime(time){
	var iSepPos = time.indexOf(':');
	var sTimeStr = time;
	var sStr1 = new String;
	var sStr2 = new String;
	var sStr3 = new String;

	sStr1 = 'x';
	sStr2 = 'x';
	sStr3 = 'x';

	if (trim(time) == '') {
		return true;
	}

	if (iSepPos > 0) {
	    sStr1 = sTimeStr.substring(0,iSepPos);
	    sTimeStr = sTimeStr.substring(iSepPos + 1, sTimeStr.length);
	}

	iSepPos = sTimeStr.indexOf(':');
	if (iSepPos > 0) {
	    sStr2 = sTimeStr.substring(0,iSepPos);
	    sStr3 = sTimeStr.substring(iSepPos + 1, sTimeStr.length);
	}
	else {
	    sStr2 = sTimeStr;
	    sStr3 = '00';
	}

	
	var sHour = sStr1;
	var sMinute = sStr2;
	var sSecond = sStr3;

	if(sHour=='' || sMinute=='' || sSecond=='') {
		alert('Giờ phải có dạng 00:00');
	    return false;
	}
	
	if (isNaN(sHour)) {
		alert('Giờ phải có dạng 00:00');
	    return false;
	}
	if (isNaN(sMinute)) {
	    alert('Giờ phải có dạng 00:00');
	    return false;
	}
	if (isNaN(sSecond)) {
		alert('Giờ phải có dạng 00:00');
	    return false;
	}

	
	if ((sHour < 0) || (sHour > 24)) {
	    alert('Giờ không quá 24 !');
	    return false;
	}
	if ((sMinute < 0) || (sMinute > 59)) {
	    alert('Phút không quá 60 !');
	    return false;
	}
	if ((sSecond < 0) || (sSecond > 59)) {
		alert('Giây không quá 60 !');
	    return false;
	}

	time = sHour + ':' + sMinute + ':' + sSecond;
	return true;
}

function ShowAttachedFile(path,filename){
	if(filename ==''){
		alert('Chua đính kèm văn bản !');
		return;
	}else{
		var width = screen.width;
		var height = screen.height;
		var l = 0 //(screen.width - 10 - width)/2;
		var t = 0 //(screen.height -  10 - height)/2;	
		FileWindow = window.open( path + filename ,'AttachedFile','toolbar=0,scrollbars=1, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
		FileWindow.focus();
	}					
}

function ShowUploadWindow(objID,dirName){
	var width = screen.width;
	
	var height = screen.height;
	var l = (screen.width - 10 - width)/2;
	var t = (screen.height -  10 - height)/2;	
	FileWindow = window.open('../DesktopModules/UploadFile.aspx?ObjID=' + objID + '&ModuleName=' + dirName,'UploadFiles','toolbar=0,scrollbars=1, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height/2 + ',1 ,align=center');
	FileWindow.focus();
}
//****************************************************

function validateEmail(objemail) {
var email;
	email=objemail.value;
	//alert(email);
	if (trim(email) == '') {
		return true;
	} else {
		var emailExp = new RegExp("^[\\w\\-\\.]+\\@[\\w\\-]+\\.[\\w\\-]+");

		if (emailExp.test(email))  {
			return true;
		} else {
			//displayMessage('COMM', 1016);
			alert('Dữ liệu nhập không phải địa chỉ mail !');
			objemail.focus();
			return false;
		}
	}

}

function validCharacter(eText) {
	var aInvalidChars = new Array('~','!','%','^','$','#','&','*','+','=','}','{','[',']','|','\\',':','<','>');
	var sFilterValue = eval('document.forms[0].all("' + eText + '")').value;
	var sInvalids = '';
	
	for (var i = 0; i < aInvalidChars.length; i++) {
		if (sFilterValue.indexOf(aInvalidChars[i]) > -1) {
			sInvalids = sInvalids + aInvalidChars[i];
		}
	}
	if (sInvalids.length > 0) {
		alert('Có kí tự đặc biệt');		
		document.forms[0].all(eText).focus();		
		return false;
	} else {
		return true;
	}
}
function Change(obj, obj2)
{
	eval('document.forms[0].all("' + obj + '")').value = 'Y';

	strCheck = '13';	
	if (strCheck.indexOf(event.keyCode) != -1)
		eval('document.forms[0].all("' + obj2 + '")').focus();
}

function ShowHideDiv(objDiv, objImg){
	if (objDiv.style.display == ""){
		objDiv.style.display = "none";
		objImg.src="../../images/plus.gif";
	}else{
		objDiv.style.display = "";
		objImg.src="../../images/minus.gif";
	}
}


function isNumeric(obj,isnotblank)   
{   
	var so;
	so=(obj.value);
	if(isnotblank=='1')//1: khong cho trong <> duoc quyen bo trong
		if(so==''){
			alert('Khong duoc bo trong truong nay !'); 
			obj.focus();	
			return false;
		}
	
	if (isNaN(so)){   
		alert('Du lieu nhap phai la kieu so.'); 
		obj.value='';
		obj.focus();	
		return false;
	}	
	if(so.length>0){
		if(isNaN(so.substring(0,1))==true){
			alert('Khong duoc nhap vao so am !');
			obj.focus();	
			return false;
		}
	}
	
	
	while (so.indexOf('.')!=-1)
	{
		so=so.replace('.','');
	}
	so=(so).replace(',','.');
	if (so*1>999999999){   
		alert('So nhap vao khong duoc lon hon so 999.999.999 !'); 
		obj.value='';
		obj.focus();	
		return false;
	}	
	else
	{
		return true;
	}
}


/////////////////////////////////////////////////////////////////////////////////////////
/*
Description: Tu?n Anh th?m c?c h?m du?i d?y
Date: 04/06/2004
*/

/////////////////////////////////////////////////////////////////////////////////////////
/* Construct for the object getParamURL */
var getParamURL = function(_url)
{
	this.URL = _url;
	this.URLls = function() {return this.URL;}
	this.getParameter = function(_para)
		{
			var strURL= this.URL;
			var strGet = _para + "=";
			var _return="";
			
			strURL = strURL.slice(strURL.indexOf("?")+1, strURL.length);
			pos = strURL.indexOf(strGet);
			i = pos + strGet.length;
			if (pos != -1){
				while (i<=strURL.length && strURL.charAt(i) != "&"){
					_return = _return + strURL.charAt(i);
					i++;
				}
			}else{
				_return = null;
			}
			return _return;
		}
}

/////////////////////////////////////////////////////////////////////////////////////////
/* Trim spaces in the left side of the string */
function LTrim(iStr)
{
	while (iStr.charCodeAt(0) <= 32){
		iStr=iStr.substr(1);
	}
	return iStr;
}

/////////////////////////////////////////////////////////////////////////////////////////
/* Trim spaces in the right side of the string */
function RTrim(iStr)
{
	while (iStr.charCodeAt(iStr.length - 1) <= 32){
		iStr=iStr.substr(0, iStr.length - 1);
	}
	return iStr;
}

/////////////////////////////////////////////////////////////////////////////////////////
function swapClass(obj, cls)
{	obj.className = cls; }

/////////////////////////////////////////////////////////////////////////////////////////
function statusBar(obj)
{	window.status=obj.outerText; }

/////////////////////////////////////////////////////////////////////////////////////////
function getCookieVal(offset) {
	var endstr = document.cookie.indexOf(";", offset);
	if (endstr == -1)
	endstr = document.cookie.length;
	return unescape(document.cookie.substring(offset, endstr));
}

/////////////////////////////////////////////////////////////////////////////////////////
function GetCookie (name) {
	var arg = name + "=";
	var alen = arg.length;
	var clen = document.cookie.length;
	var i = 0;
	while (i<clen) {
		var j = i + alen;
		if (document.cookie.substring(i,j) == arg)
		return getCookieVal(j);
		i = document.cookie.indexOf(" ", i) + 1;
		if (i=0)
		break;
	}
	return null;
}

/////////////////////////////////////////////////////////////////////////////////////////
function SetCookie (name, value) {
	var argv = SetCookie.arguments;
	var argc = SetCookie.arguments.length;
	var expires = (argc > 2) ? argv[2] : null;
	var path = (argc > 3) ? argv[3] : null;
	var domain = (argc > 4) ? argv[4] : null;
	var secure = (argc > 5) ? argv[5] : false;
	
	document.cookie = name + "=" + escape(value) + ((expires == null) ? "" : ("; expires=" + expires.toGMTString()))
						+ ((path == null) ? "" : ("; path=" + path)) + ((domain == null)? "" : ("; domain=" + domain))
						+ ((secure == null)? "; secure" : "");
}

/////////////////////////////////////////////////////////////////////////////////////////
function DeleteCookie (name) {
	var exp =  new Date();
	exp.setTime (exp.getTime()-1);
	var cval = GetCookie(name);
	document.cookie = name + "=" + cval + "; expires=" + exp.toGMTString();
}

/////////////////////////////////////////////////////////////////////////////
/*function showDialog(sURL, sWidth, sHeight){
	iwidth = sWidth; //screen.width - 50;
	iheight = sHeight; //screen.height - 100;
	
	alert(iwidth);
	alert(iheight);
	
	t = screen.height/2-iheight;//(screen.height - height)/2;		
	l = screen.width/2-iwidth;//(screen.width - iwidth)/2;
	
	
	win = window.open(sURL,'win','toolbar=0,scrollbars=1, alwaysRaised=Yes, width=' + width + ',height=' + height + ',top=' + t + ',left=' + l +',1 ,align=top');
	win.focus();
}*/

function CheckDataInNeg(obj) {	
	var so;
	so=(obj.value);
	if(so=='')
		return false;
	
	while (so.indexOf('.')!=-1)
	{
		so=so.replace('.','');
	}
	so=(so).replace(',','.');
	if (so*1>99999999999999){   
		alert('So nhap vao khong duoc lon hon so 99.999.999.999.999 !'); 
		//obj.value=so.substring(0,14);
		obj.focus();	
		return false;
	}	
	if (isNaN(so)){   
		alert('Du lieu nhap phai la kieu so.'); 
		obj.value='';
		obj.focus();	
		return false;
	}	
	if (so<=0)
	{
		alert('Du lieu nhap phai la so khong am.'); 
		obj.value='';
		obj.focus();
		return false;
	}
	else
	{
		obj.value=convertSoVN(so);
		return true;
	}
}	
function CheckData(obj) {	

//==================TuanNH (1.0)======================
//Ngày : 24/02/2006
//Mục đích : kiểm tra "Vốn từ" không được lớn hơn "Vốn đến"

	var VonTu  = "";
	var VonDen = "";
	
	//get VonTu & VonDen's value if they're not undefine
	if (document.forms[0]._ctl0__ctl0__ctl0_txtVonTu != undefined) {
		VonTu = document.forms[0]._ctl0__ctl0__ctl0_txtVonTu.value;
	}
	if (document.forms[0]._ctl0__ctl0__ctl0_txtVonDen != undefined) {
		VonDen = document.forms[0]._ctl0__ctl0__ctl0_txtVonDen.value;
	}
//==================End (1.0)=========================	
	

	var so;
	so=(obj.value);
	if(so=='')
		return false;
	
	while (so.indexOf('.')!=-1)
	{
		so=so.replace('.','');
	}
	so=(so).replace(',','.');
	if (so*1>99999999999999){   
		alert('So nhap vao khong duoc lon hon so 99.999.999.999.999 !'); 
		//obj.value=so.substring(0,14);
		obj.focus();	
		return false;
	}	
	if (isNaN(so)){   
		alert('Du lieu nhap phai la kieu so.'); 
		obj.value='';
		obj.focus();	
		return false;
	}
	else if (VonTu != "" && VonDen != "") {
		if (parseInt(VonTu) > parseInt(VonDen)) {
			alert("Số vốn từ không thể lớn hơn số vốn đến");
			document.forms[0]._ctl0__ctl0__ctl0_txtVonTu.focus();
			return false;
		}
	}
	else
	{
		obj.value=convertSoVN(so);
		return true;
	}
}	

function CheckDataSum(obj1, obj2, obj3) {	
	var so;
	so=(obj1.value);
	if(so=='')
		return false;
	
	while (so.indexOf('.')!=-1)
	{
		so=so.replace('.','');
	}
	so=(so).replace(',','.');
	if (so*1>99999999999999){   
		alert('So nhap vao khong duoc lon hon so 99.999.999.999.999 !'); 
		//obj.value=so.substring(0,14);
		obj1.focus();	
		return false;
	}	
	if (isNaN(so)){   
		alert('Du lieu nhap phai la kieu so.'); 
		obj1.value='';
		obj1.focus();	
		return false;
	}	
	else
	{
		//alert(so);
		//alert(so.indexOf('.'));
		if(so.indexOf('.')!=-1){
			so=so.substring(0,so.indexOf('.'));
		}
		//format obj2
		var so2;
		so2=obj2.value;
		while (so2.indexOf('.')!=-1)
		{
			so2=so2.replace('.','');
		}
		so2=(so2).replace(',','.');
		if(so2.indexOf('.')!=-1){
			so2=so2.substring(0,so2.indexOf('.'));
		}
		/////////////
		var so3;
		obj3.value=so*1 + so2*1;
		obj3.value=convertSoVN(obj3.value);
		obj1.value=convertSoVN(so);
		
		return true;
	}
}	

function convertSoVN(so)
{
    var kq;
    
    var nguyen;
    var le;
    var pos;
    kq='';
    pos = so.indexOf('.');

    if (pos == -1) {
		nguyen = so;
        le = '';}
    else {
        nguyen = so.substring(0, pos);
        le = so.substring(pos + 1,so.length);
        }
    
    while (nguyen.length > 3) {
        kq = nguyen.substring(nguyen.length - 3,nguyen.length) + '.' + kq;
        nguyen = nguyen.substring(0, nguyen.length - 3);
    }
    if (nguyen.length > 0) {
		if (kq!='')
			{  
				kq = nguyen + '.' + kq;
			}
		else	
			{ 
			kq = nguyen;
			}
    }
    if (kq.length > 3) {
        kq = kq.substring(0, kq.length - 1);
    }
    
    if (le.length > 2) {
		
        if (parseInt(le.substring(2,le.length)) >= 5) {
	
            le = (parseInt(le.substring(0, 2)) + 1).toString();
            }
        else {
			le = (parseInt(le.substring(0, 2))).toString(); 
        } 
    }
    else
    {
		if(le.length==1)
			le = le + '0'
		else if(le.length<1)
			le = le + '00'
    }
    if (le!='00')
    {
		kq = kq + ',' + le;
    }
    return kq;
    
}

function UpLoadFile(TableName, FileID, FileName, FileDinhKem, ObjID, TabID, Index)
{
		var _objID=document.all(ObjID).value;
		showDialog('QLDA/DesktopModules/UploadFile.aspx?Tabid=' + TabID + '&Index=' + Index +'&TableName=' + TableName + '&ObjID=' + _objID + '&FileID=' + FileID + '&FileName=' + FileName + '&FileDinhKem=' + FileDinhKem ,'500','400');
}

function showDialog(obj1,obj2,obj3)
{
		//obj2: rong - obj3: cao
		t = (screen.height-obj3)/2;//(screen.height - height)/2;		
		l = (screen.width-obj2)/2;//(screen.width - iwidth)/2;
		
		
		//win = 
		window.open(obj1,'win','toolbar=0,scrollbars=yes, alwaysRaised=Yes, width=' + obj2 + ',height=' + obj3 + ',top=' + t + ',left=' + l +',1 ,align=top');
		//win.focus();

		//window.open(obj1,"Application","width=" + obj2 + ",height=" + obj3,-1);
}

// Add by DaoLT
// Duoc su dung de cong 1 cot trong luoi, tu hang rowBegin den rowEnd
function sumColumn(gridID, strColumnName, rowBegin, rowEnd)
{
	var value,j,tentxtGiaTri,so;
	var total;
	var kq;
	total = 0
	for (j=rowBegin; j<rowEnd; j++)
	{
		name = gridID + "__ctl" + j + "_" + strColumnName;
		value = eval('document.forms[0].all("' + name + '")').value;
		
		if(value!='')
		{
			while (value.indexOf('.')!=-1)
			{
				value=value.replace('.','');
			}
			value = value.replace(",", ".")
			if(!isNaN(value))
			{
				total = total + (value * 1);
			}
		}
	}
	
	
	kq = total + '';
	kq = convertSoVN(kq);
	return kq
}
//checkall dung de check all check in grid khi click check box all
function CheckAll(gridID, strHeaderName, strColumnName){
	var NameOfCheckboxAll;
	var NameOfCheckbox;
	var flgcheck;
	var rowEnd;
	alert('a');
	rowEnd = eval('document.forms[0].all(gridID)').rows.length;
	NameOfCheckboxAll=gridID + "__ctl" + 1 + "_" + strHeaderName;
	flgcheck=eval('document.forms[0].all("' + NameOfCheckboxAll + '")').checked;//NameOfCheckboxAll.checked
	for (j=2; j<=rowEnd; j++)
	{
		NameOfCheckbox = gridID + "__ctl" + j + "_" + strColumnName;
		eval('document.forms[0].all("' + NameOfCheckbox + '")').checked=flgcheck;
	}
	return '1';
}
function checkAll() {
	var obj, flagCheck;
	flagCheck = false;
	
    //get controls
	for (i=0;i<window.document.forms(0).length;i++)
	{
		obj = window.document.forms(0).item(i);
		if (obj.id.indexOf("chkAll") != -1)
		{
			if (obj.checked == true) {
				flagCheck = true;
			}
			else {
				flagCheck = false;
			}
		}
		if (obj.id.indexOf("chkXoa")!=-1) {
			obj.checked = flagCheck;
		}
	}
}
//end ngantl
function CheckNull()
		{
		var i;
		var str;
		var obj;
				
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			
				if (obj.ISNULL == 'NOTNULL' && obj.value=='')
				{
					
					alert('Ban chua dien du thong tin!')    
					obj.focus();
					return false;
				}
			
		}
			return true;
		}

function CheckNullBoSung()
		{
		var i;
		var str;
		var obj;
				
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			
				if (obj.ISNULL == 'NOTNULL' && obj.value=='')
				{
					
					alert('Ban chua nhap so ngay bo sung!')    
					obj.focus();
					return false;
				}
			
		}
			return true;
		}
/////
function CheckNullNgay()
		{
		var i;
		var str;
		var obj;
				
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
				if (obj.ISNULL == 'NOTNULL' && obj.value=='')
				{
					alert('Ban chua dien du thong tin!')    
					obj.focus();
					return false;
				}else{
					if(isValidDate(obj.value)!=0){
						obj.focus();
						return false;
					}
				}
		}
			return true;
		}

/////
function CheckNullChild()
		{
		var i;
		var str;
		var obj;
				
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			
				if (obj.ISNULL == 'NOTNULLCHILD' && obj.value=='')
				{
					alert('Ban chua dien du thong tin!')    
					obj.focus();
					return false;
				}

			
		}
			return true;
		}		

function CallDanhMuc(TableName)
{
		showDialogDM('QLDA/DesktopModules/DanhMuc.aspx?TableName=' + TableName);
}

function showDialogDM(obj1)
{
	//alert(obj1);
	//return;
		t = screen.height - 30;
		w = screen.width - 10;
		window.open(obj1,"Application","width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}

function CallWindowParams(strURL,Parent)
{		
		strURL = GetParams(strURL);
		showWindow(strURL,Parent);		
}
function CallWindow(strURL,Parent)
{		
		showWindow(strURL,Parent);
}
function CallWindow(strURL,Parent,width,height)
{		
		showWindow(strURL,Parent,width,height);
}
/*
	TuanNH Them
	Ngay 07/06/2006
	Mo ta : 
*/
function CallWindowGCN(strURL,Parent)
{		
		t = screen.height - 30;
		w = screen.width - 10;
		//alert (obj1);
		//window.open(obj1,"Application","width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
		window.open(strURL,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}

function showWindow(obj1,Parent)
{
		t = screen.height - 30;
		w = screen.width - 10;
		//alert (obj1);
		//window.open(obj1,"Application","width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
		window.open(obj1,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}

/////////////////////////////////////
//	Description		:Add more params
//	Created By		:TuanMH
//	Created Date	:Sep 6th 2006
/////////////////////////////////////
function CallWindowKiemTra(strURL,Parent,width,height)
{		
		showWindowKiemTra(strURL,Parent,width,height);
}
function showWindowKiemTra(obj1,Parent,width,height)
{
		window.open(obj1,Parent,"width=" + width + ", height=" + height + ", left=" + (screen.width - width)/2 + ", top=" + + (screen.height - height)/2 + ", scrollbars=no");
}

/////////////////////////////////////
//	Description		:Add more params
//	Created By		:PhuocDD
//	Created Date	:Mar 29th 2006
/////////////////////////////////////
/*
function CallWindow(strURL,Parent,width,height)
{		
		showWindow(strURL,Parent,width,height);		
}*/
/////////////////////////////////////
//	Description		:Add more params
//	Created By		:PhuocDD
//	Created Date	:Mar 29th 2006
/////////////////////////////////////
/*
function showWindow(obj1,Parent,width,height)
{
		window.open(obj1,Parent,"width=" + width + ", height=" + height + ", left=" + (screen.width - width)/2 + ", top=" + + (screen.height - height)/2 + ", scrollbars=no");
}*/				

function GetText_DropDownList(objDll,objLbl){
	if(objDll.selectedIndex>=0)
	objLbl.innerText=objDll.options[objDll.selectedIndex].text;
}

//Anhlh Report

/*
function ShowReport(report, sql, param, value, path, isInPhieuChuyen)
			{
				if (isInPhieuChuyen != "" && isInPhieuChuyen != null) {
					if (KiemTraThongTinInDanhSach() == 0) {
						t = screen.height - 30;
						w = screen.width - 10;
						//alert(path + '/Reports/COMM_ReportGen.asp?report=' + report);
						sql=GetParamReport(sql);
						//alert(sql);
						//return;
						//alert(path + '/Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=yes,resizable')
						//return;
						FileWindow = window.open(path + '/Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=yes,resizable');
						//oURL = 'showReport.aspx?report=' + report + '&sql=' + sql + '&title=';
						//alert(oURL);
						//FileWindow = window.open(oURL,'_blank','toolbar=0,scrollbars=1, alwaysRaised=Yes, top=0, left=0, width=' + w + ', height=' + t + ',1 ,align=center');
						//oURL = 'showReport.aspx?report=' + report + '&sql=' + sql + '&title=' + title;
						//FileWindow = window.open(oURL,'_blank','toolbar=0,scrollbars=1, alwaysRaised=Yes, top=' + t + ', left=' + l + ', width=' + width + ', height=' + height + ',1 ,align=center');
						
						FileWindow.focus();
						return true;
					}
					else if (KiemTraThongTinInDanhSach() == 1) {alert('Bạn phải chọn hồ sơ để in');return false;}
					else if (KiemTraThongTinInDanhSach() == 2) {alert('Không có hồ sơ để in!');return false;}
				}
				else {
					t = screen.height - 30;
					w = screen.width - 10;
					//alert(path + '/Reports/COMM_ReportGen.asp?report=' + report);
					sql=GetParamReport(sql);
					//alert(sql);
					//return;
					//alert(path + '/Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=yes,resizable')
					//return;
					FileWindow = window.open(path + '/Reports/COMM_ReportGen.asp?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=yes,resizable');
					
					//oURL = 'showReport.aspx?report=' + report + '&sql=' + sql + '&title=';
					//alert(oURL);
					//FileWindow = window.open(oURL,'_blank','toolbar=0,scrollbars=1, alwaysRaised=Yes, top=0, left=0, width=' + w + ', height=' + t + ',1 ,align=center');
					
					FileWindow.focus();
					return true;
				}
			}


*/


/*
  Show Report with Crystal Report 10 
*/

function ShowReport(report, sql, param, value, path, isInPhieuChuyen)
{

	if (isInPhieuChuyen != "" && isInPhieuChuyen != null) {
		if (KiemTraThongTinInDanhSach() == 0) {
			t   = screen.height - 30;
			w   = screen.width - 10;			
			sql = GetParamReport(sql);			
			FileWindow = window.open(path + '/Reports/rptReport.aspx?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=no,resizable');
			
			FileWindow.focus();
			return true;
		}
		else if (KiemTraThongTinInDanhSach() == 1) {alert('Bạn phải chọn hồ sơ để in');return false;}
		else if (KiemTraThongTinInDanhSach() == 2) {alert('Không có hồ sơ để in!');return false;}
	}
	else {
		t   = screen.height - 30;
		w   = screen.width - 10;
		
		sql = GetParamReport(sql);
		
		FileWindow = window.open(path + '/Reports/rptReport.aspx?report=' + report + '&sql=' + sql + '&formula=' + param + '&Value=' + value ,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=yes,resizable');
		
		FileWindow.focus();
		return true;
	}
}			


function GetParamReport(str)
{		
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			
			if (str.indexOf(obj.id) != -1 && obj.id!='')
			{				
			
				str=str.replace(obj.id,'N[' + obj.value);
			}
		}
		while (str.indexOf('"')!=-1)
		{
			str=str.replace('"',"'");
			str=str.replace("'N[","N'");
		}
		return str;
}			
function GetParams(str)
{		
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			obj=window.document.forms(0).item(i);
			if (str.indexOf(obj.id) != -1 && obj.id!='')
			{					
				str=str.replace(obj.id,obj.value);
			}
		}
		while (str.indexOf('"')!=-1)
		{
			str=str.replace('"',"'");
			
		}
		return str;
}			
//End Reports
function select_deselectAll (chkAll) 
{ 
	var frm = document.forms[0];
	var i;
	var objAll;
	var obj;
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chkAll) != -1)
		{
			objAll = window.document.forms(0).item(i);	
		}
	}
	for (i=0;i<window.document.forms(0).length-1;i++)
	{
		obj = window.document.forms(0).item(i);
		if (window.document.forms(0).item(i).id.indexOf('chkXoa') != -1 )
		{
			
			if (obj.disabled == false)
			{
				if (objAll.checked == true)
				{
					obj.checked = true;
				}
				else
				{
					obj.checked = false;
				}
			}
		}
		if (window.document.forms(0).item(i).id.indexOf('txtSoBanChinh') != -1 )
		{
			if (objAll.checked == true) {
				obj.disabled = false;
			}
			else {obj.disabled = true;}
		}
		if (window.document.forms(0).item(i).id.indexOf('txtSoBanSao') != -1 )
		{
			if (objAll.checked == true) {
				obj.disabled = false;
			}
			else {obj.disabled = true;}
		}
	}
}
//kiem tra so cmnd

function isSoCMND(obj,isnotblank)   
{   
	var so;
	so=(obj.value);
	if(isnotblank=='1'){//1: khong cho trong <> duoc quyen bo trong
		if(so==''){
			alert('Khong duoc bo trong truong nay !'); 
			obj.focus();	
			return false;
		}
	}else{
		while (so.indexOf('.')!=-1)
		{
			so=so.replace('.','');
		}
		so=(so).replace(',','.');
		if (so*1>999999999){   
			alert('So nhap vao khong duoc lon hon so 999.999.999 !'); 
			obj.value='';
			obj.focus();	
			return false;
		}	
		if (isNaN(so)){   
			alert('Du lieu nhap phai la kieu so.'); 
			obj.value='';
			obj.focus();	
			return false;
		}	
		else
		{
			if((obj.value.length!=9) && (obj.value.length!=0)){
				alert('So chung minh nhan dan phai la 9 so !');
				obj.focus();
				return false;
			}
			else{
				return true;
			}
		}
	}
}
function CheckCMND(obj) {	
	var so;
	so=(obj.value);
	if(so=='')
	{
		return false;			
	}
	
	if (isNaN(so) || so.length!=9){   
		alert('So CMND khong hop le!'); 
		obj.focus();	
		return false;
	}	
	else
	{
		return true;
	}
}	

function CheckSoNguyen(obj) {	
	var so;
	so=(obj.value);
	if(so=='')
	{
		return false;			
	}
	
	if (isNaN(so)){   
		alert('So khong hop le!'); 
		obj.focus();	
		return false;
	}	
	else
	{
		return true;
	}
}	

function CheckEnter()
{
	var node = (window.event.target)?window.event.target:((window.event.srcElement)?window.event.srcElement: null);
    if ((window.event.keyCode == 13) && (node.type=='text'))
	{
		return false;
	}
}
//Loai DanhMuc_Chon
function DanhMucChon(strURL,Parent)
{		
		strURL = GetParams(strURL);
		showDanhMucChon(strURL,Parent);		
}
function DanhMucChon(obj1,Parent)
{
		//t = screen.height - 30;
		t = 300;
		//w = screen.width - 10;
		w = screen.width/1.5;
		window.open(obj1,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}

//End Loai DanhMuc_Chon
function CheckEnter()
{
	var node = (window.event.target)?window.event.target:((window.event.srcElement)?window.event.srcElement: null);
    if ((window.event.keyCode == 13) && (node.type=='text'))
	{
		return false;
	}
}
///////////////////////////////////////////////
function getNow(obj)
{
	var strDay, strMonth, strYear;
	var iDay, iMonth;
	var d = new Date();
	
	//kiểm tra nếu nhấn phím F2(ansi:113) thì hiện ngày hiện hành
	if (window.event.keyCode == 113)
	{
		iDay = d.getDate();
		if (iDay < 10)
			strDay = '0' + iDay;
		else
			strDay = iDay;
		
		iMonth = d.getMonth() + 1;
		if (iMonth < 10)
			strMonth = '0' + iMonth;
		else
			strMonth = iMonth;
		
		strYear = d.getFullYear();
		obj.value = strDay + '/' + strMonth + '/' + strYear;
	}
}
//using onkeypress
function ValidateNumeric() 
{ 
	 var keyCode = window.event.keyCode; 
	 if (keyCode==13) 
	 {
		window.focus();
		return;	
	 }
	 if (keyCode > 57 || keyCode < 48 ) 
	 window.event.returnValue = false; 
}
//ThuyTT add date 16/01/2006
//Mục đích:
//	- kiểm tra dữ liệu nhập vào có phải kiểu số
//	- kiểm tra số có nằm trong khoảng đã qui định (min,max)
//	- convert định dạng số theo kiểu Việt Nam (numDigit là số số lẻ, trường hợp null là lấy tất cả số lẻ đã nhập
function ConvertNumericVN(obj, unit, numDigit , min, max)
{
	var so;
	var point = ',';
	var separator = '.';
	
	so=(obj.value);
	
	if(so == '')	return false;
	
	//TuanNH add 01/03/2006
	//Mục đích : kiểm tra vốn kinh doanh nhập vào không nhỏ hơn TienVonMin và lớn hơn TienVonMax
	// sau khi nhân với DonViTinh
	var dpos = so.indexOf('.');
	while (dpos != -1) { 
		so = so.replace('.','');
		dpos = so.indexOf('.');
	}
	so=so.replace(separator,'');
	so=so.replace(point,'.');
	var vonkinhdoanh = parseFloat(so) * parseInt(unit);
	//end
	//kiểm tra kiểu số
	if (isNaN(so)){
		alert('Dữ liệu nhập phải là kiểu số!'); 
		obj.value='';
		obj.focus();
		return false;
	}
		
	//kiểm tra khoảng số
	if (min != null){
		if (vonkinhdoanh < min){
			alert('Số nhập vào phải lớn hơn ' + addSeparator(min,null,point,separator));
			obj.focus();
			return false;
		}
	}
	
	if (max != null){
		if (vonkinhdoanh > max){
			alert('Số nhập vào phải nhỏ hơn ' + addSeparator(max,null,point,separator));
			obj.focus();
			return false;
		}
	}

	//convert định dạng số
	obj.value = addSeparator(so, numDigit,point, separator);
	return true;
}

function addSeparator(so, numDigit, point, sep)
{
	if (numDigit != null && numDigit >= 0)
		so = (so*1).toFixed(numDigit);
	
	var nStr = so + '';
	var nStrEnd = '';
	var dpos = nStr.indexOf('.');
	
	if (dpos != -1) {
		nStrEnd = point + nStr.substring(dpos + 1, nStr.length);
		nStr = nStr.substring(0, dpos);
	}
	
	var rgx = /(\d+)(\d{3})/;
	while (rgx.test(nStr)) {
		nStr = nStr.replace(rgx, '$1' + sep + '$2');
	}
	
	return nStr + nStrEnd;
}
//ThuyTT end


//Created Author : TuanNH 
//Created Date   : 08/03/2006
//Brief			 : ''
//Updated Date   : 08/05/2006
function KiemTraThongTinInDanhSach()
{
	var i;
	var obj;
	var flagCheck      = false;
	var flagDisable    = false;
	var flagAvaibility = false;
	
	if (window.document.forms(0) != undefined) {
		for (i=0; i<window.document.forms(0).length-1; i++)
		{
			obj = window.document.forms(0).item(i);
			if (obj.id.indexOf('chkXoa') != -1)
			{
				flagAvaibility = true;
				if (obj.checked == true)
				{
					flagCheck = true;
				}
				else if (obj.checked == false && obj.disabled == true) {flagDisable = true;}
			}
		}
		if (flagAvaibility == true) {
			if (flagCheck == true) {return 0;}	// Có dữ liệu và check
			if (flagCheck == false && flagDisable == true) {return 0;}	// Có dữ liệu nhưng đã disable checkbox
			if (flagCheck == false) {return 1;}	// Chưa check
		}
	}
	return 2;	//Không có dữ liệu
}

function KiemTraNamSinhDKKD(objNgaySinh)
{
	
	if (objNgaySinh.value.length==4 && isInteger(objNgaySinh.value))
	{
		var Tuoi;
		var now = new Date();
  		var sYear = now.getFullYear();
  		Tuoi=sYear-parseInt(objNgaySinh.value);
  		
  		if (Tuoi<18)
  		{	
  			alert("Người đăng ký kinh doanh dưới 18 tuổi!");
			obj.focus();
			return false;
  		}
	}else
	{
		CheckDateOnBlur(objNgaySinh);
	}
	return true;
	
}

//TruongTD update :chinh sua ngay hen tra

function AddDays(strNgay,iNum)

{

var strNgay,iNgay,iDem,iTong,pDate;

var Leap;

var daysOfYear = new Object(); 

iTong=iNum;

iDem=0;

var strYMD=formatDateForCompare(strNgay)

/////////////////////////////////////////////

var days,months,years;

years=strYMD.substring(0,4);

months=strYMD.substring(4,6);

days=strYMD.substring(6,8);

//kiểm tra năm nhuần

if (leapYear(years)==1) 

{ Leap=29;} 

else 

{ Leap=28;} 

//Định nghĩa số ngày của các thang 

daysOfYear[1] = 31; daysOfYear[2] = Leap; daysOfYear[3] = 31; daysOfYear[4] = 30; 

daysOfYear[5] = 31; daysOfYear[6] = 30; daysOfYear[7] = 31; daysOfYear[8] = 31; 

daysOfYear[9] = 30; daysOfYear[10] = 31; daysOfYear[11] = 30; daysOfYear[12] = 31; 

var iday,imonth,iyear;

iday=eval(days);

imonth=eval(months);

iyear=eval(years);

iday=iday+Number(iNum);


while(iday>daysOfYear[imonth])

{


if (imonth==12)

{


imonth=1;

iyear++;

iday=iday-daysOfYear[12];

}

else

{

imonth++;

iday=iday-daysOfYear[imonth-1];

} 

}

return ((iday<10) ? "0" : "") + iday + '/' + ((imonth<10) ? "0" : "") + imonth + '/' + iyear;

}

//TruongTD update:Ngay hen tra
/*
function GetNgayHenTra(objNgayNhan,strNgayNghiLe,objSoNgayGiaiQuyet)
{

	var strDate,strNgay;
	var days,months,years,strYMD;
	
	//strDate=AddDays(objNgayNhan.value,objSoNgayGiaiQuyet.value);
	strDate=objNgayNhan.value;
	var dem;
	strYMD=formatDateForCompare(strDate)
	years=strYMD.substring(0,4);
	months=strYMD.substring(4,6);
	days=strYMD.substring(6,8);
	var iday,imonth,iyear;
	iday=eval(days);
	imonth=eval(months-1);
	iyear=eval(years);
	strNgay=days+'/'+months;	
	var pDate;
	pDate=new Date(iyear,imonth,iday);
	//pDate=new Date(2006,12,26\);
	//alert(pDate.getDay());
	dem=0;
	while ((strNgayNghiLe.indexOf(strNgay)!=-1)||(pDate.getDay()==6)||(pDate.getDay()==0)||dem<objSoNgayGiaiQuyet.value-1)
		{
			if((strNgayNghiLe.indexOf(strNgay)==-1)&&(pDate.getDay()!=6)&&(pDate.getDate()!=0))
			{
			//alert(strDate);
				//	alert(pDate.getDay());
				//	alert(dem);
					strDate=AddDays(strDate,1);
					strYMD=formatDateForCompare(strDate)
					years=strYMD.substring(0,4);
					months=strYMD.substring(4,6);
					days=strYMD.substring(6,8);
					iday=eval(days);
					imonth=eval(months-1);
					iyear=eval(years);
					pDate=new Date(iyear,imonth,iday);
					strNgay=days+'/'+months;	
					dem++;
					
					continue;
			}
			
			if (strNgayNghiLe.indexOf(strNgay)!=-1)
				{
					strDate=AddDays(strDate,1);
					strYMD=formatDateForCompare(strDate)
					years=strYMD.substring(0,4);
					months=strYMD.substring(4,6);
					days=strYMD.substring(6,8);
					iday=eval(days);
					imonth=eval(months-1);
					iyear=eval(years);
					pDate=new Date(iyear,imonth,iday);
					strNgay=days+'/'+months;	
					continue;
					
				}
			if (pDate.getDay()==6)
				{
					strDate=AddDays(strDate,2);
					strYMD=formatDateForCompare(strDate)
					years=strYMD.substring(0,4);
					months=strYMD.substring(4,6);
					days=strYMD.substring(6,8);
					iday=eval(days);
					imonth=eval(months-1);
					iyear=eval(years);
					pDate=new Date(iyear,imonth,iday);
					strNgay=days+'/'+months;	
					continue;	
				}
				
			if (pDate.getDay()==0)
				{
					strDate=AddDays(strDate,0);
					strYMD=formatDateForCompare(strDate)
					years=strYMD.substring(0,4);
					months=strYMD.substring(4,6);
					days=strYMD.substring(6,8);
					iday=eval(days);
					imonth=eval(months-1);
					iyear=eval(years);
					pDate=new Date(iyear,imonth,iday);
					strNgay=days+'/'+months;	
					continue;
				}
				
		
		}
	return strDate;		
}
*/

function GetNgayHenTra(objNgayNhan,strNgayNghiLe,objSoNgayGiaiQuyet)
{

	var strDate,strNgay;
	var days,months,years,strYMD;
	
	//strDate=AddDays(objNgayNhan.value,objSoNgayGiaiQuyet.value);
	strDate=objNgayNhan.value;
	var dem;
	strYMD=formatDateForCompare(strDate)
	years=strYMD.substring(0,4);
	months=strYMD.substring(4,6);
	days=strYMD.substring(6,8);
	var iday,imonth,iyear;
	iday=eval(days);
	imonth=eval(months-1);
	iyear=eval(years);
	
	strNgay=days+'/'+months;	
	var pDate;
	pDate=new Date(iyear,imonth,iday);
	//pDate=new Date(2009,3,12);
	//alert(pDate.getDay());
	dem=0;	
	while ((strNgayNghiLe.indexOf(strNgay)!=-1)||(pDate.getDay()==0)||dem<objSoNgayGiaiQuyet.value-1)
		{
			
			if((strNgayNghiLe.indexOf(strNgay)==-1)&&(pDate.getDate()!=0))
			{					
					strDate=AddDays(strDate,1);																
					strYMD=formatDateForCompare(strDate)					
					years=strYMD.substring(0,4);
					months=strYMD.substring(4,6);
					days=strYMD.substring(6,8);
					iday=eval(days);
					imonth=eval(months-1);
					iyear=eval(years);
					pDate=new Date(iyear,imonth,iday);
					strNgay=days+'/'+months;	
					dem++;
					continue;					
			}		
			if (strNgayNghiLe.indexOf(strNgay)!=-1)
				{
					strDate=AddDays(strDate,1);
					strYMD=formatDateForCompare(strDate)
					years=strYMD.substring(0,4);
					months=strYMD.substring(4,6);
					days=strYMD.substring(6,8);
					iday=eval(days);
					imonth=eval(months-1);
					iyear=eval(years);
					pDate=new Date(iyear,imonth,iday);
					strNgay=days+'/'+months;								
					continue;						
				}			
				
			if (pDate.getDay()==0)
				{
					strDate=AddDays(strDate,1);
					strYMD=formatDateForCompare(strDate)
					years=strYMD.substring(0,4);
					months=strYMD.substring(4,6);
					days=strYMD.substring(6,8);
					iday=eval(days);
					imonth=eval(months-1);
					iyear=eval(years);
					pDate=new Date(iyear,imonth,iday);
					strNgay=days+'/'+months;										
					continue;	
				}											
		
		}
	return strDate;		
}