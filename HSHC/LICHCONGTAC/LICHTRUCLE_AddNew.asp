<!--#include file = "security.asp"-->
<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Dang ky lich hop</title>
<LINK href="inc/portal.css" type=text/css rel=stylesheet>
<script language = "javascript" src="inc/common.js"></script>	
</HEAD>

<script language="javascript">
function Luu(){		
	frm.action="LICHTRUCLE_Process.asp";	
	frm.submit();
}
</script>
<%
	dim strSQL
	dim strBookID
	dim rs 
	dim conn
	
	SET conn = server.CreateObject("ADODB.Connection")
	conn.Open CONNECTION_STRING
	
	strBookID	=	request("hBookID")
	
	if strBookID <> "" then 'Update	
		strSQL = "LichTrucLe_Get @p_Book_ID = '" & strBookID & "'"
		'Response.Write strSQL
		'Response.End
		SET rs = server.CreateObject("ADODB.RecordSet")
		
		rs.Open strSQL, conn
		
		if not rs.EOF then
			strBookID = rs("Book_ID")
			strCanBo = rs("CanBo")
			strNgayTruc	= rs("Ngay")
			strGioTruc = rs("Gio")
			strTaiXe = rs("TaiXe")
			strDonVi = rs("MaDV")
			strPhucVu = rs("PhucVu")
			strLanhDao = rs("LanhDao")
			strBaoVe = rs("BaoVe")
			strLoai = rs("Loailich")
		end if
	else'Add new
		strNgayTruc = request("SelectDay")
	end if
%>
<!--#include file = "IncBeginSub.asp"-->
<BODY background=Images/bg.gif>
<center>
<form name="frm" method="POST">
<input type="hidden" name="hAction" value="<%=request("hAction")%>">
<input type="hidden" name="hBookID" value="<%=strBookID%>">
<input type="hidden" name="hQuery" value="<%=request("hQuery")%>">
<input type="hidden" name="hBack" value="LichTrucLe_List.asp"> 
<table cellspacing="0" width="100%" border=0 align=center>
<tr>
    <td width="100%" align="left"><img src="images\text_LichT7CN.jpg" border="0"></td>    
</tr>
<tr>
	<td height=10px></td>
</tr>
<tr>
	<td>
		<%call showToolBar()%>
	</td>
</tr>
<tr>
	<td width=100%>
		<table width=100% border=0 cellpadding=0 cellspacing=0 class="QH_Table">
			<tr>
				<td colspan=4 height=15px></td>
			</tr>
			<tr>
				<td width="15%" class="QH_ColLabel">Loại lịch</td>
				<td align=left width="40%">&nbsp;<%call MakeCboLoailich("cboLoailich",strLoai)%></td>
				<td width="15%" class="QH_ColLabel">Cán bộ trực</td>
				<td width="35%" align=left >&nbsp;<textarea name=txtCanBo class="QH_Textbox" cols=30%><%=strCanBo%></textarea>
				</td>
			</tr>
			<tr>
				<td class="QH_ColLabel">Ngày</td>
				<td>&nbsp;<input type=text size=10% name=txtNgayTruc class="QH_Textbox" ID="Text3" value="<%=strNgayTruc%>">
					<label class="QH_ColLabel">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Giờ</label>
					<input type=text size=7% name=txtGio class="QH_Textbox" ID="Text4" value="<%=strGioTruc%>">
				</td>
				<td class="QH_ColLabel">Tài xế</td>
				<td>&nbsp;<textarea name = txtTaiXe class="QH_Textbox" cols=30%><%=strTaiXe%></textarea>
				</td>
			</tr>
			<tr>
				<td class="QH_ColLabel">Đơn vị</td>
				<td>&nbsp;<%call MakeCboDonVi("cboDonVi",strDonVi)%></td>
				<td class="QH_ColLabel">Phục vụ</td>
				<td>&nbsp;<textarea name = txtPhucVu class="QH_Textbox" cols=30%><%=strPhucVu%></textarea>
				</td>
			</tr>
			<tr>
				<td  class="QH_ColLabel">Lãnh đạo</td>
				<td>&nbsp;<textarea name = txtLanhDao class="QH_Textbox" cols=33%><%=strLanhDao%></textarea>
				</td>
				<td  class="QH_ColLabel">Bảo vệ</td>
				<td>&nbsp;<textarea name=txtBaoVe class="QH_Textbox" cols=30%><%=strBaoVe%></textarea>
				</td>
			</tr>
			<tr>
				<td colspan=4 height=15px></td>
			</tr>
		</table>
	</td>
  </tr>
  <tr>
	<td height=10px></td>
  </tr>
  <tr>
	<td>
		<%call showToolBar()%>
	</td>
  </tr>
  <%if request("errorcode") <> "" then%>
	<tr>
		<td>
			<font color=red>Xảy ra lỗi !<br>
			Ngày trực phải trong khoảng sau: <br>
			+ Từ ngày: <%=request("from")%> <br>
			+ Đến ngày: <%=request("to")%>
			</font>
		</td>
	</tr>
  <%
  end if
  %>
</table>
</FORM>
</center>
</BODY>
</HTML>
<!--#include file = "IncEndSub.asp"-->
<%
	set conn=nothing
	set rsUser = nothing
%>
<%
	sub MakeCboDonVi(p_Name, p_DefaultValue)
		dim conn
 		set Conn = server.createObject("ADODB.connection")
		Conn.Open CONNECTION_STRING
	
		set rs = server.createObject("ADODB.recordset")            
		set rs = Conn.Execute("sp_GetAllDMPHONGBAN")            
	
		Response.Write("<select class='QH_DropdownList' name='" & p_Name & "' style = 'width:78%'>")
		
		while not rs.EOF
			if Trim(rs("MaDonVi"))=Trim(p_DefaultValue) then
				Response.Write("<option value = " & rs("MaDonVi") & " SELECTED >" & rs("TenDonVi") & vbcrlf)
			else
				Response.Write("<option value = " & rs("MaDonVi") & ">" & rs("TenDonVi") & vbcrlf)
			end if
			rs.MoveNext
		wend            
		Response.Write("</select>")    
	
		set rs = nothing        
		Conn.Close
		set Conn = nothing
	end sub
	
	sub MakeCboLoailich(p_Name, p_DefaultValue)
		dim conn
 		set Conn = server.createObject("ADODB.connection")
		Conn.Open CONNECTION_STRING
	
		set rs = server.createObject("ADODB.recordset")            
		set rs = Conn.Execute("FSSPORTALQH.dbo.sp_GetDanhMucCBO @pTableName = N'LOAILICHTRUCLE'")            
	
		Response.Write("<select class='QH_DropdownList' name='" & p_Name & "' style = 'width:78%'>")
		
		while not rs.EOF
			if Trim(rs("Ma"))=Trim(p_DefaultValue) then
				Response.Write("<option value = " & rs("Ma") & " SELECTED >" & rs("Ten") & vbcrlf)
			else
				Response.Write("<option value = " & rs("Ma") & ">" & rs("Ten") & vbcrlf)
			end if
			rs.MoveNext
		wend            
		Response.Write("</select>")    
	
		set rs = nothing        
		Conn.Close
		set Conn = nothing
	end sub
%>

<%sub ShowToolBar()%>
	 <table cellpadding="0" cellspacing="2" width="100%" >
		<tr valign="absmiddle">			
			<!--<td width="20%" valign="absmiddle" class="QH_Label" ><a href="javascript:location.href='../Home.asp';" ><img alt="Tro ve trang chu" src="images/home.gif" border="0" align="absmiddle">&nbsp;Trang chủ</a> </td>-->
			<td width="20%" valign="absmiddle" class="QH_Label" > <a href="javascript:history.back(-1);" ><img alt="Tro ve trang truoc" src="images/back.gif" border="0" align="absmiddle">&nbsp;Trang trước</a> </td>
			<td width="20%" valign="absmiddle" class="QH_Label" > <a href="javascript:Luu();"><img alt="Luu lich truc" src="images/save.gif" border="0" align="absmiddle">&nbsp;Lưu</a> </td>
			<td width="*">&nbsp;</td>
		</tr>
	</table>
<%END sub%>