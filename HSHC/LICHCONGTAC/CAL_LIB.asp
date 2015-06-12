<head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8"></head>
<%
' chi BGD , CVP va LDP la duoc them moi.
' BGD = Ban giam doc; CVP = Chanh van phong; LDP = lanh dao phong; CV = chuyen vien; VT = van thu.
Session.CodePage = 65001
Dim RSContent (22)
Dim WeekFrom, SelectDay, CalCurrent, Username, Password, Rights, Fullname
Dim isView, isAdd
Set Conn = Server.createObject("ADODB.Connection")
Conn.Open CONNECTION_STRING

Role = Trim(UCase(Session("Role")))
'UserName = Session("UserName") 
UserID = Session("UserID") 

Sub AddOneMeet()
'if Role = CVP or Role = TP or Role = GD or Role = PGD then
	isYN = Request("chkApprove") 
	if isYN = "on" then
		isYN = "Y"
	else 
		isYN = "N"
	end if
	
	SQLcmd = "INSERT INTO Book(BookBy, BookDate, Content, strLocation, ChairManID, ChairMan, JoinMember, MeetingDate, Note, Approved ) " ' Duration,
	SQLcmd = SQLcmd & "VALUES ('" & UserID & "', CONVERT(datetime,'" & DateValueVN(Now()) & " " & TimeValue(Now()) & "',103), N'" & Request("Noidung") & "'"
	SQLcmd = SQLcmd & ", N'" & Request("Diadiem") & "', '" & "NULL" &  "', N'" & Request("cboChairMan") & "',N'" & Request("Thamdu") & "', CONVERT(datetime,'" & Request("Ngayhop") & "',103)"
	SQLcmd = SQLcmd & ", N'" & Request("Ghichu") & "', '" &  isYN & "')"	' '" & Request("Thoigian") & "',
	'Response.Write (SQLcmd)
	'Response.End
	Cal_ExecuteSQL(SQLcmd)
'end if
End Sub

Sub DelOneMeet(delID)
'if Role = CVP or Role = TP or Role = GD or Role = PGD then
	SQLcmd = "DELETE FROM Book WHERE Book_ID IN (" & delID & ") AND BookBy = '" & UserID & "' And Approved = 'N'" 
	Cal_ExecuteSQL(SQLcmd)
'end if
End Sub

Sub CVPDelOneMeet(delID)
'if Role = CVP or Role = TP or Role = GD or Role = PGD then
	SQLcmd = "DELETE FROM Book WHERE Book_ID IN (" & delID & ")" 
	Cal_ExecuteSQL(SQLcmd)
'end if
End Sub

Sub ApproveOneMeet(approvedID)
	'If  Role = CVP Then
		SQLcmd = "UPDATE Book SET "
		SQLcmd = SQLcmd & "Approved = 'Y', " 
		SQLcmd = SQLcmd & "ApprovedBy = '" & UserID & "', "
		SQLcmd = SQLcmd & "ApprovedDate = CONVERT(datetime,'" & DateValueVN(Now()) & " " & TimeValue(Now()) & "', 103)  "
		SQLcmd = SQLcmd & "Where Book_ID IN (" & approvedID & ") AND Approved = 'N'" 
	
		Cal_ExecuteSQL(SQLcmd)
	'End If
End Sub

Sub PostPonseOneMeet(ID)
	If  Role <> CVP Then exit sub
		SQLcmd = "UPDATE Book SET "
		if Request("hPostPonse") = "" then
			SQLcmd = SQLcmd & "PostPonse = null "
		else
			SQLcmd = SQLcmd & "PostPonse = '" & Request("hPostPonse") & "'"
		end if
		
		'SQLcmd = SQLcmd &  "Content = N'"  & Request("Noidung") & "', "
		'SQLcmd = SQLcmd & "Location = N'" & Request("Diadiem") & "', "
		'SQLcmd = SQLcmd & "ChairManID = '" & Request("cboChairMan") & "', "
		'SQLcmd = SQLcmd & "ChairMan = N'" & Request("ChairMan") & "', "
		'SQLcmd = SQLcmd & "JoinMember = N'" & Request("Thamdu") & "', "
		'SQLcmd = SQLcmd & "MeetingDate = CONVERT(datetime,'" & Request("Ngayhop") & "', 103) , "
		'QLcmd = SQLcmd & "Duration = '" & Request("Thoigian") & "', "
		'SQLcmd = SQLcmd & "Note = N'" & Request("Ghichu") & "', "
		
		'SQLcmd = SQLcmd & "ModifiedBy = '" & UserID & "', "
		'SQLcmd = SQLcmd & "ModifiedOn = CONVERT(datetime,'" & DateValueVN(Now()) & " " & TimeValue(Now()) & "', 103)  "
		SQLcmd = SQLcmd & " Where Book_ID = '" & ID & "' AND Approved = 'Y'" 
	
		Cal_ExecuteSQL(SQLcmd)
	
End Sub

Sub UpdateOrder(updateID,iOrder)	
	SQLcmd = "UPDATE Book SET "
	SQLcmd = SQLcmd &  "OrderBy = "  & iOrder
	SQLcmd = SQLcmd &  " WHERE Book_ID = " & updateID
	'Response.Write(SQLcmd)
	'Response.End
	Cal_ExecuteSQL(SQLcmd)	
End Sub

Sub UpdateOneMeet(updateID)	
'if Role = CVP or Role = TP or Role = GD or Role = PGD then

	SQLcmd = "UPDATE Book SET "
	SQLcmd = SQLcmd &  "Content = N'"  & Request("Noidung") & "', "
	SQLcmd = SQLcmd & "strLocation = N'" & Request("Diadiem") & "', "
	'SQLcmd = SQLcmd & "ChairManID = '" & Request("cboChairMan") & "', "
	SQLcmd = SQLcmd & "ChairMan = N'" & Request("cboChairMan") & "', "
	SQLcmd = SQLcmd & "JoinMember = N'" & Request("Thamdu") & "', "
	SQLcmd = SQLcmd & "MeetingDate = CONVERT(datetime,'" & Request("Ngayhop") & "', 103) , "
	'QLcmd = SQLcmd & "Duration = '" & Request("Thoigian") & "', "
	SQLcmd = SQLcmd & "Note = N'" & Request("Ghichu") & "', "
	SQLcmd = SQLcmd & "ModifiedBy = '" & UserID & "', "
	SQLcmd = SQLcmd & "ModifiedOn = CONVERT(datetime,'" & DateValueVN(Now()) & " " & TimeValue(Now()) & "',103) " 

	SQLcmd = SQLcmd & " WHERE Book_ID=" & updateID

	Cal_ExecuteSQL(SQLcmd)	

	If  Role <> CVP and  Role <> GD Then exit sub
	' Update trang thai Hoan
	SQLcmd = "UPDATE Book SET "
	
	if Request("hPostPonse") = "" then
		SQLcmd = SQLcmd & "PostPonse = null "
	else
		SQLcmd = SQLcmd & "PostPonse = '" & Request("hPostPonse") & "'"
	end if	
	SQLcmd = SQLcmd & " Where Book_ID = '" & updateID & "' AND Approved = 'Y'" 
	Cal_ExecuteSQL(SQLcmd)	
	
	' Update trang thai Duyet
	If Request("hApprove") <> "" then ApproveOneMeet(updateID) end if
'end if 
End Sub

Function ViewOneMeet(viewID)
	SQLcmd = "SELECT Book.* FROM Book WHERE Book_ID=" & viewID

	Set rs = Server.CreateObject("ADODB.Recordset")
	rs.Open SQLcmd, Conn
	
	Set ViewOneMeet = rs
End Function

Function ViewMeet(FromDay)
		
	SQLcmd = "SELECT B.*, U.FullName, U.Role_ID FROM Book B, common..Users U "
	SQLcmd = SQLcmd & "Where U.User_ID = B.BookBy "
	SQLcmd = SQLcmd & " and CONVERT(Char, MeetingDate, 103) = '" & DateValueVN(FromDay) & "'"
	
	if Request("Diadiem_flt")<>"" then
		SQLcmd = SQLcmd & " AND strLocation LIKE N'%" & Request("Diadiem_flt") & "%'"
	end if
	if Request("ChuTri_flt")<>"" then
		SQLcmd = SQLcmd & " AND ChairMan LIKE N'%" & Request("ChuTri_flt") & "%'"
	end if
	if Request("Ten_flt")<>"" then
		SQLcmd = SQLcmd & " AND (JoinMember LIKE '%" & Request("Ten_flt") & "%')"
	end if
	SQLcmd = SQLcmd & " ORDER BY MeetingDate ASC"
	
	'Response.Write SQLcmd
	'Response.End
	
	Set rs = Server.CreateObject("ADODB.Recordset")
	rs.Open SQLcmd, Conn

	Set ViewMeet = rs
End Function

Function ViewMeetY(FromDay )
	
	SQLcmd = "SELECT B.*, U.FullName, U.Role_ID FROM Book B, common..Users U "
	SQLcmd = SQLcmd & "Where U.User_ID = B.BookBy "
	SQLcmd = SQLcmd & " And CONVERT(Char, MeetingDate, 103) = '" & DateValueVN(FromDay) & "'"
	SQLcmd = SQLcmd & " And Approved = 'Y' "
	
	if Request("Diadiem_flt")<>"" then
		SQLcmd = SQLcmd & " AND strLocation LIKE N'%" & Request("Diadiem_flt") & "%'"
	end if
	if Request("ChuTri_flt")<>"" then
		SQLcmd = SQLcmd & " AND ChairMan LIKE N'%" & Request("ChuTri_flt") & "%'"
	end if
	if Request("Ten_flt")<>"" then
		SQLcmd = SQLcmd & " AND (JoinMember LIKE '%" & Request("Ten_flt") & "%')"
	end if
	SQLcmd = SQLcmd & " ORDER BY OrderBy, MeetingDate"
	'Response.Write SQLcmd
	Set rs = Server.CreateObject("ADODB.Recordset")
	rs.Open SQLcmd, Conn

	Set ViewMeetY = rs
End Function

Function ViewMeetPB(FromDay )
		
	if trim(Request("FIRSTNAME")) <> "" then 
		if trim(Request("USER_ID")) = "0000000043" then 'Giam Doc
			SQLcmd = "select *,U.FullName,U.Role_ID from book B"
			SQLcmd = SQLcmd & " inner join common..Users U on U.User_ID = B.BookBy "
			
			SQLcmd = SQLcmd & " WHERE (B.ChairMan LIKE N'" & Request("ROLENAME") & "%'" & " OR B.ChairMan LIKE N'% " & Request("ROLENAME") & "%'" &  " OR B.Content LIKE N'" & Request("ROLENAME") & "%'" &  "OR B.Content LIKE N'% " & Request("ROLENAME") & "%'"
			
			SQLcmd = SQLcmd & " OR B.ChairMan LIKE N'" & Request("ROLENAME2") & "%'" & " OR B.ChairMan LIKE N'% " & Request("ROLENAME2") & "%'" &  " OR B.Content LIKE N'" & Request("ROLENAME2") & "%'" &  "OR B.Content LIKE N'% " & Request("ROLENAME2") & "%')"
			
			SQLcmd = SQLcmd & " And CONVERT(Char, MeetingDate, 103) = '" & DateValueVN(FromDay) & "'"
			SQLcmd = SQLcmd & " And Approved = 'Y' "
		else
			SQLcmd = "select *,U.FullName,U.Role_ID from book B"
			SQLcmd = SQLcmd & " inner join common..Users U on U.User_ID = B.BookBy "
			SQLcmd = SQLcmd & " WHERE (B.ChairMan LIKE N'%" & Request("ROLENAME") & "%" & trim(Request("FIRSTNAME")) & "%'" & "OR B.Content LIKE N'%" & Request("ROLENAME") & "%"  & trim(Request("FIRSTNAME")) & "%')"
			SQLcmd = SQLcmd & " And CONVERT(Char, MeetingDate, 103) = '" & DateValueVN(FromDay) & "'"
			SQLcmd = SQLcmd & " And Approved = 'Y' "
		end if			
	else
		SQLcmd = "select *,U.FullName,U.Role_ID from book B"
		SQLcmd = SQLcmd & " inner join common..Users U on U.User_ID = B.BookBy "
		SQLcmd = SQLcmd & " WHERE B.JoinMember LIKE '%P." & trim(Request("Dep_ID")) & "%'"
		SQLcmd = SQLcmd & " And CONVERT(Char, MeetingDate, 103) = '" & DateValueVN(FromDay) & "'"
		SQLcmd = SQLcmd & " And Approved = 'Y' "		
    end if
	
	
	if Request("Diadiem_flt")<>"" then
		SQLcmd = SQLcmd & " AND strLocation LIKE N'%" & Request("Diadiem_flt") & "%'"
	end if
	if Request("ChuTri_flt")<>"" then
		SQLcmd = SQLcmd & " AND ChairMan LIKE N'%" & Request("ChuTri_flt") & "%'"
	end if
	if Request("Ten_flt")<>"" then
		SQLcmd = SQLcmd & " AND (JoinMember LIKE '%" & Request("Ten_flt") & "%')"
	end if
	SQLcmd = SQLcmd & " ORDER BY MeetingDate ASC"
	
	'Response.Write(SQLcmd)
	'Response.End
	
	Set rs = Server.CreateObject("ADODB.Recordset")
	rs.Open SQLcmd, Conn

	Set ViewMeetPB = rs
End Function

'These funtions don't use now
Function GetBanTin(FromDay)
	SQLcmd = "SELECT Tin, Tuanle FROM BanTin WHERE CONVERT(Char,Tuanle,103) = '" & DateValueVN(FromDay) & "'"
	SQLcmd = SQLcmd & " ORDER BY Tuanle DESC"
	
	Set rs = Server.CreateObject("ADODB.Recordset")
	rs.Open SQLcmd, Conn

	Set GetBanTin = rs
End Function

Sub AddBanTin(Tin,FromDay)

	if Role = ADMIN then 'Chi thuc hien chuc nang nay khi user dang dung la admin
		SQLcmd = "INSERT INTO BanTin VALUES ('" & Tin & "', '" & FromDay & "')"
		Cal_ExecuteSQL(SQLcmd)
	end if
End Sub

Sub DelBanTin(FromDay)
	if Role = ADMIN then 'Chi thuc hien chuc nang nay khi user dang dung la admin
		SQLcmd = "DELETE FROM BanTin WHERE Tuanle = '" & FromDay & "'"
		Cal_ExecuteSQL(SQLcmd)
	end if
End Sub
'--------------------------------------------------------------------'
%>

<%

'Const CONNECTION_STRING = "driver={SQL SERVER};Server=hoaBQ;Database=Webnoibo;UID=sa;PWD=;"
'Const FontName="Verdana,Tahoma,Arial,.VnTime,.VnArial,VNI-Times"

NgayVN = Array("Hai","Ba","Tu","Nam","Sau","Bay","CN")
ThangVN = Array("","Tháng một","Tháng hai","Tháng ba","Tháng tư","Tháng năm","Tháng sáu","Tháng bảy","Tháng tám","Tháng chín","Tháng mười","Tháng mười một","Tháng mười hai")
BuoiVN = Array("AM","PM")

'Set Conn = Server.CreateObject("ADODB.Connection")
'Conn.Open CONNECTION_STRING

'------------------Database Functions--------------------------------

Sub Cal_ExecuteSQL(strSQL)
	Set cmd = Server.CreateObject("ADODB.Command")
	Set cmd.ActiveConnection = Conn
	cmd.CommandText = strSQL
	cmd.Execute
	Set cmd = nothing
End Sub

Function GetOneRecordset(strSQL)
	Set cmd = Server.CreateObject("ADODB.Command")
	Set cmd.ActiveConnection = Conn
	cmd.CommandText = strSQL

	Set GetOneRecordset = cmd.Execute
End Function

'-----------------------Mics Functions-------------------------------

sub DelOneFile(fpath,fname)
	Dim ScriptObject
	Set ScriptObject = Server.CreateObject("Scripting.FileSystemObject")
	if ScriptObject.FileExists (fpath & "\" & fname) then
		ScriptObject.DeleteFile fpath & "\" & fname
	end if
	Set ScriptObject = nothing
end sub

function CutStr(str,nlen)
	if len(str)>nlen then
		CutStr = left(str,nlen) & "..."
	else
		CutStr = str
	end if
end function

function GenZeroNum(num,nlenstr)
	s = string(nlenstr,"0")
	if len(num)<nlenstr then
		s = left(s,nlenstr-len(num)) & num
	end if
	GenZeroNum = s
end function

Function StrConVert(m_str)
Dim i, j
Dim ch1, ch2, str
    m_str = " " & m_str
    For i = 1 To Len(m_str)
        j = i + 1
        ch1 = Mid(m_str, j, 1)
        ch2 = Mid(m_str, i, 1)
        If (ch1 <> " " And ch2 = " ") Then
            Select Case ch1
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case Else
                    If ch1 >= "a" And ch1 <= "z" Then ch1 = UCase(ch1)
                    str = str & ch1
            End Select
        Else
            Select Case ch1
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case "?"
                    str = str & "?"
                Case Else
                    If ch1 >= "A" And ch1 <= "Z" Then ch1 = LCase(ch1)
                    str = str & ch1
            End Select
        End If
    Next
    StrConVert = Trim(str)
End Function

Function SpaceEncode(str)
	Dim strNew
	strNew=""
	for indexstrNew=1 to Len(Str)
		c=mid(str,indexstrNew,1)
		if c=" " then
			strNew=strNew & "&nbsp;"
		else
			strNew=strNew & c
		End if
	Next
	SpaceEncode=strNew
End Function

'-------------------Datetime Functions--------------------------------

Function StringTime()
	Dim s
	s = ""
	if Day(Now)<10 then	s = s & "0" & Day(Now) else s = s & Day(Now)
	if Month(Now)<10 then s = s & "0" & Month(Now) else s = s & Month(Now)
	s = s & Year(Now)
	if Hour(Now)<10 then s = s & "0" & Hour(Now) else s = s & Hour(Now)
	if Minute(Now)<10 then s = s & "0" & Minute(Now) else s = s & Minute(Now)
	if Second(Now)<10 then s = s & "0" & Second(Now) else s = s & Second(Now)
	StringTime = s
End Function

Function TimeValueVN(conDate,style)
	t1 = Hour(conDate)
	t2 = Minute(conDate)
	t3 = ""
	if style=12 then
		if t1>12 then
			t3 = BuoiVN(1) 'Buoi chieu
			t1 = t1 - 12
		else
			t3 = BuoiVN(0) 'Buoi Sang
		end if
	elseif style=24 then
		if t2<10 then t2 = "0" & t2
	end if

	TimeValueVN = t1 & ":" & t2 & " " & t3
End Function

Function DateValueVN(conDate)
	if Day(conDate)<10 then
		p1 = "0" & Day(conDate)
	else
		p1 = Day(conDate)
	end if
	if Month(conDate)<10 then
		p2 = "0" & Month(conDate)
	else
		p2 = Month(conDate)
	end if

	DateValueVN =  p1 & "/" & p2 & "/" & Year(conDate)
End Function

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

Function GetCureNTDate()
	strDay = Day(Date)
	strMonth = Month(Date)
	strYear = Year(Date)
	if strDay < 10 then strDay = "0" & strDay
	if strMonth < 10 then strMonth = "0" & strMonth
	GetCureNTDate = strDay & strMonth & strYear
End Function

Function GetDaysInMonth(iMonth, iYear)
	Dim dTemp
	dTemp = DateAdd("d", -1, DateSerial(iYear, iMonth + 1, 1))
	GetDaysInMonth = Day(dTemp)
End Function

Function GetWeekdayMonthStartsOn(dAnyDayInTheMonth)
	Dim dTemp
	dTemp = DateAdd("d", -(Day(dAnyDayInTheMonth) - 1), dAnyDayInTheMonth)
	GetWeekdayMonthStartsOn = WeekDay(dTemp)
End Function

Function SubtractOneMonth(dDate)
	SubtractOneMonth = DateAdd("m", -1, dDate)
End Function

Function SubtractOneYear(dDate)
	SubtractOneYear = DateAdd("yyyy", -1, dDate)
End Function

Function AddOneMonth(dDate)
	AddOneMonth = DateAdd("m", 1, dDate)
End Function

Function AddOneYear(dDate)
	AddOneYear = DateAdd("yyyy", 1, dDate)
End Function

Function AddMeetTime(dDate,strTimeAdd)
	Dim dTmp
	Dim t
	t = split(strTimeAdd,",")
	dHour = CByte(t(0))
	dMinute = CByte(t(1))
	'dDay = CByte(t(2))
	Set t = nothing

	dTmp = dDate
	dTmp = DateAdd("h", dHour, dTmp)
	dTmp = DateAdd("n", dMinute, dTmp)
	dTmp = DateAdd("d", dDay, dTmp)
	AddMeetTime=dTmp
End Function


Function GetFullNameUser(UserID)
	sSQL = "SELECT FullName  FROM common..Users WHERE User_ID = '" & UserID & "'"
	Dim tmpRst
	set tmpRst = GetOneRecordset(sSQL)
	if not(tmpRst.BOF and tmpRst.EOF) then
		GetFullNameUser = tmpRst("FullName")
		exit Function
	end if
	GetFullNameUser = ""
End Function

Function GetDeptID(UserName)
	sSQL = "SELECT Dep_ID FROM common..Users WHERE UserName = '" & UserName & "'"
	Dim tmpRst
	set tmpRst = GetOneRecordset(sSQL)
	if not(tmpRst.BOF and tmpRst.EOF) then
		GetDeptID = tmpRst("Dep_ID")
		exit Function
	end if
	GetDeptID = ""
End Function

%>

<%
Function getFullName(sUserID)
	strSQL = "SELECT FULLNAME FROM common..USERS WHERE USER_ID = '" & sUserID & "'"
	getFullName = GetOneRecordset(strSQL)("FULLNAME")
End Function

Function getFirstName(str)
	dim MyArr
	MyArr = split(str," ")
	getFirstName = MyArr(ubound(MyArr))
End Function



Function getDeptName(sDeptID)
	strSQL = "SELECT DEPARTMENTNAME FROM DEPARTMENTS WHERE DEP_ID = '" & sDeptID & "'"
	getDeptName = GetOneRecordset(strSQL)("DEPARTMENTNAME")
End Function
%>
