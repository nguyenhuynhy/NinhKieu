<!--#include file="INC/Lib.asp"-->
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft FrontPage 6.0">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
<TITLE>Danh sach nguoi chu tri hop</TITLE>
<script language = "javascript" src="inc/common.js"></script>	
<script language="javascript">
	function Chon()
	{
		var ListID = ''
		var ListName = ''
		var iRec
		var str = '', strID = '', strName = ''
		
		
		iRec = frm.chkChon.length
		if (iRec >= 2)
		{	
			for(var i=0; i<iRec; i++)
			{
				if (frm.chkChon[i].checked){
					str = frm.chkChon[i].value;
					strID = (str.split("|"))[0];//str.substring(0,6)
					strName = (str.split("|"))[1];//str.substring(7)
					
					ListID = ListID + ", " + strID;
					ListName = ListName + ", " + strName;					
				}
			}
		}else
		{
			if (frm.chkChon.checked){
					str = frm.chkChon.value;
					strID = (str.split("|"))[0];//str.substring(0,6)
					strName = (str.split("|"))[1];//str.substring(7)
					
					ListID = ListID + ", " + strID;
					ListName = ListName + ", " + strName;
				}
		}
		//alert(ListID);
		ListID = ListID.substring(1);
		ListName = ListName.substring(1);
		
		window.opener.frm.hMemberJoin.value = ListID;
		window.opener.frm.txtMemberJoin.value = ListName;
		window.close();
	}
</script>
</HEAD>
<%
		Dim Conn
		SET Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open CONNECTION_STRING
		
		dim rs
		set rs=server.CreateObject("ADODB.recordset")
		
		strSQL = "COMM_ListUser "
		set rs = Conn.Execute(strSQL)		
%>
<BODY>
<center>
<FORM name="frm">
	
	<table cellspacing="1" class="QH_TableMain" width="100%"><!--bordercolor="<%=BorderColor%>"--> 
		<tr>
			<td width="40" class="QH_DataGridHeader" ><a href = "javascript:choice(frm.chkChon)"><img src='images/checkmark_xanh.gif' border = '0' alt = 'Chon / Huy chon'></a></td>
			<td width="200" class="QH_DataGridHeader" align="center">Họ tên</td>			
			<td width="180" class="QH_DataGridHeader" align="center">Phòng ban</td>
			<td width="80" class="QH_DataGridHeader" align="center">Chức vụ</td>
		</tr>
		<!---->
		<tr>
			<td colspan=4>
			<div style = "overflow=auto;height=120">
				<table width="100%">
					<%if not rs.EOF then
						i=0
						while not rs.EOF
							i = i + 1
							if i mod 2 = 0 then 
								bColor= color2
							else
								bColor= color3
							end if%>
							
							<tr bgcolor="<%=bColor%>">
								<td width="32" align="center"><input type="checkbox" name="chkChon" value="<%=rs("UserID") & "|" & rs("FullName")%>" ID="Checkbox1"></td>
								<td width="195" class="text" align="left"><%=rs("FullName")%>&nbsp;</td>
								<td width="180"  class="text" align="left"><%=rs("TenPhongBan")%>&nbsp;</td>
								<td width="60" class="text" align="left"><%=rs("MaVaiTro")%>&nbsp;</td>
							</tr>
						<%rs.MoveNext
						wend			
					else%>
					
						<tr>
							<td></td>
						</tr>
					<%end if%>			
				</table>
				</div>
			</td>
		</tr>
		<!---->
	</table>
	
	<br>
	<%
		strSQL = "SELECT MaNhom, TenNhom FROM NHOM ORDER BY MaNhom"
		set rs = Conn.Execute(strSQL)	
	%>
	
	<table cellspacing="1"  class="QH_TableMain" width="100%">
		<tr bgcolor="<%=color1%>">
			<td width="40" class="QH_DatagridHeader" >
				<a href = "javascript:choice(frm.chkChon)"><img src='images/checkmark_xanh.gif' border = '0' alt = 'Chon / Huy chon'></a>
			</td>
			<td width="460" class="QH_DatagridHeader" align="center">Nhóm</td>
		</tr>
		<tr>
			<td colspan=2>
			<div style = "overflow=auto;height=100">
				<table width="100%">
					<tr>
						<td>
							<%if not rs.EOF then
								i=0
								while not rs.EOF
									i = i + 1
									if i mod 2 = 0 then 
										bColor= color2
									else
										bColor= color3
									end if%>
									<tr bgcolor="<%=bColor%>">
										<td width="32" align="center"><input type="checkbox" name="chkChon" value="<%=rs("MaNhom") & "|" & rs("TenNhom")%>" ID="Checkbox2"></td>
										<td class="text" align="left"><%=rs("TenNhom")%>&nbsp;</td>			
									</tr>
								<%rs.MoveNext
								wend			
							else%>
								<tr>
									<td></td>
								</tr>
							<%end if%>		
						</td>
					</tr>
				</table>
				</div>
			</td>
		</tr>
	</table>
	
	<br>
	<table cellspacing="1" width="95%">
		<tr>
			<td align="center" colspan="4">
				<a href="javascript:Chon();"><img src="images/Button_ChapNhan.jpg" class="QH_Button" border="0"></a>
				<a href="javascript:window.close();"><img src="images/Button_TroVe.jpg" class="QH_Button" border="0"></a>
			</td>
		</tr>
	</table>
	
</FORM>
</center>
</BODY>
</HTML>