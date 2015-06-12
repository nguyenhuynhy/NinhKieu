<%
	if isWriteAccess(session("USerID")) =fasle then
		response.redirect "result.asp"
		response.end
	end if
%>
<!--#include file="inc/lib.asp"-->
<!--#include file="inc/ADOVBS.inc"-->
<!--#include file="inc/header.asp"-->

<%
	sub RestoreBaoCao(strMaBaoCao)
		dim con, strSQL
		set con = Server.createObject("ADODB.connection")
		con.open CONNECTION_STRING	
		
		strSQL = "UPDATE BCT_BaoCao SET TinhTrang='G' WHERE MaBaoCao = " & strMaBaoCao
		con.execute strSQL
		set con = nothing	
	end sub

	function getDSBaoCao(strBoPhan, strLoaiBaoCao, strTuNgay, strDenNgay,strNoiDung, strTieuDe)
		dim strSQL, com, con
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		set rs = server.createObject("ADODB.recordset")
		rs.CursorLocation = 3
		set com=server.CreateObject("ADODB.Command")

		strSQL = "SELECT bc.MABaoCao, bc.tieuDe, convert(char, bc.NgayBaoCao, 103) NgayGui, u.Fullname, lbc.TenLoaiBaoCao, " &_
					"u.FullName NGuoixoa, convert(char, bc.NgayXoa, 103) NgayXoa, bp.TenDV as TenBoPhan " &_
				"FROM BCT_BaoCao bc JOIN BCT_DMLoaiBaoCao lbc ON bc.MaLoaiBaoCao = lbc.MaLoaiBaoCao " &_
				"JOIN fssportalqh..Users u ON u.userid = bc.userid " &_
				"LEFT JOIN fssportalqh..USERS u1 on u1.UserID = bc.NguoiXoa " &_
				"LEFT JOIN fssportalqh..View_DonVi_PhanLoai bp ON u.MaPhongBan = bp.MaDV " &_				
				"WHERE bc.TinhTrang='X' AND u.MaPhongBan like ? AND bc.MaLoaiBaoCao like ? AND bc.TieuDe like ? AND bc.NoiDung like ?"

		com.ActiveConnection=con
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,20,"%" &trim(strBoPhan)& "%")
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,20,"%" &strLoaiBaoCao& "%")
		com.Parameters.Append com.CreateParameter(,adVarwChar,adParamInput,1000,"%" & strTieuDe &"%")
		com.Parameters.Append com.CreateParameter(,adVarwChar,adParamInput,4000,"%" & strNoiDung & "%")
		if isDate(strTuNgay) then
			strSQL = strSQL & " AND convert(datetime, convert(char, bc.NgayBaoCao,103), 103) >= convert(datetime, ?,103)"
			com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strTuNgay)
		end if

		if isDate(strDenNgay) then
			strSQL = strSQL & " AND convert(datetime, convert(char, bc.NgayBaoCao,103), 103) <= convert(datetime, ?,103)"
			com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strDenNgay)
		end if

		strSQL = strSQL & " ORDER BY bp.TenDV, u.FullName"
		com.CommandText= strSQL

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
		set getFileName = rs
	end function
	
	sub DeleteBaoCao(strMaBaoCao)
		'------- xoa file truoc
		dim strFileName, myfile, sFolder, rs
		set rs = getFileName(strMaBaoCao)
		sFolder = Server.Mappath(".") & "\"  & UPLOADPATH
		
		do while not rs.eof
			strFileName = rs("TenFile")
			if strFileName<>"" then
				set myfile = CreateObject("Scripting.FileSystemObject")
				if myfile.FileExists(sFolder & "\" & strFileName) then
					myfile.Deletefile sFolder & "\" & strFileName
				end if			
				set myfile = nothing
			end if
			rs.movenext
		loop
		rs.close
		set rs = nothing
		
		' ---- gio toi xoa du lieu		
		dim con, strSQL
		set con = Server.createObject("ADODB.connection")
		con.open CONNECTION_STRING	
		
		strSQL = "DELETE BCT_FileBaoCao WHERE MaBaoCao = " & strMaBaoCao
		con.execute strSQL

		strSQL = "DELETE BCT_NoiNhan WHERE MaBaoCao = " & strMaBaoCao
		con.execute strSQL
		
		strSQL = "DELETE BCT_BaoCao WHERE MaBaoCao = " & strMaBaoCao
		con.execute strSQL		
		set con = nothing
	end sub

	
	if request("btnPhucHoi.X")<>"" then
		for i = 1 to request.form.item("chkDelete").count
			call RestoreBaoCao(request.form.item("chkDelete")(i))
		next
	end if

	if request("btnXoa.X")<>"" then
		for i = 1 to request.form.item("chkDelete").count
			call DeleteBaoCao(request.form.item("chkDelete")(i))
		next
	end if
%>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
<%
	strUser = session("UserID")
	dim strBoPhan, strLoaiBaoCao, strTuNgay, strNoiDung, strTieuDe, strNSDQuan, strDenNGay
	strNSDQuan = isNSDQuan(strUSer)
	strBoPhan = request.form("cboBoPhan")
	if strBoPhan ="" then 

			strBoPhan = session("DeptID")

	end if
	
	strLoaiBaoCao = request.form("cboLoaiBaoCao")
	if strLoaiBaoCao ="" then strLoaiBaoCao = "%"
	strTuNgay = request("txtTuNgay")
	strDenNgay = request("txtDenNgay")	
	strNoiDung = request("txtNoiDung")
	strTieuDe = request("txtTieuDe")

	dim i
%>
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
          <td align="center" colspan="5" width="100%" >            
          <img src="images/Text_DSBCDaXoa.jpg" border="0"></td>            
        </tr>
       <tr>
          <td width="100%" align="right" colspan="5" >            
          &nbsp;</td>            
        </tr>
       <tr>
          <td width="40%" align="right">            
          <font color="#184798">Đơn vị:&nbsp; </font></td>            
          <td width="60%" colspan="4">                      
              <select size="1" name="cboBoPhan" style="font-family: Arial; font-size: 12px">
<%if strNSDQuan = true then%>              
			<option value="%">Tất cả</option>              
              <%
end if              
              	set rs = getBoPhanbyUser(strUser)
              	do while not rs.eof 
              %>
				<option value="<%=rs("MaBoPhan")%>"<%if strBoPhan=rs("MaBoPhan") then%> selected<%end if%>><%=rs("TenBoPhan")%></option>
              <%
              		rs.movenext
              	loop
              	rs.close
              	set rs = nothing
              %>
              </select></td>            
        </tr>
       <tr>
          <td width="40%" align="right">            
          <font color="#184798">Loại báo cáo:</font></td>            
          <td width="60%" colspan="4">                      
              <select size="1" name="cboLoaiBaoCao" style="font-family: Arial; font-size: 12px">
			<option value="%">Tất cả</option>              
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
          <td width="40%" align="right" >            
          <font color="#184798">Ngày gửi:</font></td>            
          <td width="10%">&nbsp; &nbsp;từ ngày&nbsp;</td>            
          <td width="20%"><INPUT NAME="txtTuNgay" TYPE="text" VALUE="<%=strTuNgay%>" SIZE=11> 
                  <A HREF="#" onClick="cal1.select(document.frmMain.txtTuNgay,'anchor1','dd/MM/yyyy'); return false;" NAME="anchor1" ID="anchor1">
      <img src="images/cal.gif" width="16" height="16" border="0" title="click here to update the timestamp"></A></td>            
          <td width="10%">đến ngày</td>
          <td width="231"><INPUT NAME="txtDenNgay" TYPE="text" VALUE="<%=strDenNgay%>" SIZE=11> 
                  <A HREF="#" onClick="cal2.select(document.frmMain.txtDenNgay,'anchor2','dd/MM/yyyy'); return false;" NAME="anchor2" ID="anchor2">
      <img src="images/cal.gif" width="16" height="16" border="0" title="click here to update the timestamp"></A></td>            
        </tr>
       <tr>
          <td width="40%" align="right">
          <font color="#184798">Tiêu đề:</font></td>
          <td width="60" colspan="4">            
            <input type=text name="txtTieuDe" size=40 maxlength=50 value="<%=strTieuDe%>"></td>
        </tr>
       <tr>
          <td width="40%" align="right">            
          <font color="#184798">Nội dung:</font></td>            
          <td width="60" colspan="4">            
            <input type=text name="txtnoiDung" size=40 maxlength=50 value="<%=strNoiDung%>"></td>            
        </tr>
       <tr>            
          <td width="100%" align="right" colspan="5">            
          &nbsp;</td>            
        </tr>            
        <tr>
        <td width ="100%" align="center"  colspan="5">
        <b><font color="#1D4D77">            
          &nbsp;            
          <input type="image" src = "Images/button_LocThongTin.jpg" border = 0 alt = "Tro ve trang chu" ></font></b>
        </td>
        </tr> 
      </table>   
</center>
</form>        
<form name = "frmPaging" method="post" action="BCT_DeleteList.asp">
<input type="hidden" name="cboBoPhan" value="<%=strBoPhan%>">
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

	set rs = getDSBaoCao(strBoPhan, strLoaiBaoCao, strTuNgay, strDenNgay, strNoiDung, strTieuDe)
	
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
<div align="center">
  <center>
<table width="780" style="border-collapse: collapse" bordercolor="#111111" cellpadding="0" cellspacing="0"><tr><td>
                    &nbsp;Tổng số <%=totalRecs%>&nbsp;mẫu tin 
</td><td align="right">
                    Danh sách các trang: 
<%	
	if frompage < 10 then		
	Else
%>	
<a href="javascript:PagingCategory('<%=frompage-1%>', '<%=frompage-10%>')">
                    <img border="0" src="images/small_back.gif"></a>
<%
	end if

	for counter=frompage to frompage + 9
		If counter > maxpages then
		Else
%>	
<a href="javascript:PagingCategory('<%=counter%>', '<%=frompage%>')"><%=counter%></a>
<%		
	End if
	next 

	frompage = frompage + 10
	if frompage > maxpages then
		
	Else
%>
<a href="javascript:PagingCategory('<%=frompage%>', '<%=frompage%>')">
                    <img border="0" src="images/small_next.gif"></a>
<%		
	end if
	%>                      
          &nbsp;&nbsp;</font></font> 
</td></tr></table>
        </center>
</div>
        <div align="center">
          <center>
       <table cellSpacing="0" cellPadding="0" width="780" border="1" style="border-collapse: collapse">
		<tr align="center" bgcolor="#FCE8A0">
            <td nowrap width="3%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>STT</b></font></td>
            <td nowrap width="2%" bgcolor="#448A37">
            &nbsp;</td>
            <td nowrap width="25%" bgcolor="#448A37" height="20">
            <font color="#FFFFFF"><b>Tiêu đề&nbsp;</b></font></td>
            <td nowrap width="10%" bgcolor="#448A37">
            <b><font color="#FFFFFF">Loại báo 
            cáo</font></b></td>
            <td nowrap width="10%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>Ngày gửi&nbsp;</b></font></td>
            <td nowrap width="15%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            Người gửi</b>&nbsp;</font></td>
            <td nowrap width="10%" bgcolor="#448A37">
            <font color="#FFFFFF"><b>
            Nơi gửi</b>&nbsp;</font></td>
      <td nowrap width="10%" bgcolor="#448A37" height="20">
      <font color="#FFFFFF"><b>Ngày xoá</b></font></td>
      <td nowrap width="15%" bgcolor="#448A37" height="20">
      <font color="#FFFFFF"><b>
      Người xoá</b></font></td>
          </tr>
<%
if not rs.eof then
HowManyRecs = 0
	DO UNTIL rs.eof OR HowManyRecs >= MaxRecs
%>          
		<tr align="center" bgcolor="#f5f5dc">
            <td nowrap width="3%"><%=HowManyRecs+1%>&nbsp;</td>
            <td nowrap width="2%"><input type="checkbox" name="chkDelete" value="<%=rs("MaBaoCao")%>"></td>
            <td width="25%" height="20" align="left">&nbsp;<a href="" onclick="ViewDetail('<%=rs("MaBaocao")%>');return false;"><%=rs("TieuDe")%></a></td>
            <td nowrap width="10%">
            <p align="left">&nbsp;<%=rs("TenLoaiBaoCao")%></td>
            <td nowrap width="10%">&nbsp;<%=rs("NgayGui")%></td>
            <td nowrap width="15%">
            <p align="left">&nbsp;<%=rs("FullName")%></td>
            <td nowrap width="10%">
            <p align="left">&nbsp;<%=rs("TenBoPhan")%></td>
      <td align="center" bgcolor="<%=backcolor%>" width="10%" height="20"><%=rs("ngayxoa")%>&nbsp;</td>
	  <td align="left" bgcolor="<%=backcolor%>" width="15%" height="20">&nbsp;<%=rs("nguoixoa")%></td>
          </tr>
<%
				HowManyRecs = HowManyRecs + 1
				rs.movenext
			loop
	else	
%>          
<!-- Phan nay chi hien thi khi khong loc duoc du lieu -->
          <tr>
            <td colspan="9" align="center" height="16"><font color="red"><b>
            Không tìm thấy dữ liệu cho phần này</b></font></td>
          </tr>
<%
	end if
	rs.close
	set rs = nothing
%>          
          <tr valign="top">
            <td colspan = 9 height="19" align="center"><input type="image" border="0" src="images/button_phuchoi.gif" name="btnPhucHoi"><input type="image" border="0" src="images/button_xoa.jpg" name="btnXoa" alt="Xoa bao cao khoi he thong, ban khong the phuc hoi duoc sau khi da xoa"></td>
          </tr>
        </table>
          </center>
        </div>
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
		document.frmPaging.action='BCT_DeleteList.asp';		
		document.frmPaging.submit();
}
</script>
</body>
</html>