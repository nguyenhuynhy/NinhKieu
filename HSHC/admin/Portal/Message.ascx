<%@ Control CodeBehind="Message.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Message" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" />
<br>
<asp:Label ID="Message" Runat="server" CssClass="NormalRed"></asp:Label>