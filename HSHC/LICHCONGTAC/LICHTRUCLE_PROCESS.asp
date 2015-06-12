<!--#include file="inc\lib.asp"-->
<%

	dim conn	
	SET conn = server.CreateObject("ADODB.Connection")
	
	conn.Open CONNECTION_STRING

	strAction = request("haction")
	strBookID = request("hBookID")
	strCanBo = request("txtCanBo")
	strNgayTruc	= request("txtNgayTruc")
	strGioTruc = request("txtGio")
	strTaiXe = request("txtTaiXe")
	strDonVi = request("cboDonVi")
	strPhucVu = request("txtPhucVu")
	strLanhDao = request("txtLanhDao")
	strBaoVe = request("txtBaoVe")
	strModifiedBy = session("UserID")
	strLoailich = request("cboLoailich")
	'Response.Write(strAction)
	'Response.End
	'Cap nhat so thu tu
	strSTT = request("txtStt")
	strOrderType = request("OrderAction")

	SELECT CASE UCASE(strAction)
		Case "ADDNEW"
			call AddNew(strLoailich, strCanBo, strNgayTruc, strGioTruc, strTaiXe, strDonVi, strPhucVu, strLanhDao, strBaoVe, strModifiedBy)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		Case "UPDATE"
			call Update(strBookID, strLoailich, strCanBo, strNgayTruc, strGioTruc, strTaiXe, strDonVi, strPhucVu, strLanhDao, strBaoVe, strModifiedBy)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		Case "DELETE"
			call Delete(strBookID)
			Response.Redirect request("hBack") & "?" & request("hQuery")
		CASE "UPDORDER"
			'response.write(request("hBack"))
			'response.end
			call updOrder(strBookID, strSTT, strOrderType)
			Response.Redirect request("hBack") & "?" & request("hQuery")
	END SELECT
%>
<%
	SUB AddNew(p_Loailich, p_CanBo, p_NgayTruc, p_GioTruc, p_TaiXe, p_DonVi, p_PhucVu, p_LanhDao, p_BaoVe, p_ModifiedBy)
		dim strSQL
	
		strSQL = "LICHTRUCLE_Ins "
		strSQL = strSQL & "@p_Loailich = N'" & p_Loailich & "',"
		strSQL = strSQL & "@p_CanBo = N'" & p_CanBo & "',"
		strSQL = strSQL & "@p_NgayTruc = N'" & p_NgayTruc & "',"
		strSQL = strSQL & "@p_GioTruc = N'" & p_GioTruc & "',"
		strSQL = strSQL & "@p_TaiXe = N'" & p_TaiXe & "',"
		strSQL = strSQL & "@p_DonVi = N'" & p_DonVi & "',"
		strSQL = strSQL & "@p_PhucVu = N'" & p_PhucVu & "',"
		strSQL = strSQL & "@p_LanhDao = N'" & p_LanhDao & "',"
		strSQL = strSQL & "@p_BaoVe = N'" & p_BaoVe & "',"
		strSQL = strSQL & "@p_ModifiedBy = '" & p_ModifiedBy & "'"
		
		'Response.Write strSQL
		'Response.End
		dim rs
		SET rs = server.CreateObject("ADODB.RecordSet")
		rs = conn.Execute(strSQL)
		'response.Write("error: " & rs("ErrorCode"))
		'Response.End
		if rs("ErrorCode") = -2 then
			Response.Redirect "lichtrucle_addnew.asp?errorcode=" & rs("ErrorCode") & "&from=" & rs("TuNgay") & "&to=" & rs("DenNgay")
		end if
	END SUB
%>

<%
	SUB Update(p_BookID, p_Loailich, p_CanBo, p_NgayTruc, p_GioTruc, p_TaiXe, p_DonVi, p_PhucVu, p_LanhDao, p_BaoVe, p_ModifiedBy)
		dim strSQL
	
		strSQL = "LICHTRUCLE_Upd "
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"
		strSQL = strSQL & "@p_Loailich = N'" & p_Loailich & "',"
		strSQL = strSQL & "@p_CanBo = N'" & p_CanBo & "',"
		strSQL = strSQL & "@p_NgayTruc = N'" & p_NgayTruc & "',"
		strSQL = strSQL & "@p_GioTruc = N'" & p_GioTruc & "',"
		strSQL = strSQL & "@p_TaiXe = N'" & p_TaiXe & "',"
		strSQL = strSQL & "@p_DonVi = N'" & p_DonVi & "',"
		strSQL = strSQL & "@p_PhucVu = N'" & p_PhucVu & "',"
		strSQL = strSQL & "@p_LanhDao = N'" & p_LanhDao & "',"
		strSQL = strSQL & "@p_BaoVe = N'" & p_BaoVe & "',"
		strSQL = strSQL & "@p_ModifiedBy = '" & p_ModifiedBy & "'"
		
		'Response.Write strSQL
		'Response.End
		dim rs
		SET rs = server.CreateObject("ADODB.RecordSet")
		rs = conn.Execute(strSQL)
		'response.Write("error: " & rs("ErrorCode"))
		'Response.End
		if rs("ErrorCode") = -2 then
			Response.Redirect "lichtrucle_addnew.asp?errorcode=" & rs("ErrorCode") & "&from=" & rs("TuNgay") & "&to=" & rs("DenNgay")
		end if
	END SUB
	
	sub Delete(p_BookID)
		dim strSQL
		
		strSQL = "LichTrucLe_Del "
		strSQL =strSQL & "@p_Book_ID = '" & p_BookID & "'"
		conn.Execute(strSQL)
	end sub

'Cap nhat thu tu in lich cong tac
sub updOrder(p_BookID, p_curPos, p_sortType)
	dim strSQL
		strSQL = "LichTrucLe_Upd_Order "		
		strSQL = strSQL & "@p_Book_ID = '" & p_BookID & "',"
		strSQL = strSQL & "@p_curPos = '" & p_curPos & "',"
		strSQL = strSQL & "@p_sortType = '" & p_sortType & "'"
	'Response.Write strSQL
	'Response.End
	conn.Execute(strSQL)
end sub
%>