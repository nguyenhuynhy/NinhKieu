<%@ Control language="vb" CodeBehind="SQL.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.SQL" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" DisplayTitle="SQL" />
<label style="display:none;" for="<%=txtQuery.ClientID%>" >SQL Query</label>
<asp:TextBox ID="txtQuery" Runat="server" TextMode="MultiLine" Columns="50" Rows="10"></asp:TextBox>
<br>
<asp:LinkButton id="cmdExecute" runat="server" CssClass="CommandButton">Execute</asp:LinkButton>
<br>
<br>
<asp:DataGrid ID="grdResults" Runat="server" AutoGenerateColumns="True" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" summary="SQL Design Table"></asp:DataGrid>
