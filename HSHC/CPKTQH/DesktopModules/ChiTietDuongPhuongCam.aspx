<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChiTietDuongPhuongCam.aspx.vb" Inherits="CPKTQH.ChiTietDuongPhuongCam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>THÔNG TIN CHI TIẾT ĐƯỜNG PHƯỜNG CẤM</title>
		<link href='<%= Request.ApplicationPath + "/Portals/_default/Skins/LIGHTBLUESKIN/LightBlueSkin.css" %>' 
type=text/css rel=stylesheet>
			<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
			<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
			<meta name="vs_defaultClientScript" content="JavaScript">
			<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
			<script language=javascript 
		src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
			<script language=javascript 
		src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
				<TR>
					<td width="5%"></td>
					<TD width="25%" class="QH_LabelLeft">Ngành cấp trên</TD>
					<td colspan="2" width="*"><asp:label ID="lblNganhCapTren" Runat="server" CssClass="QH_LabelLeftBold" Width="100%"></asp:label></td>
				</TR>
				<TR>
					<TD colspan="4" height="5"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD class="QH_LabelLeft">Ngành kinh doanh</TD>
					<td colspan="2"><asp:Label ID="lblNganhKD" Runat="server" CssClass="QH_LabelLeftBold" Width="100%"></asp:Label></td>
				</TR>
				<TR>
					<TD colspan="4" height="5"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD class="QH_LabelLeft">Phạm vi cấm</TD>
					<td colspan="2"><asp:label ID="lblLoai" Runat="server" CssClass="QH_LabelLeftBold" Width="100%"></asp:label></td>
				</TR>
				<TR>
					<TD colspan="4" height="5"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD class="QH_LabelLeft">Thời gian</TD>
					<td width="15%" class="QH_ColLabel">Từ ngày</td>
					<td width="*"><asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" Width="40%"></asp:TextBox>
						&nbsp;<asp:Image ID="imgTuNgay" Runat="server" CssClass="QH_Button" ImageUrl="~/Images/calendar.gif"></asp:Image></td>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<td class="QH_ColLabel">Đến ngày</td>
					<td><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" Width="40%"></asp:TextBox>
						&nbsp;<asp:Image ID="imgDenNgay" Runat="server" CssClass="QH_Button" ImageUrl="~/Images/calendar.gif"></asp:Image></td>
				</TR>
				<TR>
					<TD colspan="4" height="15"></TD>
				</TR>
				<TR>
					<TD colspan="4">
						<TABLE class="QH_Table" WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
							<TR>
								<TD Class="QH_LoaiHS" align="center"><asp:Label ID="lblTenDuongPhuong" Font-Bold="True" ForeColor="#ff0000" Runat="server" Width="100%"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colspan="4" height="5"></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_Label_Title" width="15%">STT</TD>
								<TD class="QH_Label_Title" width="15%"><asp:checkbox id="chkAll" runat="server" BorderStyle="None"></asp:checkbox></TD>
								<TD class="QH_Label_Title" width="*"><asp:label id="lblMain" Width="100%" Runat="server">ds</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				<TR>
					<TD vAlign="top" colSpan="4">
						<DIV style="TABLE-LAYOUT: fixed; OVERFLOW: scroll; HEIGHT: 260px"><asp:datagrid id="dgdDuongPhuong" CssClass="QH_DataGrid" Width="100%" runat="server" CellPadding="3"
								AllowSorting="True" AutoGenerateColumns="False" ShowHeader="false">
								<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
								<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemStyle Width="48px"></ItemStyle>
										<ItemTemplate>
											<asp:Label id="lblStt" runat="server" cssclass="QH_ColLabelMiddle" Width="100%" Text="<%# dgdDuongPhuong.CurrentPageIndex*dgdDuongPhuong.PageSize + dgdDuongPhuong.Items.Count+1 %>">
											</asp:Label>
											<asp:Label id="lblMa" Visible="False" cssclass="QH_ColLabelMiddle" runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataItem.Ma") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemStyle HorizontalAlign="Center" Width="48px"></ItemStyle>
										<ItemTemplate>
											<asp:checkbox id="chkXoa" runat="server" enabled="true" Checked='<%# DataBinder.Eval(Container,"DataItem.Chon") %>'>
											</asp:checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemStyle Width="237px"></ItemStyle>
										<ItemTemplate>
											<asp:Label id="lblTen" cssclass="QH_LabelLeft" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Ten") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD colspan="4">
					</TD>
				</TR>
				<TR>
					<TD colspan="4" height="5"></TD>
				</TR>
				<TR>
					<TD colspan="4" valign="middle" align="center">
						<asp:ImageButton id="btnCapNhat" runat="server" CssClass="QH_Button" ImageUrl="~/Images/btn_CapNhat.gif"></asp:ImageButton>
						<asp:ImageButton id="btnTroVe" runat="server" CssClass="QH_Button" ImageUrl="~/Images/btn_TroVe.gif"></asp:ImageButton></TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">
function select_deselectAll (chkAll) 
{ 
	var frm = document.forms[0];
	var i;
	var objAll;
	var obj;
	for (i=0;i<window.document.forms(0).length;i++)
	{
		if (window.document.forms(0).item(i).id.indexOf(chkAll) != -1)
		{
			objAll = window.document.forms(0).item(i);	
		}
	}
	for (i=0;i<window.document.forms(0).length;i++)
	{
		obj = window.document.forms(0).item(i);
		if (window.document.forms(0).item(i).id.indexOf('chkXoa') != -1)
		{
			if (objAll.checked == true)
			{
				obj.checked = true;
			}
			else
			{
				obj.checked = false;
			}
		}
	}
}
		</script>
	</body>
</HTML>
