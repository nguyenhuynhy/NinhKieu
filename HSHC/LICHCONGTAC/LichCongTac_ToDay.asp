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
		
		'rs.open "SELECT left(meetingdate1,2) + 'h' + SUBSTRING (meetingdate1,4,2) MeetingDate, dbo.convert_abc_unicode(content) Content, dbo.convert_abc_unicode(location) Location, PostPonse FROM view_BOOK where (approved='Y') and (MeetingDate='" + m_Date + "') and Convert(numeric,left(MeetingDate1,2))<=convert(numeric,left(convert(varchar,getdate(),108),2)) ORDER BY MeetingDate1", conn,3,3
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
		<table width="100%" height="100%">
			<tr>
				<td width=<%=BannerLeft_Width%> bgcolor=<%=Color_Left%>  height="100%">
					<table width="100%">
						<tr>
							<td width="100%" height="100px">
							</td>
							<td width="100%" align="center" valign="middle">
								<FONT size=<%=m_FontLeft%> color=<%=Color_FontLeft%>><b>LỊCH
								<BR><BR>
								CÔNG
								<BR><BR>
								TÁC</b>
								</FONT>
							</td>
							<td width="100%" height="100px">
							</td>
						</tr>
					</table>
				</td>
				<td width="*" align="center" height="100%">
					<table width="100%" height="100%" bgcolor=<%=Color_BackGround%>>
						<tr>
							<td width="100%" align="center" height=<%=Height_Banner%> style="BACKGROUND-IMAGE: url(<%=Image_Banner%>);BACKGROUND-REPEAT: no-repeat;">
							</td>
						</tr>
						<tr>
							<td width="100%" height="100%">
								<MARQUEE id="MARQUEE1" scrollAmount=<%=m_Delay%> scrollDelay="50" style="WIDTH: <%=Width-BannerLeft_Width-BannerRight_Width%>; HEIGHT: <%=Height%>; TEXT-ALIGN: center;"
									direction="up">
									<%IF Not rs.eof then%>
										<%while not rs.eof%>
										<P>
											<FONT size=<%=Size_TieuDe%> color=<%=Color_TieuDe%>><%=rs("MeetingDate")%></FONT><br>
											<FONT size=<%=Size_NoiDung%> color=<%=Color_NoiDung%>><%=rs("Content")%></FONT><br>
											<FONT size=<%=Size_DiaDiem%> color=<%=Color_DiaDiem%>><%=rs("Location")%></FONT><br>
											<%If rs("PostPonse")="D" Then%>
											<FONT size=<%=Size_Note%> color=<%=Color_Note%>>( Dời họp )</FONT><br>
											<%End If%>
											<FONT size=<%=Size_Seperator%> color=<%=Color_Seperator%>>***</FONT><br><br>
											<br><br>
										</P>
									<%	
										rs.movenext
										wend		
									End if%>
								</MARQUEE>
							</td>
						</tr>
					</table>
				</td>
				<td width=<%=BannerRight_Width%> valign=Center  bgcolor=<%=Color_Right%>  height="100%">
					<table width="100%">
						<tr>
							<td align="center" valign="top">
								<%If WeekDay(now)-1<>0 then%>
								<FONT size=<%=m_FontRight%> color=<%=Color_FontRight%>>
									<b>Thứ</b>
								</FONT>
								<%End if%>
							</td>
						</tr>
						<tr>
							<td align="center" valign="top">
								<%If WeekDay(now)-1<>0 then%>
								<FONT size=<%=m_FontRight%> color=<%=Color_FontRight%>>
									<b><%=arrThu(WeekDay(now)-1)%></b>
								</FONT>
								<%Else
								%>
								<FONT size=<%=m_FontRight%> color=<%=Color_FontRight%>>
									<b>Chủ nhật</b>
								</FONT>
								<%End if%>
							</td>
						</tr>
						<tr>
							<td align="center" valign="top">
								<FONT color=<%=Color_Seperator%>>
									<hr>
								</FONT>
							</td>
						</tr>
						<tr>
							<td align="center" valign="top">
								<FONT size=<%=Size_Ngay%> color=<%=Color_Ngay%>>
									<b><%=Left(DateValueVN(now()),5)%></b>
								</FONT>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</html>
