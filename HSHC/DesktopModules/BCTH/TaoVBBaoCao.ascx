<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TaoVBBaoCao.ascx.vb" Inherits=".TaoVBBaoCao" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<table cellSpacing="0" cellPadding="0" width="90%" align="center">
	<tr>
		<td align="center">
			<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td colSpan="2"><asp:label id="lblTitle" width="100%" Runat="server" CssClass="QH_Label_Title">Soạn thảo báo cáo</asp:label></td>
				</tr>
				<tr>
					<td>
						<table width="100%" align="center">
							<tr>
								<td width="30%"><asp:label id="Label1" CssClass="QH_Label" runat="server">Đơn vị báo cáo</asp:label><font color="red">*</font></td>
								<td width="70%"><asp:dropdownlist id="ddlDonVi" CssClass="QH_TextBox" runat="server" Width="60%"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td width="30%"><asp:label id="Label2" CssClass="QH_Label" runat="server">Kỳ báo cáo</asp:label><font color="red">*</font></td>
								<td><asp:dropdownlist id="ddlKyBaoCao" CssClass="QH_textBox" runat="server" Width="60%"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
					<td>
						<table width="100%">
							<tr>
								<td width="20%"><asp:label id="Label3" CssClass="QH_label" runat="server">Năm</asp:label><font color="red">*</font></td>
								<td><asp:dropdownlist id="ddlNam" CssClass="QH_DropDownList" runat="server" Width="25%"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td width="20%"><asp:label id="Label4" CssClass="QH_Label" runat="server">Ngày tạo lập</asp:label></td>
								<td><asp:textbox id="txtNgayLap" CssClass="QH_textBox" runat="server" Width="25%"></asp:textbox><asp:image id="imgNgayXuLy" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch" ImageAlign="Middle"
										ImageUrl="~\images\calendar.gif"></asp:image></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<table width="100%" align="center">
							<tr>
								<td align="left" width="10%"><asp:label id="Label5" Runat="server" CssClass="QH_Label" Text="File đính kèm"></asp:label></td>
								<td><INPUT id="txtUpLoadFile" type="file" name="txtUpLoadFile" runat="server"></td>
							</tr>
							<tr>
								<td align="left"><asp:Label ID="lblTinhTrangHD" Runat="server" CssClass="QH_Label" Text="Tình trạng"></asp:Label>
								</td>
								<td><asp:CheckBox ID="chkTinhTrang" Runat="server"></asp:CheckBox></td>
							</tr>
							<tr>
								<td align="left" width="10%"><asp:label id="lbl1" Runat="server" CssClass="QH_Label" Text="Tiêu đề"></asp:label><FONT color="#ff3300">*</FONT>
								</td>
								<td width="90%"><asp:textbox id="txtTieuDe" Runat="server" CssClass="QH_TextBox" Width="80%" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<TD><asp:label id="lbl3" Runat="server" CssClass="QH_LabelLeftBold">Nội dung</asp:label><FONT color="#ff3300"></FONT></TD>
								<td align="right"><asp:Label ID="lblXemFile" Runat="server" CssClass="QH_Label" Visible="False">File đính kèm :</asp:Label><asp:LinkButton ID="butFileName" Visible="False" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileName") %>'></asp:LinkButton></td>
							</tr>
							<tr>
								<TD colSpan="2"><FTB:FREETEXTBOX id="ftbNoidung" width="100%" runat="server" JavaScriptLocation="ExternalFile" SupportFolder="~/Inc/FreeTextBox/"
										height="300"><TOOLBARS>
											<FTB:TOOLBAR>
												<FTB:INSERTIMAGEFROMGALLERY />
												<FTB:INSERTTABLE />
												<FTB:EDITTABLE />
											</FTB:TOOLBAR>
										</TOOLBARS>
									</FTB:FREETEXTBOX></TD>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<TD align="center" colSpan="2"><asp:imagebutton id="btnSave" Runat="server" ImageUrl="../../images/btn_Luu.gif"></asp:imagebutton>&nbsp;&nbsp;
						<asp:imagebutton id="btnTrove" Runat="server" ImageUrl="../../images/btn_TroVe.gif"></asp:imagebutton></TD>
				</tr>
			</table>
		</td>
	</tr>
</table>
