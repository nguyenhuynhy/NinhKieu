<%
	'if session("UserID") = "" then
	'	response.redirect "Login.asp"
	'end if
%>
<!--#include file="inc/lib.asp"-->
<!--#include file="inc/ADOVBS.inc"-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

<script language="javascript">
	function openNewWindow(query) {
		t = screen.height - 30;
		w = screen.width - 10;
			
		FileWindow = window.open('BCT_ThongKePrintOut.asp?' + query,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=yes,resizable');
	
		FileWindow.focus();
		
	}
</script>

</head>

<%
	dim arrBaoCao(53, 8)
	' cot 1 : loai baocao
	' cot 2 : ten bao cao
	' cot 3 : tu ngay		' kieu ngay
	' cot 4 : den ngay		' kieu ngay
	' cot 5 : tu ngay		' kieu dd/mm/yyyy
	' cot 6 : den ngay		' kieu dd/mm/yyyy
	' cot 7 : dung han
	' cot 8 : tre han
	
	function getDSBaoCao(strLoaiBaoCao, strNgaybatdau, numRow, strYear)
		dim strSQL, com, con, ngaykhoitao
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		set rs = server.createObject("ADODB.recordset")
'		rs.CursorLocation = 3
		select case strLoaiBaoCao		
			case "BCT"			
				denngay = DateValue(mid(strNgaybatdau,4,2) & "/" & left(strNgaybatdau,2) & "/" & right(strNgaybatdau,4))
				set com=server.CreateObject("ADODB.Command")
				com.ActiveConnection=con
				
				for i = 1 to numRow
					tungay = denngay
					denngay = dateadd("d", tungay, 7)
					arrBaocao(i, 0) = strLoaiBaoCao
					arrBaoCao(i,1) = "B&#225;o c&#225;o tu&#7847;n " & i
					arrBaoCao(i,3) = tungay
					arrBaoCao(i,5) = ConvertDate(tungay)
					arrBaoCao(i,4) = denngay
					arrBaoCao(i,6) = ConvertDate(denngay)					

					com.CommandText= "BCT_rptBaoCao"
					com.commandType=adCmdStoredProc

					com.Parameters("@LoaiBaoCao").value = strLoaiBaoCao
					com.Parameters("@TuNgay") = arrBaoCao(i,5)
					com.Parameters("@denNgay") = arrBaoCao(i,6)

					rs.open com
					if not rs.eof then
						arrBaoCao(i,7) = rs("dunghan")
						arrBaoCao(i,8) = rs("trehan")
					end if
					rs.close
				next		
			case "BCH"
				set com=server.CreateObject("ADODB.Command")
				com.ActiveConnection=con
				for i = 1 to numRow
					if i = 1 then
						tungay = trehanthang & "/12/" & CStr(strYear-1)	
					else
						tungay = trehanthang & "/" & right("0"& i-1, 2) & "/" & strYear	
					end if
					denngay = trehanthang & "/" & right("0"& i, 2) &"/" & strYear

					arrBaocao(i, 0) = strLoaiBaoCao
					arrBaoCao(i,1) = "B&#225;o c&#225;o th&#225;ng " & i
					arrBaoCao(i,3) = DateValue(tungay)
					arrBaoCao(i,5) = tungay
					arrBaoCao(i,4) = DateValue(denngay)
					arrBaoCao(i,6) = denngay
					
					com.CommandText= "BCT_rptBaoCao"
					com.commandType=adCmdStoredProc

					com.Parameters("@LoaiBaoCao").value = strLoaiBaoCao
					com.Parameters("@TuNgay") = arrBaoCao(i,5)
					com.Parameters("@denNgay") = arrBaoCao(i,6)

					rs.open com
					if not rs.eof then
						arrBaoCao(i,7) = rs("dunghan")
						arrBaoCao(i,8) = rs("trehan")
					end if
					rs.close
				next
			case "BCN"
				set com=server.CreateObject("ADODB.Command")
				com.ActiveConnection=con			
				tungay = trehanthang & "/12/" & CINT(strYear-1)	
				denngay = trehanthang & "/12/" & strYear

				arrBaocao(1, 0) = strLoaiBaoCao
				arrBaoCao(1,1) = "B&#225;o c&#225;o n&#259;m " & strYear

				arrBaoCao(1,3) = DateValue(tungay)
				arrBaoCao(1,5) = tungay
				arrBaoCao(1,4) = DateValue(denngay)
				arrBaoCao(1,6) = denngay
				com.CommandText= "BCT_rptBaoCao"
				com.commandType=adCmdStoredProc
				com.Parameters("@LoaiBaoCao").value = strLoaiBaoCao
				com.Parameters("@TuNgay") = arrBaoCao(1,5)
				com.Parameters("@denNgay") = arrBaoCao(1,6)

				rs.open com
				if not rs.eof then
					arrBaoCao(1,7) = rs("dunghan")
					arrBaoCao(1,8) = rs("trehan")
				end if
				rs.close				
			case "BCQ"
				set com=server.CreateObject("ADODB.Command")
				com.ActiveConnection=con			
			
				for i = 1 to numRow
					if i = 1 then
						tungay = trehanthang & "/12/" & CINT(strYear-1)	
					else
						tungay = trehanthang & "/" & right("0"& (i-1)*3, 2) & "/" & strYear	
					end if
					denngay = trehanthang & "/" & right("0"& i*3, 2) &"/" & strYear

					arrBaocao(i, 0) = strLoaiBaoCao
					arrBaoCao(i,1) = "B&#225;o c&#225;o qu&#253; " & i
					
					arrBaoCao(i,3) = DateValue(tungay)
					arrBaoCao(i,5) = tungay
					arrBaoCao(i,4) = DateValue(denngay)
					arrBaoCao(i,6) = denngay
					
					com.CommandText= "BCT_rptBaoCao"
					com.commandType=adCmdStoredProc

					com.Parameters("@LoaiBaoCao").value = strLoaiBaoCao
					com.Parameters("@TuNgay") = arrBaoCao(i,5)
					com.Parameters("@denNgay") = arrBaoCao(i,6)

					rs.open com
					if not rs.eof then
						arrBaoCao(i,7) = rs("dunghan")
						arrBaoCao(i,8) = rs("trehan")
					end if
					rs.close				
				next			
		end select
		set com=nothing
		set con = nothing					
	end function	
function getcboThu(strLoaiBaoCao)
	dim i, arr
	
	select case strLoaiBaocao
		case "BCT"
			for i=1 to 53
				arr.add(i)	
			next	
	end select
	getcboThu=arr
end function
%>
<%
	strUser = session("UserID")
	dim strLoaiBaoCao, numRow
	dim strBgColor
	dim strLoaiBaoBieu
	
	strNSDQuan = isNSDQuan(strUSer)
	strBoPhan = request.form("cboBoPhan")
	if strBoPhan ="" then 
		strBoPhan = session("DeptID")
	end if
	strLoaiBaoBieu = request.form("cboLoaiBaoBieu")	
	if strLoaiBaoBieu = "" then strLoaiBaoBieu = "TKTH"
	
	strLoaiBaoCao = request.form("cboLoaiBaoCao")
	if strLoaiBaoCao ="" then strLoaiBaoCao = "BCH"
	
	strYear = request.form("cboYear")
	if strYear = "" then strYear = year(date)
	
	strMonth = request.Form("cboMonth")
	strWeek = request.Form("cboWeek")
	
	if strMonth = "" then strMonth = month(date)
	
	select case UCASE(strLoaiBaoCao)
		case "BCT"
			numRow = 53
		case "BCH"
			numRow = 12
		case "BCN"
			numRow =1
		case "BCQ"
			numRow = 4
	end select
	t = getDSBaoCao(strLoaiBaoCao, arrStart(strYear), numRow, strYear)
	dim i
	
	
	dim fromDate
	dim toDate
	dim strSelectMonth
	strSelectMonth = request.Form("txtSelectMonth")
		
	denngay = DateValue(mid(arrStart(year(date)),4,2) & "/" & left(arrStart(year(date)),2) & "/" & right(arrStart(year(date)),4))
	
	for i = 1 to 52
		tungay = denngay
		denngay = dateadd("d", tungay, 7)
		
		if strWeek<>"" then
			if cint(strWeek)=i and strSelectMonth="" then
				i=54
				fromDate = tungay
				toDate = denngay
				strMonth = month(fromDate)
			end if
		'else
		'	if tungay<date and date<=denngay then
		'		i=54
		'		fromDate = tungay
		'		toDate = denngay
		'	end if
		end if
	next
	
	if strSelectMonth<>"" then
		fromDate = ""
		toDate = ""
		strWeek = ""
	end if
%>
<!--#include file="inc/header.asp"-->
<title>Danh sach bao cao</title>

<form method="POST" action="BCT_ThongKeTongHop.asp" name="frmMain">
<SCRIPT LANGUAGE="JavaScript" SRC="script/date.js"></SCRIPT>
<center>
      <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="780" id="AutoNumber3">
       <tr>
          <td align="center" colspan="3" width="780" >
          <img src="images/Text_DSbaocao.jpg" border="0"></td>
        </tr>
       <tr>
          <td align="right" colspan="3" width="780" >&nbsp;</td>
        </tr>
        <%if strLoaiBaoCao <> "BCT" then%>
       <tr>
          <td align="right" width="30%" ><font color="#184798">Loại báo biểu:</font></td>
          <td align="left" colspan="2" width="520" >
			<select size="1" name="cboLoaiBaoBieu" style="font-family: Arial; font-size: 12px" onchange="frmMain.submit();" ID="Select2">
				<option value="TKTH" <%if strLoaiBaoBieu="TKTH" then%>selected<%end if%>>Thống kê tổng hợp</option>
				<option value="QLTD" <%if strLoaiBaoBieu="QLTD" then%>selected<%end if%>>Quản lý tiến độ</option>
			</select>
          </td>
        </tr>
        <%end if%>
        
       <!--Tiêu chí lọc - Thong ke tong hop thong tin-->
       <%if strLoaiBaoBieu = "TKTH" then%>
			<%if strLoaiBaoCao <> "BCT" then%>
       <tr>
          <td align="right" width="30%" ><font color="#184798">Phòng ban:</font></td>
          <td align="left" colspan="2" width="520" >
			<select size="1" name="cboBoPhan" style="font-family: Arial; font-size: 12px" onchange="frmMain.submit();" ID="Select1">
			<%if strNSDQuan = true then%>
				<option value="%">T&#7845;t c&#7843;</option>
			<%end if%>
				<%
              		'set rs = getBoPhanAll()
              		IF strBoPhan="PB031" then strBoPhan = "" end if
              		
              		set rs = getBoPhanbyUser(strUser)
              		do while not rs.eof 
				%>
					<option value="<%=rs("MaBoPhan")%>" <% if strBoPhan = rs("MaBoPhan") then%>selected<%end if%>><%=rs("TenBoPhan")%></option>
				<%
              			rs.movenext
              		loop
              		rs.close
              		set rs = nothing
				%>
			</select>
          </td>   
        </tr>
			<%end if%>
       <tr>
          <td width="30%" align="right"><font color="#184798">Lo&#7841;i báo cáo:</font></td>            
          <td width="159">
              <select size="1" name="cboLoaiBaoCao" style="font-family: Arial; font-size: 12px" onchange="frmMain.submit();">
              <!--<option value="%">T&#7845;t c&#7843;</option>-->
              <%
              	set rs = getLoaiBaoCaoAll()
              	do while not rs.eof 
              		if rs("MaLoaiBaoCao")<>"BCD" then
              %>
				<option value="<%=rs("MaLoaiBaoCao")%>" <% if strLoaiBaoCao = rs("MaLoaiBaoCao") then%>selected<%end if%>><%=rs("TenLoaiBaoCao")%></option>
              <%
					end if
					
              		rs.movenext
              	loop
              	rs.close
              	set rs = nothing
              %>
              </select></td>
          <td width="361">
			<table width="100%" border=0>
				<tr>
					<td>
						<font color="#184798">Năm báo cáo: </font>
						<select size="1" name="cboYear" style="font-family: Arial; font-size: 12px" onchange="frmMain.submit();" ID="Select5">
						<%
              					'for i = year(date) - 1 to year(date)
              					for i = 2006 to year(date)
						%>
							<option value="<%=i%>" <% if cstr(stryear) = cstr(i) then%>selected<%end if%>><%=i%></option>
						<%
              					next
						%>
						</select>
					</td>
					<td align=right><a onClick="openNewWindow('LBB=<%=strLoaiBaoBieu%>&LBC=<%=strLoaiBaoCao%>&MaBP=<%=strBoPhan%>&NamBC=<%=strYear%>&ThangBC=<%=strMonth%>&TuNgay=<%=fromDate%>&DenNgay=<%=ToDate%>');" style="cursor:hand" ><img src="Images/icon_print.gif" border=0></a></td>
				</tr>
             </table>
            </td>
        </tr>
        <%end if%>
        <!--Kết thúc Tiêu chí lọc - Thong ke tong hop thong tin-->
        
        
        <!--Tiêu chí lọc - Quản lý tiến độ-->
        <%if strLoaiBaoBieu<>"TKTH" then%>
        <tr>
          <td align="right" width="30%" ><font color="#184798">Tháng</font></td>
          <td align="left" colspan="2" width="520" >
			<select size="1" name="cboMonth" style="font-family: Arial; font-size: 12px" onchange="frmMain.txtSelectMonth.value='Month';frmMain.submit();" ID="Select3">
					<option value=""></option>
				<%
              		for i=1 to 12
				%>
					<option value="<%=i%>" <%if strMonth<>"" then if cint(strMonth)=i then Response.Write("selected") end if end if%>><%=i%></option>
				<%
              		next
				%>
			</select>
          </td>   
        </tr>
        <tr>
          <td align="right" width="30%" ><font color="#184798">Tuần</font></td>
          <td align="left" >
			<select size="1" name="cboWeek" style="font-family: Arial; font-size: 12px" onchange="frmMain.submit();" ID="Select4">
					<option value=""></option>
				<%
              		for i=1 to 52
				%>
					<option value="<%=i%>" <%if strWeek<>"" then if cint(strWeek)=i then Response.Write("selected") end if end if%>><%=i%></option>
				<%
              		next
				%>
			</select>
          </td>
          <td width="361">
			<table width="100%" border=0>
				<tr>
					<td><INPUT NAME="txtFromDate" TYPE="text" VALUE="<%=fromDate%>" SIZE=11 ID="Text1" readonly="true"> <INPUT NAME="txtToDate" TYPE="text" VALUE="<%=toDate%>" SIZE=11 ID="Text2" readonly="true"></td>
					<td align=right><a onClick="openNewWindow('LBB=<%=strLoaiBaoBieu%>&LBC=<%=strLoaiBaoCao%>&MaBP=<%=strBoPhan%>&NamBC=<%=strYear%>&ThangBC=<%=strMonth%>&TuNgay=<%=fromDate%>&DenNgay=<%=ToDate%>');" style="cursor:hand" ><img src="Images/icon_print.gif" border=0></a></td>
				</tr>
			</table>
          </td>
        </tr>
        <%end if%>
        <!--Kết thúc Tiêu chí lọc - Quản lý tiến độ-->
       
       <!--Danh sach data Thong Ke Tong Hop-->
       <%if strLoaiBaoBieu = "TKTH" then%>
       <tr>
          <td align="right" colspan="3" width="100%" >
          <table border="1" cellpadding="3" cellspacing="1" style="border-collapse: collapse" bordercolor="#CCCCCC" width="100%" id="AutoNumber4">
          
			<!--Thong ke bao cao Thang, Quy, Nam-->
			
			<%if strLoaiBaoCao<>"BCT" then%>
            <tr bgcolor="#448A37" height="18">
				<td width="200" align="center" rowspan=2><b><font color="#FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phòng&nbsp;ban&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b></td>
				<%for i=1 to 12%>
				<td width="8%" align="center" colspan=3><b><font color="#FFFFFF"><%if i=3 then%>Quý 1<%end if%><%if i=6 or i=9 then%><%=i%>&nbsp;tháng đầu năm<%end if%><%if i=12 then%>Năm&nbsp;<%=strYear%><%end if%><%if i<>3 and i<>6 and i<>9 and i<>12 then%>Tháng&nbsp;<%=i%><%end if%></font></b></td>
				<%next%>
				<td width="20%" align="center" colspan=3><b><font color="#FFFFFF">Tổng cộng</font></b></td>
            </tr>
            <tr bgcolor="#448A37" height="18">
				<%for i=1 to 13%>
				<td width="8%" align="center"><b><font color="#FFFFFF">Đ</font></b></td>
				<td width="8%" align="center"><b><font color="#FFFFFF">T</font></b></td>
				<td width="8%" align="center"><b><font color="#FFFFFF">C</font></b></td>
				<%next%>
            </tr>
            
            <%
				if strBoPhan = "%" then strBoPhan = ""
            
				set rs = BCT_ThongKeTongHop(strBoPhan, strYear, strUser)
				dim sumDungH, sumTreH, sumChuaH	'Tong hang` ngang
				dim sumDungV, sumTreV, sumChuaV	'Tong han`g doc.
				dim sumDung, sumTre, sumChua	'Tong
				
				sumDung = 0
				sumTre  = 0
				sumChua = 0
				
				while not rs.eof 
					'reset tong ha`ng ngang khi wa don`g moi
					sumDungH = 0
					sumTreH  = 0
					sumChuaH = 0
            %>
            <tr height="15" bgcolor="#f5f5dc">
				<td width="200"><a href="" onclick="xemDSBaoCaoThang('<%=rs("MaDonVi")%>','<%=strYear%>');return false;"><%=rs("TenDonVi")%></a></td>
				<%for i=1 to 12%>
					<td width="8%" align="center">
					<%if rs("Thang"+cstr(i))>=1 then 
						Response.Write("<img src='Images/check.gif'>") 
						sumDungH = sumDungH + 1
					end if%>
					</td>
					<td width="8%" align="center">
					<%if rs("Thang"+cstr(i))=-1 then 
						Response.Write("<img src='Images/check_tre.gif'>") 
						sumTreH = sumTreH + 1
					end if%></td>
					<td width="8%" align="center">
					<%if rs("Thang"+cstr(i))=0 then 
						Response.Write("<img src='Images/check_chua.gif' width='15'>") 
						sumChuaH = sumChuaH + 1
					end if%></td>
				<%next%>
				<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumDungH<>0 then Response.Write(cstr(sumDungH)) end if%></font></b></td>
				<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumTreH<>0 then Response.Write(cstr(sumTreH)) end if%></font></b></td>
				<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumChuaH<>0 then Response.Write(cstr(sumChuaH)) end if%></font></b></td>
            </tr>
            <%
					'Tinh tong cong tat ca
					sumDung = sumDung + sumDungH
					sumTre  = sumTre + sumTreH
					sumChua = sumChua + sumChuaH
					
              		rs.movenext
				wend
				rs.close
				set rs = nothing
            %>
            <tr height="15" bgcolor="#ECFFEC">
				<td ><b><font color="#FF0000">Tổng cộng :</font></b></td>
				<%for i=1 to 12%>
					<%
						'reset tong hang doc. khi wa Thang' moi
						sumDungV = 0
						sumTreV  = 0
						sumChuaV = 0
						
						set rs = BCT_ThongKeTongHop(strBoPhan, strYear, strUser)
						while not rs.eof
					
							if rs("Thang"+cstr(i))>=1 then 
								sumDungV = sumDungV + 1
							end if
							if rs("Thang"+cstr(i))=-1 then 
								sumTreV = sumTreV + 1
							end if
							if rs("Thang"+cstr(i))=0 then 
								sumChuaV = sumChuaV + 1
							end if
										
              				rs.movenext
						wend
						rs.close
						set rs = nothing
					%>
					<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumDungV<>0 then Response.Write(cstr(sumDungV)) end if%></font></b></td>
					<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumTreV<>0 then Response.Write(cstr(sumTreV)) end if%></font></b></td>
					<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumChuaV<>0 then Response.Write(cstr(sumChuaV)) end if%></font></b></td>
				<%next%>
				<!--Tong tat ca-->
				<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#FF0000"><%if sumDung<>0 then Response.Write(cstr(sumDung)) end if%></font></b></td>
				<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#FF0000"><%if sumTre<>0 then Response.Write(cstr(sumTre)) end if%></font></b></td>
				<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#FF0000"><%if sumChua<>0 then Response.Write(cstr(sumChua)) end if%></font></b></td>
            </tr>
            <%end if%>
            
            <!--end Thong ke bao cao Thang, Quy, Nam-->
            
            <!--Thong ke bao cao tuan-->
            
            <%if strLoaiBaoCao="BCT" then%>
            <tr bgcolor="#448A37" height="18">
				<td width="200" align="center"><b><font color="#FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tuần báo cáo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b></td>
				<td width="8%" align="center" ><b><font color="#FFFFFF">Thời gian</font></b></td>
				<td width="20%" align="center" ><b><font color="#FFFFFF">Đúng hạn</font></b></td>
				<td width="20%" align="center" ><b><font color="#FFFFFF">Trễ hạn</font></b></td>
            </tr>
            <% for i = 1 to numRow%>
            <tr height="15">
              <td width="20%" bgcolor="#f5f5dc">&nbsp;<%=arrBaoCao(i,1)%></td>
              <td width="40%" bgcolor="#f5f5dc">&nbsp;từ ngày <%=arrBaoCao(i,5)%> đến ngày <%=arrBaoCao(i,6)%></td>
              <td width="20%" align="right" bgcolor="#f5f5dc"><%if arrBaoCao(i,7)>0 then%><a href="" onclick="xemchitiet('<%=arrBaoCao(i,5)%>','<%=arrBaoCao(i,6)%>','<%=arrBaoCao(i,0)%>','');return false;"><%=arrBaoCao(i,7)%></a><%end if%>&nbsp;</td>
              <td width="20%" align="right" bgcolor="#ECFFEC"><%if arrBaoCao(i,8)>0 then%><a href="" onclick="xemchitiet('<%=arrBaoCao(i,5)%>','<%=arrBaoCao(i,6)%>','<%=arrBaoCao(i,0)%>','true');return false;"><%=arrBaoCao(i,8)%></a><%end if%>&nbsp;</td>
            </tr>
            <%next%>
            <%end if%>
            
            <!--end thong ke bao cao tuan-->
          </table>
          </td>
        </tr>
        <!--Hien thi Ghi chu neu la Thong Ke Bao Cao Thang', Quy, Nam-->
        <%if strLoaiBaoCao<>"BCT" then%>
        <tr>
          <td colspan="3" width="100%" >
			<table width=100% border=0 ID="Table1">
				<tr>
					<td colspan=2><b><font color="#000000">&nbsp;&nbsp;&nbsp;* Ghi chú:</font></b></td>
				</tr>
				<tr>
					<td width="5%">&nbsp;</td>
					<td>
						<table width="100%" border=0 cellpadding=0 cellspacing=0 ID="Table2">
							<tr>
								<td width="15%">- Đ : Đúng hạn</td>
								<td><img src='Images/check.gif'></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="5%">&nbsp;</td>
					<td>
						<table width="100%" border=0 ID="Table3" cellpadding=0 cellspacing=0>
							<tr>
								<td width="15%">- T : Trễ hạn</td>
								<td><img src='Images/check_tre.gif'></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="5%">&nbsp;</td>
					<td>
						<table width="100%" border=0 ID="Table4" cellpadding=0 cellspacing=0>
							<tr>
								<td width="15%">- C : Chưa gửi</td>
								<td><img src='Images/check_chua.gif'></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
          </td>
        </tr>
        <%end if%>
        <!--Ket thuc hien thi Ghi Chu doi voi Thong Ke Bao Cao Thang, Quy, Nam-->
        
        <%end if%>
        <!--Ket thuc - Danh sach data Thong Ke Tong Hop-->
        
        <!--Danh sach data Quan Ly Tien Do-->
       <%if strLoaiBaoBieu <> "TKTH" then%>
       <tr>
          <td align="right" colspan="3" width="100%" >
			<table border="1" cellpadding="3" cellspacing="1" style="border-collapse: collapse" bordercolor="#CCCCCC" width="100%" id="Table5">
				<tr bgcolor="#448A37" height="18">
					<td width="200" align="center"><b><font color="#FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phòng&nbsp;ban&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b><input type=hidden name="txtSelectMonth" ID="Hidden1"></td>
					<td width="20%" align="center"><b><font color="#FFFFFF">Đúng hạn</font></b></td>
					<td width="20%" align="center"><b><font color="#FFFFFF">Trễ hạn</font></b></td>
					<td width="20%" align="center"><b><font color="#FFFFFF">Chưa gửi</font></b></td>
				</tr>
				<%
					set rs = BCT_ThongKeBaoCaoTuan(strMonth, fromDate, toDate, strUser)
					
					sumDungV = 0
					sumTreV  = 0
					sumChuaV = 0
					
					while not rs.eof 
				%>
				<tr height="15" bgcolor="#f5f5dc">
					<td width="200"><%=rs("TenDonVi")%></td>
					<td width="8%" align="center">
					<%if rs("Value")>=1 then 
						Response.Write("<img src='Images/check.gif'>") 
						sumDungV = sumDungV + 1
					end if%>
					</td>
					<td width="8%" align="center">
					<%if rs("Value")=-1 then 
						Response.Write("<img src='Images/check_tre.gif'>") 
						sumTreV = sumTreV + 1
					end if%></td>
					<td width="8%" align="center">
					<%if rs("Value")=0 then 
						Response.Write("<img src='Images/check_chua.gif' width='15'>") 
						sumChuaV = sumChuaV + 1
					end if%></td>
				</tr>
				<%		
              			rs.movenext
					wend
					rs.close
					set rs = nothing
				%>
				<tr height="15" bgcolor="#ECFFEC">
					<td ><b><font color="#FF0000">Tổng cộng :</font></b></td>
					<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumDungV<>0 then Response.Write(cstr(sumDungV)) end if%></font></b></td>
					<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumTreV<>0 then Response.Write(cstr(sumTreV)) end if%></font></b></td>
					<td width="8%" align="center" bgcolor="#ECFFEC"><b><font color="#036D1E"><%if sumChuaV<>0 then Response.Write(cstr(sumChuaV)) end if%></font></b></td>
				</tr>
			</table>
		   </td>
		</tr>
       <%end if%>
       <!--Ket thuc - Danh sach data Quan Ly Tien Do-->
        
       </table>
</form>
<form method="POST" action="bct_rptbaocao_DS.asp" name="frmMain1">
<input type="hidden" name="txtTuNgay">
<input type="hidden" name="txtDenNgay">
<input type="hidden" name="cboLoaiBaoCao">
<input type="hidden" name="txtTreHan">
</form>
<form method="POST" action="BCT_rptDSBaoCaoThang.asp" name="frmBCThang">
<input type="hidden" name="txtMaBoPhan">
<input type="hidden" name="txtNamBaoCao">
</form>
<script language="javascript">
	function xemchitiet(stungay, sdenngay, sloaibaocao,strehan){
		frmMain1.txtTuNgay.value=stungay;
		frmMain1.txtDenNgay.value=sdenngay;
		frmMain1.cboLoaiBaoCao.value=sloaibaocao;
		frmMain1.txtTreHan.value=strehan;
		frmMain1.submit();
	}
	
	function xemDSBaoCaoThang(sMaBoPhan, sNamBaoCao) {
		frmBCThang.txtMaBoPhan.value  = sMaBoPhan;
		frmBCThang.txtNamBaoCao.value = sNamBaoCao;
		frmBCThang.submit();
	}
</script>
</html>