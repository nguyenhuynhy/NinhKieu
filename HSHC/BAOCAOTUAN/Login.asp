<!-- #include file = "INC/Lib.asp" -->
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="stylesheet" type="text/css" href="INC/SSV.css">
<%
	Session.CodePage = 65001  		
	Session("UserID") = ""
%>
<title>Home page</title>
<script language = "javascript">
	var frm;
	function startUp(){
		frm = document.frmlogin1;
		frm.txtUsername.value = '';
		frm.txtPassword.value = '';
		frm.hAction.value = '<%=strAction%>';
		frm.txtUsername.focus();
	}
	function keyDown(){
		sAppName = navigator.appName;
		if(sAppName == 'Microsoft Internet Explorer'){
			var nKey = event.keyCode;
			if (nKey == '13') checkLogin()
		}	
		
	}
	
	
	function checkLogin(){	
		
		if (frm.txtUsername.value == ''){
			alert('Ten Truy cap khong duoc bo trong');
			frm.txtUsername.focus();
		}else{
			if (frm.txtPassword.value == ''){
				alert('Mat khau khong the bo trong');
				frm.txtPassword.focus();
			}else{
				frm.action = 'BCT_CheckLogin.asp';
				frm.submit();
			}	
		}	
	}	
	
	function retHome(){
		location.href = 'Home.asp';
	}
</script>	
</head>
<body bgcolor="000000" topmargin="0" leftmargin="0" onload="javascript:startUp();"  background=Images/550.gif>
<center>
<table width="100%" border="0" cellspacing="0" cellpadding="0" height = 100%>
  <tr>
    <td align="center" valign="middle"> 
      
      <table width="450" border="0" cellspacing="0" cellpadding="0" align="center" bgcolor="#0066CC">
        <tr> 
          <td>&nbsp;</td>
        </tr>
        <tr> 
          <td align="center" valign="middle"> 
            <form name="frmlogin1" method="post">
			  <input type = hidden name = hAction value = "ADMIN">
			  <table width="400" border="0" cellspacing="0" cellpadding="5" align="center" bgcolor="#FFFFFF">
                <tr align="center"> 
                  <td colspan="2"><font face="Verdana"><b>
                  <img src="images/login.gif"></b></font></td>
                </tr>
<%if request("txtError")<>"" then%>
                <tr> 
                  <td align="center" bgcolor="#E4E4E4" colspan="2">&nbsp;<font color="red"><b><%=request("txtError")%></b></font></td> 
                </tr>
<%end if%>                
                <tr> 
                  <td align="right" width="105" bgcolor="#E4E4E4"><font face="arial" size="2">Tên truy cập</font></td> 
                  <td width="208" bgcolor="#E4E4E4"> 
                    <input type="text" name="txtUsername" maxlength="20" size="20" style="border: 1 solid #FF0000" value="<%=Request("txtTenSD")%>">
                  </td>
                </tr>
                <tr> 
                  <td align="right" width="105" bgcolor="#E4E4E4"><font face="arial" size="2">Mật khẩu</font></td>
                  <td width="208" bgcolor="#E4E4E4"> 
                    <input type="password" name="txtPassword" size="12" maxlength="20" style="border: 1 solid #FF0000" onkeydown = "javascript:keyDown()">
                  </td>
                </tr>
                <tr align="center"> 
                  <td colspan="2"> 
                    <input type="button" style = "font-family:Arial" name="btnSubmit" value="Truy cập" style="background-color: #FFCC00; color: #000000; border: 1 outset #000080;width:100" onclick = "javascript:checkLogin();">
                    <input type="button" style = "font-family:Arial" name="btnCancel1" value="Trở về" style="background-color: #FFCC00; color: #000000; border: 1 outset #000080;width:100" onclick="javascript:history.back();">
					</td>
                </tr>
              </table>
              <input type="hidden" name="Params" value="<%=Request("Params")%>">
            </form>
          </td>
        </tr>
        <tr> 
          <td>&nbsp;</td>
        </tr>
      </table>
      
    </td>
  </tr>
</table>
</center>
</body>
</html>