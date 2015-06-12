<!-- #include file = "INC/Lib.asp" -->
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="stylesheet" type="text/css" href="INC/SSV.css">
<script language = "javascript">
	function redirectPage(varPage){
		location.href = varPage;
	}
</script>	
</head>

<%
	Session.CodePage = 65001  		
	set conn = server.createObject("ADODB.connection")			  
	conn.open CONNECTION_STRING  
	
	
	'------------------------ Login ---------------------------
	
	strUserName = replace(request.form("txtUsername"),"'","''")	
	strPassword = request.form("txtPassword")		
	strAction = trim(Request("hAction"))
	
	'strWhichOne = Request.Form("WhichOne")
	'strActType = Request.Form("ActType")
	
	'Response.Write(strUserName & "<p>")
	'Response.Write(strPassword & "<p>")
	'Response.Write("strAction = " &  strAction)
	'Response.End
	'if strAction = "CP" then Response.Redirect("COMM_ChangePassword.asp") end if
	
	if strAction = "THOAT" then 
		Session.Abandon
		Response.Redirect("../Home.asp") 		
	end if
			
	if strAction <> "LO" then
		set rs=server.CreateObject("ADODB.recordset")  		  
		strSQL = "Comm_Login"  
		strSQL = strSQL & " '" & strUserName & "','" & strPassword & "'"
		'Response.Write strSQL
		'Response.End
		rs.Open strSQL, conn  		
		if not rs.BOF and not rs.EOF then			
			if rs("Result") = "0" then
				Result = rs("Result") 				
				strSQL = "Comm_GetUserID"
				strSQL = strSQL & " '" & strUserName & "','" & strPassword & "'"										
				
				'Response.Write strSQL
				'Response.End
				
				set rs = conn.execute(strSQL)					
				if not rs.BOF and not rs.EOF then
					Session("UserID")	= trim(rs("UserID"))
					'Session("DepID")	= trim(rs("Dep_ID"))
					'Session("DepName")	= trim(rs("Dept_Name"))												
					Session("UserName") = trim(rs("UserName"))
					Session("FullName") = trim(rs("FullName"))
					Session("Role")		= trim(rs("MaVaiTro"))		
						
					'strUserID	= Session("UserID")
					'strDeptID	= Session("DepID")
					'strUserName = Session("UserName")
					'strFullName	= Session("FullName")
					'strRole		= Session("Role")
					'strDepName	= Session("DepName")
					
				end if
			else
				Call DisplayError(rs("Result")) 
			end if
		
			if Result = "0" then Response.Redirect "CAL_WEEK_APPROVED.asp" end if
		end if
	
		
	
	else
		call Logout
	end if	
		
%>
                                                                                                                                                         
<%	                                                                                                                                                             
	
	'Set rs = Nothing                                                                                                                                                             
	Set conn = Nothing                                                                                                                                                             
%>                                  
<body bgcolor="white" topmargin="0" leftmargin="0">

</body>

</html>
<%Sub DisplayError(errorID)
	Response.Redirect "Result.asp?ErrID=" & errorID
end sub
%>