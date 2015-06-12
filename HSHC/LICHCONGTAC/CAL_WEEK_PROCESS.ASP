<!--#include file = "INC/Lib.asp"-->
<!--#include file = "security.asp"-->
<HEAD>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</HEAD>
<%
			dim conn
			dim Err
			set conn = server.CreateObject("ADODB.Connection")
			
			conn.Open CONNECTION_STRING
			
			strAction		=	request("hAction")
			
			strChucTho		=	request("cboChucTho")
			strBookID		=	request("hBookID")
			strBookBy		=	session("UserID")
			strLocationID	=	request("cboLocation")
			strLocation		=	replace(request("txtLocation"),"'","''")
			strContent		=	replace(request("txtContent"),"'","''")
			strMeetingDate	=	request("txtMeetingDate") 
			if request("cboHour")<>"" then strMeetingDate = strMeetingDate & " " & request("cboHour") & ":" & request("cboMinute")
			strDep_ID		=	request("hMemberJoin")
			strMemberJoin	=	replace(request("txtMemberJoin"),"'","''")
			strChairManID	=	request("cboChairMan")
			strChairMan		=	request("hChairMan")
			strNote			=	replace(request("txtNote"),"'","''")
			strType			=	request("cboType")	
			strDuration		=	request("txtDuration")
			if request("chkNgoaiLich") <> "" then
				strNgoaiLich	=	"1"
			else
				strNgoaiLich	=	"0"
			end if
			
			'Cap nhat so thu tu
			strSTT = request("txtStt")
			strOrderType = request("OrderAction")
			
			'iif(request("chkNgoaiLich") <> "", "1", "0")
			'Response.Write strAction & "," & strBookBy
			'Response.End
	SELECT CASE UCASE(strAction)
		CASE "ADDNEW"			
			Call AddNew(strBookBy, strContent, strLocationID, strLocation, strMeetingDate,strDuration,strDep_ID, strMemberJoin, strChairManID, _
						strChairMan, strNote, "","","N","","","",strType,strChucTho,strBookBy,strNgoaiLich, strSTT) 
			Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE "CV_ADDNEW"
			dim rs
			set rs=server.CreateObject("ADODB.Recordset")
			
			strFromDate		=	request("txtFromDate")
			strToDate		=	request("txtToDate")
			
			strSQL = "Book_GetTime "			
			strSQL = strSQL & "@p_ChairManID = '" & strChairManID & "',"
			strSQL = strSQL & "@p_Duration = '" & strDuration & "',"
			strSQL = strSQL & "@p_FromDate = '" & strFromDate & "',"
			strSQL = strSQL & "@p_ToDate = '" & strToDate & "'"
						
			set rs = conn.Execute(strSQL)
			
			if rs("Time")<>"" then
				Call AddNew(strBookBy, strContent, strLocationID, strLocation, rs("Time"),strDuration,strDep_ID, strMemberJoin, strChairManID, _
						strChairMan, strNote, "","","N","","","",strType,strChucTho,strBookBy,strNgoaiLich, strSTT) 
				Response.Redirect "CAL_WEEK_LIST.ASP"
			else
				Response.Redirect "Result.asp?ErrID=00022"
			end if
			'Response.Write(rs("Time"))
			'esponse.End
			'strFromDate		= request("hFromDate")
			'Call CV_AddNew(strFromDate, strBookBy, strContent, strMeetingDate,strDuration ,strDep_ID, strMemberJoin, strChairManID, _
			'			strChairMan, strNote,strType,strChucTho,strBookBy) 
			'Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE "APPROVED_ADDNEW"
			Err = CheckValidByContent(strMeetingDate, strChairManID, strLocationID, strType)			
			IF Err = "0" then
				Call AddNew(strBookBy, strContent, strLocationID, strLocation, strMeetingDate,strDuration,strDep_ID, strMemberJoin, strChairManID, _
							strChairMan, strNote, "","","Y","","","",strType,strChucTho,strBookBy,strNgoaiLich, strSTT) 			
				Response.Redirect request("hBack") & "?" & request("hQuery")
			ELSE
				Response.Redirect "Result.asp?ErrID=" & Err & "&hQuery=" & server.URLEncode(request("hQuery"))
			END IF
		CASE "UPDATE"			
			Call Update(strBookID,strBookBy, strContent, strLocationID, strLocation, strMeetingDate,strDuration,strDep_ID, strMemberJoin, strChairManID, _
						strChairMan, strNote, "","","N","","","",strType,strChucTho,strBookBy,strNgoaiLich, strSTT) 
			Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE "APPROVED_UPDATE"			
			'Err = CheckValidByContent(strMeetingDate, strChairManID, strLocationID, strType)			
			'IF Err = "0" then
				Call Update(strBookID,strBookBy, strContent, strLocationID, strLocation, strMeetingDate,strDuration,strDep_ID, strMemberJoin, strChairManID, _
							strChairMan, strNote, "","","","","","",strType,strChucTho,strBookBy,strNgoaiLich, strSTT) 
				Response.Redirect request("hBack") & "?" & request("hQuery")
			'ELSE
				'Response.Redirect "Result.asp?ErrID=" & Err & "&hQuery=" & server.URLEncode(request("hQuery"))
			'END IF
		CASE "APPROVE"		
			Err = CheckValid(strBookID)
			if Err = "0" then
				call Approve(strBookID, session("UserID"))			
				Response.Redirect request("hBack") & "?" & request("hQuery")
			else
				Response.Redirect "Result.asp?ErrID=" & Err & "&hQuery=" & server.URLEncode(request("hQuery"))
			end if
		CASE "NOTAPPROVE"			
			call NotApprove(strBookID)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE "DELETE"			
			call Delete(strBookID)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE "POSTPONSE"			
			call Postponse(strBookID)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE "UPDORDER"
			call updOrder(strBookID, strSTT, strOrderType)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE ELSE
			Response.Redirect "CAL_WEEK_LIST.ASP"
	END SELECT
%>

<%
	sub AddNew(p_BookBy,p_Content, p_LocationID ,p_Location,p_MeetingDate,p_Duration,p_Dep_ID,p_JoinMember,p_ChairManID,p_ChairMan,p_Note, _
		p_AssignTo,p_OthersAssign,p_Approved, p_ApprovedBy,p_ApprovedDate,p_PostPonse, p_Type,p_ChucTho,p_ModifiedBy, p_strNgoaiLich, p_strStt)
		
		dim strSQL
		
		strSQL = "Book_Ins "
		strSQL = strSQL & "@p_BookBy = '" & p_BookBy & "',"
		strSQL = strSQL & "@p_Content = N'" & p_Content & "',"
		strSQL = strSQL & "@p_LocationID = '" & p_LocationID & "',"
		strSQL = strSQL & "@p_Location = N'" & p_Location & "',"
		strSQL = strSQL & "@p_MeetingDate = '" & p_MeetingDate & "',"
		strSQL = strSQL & "@p_Duration = '" & p_Duration & "',"
		strSQL = strSQL & "@p_Dep_ID = '" & p_Dep_ID & "',"
		strSQL = strSQL & "@p_JoinMember = N'" & p_JoinMember & "',"
		strSQL = strSQL & "@p_ChairManID = '" & p_ChairManID & "',"
		strSQL = strSQL & "@p_ChairMan = N'" & p_ChairMan & "',"
		strSQL = strSQL & "@p_Note = N'" & p_Note & "',"
		strSQL = strSQL & "@p_AssignTo = '" & p_AssignTo & "',"
		strSQL = strSQL & "@p_OthersAssign = '" & p_OthersAssign & "',"
		strSQL = strSQL & "@p_Approved = '" & p_Approved & "',"
		strSQL = strSQL & "@p_ApprovedBy = '" & p_ApprovedBy & "',"
		strSQL = strSQL & "@p_ApprovedDate = '" & p_ApprovedDate & "',"
		strSQL = strSQL & "@p_PostPonse = '" & p_PostPonse & "',"
		strSQL = strSQL & "@p_Type = '" & p_Type & "',"
		strSQL = strSQL & "@p_ChucTho = '" & p_ChucTho & "',"
		strSQL = strSQL & "@p_ModifiedBy = '" & p_ModifiedBy & "',"
		strSQL = strSQL & "@p_NgoaiLich = '" & p_strNgoaiLich & "'"',"
		'strSQL = strSQL & "@p_Stt = " & p_strStt 
				
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)
	end sub
%>

<%
	sub Update(p_BookID, p_BookBy,p_Content, p_LocationID ,p_Location,p_MeetingDate,p_Duration,p_Dep_ID,p_JoinMember,p_ChairManID,p_ChairMan,p_Note, _
		p_AssignTo,p_OthersAssign,p_Approved, p_ApprovedBy,p_ApprovedDate,p_PostPonse, p_Type,p_ChucTho,p_ModifiedBy, p_strNgoaiLich, p_strStt)
		
		dim strSQL
		
		strSQL = "Book_Upd "		
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"
		strSQL = strSQL & "@p_BookBy = '" & p_BookBy & "',"
		strSQL = strSQL & "@p_Content = N'" & p_Content & "',"
		strSQL = strSQL & "@p_LocationID = '" & p_LocationID & "',"
		strSQL = strSQL & "@p_Location = N'" & p_Location & "',"
		strSQL = strSQL & "@p_MeetingDate = '" & p_MeetingDate & "',"
		strSQL = strSQL & "@p_Duration = '" & p_Duration & "',"
		strSQL = strSQL & "@p_Dep_ID = '" & p_Dep_ID & "',"
		strSQL = strSQL & "@p_JoinMember = N'" & p_JoinMember & "',"
		strSQL = strSQL & "@p_ChairManID = '" & p_ChairManID & "',"
		strSQL = strSQL & "@p_ChairMan = N'" & p_ChairMan & "',"
		strSQL = strSQL & "@p_Note = N'" & p_Note & "',"
		strSQL = strSQL & "@p_AssignTo = '" & p_AssignTo & "',"
		strSQL = strSQL & "@p_OthersAssign = '" & p_OthersAssign & "',"
		strSQL = strSQL & "@p_Approved = '" & p_Approved & "',"
		strSQL = strSQL & "@p_ApprovedBy = '" & p_ApprovedBy & "',"
		strSQL = strSQL & "@p_ApprovedDate = '" & p_ApprovedDate & "',"
		strSQL = strSQL & "@p_PostPonse = '" & p_PostPonse & "',"
		strSQL = strSQL & "@p_Type = '" & p_Type & "',"
		strSQL = strSQL & "@p_ChucTho = '" & p_ChucTho & "',"
		strSQL = strSQL & "@p_ModifiedBy = '" & p_ModifiedBy & "',"
		strSQL = strSQL & "@p_NgoaiLich = '" & p_strNgoaiLich & "'"',"
		'strSQL = strSQL & "@p_Stt = " & p_strStt 
		
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)
	end sub
%>

<%
	sub Approve(p_BookID,p_ApprovedBy)
		
		dim strSQL
		
		strSQL = "Book_Approved "		
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"		
		strSQL = strSQL & "@p_Approved = 'Y',"
		strSQL = strSQL & "@p_ApprovedBy = '" & p_ApprovedBy & "'"		
		
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)
	end sub
	
	sub NotApprove(p_BookID)
		
		dim strSQL
		
		strSQL = "Book_Approved "		
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"		
		strSQL = strSQL & "@p_Approved = 'N'"		
		
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)
	end sub
	
	sub Postponse(p_BookID)
		
		dim strSQL
		
		strSQL = "Book_Postponse "		
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"		
		strSQL = strSQL & "@p_Postponse = 'D'"		
		
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)
	end sub

	function CheckValid(p_BookID)
		dim rs
		dim strSQL
		set rs = server.CreateObject("ADODB.recordset")
		
		strSQL = "Comm_CheckBook "
		strSQL =strSQL & "@p_BookID = '" & p_BookID & "'"
		
		'Response.Write strSQL
		'Response.End
		
		set rs = conn.Execute(strSQL)
		CheckValid = rs("Result")
		set rs=nothing
	end function
	
	function CheckValidByContent(p_MeetingDate, p_ChairManID, p_LocationID, p_Type)
		dim rs
		dim strSQL
		set rs = server.CreateObject("ADODB.recordset")
		
		strSQL = "Comm_CheckBookByContent "
		strSQL =strSQL & "@p_MeetingDate = '" & p_MeetingDate & "',"
		strSQL =strSQL & "@p_ChairManID = '" & p_ChairManID & "',"
		strSQL =strSQL & "@p_LocationID = '" & p_LocationID & "',"
		strSQL =strSQL & "@p_Type = '" & p_Type & "'"
		
		set rs = conn.Execute(strSQL)
		CheckValidByContent = rs("Result")
		set rs=nothing
	end function
	
	sub Delete(p_BookID)
		dim strSQL
		
		strSQL = "Book_Del "
		strSQL =strSQL & "@p_Book_ID = '" & p_BookID & "'"
		conn.Execute(strSQL)
	end sub
	
	sub CV_AddNew(p_FromDate,p_BookBy,p_Content,p_MeetingDate,p_Duration,p_Dep_ID,p_JoinMember,p_ChairManID,p_ChairMan, _
		p_Note,	p_Type,	p_ChucTho,	p_ModifiedBy)
		
		dim strSQL
		
		strSQL = "CV_Book_Ins "		
		
		strSQL = strSQL & "@p_FromDate = '" & p_FromDate & "',"
		strSQL = strSQL & "@p_BookBy = '" & p_BookBy & "',"
		strSQL = strSQL & "@p_Content = N'" & p_Content & "',"
		strSQL = strSQL & "@p_MeetingDate = '" & p_MeetingDate & "',"
		strSQL = strSQL & "@p_Duration = '" & p_Duration & "',"
		strSQL = strSQL & "@p_Dep_ID = '" & p_Dep_ID & "',"
		strSQL = strSQL & "@p_JoinMember = N'" & p_JoinMember & "',"
		strSQL = strSQL & "@p_ChairManID = '" & p_ChairManID & "',"
		strSQL = strSQL & "@p_ChairMan = N'" & p_ChairMan & "',"
		strSQL = strSQL & "@p_Note = N'" & p_Note & "',"
		strSQL = strSQL & "@p_Type = '" & p_Type & "',"
		strSQL = strSQL & "@p_ChucTho = '" & p_ChucTho & "',"
		strSQL = strSQL & "@p_ModifiedBy = '" & p_ModifiedBy & "'"		
			
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)		
	end sub
	
'Cap nhat thu tu in lich cong tac
sub updOrder(p_BookID, p_curPos, p_sortType)
	dim strSQL
		strSQL = "Book_Upd_Order "		
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"
		strSQL = strSQL & "@p_curPos = '" & p_curPos & "',"
		strSQL = strSQL & "@p_sortType = '" & p_sortType & "'"
	'Response.Write strSQL
	'Response.End
	conn.Execute(strSQL)
end sub
%>
