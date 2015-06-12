<!--#include file="inc/Lib.asp"-->
<HTML>
<TITLE>Thong Bao</TITLE>
<HEAD>
<META HTTP-EQUIV="CONTENT-TYPE" Content="text/html; charset=UTF-8">
</HEAD>
<%
	Dim Conn
	SET Conn = Server.CreateObject("ADODB.Connection")
	Conn.Open CONNECTION_STRING
	'------------------------------------------------
	strType = Request("ErrID")
	strMessage = Request("Message")
	strPage = Request("Page")
	strQuery = Request("hQuery")
	
	SET rs = server.createObject("ADODB.recordset")	
	Myarray = split(strType,",",-1,1)
%>
<SCRIPT language="javascript">
function startup()
{
	img.focus();
}
</SCRIPT>
<BODY  leftmargin=0 topmargin=0 background="Images/BG_Line.gif" onload="javascript:startup();">
<TABLE WIDTH="100%" HEIGHT="300"  cellpadding=0 cellspacing=0>
<%
IF strType<>"" THEN
For inti=0 to ubound(Myarray)
SQL = "COMM_GetError '"&strType&"'"
'Response.Write SQL
'Response.End
SET rs = Conn.Execute(SQL)
If not rs.EOF Then
	
	If rs("ReturnPage")<>"" Then
		strReturn = rs("ReturnPage") & "?" & strQuery
	Else	
		strReturn = "javascript:history.back();"
	End If
%>	
	<TR HEIGHT="*">
	  <TD align="middle">
		<BR>
		<TABLE WIDTH="70%" border=0 cellspacing=1>
			<TR bgcolor="#B7CFE5">
				<TD align="middle"><IMG src="Images/text_ThongbaoKQ.jpg" border=0></TD>
			</TR>
			<TR bgcolor="#B7CFE5">
				<TD><FONT face="Arial" size="2" color="red"><%=rs("Description")%></FONT></TD>
			</TR>
			<TR>
				<TD align="middle"><A href="<%=strReturn%>" name=img><IMG  src="Images/button_trove.gif" border=0></A></a></TD>
			</TR>
		</TABLE>
	  </TD>
	</TR>
<%ELSE 'rs.EOF%>
	<TR>
	  <TD align="middle">	
		<TABLE WIDTH="70%" border=1  cellpadding=3 cellspacing=1 style="BORDER-COLLAPSE: collapse" bordercolor="<%=color1%>">
			<TR bgcolor="#B7CFE5">
				<TD align="middle"><IMG src="Images/text_ThongbaoKQ.jpg" border=0></TD>
			</TR>
			<TR bgcolor="#B7CFE5">
				<TD><FONT face="Arial" size="2" color="red">Lỗi không xác định</FONT></TD>
			</TR>
		</TABLE>
		<BR>
		<TABLE WIDTH="70%" border=0 cellspacing=1>
			<TR>
				<TD align="middle"><A href="javascript:history.back();" name=img><IMG  src="Images/button_Trove.jpg" border=0></A></TD>
			</TR>
		</TABLE>
	  </TD>
	</TR>
<%
End If
Next
Else 'Khong co ma loi
%>
	<TR>
	  <TD align="middle">	
		<TABLE WIDTH="70%" border=1  cellpadding=3 cellspacing=1 style="BORDER-COLLAPSE: collapse" bordercolor="<%=color1%>">
			<TR bgcolor="#B7CFE5">
				<TD align="middle"><IMG src="Images/text_ThongbaoKQ.jpg" border=0></TD>
			</TR>
			<TR bgcolor="#B7CFE5">
				<TD><FONT face="Arial" size="2" color="red"><%=strMessage%></FONT></TD>
			</TR>
		</TABLE>
		<BR>
		<TABLE WIDTH="70%" border=0 cellspacing=1>
			<TR>
				<TD align="middle"><A href="<%=strPage%>" name=img><IMG  src="Images/button_Trove.jpg" border=0></A></TD>
			</TR>
		</TABLE>
	  </TD>
	</TR>
<%
End If
Set rs = Nothing
Set Conn = Nothing
%>	
	<TR HEIGHT=20>
	  <TD>
		<table width="100%" cellspacing="0" cellpadding="0" border=0>
			<tr>
			 <td background="Images/Resultfooter02.gif" width="100%"></td>
			</tr>
		</table>	
	  </TD>
	</TR>
</TABLE>		
</BODY>
</HTML>
