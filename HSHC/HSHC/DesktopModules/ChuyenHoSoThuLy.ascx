<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuuPhanCong" Src="ThongTinTraCuuPhanCong.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ChuyenHoSoThuLy.ascx.vb" Inherits="HSHC.ChuyenHoSoThuLy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">

function LaySoBienNhan()
		{
			var value,j,tenchkChon,ID,PrintID;
			PrintID='';
			for (j=3; j<eval('document.forms[0].all("<%=Me.ClientID%>_grdDanhSach")').rows.length+1 ; j++)
				{
					tenchkChon = "<%=Me.ClientID%>_grdDanhSach__ctl" + j + "_" + "chkXoa";
					ID = "<%=Me.ClientID%>_grdDanhSach";
					if(eval('document.forms[0].all("' + tenchkChon + '")').checked==1){
						if (PrintID!='')
						{
							PrintID=PrintID+','
						}
						PrintID=PrintID+eval('document.forms[0].all("' + ID + '")').rows(j-2).cells(2).innerText
					}
				}
				for (i=0;i<window.document.forms(0).length-1;i++)
				{
							
					if (window.document.forms(0).item(i).id.indexOf('txtChuoiSoBienNhan') != -1)
					{
							
						objSoBienNhan = window.document.forms(0).item(i);	
						objSoBienNhan.value= PrintID;
					}
							
				}
		}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td align="center">
			<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="90%" border="0">
				<TR>
					<TD vAlign="top" width="100%">
						<table class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
							<TR vAlign="middle">
								<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại&nbsp;hồ sơ 
										tiếp&nbsp;nhận&nbsp;&nbsp;</STRONG>
								</TD>
								<TD vAlign="middle" align="left" width="60%"><asp:dropdownlist id="ddlLinhVuc" runat="server" CssClass="QH_DropDownList" AutoPostBack="True" Width="95%"></asp:dropdownlist></TD>
								<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1"><asp:linkbutton id="btnThucHien" runat="server" CssClass="QH_Button" Visible="False">Thực hiện</asp:linkbutton></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<table width="100%">
							<tr>
								<td><asp:label id="lblHeader" runat="server" CssClass="QH_Label_Title" Width="100%"></asp:label></td>
							</tr>
							<tr>
								<td>
									<TABLE class="QH_Table" id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD height="10"></TD>
										</TR>
										<TR>
											<TD><uc1:thongtintracuuphancong id="ThongTinTraCuuPhanCong1" runat="server"></uc1:thongtintracuuphancong></TD>
										</TR>
										<TR>
											<TD height="5"><INPUT id="txtMaNguoiTacNghiep" type="hidden" size="1" name="txtMaNguoiTacNghiep" runat="server"><INPUT id="txtMaLinhVuc" type="hidden" size="1" name="txtMaLinhVuc" runat="server"><INPUT id="txtChuoiSoBienNhan" type="hidden" size="1" name="txtChuoiSoBienNhan" runat="server"></TD>
										</TR>
										<TR>
											<TD align="right"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton> <asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton> <asp:linkbutton id="btnInRaGiay" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD height="10"></TD>
										</TR>
										<TR>
											<TD><asp:datagrid id="grdDanhSach" CssClass="QH_DataGridBottom" Width="100%" Runat="server" autogeneratecolumns="False"
													AllowPaging="True" PageSize="10">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</td>
	</tr>
</TABLE>
<script language="javascript">
function CheckGrid()
{
	var gridID = "<%=grdDanhSach.ClientID%>";
	var rowEnd = eval('document.forms[0].all("<%=grdDanhSach.ClientID%>")').rows.length;
	kq=CheckAll(gridID, "chkSelectAll", "chkSelect", rowEnd);
}
</script>
