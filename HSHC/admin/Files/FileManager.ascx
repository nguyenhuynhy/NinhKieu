<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control Inherits="PortalQH.FileManager" CodeBehind="FileManager.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<portal:title id="Title1" EditText="Upload New File(s)" runat="server"></portal:title>
<br>
<p align="center">
	<asp:Label ID="lblRootType" Runat="server" CssClass="SubHead"></asp:Label>
	&nbsp;&nbsp;
	<asp:Label ID="lblRootFolder" Runat="server" CssClass="Normal"></asp:Label>
</p>
<asp:datagrid id="grdFiles" runat="server" Border="0" CellPadding="4" AutoGenerateColumns="false" OnDeleteCommand="grdFiles_DeleteCommand" OnEditCommand="grdFiles_EditCommand" DataKeyField="FileName" summary="File Manager Design Table">
	<Columns>
		<asp:TemplateColumn>
			<ItemTemplate>
				<asp:ImageButton ID="cmdDelete" AlternateText="Delete" Runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/images/delete.gif"></asp:ImageButton>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn DataField="FileName" HeaderText="File Name">
			<HeaderStyle Wrap="False" CssClass="NormalBold"></HeaderStyle>
			<ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
		</asp:BoundColumn>
		<asp:TemplateColumn HeaderText="Size (KB)">
			<HeaderStyle HorizontalAlign="Right" CssClass="NormalBold"></HeaderStyle>
			<ItemStyle HorizontalAlign="Right" CssClass="Normal"></ItemStyle>
			<ItemTemplate>
				<asp:label runat="server" Text='<%# FormatSize(DataBinder.Eval(Container.DataItem, "Size")) %>' ID="Label1"/>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn>
			<ItemTemplate>
				<asp:LinkButton ID="cmdDownLoad" Runat="server" CssClass="CommandButton" CausesValidation="False" CommandName="Edit" Text="Download"></asp:LinkButton>
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
<br>
<asp:Label ID="lblDiskSpace" Runat="server" CssClass="Normal"></asp:Label>
<br>
<br>
<asp:linkbutton id="cmdSynchronize" runat="server" Cssclass="CommandButton">Synchronize Database And File System</asp:linkbutton>
<br>
<br>
<span class="SubHead"><label for=”<%=chkUploadRoles.ClientID%>">File Upload Roles:</label></span>
<br>
<br>
<asp:checkboxlist id="chkUploadRoles" runat="server" width="300" Font-Size="8pt" Font-Names="Verdana,Arial" cellspacing="0" cellpadding="0" RepeatColumns="2"></asp:checkboxlist>
<br>
<asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update"></asp:linkbutton>
<br>

