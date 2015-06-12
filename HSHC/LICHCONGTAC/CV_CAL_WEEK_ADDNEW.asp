<!--#include file = "security.asp"-->
<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Dang ky lich hop</title>
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
<script language="JavaScript" src="inc/Corescript.js"></script>	
<script language = "javascript" src="inc/common.js"></script>
<script language="javascript">
	function openMemberJoin(){
		FileWindow = window.open('MemberJoin_List.asp','Recipient','toolbar=0,scrollbars=1, alwaysRaised=Yes, width=500, height=340,1 ,align=center');
		FileWindow.focus();
	}
	function ChangeLocation()
	{
		if (frm.cboLocation.value != ''){
			//frm.hLocation.value = frm.cboLocation.value;		
			frm.txtLocation.value = frm.cboLocation.options(frm.cboLocation.selectedIndex).innerText
			frm.txtLocation.readOnly = true
		}else{			
			frm.txtLocation.readOnly = false;
			//frm.hLocation.value = '';
			frm.txtLocation.value = '';
		}
		
	}
	
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
	
	function CheckNgayHop(){
		if (frm.txtMeetingDate.value == ''){
			alert ("Nhap vao ngay lam viec.") ;     	
			frm.txtMeetingDate.focus();	
			return;		
		}else{
			if (isValidDate(frm.txtMeetingDate.value)!=0){
				alert("Ngay " + frm.txtMeetingDate.value + " khong hop le!");
				frm.txtMeetingDate.focus();    
				return;  
			}
		}
		
		if (frm.hAction.value != 'approved_update'){ //Truong hop CVP cap nhat thi o kiem tra ngay hop la tuan sau
			if (frm.hMinDate.value != '' && frm.txtMeetingDate.value !=''){					
				
				intreturn == 0;
				//var DayName = Days[today.getDay()]; 
				//if upper(DayName)=="Monday"
				if (Weekday(now())!=1)
				{
				intreturn = compareDates(frm.hMinDate.value, frm.txtMeetingDate.value)  
				}	
				
				if (intreturn == 1)  
				{    			  
					alert ("Chi chap nhan dang ky lich cho tuan sau.") ;     	
					frm.txtMeetingDate.focus();    			  
				}      
			}	
		}
	}
	function ChangeChairMan()
	{	
		frm.hChairMan.value = frm.cboChairMan.options(frm.cboChairMan.selectedIndex).innerText		
	}
	
	function Luu(){		
		if (Validate()){
			frm.action = 'CAL_WEEK_PROCESS.ASP';
			frm.submit();
		}
	}
	
	/*function ChangeType()
	{		
		if (frm.cboType.value=='DT'){	
			//frm.cboChucTho.checked = false
			//frm.cboChucTho.disabled = false
		}
		else{			
			//frm.cboChucTho.checked = false
			//frm.cboChucTho.disabled = true
		}
		ChucThoChange()
	}*/
	/*function ChucThoChange()
	{
		if (frm.cboChucTho.checked){
			frm.cboHour.disabled = true
			frm.cboMinute.disabled = true
			frm.cboLocation.disabled = true
			frm.txtLocation.disabled = true
			frm.cboChairMan.disabled = true
			frm.txtNote.disabled = true
			frm.txtMemberJoin.disabled = true			
		}else{
			frm.cboHour.disabled = false
			frm.cboMinute.disabled = false
			frm.cboLocation.disabled = false
			frm.txtLocation.disabled = false
			frm.cboChairMan.disabled = false
			frm.txtNote.disabled = false
			frm.txtMemberJoin.disabled = false
		}		
	}*/
	function Validate(){
		if (frm.txtContent.value == ''){
			alert('Xin cho biet noi dung lich lam viec.');
			frm.txtContent.focus();
			return false;
		}
		return true;
	}
</script>
</head>
<%
	dim strSQL
	dim rs
	dim conn
	
	SET conn = server.CreateObject("ADODB.Connection")
	conn.Open CONNECTION_STRING
	
	strAction	=	request("hAction")
	strBookID	=	trim(request("hBookID"))
	
	if strBookID = "" then 'AddNew		
		strBookDate	=	request("hAddnewDate")
		strType		=	request("hAddnewType")	
		strGio		=	8
	else 'Edit
		strBookID	= request("hBookID")
		
		set rs = server.CreateObject("ADODB.Recordset")
		
		strSQL = "Book_Get @p_BookID = '" & strBookID & "'"
		
		'Response.Write strSQL
		'Response.End
		rs.CursorLocation=3
		rs.Open strSQL, conn
		
		if not rs.EOF then
			strBookID		= rs("Book_ID")			
			strType			= rs("Type")
			strBookDate		= rs("MDate")
			strGio			= rs("Gio")
			strPhut			= rs("Phut")
			strContent		= rs("Content")
			strLocationID	= rs("LocationID")
			strLocation		= rs("Location")
			strChairManID	= rs("ChairManID")
			strChairMan		= rs("ChairMan")
			strMemberJoinID	= rs("Dep_ID")
			strMemberJoin	= rs("JoinMember")
			strNote			= rs("Note")
			strDuration		= rs("Duration")
			strNgoaiLich	= rs("NgoaiLich")
			if strNgoaiLich = "1" then
				chkNgoaiLich = "Checked"
			else
				chkNgoaiLich = ""
			end if 
			strSTT			= rs("Stt")
			if rs("ChucTho")="Y" then strCongViec = "checked" else strCongViec = "" end if
		end if
	end if
%>
<!--#include file = "IncBeginSub.asp"-->
<body background=Images/bg.gif topmargin=0 leftmargin=0>
<center>
<form name="frm" method="POST">
<!--<input name="hChairMan" Type="text" value="">-->
<input name="hMemberJoin" Type="hidden" value="<%=strMemberJoinID%>">
<input name="hQuery" Type="hidden" value="<%=request("hQuery")%>">
<input name="hBookID" Type="hidden" value="<%=strBookID%>">
<input name="hAction" Type="hidden" value="<%=strAction%>">
<input name="hChairMan" Type="hidden" value="<%=strChairMan%>">
<input type="hidden" name="hBack" value="<%=request("hBack")%>"> 
<input type="hidden" name="hMinDate" value="<%=DateValueVN(Now() + 7 - Weekday(Now() + 7) + 2 )%>"> 
<table border="0" cellspacing="0" style="border-collapse: collapse" width="100%">  
<tr>
	<td><img src="images\Text_DangKyLichLamViec.gif" border="0"></td>
</tr>
<tr>
	<td align="center">
	<table cellspacing="1" width="100%">  
	  <tr>
  			<td><%call showToolBar()%></td>
		</tr>
	  <tr>
	    <td width="100%">
			<table cellspacing="1" width="100%">
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">Lịch làm việc của</td>
					<td width=*" class="QH_LabelLeft"><%call MakeCbo("cboType","SELECT * FROM BOOKTYPES WHERE SHOW='1' ORDER BY STT","UB","BookType_ID","BookType","396","0"," anable")%></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">Ngày họp</td>
					<td width=*" class="QH_LabelLeft"><input type="text" name="txtMeetingDate" size="16" class="QH_Textbox" value="<%=strBookDate%>" onblur="javascript:CheckNgayHop();">&nbsp;&nbsp;
					Giờ bắt đầu&nbsp;<%call MakeComboGio("cboHour",strGio)%>&nbsp;<%call MakeComboPhut("cboMinute",strPhut)%>&nbsp;&nbsp;
					&nbsp;Thời gian họp&nbsp;<input type="text" class="QH_Textbox" name="txtDuration" value="<%=strDuration%>" size="6" onblur="javascript:checknum(frm.txtDuration)">&nbsp;( phút )
					</td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" valign="top" align="right">Nội dung <font size="2" color="red">(*)</font></td>
					<td width=*" class="QH_LabelLeft"><textarea name="txtContent" rows="4" cols="75" class="QH_Textbox"><%=strContent%></textarea></td>
				</tr>				
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">
						<!--<a href="javascript:openNguoiChuTri();">-->Người chủ trì<!--</a>--></td>
					<td width=*" class="QH_LabelLeft"><%call MakeCbo("cboChairMan","COMM_GetChairMan",strChairManID,"UserID","FullName","200","1"," onchange='javascript:ChangeChairMan();'")%>
					<input type = "checkbox" value="false" <%=chkNgoaiLich%> name="chkNgoaiLich" ID="Checkbox1">Ngoài lịch</td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">Địa điểm</td>
					<td width=*" class="QH_LabelLeft"><%call MakeCbo("cboLocation","COMM_GetLocation",strLocationID,"ID","LocationName","200","0"," onchange='javascript:ChangeLocation();'")%>
					&nbsp;<input type="text" name="txtLocation" maxlength="1000" size="32" class="QH_Textbox" value="<%=strLocation%>"></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right"><a href="javascript:openMemberJoin();">Thành phần tham dự</a></td>
					<td width=*" class="QH_LabelLeft"><Textarea name="txtMemberJoin" maxlength="1000" Cols="75" rows="4" class="QH_Textbox"><%=strMemberJoin%></Textarea></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">Chuẩn bị</td>
					<td width=*" class="QH_LabelLeft"><textarea name="txtNote" rows="4" cols="75" class="QH_Textbox"><%=strNote%></textarea></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right"></td>
					<td width=*" class="QH_LabelLeft">
					<input Type="hidden" name="txtStt" maxlength="2" size="15" class="QH_Textbox"  value="<%=strSTT%>" ID="Text1">
				</tr>
			
				<!--<tr>
					<td align="center" colspan="2"><a href="javascript:Luu();"><img src="images\button_Luu.jpg" border="0"></a>&nbsp;&nbsp;
						<a href="javascript:history.back(-1);"><img src="images\button_TroVe.jpg" border="0"></a>
					</td>
				</tr>-->
				
			</table>
	    </td>
	  </tr>
	  <tr>
		<td><br><%call showToolBar()%></td>
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
	sub MakeComboGio(p_Name, p_value)
		Response.Write "<SELECT class='QH_DropdownList' Name='" & p_Name & "'>"
		'Response.Write "<option value='' selected>--</option>"
		FOR i=0 to 23 
			if i = p_value then
				Response.Write "<option value='" & i & "' selected>" & i & "</option>"
			else
				Response.Write "<option value='" & i & "'>" & i & "</option>"
			end if
		next
		Response.Write "</SELECT>"
	End sub
	

	sub MakeComboPhut(p_Name, p_value)
		Response.Write "<SELECT class='QH_DropdownList' Name='" & p_Name & "'>"		
		FOR i=0 to 11 
			if 5*i = p_value then
				Response.Write "<option value='" & i*5 & "' selected>" &  right("0" & (i* 5),2) & "</option>"
			else
				Response.Write "<option value='" & i*5 & "'>" & right("0" & (i*5),2) & "</option>"
			end if
		next
		Response.Write "</SELECT>"
	End sub	
	
%>
<%sub ShowToolBar()%>
	 <table border="0" cellpadding="0" cellspacing="2" width="100%">
		<tr valign="absmiddle">			
			<!--<td width="20%" class="QH_Label" valign="absmiddle"><a href="javascript:location.href='../Home.asp';" ><img alt="Tro ve trang chu" src="images/home.gif" border="0" align="absmiddle">&nbsp;Trang chủ</a></td>-->
			<td width="20%" class="QH_Label" valign="absmiddle"><a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a></td>
			<td width="20%" class="QH_Label" valign="absmiddle"><a href="javascript:Luu();"><img alt="Luu lich lam viec" src="images/save.gif" border="0" align="absmiddle">&nbsp;Lưu</a></td>			
			<td width="*" class="QH_Label">&nbsp;</td>
		</tr>
	</table>
<%END sub%>

