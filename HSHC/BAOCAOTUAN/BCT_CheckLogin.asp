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
	
	if strAction = "THOAT" then 
		Session.Abandon
		Response.Redirect("../Home.asp") 		
	end if
			
	if strAction <> "LO" then
		set rs=server.CreateObject("ADODB.recordset")  		  
		strSQL = "SELECT cast(u.password as varchar) password, u.MaBoPhan, u.UserID " &_
					"FROM commonBT..Users u JOIN BCT_PhanQuyen pq ON u.UserID=pq.UserID " &_
					"WHERE u.UserName = '"& strUserName & "'"
		rs.Open strSQL, conn
		if not rs.EOF then
			if strPassword = rs("Password") then
				Session("UserID")	= trim(rs("UserID"))
				Session("DeptID")	= trim(rs("MaBoPhan"))
				session("UserName")	= strUserName
				Response.Redirect("BCT_List.asp") 
				response.end
			else
				strError = "Sai mat khau, vui long nhap lai"
			end if
		else
			strError = "Sai ten nguoi truy cap, vui long nhap lai"
		end if
		rs.close
		Set rs = Nothing
	end if	
%>
                                                                                                                                                         
<%	
	Set conn = Nothing
%>                                  
<body bgcolor="white" topmargin="0" leftmargin="0" onload="Submit()">
<script language="javascript">
	function Submit(){
		frmMain.submit();
	}
</script>
<form action="Login.asp" method="POST" name="frmMain">
<input type="hidden" name="txtError" value="<%=strError%>">
</form>
</body>

</html>