<%
Session.codepage = 65001	

Function FileSearch(byval strSearchString, arrFile(), byval intNum, arrKQ, NumKQ)
'    On Error resume next
    NumKQ = 0
    ReDim arrQK(intNum)
    Set WordApp = server.createObject("Word.Application")
	WordApp.Visible = False
    For i = 1 To intNum
        WordApp.Documents.Open (arrFile(i))
        If WordApp.Selection.Find.Execute(strSearchString, false) = True Then
            NumKQ = NumKQ + 1
            arrKQ(NumKQ) = arrFile(i)
        End If
        WordApp.Documents.close()
    Next
    WordApp.Quit (0)
    FileSearch = True
    Exit Function

'    if error.number<>0 then
'	    FileSearch = False
'	    WordApp.Quit (0)
'    end if
End Function

	dim arrFile(2)
	dim bNhu
	dim arrKQ(2)
	dim numKQ
	
	for i = 0 to ubound(arrKQ)
		arrKQ(i) = ""
	next

		sServerPath = Server.Mappath(".") & "\"
		sUploadFolder = sServerPath & UPLOADPATH
	arrFile(1) = sServerPath& "filebaocao\1017402437_2003630103037.doc"
	arrFile(2) = sServerPath&"filebaocao\1017402437_2003630103043.doc"
response.write arrFile(1)
'response.end
	strString = request("txtSearch")
	if request("btnSubmit")<>"" then		
	response.write "truoc search" & "<br>"
		t = FileSearch(strString,arrFile, 2, arrKQ, numKQ)
for i = 1 to numKQ
	response.write arrKQ(i) & "<br>"
next
	end if

%>
<html>

<head>
<meta http-equiv="Content-Language" content="en-us">
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>New Page 2</title>
</head>

<body>

<form method="POST" action="test.asp">
  <p>Search string: <input type="text" name="txtSearch" size="20"><input type="submit" value="Submit" name="btnSubmit"></p>
</form>

</body>

</html>