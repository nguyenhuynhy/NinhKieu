<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BaoCaoTinhHinhXacNhan.ascx.vb" Inherits="CPVHQH.BaoCaoTinhHinhXacNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc1" TagName="Reports" Src="../../Report/DesktopModules/Reports.ascx" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/PopupCalendar.js"%>'></script>
<script language="javascript">
function LayLoaiBaoCao()
		{
			var value,j,tenchkChon,ID,PrintID,objLoai;
			PrintID='';
			
			for (j=0; j<eval('document.forms[0].all("<%=Me.UniqueID%>:lstReports")').length-1 ; j++)
				{
					ID = "<%=Me.ClientID%>_lstReports_" + j;
					
					if(eval('document.forms[0].all("' + ID + '")').checked==1){
						
						value = eval('document.forms[0].all("' + ID + '")').value;		
					}
				}
				for (i=0;i<window.document.forms(0).length-1;i++)
				{
							
					if (window.document.forms(0).item(i).id.indexOf('txtLoai') != -1)
					{
							
						objLoai = window.document.forms(0).item(i);	
						objLoai.value= value;
					}
							
				}
		}

</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Width="100%" CssClass="QH_Label_Title" Runat="server"></asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td align="center" width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD vAlign="top" width="100%">
									<TABLE class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
										<TR vAlign="middle">
											<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại hồ sơ tiếp nhận 
													&nbsp;</STRONG>
											</TD>
											<TD vAlign="middle" align="left" width="60%"><asp:dropdownlist id="ddlLinhVuc" Width="95%" CssClass="QH_DropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1">
												<asp:linkbutton id="btnThucHien" Visible="false" CssClass="QH_Button" runat="server">Thực hiện</asp:linkbutton>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%" colSpan="3">
												<asp:radiobuttonlist id="lstReports" Width="100%" runat="server" AutoPostBack="True" RepeatColumns=2 CssClass="QH_RadioButtonList"></asp:radiobuttonlist></TD>
										</TR>			
									</TABLE>
								</TD>
							</TR>
							
							<TR vAlign="top">
								<TD vAlign="top" width="*">
									<uc1:Reports id="Reports1" runat="server"></uc1:Reports>
								</TD>
							
							</TR>
						</TABLE>
					</td>
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
