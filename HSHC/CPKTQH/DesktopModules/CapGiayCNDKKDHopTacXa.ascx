<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="ucLinhVucCapPhep" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapGiayCNDKKDHopTacXa.ascx.vb" Inherits="CPKTQH.CapGiayCNDKKDHopTacXa" %>
<%@ Register TagPrefix="portal" Namespace="CPKTQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="Tab" TagName="TTSGP" Src="ThongTinSoGiayPhep.ascx" %>
<%@ Register TagPrefix="Tab" TagName="TTCN" Src="ThongTinCaNhan.ascx" %>
<%@ Register TagPrefix="Tab" TagName="TTDSXV" Src="ThongTinDanhSachXaVien.ascx" %>
<link href='<%= Request.ApplicationPath + "/INC/BT_DKKD.css" %>' 
type=text/css rel=stylesheet>
	<script language="javascript">
function CallNganhNghe(strURL,Parent)
{		
		strURL = GetParams(strURL);
		showWindow1(strURL,Parent);		
}
function showWindow1(obj1,Parent)
{
		//t = screen.height - 30;
		t = 300;
		w = screen.width - 10;
		window.open(obj1,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}
function FillDiaChi(obj1,obj2,str)
{
		obj1.value=str;
		
}


	</script>
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD width="100%" height="24">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="QH_Khung_TopLeft" width="16" height="24"></td>
						<td class="QH_Khung_TopMid" width="*"><asp:label id="Label5" runat="server" CssClass="QH_Label_Title" Width="100%">Thông tin giấy Chứng nhận ĐKKD Hợp tác xã</asp:label></td>
						<td class="QH_Khung_TopRight" width="16" height="24"></td>
					</tr>
				</table>
			</TD>
		</TR>
		<TR>
			<TD align="center">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="QH_Khung_Left" width="16">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr height="141">
									<td class="QH_Khung_Left1"></td>
								</tr>
							</TABLE>
						</td>
						<td vAlign="top" align="left" width="*">
							<!-- Content --><BR>
							<table width="100%" align="center">
								<!-- add  các user control   -->
								<tr>
									<TD align="center" width="100%" height="83">
										<table id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="left"><portal:tabstrip id="ctlTab" runat="server">
														<tab Text="Thông tin ĐKKD" PanelID="pnlNoiDungDKKD" />
														<tab Text="Thông tin chủ nhiệm" PanelID="pnlNguoiDungDau" />
														<tab Text="Danh sách xã viên" PanelID="pnlDanhSachXaVien" />
													</portal:tabstrip><asp:panel id="pnlNoiDungDKKD" CssClass="eDMS_tabPanel" Runat="Server">
														<tab:TTSGP id="ctlTTGP" runat="server"></tab:TTSGP>
													</asp:panel><asp:panel id="pnlNguoiDungDau" CssClass="eDMS_tabPanel" Runat="Server">
														<tab:TTCN id="ctlTTCN" runat="server"></tab:TTCN>
													</asp:panel><asp:panel id="pnlDanhSachXaVien" CssClass="eDMS_tabPanel" Runat="Server">
														<tab:TTDSXV id="ctlTTXV" runat="server"></tab:TTDSXV>
													</asp:panel></TD>
											</TR>
										</table>
									</TD>
								</tr>
								<!-- /add  các user control-->
								<tr>
									<td align="center">&nbsp;
										<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">C&#7853;p nh&#7853;t</asp:linkbutton>
										<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton><asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton><asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button">Tr&#7903; v&#7873;</asp:linkbutton></td>
								</tr>
							</table>
							<!-- Content --><INPUT id="cMsg" type="hidden" name="cMsg" runat="server"><INPUT id="hMsg" type="hidden" name="hMsg" runat="server"></td>
						<td class="QH_Khung_Right" width="16">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr height="*">
									<td></td>
								</tr>
								<tr height="141">
									<td class="QH_Khung_Right1"></td>
								</tr>
							</TABLE>
						</td>
					</tr>
				</table>
			</TD>
		</TR>
	</TABLE>
	<script>
		if (document.all("<%=hMsg.ClientID%>").value != ''){
			alert(document.all("<%=hMsg.ClientID%>").value);
			document.all("<%=hMsg.ClientID%>").value='';
		}
	
	if (document.all("hPanelID").value != "")
		{
			showPanel(document.all("hPanelID").value, 'ctlTab_' + document.all("hPanelID").value);
		}else{
			showPanel('pnlNoiDungDKKD', 'ctlTab_pnlNoiDungDKKD');
		}

	</script>
	<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
	<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
	<asp:textbox id="txtGiayCNDKKDHTXID" runat="server" Width="0px"></asp:textbox>
	<asp:textbox id="txtMaSoNguoiSuDung" runat="server" Width="0px"></asp:textbox>
