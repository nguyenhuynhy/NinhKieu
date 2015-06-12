<!-- #include file = "INC/lib.asp" -->
<!-- #include file = "INC/ConfigLichCongTac.asp" -->
<script language="javascript">
function StartUp(){
	document.body.style.overflow='hidden';
}
</script>
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
<%
		Dim Conn
		Dim m_Date
		Dim arrThu
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING
		set rs = server.CreateObject("ADODB.Recordset")
		
		m_Date=DateValueVN(now())
		arrThu=split("Chu nhat,hai,ba,t&#432;,n&#259;m,s&#225;u,b&#7843;y",",")
		'response.Write WeekDay(now)
		'response.end
		'rs.open "SELECT left(meetingdate1,2) + 'h' + SUBSTRING (meetingdate1,4,2) MeetingDate, dbo.convert_abc_unicode(content) Content, dbo.convert_abc_unicode(location) Location, ChuTri, PostPonse FROM view_BOOK where (approved='Y') and (MeetingDate='" + m_Date + "') ORDER BY MeetingDate1", conn,3,3
		dim strSQL
		strSQL = "sp_GetLichToDay "
		strSQL = strSQL & "@pDate = '" & m_Date & "'"
		rs.open strSQL, conn, 3,3
%>
<html>
	<head>
		<title>Lich cong tac hom nay</title>
		<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
		<meta name="ProgId" content="FrontPage.Editor.Document">
		<meta http-equiv="REFRESH" content=<%=m_TimeRefresh%>>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	</head>
	<body text="#000000" topmargin="0" leftmargin="0" onload="javascript:StartUp();">
	<b>
<!--------------------------------------------------------------------------------------------------------------->		
		<div align="center">
	<table border="0" width="800" cellspacing="0" cellpadding="0" background="images/Lich_hom_nay_5.jpg" height="600" id="table1">
		<!-- MSTableType="layout" -->
		<tr>
			<td width="30" height="48">&nbsp;</td>
			<td width="630" height="70">&nbsp;</td>
			<td width="110" height="48">&nbsp;</td>
			<td width="30" height="48">&nbsp;</td>
		</tr>
		<tr>
			<td width="30" height="30">&nbsp;</td>
			<td width="630" height="30">&nbsp;</td>
			<td width="110" height="60" rowspan="2" align="center">
				<FONT size="6" color="White" face="Arial, AvantGarde-Demi">
			<b><%=Left(DateValueVN(now()),5)%></b>
			</FONT>
			</td>
			<td width="30" height="30">&nbsp;</td>
		</tr>
		<tr>
			<td width="30" height="30">&nbsp;</td>
			<td width="630" height="30" align="right">
				<%If WeekDay(now)-1<>0 then%>
				<FONT size="6" color="White" face="Arial, AvantGarde-Demi">
					<b>Thứ</b>
				</FONT>
			<%End if%>
			<%If WeekDay(now)-1<>0 then%>
				<FONT size="6" color="White" face="Arial, AvantGarde-Demi">
					<b><%=arrThu(WeekDay(now)-1)%> &nbsp;&nbsp;&nbsp;</b>
				</FONT>
			<%Else
			%>
				<FONT size="6" color="White" face="Arial, AvantGarde-Demi">
					<b>Chủ nhật &nbsp;&nbsp;&nbsp;</b>
				</FONT>
			<%End if%>
			</td>
			<td width="30" height="30">&nbsp;</td>
		</tr>
		<tr>
			<td width="30">&nbsp;</td>
			<td height="30" colspan="2" valign="top">&nbsp;</td>
			<td width="30">&nbsp;</td>
		</tr>

		<tr>
			<td width="30">&nbsp;</td>
			<td width="740" align="center" colspan="2">
				<MARQUEE id="MARQUEE1" scrollAmount=<%=m_Delay%> scrollDelay="50" style="WIDTH: <%=Width-BannerLeft_Width-BannerRight_Width%>; HEIGHT: 480; TEXT-ALIGN: center;"
									direction="up">
								  <%IF Not rs.eof then%>
									  <%while not rs.eof%>
									  <P>
										  <FONT size=<%=Size_TieuDe%> color=<%=Color_TieuDe%> face="Arial, AvantGarde-Demi"><b><%=rs("MeetingDate")%></b></FONT><br>
										  <FONT size=<%=Size_NoiDung%> color=<%=Color_NoiDung%> face="Arial, AvantGarde-Demi"><b><%=rs("Content")%></b></FONT><br>
										  <FONT size=<%=Size_DiaDiem%> color=<%=Color_DiaDiem%> face="Arial, AvantGarde-Demi"><b><%=rs("Location")%></b></FONT><br>
										  <FONT size=<%=Size_Note%> color=<%=Color_Note%> face="Arial, AvantGarde-Demi"><b><%If rs("PostPonse")="D" then%>(Dời họp)<%End IF%></b></FONT><br><br>
										  <FONT size=<%=Size_Seperator%> color=<%=Color_Seperator%> face="Arial, AvantGarde-Demi"><b>***</b></FONT><br><br>
										  <br><br>
									  </P>
								  <%	
										rs.movenext
										wend		
									End if%>
							  </MARQUEE>	  
			</td>
			<td width="30">&nbsp;</td>
		</tr>
	</table>
</div>

<!--------------------------------------------------------------------------------------------------------------->				
</b>
	</body>
</html>
