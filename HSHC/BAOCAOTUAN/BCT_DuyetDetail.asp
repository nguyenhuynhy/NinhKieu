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
					"bc.NoiDung, convert(char, bc.TuNgay, 103) TuNgay, convert(char, bc.DenNgay, 103) DenNgay, fbc.TenFile, fbc.TenFileGoc " &_
					"FROM BCT_BaoCao bc JOIN BCT_DMLoaiBaoCao lbc ON bc.MaLoaiBaoCao = lbc.MaLoaiBaoCao " &_
					"JOIN fssportalqh..Users u ON u.userid = bc.userid " &_
					"LEFT JOIN fssportalqh..View_DonVi_PhanLoai bp ON bp.MaDV = u.MaPhongBan " &_
					"LEFT JOIN BCT_FileBaoCao fbc ON fbc.MaBaoCao=bc.MaBaoCao " &_
					"WHERE bc.MaBaoCao = "&strMaBaoCao
		rs.open strSQL, CONNECTION_STRING
		set getBaoCaoByMaBaoCao = rs
	end function
	
	sub DuyetBC(strMaBaoCao, strTinhTrang)
		dim strSQL, com, con
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		strSQL="UPDATE BCT_BAOCAO SET TinhTrang=? WHERE MaBaoCao=?"
		set com=server.CreateObject("ADODB.Command")
		com.ActiveConnection=con
		com.CommandText= strSQL
		com.Parameters.Append com.CreateParameter(,adChar,adParamInput,1,strTinhTrang)
		com.Parameters.Append com.CreateParameter(,adInteger,adParamInput,,strMaBaoCao)
		com.Execute 
		set com=nothing
		set con = nothing	
	end sub

	sub DeleteBaoCao(strMaBaoCao, strUSer)
		dim con, strSQL
		set con = Server.createObject("ADODB.connection")
		con.open CONNECTION_STRING	
		
		strSQL = "UPDATE BCT_BaoCao SET TinhTrang='X', NgayXoa=getDate(), NguoiXoa ='"&strUSer&"'  WHERE MaBaoCao = " & strMaBaoCao
		con.execute strSQL
		set con = nothing
	
	end sub

	dim strMaBaoCao, strUserNAme, strNoiGui, strNgayBaoCao, strTieuDe, strNoiDung, strUSer, strTuNgay, strDenNgay, strLoaiBaoCao, strTenFile
	dim strNoiNhan

	strMaBaoCao = request.form("txtMaBaoCao")
	strUser = session("UserID")
	
	if request("btnDuyet") <>"" then	
		call DuyetBC(strMaBaoCao, request.form("btnGui"))
		response.redirect "bct_choduyet.asp"
		response.end
	end if

	if request("btnXoa.X")<>"" then
		call DeleteBaoCao(strMaBaoCao, strUSer)
		response.redirect "bct_choduyet.asp"
	end if

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
		strTenFile = rs("TenFile")
		strTenFileGoc = rs("TenFileGoc")
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
<form method="POST" action="BCT_duyetdetail.asp" name="frmMain">
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
	
	function fSubmit(svalue){
		frmMain.btnGui.value=svalue;
		frmMain.action='bct_DuyetDetail.asp?btnDuyet=Yes';
		frmMain.submit();
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
<%if strTenFileGoc<>"" then%>    
    <tr>
      <td align="right" valign="top" width="20%" bgcolor="#f5f5dc">File đính kèm&nbsp;&nbsp; </td>
      <td width="80%" bgcolor="#f5f5dc"><%=strTenFileGoc%>(<a href="" onclick="window.open('<%=replace(UPLOADPATH,"\","/") &strTenFile%>');return false">down load File</a>)</td>
    </tr>
<%end if%>    
    <tr align="center">
      <td width="100%" colspan="2" height="34" bgcolor="#f5f5dc">&nbsp;
      <%if isWriteAccess(strUSer) = true then %>
      <input type="image" border="0" src="images/button_Duyet.gif" name="btnDuyet" onclick="fSubmit('D');return false;"><input type="image" border="0" src="images/button_KhongDuyet.gif" name="btnKhongDuyet" onclick="fSubmit('K');return false;">
<input type="image" border="0" src="images/button_xoa.jpg" name="btnXoa">
<%end if%>
<input type="image" src = "images/button_trove.jpg" border = 0 alt = "Tro ve trang danh sach bao cao" name="btnTroVe" onclick="history.go(-1);return false;">
</td>
    </tr> 
  </table>  
        </td>
    </tr> 
</table>
</center>
<input type="hidden" name="txtMaBaoCao" value="<%=strMaBaoCao%>">
<input type="hidden" name="btnGui" value="">
</form>
<DIV ID="testdiv1" STYLE="position:absolute;visibility:hidden;background-color:white;layer-background-color:white;"></DIV>