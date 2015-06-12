<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Reports.ascx.vb" Inherits="Reports" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="tblMain" cellSpacing="0" cellPadding="0" border="0" width="100%">
	<TR>
		<TD vAlign="top" align="center" width="100%">
			<asp:label id="lblErr" runat="server" ForeColor="Red"></asp:label>
		</TD>
	</TR>
	<TR>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" width="100%">
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<td width="100%" vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server" class="QH_RadioButtonList">
						</TABLE>
					</td>
				</tr>
				<tr>
					<td width="100%" vAlign="top" align="center">
						<TABLE class="QH_Table" cellSpacing="0" cellPadding="0" border="0" width="100%">
							<TR>
								<TD class="QH_ColLabel" width="80">Nhóm theo</TD>
								<TD width="150"><asp:dropdownlist CssClass="QH_DropDownList" id="grp1" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel" width="80">Nhóm theo</TD>
								<TD width="150"><asp:dropdownlist CssClass="QH_DropDownList" id="grp2" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel" width="80">Nhóm theo</TD>
								<TD width="150"><asp:dropdownlist CssClass="QH_DropDownList" id="grp3" runat="server" Width="100%"></asp:dropdownlist></TD>
								<!--<TD>GroupBy</TD>
								<TD><asp:dropdownlist id="grp4" runat="server" Width="85px"></asp:dropdownlist></TD>
								<TD>GroupBy</TD>
								<TD><asp:dropdownlist id="grp5" runat="server" Width="85px"></asp:dropdownlist></TD>-->
							</TR>
							<TR>
								<TD class="QH_ColLabel">Diễn giải</TD>
								<TD><asp:dropdownlist CssClass="QH_DropDownList" id="des1" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel">Diễn giải</TD>
								<TD><asp:dropdownlist CssClass="QH_DropDownList" id="des2" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel">Diễn giải</TD>
								<TD><asp:dropdownlist CssClass="QH_DropDownList" id="des3" runat="server" Width="100%"></asp:dropdownlist></TD>
								<!--<TD>Description</TD>
								<TD><asp:dropdownlist id="des4" runat="server" Width="85px"></asp:dropdownlist></TD>
								<TD>Description</TD>
								<TD><asp:dropdownlist id="des5" runat="server" Width="85px"></asp:dropdownlist></TD>-->
							</TR>
							<TR>
								<TD class="QH_ColLabel">Sắp xếp theo</TD>
								<TD><asp:dropdownlist CssClass="QH_DropDownList" id="sort1" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel">Sắp xếp theo</TD>
								<TD><asp:dropdownlist CssClass="QH_DropDownList" id="sort2" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel">Sắp xếp theo</TD>
								<TD><asp:dropdownlist CssClass="QH_DropDownList" id="sort3" runat="server" Width="100%"></asp:dropdownlist></TD>
								<!--<TD>Sort By</TD>
								<TD><asp:dropdownlist id="sort4" runat="server" Width="85px"></asp:dropdownlist></TD>
								<TD>Sort By</TD>
								<TD><asp:dropdownlist id="sort5" runat="server" Width="85px"></asp:dropdownlist></TD>-->
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD align="center" width="100%">
			<asp:linkbutton id="btnPreview" CssClass="QH_Button" runat="server">Xem báo cáo</asp:linkbutton>
		</TD>
	</TR>
</TABLE>
