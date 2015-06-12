<!--#include file="INC/Lib.asp"-->
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<LINK href="inc/ssv.css" type=text/css rel=Stylesheet>
<LINK href="inc/default.css" type=text/css rel=Stylesheet>
<TITLE>Danh sach nguoi chu tri hop</TITLE>
<script language = "javascript" src="inc/common.js"></script>	
<script language="javascript">
	function c()
	{
		alert(frm.select1.options(frm.select1.selectedIndex).innerText)
	}
</script>
</HEAD>
<%
		Dim Conn
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING
		
		dim rs
		set rs=server.CreateObject("ADODB.recordset")
		
		strSQL = "COMM_ListUserChuTri"
		set rs = Conn.Execute(strSQL)
		
		
		
%>
<BODY>
<FORM name="frm">
	<table border="1" cellspacing="1" style="border-collapse: collapse" bordercolor="#FFDD3C" width="90%">
		<tr bgcolor="#FFDD3C">
			<td width="5%"><a href = "javascript:choice(frm.chkChon)"><img src='images/checkmark_xanh.gif' border = '0' alt = 'Chon / Huy chon'></a></td>
			<td width="*" class="title" align="center">Họ tên</td>			
		</tr>
		<%if not rs.EOF then
			i=0
			while not rs.EOF
				i = i + 1
				if i mod 2 = 0 then 
					bColor= "#FFF8D7"
				else
					bColor= "#FFFFFF"
				end if%>
				<tr bgcolor="<%=bColor%>">
					<td align="center"><input type="checkbox" name="chkChon" value="<%=rs("UserID")%>"></td>
					<td class="text" align="left"><%=rs("FullName")%></td>
				</tr>
			<%rs.MoveNext
			wend
		else%>
			<tr>
				<td></td>
			</tr>
		<%end if%>
	</table>
</FORM>
</BODY>
</HTML>
