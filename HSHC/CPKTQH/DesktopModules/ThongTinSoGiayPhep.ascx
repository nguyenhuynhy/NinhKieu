<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinSoGiayPhep.ascx.vb" Inherits="CPKTQH.ThongTinSoGiayPhep" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">
function txtSoGiayPhep_blur()
{
	var ctl = '<%=request.params("ctl")%>';
	if (ctl=='CAPMOICNDKKD')
	{
		var txtSoGiayPhep = document.all('<%=txtSoGiayPhep.clientID%>') ;
		var txtSoGiayPhepGoc = document.all('<%=txtSoGiayPhepGoc.clientID%>') ;
		var txtSoGiayPhepTruoc = document.all('<%=txtSoGiayPhepTruoc.clientID%>') ;
	
		txtSoGiayPhepGoc.value = txtSoGiayPhep.value;
		txtSoGiayPhepTruoc.value = txtSoGiayPhep.value;
	}
}
</script>
<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="96%" border="0">
	<tr>
		<td vAlign="middle" width="100%" colSpan="8" height="23"><asp:label id="Label4" runat="server" CssClass="QH_LabelLeftBold" Width="100%">Thông tin GCN ĐKKD</asp:label></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" width="15%">Số&nbsp;GCN&nbsp;ĐKKD&nbsp; <FONT color="#ff0000">*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" runat="server" CssClass="QH_Textbox" Width="40%"></asp:textbox></td>
		<TD class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" rowSpan="1">Số 
			GCN&nbsp;gốc <FONT color="#ff0000">*</FONT></TD>
		<TD class="QH_ColControl" width="15%"><asp:textbox id="txtSoGiayPhepGoc" runat="server" CssClass="QH_Textbox" Width="100%"></asp:textbox></TD>
		<TD class="QH_ColLabel" width="10%">Ngày cấp <FONT color="#ff0000">*</FONT></TD>
		<TD class="QH_ColControl" width="10%"><asp:textbox id="txtNgayCapGoc" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></TD>
	</tr>
	<TR>
		<TD class="QH_ColLabel" vAlign="middle" width="15%">Ngày cấp <FONT color="#ff0000">*</FONT></TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCap" runat="server" CssClass="QH_textbox" Width="40%" EnableViewState="true"></asp:textbox>&nbsp;<asp:image id="imgNgayCap" runat="server" CssClass="QH_Button" AlternateText="Chọn lịch" ImageAlign="Middle"
				ImageUrl="~\images\calendar.gif" Visible="False"></asp:image></TD>
		<TD class="QH_ColLabel" vAlign="middle" width="15%">Số GCN trước <FONT color="#ff0000">*</FONT></TD>
		<TD class="QH_ColControl" width="15%"><asp:textbox id="txtSoGiayPhepTruoc" runat="server" CssClass="QH_Textbox" Width="100%"></asp:textbox></TD>
		<TD class="QH_ColLabel" width="10%">Ngày cấp <FONT color="#ff0000">*</FONT></TD>
		<td class="QH_ColControl" width="10%"><asp:textbox id="txtNgayCapTruoc" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></td>
	</TR>
</table>
<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="96%" border="0">
	<tr>
		<td vAlign="middle" width="100%" colSpan="4" height="23"><asp:label id="Label1" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><b>Thông 
					tin kinh doanh</b></asp:label></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%"><FONT color="#ff0000"><FONT color="#000000">Lĩnh 
					vực&nbsp;CP </FONT><FONT color="#ff0000">*</FONT></FONT></td>
		<td class="QH_ColControl" width="35%"><FONT color="#ff0000"><asp:dropdownlist id="ddlMaLinhVucCapPhep" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></FONT></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%"><asp:label id="Label5" runat="server">S&#7889; biên nh&#7853;n</asp:label></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" runat="server" CssClass="QH_Textbox" Width="40%"></asp:textbox></td>
	</tr>
	<tr>
		<!--
		<td class="QH_ColLabel" vAlign="middle" width="15%">Hình thức KD&nbsp; <FONT color="#ff0000">
				*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaHinhThucKinhDoanh" runat="server" CssClass="QH_DropDownList" Width="100%"
				EnableViewState="true"></asp:dropdownlist></td>
		-->
		<td class="QH_ColLabel" vAlign="middle" width="15%"><FONT color="#ff0000"><FONT color="#ff0000"><FONT color="#000000">Ngành 
						KD&nbsp; </FONT><FONT color="#ff0000">*</FONT></FONT></FONT></td>
		<td class="QH_ColControl" width="35%">
			<asp:dropdownlist id="ddlMaNganhKinhDoanh" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%"><FONT color="#ff0000"><FONT color="#000000">Tên 
					hợp tác xã&nbsp; </FONT><FONT color="#ff0000">*</FONT></FONT><FONT color="#000000">
			</FONT>
		</td>
		<td class="QH_ColControl" width="35%">
			<asp:textbox id="txtBangHieu" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"
				MaxLength="100"></asp:textbox></td>
	</tr>
	<TR>
		<TD class="QH_ColLabel" vAlign="top" width="15%" rowSpan="2">
			<P style="MARGIN-TOP: 4px; MARGIN-BOTTOM: 0px">Mặt hàng&nbsp;KD <FONT color="#ff0000">*</FONT></P>
		</TD>
		<P></P>
		<td class="QH_ColControl" vAlign="top" width="35%" rowSpan="2"><asp:textbox id="txtMatHangKinhDoanh" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"
				MaxLength="500" TextMode="MultiLine" Rows="1" Height="42px"></asp:textbox></td>
	</TR>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Vốn KD <FONT color="#ff0000">*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtVonKinhDoanh" runat="server" CssClass="QH_TextBox" Width="40%" EnableViewState="true"
				MaxLength="15"></asp:textbox>&nbsp;(đồng)</td>
	</tr>
	<tr>
		<td vAlign="middle" width="100%" colSpan="4" height="23"><asp:label id="lblDiaChiKinhDoanh" runat="server" CssClass="QH_LabelLeftBold" Width="100%"><b>&#272;&#7883;a 
					ch&#7881; kinh doanh</b></asp:label></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%" height="23">Số nhà <FONT color="#ff0000">
				*</FONT></td>
		<td class="QH_ColControl" width="35%" height="23"><asp:textbox id="txtSoNha" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%" height="23">Điện thoại</td>
		<td class="QH_ColControl" width="35%" height="23"><asp:textbox id="txtDienThoai" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Đường</td>
		<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuong" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Fax</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtFax" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Phường <FONT color="#ff0000">*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuong" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Email</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtEmail" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Địa chỉ cũ</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCu" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Website</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtWebsite" runat="server" CssClass="QH_textbox" Width="100%" EnableViewState="true"></asp:textbox></td>
	</tr>
	<TR>
		<td vAlign="middle" width="100%" colSpan="4" height="23"><asp:label id="Label2" runat="server" CssClass="QH_LabelLeftBold" Width="100%">
				<b>Thông tin khác</b></asp:label></td>
	</TR>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%"><asp:label id="Label3" runat="server">Ng&#432;&#7901;i ký</asp:label></td>
		<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlNguoiKy" runat="server" CssClass="QH_Dropdownlist" Width="100%"></asp:dropdownlist></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Số lần cấp đổi</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoLanCapDoi" runat="server" Width="40%" CssClass="QH_textbox" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="top" width="15%" rowSpan="2"><p style="MARGIN-TOP: 4px; MARGIN-BOTTOM: 0px">Ghi 
				chú</p>
		</td>
		<td class="QH_ColControl" vAlign="top" width="35%" rowSpan="2"><asp:textbox id="txtGhiChu" runat="server" Width="100%" CssClass="QH_textbox" MaxLength="500"
				EnableViewState="true" Height="42px" Rows="1" TextMode="MultiLine"></asp:textbox></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Số lần cấp phó bản</td>
		<td class="QH_ColControl" width="35%" height="14"><asp:textbox id="txtSoLanCapPhoBan" runat="server" Width="40%" CssClass="QH_textbox" EnableViewState="true"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Số lần thay đổi</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoLanThayDoi" runat="server" Width="40%" CssClass="QH_textbox" EnableViewState="true"></asp:textbox></td>
	</tr>
</table>
