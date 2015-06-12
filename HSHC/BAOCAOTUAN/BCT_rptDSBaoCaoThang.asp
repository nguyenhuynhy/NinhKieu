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
			
		FileWindow = window.open('BCT_DSBaoCaoThangPrintOut.asp?' + query,'_blank','width=' + w + ', height=' + t + ', left=0, top=0, location=no, scrollbars=yes,resizable');
	
		FileWindow.focus();
		
	}
</script>

</head>

<%
	strUser = session("UserID")
	dim strMaBoPhan
	dim strNamBaoCao
	
	strNSDQuan = isNSDQuan(strUSer)
	
	strMaBoPhan = request.Form("txtMaBoPhan")
	strNamBaoCao = request.Form("txtNamBaoCao")
	
%>
<!--#include file="inc/header.asp"-->
<title>Danh sach bao cao</title>

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
        <tr>
          <td align="left" colspan="3" width="780" >
			<a onClick="openNewWindow('MaBoPhan=<%=strMaBoPhan%>&NamBaoCao=<%=strNamBaocao%>');" style="cursor:hand" ><img src="Images/icon_print.gif" border=0></a>
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
					<td width="200"><a href="" onclick="ViewDetail('<%=rs("MaBaocao")%>');return false;"><%=rs("TieuDe")%></a></td>
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
				<tr align="center">
					<td width="100%" colspan="5" bgcolor="#f5f5dc">&nbsp;
						<input type="image" src = "images/button_trove.jpg" border = 0 alt = "Tro ve trang danh sach bao cao" name="btnTroVe" onclick="history.go(-1);return false;" ID="Image1"></td>
				</tr>
			</table>
		   </td>
		</tr>
       <!--Ket thuc - Danh sach Bao cao thang-->
		<form method="POST" action="BCT_Detail.asp" name="frmBCDetail">
			<input type="hidden" name="txtMaBaoCao">
		</form>
		
		<script language="javascript">
			function ViewDetail(sMaBaoCao){
				frmBCDetail.txtMaBaoCao.value = sMaBaoCao;
				frmBCDetail.submit();
			}

		</script>
        
       </table>

</html>