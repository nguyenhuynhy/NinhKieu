<!--
/* ham tra ve gia tri lam tron so thap phan vd : 20.45 -> 20.5 */
function trim(str) {
	str = str.replace (/^\s+/g, "");
	str = str.replace (/\s+$/g, "");
	return str;
}


function RoundNumber(nTemp){
	if (nTemp.indexOf('.')>=0) {
		t = nTemp.substr(0, nTemp.indexOf('.'));
		t1 = nTemp.substr(nTemp.indexOf('.')+1, nTemp.length - nTemp.indexOf('.'));
		t1 = parseFloat(t1.charAt(0)+'.'+ t1.substr(1, t1.length - 1));
		t1 = Math.round(t1);
		if (t1==10) {
			t=parseInt(t)+1;
			t1=0;
		}	
		if (t1==0) return t;
		else return t+'.'+t1;
	}
	else return nTemp;
}

/* ham kiem tra tinh hop le cua ngay thang */
function isSmaller(fMonth,fYear,tMonth,tYear)
	{
		if (fYear*12+fMonth<=tYear*12+tMonth)
			return true; 
		else
			return false;
	}
/* ham kiem tra gia tri truyen vao la chuoi rong hay khong */
	function isBlank(s){
		var temp = s;
		temp = trim(temp);
		
		if (temp=="") {
			return true;
		}
		return false;
	}		
/* ham check 1 so nhap vao tu 0-24, neu sai thi bao loi va dat gia tri = 0 lai */
function CheckNumber(objText){
	if ((!(isBlank(objText.value))&&!(objText.value-0)&& (objText.value!='0'))||(objText.value < 0)||(objText.value>24)) {
		alert('Number between 0 and 24, please enter again!');
		objText.value='';
		objText.focus();
		return false;
	}		
	else{
		if (parseInt(objText.value)>24){
			alert('Number between 0 and 24, please enter again!');
			objText.value='';
			objText.focus();
			return false;
		}
	}
	return true;
}

/* ham check 1 so nhap vao la so */
function ValidateNumber(objText){
	if ((!(isBlank(objText.value))&&!(objText.value-0)&& (objText.value!='0'))||(objText.value < 0)) {
		alert('Invalid number input, please enter again!');
		objText.value='';
		objText.focus();
		return false;
	}
	return true;
}

function SetImageOver(obj)
{
	obj.src=obj.src.replace(/\.jpg/g,"_Over.jpg")
}

function SetImageOut(obj)
{
	obj.src=obj.src.replace(/_Over\.jpg/g,".jpg")
}

var bNetscape4     = (navigator.appName == "Netscape" && navigator.appVersion.substring(0,1) == "4");
var bNetscape6     = (navigator.appName == "Netscape" && navigator.appVersion.substring(0,1) >= "5");
var bExplorer4plus = (navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.substring(0,1) >= "4");
var bExplorer5plus = (navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.substring(0,1) >= "5");
var bOpera5        = (navigator.appName == "Opera" && navigator.appVersion.substring(0,1) >= "5" );

function dquo()
{
  return '"';
}

function squo()
{
  return "'";
}

function getLayer(sName)
{
  var layer;
  if ( bNetscape4 ) layer=document[sName];
  else if ( bExplorer4plus ) eval('layer=window.'+sName);
  else if ( bNetscape6 || bOpera5 ) layer = document.getElementById(sName);
  return layer;
}

function showLayer(sName)
{
  var layer;
  layer=getLayer(sName);
  layer.style.visibility="visible";
}

function hideLayer(sName)
{
  var layer;
  layer=getLayer(sName);
  layer.style.visibility="hidden";
}

function addCookie(sName,sValue)
{
  document.cookie =sName + "=" + escape(sValue) + ";path=/;";
}

function getCookie(sName)
{
  // cookies are separated by semicolons
  var aCookie = document.cookie.split(";");
  for (var i=0; i < aCookie.length; i++)
  {
    // a name/value pair (a crumb) is separated by an equal sign
    var aCrumb = aCookie[i].split("=");
	var st;
	if (i>0) st=aCrumb[0].substr(1); else st=aCrumb[0];
    if (sName == st) return unescape(aCrumb[1]);
  }
  // a cookie with the requested name does not exist
  return null;
}


function fixStringSize(st,size)
{
  if (st.length>size) return (st.substr(0,size-3)+"...")
  else return st;
}

function getFormElement(sName)
{
  var i,j,colForm,oForm,oElement;
  colForm=document.forms;
  for (i=0;i<colForm.length;i++)
  {
    oForm=colForm[i];
    for (j=0;j<oForm.length;j++)
    {
      oElement=oForm[j];
      if (oElement.name==sName) return oElement;
    }
  }
}

///////////////// function open new window de insert task trong HS Basis
function OpenTask(){
		var option,newwindow;		    
		option="toolbar=0, align=center, status=0,menubar=0,scrollbars=0,resizable=0,width=400,height=210,titlebar=0,location=0";
		newwindow=window.open("Task_Insert.asp","",option);
}
//-->
