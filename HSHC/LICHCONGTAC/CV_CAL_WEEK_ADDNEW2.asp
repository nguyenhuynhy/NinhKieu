<!--#include file = "security.asp"-->
<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta name="GENERATOR" content="Microsoft FrontPage 6.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Dang ky lich hop</title>
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
<script language="JavaScript" src="inc/Corescript.js"></script>	
<script language = "javascript" src="inc/common.js"></script>
<%
	dim strSQL
	dim rs
	dim conn
	
	SET conn = server.CreateObject("ADODB.Connection")
	conn.Open CONNECTION_STRING
	
	Set rsUser = Server.CreateObject("ADODB.Recordset")
	rsUser.CursorLocation = 3
	strSQL = "COMM_GetChairMan"
	rsUser.Open strSQL,Conn
	iCountUser = rsUser.RecordCount 
	
%>
<script language="javascript">
	var User  = new Array(2);
	User[0]   = new Array(<%=iCountUser%>);
	User[1]   = new Array(<%=iCountUser%>);	
	
	function startup(){		
		<%
		if not rsUser.EOF then
		i=0
		while not rsUser.EOF
		%>
			User[0][<%=i%>]='<%=rsUser("UserID")%>';			
			User[1][<%=i%>]='<%=rsUser("DefaultLocation")%>';				
		<%
		i=i+1
		rsUser.MoveNext
		wend
		end if
		Set rsUser=Nothing
		%>	
	}

	function openMemberJoin(){
		FileWindow = window.open('MemberJoin_List.asp','Recipient','toolbar=0,scrollbars=0, alwaysRaised=Yes, width=500, height=340,1 ,align=center');
		FileWindow.focus();
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
	
	function ChangeLocation()
	{
		if (frm.cboLocation.value != ''){			
			frm.txtLocation.value = frm.cboLocation.options(frm.cboLocation.selectedIndex).innerText
			frm.txtLocation.readOnly = true
		}else{			
			frm.txtLocation.readOnly = false;			
			frm.txtLocation.value = '';
		}
		
	}
	
	function ChangeChairMan()
	{	
		var i;
		var sLocation;
		
		frm.hChairMan.value = frm.cboChairMan.options(frm.cboChairMan.selectedIndex).innerText		
		
		//alert(frm.cboChairMan.value);
		
		if (frm.cboChairMan.selectedIndex == 0){
			frm.cboLocation.selectedIndex = 0
		}else{
			i=0
			while (i<<%=iCountUser%>){				
				if (User[0][i]== frm.cboChairMan.value){
					sLocation = User[1][i];
					break;
				}
				i++;
			}
		}
		if (sLocation!=''){
			for(i=0;i<frm.cboLocation.length;i++)
			{
				if(sLocation==frm.cboLocation.options[i].value){	
					frm.cboLocation.selectedIndex = i;				
					break;
				}
			}				
		}else{
			frm.cboLocation.selectedIndex = 0
		}
			ChangeLocation();
	}
	
	function Luu(){		
		if (Validate()){
			frm.action = 'CAL_WEEK_PROCESS.ASP';
			frm.hAction.value='CV_ADDNEW';
			frm.submit();
		}
	}	
	function Validate(){
		var intreturn; 
		if (frm.txtContent.value == ''){
			alert('Xin cho biet noi dung lich lam viec.');
			frm.txtContent.focus();
			return false;
		}
		/*if (frm.cboChairMan.value == ''){
			alert('Xin cho biet nguoi chu tri.');
			frm.cboChairMan.focus();
			return false;
		}
		*/
		if (frm.txtFromDate.value != '' && frm.txtToDate.value !=''){					
				intreturn = compareDates(frm.txtFromDate.value, frm.txtToDate.value);
				if (intreturn == 1)  
				{    			  
					alert ("Tu ngay phai nho hon den ngay.") ;     	
					frm.txtFromDate.focus();
					return false;    			  
				}  
				    
			}
		return true;
	}
	
	function CheckDate(obj){
		var intreturn; 
		
		if (obj.value == ''){
			alert ("Nhap vao khoang thoi gian can dang ky.") ;     	
			obj.focus();	
			return;		
		}else{
			if (isValidDate(obj.value)!=0){
				alert("Ngay " + obj.value + " khong hop le!");
				obj.focus();    
				return;  
			}
			
			if (frm.hMinDate.value != '' && obj.value !=''){
													
				//alert(frm.hMinDate.value)
				intreturn = 0;

				//var DayName = Days[today.getDay()]; 
				//if upper(DayName)=="Monday"
				//alert(new Date().getDay());
				if (new Date().getDay()!=1)
				{				
					intreturn = compareDates(frm.hMinDate.value, obj.value);
				}
				
				if (intreturn == 1)  
				{    			  
					alert ("Chi chap nhan dang ky lich cho tuan sau.") ;     	
					obj.focus();    			  
				}      
			}
		}		
	}
</script>
</head>
<%
	
	
	strAction	=	request("hAction")
	strBookID	=	trim(request("hBookID"))
	strSTT		= 1
	
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
<body background=Images/bg.gif topmargin=0 leftmargin=0 onload="javascript:startup();">
<center>
<form name="frm" method="POST">
<!--<input name="hChairMan" Type="text" value="">-->
<input name="hMemberJoin" Type="hidden" value="<%=strMemberJoinID%>">
<input name="hAction" Type="hidden" value="<%=strAction%>">
<input name="hChairMan" Type="hidden" value="<%=strChairMan%>">
<input type="hidden" name="hBack" value="<%=request("hBack")%>">  
<input type="hidden" name="hMinDate" value="<%=DateValueVN(DateValue(Now() + 7 - Weekday(Now() + 7) + 2 ))%>">
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
					<td class="QH_LabelLeft" width=*"><%call MakeCbo("cboType","SELECT * FROM BOOKTYPES WHERE SHOW='1' ORDER BY STT","UB","BookType_ID","BookType","396","0","enable")%></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">Từ ngày</td>
					<td class="QH_LabelLeft" width=*">
						<input type="text" size="15" class="QH_Textbox" name="txtFromDate" value="<%=DateValueVN(DateValue(Now() + 7 - Weekday(Now() + 7) + 2 ))%>" onblur="javascript:CheckDate(frm.txtFromDate);">&nbsp;
						Đến ngày&nbsp;<input size="15" type="text" class="QH_Textbox" name="txtToDate" value="<%=DateValueVN(DateValue(Now() + 7 - Weekday(Now() + 7) + 6))%>" onblur="javascript:CheckDate(frm.txtToDate);">&nbsp;&nbsp;
						Thời gian họp&nbsp;<input size="5" class="QH_TextRight" type="text" name="txtDuration" value="" size="2" onblur="javascript:checknum(frm.txtDuration)">&nbsp;( phút )
					</td>
				</tr>				
				<tr>
					<td class="QH_ColLabel" width="25%" valign="top" align="right">Nội dung <font size="2" color="red">(*)</font></td>
					<td class="QH_LabelLeft" width=*"><textarea name="txtContent" rows="4" cols="75" class="QH_textbox"><%=strContent%></textarea></td>
				</tr>	
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">
						Người chủ trì</td>
					<td class="QH_LabelLeft" width=*"><%call MakeCbo("cboChairMan","COMM_GetChairMan",strChairManID,"UserID","FullName","200","1"," onchange='javascript:ChangeChairMan();'")%>
					<input type = "checkbox" value="false" <%=chkNgoaiLich%> name="chkNgoaiLich" ID="Checkbox1">Ngoài lịch</td>
				</tr>
				<tr>
					<td  class="QH_ColLabel" width="25%" align="right">Địa điểm</td>
					<td class="QH_LabelLeft" width=*"><%call MakeCbo("cboLocation","COMM_GetLocation",strLocationID,"ID","LocationName","200","0"," onchange='javascript:ChangeLocation();'")%>
					&nbsp;<input class="QH_Textbox" type="text" name="txtLocation" maxlength="1000" size="32" value="<%=strLocation%>"></td>
				</tr>				
				<tr>
					<td class="QH_ColLabel" width="25%" align="right"><a href="javascript:openMemberJoin();">Thành phần tham dự</a></td>
					<td class="QH_LabelLeft" width=*"><textarea class="QH_Textbox" name="txtMemberJoin" rows="4" cols="75"><%=strMemberJoin%></textarea></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right">Chuẩn bị</td>
					<td class="QH_LabelLeft" width=*"><textarea class="QH_Textbox" name="txtNote" rows="4" cols="75"><%=strNote%></textarea></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" width="25%" align="right"></td>
					<td width=*" class="QH_LabelLeft">
					<input type="hidden" name="txtStt" maxlength="2" size="15" class="QH_Textbox"  value="<%=strSTT%>" ID="Text1">
				</tr>
			
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
<%
	set conn=nothing
	set rsUser=nothing
	set rs=nothing
%>
<!--#include file = "IncEndSub.asp"-->
<%
	sub MakeComboGio(p_Name, p_value)
		Response.Write "<SELECT Name='" & p_Name & "'>"
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
		Response.Write "<SELECT Name='" & p_Name & "'>"		
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
	 <table cellpadding="0" cellspacing="2" width="100%">
		<tr valign="absmiddle">			
			<!--<td width="20%" class="QH_Label" valign="absmiddle"><a href="javascript:location.href='../Home.asp';" ><img alt="Tro ve trang chu" src="images/home.gif" border="0" align="absmiddle">&nbsp;Trang chủ</a></td>-->
			<td width="20%" class="QH_Label" valign="absmiddle"><a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a></td>
			<td width="20%" class="QH_Label" valign="absmiddle"><a href="javascript:Luu();"><img alt="Luu lich lam viec" src="images/save.gif" border="0" align="absmiddle">&nbsp;Lưu</a></td>			
			<td width="*">&nbsp;</td>
		</tr>
	</table>
<%END sub%>