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
<%
	
	Dim m_Conn
	Set m_Conn = Server.CreateObject("ADODB.Connection")	
	m_Conn.Open CONNECTION_STRING
	
	Set rsUser = Server.CreateObject("ADODB.Recordset")
	rsUser.CursorLocation = 3
	'Phuong modify ngay 05/09/2003: Chi cho hien thi cac user truc
	'strSQL="COMM_ListUser @p_Order='STT'"
	strSQL = "COMM_ListUser @p_DK='UserID IN (''U00002'',''U00003'',''U00004'',''U00005'',''U00006'',''U00007'',''U00008'',''U00009'',''U00014'',''U00015'',''U00018'')', @p_Order='STT'"
	'End Phuong modify ngay 05/09/2003
	'Response.Write strsql
	'Response.End 
	rsUser.Open strSQL,m_Conn
	iCountUser = rsUser.RecordCount + 1	
%>
<script language="javascript">
	var User  = new Array(5);
	User[0]   = new Array(<%=iCountUser%>);
	User[1]   = new Array(<%=iCountUser%>);
	User[2]   = new Array(<%=iCountUser%>);
	User[3]   = new Array(<%=iCountUser%>);
	User[4]   = new Array(<%=iCountUser%>);
	
	function startup(){		
		User[0][0]="";
		User[1][0]="";
		User[2][0]="";
		User[3][0]="";		
		User[4][0]="";		
		<%
		if not rsUser.EOF then
		i=1
		while not rsUser.EOF
		%>
			User[0][<%=i%>]='<%=rsUser("UserID")%>';
			User[1][<%=i%>]='<%=rsUser("FullName")%>';
			User[2][<%=i%>]='<%=rsUser("Tenbophan")%>';
			User[3][<%=i%>]='<%=rsUser("Tenvaitro")%>';				
			User[4][<%=i%>]='<%=rsUser("MaBoPhan")%>';				
		<%
		i=i+1
		rsUser.MoveNext
		wend
		end if
		Set rsUser=Nothing
		%>	
	}
	function UpdateNguoitruc(){		
		var strMaBoPhan
		inti = frm.cboNguoiTruc.selectedIndex;						
		frm.txtNguoiTruc.value = User[1][inti];
		strMaBoPhan = User[4][inti];
		if (strMaBoPhan == 'PB0031  ' )
		{
			frm.cboDonVi.selectedIndex = 1	;
		}
		else
		{
			frm.cboDonVi.selectedIndex = 0;
		}
		frm.txtChucVu.value = User[3][inti];
		
		if (inti!=0){
			frm.txtNguoiTruc.readOnly = true;
			frm.txtChucVu.readOnly = true;
		}else{
			frm.txtNguoiTruc.readOnly = false;
			frm.txtChucVu.readOnly = false;
		}		
	}
	function Luu(){		
		frm.action="LICHTRUC_Process.asp";	
		frm.submit();
	}
</script>
<%
	dim strSQL
	dim strBookID
	dim rs 
	SET rs = server.CreateObject("ADODB.RecordSet")
	
	strBookID	=	request("hBookID")
	
	if strBookID <> "" then 'Update	
		strSQL = "LichTruc_Get @p_Book_ID = '" & strBookID & "'"
		'Response.Write strSQL
		'Response.End
		rs.Open strSQL, m_conn
		
		strBookID = rs("Book_ID")
		strNgayTruc	= rs("NgayTruc")
		strBuoi	=	rs("BuoiTruc")
		strNguoiTrucID = rs("NguoiTrucID")
		strNguoiTruc = rs("NguoiTruc")
		strBoPhan = rs("BoPhan")
		strChucVu = rs("ChucVu")
	else
		strNgayTruc = request("hAddnewDate")
	end if
%>
<!--#include file = "IncBeginSub.asp"-->
<BODY background=Images/bg.gif onload="javascript:startup();">
<center>
<form name="frm" method="POST">
<input type="hidden" name="hAction" value="<%=request("hAction")%>">
<input type="hidden" name="hBookID" value="<%=strBookID%>">
<input type="hidden" name="hQuery" value="<%=request("hQuery")%>">
<input type="hidden" name="hBack" value="LichTruc_List.asp"> 
<table cellspacing="0" width="100%">
  <tr>
    <td width="100%" align="left" colspan="2"><img src="images\text_LichT7CN.gif" border="0"></td>    
  </tr>
  <tr><td colspan="2"><%call showToolBar()%></td></tr>
  <tr><!--<a href="javascript:DispDate2(checkform.txtNgay);"><img src="images\button_calendar.gif" border="0"></a>-->
    <td width="30%" class="QH_ColLabel">Ngày trực</td>
    <td width="*">&nbsp;<input type=text name=txtNgayTruc size="14" value="<%=strNgayTruc%>" class="QH_Textbox" onblur="javascript:CheckDate(this)">&nbsp;<img height="21" src="images\button_calendar.gif" border="0" onclick="javascript:DispDate(frm.txtNgayTruc);">
    </td>
  </tr>
  <tr>
	<td class="QH_ColLabel">Thời gian</td>
	<td>&nbsp;<%call MakeCboBuoi("cboBuoi",strBuoi)%></td>
  </tr>
  <tr>
    <td class="QH_ColLabel">Chọn người trực</td>
    <td class="QH_LabelLeft"><%
		'Phuong modify ngay 05/09/2003: Chi cho hien thi cac user truc
		'call MakeCboNguoiTruc("cboNguoiTruc","COMM_ListUser @p_Order='STT'",strNguoiTrucID,"UserID","FullName","200","1"," onchange='javascript:UpdateNguoitruc();'")
		call MakeCboNguoiTruc("cboNguoiTruc","COMM_ListUser @p_DK='UserID IN (''U00002'',''U00003'',''U00004'',''U00005'',''U00006'',''U00007'',''U00008'',''U00009'',''U00014'',''U00015'',''U00018'')', @p_Order='STT'",strNguoiTrucID,"UserID","FullName","228","1"," onchange='javascript:UpdateNguoitruc();'")
		'End Phuong modify ngay 05/09/2003
		%>
	</td>
  </tr>
  <tr>
    <td class="QH_ColLabel" align="right">Người trực</td>
    <td class="QH_LabelLeft"><input type="text" class="QH_Textbox" name="txtNguoiTruc" maxlength="100" value="<%=strNguoiTruc%>" size="39"></td>
  </tr>
  <tr>
    <td class="QH_ColLabel" align="right">Chức vụ</td>
    <td class="QH_LabelLeft"><input type="text" class="QH_Textbox" name="txtChucVu" value="<%=strChucVu%>" maxlength="500" size="39" ID="Text1"></td>
  </tr>
  <tr>
    <td class="QH_ColLabel" align="right">Đơn vị</td>
    <td class="QH_LabelLeft"><%call MakeCboDonVi("cboDonVi",strBoPhan)%></td>
  </tr>
  <tr><td colspan="2"><br><%call showToolBar()%></td></tr>   
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
	sub MakeCboBuoi(p_Name, p_value)
		dim p_SSel
		dim p_TSel
		
		if p_value = "S" OR p_value= "" then p_SSel = "Selected"
		if p_value = "T" then p_TSel = "Selected"
						
		Response.Write "<SELECT class='QH_DropdownList' Name='" & p_Name & "' style='width:228'>"	 & vbcrlf
		Response.Write "<option value='S' " & p_SSel & ">Bu&#7893;i s&#225;ng</option>" & vbcrlf
		Response.Write "<option value='T' " & p_TSel & ">Bu&#7893;i t&#7889;i</option>" & vbcrlf
		Response.Write "</SELECT>" & vbcrlf
	end sub
	
	sub MakeCboDonVi(p_Name, p_value)
		dim p_QUSel
		dim p_UBSel
		
		if p_value = "QU" OR p_value= "" then p_QUSel = "Selected"
		if p_value = "UB" then p_UBSel = "Selected"
						
		Response.Write "<SELECT class='QH_DropdownList' Name='" & p_Name & "' class='text' style='width:228'>"	 & vbcrlf
		Response.Write "<option value='UB' " & p_UBSel & ">U&#7927; ban nh&#226;n d&#226;n Qu&#7853;n</option>" & vbcrlf
		Response.Write "<option value='QU' " & p_QUSel & ">Qu&#7853;n u&#7927;</option>" & vbcrlf
		Response.Write "</SELECT>" & vbcrlf
	end sub
	
	sub MakecboNguoiTruc(Name,strSQL,DefaultValue,value,text,width,optnull, optFuntion)
 		dim conn
 		set Conn = server.createObject("ADODB.connection")
		Conn.Open CONNECTION_STRING
	
		set rs = server.createObject("ADODB.recordset")            
		set rs = Conn.Execute(strSQL)            
	
		if len(optFuntion)>=10 then
		Response.Write("<select class='QH_DropdownList' name='" & Name & "' style = 'width:" & width & "'>")		
		else	            
		Response.Write("<select class='QH_DropdownList' name='" & Name & "' style = 'width:" & width & "'>")
		end if
		
		If optnull="1" Then
			Response.Write("<option value = ''>C&#225;n b&#7897; thu&#7897;c Qu&#7853;n &#7910;y")
		End IF
		while not rs.EOF
			if Trim(rs(value))=Trim(DefaultValue) then
				Response.Write("<option value = " & rs(value) & " SELECTED >" & rs(text) & vbcrlf)
			else
				Response.Write("<option value = " & rs(value) & ">" & rs(text) & vbcrlf)
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
			<td width="20%" valign="absmiddle" class="QH_Label" > <a href="javascript:Luu();"><img alt="Luu lich lam viec" src="images/save.gif" border="0" align="absmiddle">&nbsp;Lưu</a> </td>			
			<td width="*">&nbsp;</td>
		</tr>
	</table>
<%END sub%>