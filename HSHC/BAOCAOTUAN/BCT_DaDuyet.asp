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
	function getDSBaoCao(strKhoiID, strLoaiBaoCao, strTuNgay, strDenNgay,strNoiDung, strTieuDe)
		dim strSQL, com, con
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		set rs = server.createObject("ADODB.recordset")
		rs.CursorLocation = 3
		set com=server.CreateObject("ADODB.Command")

		com.ActiveConnection=con
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,20,trim(strKhoiID))
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,20,strLoaiBaoCao)
		com.Parameters.Append com.CreateParameter(,adVarwChar,adParamInput,1000, strTieuDe)
		com.Parameters.Append com.CreateParameter(,adVarwChar,adParamInput,4000, strNoiDung)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strTuNgay)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strDenNgay)
		com.CommandText= "BCT_DSBaocaoDaDuyet"
		com.commandType=adCmdStoredProc

		rs.open com
		set getDSBaoCao = rs
		set com=nothing
		set con = nothing					
	end function	


	function getFileName(strMaBaoCao)
		dim con, strSQL, rs
		set rs = server.createObject("ADODB.recordset")
		strSQL = "SELECT TenFile from BCT_FileBaoCao WHERE MaBaoCAo=" & strMaBaoCao
		rs.open strSQL, CONNECTION_STRING
		if not rs.eof then
			getFileName = rs("TenFile")
		else
			getFileName = ""
		end if
		rs.close
		set rs = nothing
	end function	
%>
<%
	strUser = session("UserID")
	dim strKhoiID, strLoaiBaoCao, strTuNgay, strNoiDung, strTieuDe, strNSDQuan, strDenNGay
	dim strBgColor
	strNSDQuan = isNSDQuan(strUSer)
	strKhoiID = request.form("cbokhoi")
	strLoaiBaoCao = request.form("cboLoaiBaoCao")
	if strLoaiBaoCao ="" then strLoaiBaoCao = "%"
	strTuNgay = request("txtTuNgay")
	strDenNgay = request("txtDenNgay")	
	strNoiDung = request("txtNoiDung")
	strTieuDe = request("txtTieuDe")

	if strTuNgay = "" and strDenNgay = "" then
		strTuNgay = "01/" & right("0" & month(date),2) & "/" & year(date)
		strDenNgay =  right("0" & day(date),2)& "/" & right("0" & month(date),2) & "/" & year(date)
	end if
	dim i
%>
<!--#include file="inc/header.asp"-->
<title>Danh sach bao cao</title>

<form method="POST" action="" name="frmMain">
<SCRIPT LANGUAGE="JavaScript" SRC="script/AnchorPosition.js"></SCRIPT>
<SCRIPT LANGUAGE="JavaScript" SRC="script/PopupWindow.js"></SCRIPT>
<SCRIPT LANGUAGE="JavaScript" SRC="script/CalendarPopup.js"></SCRIPT> 
<SCRIPT LANGUAGE="JavaScript" SRC="script/date.js"></SCRIPT>
<SCRIPT LANGUAGE="JavaScript">document.write(CalendarPopup_getStyles());</SCRIPT>
<SCRIPT LANGUAGE="JavaScript">
var cal1 = new CalendarPopup("testdiv1");
var cal2 = new CalendarPopup("testdiv1");

	var Awnd=null;
	window.name ="Input Leave Detail"
	var Remote=null;
	function RS(Name,Url,Width,Height,Op){
		var option;
	// Purpose of this function is to open the page whose name and path is 
	//taken from Variable Name and Url 
	option="toolbar=0, align=center, status=0,menubar=0,scrollbars==1, resizable=0,width=600,height=250,titlebar=0,location=0";            	           
	Remote=window.open(Url,Name,option);
		if (Remote!=null) {
		//This snip code to ensure that only one window is opened regardless 
		// how many time the user click
			if(Remote.opener==null) Remote.opener=self;
		}
		if(Op==1) return Remote;	
	}
	
		function openWindow(){		
		FileWindow = window.open('BCT_AttachFiles.asp?ID=<%=strID%>&AttachedFile=<%=strFileName%>','Recipient','toolbar=0,scrollbars=1, alwaysRaised=Yes, width=550, height=200,1 ,align=center');
		FileWindow.focus();
	}	
              </SCRIPT>
<center>
      <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="780" id="AutoNumber3">            
       <tr>
          <td align="center" colspan="5" >            
          <img src="images/Text_DSbaocao.jpg" border="0"></td>            
        </tr>
       <tr>
          <td align="right" colspan="5" >            
          &nbsp;</td>            
        </tr>
       <tr>
          <td width="30%" align="right">            
          <font color="#184798">Khối:&nbsp; </font></td>            
          <td width="60%" colspan="4">                      
              <select size="1" name="cboKhoi" style="font-family: Arial; font-size: 12px">
			<option value="">T&#7845;t c&#7843;</option>              
              <%
              	set rs = getDMKhoi()
              	do while not rs.eof 
              %>
				<option value="<%=rs("KhoiID")%>"<%if CStr(strKhoiID)=CStr(rs("KhoiID")) then%> selected<%end if%>><%=rs("TenKhoi")%></option>
              <%
              		rs.movenext
              	loop
              	rs.close
              	set rs = nothing
              %>
              </select></td>            
        </tr>
       <tr>
          <td width="30%" align="right">            
          <font color="#184798">Lo&#7841;i báo cáo:</font></td>            
          <td width="60%" colspan="4">                      
              <select size="1" name="cboLoaiBaoCao" style="font-family: Arial; font-size: 12px">
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
        </tr>
       <tr>
          <td width="30%" align="right" >            
          <font color="#184798">Ngày g&#7917;i:</font></td>            
          <td width="10%">&nbsp; &nbsp;t&#7915; ngày&nbsp;</td>            
          <td width="20%"><INPUT NAME="txtTuNgay" TYPE="text" VALUE="<%=strTuNgay%>" SIZE=11> 
                  <A HREF="#" onClick="cal1.select(document.frmMain.txtTuNgay,'anchor1','dd/MM/yyyy'); return false;" NAME="anchor1" ID="anchor1">
      <img src="images/cal.gif" width="16" height="16" border="0" title="click here to update the timestamp"></A></td>            
          <td width="10%">&#273;&#7871;n ngày</td>
          <td><INPUT NAME="txtDenNgay" TYPE="text" VALUE="<%=strDenNgay%>" SIZE=11> 
                  <A HREF="#" onClick="cal2.select(document.frmMain.txtDenNgay,'anchor2','dd/MM/yyyy'); return false;" NAME="anchor2" ID="anchor2">
      <img src="images/cal.gif" width="16" height="16" border="0" title="click here to update the timestamp"></A></td>            
        </tr>
       <tr>
          <td width="30%" align="right">
          <font color="#184798">Tiêu &#273;&#7873;:</font></td>
          <td width="60%" colspan="4">            
            <input type=text name="txtTieuDe" size=40 maxlength=50 value="<%=strTieuDe%>"></td>
        </tr>
       <tr>
          <td width="30%" align="right">            
          <font color="#184798">N&#7897;i dung:</font></td>            
          <td width="60%" colspan="4">            
            <input type=text name="txtnoiDung" size=40 maxlength=50 value="<%=strNoiDung%>"></td>            
        </tr>
       <tr>            
          <td align="right" colspan="5">            
          &nbsp;</td>            
        </tr>            
        <tr>
        <td align="center"  colspan="5">
        <b><font color="#1D4D77">            
          &nbsp;            
          <input type="image" src = "Images/button_LocThongTin.jpg" border = 0 alt = "Tro ve trang chu" ></font></b>
        </td>
        </tr> 
      </table>   
</form>        
<form name = "frmPaging" method="post" action="BCT_List.asp">
<input type="hidden" name="cboKhoi" value="<%=strKhoiID%>">
<input type="hidden" name="cboLoaiBaoCao" value="<%=strLoaiBaoCao%>">
<INPUT NAME="txtTuNgay" TYPE="hidden" VALUE="<%=strTuNgay%>">
<INPUT NAME="txtDenNgay" TYPE="hidden" VALUE="<%=strDenNgay%>">
<input type="hidden" name="txtTieuDe" value="<%=strTieuDe%>">
<input type="hidden" name="txtnoiDung" value="<%=strNoiDung%>">
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

	set rs = getDSBaoCao(strKhoiID, strLoaiBaoCao, strTuNgay, strDenNgay, strNoiDung, strTieuDe)
	
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
            <td nowrap width="10%" bgcolor="#448A37">
            <b><font color="#FFFFFF">Lo&#7841;i báo 
            cáo</font></b></td>
            <td nowrap width="5%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>Ngày g&#7917;i&nbsp;</b></font></td>
            <td nowrap width="15%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            Ng&#432;&#7901;i g&#7917;i</b>&nbsp;</font></td>
            <td width="*" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            N&#417;i g&#7917;i</b>&nbsp;</font></td>
            <td width="*" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            N&#417;i nhận</b>&nbsp;</font></td>
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
		<%
		'Response.Write MaxRecs &  "a"
		'Response.Write mypage   & "b"
		'Response.Write howmanyrecs & "c"
		%>
            <td nowrap width="3%"><%=MaxRecs*(mypage-1)+HowManyRecs+1%>&nbsp;</td>
            <td width="20%" height="20" align="left">&nbsp;<a href="" onclick="ViewDetail('<%=rs("MaBaocao")%>');return false;"><%=rs("TieuDe")%></a></td>
            <td nowrap width="10%"><%=rs("TenLoaiBaoCao")%>&nbsp;</td>
            <td nowrap width="5%"><%=rs("NgayGui")%>&nbsp;</td>
            <td width="15%" align="left"><%=rs("FullName")%>&nbsp;</td>
            <td width="*" align="left"><%=rs("TenBoPhan")%>&nbsp;</td>
            <td width="*" align="left"><%=rs("TenNoiNhan")%>&nbsp;</td>            
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
        </table>
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
		document.frmPaging.action='BCT_DaDuyet.asp';		
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