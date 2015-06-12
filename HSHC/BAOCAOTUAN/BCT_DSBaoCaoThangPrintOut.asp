<%
	'if session("UserID") = "" then
	'	response.redirect "Login.asp"
	'end if
%>
<!--#include file="inc/lib.asp"-->
<!--#include file="inc/ADOVBS.inc"-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

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

</head>

<%
	strUser = session("UserID")
	dim strMaBoPhan
	dim strNamBaoCao
	
	strNSDQuan = isNSDQuan(strUSer)
	
	strMaBoPhan = request.QueryString("MaBoPhan")
	strNamBaoCao = request.QueryString("NamBaoCao")
	
%>

<title>Danh sach bao cao</title>


<center>
      <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="780" id="AutoNumber3">
       <tr>
          <td align="right" colspan="3" width="780" >&nbsp;</td>
        </tr>
        <tr>
          <td align="right" colspan="3" width="780" >
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
        <!--Danh sach data Bao cao thang-->
       <tr>
          <td align="right" colspan="3" width="100%" >
			<table border="1" cellpadding="3" cellspacing="1" style="border-collapse: collapse" bordercolor="#CCCCCC" width="100%" id="Table5">
				<%
				IF strMaBoPhan <>"" and strNamBaoCao<>"" then
					set rs = BCT_DSBaoCaoThang(strMaBoPhan, strNamBaoCao)
					dim count
					
					count = 0
					while not rs.eof and count<5
				%>
				<tr height="15" bgcolor="#ECFFEC">
					<td colspan="5"><b><font color="#036D1E"><%=rs("TenDonVi")%></font></b></td>
				</tr>
				<%	
						count = 5	
						rs.movenext
              		wend
					rs.close
					set rs = nothing
				end if
				%>
				<tr bgcolor="#448A37" height="18">
					<td width="200" align="center"><b><font color="#FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tiêu đề&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b></td>
					<td width="20%" align="center"><b><font color="#FFFFFF">Ngày báo cáo</font></b></td>
					<td width="20%" align="center"><b><font color="#FFFFFF">Từ ngày</font></b></td>
					<td width="20%" align="center"><b><font color="#FFFFFF">Đến ngày</font></b></td>
					<td width="20%" align="center"><b><font color="#FFFFFF">Tình trạng</font></b></td>
				</tr>
				<%
				IF strMaBoPhan <>"" and strNamBaoCao<>"" then
					set rs = BCT_DSBaoCaoThang(strMaBoPhan, strNamBaoCao)
					
					while not rs.eof 
				%>
				<tr height="15" bgcolor="#f5f5dc">
					<td width="200"><%=rs("TieuDe")%></td>
					<td width="8%" align="center"><%=rs("NgayBaoCao")%></td>
					<td width="8%" align="center"><%=rs("TuNgay")%></td>
					<td width="8%" align="center"><%=rs("DenNgay")%></td>
					<td width="8%" align="center"><%=rs("TinhTrang")%></td>
				</tr>
				<%		
              			rs.movenext
					wend
					rs.close
					set rs = nothing
				end if
				%>
			</table>
		   </td>
		</tr>
        
       </table>

</html>