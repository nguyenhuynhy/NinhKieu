<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" type="text/css" href="style/style.css">
<script language="JavaScript1.2" src="script/coolmenus4.js"></script>
<script language="JavaScript1.2" src="script/cm_addins.js"></script>
<!-- Navbar def -->
<script language="JavaScript" type="text/javascript">
<!-- Dummy comment to hide code from non-JavaScript browsers.

if (document.images) {
DanhSach_off = new Image(); DanhSach_off.src = "images/DanhSach.gif"
DanhSach_over = new Image(); DanhSach_over.src = "images/DanhSach_over.gif"
NhapMoi_off = new Image(); NhapMoi_off.src = "images/NhapMoi.gif"
NhapMoi_over = new Image(); NhapMoi_over.src = "images/NhapMoi_over.gif"
PhucHoi_off = new Image(); PhucHoi_off.src = "images/PhucHoi.gif"
PhucHoi_over = new Image(); PhucHoi_over.src = "images/PhucHoi_over.gif"
DanhSachChoDuyet_off = new Image(); DanhSachChoDuyet_off.src = "images/DanhSachChoDuyet.gif"
DanhSachChoDuyet_over = new Image(); DanhSachChoDuyet_over.src = "images/DanhSachChoDuyet_over.gif"
TimKiemTheoNoiDungFile_off = new Image(); TimKiemTheoNoiDungFile_off.src = "images/TimKiemTheoNoiDungFile.gif"
TimKiemTheoNoiDungFile_over = new Image(); TimKiemTheoNoiDungFile_over.src = "images/TimKiemTheoNoiDungFile_over.gif"
DanhSachDaDuyet_off = new Image(); DanhSachDaDuyet_off.src = "images/DanhSachDaDuyet.gif"
DanhSachDaDuyet_over = new Image(); DanhSachDaDuyet_over.src = "images/DanhSachDaDuyet_over.gif"
BaoBieu_off = new Image(); BaoBieu_off.src = "images/BaoBieu.gif"
BaoBieu_over = new Image(); BaoBieu_over.src = "images/BaoBieu_over.gif"
}

function turn_off(ImageName) {
	if (document.images != null) {
		document[ImageName].src = eval(ImageName + "_off.src");
	}
}

function turn_over(ImageName) {
	if (document.images != null) {
		document[ImageName].src = eval(ImageName + "_over.src");
	}
}

// End of dummy comment -->
</script>
<!-- Navbar def end -->
</head>
<%
If request.QueryString("Sp")="1" then'neu la trang bat dau
	If request.QueryString("UID")<>"" then
		Session("UserID") = request.QueryString("UID")
		Session("DeptID")=getBoPhanOfUser(Session("UserID"))
	else
		Session("UserID")= ""
	end if
else
	If request.QueryString("UID")<>"" then
		Session("UserID")=request.QueryString("UID")
		Session("DeptID")=getBoPhanOfUser(Session("UserID"))
	end if
end if
		
		
%>
<body topmargin="0" leftmargin="0">

<form name="frmHeader" method="post">
<input type="hidden" name="hAction" value="">
<tr height="25" valign="middle">
		<td width="100%">
			<table cellspacing="0" cellpadding="0" width ="100%">
				
				<tr>
					<td width="100%" colspan="6"></td>
				</tr>
				<tr>
					<td width="16%" class="QH_Label"><a href="BCT_List.asp" onmouseout="turn_off('DanhSach')" onmouseover="turn_over('DanhSach')"><img name="DanhSach" src="images/DanhSach.gif" alt="Danh sách" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="BCT_New.asp" onmouseout="turn_off('NhapMoi')" onmouseover="turn_over('NhapMoi')"><img name="NhapMoi" src="images/NhapMoi.gif" alt="Nhập mới" width="110" height="22" border="0"><b></a></td>					
					<td width="16%" class="QH_Label"><a href="BCT_DeleteList.asp" onmouseout="turn_off('PhucHoi')" onmouseover="turn_over('PhucHoi')"><img name="PhucHoi" src="images/PhucHoi.gif" alt="Phục hồi" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="BCT_choduyet.asp" onmouseout="turn_off('DanhSachChoDuyet')" onmouseover="turn_over('DanhSachChoDuyet')"><img name="DanhSachChoDuyet" src="images/DanhSachChoDuyet.gif" alt="Danh sách chờ duyệt" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="BCT_AdvanceSearch.asp" onmouseout="turn_off('TimKiemTheoNoiDungFile')" onmouseover="turn_over('TimKiemTheoNoiDungFile')"><img name="TimKiemTheoNoiDungFile" src="images/TimKiemTheoNoiDungFile.gif" alt="Tìm kiếm theo nội dung file" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="BCT_DaDuyet.asp" onmouseout="turn_off('DanhSachDaDuyet')" onmouseover="turn_over('DanhSachDaDuyet')"><img name="DanhSachDaDuyet" src="images/DanhSachDaDuyet.gif" alt="Danh sách đã duyệt" width="110" height="22" border="0"><b></a></td>
					<td width="16%" class="QH_Label"><a href="BCT_ThongKeTongHop.asp" onmouseout="turn_off('BaoBieu'	)" onmouseover="turn_over('BaoBieu')"><img name="BaoBieu" src="images/BaoBieu.gif" alt="Báo biểu" width="110" height="22" border="0"><b></a></td>
				</tr>
			</table>			
		</td>		
	</tr>
</form>