<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VPHC_DSHoSoVP.ascx.vb" Inherits="THTT.VPHC_DSHoSoVP" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Danh sách hồ sơ vi phạm hành chính</asp:label></TD>
	</TR>
	<TR>
		<TD height="10"></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="3">
			<asp:Label id="Label5" CssClass="QH_Label" Runat="server">Số dòng hiển thị</asp:Label>
			<asp:TextBox id="txtSoDong" CssClass="QH_TextBox" Width="25px" Runat="server" AutoPostBack="True"
				MaxLength="2"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD align="center"><asp:datagrid id="datagrid1" CssClass="QH_Datagrid" Width="100%" Runat="server" ShowHeader="True"
				AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" AllowSorting="True">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="Stt">
						<HeaderStyle Width="3%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink runat="server" Text="<%# datagrid1.CurrentPageIndex*datagrid1.PageSize + datagrid1.Items.Count+1 %>" ID="Hyperlink1" NavigateUrl='<%#GetMidURL("ID",trim(DataBinder.Eval(Container, "DataItem.ABC_MasoHS")) & "&Type=" & DataBinder.Eval(Container, "DataItem.PhanLoai") & "&DB=" & Request.QueryString("DB") & "&Loai=" & Request.QueryString("Loai"),GetCtr(DataBinder.Eval(Container, "DataItem.PhanLoai")))%>'>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Số QĐ">
						<HeaderStyle Width="10%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoQD") %>' ID="Label3">
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoQD") %>' ID="Textbox1">
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Họ tên">
						<HeaderStyle Width="15%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HOTEN") %>' ID="Label1">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Địa chỉ">
						<HeaderStyle Width="20%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DiaChi") %>' ID="Label2">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="NoiDungvp" HeaderText="Nội dung vi phạm">
						<HeaderStyle Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Số tiền">
						<HeaderStyle Width="10%"></HeaderStyle>
						<ItemStyle CssClass="QH_LabelRight"></ItemStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SoTien") %>' ID="Label6">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Tình trạng">
						<HeaderStyle Width="15%"></HeaderStyle>
						<ItemStyle></ItemStyle>
						<ItemTemplate>
							<asp:Label ForeColor=#006699 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TinhTrang") %>' ID="Label4" >
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
	<TR>
		<TD colspan="4" height="10"></TD>
	</TR>
	<TR>
		<TD colspan="3" align="center">
			<asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_TroVe.gif" CssClass="QH_Button"></asp:ImageButton>
			<asp:ImageButton id="btnIn" CssClass="QH_Button" ImageUrl="../../Images/btn_In.gif" runat="server"
				Visible="True"></asp:ImageButton>
		</TD>
	</TR>
</TABLE>
