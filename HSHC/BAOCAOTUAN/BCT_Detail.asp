<!--#include file="inc/ADOVBS.inc"-->
<!--#include file="inc/lib.asp"-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>

<%	
	function getBaoCaoByMaBaoCao(strMaBaoCao)
		dim rs
		set rs = server.createObject("ADODB.recordset")
		strSQL = "SELECT bc.MABaoCao, bc.tieuDe, convert(char, bc.NgayBaoCao, 101) NgayGui, u.Fullname, lbc.TenLoaiBaoCao, bp.TenDV tenBoPhan, " &_
					"bc.NoiDung, convert(char, bc.TuNgay, 103) TuNgay, convert(char, bc.DenNgay, 103) DenNgay " &_
					"FROM BCT_BaoCao bc JOIN BCT_DMLoaiBaoCao lbc ON bc.MaLoaiBaoCao = lbc.MaLoaiBaoCao " &_
					"JOIN fssportalqh..Users u ON u.userid = bc.userid " &_
					"LEFT JOIN fssportalqh..View_DonVi_PhanLoai bp ON bp.MaDV = u.MaPhongBan " &_
					"WHERE bc.MaBaoCao = "&strMaBaoCao
		rs.open strSQL, CONNECTION_STRING
		set getBaoCaoByMaBaoCao = rs
	end function
	
	function getFileBaoCao(strMaBaoCao)
		dim rs
		set rs = server.createObject("ADODB.recordset")
		strSQL = "SELECT fbc.MaBaoCao, fbc.TenFile, fbc.TenFileGoc " &_
					"FROM BCT_FileBaoCao fbc " &_
					"WHERE fbc.MaBaoCao = "&strMaBaoCao
		rs.open strSQL, CONNECTION_STRING
		set getFileBaoCao = rs
	end function	
	
	dim strMaBaoCao, strUserNAme, strNoiGui, strNgayBaoCao, strTieuDe, strNoiDung, strUSer, strTuNgay, strDenNgay, strLoaiBaoCao, strTenFile
	dim strNoiNhan
	strMaBaoCao = request.form("txtMaBaoCao")
	set rs =getBaoCaoByMaBaoCao(strMaBaoCao)
	if not rs.eof then
		strNoiGui = rs("TenBoPhan")
		strUserNAme =  rs("Fullname")
		strNgayBaoCao = rs("NgayGui")
		strTieuDe = rs("TieuDe")
		strNoiDung = rs("Noidung")
		strTuNgay = rs("TuNgay")
		strDenNgay = rs("DenNgay")
		strLoaiBaoCao = rs("TenLoaiBaoCao")
	end if	
	rs.close
	
	set rs =getNoiNhanByMaBaoCao(strMaBaoCao)
	do while not rs.eof
		strNoiNhan = strNoiNhan & rs("FullName") & "; "
		rs.movenext
	loop
	rs.close	
	set rs= nothing
	
%>
<!--#include file="inc/header.asp"-->
<center>
<form method="POST" action="BCT_List.asp" name="frmMain">
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

<table border="0" cellpadding="0" cellspacing="0" width = "780" bgcolor=Snow style="border-collapse: collapse" bordercolor="#111111">
    <tr> 
		<td height="56" align="center">
        <img src="images/Text_NDBaoCao.jpg" border="0"></td>
    </tr> 
    <tr> 
		<td height="56" align="center">  
  <table width="100%" cellpadding="3" cellspacing="0" bgcolor=#FDF1CA border=1 bordercolor = "#428C31" style="border-collapse: collapse">
    <tr>
      <td width="20%"  height="29" bgcolor="#f5f5dc" align="right">
        Người gửi:&nbsp;&nbsp; </td>
      <td width="80%" height="29" bgcolor="#f5f5dc">&nbsp;<%=strUserName%>-<%=strNoiGui%></td>
    </tr>
    <tr>
      <td width="20%"  height="29" bgcolor="#f5f5dc">
        <p align="right">Nơi nhận:&nbsp;</td>
      <td width="80%" height="29" bgcolor="#f5f5dc"><%=strNoiNhan%></td>
    </tr>
    <tr>
      <td align="right" height="29" width="20%" bgcolor="#f5f5dc">Loại báo cáo<font color="black">:</font><font color="#FF0000">*&nbsp;</font></td>
      <td height="29" width="80%" bgcolor="#f5f5dc"><%=strLoaiBaoCao%></td>
    </tr>
    <tr>
      <td align="right" height="29" width="20%" bgcolor="#f5f5dc">
      Thời gian:<font color="#FF0000"> * </font></td>
      <td height="29" width="80%" bgcolor="#f5f5dc">Từ ngày&nbsp;<%=strTuNgay%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      đến ngày&nbsp; <%=strDenNGay%></td>
    </tr>
    <tr>
      <td align="right" height="29" width="20%" bgcolor="#f5f5dc">
      <font color="black">Tiêu đề:</font><font color="#FF0000">*&nbsp;</font></td>
      <td height="29" width="80%" bgcolor="#f5f5dc"><%=strTieuDe%></td>
    </tr>
    <tr>
      <td align="right" valign="top" width="20%" bgcolor="#f5f5dc">
      <font color="black">Nội dung:</font><font color="#FF0000">*&nbsp;</font></td>
      <td width="80%" bgcolor="#f5f5dc"><%=strNoiDung%>&nbsp;</td>
    </tr>
<%
	set rs = getFileBaoCao(strMaBaoCao)
	if not rs.eof then
		strTenFileGoc = "cofile"
	end if	

if strTenFileGoc<>"" then
%>    
    <tr>
      <td align="right" valign="top" width="20%" bgcolor="#f5f5dc">File đính kèm&nbsp;&nbsp; </td>
      <td width="80%" bgcolor="#f5f5dc"><%	do while not rs.eof %>
<%=rs("TenFileGoc")%>(<a href="" onclick="window.open('<%=replace(UPLOADPATH,"\","/") &rs("TenFile")%>');return false">down load File</a>); <%
		rs.movenext
	loop
	rs.close
	set rs = nothing
	%>
</td>
    </tr>
<%
end if
%>  

    <tr align="center">
      <td width="100%" colspan="2" height="34" bgcolor="#f5f5dc"><%if isWriteAccess(session("UserID")) = true then %><!--<img border=0 src="images/ChinhSua.gif" name="btnSoanBaoCao">--><%end if%>&nbsp;
			<input type="image" src = "images/button_trove.jpg" border = 0 alt = "Tro ve trang danh sach bao cao" name="btnTroVe" onclick="history.go(-1);return false;"></td>
    </tr>
 
  </table>  
        </td>
    </tr> 
</table>
</center>
<input type="hidden" name="btnGui" value="nhunhu">
</form>

<DIV ID="testdiv1" STYLE="position:absolute;visibility:hidden;background-color:white;layer-background-color:white;"></DIV>