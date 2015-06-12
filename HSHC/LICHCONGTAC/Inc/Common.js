var iCounter = 0

/****************************************************************************************
* Trong File Common.js chua tat ca cac Main Function sau day:
* 1. isBlank(obj)
*		Kiem tra du lieu la Null thi se return True
* 2. CheckDate(obj)
*		Kiem tra du lieu kieu ngay theo dang dd/mm/yyyy
* 3. FromSmallToDate(objFromDate,objToDate)
*		Du lieu Ngay1 phai nho hon du lieu Ngay2
* 4. DispDate(obj)
*		Hien thi calendar de chon ngay thang nam
* 5. isWeb(obj)
*		Kiem tra du lieu nhap co phai dia chi WebSite (http://www.yahoo.com)
* 6. isEmail(obj)
*		Kiem tra du lieu la Dia chi Email (FSOFT@yahoo.com)
*----------------------------------------------------------------------------------------
* Ngoai ra co cac function phu sau day:
* 1. isValidDate(strDate)
* 2. IsSmaller(inputStr1, inputStr2)
*****************************************************************************************/

//--------------------------------------------
// Them hang nay vao Code HTML
// <script language="JavaScript" src="Common.js"></script>
//--------------------------------------------

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
			alert("Ngay " + obj.value + " khong hop le!");    
			obj.focus();
			return;    
		}    
	}    
}    

/*********************************************
*****  Fromdate < ToDate return True    ******
**  Duoc Call boi function FromSmallToDate ***
*********************************************/
function IsSmaller(inputStr1, inputStr2)
{
	var delim1 = inputStr1.indexOf("/")
	var delim2 = inputStr1.lastIndexOf("/")
	
	// lay ngay, thang, nam cua ngay1
	var dd1 = parseInt(inputStr1.substring(0,delim1),10)
	var mm1 = parseInt(inputStr1.substring(delim1 + 1,delim2),10)
	var yyyy1 = parseInt(inputStr1.substring(delim2 + 1,inputStr1.length),10)

	delim1 = inputStr2.indexOf("/")
	delim2 = inputStr2.lastIndexOf("/")

	// lay ngay, thang, nam cua ngay2
	dd2 = parseInt(inputStr2.substring(0,delim1),10)
	mm2 = parseInt(inputStr2.substring(delim1 + 1,delim2),10)
	yyyy2 = parseInt(inputStr2.substring(delim2 + 1,inputStr2.length),10)

	// ngay1 nho hon ngay 2 ?
	if (yyyy2 >= yyyy1)
	{
		if (mm2 == mm1) 
			if (dd2 >= dd1) return true;
			else return false;
		else
			if (mm2 > mm1) return true;
			else return false;
	}
	else
		return false;
}
/******************************************
**** Kiem tra tu ngay nho hon Den ngay ****
**** objFromDate : Thanh phan cua form ****
**** objToDate : Thanh phan cua form   ****
******************************************/
function FromSmallToDate(objFromDate,objToDate)
{
	FromDate = objFromDate.value
	ToDate = objToDate.value
	if ((!isBlank(FromDate)) && (!isBlank(ToDate)))
	{ 
		if  (!IsSmaller(FromDate, ToDate)) 
		{
			alert("Tu ngay phai nho hon den ngay");
			objToDate.focus()
			return false;
		}
		else
			return true;
	}
	else
		return true;
}
function fnConvertDateVN_EN(strDate){
	arr = strDate.split("/");
	strDate = arr[1] + "/"  + arr[0] + "/" + arr[2] ;
	return strDate;
}

/*******************************************
******          CALENDAR             *******
******  File dinh kem Cal_Dialog.asp *******
*******************************************/

var oDialog = "Cal_Dialog.asp";  // Passes URL and filename of dialog box as a variable
var bDialogStatus = false;     // Indicates whether modeless dialog box is currently open
var sDate=""; 
var oSelected = ""

function DispDate(obj){
	sDate = obj.value;
	oSelected = obj
	window.showModalDialog(oDialog, window , "dialogHeight: 260px; dialogWidth: 200px;  center: Yes; help: No; resizable: No; status: No; scroll = no");
}

var oDialog2 = "Cal_Dialog2.asp";  // Passes URL and filename of dialog box as a variable

function DispDate2(obj){
	sDate = obj.value;
	oSelected = obj
	window.showModalDialog(oDialog2, window , "dialogHeight: 260px; dialogWidth: 200px;  center: Yes; help: No; resizable: No; status: No; scroll = no");
}

function fnUpdate()
{  
	oSelected.value = sDate;
	//document.checkform.SelectDay.value = fnConvertDateVN_EN(sDate)
	//document.checkform.submit();
}

function fnUpdate2()
{  
	oSelected.value = sDate;
	document.checkform.SelectDay.value = fnConvertDateVN_EN(sDate)
	document.checkform.submit();
}
/*******************************************
***** Kiem tra Dia Chi WebSite hop le ******
***** Co dang http://www.yahoo.com    ******
*******************************************/
function isWeb(obj)
{	
	if (!isBlank(obj))
	{
		var strweb=obj.value;
		if ((strweb.indexOf("http://") == -1) || strweb.indexOf(".") == -1)
		{
			alert("Vui long nhap ten Website hop le");
			obj.focus();
			return false;
		}
		else
		{
			return true;
		}
	}
	else
	{
		return true;
	}
}
/**************************************
***** Kiem tra dia chi Email hop le ***
***** Co dang FSOFT@yahoo.com       ***
**************************************/
function isEmail(obj)
{
	if (!isBlank(obj))
	{
		var str=obj.value;
		if ((str.indexOf('@', 0) == -1) || (str.indexOf('.') == -1)|| str.length<5)
		{
			alert("Vui long nhap Email hop le");
			obj.focus();
			return false;
		}
		else
		{
			return true;
		}
	}
	else
	{
		return true;
	}
}
/*************************************************
*******  Kiem tra du lieu kieu so ****************
**************************************************/
function checknum(obj)
{
	if (isNaN(obj.value))
	{
		alert('Nhap vao du lieu kieu so');
		obj.focus();
	}
}

/************************************************
***** Ham xu ly cho button Soan moi cong van ****
*************************************************/
function AddNewCVDi(strUserRole){
	if (strUserRole == 'VT') {location.href = 'VT_CVDIAddNew.asp'};
	if (strUserRole == 'CV') {location.href = 'CV_CVDIAddNew.asp'};
}

/*********************************************
***** Ham xu ly cho button Hieu chinh cong van di ***
**********************************************/
function EditCVDi(iRec){
	var bCont = false;
	if (iRec > 0) {
		if (iRec!= 1){
			for (i=0;i<=iRec -1;i++){				
				if (frm.chkID[i].checked){
					frm.hID.value = frm.chkID[i].value;
					bCont = true;
					break;
				}
			}
		}
		else{
			if (frm.chkID.checked) {
				bCont = true;
				frm.hID.value = frm.chkID.value;
			}			
		}
	}
	else{
		bCont = true
	}
	if(!bCont){
		alert('Xin chon mau tin can hieu chinh')
	}else{
		frm.action = 'CV_CVDiEdit.asp';
		frm.hAction.value = 'EDIT';
		frm.submit();
	}	
}

/*********************************************
***** Ham xu ly cho button Xoa cong van di ***
**********************************************/
function DeleteCVDi(iRec){
	var bCont = false;
	var IDlist='';
	if (iRec > 0) {
		if (iRec!= 1){
			for (i=0;i<=iRec -1;i++){				
				if (frm.chkID[i].checked){
					bCont = true;
					IDlist += frm.chkID[i].value + ",";
				}
			}
		}
		else{
			if (frm.chkID.checked) {
				bCont = true;
				IDlist += frm.chkID.value + ",";
			}			
		};
		IDlist = IDlist.substring(0,IDlist.length-1);
	}
	else{
		bCont = true
	}	
	if(!bCont){
		alert('Xin chon mau tin can xoa')
	}else if(confirm('Ban that su muon xoa ?')){
		frm.action = 'Comm_CVDiProcess.asp';
		frm.hAction.value = 'DELETE';
		frm.hID.value = IDlist;
		frm.submit();
	}	
}

/*********************************************
***** Ham xu ly cho button Thay doi tinh trang CVDi ***
**********************************************/
function ChangeStatus(iRec,NextStatusID){
	var bCont = false;
	var IDlist='';	
	if (iRec > 0) {
		if (iRec!= 1){
			for (i=0;i<=iRec -1;i++){				
				if (frm.chkID[i].checked){
					IDlist += frm.chkID[i].value + ",";
					bCont = true;
				}						
			}
		}
		else{
			if (frm.chkID.checked) {
				bCont = true;
				IDlist += frm.chkID.value + ",";
			}
		};
		IDlist = IDlist.substring(0,IDlist.length-1);
	}
	else{
		bCont = true
	}	
	
	if(!bCont){
		alert('Xin chon mau tin can chuyen tinh trang')
	}else if(confirm('Ban that su muon chuyen tinh trang?')){
		frm.action = 'Comm_CVDIChangeStatus.asp';
		frm.hAction.value = "CHANGESTATUS";
		frm.hNextStatusID.value = NextStatusID;		
		frm.hID.value = IDlist;
		frm.submit();
	}
}


function SetChecked(val) {
	len = frm.elements.length;
	var i=0;
	for( i=0 ; i<len ; i++) {
		if (frm.elements[i].name=='chkID') {
		//alert (len);
			frm.elements[i].checked=val;
		}
	}
}

function ShowDate(dt){
	var month,day,year;
   	month = dt.getMonth()+1;
   	day = dt.getDate();
   	year = dt.getFullYear();

   	if (month < 10) month = "0" + month;
   	if (day < 10) day = "0" + day;

   	return day + "/" + month + "/" + year;
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

function checkCheckBox(chkObj){
	var retValue = 0;
	if(chkObj){
		if(!chkObj.length){
			if(chkObj.checked){
				retValue = 1;	
			}	
		}else{
			for(var i = 0;i<chkObj.length;i++){
				if(chkObj[i].checked){
					retValue = 1;
					break;
				}
			}
		}
	}else{
		retValue = -1;
	}
	return retValue;
}

function clearForm(formObj){

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

function retCV_Main(){
	location.href = 'CV_Main.asp';
}

function retHome(){
	location.href = 'Home.asp';
}


function checkObject(chkObj){
	var retValue = 0;
	if(chkObj){
		if(!chkObj.length){
			if(chkObj.checked){
				retValue = 1;	
			}	
		}else{
			for(var i = 0;i<chkObj.length;i++){
				if(chkObj[i].checked){
					retValue = 1;
					break;
				}
			}
		}
	}else{
		retValue = -1;
	}
	return retValue;
}

function choice(chkObj){
	if(iCounter%2 == 0){
		sSelected = true
	}else{
		sSelected = false
	}	 
	iCounter = iCounter + 1
	
	if(chkObj){
		if(!chkObj.length){
			chkObj.checked = sSelected	
		}else{
			for(var i = 0;i<chkObj.length;i++){
				chkObj[i].checked = sSelected
			}
		}
	}	
}
function formatDateForCompare(datestr) {
 	//var datefmt = platform.document.GLOBAL.DATE_FORMAT.value;    // DATE_FORMAT
	//var datesep = platform.document.GLOBAL.DATE_SEPERATOR.value;    // DATE_SEPERATOR
	var datefmt ='dd/MM/yyyy'
	var datesep ='/'
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

	
	datefmt.replace(datesep, '/')  		
  	datefmt = Trim(datefmt);
  	
  	var sMonth = '';
  	var sDay = '';
  	var sYear = '';
   	
  	if ((datefmt == 'MM/dd/yyyy') || (datefmt == 'M/d/yy') || (datefmt == 'MM/dd/yy') || (datefmt == 'M/d/yyyy')) {
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

function compareDates(date1, date2){
	if (parseInt(formatDateForCompare(date1)) > parseInt(formatDateForCompare(date2))) {
		return 1;
	}else if(parseInt(formatDateForCompare(date1)) == parseInt(formatDateForCompare(date2))) {
  		return 0;
  	}else {
  		return -1;
  	}
}