<%
'---------------------Global Constants and Variables---------------------

	Session.Timeout=60
	Response.CacheControl = false
	Response.Expires = 0
	Response.Buffer = True	
	
	Session.codepage = 65001	
	dim arrMonth, arrStart(3000) 
	arrMonth = array("","Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec")
	arrStart(2006) = "30/12/2005"
	arrStart(2007) = "29/12/2006"
	arrStart(2008) = "28/12/2007"
	arrStart(2009) = "26/12/2008"
	arrStart(2010) = "01/01/2010"
	arrStart(2011) = "31/12/2010"
	arrStart(2012) = "30/12/2011"
	arrStart(2013) = "28/12/2012"
	arrStart(2014) = "27/12/2013"
	arrStart(2015) = "26/12/2014"
	arrStart(2016) = "01/01/2016"
	arrStart(2017) = "30/12/2016"
	arrStart(2018) = "29/12/2017"
	arrStart(2019) = "28/12/2018"
	arrStart(2020) = "27/12/2019"
	arrStart(2021) = "01/01/2021"
	arrStart(2022) = "31/12/2021"

	Const CONNECTION_STRING = "driver={SQL SERVER};Server=tegnamth4;Database=FSSWEBQH;UID=sa;PWD=sa;"
	Const Interval=30	
	Const TimeInterval=10
	Const OrgCode="001"		
	Const UPLOADPATH = "FileBaoCao\"
	Const UPLOADFOLDER = "FileBaoCao"
	Const TREHANTUAN = 6		' weekday(Thu 5) = 5
	Const TREHANTHANG = 15		' qua ngay nay cua thang thi bi coi la tre han
	Const TREHANQUY = 15		' qua ngay nay cua thang thi bi coi la tre han
	Const TREHANNAM = 15		' qua ngay nay cua thang thi bi coi la tre han

'--------------------------Utility Functions-------------------------

' Su dung Sub DisplayError de goi trang Result.asp
Sub DisplayError(strPagename,strCode,intBack)
	strPagename = server.HTMLEncode(strPagename) 
	response.write("<script language='" & "javascript" & "'>")
	response.write("location.href='Result.asp?pagename=" & strPagename & "&code=" & strcode & "&Back=" & intBack & "'"	)
	response.write("</script>")	
End Sub

function isNSDQuan(strUSer)
	dim rs, strSQL, strBoPhan
	set rs = server.createObject("ADODB.recordset")
'	rs.open "SELECT PhanLoai from fssportalqh..View_DonVi_PhanLoai bp JOIN fssportalqh..Users u ON u.maphongban = bp.MADV " &_
'			 "where u.userID='" & strUser& "'", CONNECTION_STRING
'	if not rs.eof then
'		strBoPhan = rs("PhanLoai")
'	else
'		strBoPhan = "F"
'	end if
	rs.open "SELECT * FROM BCT_PhanQuyen bp where userID='" & strUser& "'", CONNECTION_STRING
	if not rs.eof then
		strBoPhan = UCASE(rs("LoaidonVi"))
	else
		strBoPhan = ""
	end if

	rs.close
	set rs = nothing
	if UCASE(strBoPhan) ="Q" then	
		isNSDQuan = true
	else
		isNSDQuan= false
	end if
end function

function isWriteAccess(strUSer)
	dim rs, strSQL, strQuyen
	set rs = server.createObject("ADODB.recordset")
	rs.open "SELECT PhanQuyen from bct_PhanQuyen where userID='" & strUser & "'", CONNECTION_STRING
	if not rs.eof then
		strQuyen = UCASE(rs("PhanQuyen"))
	else
		strQuyen = "R"
	end if
	rs.close
	set rs = nothing

	if strQuyen ="W" then	
		isWriteAccess = true
	else
		isWriteAccess= false
	end if
'	if isNSDQuan(strUSer) = true then		' nguoi su dung la o quan thi chi co quyen READ
'		isWriteAccess= false
'	else
'		isWriteAccess = true
'	end if
end function
' HienND add them vao de kiem tra quyen duyet bao cao
function isApproveAccess(strUSer)
	dim rs, strSQL, strQuyen
	set rs = server.createObject("ADODB.recordset")
	rs.open "SELECT PhanQuyen from bct_PhanQuyen where userID='" & strUser & "'", CONNECTION_STRING
	if not rs.eof then
		strQuyen = UCASE(rs("PhanQuyen"))
	else
		strQuyen = "R"
	end if
	rs.close
	set rs = nothing

	if strQuyen ="W" then	
		isWriteAccess = true
	else
		isWriteAccess= false
	end if
'	if isNSDQuan(strUSer) = true then		' nguoi su dung la o quan thi chi co quyen READ
'		isWriteAccess= false
'	else
'		isWriteAccess = true
'	end if
end function

function getLoaiBaoCaoAll()
	dim rs, strSQL
	strSQL="select * from BCT_DMLoaiBaoCao" 
	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set getLoaiBaoCaoAll = rs
end function

function getInfobyUser(strUser)
	dim rs, strSQL
	strSQL="select u.*, bp.TenDV TenBoPhan, vt.TenVaiTro from fssportalqh..Users u " &_
		"LEFT join fssportalqh..View_DonVi_PhanLoai bp on u.maphongban = bp.MaDV " &_
		"LEFT Join fssportalqh..DMRole vt on vt.MaVaiTro = u.MaVaiTro " &_
		"where userID='" & strUser & "'"
	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set getInfobyUser = rs
end function

function getBoPhanOfUser(strUser)
	dim rs, strSQL, strBoPhan
	set rs = server.createObject("ADODB.recordset")
	strSQL="select madv as MaBoPhan, tendv as tenbophan " &_
		"from fssportalqh..View_DonVi_PhanLoai bp JOIN fssportalqh..Users u ON bp.MaDV = u.maphongban " &_
		"WHERE u.UserID = '" & strUser & "'"

	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	if not rs.eof then
		getBoPhanOfUser = rs("MaBoPhan")
	else
		getBoPhanOfUser = ""
	end if
	rs.close
	set rs = nothing
end function

function getBoPhanbyUser(strUser)
	dim rs, strSQL, strBoPhan
	set rs = server.createObject("ADODB.recordset")
	if isNSDQuan(strUSer) = true then
		'strSQL="select madv as MaBoPhan, tendv as tenbophan from fssportalqh..View_DonVi_PhanLoai WHERE PhanLoai='P' OR PhanLoai='G' OR PhanLoai='F'" 
		strSQL="select MaDonVi as MaBoPhan, TenDonVi as tenbophan from BCT_DONVIBAOCAO dv WHERE dv.MaDonVi <> 'PB031' "
	else
		'strSQL="select madv as MaBoPhan, tendv as tenbophan from fssportalqh..View_DonVi_PhanLoai WHERE MaDV='" & session("deptID") & "'"
		strSQL="select madv as MaBoPhan, tendv as tenbophan " &_
			"from fssportalqh..View_DonVi_PhanLoai bp JOIN fssportalqh..Users u ON bp.MaDV = u.maphongban " &_
			"WHERE u.UserID = '" & strUser & "' AND bp.MaDV<>'PB031' "
	end if
	'Response.Write(strSQL)
	'Response.End
	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set getBoPhanbyUser = rs
end function

function getBoPhanAll()
	dim rs, strSQL, strBoPhan
	set rs = server.createObject("ADODB.recordset")
	'strSQL="select madv as MaBoPhan, tendv as tenbophan from fssportalqh..View_DonVi_PhanLoai WHERE PhanLoai='P' OR PhanLoai='G' OR PhanLoai='F'" 
	strSQL="select MaDonVi as MaBoPhan, TenDonVi as tenbophan from BCT_DONVIBAOCAO"

	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set getBoPhanAll = rs
end function

function getCanhan()
	' lay ca nhan phong ban o lanh dao quan thoi	PB0030, 31, 53, 52, 26
	dim rs, strSQL, strBoPhan
	set rs = server.createObject("ADODB.recordset")
	'strSQL="select * from fssportalqh..users WHERE MaBoPhan in('PB0030','PB0031','PB0053','PB0052','PB0026')"
	' HienND update test choiz
	'strSQL="select * from fssportalqh..users WHERE MaPhongBan in('P010','P013','VPUB')"
	strSQL ="sp_BCT_GetCaNhan"
	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set getCaNhan = rs
end function

function getNoiNhanByMaBaoCao(strMaBaoCao)
	dim rs
	set rs = server.createObject("ADODB.recordset")
	strSQL = " select * from ( " &_
				"select u.fullname, phanloainoinhan " &_
				"from bct_noinhan nn join fssportalqh..users u on u.userid = nn.manoinhan and phanloainoinhan='C' " &_
				"WHERE nn.MaBaoCao=" & strMaBaoCao & "UNION " &_ 
				"select dv.tendv, phanloainoinhan " &_
				"from bct_noinhan nn " &_
				"join fssportalqh..view_donvi_phanloai dv on dv.madv = nn.manoinhan and phanloainoinhan='P' " &_
				"WHERE nn.MaBaoCao=" & strMaBaoCao & ") a " &_
		"ORDER BY phanloainoinhan"
	rs.open strSQL, CONNECTION_STRING
	set getNoiNhanByMaBaoCao = rs
end function

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

Function ConvertDate(dtDate)
	dim strDay, strMonth, strYear
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

function getDMKhoi()
	dim rs, strSQL
	set rs = server.createObject("ADODB.recordset")
	strSQL="select * from fssportalqh..DMKhoi "

	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set getDMKhoi = rs
end function

function validdate(strLoaiBaoCao, fromdate, todate)
	dim strReturnDate, strGap
	select case UCASE(strLoaiBaoCao)
		case "BCT"
			if weekday(ToDate)>=5 then
				strGap = weekday(ToDate) - TREHANTUAN
			else
				strGap = 7 + weekday(ToDate) - TREHANTUAN
			end if
			strReturnDate = dateadd("d",-strGap,Todate)
		case "BCH"	' bao cao thang
			strReturnDate = DateValue(TREHANTHANG & "/" & arrMonth(Month(todate)) & "/" & year(todate))
		case "BCQ"	' bao cao quy
			If MyQuarter(toDate) = 4 Then
                strReturnDate = DateValue(TREHANTHANG & "/" & arrMonth(Month(todate)) & "/"  & Year(toDate))
            Else
                strReturnDate = DateValue(TREHANTHANG & "/" & arrMonth(MyQuarter(toDate) * 3) & "/" & Year(toDate))
            End If
		case "BCN"
			strReturnDate = DateValue(TREHANTHANG & "/"& arrMonth(12) &"/" & year(todate))
		case else	' bao cao dot xuat
			strReturnDate =	date()
	end select
	validdate = strReturnDate
end function

Function MyQuarter(mDate)
'		mdate=cdate(mdate)
	    If Month(mDate) >= 1 And Month(mDate) <= 3 Then
    	    MyQuarter = 1
	    ElseIf Month(mDate) >= 4 And Month(mDate) <= 6 Then
    	    MyQuarter = 2
	    ElseIf Month(mDate) >= 7 And Month(mDate) <= 9 Then
    	    MyQuarter = 3
	    Else
    	    MyQuarter = 4
	    End If
	End Function

Function CreatecboThu(numRow,arrBaoCao)
	
	response.Write "<select size='1' name='cboThu' style='font-family: Arial; font-size: 12px' onchange='SetTuNgayDenNgay()'>"
	for i = 1 to numRow
		response.Write "<option value='" & arrBaoCao(i,3) & "'>" & arrBaoCao(i,1) & "</option>"
	next
	response.Write "</select>"
		
End Function


'TuanNH created date 19/10/2006
'Thong ke tong hop tinh hinh gui bao cao thang, quy, nam cua cac Phong Ban
'
function BCT_ThongKeTongHop(pMaDonVi, pNamBaoCao, pUserID)
	dim rs, strSQL
	strSQL="exec sp_BCT_ThongKeTongHop '', '" + pMaDonVi + "','" + cstr(pNamBaoCao) + "','" + pUserID + "'"
	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set BCT_ThongKeTongHop = rs
end function


'TuanNH created date 20/10/2006
'Quan ly tien do tinh hinh gui bao cao Tuan, Thang
'
function BCT_ThongKeBaoCaoTuan(pThangBaoCao, pTuNgay, pDenNgay, strUser)
	dim rs, strSQL
	strSQL="exec sp_BCT_ThongKeBaoCaoTuan '', '" & cstr(pThangBaoCao) & "', '" & cstr(pTuNgay) & "','" & cstr(pDenNgay) & "','" + strUser + "'"
	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set BCT_ThongKeBaoCaoTuan = rs
end function


'TuanNH created date 21/10/2006
'Danh sach bao cao thang cua phong ban
'
function BCT_DSBaoCaoThang(pMaBoPhan, pNamBaoCao)
	dim rs, strSQL
	strSQL="exec sp_BCT_DSBaoCaoThang '', '" & cstr(pMaBoPhan) & "','" & cstr(pNamBaoCao) & "'"
	set rs=server.CreateObject("ADODB.Recordset")
	rs.open strSQL, CONNECTION_STRING
	set BCT_DSBaoCaoThang = rs
end function

%>
