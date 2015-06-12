<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuu" Src="ThongTinTraCuu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachHuyHoSo.ascx.vb" Inherits="PortalQH.DanhSachHuyHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD height="10"></TD>
	</TR>
	<TR>
		<TD height="24"><uc1:thongtintracuu id="ThongTinTraCuu1" runat="server"></uc1:thongtintracuu></TD>
	</TR>
	<TR>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD align="right"><asp:imagebutton id="btnTimKiem" runat="server" ImageUrl="../../images/btn_Timkiem.gif" CssClass="QH_Button"></asp:imagebutton></TD>
	</TR>
	<TR>
		<TD height="10"></TD>
	</TR>
	<TR>
		<TD><asp:datagrid id="grdDanhSachHoSo" CssClass="QH_DataGridBottom" Width="100%" Runat="server" autogeneratecolumns="False"
				AllowSorting="True">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="STT">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblSTT" Runat="server" CssClass="QH_ColLabelMiddle" Width="100%" Text='<%# grdDanhSachHoSo.CurrentPageIndex*grdDanhSachHoSo.PageSize + grdDanhSachHoSo.Items.Count + 1 %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Tình trạng">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblTinhTrang" Runat="server" CssClass="QH_ColLabelMiddle" Width="100%" text='<%# DataBinder.Eval(Container,"DataItem.TinhTrang") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Số biên nhận">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink id="hplSoBienNhan" Runat="server" Text='<%# DataBinder.Eval(container.dataitem,"SoBienNhan") %>' NavigateUrl='<%# "~/default.aspx?tabid=" & cstr(request.params("tabid")) & "&SoBienNhan=" & DataBinder.Eval(container.dataitem,"SoBienNhan") %>'>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Họ tên">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblHoTen" Runat="server" CssClass="QH_ColLabelLeft" Width="100%" text='<%# DataBinder.Eval(Container,"DataItem.Hoten") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Địa chỉ">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblDiaChi" Runat="server" CssClass="QH_ColLabelLeft" Width="100%" text='<%# DataBinder.Eval(Container,"DataItem.DiaChi") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Ngày nhận">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblNgayNhan" Runat="server" CssClass="QH_ColLabelMiddle" Width="100%" text='<%# DataBinder.Eval(Container,"DataItem.NgayNhan") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Ngày hẹn trả">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblNgayHenTra" Runat="server" CssClass="QH_ColLabelMiddle" Width="100%" text='<%# DataBinder.Eval(Container,"DataItem.NgayHenTra") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Loại hồ sơ">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblLoaiHoSo" Runat="server" CssClass="QH_ColLabelMiddle" Width="100%" text='<%# DataBinder.Eval(Container,"DataItem.LoaiHoSo") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
		</TD>
	</TR>
</TABLE>
