<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TaoChuDeBaoCaoThoiVu.ascx.vb" Inherits="TaoChuDeBaoCaoThoiVu" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">
	function changeLoaiBaoCao() {
		var i, obj;
		if (window.document.forms(0) != undefined) {
			for (i=0; i<window.document.forms(0).length; i++) {
				obj = window.document.forms(0).item(i);
				if (obj.id.indexOf("ddlLoaiBaoCao")!=-1) {
					if (obj.value=="BCT") {
						document.all.trThang.style.display = "none";
						document.all.trTuan.style.display = "block";
					}
					else {
						document.all.trThang.style.display = "block";
						document.all.trTuan.style.display = "none";
					}
				}
			}
		}
	}
	
</script>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td>
			<table id="table2" width="70%" align="center">
				<tr>
					<TD class="QH_ColLabel" width="35%" align="right">Năm</TD>
					<TD class="QH_ColControl"><asp:DropDownList Runat="server" ID="ddlNam" CssClass="QH_DropDownList"></asp:DropDownList></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel" width="35%" align="right">Loại báo cáo</TD>
					<TD class="QH_ColControl">
						<asp:DropDownList Runat="server" ID="ddlLoaiBaoCao" CssClass="QH_DropDownList">
							<asp:ListItem Value="BCT">Báo cáo tuần</asp:ListItem>
							<asp:ListItem Value="BCH">Báo cáo tháng</asp:ListItem>
						</asp:DropDownList></TD>
				</tr>
				<tr id="trThang">
					<TD class="QH_ColLabel" width="35%" align="right">Tháng</TD>
					<TD class="QH_ColControl"><asp:DropDownList Runat="server" ID="ddlThang" CssClass="QH_DropDownList"></asp:DropDownList></TD>
				</tr>
				<tr id="trTuan">
					<td colspan="2">
						<table width="100%" cellpadding="0" cellspacing="0" border="0">
							<tr>
								<TD class="QH_ColLabel" width="20%" align="right">Tuần</TD>
								<TD class="QH_ColLabel" width="15%"><asp:DropDownList Runat="server" ID="ddlTuan" CssClass="QH_DropDownList"></asp:DropDownList></TD>
								<TD class="QH_ColLabel" width="10%" align="right">Từ ngày</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" Width="85%" CssClass="QH_TextBox" Runat="server" MaxLength="10" ReadOnly="True"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="10%" align="right">Đến ngày</TD>
								<TD class="QH_ColControl"><asp:textbox id="txtDenNgay" Width="85%" CssClass="QH_TextBox" Runat="server" MaxLength="10"
										ReadOnly="True"></asp:textbox></TD>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<TD class="QH_ColLabel" width="35%" align="right">Chủ đề</TD>
					<TD class="QH_ColControl"><asp:TextBox Runat="server" ID="txtChuDe" CssClass="QH_TextBox" TextMode="MultiLine" Width="300"
							Height="80"></asp:TextBox></TD>
				</tr>
				<tr>
					<td colspan="2" align="center"><asp:LinkButton Runat="server" CssClass="QH_Button" id="btnCapNhat">Cập nhật</asp:LinkButton>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
