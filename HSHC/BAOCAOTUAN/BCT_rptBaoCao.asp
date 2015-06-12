<%
	'if session("UserID") = "" then
	'	response.redirect "Login.asp"
	'end if
%>
<!--#include file="inc/lib.asp"-->
<!--#include file="inc/ADOVBS.inc"-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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
	strNSDQuan = isNSDQuan(strUSer)
	strBoPhan = request.form("cboBoPhan")
	if strBoPhan ="" then 
		strBoPhan = session("DeptID")
	end if
	
	
	strLoaiBaoCao = request.form("cboLoaiBaoCao")
	if strLoaiBaoCao ="" then strLoaiBaoCao = "BCT"
	
	strYear = request.form("cboYear")
	if strYear = "" then strYear = year(date)
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
<!--#include file="inc/header.asp"-->
<title>Danh sach bao cao</title>

<form method="POST" action="bct_rptbaocao.asp" name="frmMain">
<SCRIPT LANGUAGE="JavaScript" SRC="script/date.js"></SCRIPT>
<center>
      <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="780" id="AutoNumber3">            
       <tr>
          <td align="center" colspan="3" width="780" >            
          <img src="images/Text_DSbaocao.jpg" border="0"></td>            
        </tr>
       <tr>
          <td align="right" colspan="3" width="780" >            
          &nbsp;</td>            
        </tr>
       <tr>
          <td width="260" align="right"><font color="#184798">Lo&#7841;i báo cáo:</font></td>            
          <td width="159">                      
              <select size="1" name="cboLoaiBaoCao" style="font-family: Arial; font-size: 12px" onchange="frmMain.submit();">
			<option value="%">T&#7845;t c&#7843;</option>         
              <%
              	set rs = getLoaiBaoCaoAll()
              	do while not rs.eof 
              %>
				<option value="<%=rs("MaLoaiBaoCao")%>" <% if strLoaiBaoCao = rs("MaLoaiBaoCao") then%>selected<%end if%>><%=rs("TenLoaiBaoCao")%></option>
              <%
              		rs.movenext
              	loop
              	rs.close
              	set rs = nothing
              %>
              </select></td>            
          <td width="361">                      
              <font color="#184798">Năm báo cáo: </font>                      
              <select size="1" name="cboYear" style="font-family: Arial; font-size: 12px" onchange="frmMain.submit();">
              <%
              		for i = year(date) - 1 to year(date)
              %>
				<option value="<%=i%>" <% if cstr(stryear) = cstr(i) then%>selected<%end if%>><%=i%></option>
              <%
              		next
			%>
              </select></td>            
        </tr>
       <tr>
          <td align="right" width="260" >&nbsp;</td>
          <td align="right" colspan="2" width="520" >            
          <p align="left">                      
              &nbsp;</td>            
        </tr>
       <tr>
          <td align="right" colspan="3" width="780" >
          <table border="0" cellpadding="0" cellspacing="1" style="border-collapse: collapse" bordercolor="#111111" width="100%" id="AutoNumber4">
            <tr bgcolor="#448A37" height="18">
              <td width="20%" align="center"><b><font color="#FFFFFF">Loại báo cáo</font></b></td>
              <td width="40%" align="center">&nbsp;</td>
              <td width="20%" align="center"><b><font color="#FFFFFF">&nbsp;Đúng hạn</font></b></td>
              <td width="20%" align="center"><b><font color="#FFFFFF">Trễ hạn</font></b></td>
            </tr>
            <% for i = 1 to numRow%>
            <tr height="15">
              <td width="20%" bgcolor="#f5f5dc">&nbsp;<%=arrBaoCao(i,1)%></td>
              <td width="40%" bgcolor="#f5f5dc">&nbsp;từ ngày <%=arrBaoCao(i,5)%> đến ngày <%=arrBaoCao(i,6)%></td>
              <td width="20%" align="right" bgcolor="#f5f5dc"><%if arrBaoCao(i,7)>0 then%><a href="" onclick="xemchitiet('<%=arrBaoCao(i,5)%>','<%=arrBaoCao(i,6)%>','<%=arrBaoCao(i,0)%>','');return false;"><%=arrBaoCao(i,7)%></a><%end if%>&nbsp;</td>
              <td width="20%" align="right" bgcolor="#ECFFEC"><%if arrBaoCao(i,8)>0 then%><a href="" onclick="xemchitiet('<%=arrBaoCao(i,5)%>','<%=arrBaoCao(i,6)%>','<%=arrBaoCao(i,0)%>','true');return false;"><%=arrBaoCao(i,8)%></a><%end if%>&nbsp;</td>
            </tr>
            <%next%>
          </table>
          </td>            
        </tr>
       </table>   
</form>
<form method="POST" action="bct_rptbaocao_DS.asp" name="frmMain1">
<input type="hidden" name="txtTuNgay">
<input type="hidden" name="txtDenNgay">
<input type="hidden" name="cboLoaiBaoCao">
<input type="hidden" name="txtTreHan">
</form>
<script language="javascript">
	function xemchitiet(stungay, sdenngay, sloaibaocao,strehan){
		frmMain1.txtTuNgay.value=stungay;
		frmMain1.txtDenNgay.value=sdenngay;
		frmMain1.cboLoaiBaoCao.value=sloaibaocao;
		frmMain1.txtTreHan.value=strehan;
		frmMain1.submit();
	}
</script>
</html>