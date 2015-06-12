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
	function getDSBaoCao(strLoaiBaoCao, strTuNgay, strDenNgay,strTreHan)
		dim strSQL, com, con
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		set rs = server.createObject("ADODB.recordset")
		rs.CursorLocation = 3
		set com=server.CreateObject("ADODB.Command")

		com.ActiveConnection=con
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,20,strLoaiBaoCao)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strTuNgay)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strDenNgay)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strTreHan)
		com.CommandText= "BCT_rptBaocaoChiTiet"
		com.commandType=adCmdStoredProc

		rs.open com
		set getDSBaoCao = rs
		set com=nothing
		set con = nothing					
	end function	


	strUser = session("UserID")
	dim strBoPhan, strLoaiBaoCao, strTuNgay, strNoiDung, strTieuDe, strNSDQuan, strDenNGay
	dim strBgColor
	
	strLoaiBaoCao = request.form("cboLoaiBaoCao")
'	if strLoaiBaoCao ="" then strLoaiBaoCao = "%"
	strTuNgay = request("txtTuNgay")
	strDenNgay = request("txtDenNgay")	
	strTreHan = trim(request("txtTreHan"))

	dim i
%>
<!--#include file="inc/header.asp"-->
<title>Danh sach bao cao</title>

<form method="POST" action="" name="frmMain">
<center>
      <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="780" id="AutoNumber3">            
       <tr>
          <td align="center" >            
          <img src="images/Text_DSbaocao.jpg" border="0"></td>            
        </tr>
       <tr>
          <td align="right" >            
          &nbsp;</td>            
        </tr>
       </table>   
</form>        
<form name = "frmPaging" method="post" action="BCT_rptBaoCao_DS.asp">
<input type="hidden" name="cboLoaiBaoCao" value="<%=strLoaiBaoCao%>">
<INPUT NAME="txtTuNgay" TYPE="hidden" VALUE="<%=strTuNgay%>">
<INPUT NAME="txtDenNgay" TYPE="hidden" VALUE="<%=strDenNgay%>">
<input type="hidden" name="txtTreHan" value="<%=strTreHan%>">
<input type="hidden" name="WhichPage">                  
<input type="hidden" name="fPage">                  
<input type="hidden" name="txtFromPage" value="<%=FromPage%>">
<%
	'****************************
	'Get data into variables
	'Create object for COM, 
	' devide into pages
	'*****************************
	mypage=request("whichpage")
	If mypage="" then
		mypage=1
	end if	

	frompage=request("fpage")
	If frompage="" then
		frompage=1
	end if	
	mypagesize=15

'	set rs=server.CreateObject("ADODB.recordset")

	set rs = getDSBaoCao(strLoaiBaoCao, strTuNgay, strDenNgay, strTreHan)
	
	if not rs.EOF then
		rs.movefirst
		rs.pagesize = mypagesize
		maxpages = CInt(rs.pagecount)
		maxrecs = CInt(rs.pagesize)
		rs.absolutepage = mypage
		howmanyrecs = 0
		TotalRecs = rs.recordcount
	end if	
%>
  
<table width="780" style="border-collapse: collapse" bordercolor="#111111" cellpadding="0" cellspacing="0" border="0"><tr><td>
                    &nbsp;T&#7893;ng s&#7889; <%=totalRecs%>&nbsp;m&#7851;u tin 
</td><td align="right">
                    Danh sách các trang: 
<%	
	if frompage < 10 then		
	Else
%>	
<a href="javascript:PagingCategory('<%=frompage-1%>', '<%=frompage-10%>')"><img border="0" src="images/small_back.gif"></a>
<%
	end if

	for counter=frompage to frompage + 9
		If counter > maxpages then
		Else
%>	
<a href="javascript:PagingCategory('<%=counter%>', '<%=frompage%>')" class="Special"><%=counter%></a>
<%		
	End if
	next 

	frompage = frompage + 10
	if frompage > maxpages then
		
	Else
%>
<a href="javascript:PagingCategory('<%=frompage%>', '<%=frompage%>')" class="Special"><img border="0" src="images/small_next.gif"></a>
<%		
	end if
	%>                      
          &nbsp;&nbsp;</font></font> 
</td></tr></table>
       
       <table cellSpacing="0" cellPadding="2" width="780" border="1" style="border-collapse: collapse">
		<tr align="center" bgcolor="#FCE8A0">
            <td nowrap width="3%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>STT</b></font></td>
            <td nowrap width="20%" bgcolor="#448A37" height="20">
            <font color="#FFFFFF"><b>Tiêu &#273;&#7873;&nbsp;</b></font></td>
            <td nowrap width="15%" bgcolor="#448A37">
            <b><font color="#FFFFFF">Lo&#7841;i báo 
            cáo</font></b></td>
            <td nowrap width="5%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>Ngày g&#7917;i&nbsp;</b></font></td>
            <td nowrap width="15%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            Ng&#432;&#7901;i g&#7917;i</b>&nbsp;</font></td>
            <td width="15%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            N&#417;i g&#7917;i</b>&nbsp;</font></td>
            <td width="15%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            N&#417;i Nhận</b>&nbsp;</font></td>
            <td width="10%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            Tình tr&#7841;ng</b></font></td>
          </tr>
<%
if not rs.eof then
HowManyRecs = 0
	DO UNTIL rs.eof OR HowManyRecs >= MaxRecs
		if rs("TreHan") = 0 then
			strBgColor = "#f5f5dc"
		else
			strBgColor = "#ECFFEC"		
		end if
%>          
		<tr align="center" bgcolor="<%=strBgColor%>">
            <td nowrap width="3%"><%=HowManyRecs+1%>&nbsp;</td>
            <td width="20%" height="20" align="left">&nbsp;<a href="" onclick="ViewDetail('<%=rs("MaBaocao")%>');return false;"><%=rs("TieuDe")%></a></td>
            <td nowrap width="15%"><%=rs("TenLoaiBaoCao")%>&nbsp;</td>
            <td nowrap width="5%"><%=rs("NgayGui")%>&nbsp;</td>
            <td width="15%"><%=rs("FullName")%>&nbsp;</td>
            <td width="15%"><%=rs("TenBoPhan")%>&nbsp;</td>
            <td width="15%"><%=rs("TenNoiNhan")%>&nbsp;</td>
            <td width="10%" nowrap><%=rs("TinhTrang")%>&nbsp;</td>
          </tr>
<%
				HowManyRecs = HowManyRecs + 1
				rs.movenext
			loop
	else	
%>          
<!-- Phan nay chi hien thi khi khong loc duoc du lieu -->
          <tr>
            <td colspan="8" align="center" height="16"><font color="red"><b>
            Không tìm th&#7845;y d&#7919; li&#7879;u cho ph&#7847;n này</b></font></td>
          </tr>
<%
	end if
	rs.close
	set rs = nothing
%>
          <tr>
            <td colspan="8" align="center" height="16">
			<input type="image" src = "images/button_trove.jpg" border = 0 alt = "Tro ve trang danh sach bao cao" name="I1" onclick="history.go(-1);return false;"></td>
          </tr>
        </table>
      <!--    </center>
        </div>-->
</form>
<form name="frmMain1" method = post>
<input type="hidden" name="txtMaBaoCao">
</form>
<DIV ID="testdiv1" STYLE="position:absolute;visibility:hidden;background-color:white;layer-background-color:white;"></DIV>
<script>
	function ViewDetail(sMaBaoCao){
		frmMain1.txtMaBaoCao.value=sMaBaoCao;
		frmMain1.action="BCT_Detail.asp";
		frmMain1.submit();
	}

/* function used for paging Item List */
function PagingCategory(value1, value2){
		document.frmPaging.WhichPage.value= value1;
		document.frmPaging.fPage.value= value2;
		document.frmPaging.action='BCT_rptBaoCao_DS.asp';		
		document.frmPaging.submit();
}
</script>
<table border="0" cellpadding="5" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="780" id="AutoNumber4">
  <tr>
    <td width="24%" colspan="2">&nbsp;</td>
    <td width="93%" colspan="2"><font color="#FF0000"><b>Ghi chú :</b></font></td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="4%" nowrap style="padding-left: 4; padding-right: 4; padding-top: 1; padding-bottom: 1" bgcolor="#f5f5dc" colspan="2">&nbsp;</td>
    <td width="93%" nowrap style="padding-left: 4; padding-right: 4; padding-top: 1; padding-bottom: 1">
    Báo cáo đúng hạn</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="4%" nowrap style="padding-left: 4; padding-right: 4; padding-top: 1; padding-bottom: 1" bgcolor="#ECFFEC" colspan="2">&nbsp;</td>
    <td width="93%" nowrap style="padding-left: 4; padding-right: 4; padding-top: 1; padding-bottom: 1">Báo 
    cáo trễ hạn</td>
  </tr>
</table>
</center>
</body>
</html>