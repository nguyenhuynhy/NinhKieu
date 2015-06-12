<!-- #include file = "INC/Lib.asp" -->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<%
	dim AttachedFile, FileName
	Session.CodePage = 65001  		
	
	AttachedFile = Request("AttachedFile")
	arrFileName = Request("FileName")
	
	Query = Request("Query")
	OriginalFile = request("txtAttachedFile")
	arrOriginal = split(OriginalFile,"\")
	OriginalFile = arrOriginal(UBound(arrOriginal))

	set fs		= 	server.CreateObject("scripting.FileSystemObject")
	
	sServerPath = Server.Mappath(".") & "\"
	sTempFolder = sServerPath & "Temp" & "\"
	
	'Tao folder Temp
	strFolder =  sServerPath & "\Temp"
	if not fs.FolderExists(strFolder) then
		fs.CreateFolder(strFolder)
	end if
	
	'Tao folder ThongBao
	strFolder = sServerPath & "\" & UPLOADFOLDER
	if not fs.FolderExists(strFolder) then
		fs.CreateFolder(strFolder)
	end if
%>

<%	
   Dim mySmartUpload
   Dim file
   Dim intCount
   dim strSQL
   intCount=0

   Set mySmartUpload = Server.CreateObject("aspSmartUpload.SmartUpload")
   mySmartUpload.Upload
	
   For each file In mySmartUpload.Files
      If not file.IsMissing Then
		FileName = file.FileName
		set myfile = CreateObject("Scripting.FileSystemObject")

		if myfile.FileExists(sTempFolder & "\" & AttachedFile) then
			myfile.Deletefile sTempFolder & "\" & AttachedFile
		end if
		
		ExtensionName=myfile.GetExtensionName(FileName)				
		NewFileName= UCase(Session.SessionID & "_"  & Year(Now) &  Month(Now) & Day(Now) & Hour(Now) & Minute(Now) & Second(Now))		
		NewFileName=NewFileName & "." & ExtensionName
	
		
		NewFileName = myfile.GetFileName(NewFileName)
		file.SaveAs(sTempFolder & NewFileName)	       	

		AttachedFile = AttachedFile & OriginalFile & "@@"
		arrFileName = arrFileName & NewFileName & "@@"
	
      End If
    Next
'    response.redirect "bct_attachfiles.asp?AttachedFile=" &  AttachedFile & "&FileName=" & arrFileName
%>
<body onload="fSubmit()">
<form name="frmMain" method="post" action="bct_attachfiles.asp">
<input type="hidden" name="AttachedFile" value="<%=AttachedFile%>">
<input type="hidden" name="FileName" value="<%=arrFileName%>">
</form>
</body>
<script language="javascript">
function fSubmit(){
	frmMain.submit();
}
</script>