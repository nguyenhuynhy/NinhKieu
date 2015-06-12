<%
'---------------------Global Constants and Variables---------------------

	Session.Timeout= 480
	Response.CacheControl = false
	Response.Expires = 0
	Response.Buffer = True	
	
	Session.codepage = 65001	
	
	Const CONNECTION_STRING = "driver={SQL SERVER};Server=phuocdd;Database=WEB;UID=sa;PWD=;"
	Const Interval=30	
	Const TimeInterval=10
	Const OrgCode="001"		
	'Const PAGESIZE = 10
	
	Dim icount,maxrecs,page,maxpages,count_recs,iRec
	Dim PAGESIZE			' Number of record in 1 page
	PAGESIZE =  10	' Default value of PAGESIZE
	Const PAGEDISPLAY = 10 	' Maximum page display in web page
	
	'dinh nghia mau cua table
	Const BorderColor = "#FFFFFF"
	Const color1="#B7CFE5"
	Const color2="#DCECF6"
	Const color3="#F3FCFF"
	Const MaxNgay = 7
	
	'dinh nghia mau cho cot thu
	Const Col_SelectedColor = "#D0D064"
	Const Col_Color1 = "#BDDBF5"'"#5486DD"'"#BDDBF5"
	Const Col_Color2 = "#CEDFE7"'"#BDDBF5"'"#CEDFE7"
	
	'Phong modify 21/06/2002 Khai bao cac hang so duong dan mo file soan CV Di
	Const ServerTempPath = "D:\WebNoiBo\Temp\"
	Const ServerDocPath =  "D:\WebNoiBo\Document\"
	Const ServerTemplatePath =  "D:\WebNoiBo\Template\"
	Const ClientPath = "\\Server2\Temp\"
	'end phong
	
	CONSTHOST = "mail.fsofthcm.com.vn" ' Specify a valid SMTP server  	
	CONSTFROM =  "tttt@net.gov.vn" ' Specify sender's address  
	CONSTFROMNAME = "WebMaster"  ' Specify sender's name 
	CMENU	= "D8E4EF"  
	CTEXT	= "1A4287"
	CTITLE	= "E3E9C0"	
	
	'maxpages = 0
	'maxrecs = 0
	'count_recs = 0
	'strpage = request("page")
	 
	'If strpage = "" then 
   	'	page = 1 
   	'else	 
   	'	page=cint(request("page"))
	'end if

'--------------------------Utility Functions-------------------------

' Su dung Sub DisplayError de goi trang Result.asp
Sub DisplayError(strPagename,strCode,intBack)
	strPagename = server.HTMLEncode(strPagename) 
	response.write("<script language='" & "javascript" & "'>")
	response.write("location.href='Result.asp?pagename=" & strPagename & "&code=" & strcode & "&Back=" & intBack & "'"	)
	response.write("</script>")	
End Sub


Sub initPage(p_rs)
	strpage = request("page")
	If strpage = "" then 
		page = 1 
	else	 
		page=cint(request("page"))		
	end if

	p_rs.pagesize= PAGESIZE '10 records per page                                                                                                                                                       
	maxpages=cint(p_rs.pagecount)                             	                                                                                                                           
	maxrecs=cint(p_rs.pagesize)                                                                                                                                                       
   	p_rs.absolutepage=page                                                                                                                                                        
	count_recs=0
	icount = p_rs.RecordCount
	if iCount>=PAGESIZE*page then
		iRec=PAGESIZE
	else
		iRec=iCount mod PAGESIZE
	end if
End Sub

Sub WriteSubTitle(page,maxpages,strMore)
' Ham duoc su dung de hien thi line o duoi title
	' Hien thi dong ket qua   	
	response.write "<table border='0' width='100%' cellspacing='1' >"	 
	response.write "<tr><td width='61%' align='right'>"
	if ((page)*PAGESIZE)<= icount then
		response.write "<font color='#0000FF' size=2>" & "K&#7871;t qu&#7843; " & "<b>" & ((page-1)*PAGESIZE + 1)& " - " & ((page)*PAGESIZE) & "</b>" & " trong " & "<b>" & icount & "</b>" & " record" & "</font>"
	else
		response.write "<font color='#0000FF' size=2>" & "K&#7871;t qu&#7843; " & "<b>" & ((page-1)*PAGESIZE + 1)& " - " & icount & "</b>" & " trong " & "<b>" & icount & "</b>" & " record" & "</font>"
	end if
	response.write "</td><td width='39%' align='right'>"

	' Hien thi button Lui ve 1 trang	
	If page<> 1 and page <>0 then                                                                                          
    	Response.write("<A Href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & page -1 & strMore & "><img src=images/button_lui.jpg border=0>" & "</A>")
	ElseIf maxpages >1 then
		Response.write "<img src=images/button_lui_dis.jpg border=0>"
    End if    

	' Hien thi cac so o giua
    if maxpages>1 then
		j=page+(PAGEDISPLAY/2)-1
		k=page-(PAGEDISPLAY/2)
		if j > maxpages then
			j = maxpages
			k = maxpages-PAGEDISPLAY
		end if
		if k<1 then
			k=1
		end if
		for i=k to j
			if page<>i then
				Response.Write ("<a href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & i & strMore & "><u>"  &i& "</u></a>" )
			else
				Response.Write ("<font color=red>" &i& "</font>" )
			end if
			Response.Write ("&nbsp;")
		next
	end if

	' Hien thi button Toi tiep 1 trang
	IF page<maxpages then                                             
		Response.write("<A Href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & page + 1 & strMore & "><img src=images/button_toi.jpg border=0>" & "</A>")
	Elseif maxpages >1 then
     	Response.write "<img src=images/button_toi_dis.jpg border=0>"
	End if  
	response.write "</td></tr></table>"
end sub

Sub DividePage(page,maxpages,strMore)
	' Hien thi button Lui ve 1 trang	    	     
	If page<> 1 and page <>0 then                                                                                          
    	Response.write("<A Href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & page -1 & strMore & "><img src=images/button_lui.jpg border=0>" & "</A>")
	ElseIf maxpages >1 then
		Response.write "<img src=images/button_lui_dis.jpg border=0>"
    End if    
   
	' Hien thi cac so o giua   
    if maxpages>1 then
		j=page+(PAGEDISPLAY/2)-1
		k=page-(PAGEDISPLAY/2)
		if j > maxpages then
			j = maxpages
			k = maxpages-PAGEDISPLAY
		end if
		if k<1 then
			k=1
		end if
		for i=k to j
			if page<>i then
				Response.Write ("<a href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & i & strMore & "><u>"  &i& "</u></a>" )
			else
				'Response.Write ("<a href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & i & strMore & "><font color=red>"  &i& "</font></a>" )
				Response.Write ("<font color=red>"  &i& "</font>" )
			end if
			Response.Write ("&nbsp;")
		next
	end if

	' Hien thi button Toi tiep 1 trang	
	IF page<maxpages then                                             
		Response.write("<A Href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & page + 1 & strMore & "><img src=images/button_toi.jpg border=0>" & "</A>")
	Elseif maxpages >1 then
     	Response.write "<img src=images/button_toi_dis.jpg border=0>"
	End if  
End sub

%>
<%
Rem ------------------------------------------------------------------------------------
Rem  Sub Phan Trang cho rieng trang Search
Rem ------------------------------------------------------------------------------------
Sub PreNextPage(page, maxpages, strSearch, strDonviTraloi, strChude, strTungay, strDenngay)
	dim strPreNextpage
		if strSearch		<> ""	then strPreNextpage = strPreNextpage & "&txtSearch="		& strSearch
    	if strDonviTraloi	<> ""	then strPreNextpage = strPreNextpage & "&CboDonviTraloi="	& strDonviTraloi
    	if strChude			<> ""	then strPreNextpage = strPreNextpage & "&cboChude="			& strChude
    	if strTungay		<> ""	then strPreNextpage = strPreNextpage & "&txtTungay="		& strTungay
    	if strDenngay		<> ""	then strPreNextpage = strPreNextpage & "&txtDenngay="		& strDenngay  
    	strPreNextpage = strPreNextpage & ">"      
	If page<> 1 and page <>0 then                                                                                          
    	Response.write("<A Href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & page -1 & strprenextpage & "<img src=images/button_lui.jpg border=0>" & "</A>")                                                                                              
	ElseIf maxpages >1 then
		Response.write "<img src=images/button_lui_dis.jpg border=0>"                                    
    End if    
	  
	IF page<maxpages then                                                                                         
		Response.write("<A Href=" & Request.ServerVariables("SCRIPT_NAME") & "?page=" & page + 1 & strprenextpage & "<img src=images/button_toi.jpg border=0>" & "</A>")                                                                                             
	Elseif maxpages >1 then
     	Response.write "<img src=images/button_toi_dis.jpg border=0>"
	End if  
End sub


Sub GoNextPage(sItem,sOption,sFrom,sTo,sTotal)
	dim strPreNextpage
		if sItem		<> ""	then strPreNextpage = strPreNextpage & "&Item="		& sItem
    	if sOption	<> ""	then strPreNextpage = strPreNextpage & "&sOption="	& sOption
    	if sFrom			<> ""	then strPreNextpage = strPreNextpage & "&From="			& sFrom
    	if sTo		<> ""	then strPreNextpage = strPreNextpage & "&To="		& sTo
    	strPreNextpage = strPreNextpage & ">"      
	
    	Response.write("<A Href=" & "CVDEN_Statistis_Detail.asp" & strprenextpage & sTotal & "</A>")                                                                                              
	
	  
	
End sub
%>
<%	Sub ExecuteSQL(strSQL)
	set conn_exec = server.createObject("ADODB.connection")			
	conn_exec.open CONNECTION_STRING 	
	set rs = server.CreateObject("ADODB.recordset")
	Set rs = conn_exec.Execute(strSQL) 
	set rs =nothing
	set conn_exec =nothing
	
	End Sub
%>
<%	Sub DisplayReceivedByIntDoc_ID(strIntDoc_ID , strWrite)
	set conn_exec = server.createObject("ADODB.connection")			
	conn_exec.open CONNECTION_STRING 	
	set rs=Server.CreateObject("ADODB.Recordset")
	sql="VB_LstReceiverByIntDoc_ID '" & strIntDoc_ID & "'"
	strWrite = "Y"
	sql= sql & ",'" & strWrite & "'"						
	rs.open sql,conn
	Response.Write("<Font face=Arial size=2>") 
	do while not rs.EOF			
		Response.Write(" - " & rs("FullName")&  "<br>")				
		rs.MoveNext
	loop						
	Response.Write("</Font>") 
	set rs =nothing
	set conn_exec =nothing
	End Sub
%>	

<%	Function CToMonth()
		CToMonth = right("0"& day(date()),2) & "/" & right("0" & month(date()),2)& "/" & year(date())
	End Function 
%>
<%	
Function TheFirstDayOfMonth
	TheFirstDayOfMonth = "01" & "/" & right("0"& month(date()),2) & "/" & year(date())
End Function
%>
<%
Function TheEndDayOfMonth
Dim strTemp 
Dim datTemp 
    If Month(Date) <> 12 Then
        strTemp = "01" & "/" & Right("0" & Month(Date) + 1, 2) & "/" & Year(Date)
    Else
        strTemp = "01" & "/" & Right("0" & 1, 2) & "/" & Year(Date) + 1
    End If    
    datTemp = CDate(strTemp)    
    TheEndDayOfMonth = DateAdd("d", -1, ConvertDate(datTemp))
End Function
%>
<%
Function ConvertDate(dtDate)
	if dtDate = "" then
		ConvertDate = ""
		exit function
	end if
	strDay = Day(dtDate)
	strMonth = Month(dtDate)
	strYear = Year(dtDate)
	if strDay < 10 then strDay = "0" & strDay
	if strMonth < 10 then strMonth = "0" & strMonth
	ConvertDate = strDay & "/" & strMonth & "/" & strYear
	if trim(ConvertDate) = "//" then ConvertDate = ""
End Function

Function Quote(str)
	Quote = replace(str,"'","''")
End Function
%>
<%

Function DateValueVN(conDate)	
	DateValueVN = right("0"& day(conDate),2) & "/" & right("0"& month(conDate),2) & "/" & year(conDate)
End Function

sub DelOneFile(fpath,fname)
	Dim ScriptObject
	Set ScriptObject = Server.CreateObject("Scripting.FileSystemObject")
	if ScriptObject.FileExists (fpath & "\" & fname) then
		ScriptObject.DeleteFile fpath & "\" & fname
	end if
	Set ScriptObject = nothing
end sub



Function CONVERT_UNICODE_ABC(strUnicode)
aUni = Array(ChrW(7857), ChrW(7856), ChrW(7859), ChrW(7858), ChrW(7861), ChrW(7860), ChrW(7855), ChrW(7854), ChrW(7863), ChrW(7862), _
    ChrW(7847), ChrW(7846), ChrW(7849), ChrW(7848), ChrW(7851), ChrW(7850), ChrW(7845), ChrW(7844), ChrW(7853), ChrW(7852), _
    ChrW(7873), ChrW(7872), ChrW(7875), ChrW(7874), ChrW(7877), ChrW(7876), ChrW(7871), ChrW(7870), ChrW(7879), ChrW(7878), _
    ChrW(7891), ChrW(7890), ChrW(7893), ChrW(7892), ChrW(7895), ChrW(7894), ChrW(7889), ChrW(7888), ChrW(7897), ChrW(7896), _
    ChrW(7901), ChrW(7900), ChrW(7903), ChrW(7902), ChrW(7905), ChrW(7904), ChrW(7899), ChrW(7898), ChrW(7907), ChrW(7906), _
    ChrW(7915), ChrW(7914), ChrW(7917), ChrW(7916), ChrW(7919), ChrW(7918), ChrW(7913), ChrW(7912), ChrW(7921), ChrW(7920), _
    ChrW(258), ChrW(194), ChrW(202), ChrW(416), ChrW(212), ChrW(431), ChrW(272), ChrW(208), ChrW(259), ChrW(226), _
    ChrW(234), ChrW(417), ChrW(244), ChrW(432), ChrW(273), ChrW(224), ChrW(192), _
    ChrW(7843), ChrW(7842), ChrW(227), ChrW(195), ChrW(225), ChrW(193), ChrW(7841), ChrW(7840), ChrW(232), ChrW(200), _
    ChrW(7867), ChrW(7866), ChrW(7869), ChrW(7868), ChrW(233), ChrW(201), ChrW(7865), ChrW(7864), ChrW(236), ChrW(204), _
    ChrW(7881), ChrW(7880), ChrW(297), ChrW(296), ChrW(237), ChrW(205), ChrW(7883), ChrW(7882), ChrW(242), ChrW(210), _
    ChrW(7887), ChrW(7886), ChrW(245), ChrW(213), ChrW(243), ChrW(211), ChrW(7885), ChrW(7884), ChrW(249), ChrW(217), _
    ChrW(7911), ChrW(7910), ChrW(361), ChrW(360), ChrW(250), ChrW(218), ChrW(7909), ChrW(7908), ChrW(7923), ChrW(7922), _
    ChrW(7927), ChrW(7926), ChrW(7929), ChrW(7928), ChrW(253), ChrW(221), ChrW(7925), ChrW(7924))

aUniTmp = Array("x7857", "x7856", "x7859", "x7858", "x7861", "x7860", "x7855", "x7854", "x7863", "x7862", _
    "x7847", "x7846", "x7849", "x7848", "x7851", "x7850", "x7845", "x7844", "x7853", "x7852", _
    "x7873", "x7872", "x7875", "x7874", "x7877", "x7876", "x7871", "x7870", "x7879", "x7878", _
    "x7891", "x7890", "x7893", "x7892", "x7895", "x7894", "x7889", "x7888", "x7897", "x7896", _
    "x7901", "x7900", "x7903", "x7902", "x7905", "x7904", "x7899", "x7898", "x7907", "x7906", _
    "x7915", "x7914", "x7917", "x7916", "x7919", "x7918", "x7913", "x7912", "x7921", "x7920", _
    "x258", "x194", "x202", "x416", "x212", "x431", "x272", "x208", "x259", "x226", _
    "x234", "x417", "x244", "x432", "x273", "x224", "x192", _
    "x7843", "x7842", "x227", "x195", "x225", "x193", "x7841", "x7840", "x232", "x200", _
    "x7867", "x7866", "x7869", "x7868", "x233", "x201", "x7865", "x7864", "x236", "x204", _
    "x7881", "x7880", "x297", "x296", "x237", "x205", "x7883", "x7882", "x242", "x210", _
    "x7887", "x7886", "x245", "x213", "x243", "x211", "x7885", "x7884", "x249", "x217", _
    "x7911", "x7910", "x361", "x360", "x250", "x218", "x7909", "x7908", "x7923", "x7922", _
    "x7927", "x7926", "x7929", "x7928", "x253", "x221", "x7925", "x7924")
    
aTCVN = Array("»", "»", "¼", "¼", "½", "½", "¾", "¾", "Æ", "Æ", _
    "Ç", "Ç", "È", "È", "É", "É", "Ê", "Ê", "Ë", "Ë", _
    "Ò", "Ò", "Ó", "Ó", "Ô", "Ô", "Õ", "Õ", "Ö", "Ö", _
    "å", "å", "æ", "æ", "ç", "ç", "è", "è", "é", "é", _
    "ê", "ê", "ë", "ë", "ì", "ì", "í", "í", "î", "î", _
    "õ", "õ", "ö", "ö", "÷", "÷", "ø", "ø", "ù", "ù", _
    "¡", "¢", "£", "¥", "¤", "¦", "§", "§", "¨", "©", _
    "ª", "¬", "«", "­", "®", "µ", "µ", _
    "¶", "¶", "·", "·", "¸", "¸", "¹", "¹", "Ì", "Ì", _
    "Î", "Î", "Ï", "Ï", "Ð", "Ð", "Ñ", "Ñ", "×", "×", _
    "Ø", "Ø", "Ü", "Ü", "Ý", "Ý", "Þ", "Þ", "ß", "ß", _
    "á", "á", "â", "â", "ã", "ã", "ä", "ä", "ï", "ï", _
    "ñ", "ñ", "ò", "ò", "ó", "ó", "ô", "ô", "ú", "ú", _
    "û", "û", "ü", "ü", "ý", "ý", "þ", "þ")

	Dim StrConv
    
    StrConv = strUnicode
    
    For i = 0 To UBound(aUni)
        StrConv = Replace(StrConv, aUni(i), aUniTmp(i))
    Next
 
    For Y = 0 To UBound(aUniTmp)
        StrConv = Replace(StrConv, aUniTmp(Y), aTCVN(Y))
    Next
    
    CONVERT_UNICODE_ABC = StrConv
End function


Function CONVERT_ABC_UNICODE(strABC)
'strABC = "ß"
'Dim abc,unicode
Dim strUnicode
arrABC = Array("¸", "µ", "¶", "·", "¹", "¨", "¾", "»", "¼", "½", _
    "Æ", "©", "Ê", "Ç", "È", "É", "Ë", "ã", "ß", "á", _
    "â", "ä", "«", "è", "å", "æ", "ç", "é", "¬", "í", _
    "ê", "ë", "ì", "î", "ó", "ï", "ñ", "ò", "ô", "­", _
    "ø", "õ", "ö", "÷", "ù", "Ð", "Ì", "Î", "Ï", "Ñ", _
    "ª", "Õ", "Ò", "Ó", "Ô", "Ö", "Ý", "×", "Ø", "Ü", _
    "Þ", "ý", "ú", "û", "ü", "þ", "®", "¤", "¥", "¦", "Í", _
    "¢", "§", "Á", "€", "", "‚", "", "ˆ", "", "Ž", "", _
    "ð", "", "¢", "ƒ", "„", "…", "", "·", "¹", "¼", _
    "½", "¾", "", "¤", "–", "—", "˜", "™", "", "¥", _
    "", "ž", "Ÿ", "¦", "", "Ú", "¨", "Ñ", "¬", "", _
    "¦", "­", "¯", "±", "", "", "É", "×", "Þ", "þ", _
    "", "Ê", "", "“", "”", "•", "", "Í", "µ", "·", _
    "¸", "", "Ý", "²", "ý", "³", "", "§")

Unicode = Array("225", "224", "7843", "227", "7841", "259", "7855", "7857", "7859", "7861", _
    "7863", "226", "7845", "7847", "7849", "7851", "7853", "243", "242", "7887", _
    "245", "7885", "244", "7889", "7891", "7893", "7895", "7897", "417", "7899", _
    "7901", "7903", "7905", "7907", "250", "249", "7911", "361", "7909", "432", _
    "7913", "7915", "7917", "7919", "7921", "233", "232", "7867", "7869", "7865", _
    "234", "7871", "7873", "7875", "7877", "7879", "237", "236", "7881", "297", _
    "7883", "253", "7923", "7927", "7929", "7925", "273", "212", "416", "431", "205", _
    "194", "272", "193", "192", "7842", "195", "7840", "258", "7854", "7856", "7858", _
    "7860", "7862", "194", "7844", "7846", "7848", "7850", "7852", "211", "210", _
    "7886", "213", "7884", "212", "7888", "7890", "7892", "7894", "7896", "416", _
    "7898", "7900", "7902", "7904", "7906", "218", "217", "7910", "360", "7908", _
    "431", "7912", "7914", "7916", "7918", "7920", "201", "200", "7866", "7868", _
    "7864", "202", "7870", "7872", "7874", "7876", "7878", "205", "204", "7880", _
    "296", "7882", "221", "7922", "7926", "7928", "7924", "208")

UnicodeTmp = Array("x225", "x224", "x7843", "x227", "x7841", "x259", "x7855", "x7857", "x7859", "x7861", _
    "x7863", "x226", "x7845", "x7847", "x7849", "x7851", "x7853", "x243", "x242", "x7887", _
    "x245", "x7885", "x244", "x7889", "x7891", "x7893", "x7895", "x7897", "x417", "x7899", _
    "x7901", "x7903", "x7905", "x7907", "x250", "x249", "x7911", "x361", "x7909", "x432", _
    "x7913", "x7915", "x7917", "x7919", "x7921", "x233", "x232", "x7867", "x7869", "x7865", _
    "x234", "x7871", "x7873", "x7875", "x7877", "x7879", "x237", "x236", "x7881", "x297", _
    "x7883", "x253", "x7923", "x7927", "x7929", "x7925", "x273", "x212", "x416", "x431", "x205", _
    "x194", "x272", "x193", "x192", "x7842", "x195", "x7840", "x258", "x7854", "x7856", "x7858", _
    "x7860", "x7862", "x194", "x7844", "x7846", "x7848", "x7850", "x7852", "x211", "x210", _
    "x7886", "x213", "x7884", "x212", "x7888", "x7890", "x7892", "x7894", "x7896", "x416", _
    "x7898", "x7900", "x7902", "x7904", "x7906", "x218", "x217", "x7910", "x360", "x7908", _
    "x431", "x7912", "x7914", "x7916", "x7918", "x7920", "x201", "x200", "x7866", "x7868", _
    "x7864", "x202", "x7870", "x7872", "x7874", "x7876", "x7878", "x205", "x204", "x7880", _
    "x296", "x7882", "x221", "x7922", "x7926", "x7928", "x7924", "x208")
    
    strUnicode = strABC
 Dim Str
    If strUnicode <> "" Then
        For j = 0 To UBound(arrABC)
            Str = UnicodeTmp(j)
            strUnicode = Replace(strUnicode, arrABC(j), Str)
        Next
        For i = 0 To UBound(Unicode)
            Str = ChrW(Unicode(i))
            strUnicode = Replace(strUnicode, UnicodeTmp(i), Str)
        Next
    End If
    
    CONVERT_ABC_UNICODE = strUnicode
End Function

'------------------Database Functions--------------------------------

Sub ExecuteSQL(strSQL)
	set conn_exec = server.createObject("ADODB.connection")			
	conn_exec.open CONNECTION_STRING 	
	set rs = server.CreateObject("ADODB.recordset")
	Set rs = conn_exec.Execute(strSQL) 
	set rs =nothing
	set conn_exec =nothing
	
End Sub

Sub ExecuteSQL2(strSQL)
	Set cmd = Server.CreateObject("ADODB.Command")
	Set cmd.ActiveConnection = cnn
	cmd.CommandText = strSQL
	cmd.Execute
	Set cmd = nothing
End Sub

Function GetOneRecordset(strSQL)
	Set cmd = Server.CreateObject("ADODB.Command")
	Set cmd.ActiveConnection = cnn
	cmd.CommandText = strSQL

	Set GetOneRecordset = cmd.Execute
End Function


'----------------------User Functions----------------------------------------'

Function UserRightofFunction(UserName,FunctionName)
'Lay quyen cua mot User ve mot chuc nang nao do, neu khong co thi bao loi hoac tra ve gia tri mac dinh cua chuc nang do.
'Check xem co User nay hay khong?
if UserName<>"" and FunctionName<>"" then
	sSQL = "SELECT Count(*) as N FROM common..Users WHERE UserName = '" & UserName & "'"
	Dim tmpRst
	Set tmpRst = GetOneRecordset(sSQL)
	if tmpRst("N") = 0 then
		'Khong co User nay
		UserRightofFunction = "USER_NOT_EXIST"
		exit function
	end if
	'Kiem tra xem User co quyen rieng ve chuc nang nay hay khong?
	sSQL = ""
	sSQL = sSQL & "SELECT QuyenGi FROM AiQuyenGi "
	sSQL = sSQL & "LEFT JOIN DMChucNang ON DMChucNang.MaChucNang = AiQuyenGi.MaChucNang "
	sSQL = sSQL & "WHERE IsNhom = 0 AND Ma = '" & UserName & "' AND AiQuyenGi.MaChucNang = '" & FunctionName & "' AND TamNgung = 0"
	Set tmpRst = GetOneRecordset(sSQL)
	if not (tmpRst.EOF and tmpRst.BOF) then
		UserRightofFunction = tmpRst("QuyenGi")
		exit function
	end if

	sSQL = ""
	sSQL = sSQL & "SELECT QuyenGi, Cap FROM AiQuyenGi "
	sSQL = sSQL & "LEFT JOIN DMChucNang ON DMChucNang.MaChucNang = AiQuyenGi.MaChucNang "
	sSQL = sSQL & "LEFT JOIN DMQuyenMD ON DMQuyenMD.TenQuyen = AiQuyenGi.QuyenGi "
	sSQL = sSQL & "WHERE IsNhom = 1 AND Ma IN (SELECT MaNhom FROM AiNhomNao WHERE TenSD = '" & UserName & "') "
	sSQL = sSQL & "AND AiQuyenGi.MaChucNang = '" & FunctionName & "' AND TamNgung = 0 "
	sSQL = sSQL & "ORDER BY CAP DESC"
	Set tmpRst = GetOneRecordset(sSQL)
	if not (tmpRst.EOF and tmpRst.BOF) then
		UserRightofFunction = tmpRst("QuyenGi")
		exit function
	end if
	UserRightofFunction = "USER_NO_RIGHT"
else
	UserRightofFunction = "USERNAME_EMPTY"
end if
End Function

function ShowDate(dDate)
	if dDate="" or isnull(dDate) then
		ShowDate=""
	else
		ShowDate = right("0" & Day(dDate),2) & "/" & right("0" & Month(dDate),2) & "/" & Year(dDate)
	end if
End function

function FirstDateOfWeek(dDate)	
	dim dt, offset
	offset = Weekday(dDate)-2
	dt = dateadd("d",-Cint(offset),dDate)   	
	FirstDateOfWeek = dt
end function

function LastDateOfWeek(dDate)	
	dim dt, offset
	offset = 7 - weekday(dDate) + 1
	dt = dateadd("d",offset,dDate)   	
	LastDateOfWeek = dt
end function

function FirstDateOfMonth(dDate)	
	dim dt
	dt = dateserial(year(dDate),month(dDate),1)   	
	FirstDateOfMonth = dt
end function

function LastDateOfMonth(dDate)	
	Dim dt
   	dt = dateserial(year(dDate),month(dDate)+1,1)
   	dt = dateadd("d",-1,dt)
   	LastDateOfMonth = dt
end function

Function FirstDateOfYear(dDate)		
	FirstDateOfYear = "01/01/" & year(dDate)
end Function

Function LastDateOfYear(dDate)	
	LastDateOfYear = "31/12/" & year(dDate)
end Function

sub Makecbo(Name,strSQL,DefaultValue,value,text,width,optnull, optFuntion)
 	dim conn
 	set Conn = server.createObject("ADODB.connection")
	Conn.Open CONNECTION_STRING

	set rs = server.createObject("ADODB.recordset")            
	set rs = Conn.Execute(strSQL)            
	
	if trim(optFuntion)<>"" then
	Response.Write("<select class='QH_DropDownList' name='" & Name & "' style = 'width:" & width & ";font-family:Arial'" & optFuntion & ">")		
	else	            
	Response.Write("<select class='QH_DropDownList' name='" & Name & "' style = 'width:" & width & ";font-family:Arial'>")
	end if
	If optnull="1" Then
		Response.Write("<option value = ''>")
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

Function DispTinNhan()
	Set Conn = server.createObject("ADODB.connection")
	Conn.Open CONNECTION_STRING
	
	Set rs = server.createObject("ADODB.recordset")
	SQL = "Web_LstTINNHAN @p_Tinhtrang='A'"
	Set rs = Conn.Execute(SQL)
	If Not rs.EOF Then
	'strBlank = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
	strBlank = "<img src='../Images/space.gif' border=0 width=200 height=1>"	
	Do While Not rs.EOF 
		If rs("NgayNhan")<>"" Then
			vitri = InstrRev(rs("NgayNhan"),"/")
			Ngay = "  (" & left(rs("NgayNhan"),vitri-1) & ")"
		Else
			Ngay = ""
		End If
		If DispTinNhan="" Then
			DispTinNhan = rs("Noidung")& Ngay
		Else
			DispTinNhan = DispTinNhan & strBlank & rs("Noidung")& Ngay 
		End If	
		rs.MoveNext
	Loop	
	Else
		DispTinNhan = ""	
	End If
	
	Set rs=Nothing
	Set Conn=Nothing
End Function

Function ReplaceEnterChar(p_String)
	ReplaceEnterChar = replace(p_String,vbCrLf,"<br>")
	'ReplaceEnterChar = replace(replace(p_String,vbCrLf,"<br>")," ","&nbsp;")
End function

%>