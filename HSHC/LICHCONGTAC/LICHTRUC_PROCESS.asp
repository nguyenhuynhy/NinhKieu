<!--#include file="inc\lib.asp"-->
<%

	dim conn	
	SET conn = server.CreateObject("ADODB.Connection")
	
	conn.Open CONNECTION_STRING

	strAction		=	request("haction")
	strBookID		=	request("hBookID")
	strNgayTruc		=	request("txtNgayTruc")
	strBuoi			=	request("cboBuoi")
	strNguoiTrucID	=	request("cboNguoiTruc")
	strNguoiTruc	=	request("txtNguoiTruc")
	strDonVi		=	request("cboDonVi")
	strChucVu		=	request("txtChucVu")
	strModifiedBy	=	session("UserID")
	
	SELECT CASE UCASE(strAction)
		Case "ADDNEW"
			call AddNew(strNgayTruc, strBuoi, strNguoiTrucID, strNguoiTruc, strDonVi, strChucVu, strModifiedBy)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		Case "UPDATE"
			call Update(strBookID, strNgayTruc, strBuoi, strNguoiTrucID, strNguoiTruc, strDonVi, strChucVu, strModifiedBy)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		Case "DELETE"
			call Delete(strBookID)
			Response.Redirect request("hBack") & "?" & request("hQuery")
	END SELECT
%>
<%
	SUB AddNew(p_MeetingDate,p_Buoitruc,p_NguoiTrucID,p_NguoiTruc,p_Bophan,	p_Chucvu,p_ModifiedBy)
		dim strSQL
	
		strSQL = "LICHTRUC_Ins "
		strSQL = strSQL & "@p_MeetingDate = '" & p_MeetingDate & "',"
		strSQL = strSQL & "@p_Buoitruc = '" & p_Buoitruc & "',"
		strSQL = strSQL & "@p_NguoiTrucID = '" & p_NguoiTrucID & "',"
		strSQL = strSQL & "@p_NguoiTruc = N'" & p_NguoiTruc & "',"
		strSQL = strSQL & "@p_Bophan = N'" & p_Bophan & "',"
		strSQL = strSQL & "@p_Chucvu = N'" & p_Chucvu & "',"
		strSQL = strSQL & "@p_ModifiedBy = '" & p_ModifiedBy & "'"
		
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)
	END SUB
%>

<%
	SUB Update(p_BookID, p_MeetingDate,p_Buoitruc,p_NguoiTrucID,p_NguoiTruc,p_Bophan,	p_Chucvu,p_ModifiedBy)
		dim strSQL
	
		strSQL = "LICHTRUC_Upd "
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"
		strSQL = strSQL & "@p_MeetingDate = '" & p_MeetingDate & "',"
		strSQL = strSQL & "@p_Buoitruc = '" & p_Buoitruc & "',"
		strSQL = strSQL & "@p_NguoiTrucID = '" & p_NguoiTrucID & "',"
		strSQL = strSQL & "@p_NguoiTruc = N'" & p_NguoiTruc & "',"
		strSQL = strSQL & "@p_Bophan = N'" & p_Bophan & "',"
		strSQL = strSQL & "@p_Chucvu = N'" & p_Chucvu & "',"
		strSQL = strSQL & "@p_ModifiedBy = '" & p_ModifiedBy & "'"
		
		'Response.Write strSQL
		'Response.End
		conn.Execute(strSQL)
	END SUB
	
	sub Delete(p_BookID)
		dim strSQL
		
		strSQL = "LichTruc_Del "
		strSQL =strSQL & "@p_Book_ID = '" & p_BookID & "'"
		conn.Execute(strSQL)
	end sub
%>