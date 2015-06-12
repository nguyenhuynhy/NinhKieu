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
	function printOut() {
		document.all.imgPrint.style.visibility="hidden";
		window.print();
		document.all.imgPrint.style.visibility="visible";
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
	dim strBoPhan
	dim strYear
	dim strMonth
	dim fromDate, toDate
	
	strBoPhan = request.QueryString("MaBP")
	strLoaiBaoBieu = request.QueryString("LBB")
	strLoaiBaoCao = request.QueryString("LBC")
	strYear = request.QueryString("NamBC")
	strMonth = request.QueryString("ThangBC")
	fromDate = request.QueryString("TuNgay")
	toDate = request.QueryString("DenNgay")
	
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
%>

<title>Danh sach bao cao</title>

<script language="Javascript">
	function doprint() {
		//save existing user's info
		var h = factory.printing.header;
		var f = factory.printing.footer;
		//hide the button
		document.all("printbtn").style.visibility = 'hidden';
		//set header and footer to blank
		factory.printing.header = "";
		factory.printing.footer = "";
		factory.printing.portrait = false;
		factory.printing.leftMargin = "0.05";
		//print page without prompt
		factory.DoPrint(false);
		//restore user's info
		factory.printing.header = h;
		factory.printing.footer = f;
		//show the print button
		document.all("printbtn").style.visibility = 'visible';
	}
</script>

<style>
	table, td, tr {
		font-size:14px;
	}
</style>

<center>
      <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapsel; " bordercolor="#111111" width="780" id="AutoNumber3">
       
       <tr>
			<td align="right" colspan="3" width="100%" >
				<OBJECT id=factory style="DISPLAY: none" 
codeBase="ScriptX/ScriptX.cab#Version=5,0,4,185" 
classid=clsid:1663ed61-23eb-11d2-b92f-008048fdd814 viewastext>
				</OBJECT>
				<!--<a onClick="printOut();" style="cursor:hand" ><img src="Images/icon_print.gif" border=0 name="imgPrint"></a>
				-->
				<div id="printbtn">
					<table ID="Table6">
						<tr>
							<td>
							<a href="javascript:doprint();" class="ButtonLink"><img src="IMAGES/icon_print_16x16.gif" width="16" height="16" border="0" title="In"> 
							In ra giấy</a>
							</td>
							<td>
							<a href="javascript:window.close(this);" class="ButtonLink"><img src="IMAGES/close.gif" width="16" height="16" border="0" title="Đóng lại"> 
							Đóng cửa sổ</a>
							</td>
						</tr>
					</table>
				</div>
			</td>
       </tr>
       
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
				<td width="8%" align="center" colspan=3><b><font color="#FFFFFF">Tháng&nbsp;<%=i%></font></b></td>
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
				<td width="200"><%=rs("TenDonVi")%></td>
				<%for i=1 to 12%>
					<td width="8%" align="center">
					<%if rs("Thang"+cstr(i))=1 then 
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
					
							if rs("Thang"+cstr(i))=1 then 
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
              <td width="20%" align="right" bgcolor="#f5f5dc"><%if arrBaoCao(i,7)>0 then%><%=arrBaoCao(i,7)%><%end if%>&nbsp;</td>
              <td width="20%" align="right" bgcolor="#ECFFEC"><%if arrBaoCao(i,8)>0 then%><%=arrBaoCao(i,8)%><%end if%>&nbsp;</td>
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
					<td width="200" align="center"><b><font color="#FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phòng&nbsp;ban&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b></td>
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
					<%if rs("Value")=1 then 
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
</html>