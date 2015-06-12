	<!-- #include file = "inc/Lib.asp"-->
<%
Set oConn = Server.CreateObject("ADODB.Connection")
oConn.Open CONNECTION_STRING
set session("oRs") = Server.CreateObject("ADODB.Recordset")
set session("oRssubA") = Server.CreateObject("ADODB.Recordset")

session("oRssubA").ActiveConnection = oConn
session("oRs").ActiveConnection = oConn
	strLocation		=	request("Location")
	strChairMan		=	request("ChairMan")
	strDK			= 	Request("DK")
	
	IF Request("DK") = "" then
		strDK = "Y"
	else
		strDK = "N"
	end if
	
	if Request("FromDay")="" then
		strFromDay = DateValue(Now())
	else
		strFromDay = DateValue(Request("FromDay"))
		'strFromDay = Request("FromDay")
	end if		
	strFromDay = DateValue(day(strFromDay) & "/" & month(strFromDay) & "/" & year(strFromDay))	
	
	if Weekday(strFromDay) = 1 then
		WeekFrom = DateValue(strFromDay + 1)
	else
		WeekFrom = DateValue(strFromDay - Weekday(strFromDay) + 2 )
	end if
	
	strToday= DateValueVN(DateAdd("d",MaxNgay - 1,WeekFrom))

	WeekFrom = DateValueVN(WeekFrom)
	
	'strToDay	= Request("ToDay")		
	'Response.Write WeekFrom
	'Response.End
	'************************************
	
	
	strSQL = "Rpt_Lichlamviec " &_
		"@FromDay	= '"& WeekFrom & "'," &_
		"@Location	= '" & strLocation &"'," &_
		"@ChairMan	= '" & strChairMan &"'" 
	strsubSQL = "Rpt_SubLichlamviec " &_
		"@FromDay	= '"& WeekFrom & "'," &_
		"@Location	= '" & strLocation &"'," &_
		"@ChairMan	= '" & strChairMan &"'" 
	
		
	
	
session("oRs").Open strSQL
session("oRssubA").Open strsubSQL

reportname 	= "report\rpt_LichCongTac.rpt"
subreportnameA 	= "rpt_LichCongTac_NgoaiLich.rpt"

If Not IsObject (session("oApp")) Then                              
Set session("oApp") = Server.CreateObject("CrystalRuntime.Application")
End If                                                                

' CREATE THE REPORT OBJECT                                     
'                                                                     
'The Report object is created by calling the Application object's OpenReport method.

Path = Request.ServerVariables("PATH_TRANSLATED")                     
While (Right(Path, 1) <> "\" And Len(Path) <> 0)                      
iLen = Len(Path) - 1                                                  
Path = Left(Path, iLen)                                               
Wend                                                                  
                                                                      

'OPEN THE REPORT (but destroy any previous one first)

If IsObject(session("oRpt")) then
	Set session("oRpt") = nothing
End if

Set session("oRpt") = session("oApp").OpenReport(path & reportname, 1)
Set session("oRptsubA") = session("oRpt").OpenSubreport(subreportnameA)


'This line uses the "PATH" and "reportname" variables to reference the Crystal
'Report file, and open it up for processing.
'
'Notice that we do not create the report object only once.  This is because
'within an ASP session, you may want to process more than one report.  The
'rptserver.asp component will only process a report object named session("oRpt").
'Therefor, if you wish to process more than one report in an ASP session, you
'must open that report by creating a new session("oRpt") object.

session("oRpt").MorePrintEngineErrorMessages = False
session("oRpt").EnableParameterPrompting = False


session("oRpt").DiscardSavedData
set Database = session("oRpt").Database
set DatabasesubA = session("oRptsubA").Database
'Instantiates a database collection which references the database(s) used in the report.

set Tables = Database.Tables
set TablessubA 	= DatabasesubA.Tables
'Instantiates a Tables collection which references the Tables of the Database object.

set Table1 = Tables.Item(1)
set Table1subA 	= TablessubA.Item(1)
'Instantiates a table object which references the first table used in the report.
'In this case this table object currently refers to the ADORecordset.ttx file.

Table1.SetPrivateData 3, session("oRs")
Table1subA.SetPrivateData 3, session("oRssubA")

'The "SetPrivateData" line tells the report that it datasource is now the recordset
'Now the report will display the data contained in the session("oRs") record set.
'If your report contained a subreport that was based off this or a different reordset
'you must follow the same steps above only referencing the subreport object.
'
'
'======================================================================================
'Defining the Selection Formula
'======================================================================================
'response.write strFromday 

'strFromday = DateValueVN(WeekFrom)
'strToday= DateValueVN(DateAdd("d",5,WeekFrom))
strFromday = WeekFrom
'strToday= DateValueVN(DateAdd("d",5,DateValue(WeekFrom)))

session("oRpt").FormulaFields.Item(1).text = "'" & strFromday & "'"
session("oRpt").FormulaFields.Item(2).text = "'" & strToday & "'"


On Error Resume Next                                                  
session("oRpt").ReadRecords                                           
If Err.Number <> 0 Then                                               
  Response.Write "An Error has occured on the server in attempting to access the data source"
Else

  If IsObject(session("oPageEngine")) Then                              
  	set session("oPageEngine") = nothing
  End If
set session("oPageEngine") = session("oRpt").PageEngine
End If                                                                

viewer = Request.Form("Viewer")
viewer = "ActiveX"
'This line collects the value passed for the viewer to be used, and stores
'it in the "viewer" variable.

If cstr(viewer) = "ActiveX" then
%>
<!-- #include file="webcomponentreport/SmartViewerActiveX.asp" -->
<%
ElseIf cstr(viewer) = "Netscape Plug-in" then
%>
<!-- #include file="webcomponentreport/ActiveXPluginViewer.asp" -->
<%
ElseIf cstr(viewer) = "Java using Browser JVM" then
%>
<!-- #include file="webcomponentreport/SmartViewerJava.asp" -->
<%
ElseIf cstr(viewer) = "Java using Java Plug-in" then
%>
<!-- #include file="webcomponentreport/JavaPluginViewer.asp" -->
<%
ElseIf cstr(viewer) = "HTML Frame" then
	Response.Redirect("webcomponentreport/htmstart.asp")
Else
	Response.Redirect("webcomponentreport/rptserver.asp")
End If
'The above If/Then/Else structure is designed to test the value of the "viewer" varaible
'and based on that value, send down the appropriate Crystal Smart Viewer.
%>