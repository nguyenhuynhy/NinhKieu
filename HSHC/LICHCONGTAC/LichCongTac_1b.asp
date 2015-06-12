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
		rs.open "SELECT left(meetingdate1,2) + 'h' + SUBSTRING (meetingdate1,4,2) MeetingDate, dbo.convert_abc_unicode(content) Content, dbo.convert_abc_unicode(location) Location, ChuTri, PostPonse FROM view_BOOK where (approved='Y') and (MeetingDate='" + m_Date + "') ORDER BY MeetingDate1", conn,3,3
%>
<html>
	<head>
		<title>Lich cong tac hom nay</title>
		<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
		<meta name="ProgId" content="FrontPage.Editor.Document">
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	</head>
	<body text="#000000" topmargin="0" leftmargin="0" onload="javascript:StartUp();">
		
		<table cellpadding="0" cellspacing="0" width="100%" height="100%" background="images/Lich_hom_nay_2.jpg">
	<!-- MSTableType="layout" -->
	<tr>
		<td width="30" align="center" valign="middle" rowspan="5">&nbsp;</td>
		<td width="215"></td>
		<td height="30" width="491"></td>
		<td width="30" rowspan="5"></td>
	</tr>
	<tr>
	  <td align="left" width="215">&nbsp;</td>
		<td align="left" height="30" width="491">
			<%If WeekDay(now)-1<>0 then%>
				<FONT size="4" color="White" face="Helvetica, Arial, AvantGarde-Demi">
					<b>Thứ</b>
				</FONT>
			<%End if%>
			<%If WeekDay(now)-1<>0 then%>
				<FONT size="4" color="White" face="Helvetica, Arial, AvantGarde-Demi">
					<b><%=arrThu(WeekDay(now)-1)%>, </b>
				</FONT>
			<%Else
			%>
				<FONT size="4" color="White" face="Helvetica, Arial, AvantGarde-Demi">
					<b>Chủ nhật, </b>
				</FONT>
			<%End if%>
			<FONT size="4" color="White" face="Helvetica, Arial, AvantGarde-Demi">
			<b><%=Left(DateValueVN(now()),5)%></b>
			</FONT>
		</td>
	</tr>
	<tr>
	  <td height="62" colspan="2" align="center">&nbsp;</td>
	  </tr>
	<tr>
	  <td height="433" colspan="2" align="center">
		  <MARQUEE id="MARQUEE1" scrollAmount=<%=m_Delay%> scrollDelay="50" style="WIDTH: <%=Width-BannerLeft_Width-BannerRight_Width%>; HEIGHT: 432; TEXT-ALIGN: center;"
									direction="up">
								  <%IF Not rs.eof then%>
									  <%while not rs.eof%>
									  <P>
										  <FONT size=<%=Size_TieuDe%> color=<%=Color_TieuDe%> face="Helvetica, Arial, AvantGarde-Demi"><%=rs("MeetingDate")%></FONT><br>
										  <FONT size=<%=Size_NoiDung%> color=<%=Color_NoiDung%> face="Helvetica, Arial, AvantGarde-Demi"><%=rs("Content")%></FONT><br>
										  <FONT size=<%=Size_DiaDiem%> color=<%=Color_DiaDiem%> face="Helvetica, Arial, AvantGarde-Demi"><%=rs("Location")%></FONT><br>
										  <FONT size=<%=Size_Note%> color=<%=Color_Note%> face="Helvetica, Arial, AvantGarde-Demi"><%If rs("PostPonse")="D" then%>(Dời họp)<%End IF%></FONT><br><br>
										  <FONT size=<%=Size_Seperator%> color=<%=Color_Seperator%> face="Helvetica, Arial, AvantGarde-Demi">***</FONT><br><br>
										  <br><br>
									  </P>
								  <%	
										rs.movenext
										wend		
									End if%>
							  </MARQUEE>	  </td>
		</tr>
	<tr>
	  <td width="215">&nbsp;</td>
		<td height="30" width="491">&nbsp;</td>
	</tr>
</table>
				
	</body>
</html>
