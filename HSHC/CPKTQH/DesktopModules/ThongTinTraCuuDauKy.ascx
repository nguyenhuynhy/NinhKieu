<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuuDauKy.ascx.vb" Inherits="CPKTQH.ThongTinTraCuuDauKy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" class="QH_Table">
	<tr>
		<td width="50%">
			<TABLE cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<TD class="QH_ColLabel" width="30%">Loại hình</TD>
					<TD Width="70%" class="QH_ColControl">
						<asp:DropDownList id="ddlLoaiHinh" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:DropDownList></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Loại hồ sơ</TD>
					<TD class="QH_ColControl">
						<asp:DropDownList ID="ddlLoaiHoSo" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Tình trạng</TD>
					<TD class="QH_ColControl"><asp:DropDownList ID="ddlTinhTrang" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Từ ngày</TD>
					<TD class="QH_ColControl"><asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="35%"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Đến ngày</TD>
					<TD class="QH_ColControl"><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="35%"></asp:TextBox>
						&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
							<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
						</asp:hyperlink></TD>
				</tr>
			</TABLE>
		</td>
		<td width="50%">
			<TABLE cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<TD class="QH_ColLabel" width="30%">Số biên nhận</TD>
					<TD class="QH_ColControl" width="70%">
						<asp:TextBox id="txtSoBienNhan" Width="35%" CssClass="QH_TextBox" Runat="server"></asp:TextBox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Họ tên</TD>
					<TD class="QH_ColControl"><asp:TextBox id="txtHoTen" Width="90%" runat="server" CssClass="QH_Textbox"></asp:TextBox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Số nhà</TD>
					<TD class="QH_ColControl">
						<asp:TextBox id="txtSoNha" Width="90%" CssClass="QH_TextBox" Runat="server"></asp:TextBox></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Đường</TD>
					<TD class="QH_ColControl">
						<asp:DropDownList id="ddlDuong" Width="90%" CssClass="QH_DropDownList" Runat="server"></asp:DropDownList></TD>
				</tr>
				<tr>
					<TD class="QH_ColLabel">Phường</TD>
					<TD class="QH_ColControl"><asp:DropDownList ID="ddlPhuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</tr>
			</TABLE>
		</td>
	</tr>
</TABLE>
