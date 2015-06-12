<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Codebehind="ModuleDefValidator.ascx.vb" Inherits="PortalQH.ModuleDefValidator"%>
<br>
<div align="center">
	<div>
		<div class="Normal">Please select a *.dnn file from your local system for 
			validation.</div>
		<div class="Normal"><b>NOTE:</b>&nbsp;&nbsp;Beta 2 release only validates Version 
			2.0 .dnn files</div>
		<br>
		<label style="DISPLAY: none" for="<%=cmdBrowse.ClientID%>">Browse Files</label>
		<INPUT id="cmdBrowse" type="file" size="50" name="cmdBrowse" runat="server">&nbsp;&nbsp;
		<asp:linkbutton id="lnkValidate" runat="server" CssClass="CommandButton">Validate</asp:linkbutton>
	</div>
	<BR>
	<asp:datalist id="lstResults" runat="server" Width="100%" Visible="False" BorderWidth="0" CellSpacing="0"
		CellPadding="4">
		<HeaderTemplate>
			<span class="NormalBold">Validation Results</span>
		</HeaderTemplate>
		<ItemTemplate>
			<span class="Normal">
				<%# Container.DataItem %>
			</span>
		</ItemTemplate>
	</asp:datalist>
</div>
