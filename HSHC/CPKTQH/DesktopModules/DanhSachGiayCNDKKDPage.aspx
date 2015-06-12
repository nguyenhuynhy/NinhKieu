<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DanhSachGiayCNDKKDPage.aspx.vb" Inherits="CPKTQH.DanhSachGiayCNDKKDPage"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DANH SACH GIAY CHUNG NHAN DANG KY KINH DOANH</title>
		<link 
href='<%= Request.ApplicationPath + "/Portals/_default/Skins/LIGHTBLUESKIN/LightBlueskin.css" %>' 
type=text/css rel=stylesheet>
			<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
			<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
			<meta name="vs_defaultClientScript" content="JavaScript">
			<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<td><asp:label id="lblTieuDe" Runat="server" CssClass="QH_Label_Title" Width="100%">Danh sách giấy chứng nhận đăng ký kinh doanh</asp:label></td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="Label1" Runat="server" CssClass="QH_ColLabel1">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" Runat="server" CssClass="QH_TextRight" Width="30px" MaxLength="3"
							AutoPostBack="True"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:datagrid id="dgdDanhSach" Runat="server" CssClass="QH_DataGridBottom" Width="100%" AllowPaging="True"
							autogeneratecolumns="False" CellPadding="3">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="STT">
									<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="GiayCNDKKDID" DataField="GiayCNDKKDID" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Số GCN ĐKKD" HeaderStyle-HorizontalAlign="Center" DataField="SoGiayPhep">
									<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Ngày cấp" HeaderStyle-HorizontalAlign="Center" DataField="NgayCap">
									<ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Họ tên" HeaderStyle-HorizontalAlign="Center" DataField="HoTen">
									<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Địa chỉ kinh doanh" HeaderStyle-HorizontalAlign="Center" DataField="DiaChi">
									<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Bảng hiệu" HeaderStyle-HorizontalAlign="Center" DataField="BangHieu">
									<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Mặt hàng kinh doanh" HeaderStyle-HorizontalAlign="Center" DataField="MatHangKinhDoanh">
									<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td align="center"><asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
