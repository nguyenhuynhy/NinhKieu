<!--#include file = "inc/lib.asp" -->
<html>
<head>
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Lich lam viec trong ngay</title>
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
</head>
<%
		Dim Conn
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING

		SelectDay = date()
		
%>
<body text="#000000"  topmargin=0 leftmargin=0   background=Images/bg.gif>
<center>
<form name="checkform" action="CAL_WEEK_APPROVED.ASP" method="POST">
<table border="0" cellspacing="1" style="border-collapse: collapse" bordercolor="#111111" width="95%" id="AutoNumber1">
  <tr> 
    <td width="100%">
		<img src="images\Text_LichLamViecNgay.gif">			
    </td>
  </tr>  
  <tr>
	<td width="100%">&nbsp;</td>    
  </tr>		  
  <tr>
	<td width="100%"><%call Show_Lich(SelectDay)%></td>
  </tr>     
</table>
</form>
</center>
</body>
</html>
<%
	SET Conn=nothing
%>
<%sub Show_Lich(p_SelectedDate)
	dim i
	dim curDate
	dim arrThu	
	dim rs 
	
	arrThu = split("Th&#7913; hai,Th&#7913; ba,Th&#7913; t&#432;,Th&#7913; n&#259;m,Th&#7913; s&#225;u,Th&#7913; b&#7843;y,Ch&#7911; nh&#7853;t",",")
	curDate =  p_FromDate
	
	set rs = server.CreateObject("ADODB.Recordset")
	
	
	rs.open "SELECT BookType_ID, BookType, VietTat FROM BookTypes WHERE SHOW='1' AND BookType_ID IN ('UB','QU') ORDER BY STT", conn,3,3	
	curDate = p_SelectedDate
%>

	<table class="QH_TableMain" cellSpacing="0"	cellPadding="0" width="100%"  background="Images/bg.gif">
		<tr valign="middle" height="25">
			<td width="10%"  class="QH_DataGridHeader" align="center">Thứ/Ngày</td>
			<td width="45%"  class="QH_DataGridHeader" align="center">Sáng</td>
			<td width="1"></td>
			<td width=*"  class="QH_DataGridHeader" align="center">Chiều</td>
		</tr>			
	
		<%j=0
		while not rs.eof%>
			<tr>
				<td align="center" class="QH_LabelBold" valign="top" bgcolor="<%=Col_Color1%>">					
						<%if j=0 then%><%=arrThu(WeekDay(curDate) - 2)%><br><%=left(DateValueVN(curDate),5)%><br><%end if%>
						<%=rs("VietTat")%>
				</td>
				<td class="QH_Label" align="center" valign="top"><%call ShowOneDay(DateValueVN(curDate),"S",rs("BookType_ID"))%></td>
				<td width="1" bgcolor="<%=Col_Color1%>"></td>
				<td class="QH_Label" align="center" valign="top"><%call ShowOneDay(DateValueVN(curDate),"C",rs("BookType_ID"))%></td>
			</tr>
			<tr>
				<td height="1px" bgcolor="<%=Col_Color1%>"></td>
				<td height="1px" bgcolor="<%=Col_Color1%>"></td>
				<td height="1px" bgcolor="<%=Col_Color1%>"></td>
				<td height="1px" bgcolor="<%=Col_Color1%>"></td>
			</tr>
		<%
			rs.movenext
			j=j+1
		wend%>			
	</table>
<%	set rs=nothing
	end sub%>

<%sub ShowOneDay(p_Day, p_AMPM, p_Type) 'Type=1:TT/QU;2:UBND
	dim strSQL 
	dim rs
	
	
	set rs=server.CreateObject("ADODB.Recordset")
	
	strSQL = "Book_GetOneDay "
	strSQL = strSQL & "@p_Date = '" & p_Day & "',"
	strSQL = strSQL & "@p_Type = '" & p_Type & "',"
	strSQL = strSQL & "@p_Approved = 'Y',"	
	strSQL = strSQL & "@p_Time = '" & p_AMPM & "'"	
		
	rs.open strSQL, conn, 3,3
	
	IF NOT rs.eof Then
		while not rs.eof
		%>
			<table cellpadding="0" cellspacing="2"width="95%">
				<tr>
				<%if rs("ChucTho") = "" then%>
					<td width="13%" align="left" valign="top"  class="QH_LabelDisplay">
						<%=rs("Gio") & ":" & rs("Phut")%> <br>
						<%=rs("TinhTrang")%>
					</td>
					<td width="*" class="QH_LabelDisplay"><p align="justify">
						<b>Nội dung:</b>&nbsp;<%=rs("Content")%><br>
						<%if rs("ChairMan") <> "" then%>
							<b>Chủ trì:</b>&nbsp;<font color='red'><%=rs("ChairMan")%></font><br>
						<%end if%>
						<%if rs("Location") <> "" then%>
							<b>Địa điểm:</b>&nbsp;<%=rs("Location")%><br>
						<%end if%>
						<%if rs("JoinMember") <> "" then%>
							<b>Thành phần:</b>&nbsp;<%=rs("JoinMember")%><br>
						<%end if%>						
						<%if rs("Note") <> "" then%>
							<b>Chuẩn bị:</b>&nbsp;<%=rs("Note")%><br>
						<%end if%>						
					</p><br></td>
				<%else%>
					<td width="100%" class="QH_LabelDisplay">	
							<b>Chúc thọ</b><br>
							<%=ReplaceEnterChar(rs("Content"))%><br><br>
					</td>
				<%end if%>
				</tr>
			</table>

		<%		rs.movenext
			wend 
	else
		Response.Write "&nbsp;"
	end if
	set rs=nothing
%>
	
<%end sub%>

<%
	Function DateValueVN(conDate)
	if Day(conDate)<10 then
		p1 = "0" & Day(conDate)
	else
		p1 = Day(conDate)
	end if
	if Month(conDate)<10 then
		p2 = "0" & Month(conDate)
	else
		p2 = Month(conDate)
	end if

	DateValueVN =  p1 & "/" & p2 & "/" & Year(conDate)
End Function
%>

