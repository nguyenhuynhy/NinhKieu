<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="PhieuKhaoSat.ascx.vb" Inherits="CPKTQH.PhieuKhaoSat" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<script language="javascript">
function ChonYKien(obj1)
{

			
	

}
</script>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD vAlign="top" width="100%">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" width="16%" height="23">Giờ khảo sát</TD>
					<TD class="QH_ColControl" width="29%" height="23"><asp:textbox id="txtGioKhaoSat" Width="40%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
					<TD class="QH_ColLabel" width="18%" height="23">Ngày khảo sát</TD>
					<TD class="QH_ColControl" width="*" height="23"><asp:textbox id="txtNgayKhaoSat" Width="40%" runat="server" CssClass="QH_Textbox"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgaykhaosat" CssClass="CommandButton" Runat="server">
							<asp:Image runat="server" ID="btnNgayQD" ImageUrl="~/Images/calendar.gif" CssClass="QH_imageButton"></asp:Image>
						</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="13%">Cán bộ khảo sát 1</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtCanBoKhaoSat1" Width="90%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
					<TD class="QH_ColLabel" width="13%" colSpan="1" rowSpan="1">Chức vụ 1</TD>
					<TD class="QH_ColControl" colSpan="1"><asp:textbox id="txtChucVu1" Width="80%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
				<TR>
					<TD class="QH_ColLabel">Cán bộ khảo sát 2</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtCanBoKhaoSat2" Width="90%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
					<TD class="QH_ColLabel">Chức vụ 2</TD>
					<TD class="QH_ColControl"><asp:textbox id="txtChucVu2" Width="80%" runat="server" CssClass="QH_Textbox"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel">Lãnh đạo đơn vị</TD>
					<TD class="QH_ColControl">
						<asp:textbox id="txtLanhDaoDonVi" CssClass="QH_Textbox" runat="server" Width="90%"></asp:textbox></TD>
					<TD class="QH_ColLabel"></TD>
					<TD class="QH_ColControl"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</table>
<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr vAlign="top">
		<TD class="QH_ColControl" colSpan="2"><asp:datagrid id="dgdNoiDungKhaoSat" tabIndex="17" runat="server" CssClass="QH_DataGrid" OnDeleteCommand="dgdNoiDungKhaoSat_DeleteCommand"
				OnUpdateCommand="dgdNoiDungKhaoSat_UpdateCommand" OnPageIndexChanged="dgdNoiDungKhaoSat_PageIndexChanged" OnEditCommand="dgdNoiDungKhaoSat_EditCommand"
				AutoGenerateColumns="False" PageSize="4" ShowFooter="True" AllowPaging="True" AllowSorting="True" PagerStyle-Mode="NumericPages"
				PagerStyle-HorizontalAlign="Left" PagerStyle-Position="Bottom" HorizontalAlign="Left">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img alt=&quot;Lưu&quot; align=middle border=0 src=./Images/save.gif&gt;"
						HeaderText="Chọn" CancelText="&lt;img alt=&quot;Bỏ qua&quot; align=middle border=0 src=./Images/cancel.gif&gt;"
						EditText="&lt;img alt=&quot;sửa&quot; align=middle border=0 src=./Images/edit.gif&gt;">
						<HeaderStyle Width="4%"></HeaderStyle>
						<ItemStyle Width="4%"></ItemStyle>
					</asp:EditCommandColumn>
					<asp:ButtonColumn Text="&lt;img alt=&quot;Xo&#225;&quot; align=middle border= 0 src= ./Images/delete.gif&gt;"
						CommandName="Delete">
						<HeaderStyle Width="3%"></HeaderStyle>
						<ItemStyle Width="3%"></ItemStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn Visible="False" DataField="NoiDungKhaoSatID" HeaderText="NoiDungKhaoSatID"></asp:BoundColumn>
					<asp:TemplateColumn SortExpression="NoiDungKhaoSat" HeaderText="Nội dung khảo sát">
						<HeaderStyle Width="15%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label id="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDungKhaoSat")%>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<asp:LinkButton id="Linkbutton2" onclick="AddNewRow" runat="server" Text="Thêm dòng mới..." Enabled="<%# IsLastPage() %>">
							</asp:LinkButton>
						</FooterTemplate>
						<EditItemTemplate>
							<asp:TextBox ID="txtNoiDungKhaoSat" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.NoiDungKhaoSat")%>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="KetQuaKhaoSat" HeaderText="Kết quả khảo sát">
						<HeaderStyle Width="18%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label runat="server" ID="Label6" Text='<%# DataBinder.Eval(Container, "DataItem.KetQuaKhaoSat")%>'>
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox ID="txtKetQuaKhaoSat" runat="server" cssclass="QH_TextBox" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.KetQuaKhaoSat")%>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" CssClass="ActivePage"
					Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</tr>
	<tr vAlign="top">
		<TD class="QH_ColLabel" width="15%" rowSpan="2">Kết luận
		</TD>
		<td><asp:radiobuttonlist id="lstRadioKetLuan" runat="server">
				<asp:ListItem Value="0">Đủ điều kiện cấp giấy chứng nhận đăng k&#253; kinh doanh</asp:ListItem>
				<asp:ListItem Value="1">Kh&#244;ng đủ điều kiện cấp giấy chứng nhận đăng k&#253; kinh doanh</asp:ListItem>
				<asp:ListItem Value="2">&#221; kiến kh&#225;c</asp:ListItem>
			</asp:radiobuttonlist></td>
	</tr>
	<tr vAlign="top">
		<td colSpan="2"><asp:textbox id="txtDienGiai" Width="90%" runat="server" CssClass="QH_Textbox" TextMode="MultiLine"
				Rows="2"></asp:textbox></td>
	</tr>
	<TR>
		<TD colSpan="2"><asp:textbox id="txtTrinhThamDinhID" Width="0px" runat="server"></asp:textbox>
			<asp:TextBox id="txtKetLuan" Width="0px" runat="server"></asp:TextBox></TD>
	</TR>
</TABLE>
