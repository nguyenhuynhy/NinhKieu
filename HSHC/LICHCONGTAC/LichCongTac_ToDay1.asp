<!-- #include file = "INC/lib.asp" -->
<!-- #include file = "INC/ConfigLichCongTac1.asp" -->
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
		Dim arrThu, arrSo
		arrThu=split("Images/Thu/CN.jpg,Images/Thu/Hai.jpg,Images/Thu/Ba.jpg,Images/Thu/Tu.jpg,Images/Thu/Nam.jpg,Images/Thu/Sau.jpg,Images/Thu/Bay.jpg",",")
		arrSo=split("Images/So/0.jpg,Images/So/1.jpg,Images/So/2.jpg,Images/So/3.jpg,Images/So/4.jpg,Images/So/5.jpg,Images/So/6.jpg,Images/So/7.jpg,Images/So/8.jpg,Images/So/9.jpg",",")
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING
		set rs = server.CreateObject("ADODB.Recordset")
		
		m_Date=DateValueVN(now())
		Dim mThu, mNgay1, mNgay2, mThang1, mThang2
		mThu=arrThu(WeekDay(now)-1)
		
		mNgay1=arrSo(cint(mid(DateValueVN(now()),1,1)))
		mNgay2=arrSo(cint(mid(DateValueVN(now()),2,1)))
		mThang1=arrSo(cint(mid(DateValueVN(now()),4,1)))
		mThang2=arrSo(cint(mid(DateValueVN(now()),5,1)))
		
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
		<table width="100%" height="100%" bgcolor=<%=Color_BackGround%>>
			<tr>
				<td width="100%" align=center valign="Top" bgcolor=<%=Color_BackGround%> height="84">
					<table width=<%=Width_Banner%> height="100%" cellpadding=0 cellspacing=0 border=0>
						<tr>
							<td width="100%" height="36" colspan="4" style="BACKGROUND-IMAGE: url(<%=Image_Banner2%>);BACKGROUND-REPEAT: no-repeat;">
							</td>
						</tr>
						<tr>
							<td width="222" height="38" style="BACKGROUND-IMAGE: url(<%=Image_Banner4%>);BACKGROUND-REPEAT: no-repeat;">
							</td>
							<td width="63" height="38" style="BACKGROUND-IMAGE: url(<%=Image_Banner5%>);BACKGROUND-REPEAT: no-repeat;"><IMG src=<%=mThu%> align=left border=0>
							</td>
							<td width="80" height="38" style="BACKGROUND-IMAGE: url(<%=Image_Banner6%>);BACKGROUND-REPEAT: no-repeat;">
							</td>
							<td width="182" height="38" style="BACKGROUND-IMAGE: url(<%=Image_Banner7%>);BACKGROUND-REPEAT: no-repeat;"><IMG src=<%=mNgay1%> align=left border=0><IMG src=<%=mNgay2%> align=left border=0><IMG src=<%=Image_Seperator%> align=left border=0><IMG src=<%=mThang1%> align=left border=0><IMG src=<%=mThang2%> align=left border=0>
							</td>
						</tr>
						<tr>
							<td width="100%" height="10" colspan="4" style="BACKGROUND-IMAGE: url(<%=Image_Banner8%>);BACKGROUND-REPEAT: no-repeat;">
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>				
				<td width="100%" align="center" valign="Top" bgcolor=<%=Color_BackGround%>  style="BACKGROUND-POSITION: <%=Align%>; BACKGROUND-IMAGE: url(<%=Image_BackGround%>);BACKGROUND-REPEAT: no-repeat;">
					<table width=<%=Width_Banner%> height="100%" cellpadding=0 cellspacing=0 border=0 ID="Table1">
						<tr>
							<td width="100%" height="36" colspan="4">
								<MARQUEE id="MARQUEE1" scrollAmount=<%=m_Delay%> scrollDelay="50" style="WIDTH: <%=Width%>; HEIGHT: <%=Height%>; TEXT-ALIGN: center;"
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
			</tr>
		</table>
	</body>
</html>
