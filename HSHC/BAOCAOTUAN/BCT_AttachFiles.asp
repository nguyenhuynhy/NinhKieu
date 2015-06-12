<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="stylesheet" type="text/css" href="style/style.css">
<title>Dinh kem file thong bao</title>

</head>
<SCRIPT Language = "javascript">
	
	var frm;
	
	function startUp(){
		frm = document.UPLOAD_FORM;				
	}
	
	function validateData(){
		var returnValue = false;
		if(frm.txtAttachedFile.value ==''){
			alert('Xin chon tap tin dinh kem');
			frm.txtAttachedFile.focus();
		}else{
			returnValue = true;
		}				
		return returnValue;
	}
	function OK(){
		if(validateData()){				
			frm.action = 'BCT_AttachFileProcess.asp?txtAttachedFile=' + frm.txtAttachedFile.value + '&AttachedFile=' + frm.AttachedFile.value + '&FileName='+frm.FileName.value;
			frm.submit();
		}	
	}	
	
	function Xoafile(sFileName, sOrgFile){
		frm.action = 'BCT_AttachFiles.asp?txtAttachedFile=' + frm.txtAttachedFile.value 
						+ '&AttachedFile=' + frm.AttachedFile.value + '&FileName='+frm.FileName.value
						+'&btnXoa=Yes&txtXFileName='+sFileName + '&txtXOrg='+sOrgFile;
		frm.submit();
	}

	function TroVe(){
		frm.action='BCT_AttachFiles.asp?btnTroVe=Yes'
						+ '&AttachedFile=' + frm.AttachedFile.value + '&FileName='+frm.FileName.value
		frm.submit();		
	}
</SCRIPT>

<%
	dim OriginalFile, sXFileName, sXOrgFile, strAttachedFile, strFileName
	strAttachedFile = Request("AttachedFile")
	strFileName = Request("FileName")
	if request("btnXoa")<>"" then
		dim sServerPath, sTempFolder, myfile
		sXFileName=request("txtXFileName")
		sXOrgFile = request("txtXOrg")

		' xoa file do o trng thu muc temp
		sServerPath = Server.Mappath(".") & "\"
		sTempFolder = sServerPath & "Temp" & "\"
		set myfile = CreateObject("Scripting.FileSystemObject")

		if myfile.FileExists(sTempFolder & "\" & sXFileName) then
			myfile.Deletefile sTempFolder & "\" & sXFileName
		end if
		
		strAttachedFile = replace(strAttachedFile, sXOrgFile &"@@", "")
		strFileName = replace(strFileName, sXFileName &"@@", "")
	end if
	
'response.write strFileName & "<br>" & strAttachedFile
'response.end
'	if Request("AttachedFile")<>"" then
		arrAttachedFile=split(strAttachedFile, "@@")
		arrFileName=split(strFileName, "@@")
'	end if
%>	
<body topmargin="2" leftmargin="0" onload="startUp();" bgcolor="#EFF7FF">
<center><br>
<FORM METHOD="post" ENCTYPE="multipart/form-data" name = "UPLOAD_FORM">
<input name="AttachedFile" type="hidden" value = "<%=strAttachedFile%>">
<input name="FileName" type="hidden"  value = "<%=strFileName%>">
<table border="0" cellpadding="5" cellspacing="0" width = "400">
  	<tr><td align=middle valign=bottom><b><font face ="Arial" size ="4" color = "#003366">Đính kèm File báo cáo</font></b>
    		<hr width = "100%" size=1  color=goldenrod>    
    		</td>
  	</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width = "500">
	<tr>
			<td width = "25%" valign = middle nowrap height="40"><font face = "Arial" size = 2 color="#1d4d77">Chọn tập tin đính kèm&nbsp;</font></td>
			<td width ="*" height="40" align="left"><INPUT TYPE="file" NAME="txtAttachedFile" size="40">
			</td>		
	</tr>	
	<tr>
			<td width = "25%" valign = middle nowrap>&nbsp;</td>
			<td width ="*" align="left">
		<A href="javascript:OK();"><IMG src="Images/button_chon.jpg" border=0></a></td>		
	</tr>	
	<tr>
	<td width = "25%" align = middle nowrap height="22" colspan="2">&nbsp;</tr>	
	<tr>
	<td width = "25%" align = middle nowrap height="22" colspan="2">
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="100%" id="AutoNumber1">
      <tr>
        <td width="15%" bgcolor="#0099CC" align="center"><font color="#FFFFFF">
        Stt</font></td>
        <td width="70%" bgcolor="#0099CC" align="center"><font color="#FFFFFF">
        Tên tập tin</font></td>
        <td width="15%" bgcolor="#0099CC" align="center"><font color="#FFFFFF">
        Xoá</font></td>
      </tr>
<%
dim stt
stt = 0
for i =0 to ubound(arrAttachedFile)-1
	if arrAttachedFile(i)<>"" then
		stt = stt + 1
		OriginalFile = OriginalFile & arrAttachedFile(i) & ";"
%>      
      <tr>
        <td width="15%">&nbsp;<%=stt%></td>
        <td width="70%">&nbsp;<%=arrAttachedFile(i)%></td>
        <td width="15%" align="center"><a href="" onclick="Xoafile('<%=arrFileName(i)%>','<%=arrAttachedFile(i)%>');return false;"><img border="0" src="images/icon_del.gif"></a></td>
      </tr>
<%
	end if
next
%>      
    </table>
	</tr>	
</table>
			<br><input type="image" src = "images/button_trove.jpg" border = 0 alt = "Tro ve trang danh sach bao cao" name="btnTroVe" onclick="TroVe();return false;">
</FORM>	
</center>
</body>
</html>
<%if request("btnTroVe")<>"" then%>
<script language="javascript">
	window.opener.lblFileName.innerText = '<%=OriginalFile%>';
	window.opener.frmMain.hFileName.value = '<%=strFileName%>';
	window.opener.frmMain.hOriginalFileName.value = '<%=strAttachedFile%>';
	window.close();	
</script>
<%
	end if
%>