<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DanhSachHoSoShowLCD.aspx.vb" Inherits="HSHC.DanhSachHoSoShowLCD"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Danh sach ho so hien thi ra man hinh LCD</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="3" cellspacing="1">
				<tr>
					<td>
						<table width="100%" height="100%" cellpadding="3" cellspacing="1" border="1">
							<tr bgcolor="#eeeeee" style="FONT-FAMILY:Time New Romans; HEIGHT:20px; FONT-SIZE:20px; FONT-WEIGHT:bold">
								<td>DANH SÁCH HỒ SƠ ĐÃ GIẢI QUYẾT XONG, MỜI QUÝ KHÁCH ĐẾN NHẬN LẠI HỒ SƠ</td>
							</tr>
							<tr>
								<td valign="top">
									<table cellspacing="1" cellpadding="3" Border="1" bordercolordark="#ffffff" bordercolorlight="#787878"
										style="WIDTH:100%">
										<tr>
											<td align="center" height="20">Số biên nhận</td>
											<td width="30%" align="center" bgcolor="#99cccc">Họ tên</td>
											<td width="20%" align="center" bgcolor="#99cccc">Ngày nhận hồ sơ</td>
											<td width="20%" align="center" bgcolor="#99cccc">Ngày hẹn trả hồ sơ</td>
										</tr>
									</table>
									<marquee height="150" direction="up" scrollamount="1">
										<asp:DataList Runat="server" ID="dtlDSHoSoTraKetQua" Width="100%" CellPadding="3" CellSpacing="1"
											Border="1" bordercolordark="#FFFFFF" bordercolorlight="#787878">
											<ItemStyle Height="20px" Font-Bold="True" ForeColor="#0000ff"></ItemStyle>
											<AlternatingItemStyle BackColor="#33ccff"></AlternatingItemStyle>
											<ItemTemplate>
												<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %></td>
								<td width="30%"><%# DataBinder.Eval(Container, "DataItem.HoTen") %></td>
								<td width="20%"><%# DataBinder.Eval(Container, "DataItem.NgayNhan") %></td>
								<td width="20%"><%# DataBinder.Eval(Container, "DataItem.NgayHenTra") %>
									</ItemTemplate> </asp:DataList></MARQUEE>
								</td>
							</tr>
							<tr bgcolor="#eeeeee" style="FONT-FAMILY:Time New Romans; HEIGHT:20px; FONT-SIZE:20px; FONT-WEIGHT:bold">
								<td>DANH SÁCH HỒ SƠ KHÔNG ĐƯỢC GIẢI QUYẾT, MỜI QUÝ KHÁCH ĐẾN NHẬN LẠI HỒ SƠ</td>
							</tr>
							<tr>
								<td valign="top">
									<table cellspacing="1" cellpadding="3" Border="1" bordercolordark="#ffffff" bordercolorlight="#787878"
										style="WIDTH:100%">
										<tr>
											<td align="center" height="20">Số biên nhận</td>
											<td width="30%" align="center" bgcolor="#99cccc">Họ tên</td>
											<td width="20%" align="center" bgcolor="#99cccc">Ngày nhận hồ sơ</td>
											<td width="20%" align="center" bgcolor="#99cccc">Ngày hẹn trả hồ sơ</td>
										</tr>
									</table>
									<marquee height="100" direction="up" scrollamount="1">
										<asp:DataList Runat="server" ID="dtlDSHoSoKhongGiaiQuyet" Width="100%" CellPadding="3" CellSpacing="1"
											Border="1" bordercolordark="#FFFFFF" bordercolorlight="#787878">
											<ItemStyle Height="20px" Font-Bold="True" ForeColor="#0000ff"></ItemStyle>
											<ItemTemplate>
												<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %></td>
								<td width="30%"><%# DataBinder.Eval(Container, "DataItem.HoTen") %></td>
								<td width="20%"><%# DataBinder.Eval(Container, "DataItem.NgayNhan") %></td>
								<td width="20%"><%# DataBinder.Eval(Container, "DataItem.NgayHenTra") %>
									</ItemTemplate> </asp:DataList></MARQUEE>
								</td>
							</tr>
							<tr bgcolor="#eeeeee" style="FONT-FAMILY:Time New Romans; HEIGHT:20px; FONT-SIZE:20px; FONT-WEIGHT:bold">
								<td>DANH SÁCH HỒ SƠ ĐANG CHỜ BỔ SUNG, MỜI QUÝ KHÁCH ĐẾN BỔ SUNG HỒ SƠ</td>
							</tr>
							<tr>
								<td valign="top">
									<table cellspacing="1" cellpadding="3" Border="1" bordercolordark="#ffffff" bordercolorlight="#787878"
										style="WIDTH:100%">
										<tr>
											<td align="center" height="20">Số biên nhận</td>
											<td width="30%" align="center" bgcolor="#99cccc">Họ tên</td>
											<td width="20%" align="center" bgcolor="#99cccc">Ngày nhận hồ sơ</td>
											<td width="20%" align="center" bgcolor="#99cccc">Ngày hẹn trả hồ sơ</td>
										</tr>
									</table>
									<marquee height="100" direction="up" scrollamount="1">
										<asp:DataList Runat="server" ID="dtlDSHoSoBoSung" Width="100%" CellPadding="3" CellSpacing="1"
											Border="1" bordercolordark="#FFFFFF" bordercolorlight="#787878">
											<ItemStyle Height="20px" Font-Bold="True" ForeColor="#0000ff"></ItemStyle>
											<ItemTemplate>
												<%# DataBinder.Eval(Container, "DataItem.SoBienNhan") %></td>
								<td width="30%"><%# DataBinder.Eval(Container, "DataItem.HoTen") %></td>
								<td width="20%"><%# DataBinder.Eval(Container, "DataItem.NgayNhan") %></td>
								<td width="20%"><%# DataBinder.Eval(Container, "DataItem.NgayHenTra") %>
									</ItemTemplate> </asp:DataList></MARQUEE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
