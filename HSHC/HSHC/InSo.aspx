<%@ Page Language="vb" AutoEventWireup="false" Codebehind="InSo.aspx.vb" Inherits="HSHC.InSo" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=10.0.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>InSo</title>
		<META content="text/html; charset=UTF-8" http-equiv="Content-Type">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<script language=javascript src='<%= Request.ApplicationPath + "/Inc/jquery-1.7.1.min.js"%>'></script>
		<script language=javascript src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
		<script language=javascript src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
		<script language=javascript src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
		<script language=javascript src='<%= Request.ApplicationPath + "/Inc/dhtmlxcalendar.js"%>'></script>
		<link rel=stylesheet type=text/css href='<%= Request.ApplicationPath + "/Portals/_default/Skins/LIGHTBLUESKIN/LightBlueSkin.css" %>'>
		</link>
		<link rel=stylesheet type=text/css href='<%= Request.ApplicationPath + "/Portals/_default/Skins/LIGHTBLUESKIN/dhtmlxcalendar.css" %>'>
		</link>
		<script type="text/javascript" language="javascript">
			var myCalendar;
			function doOnLoad() {
				document.write("sdfsdfjskldf");		
				myCalendar = new dhtmlXCalendarObject(["date_from", "date_to"]);
				//myCalendar.setDate("2013-03-10");
				myCalendar.hideTime();
				// init values
				var t = new Date();
				byId("date_from").value = 1 + "/" + (t.getMonth() + 1) + "/" + (t.getYear() + 1900); ;
				byId("date_to").value = t.getUTCDate() + "/" + (t.getMonth() + 1) + "/" + (t.getYear() + 1900); ;
			}

			function setSens(id, k) {
				// update range
				if (k == "min") {
					myCalendar.setSensitiveRange(byId(id).value, null);
				} else {
					myCalendar.setSensitiveRange(null, byId(id).value);
				}
			}
			function byId(id) {
				return document.getElementById(id);				
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tblHeader" class="QH_LoaiHS" width="100%" align="center" runat="server">
				<TR vAlign="middle">
					<TD height="50" vAlign="middle" width="20%" align="right"><STRONG>Loại hồ sơ tiếp nhận</STRONG></TD>
					<TD vAlign="middle" width="80%" align="left">
						<asp:dropdownlist id="ddlLoaiHS" runat="server" AutoPostBack="True" CssClass="QH_DropDownList" Width="95%"></asp:dropdownlist>
					</TD>
				</TR>
				<tr>
					<td colspan="3">
						<table width="600" align="center">
							<tr>
								<TD class="QH_ColLabel" height="11">Từ ngày</TD>
								<TD class="QH_ColControl">
									<asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
									&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></TD>
								<TD class="QH_ColLabel" height="11">Đến ngày</TD>
								<TD Width="35%" class="QH_ColControl" height="11"><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="70px"></asp:TextBox>
									&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></TD>
							</tr>
							<tr>
								<td colspan="4" align="center">
									<asp:button id="btnThucHien" runat="server" CssClass="QH_Button" Text="Thực Hiện"></asp:button>
									<asp:button id="btnXuatExcel" runat="server" Text="Xuất Excel" CssClass="QH_Button"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!--
			<P align="center">
			<asp:datagrid id="data" runat="server" CssClass="QH_DataGrid" Width="100%" AutoGenerateColumns="False"
					CellPadding="3">
					<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="STT" HeaderText="STT"></asp:BoundColumn>
						<asp:BoundColumn DataField="HoSoTiepNhanID" HeaderText="SỐ BI&#202;N NHẬN"></asp:BoundColumn>
						<asp:BoundColumn DataField="HoTenNguoiNop" HeaderText="HỌ T&#202;N NGƯỜI NỘP"></asp:BoundColumn>
						<asp:BoundColumn DataField="NoiDungKhac" HeaderText="NỘI DUNG"></asp:BoundColumn>
						<asp:BoundColumn DataField="NgayNhan" HeaderText="NG&#192;Y NHẬN"></asp:BoundColumn>
						<asp:BoundColumn DataField="KyTenNop" HeaderText="K&#221; T&#202;N NỘP"></asp:BoundColumn>
						<asp:BoundColumn DataField="NgayThucTra" HeaderText="NG&#192;Y TRẢ"></asp:BoundColumn>
						<asp:BoundColumn DataField="KyTenNhan" HeaderText="K&#221; NHẬN"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
				</P>
				-->
			<asp:Label id="txtKQ" runat="server">Label</asp:Label>
		</form>
	</body>
</HTML>
