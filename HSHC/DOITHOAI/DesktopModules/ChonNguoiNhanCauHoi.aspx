<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChonNguoiNhanCauHoi.aspx.vb" Inherits="DOITHOAI.ChonNguoiNhanCauHoi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Chọn người nhận câu hỏi</title>
		<link 
href='<%= Request.ApplicationPath + "/Portals/_default/Skins/BLUESKIN/Blueskin.css" %>' 
type=text/css rel=stylesheet>
			<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
			<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
			<meta name="vs_defaultClientScript" content="JavaScript">
			<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
			<script language=javascript 
		src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
			<script language="javascript">
				function form1_onsubmit(objTenDangNhap)
				{
					
					var objset,objget,i;
					for (i=0;i<window.opener.document.forms(0).length;i++)
					{
						if (window.opener.document.forms(0).item(i).id.indexOf('txtUserName') != -1)
						{		
							objset = window.opener.document.forms(0).item(i);	
							break;
						}
					}
										
						objset.value=objTenDangNhap.innerText;
					
						window.close();
						window.opener.document.forms(0).submit();						
				}
			</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="main" cellSpacing="0" cellPadding="0" width="90%" border="0" align="center">
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td><asp:label id="lblTitle" runat="server" Width="100%" CssClass="QH_Label_Title">Chọn người nhận câu hỏi</asp:label></td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td vAlign="top" align="center" width="70%">
						<table class="QH_LoaiHS" cellSpacing="0" cellPadding="0" width="70%" border="0">
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td class="QH_ColLabel2" vAlign="middle" width="15%">Nội dung tìm
								</td>
								<td vAlign="middle" width="25%"><asp:textbox id="txtNoiDung" runat="server" cssclass="QH_Textbox" Width="100%"></asp:textbox></td>
								<td class="QH_ColLabel2" vAlign="middle" width="10%">Tìm theo
								</td>
								<td vAlign="middle" width="25%"><asp:dropdownlist id="ddlHinhThucTim" runat="server" cssclass="QH_DropdownList" Width="100%">
										<asp:ListItem Value="0">Theo t&#234;n t&#224;i khoản</asp:ListItem>
										<asp:ListItem Value="1">Theo địa chỉ mail</asp:ListItem>
										<asp:ListItem Value="2">Theo t&#234;n đầy đủ</asp:ListItem>
									</asp:dropdownlist></td>
								<td vAlign="middle" width="20%"><asp:linkbutton id="lnkTim" runat="server" CssClass="QH_button">Tìm kiếm</asp:linkbutton></td>
							</tr>
							<tr>
								<td height="5"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><asp:datagrid id="grdABC" runat="server" AllowPaging="True" EnableViewState="false" AutoGenerateColumns="false"
							width="100%" CellPadding="1" border="0">
							<PagerStyle Position="Top" HorizontalAlign="Center"></PagerStyle>
							<Columns>
								<asp:TemplateColumn HeaderText=""></asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td><asp:datagrid id="grdUsers" runat="server" AllowPaging="True" EnableViewState="false" AutoGenerateColumns="false"
							width="100%" CellPadding="4" Border="0">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
							<Columns>
								<asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Chọn">
									<ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton ID="btnChon" Runat="server" ImageUrl="~/images/edit.gif"></asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Stt" HeaderStyle-HorizontalAlign="Right">
									<ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle>
									<ItemTemplate>
										<%# grdUsers.CurrentPageIndex*grdUsers.PageSize + grdUsers.Items.Count+1 %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="">
									<ItemStyle Width="2%"></ItemStyle>
									<ItemTemplate>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="Tên đầy đủ" DataField="FullName" HeaderStyle-HorizontalAlign="Left"
									ItemStyle-Width="40%" />
								<asp:TemplateColumn HeaderText="Tên đăng nhập" HeaderStyle-HorizontalAlign="left">
									<ItemStyle HorizontalAlign="Left" Width="23%"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblTenDangNhap" Runat="server" text='<%#DataBinder.Eval(Container.DataItem,"Name")%>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="Địa chỉ Email" DataField="Email" HeaderStyle-HorizontalAlign="Left"
									ItemStyle-Width="30%" />
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td align="center">
						<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_button">Trở về</asp:linkbutton></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
