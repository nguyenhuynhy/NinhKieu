<!--#include file="inc/ADOVBS.inc"-->
<!--#include file="inc/lib.asp"-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
<title>Soan moi bao cao</title>
<%	
'----------- tinh trang bao cao -----------
' G: Gui cho duyet bao cao
' D: Da duyet
' X: Xoa bao cao
'------------------------------------------------

	if isWriteAccess(session("USerID")) =fasle then
		response.redirect "result.asp"
		response.end
	end if

	'------------- ham kiem tra xem co goi bao cao nay ve Quan chua, neu co roi thi tra ve true --------------
	function checkDuplicate(strLoaiBaoCao, strTuNgay, strDenNgay, strNguoiGui, strNoiNhan)
		dim strSQL, rs
		strSQL = "SELECT bc.mabaocao, tungay, manoinhan, userID " &_
					"FROM bct_baocao bc join bct_noinhan nn on bc.mabaocao = nn.mabaocao " &_
					"where bc.tinhtrang<>'X' and convert(char,bc.tungay,103) = '" & strTuNgay & "' and convert(char,bc.denngay,103) = '"& strDenNgay &"' " &_
					"and manoinhan='"& strNoiNhan &"' and userid='"& strNguoiGui &"' AND MaLoaiBaoCao = '" & strLoaiBaoCao & "'"
		set rs = server.createObject("ADODB.recordset")
		rs.open strSQL, CONNECTION_STRING
		if not rs.eof then
			checkDuplicate = true
		else
			checkDuplicate = false
		end if
		
		rs.close
		set rs = nothing		
	end function 
	
	
	function getMaBaoCao(strUser)
		dim rs, strSQL
		set rs = server.createObject("ADODB.recordset")
		strSQL="select max(MaBaoCao) Mabaocao from BCT_BaoCao where userID='" & strUser & "'"
		rs.open strSQL, CONNECTION_STRING
		if not rs.eof then
			getMaBaoCao = rs("MaBaoCao")
		else
			getMaBaoCao = 0
		end if
		rs.close
		set rs = nothing
	end function

	sub InsertFileBaoCao(strMaBaoCao, strFileName, strFileGoc)
		dim strSQL, com, con
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		strSQL="Insert into BCT_FileBAOCAO(MaBaoCao, TenFile, TenFileGoc) values(?,?,?)"
		set com=server.CreateObject("ADODB.Command")
		com.ActiveConnection=con
		com.CommandText= strSQL
		com.Parameters.Append com.CreateParameter(,adInteger,adParamInput,,strMaBaoCao)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,100,strFileName)
		com.Parameters.Append com.CreateParameter(,adVarWChar,adParamInput,100,strFileGoc)
		com.Execute 
		set com=nothing
		set con = nothing			
	end sub

	sub insertNoiNhan(strMabaoCao, strMaNoiNhan, strType)
		dim strSQL, com, con
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		strSQL="Insert into BCT_NoiNhan(MaBaoCao, MaNoiNhan, PhanLoaiNoiNhan) values(?,?,?)"
		set com=server.CreateObject("ADODB.Command")
		com.ActiveConnection=con
		com.CommandText= strSQL
		com.Parameters.Append com.CreateParameter(,adInteger,adParamInput,,strMaBaoCao)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,20,strMaNoiNhan)
		com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,1,strType)
		com.Execute 
		set com=nothing
		set con = nothing				
	end sub

	sub InsertBaoCao(strUser, strTieuDe, strNoiDung, strLoaiBaoCao, strTuNgay, strDenNgay, strTreHan)
		dim strSQL, com, con, strSub1, strSub2, strSub3, strSub4
		set con = server.createObject("ADODB.connection")
		con.open CONNECTION_STRING

		set com=server.CreateObject("ADODB.Command")
		com.ActiveConnection=con

		strSQL="Insert into BCT_BAOCAO(MaLoaiBaoCao, UserID, NgayBaoCao, TieuDe, NoiDung, TinhTrang, TreHan"

		com.Parameters.Append com.CreateParameter(,adChar,adParamInput,3,strLoaiBaoCao)
		com.Parameters.Append com.CreateParameter(,adChar,adParamInput,20,strUser)
		com.Parameters.Append com.CreateParameter(,adVarWChar,adParamInput,1000,strTieuDe)
		com.Parameters.Append com.CreateParameter(,adVarWChar,adParamInput,4000,strNoiDung)
		com.Parameters.Append com.CreateParameter(,adChar,adParamInput,1, strTreHan)		

		if strTuNgay<>"" then
			strSub1 = ", TuNgay"
			strSub2 = ",convert(datetime,?,103)"
			com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strTuNgay)
		end if		
		if strDenNgay<>"" then
			strSub3 = ", DenNgay"
			strSub4 = ",convert(datetime,?,103)"
			com.Parameters.Append com.CreateParameter(,adVarChar,adParamInput,10,strDenNgay)
		end if		
		
		strSQL = strSQL & strSub1 & strSub3 & ") values(?,?,getdate(),?,?,'G',convert(bit,?)" & strSub2 & strSub4 & ")"
		com.CommandText= strSQL
		com.Execute 
		set com=nothing
		set con = nothing
	end sub

	dim strLoaiBaoCao, strTieuDe, strNoiDung, strTemp, strUser, strTuNgay, strDenNgay
	dim strFileName, strOrgFileName, strNguoiGui, strNoiGui, strTreHan, strDepIDInoiGui
	dim arrCaNhan, arrDonVi
	dim arrFilename, arrOriginalFileName
	dim strError

	
	strDepIDInoiGui = Session("DeptID")
	strUser = session("UserID")
	set rs = getInfobyUser(strUser)
	if not rs.eof then
		strNguoiGui = rs("FullName")
		strNoiGui = rs("TenBoPhan")
	end if
	rs.close
	set rs = nothing
	
	if request.form("btnGui")<>"" then
		strError = false	'	-------------- gan bao loi bang false
		strLoaiBaoCAo = request.form("cboLoaiBaoCao")
		strTieuDe = request.form("txtTieuDe")

		strNoiDung = request.form("txtNoiDung")	
		strTuNgay = request.form("txtTuNgay")
		strDenNgay = request.form("txtDenNgay")
		
		strFilename =	Request("hFileName")
		strOriginalFileName = replace(request("hOriginalFileName"),"'","''")
		arrFilename = split(strFilename, "@@")
		arrOriginalFileName = split(strOriginalFileName,"@@")

		strTreHan = "0"
		
		dim curDate, frDate, toDate
		dim arrMaBaoCao(20), icount, j
		
		curDate = date()
		toDate =DateValue(mid(strDenNgay,4,2) & "/" & left(strDenNgay,2) & "/" & right(strDenNgay,4))
		frDate = DateValue(mid(strTuNgay,4,2) & "/" & left(strTuNgay,2) & "/" & right(strTuNgay,4))

		if UCASE(session("UserName"))="UTNT" OR UCASE(session("UserName"))="DINHPV" then
			strTreHan = "0"
		else
			if curDate > ValidDate(strLoaiBaoCao, frDate, todate) then
				strtrehan = "1"
			end if	
		end if

		'--------------insert noi nhan 
		arrCaNhan = split(request.form("cboCaNhan"),", ")
		arrDonVi = split(request.form("cboDonVi"),", ")
		
		iCount = 0
		
		for i = 0 to ubound(arrCaNhan)
			if checkDuplicate(strLoaiBaoCao, strTuNgay, strDenNgay, strUser, arrcaNhan(i)) = false then
				call InsertBaoCao(strUser, strTieuDe, strNoiDung, strLoaiBaoCao, strTuNgay, strDenNgay, strTreHan)
				arrMaBaoCao(iCount) = getMaBaoCao(strUser)
				call insertNoiNhan(arrMaBaoCao(iCount), arrcaNhan(i), "C") 
				iCount = iCount + 1
			else
		' thong bao khong cap nhat duoc vi trung record
			strError	= true
			end if	
		next

		for i = 0 to ubound(arrDonVi)
			if checkDuplicate(strLoaiBaoCao, strTuNgay, strDenNgay, strUser, arrDonVi(i)) = false then
				call InsertBaoCao(strUser, strTieuDe, strNoiDung, strLoaiBaoCao, strTuNgay, strDenNgay, strTreHan)
				arrMaBaoCao(iCount) = getMaBaoCao(strUser)
				call insertNoiNhan(arrMaBaoCao(iCount), arrDonVi(i), "P") 
				iCount = iCount + 1
			else
		' thong bao khong cap nhat duoc vi trung record
			strError	= true		
			end if	
		next
		
		'-------- chep file upload
		if strError	= false then
			sServerPath = Server.Mappath(".") & "\"
			sUploadFolder = sServerPath & UPLOADPATH
			sTempFolder = sServerPath & "Temp" & "\"
			set fs = server.CreateObject("scripting.FileSystemObject")		
			for i = 0 to ubound(arrFilename)
				IF trim(arrFileName(i)) <> "" then 
					IF fs.FileExists(sTempFolder & arrFilename(i)) then													
						fs.CopyFile sTempFolder & arrFilename(i) , sUploadFolder & arrFilename(i)
						fs.DeleteFile sTempFolder & arrFilename(i) 
					else
						arrFilename(i) = ""
						arrOriginalFileName(i) = ""
					end if
					for j=0 to iCount-1
						call InsertFileBaoCao(arrMaBaoCao(j), arrFileName(i), arrOriginalFileName(i))	
					next
				END IF
			next			
			response.redirect "BCT_List.asp"
			response.end
		end if	
	end if
%>
<!--#include file="inc/header.asp"-->
<body onload="<%if strError = true then%>alert('Chuong trinh khong the cap nhat vi ban da gui bao cao voi cung thoi gian nhu tren vao he thong roi. \n Ban hay vao lai menu DANH SACH BAO CAO, chon va xoa bao cao da gui. Sau do gui lai bao cao nay!')<%end if%>">
<center>
<form method="POST" action="BCT_New.asp" name="frmMain">
<SCRIPT LANGUAGE="JavaScript" SRC="script/AnchorPosition.js"></SCRIPT>
<SCRIPT LANGUAGE="JavaScript" SRC="script/PopupWindow.js"></SCRIPT>
<SCRIPT LANGUAGE="JavaScript" SRC="script/CalendarPopup.js"></SCRIPT> 
<SCRIPT LANGUAGE="JavaScript" SRC="script/date.js"></SCRIPT>
<SCRIPT LANGUAGE="JavaScript" SRC="script/lib.js"></SCRIPT>
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
		FileWindow = window.open('BCT_AttachFiles.asp?AttachedFile='+frmMain.hOriginalFileName.value+'&FileName='+frmMain.hFileName.value,'Recipient','toolbar=0,scrollbars=1, alwaysRaised=Yes, width=600, height=350,1 ,align=center');
		FileWindow.focus();
	}	
	
	function Check(){
		var sTuNGay, sDenNgay, sTieuDe, sNoiDung
		sTuNgay = frmMain.txtTuNgay.value;
		sDenNgay = frmMain.txtDenNgay.value;
		sTieuDe = frmMain.txtTieuDe.value;
		sNoiDung = frmMain.txtNoiDung.value;
		if (isBlank(sTuNgay) || isBlank(sDenNgay)) {
			alert ('Vui long nhap thoi gian bao cao');
			return;
		}
		
		if (!isDate(sTuNgay,'dd/MM/yyyy') || !isDate(sDenNgay,'dd/MM/yyyy')) {
			alert ('Vui long nhap thoi gian bao cao theo dang \'dd/mm/yyyy\'');
			return;
		}
		
		if (compareDates(sTuNgay,'dd/MM/yyyy',sDenNgay,'dd/MM/yyyy') !=0) {
			alert ('Vui long nhap tu ngay bao cao nho? hon den ngay bao cao');
			return;
		}

		if (isBlank(sTieuDe)){
			alert('Vui long nhap tieu de');
			frmMain.txtTieuDe.focus();
			return false;
		}

		if (isBlank(sNoiDung)){
			alert('Vui long nhap noi dung');
			frmMain.txtNoiDung.focus();
			return false;
		}

		if (frmMain.cboLoaiBaoCao.value ==''){
			alert('Vui long chon loai bao cao');
			frmMain.txtNoiDung.focus();
			return false;
		}

		if (frmMain.cboCaNhan.value =='' && frmMain.cboDonVi.value==''){
			alert('Vui long chon noi gui');
			frmMain.txtNoiDung.focus();
			return false;
		}
		
		/*if (isBlank(lblFileName.innerText)) {
			alert('Vui long chon file goi kem');
			return false;
		}*/
		
		frmMain.submit();
	}
	
		
	function Chuyenngay(trehan){
		var sel = frmMain.cboLoaiBaoCao.value;
		var t = new Date();
		trehan -=1;
		switch(sel){
			case 'BCT':
				var fstWeek = new Date(), lstWeek;
				if (t.getDay() > trehan)	//	lon hon ngay thu 5
					fstWeek.setDate(t.getDate()-(t.getDay() - trehan))
				else
					fstWeek.setDate(t.getDate()-(7+ t.getDay() - trehan))
				lstWeek = new Date(fstWeek);
				lstWeek.setDate(fstWeek.getDate()+7);
				frmMain.txtTuNgay.value=formatDate(fstWeek,'dd/MM/yyyy');
				frmMain.txtDenNgay.value=formatDate(lstWeek,'dd/MM/yyyy');
				break;
			case 'BCN':
				frmMain.txtTuNgay.value = "<%=TREHANNAM%>/12/" + parseInt(t.getYear()-1);
				frmMain.txtDenNgay.value="<%=TREHANNAM%>/12/"+t.getYear();
				break;			
			case 'BCQ':
				switch(t.getMonth()+1){
					case 1:
					case 2:
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/12/"+ parseInt(t.getYear()-1);
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/03/"+ t.getYear();
						break;						
					case 3:
						if (t.getDate() ><%=TREHANQUY%>){
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/03/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/06/"+ t.getYear();
						}	
						else{
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/12/"+ parseInt(t.getYear()-1);
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/03/"+ t.getYear();
						}	
						break;					
					case 4:
					case 5:
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/03/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/06/"+ t.getYear();
						break;
					case 6:
						if (t.getDate() ><%=TREHANQUY%>){
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/06/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/09/"+ t.getYear();
						}	
						else{
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/03/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/06/"+ t.getYear();
						}	
						break;					
					case 7:
					case 8:
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/06/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/09/"+ t.getYear();
						break;					
					case 9:
						if (t.getDate() ><%=TREHANQUY%>){
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/09/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/12/"+ t.getYear();
						}	
						else{
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/06/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/09/"+ t.getYear();
						}	
						break;										
					case 10:
					case 11:
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/09/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/12/"+ t.getYear();
						break;					
					case 12:
						if (t.getDate() ><%=TREHANQUY%>){
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/12/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/03/"+ parseInt(t.getYear()+1);
						}	
						else{
							frmMain.txtTuNgay.value="<%=TREHANQUY%>/09/"+ t.getYear();
							frmMain.txtDenNgay.value="<%=TREHANQUY%>/12/"+ t.getYear();
						}	
						break;
				}
				break;
			case 'BCH':		// mac dinh la thang truoc do
				if (t.getDate() ><%=TREHANTHANG%>){			
					if (parseInt(t.getMonth()+1)<10) 
						frmMain.txtTuNgay.value="<%=TREHANTHANG%>/0"+parseInt(t.getMonth()+1)+"/"+ t.getYear();							
					else 
						frmMain.txtTuNgay.value="<%=TREHANTHANG%>/"+parseInt(t.getMonth()+1)+"/"+ t.getYear();

					if (parseInt(t.getMonth()+2)<10) 
						frmMain.txtDenNgay.value= "<%=TREHANTHANG%>/0" + parseInt(t.getMonth()+2)+"/" + t.getYear();
					else{					
						if (parseInt(t.getMonth()+2)>=12) 
							frmMain.txtDenNgay.value= "<%=TREHANTHANG%>/01/" + parseInt(t.getYear()+1);
						else	
							frmMain.txtDenNgay.value= "<%=TREHANTHANG%>/" + parseInt(t.getMonth()+2)+"/" + t.getYear();
					}
				}
				else{
					if (t.getMonth()<10) {
						if (t.getMonth() == 0)
							frmMain.txtTuNgay.value="<%=TREHANTHANG%>/12/"+ parseInt(t.getYear() -1);
						else
							frmMain.txtTuNgay.value="<%=TREHANTHANG%>/0"+t.getMonth()+"/"+ t.getYear();
					}
					else
						frmMain.txtTuNgay.value="<%=TREHANTHANG%>/"+t.getMonth()+"/"+ t.getYear();

					if (parseInt(t.getMonth()+1)<10) 
						frmMain.txtDenNgay.value= "<%=TREHANTHANG%>/0" + parseInt(t.getMonth()+1)+"/" + t.getYear();
					else
						frmMain.txtDenNgay.value= "<%=TREHANTHANG%>/" + parseInt(t.getMonth()+1)+"/" + t.getYear();
				}		
				
		}		
	}
	
	function CapNhatNgay(){
		var sel = frmMain.cboLoaiBaoCao.value;
		var frDate = frmMain.txtTuNgay.value;
		if (!isDate(frDate,'dd/MM/yyyy')) {
			alert ('Vui long nhap thoi gian bao cao theo dang \'dd/mm/yyyy\'');
			return;	
		}
		var sDate, t
		sDate = getDateFromFormat(frDate,'dd/MM/yyyy');
		t = new Date(sDate)	;
		switch(sel){
			case 'BCT': 
				t.setDate(t.getDate()+7)	// cong len 7 ngay			
				frmMain.txtDenNgay.value=formatDate(t, 'dd/MM/yyyy');
				break;				
/*				
			case 'BCN':
				frmMain.txtTuNgay.value = "01/01/" + t.getYear();
				frmMain.txtDenNgay.value="31/12/"+t.getYear();			
				break;	
			case 'BCQ':
				switch(t.getMonth()+1){
					case 1:
					case 2:
						frmMain.txtTuNgay.value="01/10/"+ t.getYear() -1;
						frmMain.txtDenNgay.value="31/12/"+t.getYear() -1;
						break;					
					case 3:
					case 4:
					case 5:
						frmMain.txtTuNgay.value="01/01/"+ t.getYear();
						frmMain.txtDenNgay.value="31/03/"+t.getYear();
						break;					
					case 6:
					case 7:
					case 8:
						frmMain.txtTuNgay.value="01/04/"+ t.getYear();
						frmMain.txtDenNgay.value="30/06/"+t.getYear();
						break;
					case 9:
					case 10:
					case 11:
						frmMain.txtTuNgay.value="01/07/"+ t.getYear();
						frmMain.txtDenNgay.value="30/09/"+t.getYear();
						break;						
					case 12:
						frmMain.txtTuNgay.value="01/10/"+ t.getYear();
						frmMain.txtDenNgay.value="31/12/"+t.getYear();
						break;						
				}
				break;	
			default:
				if (parseInt(t.getMonth()+1)<10) frmMain.txtTuNgay.value="01/0"+parseInt(t.getMonth()+1)+"/"+ t.getYear();
				else frmMain.txtTuNgay.value="01/"+parseInt(t.getMonth()+1)+"/"+ t.getYear();
				var endDate = "01/"
				if (parseInt(t.getMonth()+2)<10) endDate += "0" + parseInt(t.getMonth()+2)+"/"
				else endDate += parseInt(t.getMonth()+2)+"/"
				endDate += t.getYear();
				endDate = getDateFromFormat(endDate,'dd/MM/yyyy');
				t = new Date(endDate)
				t.setDate(t.getDate()-1)
				frmMain.txtDenNgay.value=formatDate(t,'dd/MM/yyyy');
*/				
		}	
	}
              </SCRIPT>

<table border="0" cellpadding="0" cellspacing="0" width = "780" bgcolor=Snow style="border-collapse: collapse" bordercolor="#111111">
    <tr> 
		<td height="56" align="center"><img src="images/Text_SBaoCao.jpg" border="0"></td>
    </tr> 
    <tr> 
		<td height="56" align="center">  
  <table width="90%" cellpadding="3" cellspacing="0" bgcolor=#FDF1CA border=1 bordercolor = "#428C31" style="border-collapse: collapse">
    <tr>
      <td width="30%"  height="29" bgcolor="#f5f5dc" align="right">
        Người gửi:&nbsp;&nbsp; </td>
      <td width="70%" height="29" bgcolor="#f5f5dc" colspan="2">&nbsp;<b><%=strNguoiGui%>-<%=strNoiGui%></b></td>
    </tr>
    <tr>
      <td width="30%"  height="29" bgcolor="#f5f5dc">
        <p align="right">Nơi nhận:&nbsp;</td>
      <td width="24%" height="29" bgcolor="#f5f5dc"><font color = 003366>Cá nhân<br>
      <select size="5" name="cboCaNhan" multiple style="font-family: Arial; font-size: 10pt">
      	<option value="">Không chọn</option>      
      <%
      	set rs = getCanhan()
      	do while not rs.eof
      %>
      	<option value="<%=rs("UserID")%>"><%=rs("UserName")%>-<%=rs("FullName")%></option>
      <%
      		rs.movenext()
      	loop
      	rs.close
      %>
      </select></font></td>
      <td width="46%" height="29" bgcolor="#f5f5dc"><font color="#003366">Đơn vị</font><br>
      <select size="5" name="cboDonVi" multiple style="font-family: Arial; font-size: 10pt">
      	<option value="">Không chọn</option>      
      <%      
      	set rs = getBoPhanAll()
      	do while not rs.eof
      %>
      	<option value="<%=rs("MaBoPhan")%>"><%=rs("TenBoPhan")%></option>
      <%
      		rs.movenext()
      	loop
      	rs.close
      %>
      </select></td>
    </tr>
    <tr>
      <td align="right" height="29" width="30%" bgcolor="#f5f5dc">Loại báo cáo<font color="black">:</font><font color="#FF0000">*&nbsp;</font></td>
      <td height="29" width="70%" bgcolor="#f5f5dc" colspan="2">
              <select size="1" name="cboLoaiBaoCao" style="font-family: Arial; font-size: 12px" onchange="Chuyenngay(<%=TREHANTUAN%>)">
      	<option value="">Chọn loại báo cáo</option>
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
      <td align="right" height="29" width="30%" bgcolor="#f5f5dc">
      Thời gian:<font color="#FF0000"> * </font></td>
      <td height="29" width="70%" bgcolor="#f5f5dc" colspan="2">Từ ngày&nbsp; <INPUT NAME="txtTuNgay" TYPE="text" VALUE="<%=strTuNgay%>" SIZE=11 onBlur="CapNhatNgay()">
                  <A HREF="#" onClick="cal1.select(document.frmMain.txtTuNgay,'anchor1','dd/MM/yyyy'); return false;" NAME="anchor1" ID="anchor1">
      <img src="images/cal.gif" width="16" height="16" border="0" title="click here to update the timestamp"></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      đến ngày&nbsp; <INPUT NAME="txtDenNgay" TYPE="text" VALUE="<%=strDenNGay%>" SIZE=11> 
                  <A HREF="#" onClick="cal2.select(document.frmMain.txtDenNgay,'anchor2','dd/MM/yyyy'); return false;" NAME="anchor2" ID="anchor2">
      <img src="images/cal.gif" width="16" height="16" border="0" title="click here to update the timestamp"></A>
                </td>
    </tr>
    <tr>
      <td align="right" height="29" width="30%" bgcolor="#f5f5dc">
      <font color="black">Tiêu đề:</font><font color="#FF0000">*&nbsp;</font></td>
      <td height="29" width="70%" bgcolor="#f5f5dc" colspan="2"><input type="text" name="txtTieuDe" size="74" value="<%=strTieuDe%>" style="font-family: Arial" maxlength="200"></td>
    </tr>
    <tr>
      <td align="right" valign="top" width="30%" bgcolor="#f5f5dc">
      <font color="black">Nội dung:</font><font color="#FF0000">*&nbsp;</font></td>
      <td width="70%" bgcolor="#f5f5dc" colspan="2"><textarea rows="8" name="txtNoiDung" cols="75" style="font-family: Arial"><%=strNoiDung%></textarea></td>
    </tr>
    <tr>
      <td align="right" valign="top" width="30%" bgcolor="#f5f5dc">
      <a href="javascript:openWindow();">File đính kèm<a href="javascript:clearFile();"> </a>&nbsp;</td>
      <td width="70%" bgcolor="#f5f5dc" colspan="2"> <label ID="lblFileName"><%=strOriginalFileName%></label></b></font>                                     
                  <input name="hFileName" value="<%=strFileName%>" type="hidden">
                  <input name="hOriginalFileName" value="<%=strOriginalFileName%>" type="hidden">
&nbsp;</td>
    </tr>
    <tr align="center">
      <td width="100%" colspan="3" height="34" bgcolor="#f5f5dc">&nbsp;
			<input type="image" src = "images/button_gui.jpg" border = 0 alt = "Luu bao cao va tro ve trang danh sach bao cao" name="btnLuu" onclick="Check(); return false;"> </td>
    </tr>
 
  </table>  
        </td>
    </tr> 
</table>
</center>
<input type="hidden" name="btnGui" value="yes">
</form>
<DIV ID="testdiv1" STYLE="position:absolute;visibility:hidden;background-color:white;layer-background-color:white;"></DIV>