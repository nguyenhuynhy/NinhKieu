<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongKeDanhSachHoSoViPhamLV.ascx.vb" Inherits="THTT.ThongKeDanhSachHoSoViPhamLV" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">   
function GoBack() 
{ 
alert(abc);
if (navigator.appName == "Microsoft Internet Explorer") 
document.location="javascript: history.go(-1)" 
else 
document.location="javascript: window.back()" 
} 
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD colSpan="3"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD colSpan="3" height="15"></TD>
	</TR>
	<TR>
		<TD width="20%"></TD>
		<TD width="*">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD width="25%"><asp:label id="Label1" CssClass="QH_LabelLeft" Width="100%" Runat="server">Phòng ban /Đơn vị</asp:label></TD>
					<TD class="QH_ColLabelLeft" width="5%">:</TD>
					<TD width="*"><asp:label id="lblTenDonVi" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label3" CssClass="QH_LabelLeft" Width="100%" Runat="server">Thời gian tiếp nhận</asp:label></TD>
					<TD class="QH_ColLabelLeft">:</TD>
					<TD><asp:label id="lblThoiGian" CssClass="QH_LabelLeftBold" Width="100%" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="20%"></TD>
	</TR>
	<TR>
		<TD height="15"></TD>
	</TR>
	<TR>
		<TD colSpan="3"><asp:label id="lblLoai" CssClass="QH_LabelMiddleBold" Width="100%" Runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="3"><asp:label id="Label4" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" Runat="server" AutoPostBack="True"
				MaxLength="3"></asp:textbox></TD>
	</TR>
	<TR>
		<TD colSpan="6"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" runat="server" width="100%" AutoGenerateColumns="False"
				CellPadding="3" AllowSorting="True" AllowPaging="True">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="STT">
						<ItemStyle Width="5%" HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label width="100%" id="Label2" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Số hồ sơ">
						<ItemStyle Width="8%" HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Hyperlink id="hplSoBienBan" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.SoBienBan")%>' NavigateUrl='<%# EditURL("MaDonVi",Request.Params("MaDonVi")&"&TenDonVi=" & Request.Params("TenDonVi") & "&ID=" & DataBinder.Eval(Container, "DataItem.BienBanID") & "&TuNgay=" & Request.Params("TuNgay") & "&DenNgay=" & Request.Params("DenNgay")& "&SelectID=" &Request.Params("SelectID")& "&SelectIndex=" &Request.Params("SelectIndex")& "&LoaiHoSo=" & Request.Params("LoaiHoSo"),"VPHC_CHITIETHOSO") %>'>
							</asp:Hyperlink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Họ tên">
						<ItemStyle Width="18%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblHoTen" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.HoTen") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Địa chỉ vi phạm">
						<ItemStyle Width="18%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblDiaChiViPham" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChiViPham") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Ngày nhận">
						<ItemStyle Width="8%" HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblNgayNhan" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NgayNhan") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Ngày quyết định">
						<ItemStyle Width="8%" HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblNgayQuyetDinh" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NgayQuyetDinh") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Nội dung vi phạm">
						<ItemStyle Width="18%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblNoiDungViPham" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDungViPham") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Tình trạng">
						<ItemStyle Width="17%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblTenTinhTrang" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.TenTinhTrang") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></TD>
	</TR>
	<TR>
		<TD colSpan="3" height="5"></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="3"><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
	</TR>
</TABLE>
<asp:textbox id="txtBienBanID" CssClass="QH_TextBox" Width="0%" Runat="server" Enabled="False"></asp:textbox>
<P></P>
