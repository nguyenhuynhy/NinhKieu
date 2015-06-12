<%@ Control language="vb" CodeBehind="EditSearch.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditSearch" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" />
<br>
<table cellSpacing="0" cellPadding="2" border="0" summary="Edit Search Design Table">
	<tr>
		<td class="SubHead"><label for="<%=txtResults.ClientID%>">Maximum Search Results:</label></td>
		<td class="NormalTextBox"><asp:textbox id="txtResults" CssClass="NormalTextBox" runat="server" MaxLength="5"></asp:textbox></td>
	</tr>
	<TR>
		<TD class="SubHead"><label for="<%=txtTitle.ClientID%>">Maximum Title Length:</label></TD>
		<td class="NormalTextBox"><asp:textbox id="txtTitle" CssClass="NormalTextBox" runat="server" MaxLength="5"></asp:textbox></td>
	</TR>
	<tr>
		<td class="SubHead"><label for="<%=txtDescription.ClientID%>">Maximum Description Length:</label></td>
		<td class="NormalTextBox"><asp:textbox id="txtDescription" CssClass="NormalTextBox" runat="server" MaxLength="5"></asp:textbox></td>
	</tr>
	<TR>
		<TD colspan="2">&nbsp;</TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=chkDescription.ClientID%>">Show Description?</label></TD>
		<TD class="NormalTextBox"><asp:checkbox id="chkDescription" CssClass="NormalTextBox" runat="server"></asp:checkbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=chkAudit.ClientID%>">Show Audit?</label></TD>
		<TD class="NormalTextBox"><asp:checkbox id="chkAudit" CssClass="NormalTextBox" runat="server"></asp:checkbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=chkBreadcrumbs.ClientID%>">Show Breadcrumbs?</label></TD>
		<TD class="NormalTextBox"><asp:checkbox id="chkBreadcrumbs" CssClass="NormalTextBox" runat="server"></asp:checkbox></TD>
	</TR>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />
</p>
<hr><br>
<table cellSpacing="0" cellPadding="2" border="0" summary="Edit Search Design Table">
	<tr>
		<td align="center" valign="bottom">
			<span class="SubHead"><label for="<%=cboTables.ClientID%>">Table:</label></span>
			&nbsp;
			<asp:DropDownList ID="cboTables" Runat="server" CssClass="NormalTextBox" DataTextField = "FKTABLE_NAME" DataValueField="FKTABLE_NAME"></asp:DropDownList>
			&nbsp;
			<asp:LinkButton ID="cmdAdd" Runat="server" CssClass="CommandButton">Add</asp:LinkButton>
		</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td align="center">
			<asp:datagrid id="grdCriteria" runat="server" CssClass="Normal" DataKeyField="SearchID" Border="0" CellPadding="4" CellSpacing="4" AutoGenerateColumns="False" OnEditCommand="grdCriteria_Edit" OnDeleteCommand="grdCriteria_Delete" OnUpdateCommand="grdCriteria_Update" OnCancelCommand="grdCriteria_CancelEdit" EnableViewState="True" summary="Edit Search Design Table">
				<Columns>
					<asp:TemplateColumn ItemStyle-Wrap="False">
						<ItemTemplate>
							<asp:imagebutton id="cmdEditCriteria" runat="server" causesvalidation="false" commandname="Edit" ImageUrl="~/images/edit.gif" AlternateText="Edit"></asp:imagebutton>
							<asp:ImageButton ID="cmdDeleteCriteria" Runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/images/delete.gif" AlternateText="Delete"></asp:ImageButton>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:imagebutton id="cmdSaveCriteria" runat="server" causesvalidation="false" commandname="Update" ImageUrl="~/images/save.gif" AlternateText="Update"></asp:imagebutton>
							<asp:imagebutton id="cmdCancelCriteria" runat="server" causesvalidation="false" commandname="Cancel" ImageUrl="~/images/cancel.gif" AlternateText="Cancel"></asp:imagebutton>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn HeaderText="Table" DataField="TableName" ReadOnly="True" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
					<asp:TemplateColumn HeaderText="Title" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
						<ItemTemplate>
							<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TitleField") %>' ID="Label1"/>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:DropDownList ID="cboTitleField" Runat="server" CssClass="NormalTextBox" DataSource='<%# arrFields %>' SelectedIndex='<%# SelectField(DataBinder.Eval(Container.DataItem, "TitleField")) %>'></asp:DropDownList>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Description" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
						<ItemTemplate>
							<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DescriptionField") %>' ID="Label2"/>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:DropDownList ID="cboDescriptionField" Runat="server" CssClass="NormalTextBox" DataSource='<%# arrFields %>' SelectedIndex='<%# SelectField(DataBinder.Eval(Container.DataItem, "DescriptionField")) %>'></asp:DropDownList>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Updated" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
						<ItemTemplate>
							<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedDateField") %>' ID="Label3"/>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:DropDownList ID="cboCreatedDateField" Runat="server" CssClass="NormalTextBox" DataSource='<%# arrFields %>' SelectedIndex='<%# SelectField(DataBinder.Eval(Container.DataItem, "CreatedDateField")) %>'></asp:DropDownList>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="By" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold">
						<ItemTemplate>
							<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByUserField") %>' ID="Label4"/>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:DropDownList ID="cboCreatedByUserField" Runat="server" CssClass="NormalTextBox" DataSource='<%# arrFields %>' SelectedIndex='<%# SelectField(DataBinder.Eval(Container.DataItem, "CreatedByUserField")) %>'></asp:DropDownList>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
		</td>
	</tr>
</table>
