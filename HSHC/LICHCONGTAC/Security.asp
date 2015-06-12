<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>

<%
	'If not request.QueryString("UID") is nothing then
	'	Session("UserID")=request.QueryString("UID")	
	'	Response.Write(Session("UserID"))
	'	response.end
	'else
	'	Response.Write("nothing")
	'	response.end
	'end if
	''''''''''''''''''''''''''''''''''''''''''''
	IF Session("UserID") = "" then 	
		Response.Redirect "Result.asp?ErrID=0"		
	else
		IF Check_UserRight(Session("UserID")) = 1 then
			Response.Redirect "Result.asp?ErrID=4"
		end if
	end if
%>
<%
	function Check_UserRight(p_UserID)
		dim conn
		dim rs
		dim strSQL
		dim arrPath
		
		arrPath = split(Request.ServerVariables("PATH_INFO"),"/")
				
		set conn = server.CreateObject("ADODB.Connection")
		set rs = server.CreateObject("ADODB.Recordset")
		
		conn.Open CONNECTION_STRING

		strSQL = "CheckAccessRight "
		strSQL = strSQL & "@UserID = '" & p_UserID & "',"
		strSQL = strSQL & "@TenTrang = '" & arrPath(UBound(arrPath)) & "'"
		
		set rs=conn.Execute(strSQL)
		
		if rs.eof then

			Check_UserRight = 1
		else

			Check_UserRight = 0 'thanh cong
		end if
		
		set rs = nothing
		set conn = nothing
	end function
%>