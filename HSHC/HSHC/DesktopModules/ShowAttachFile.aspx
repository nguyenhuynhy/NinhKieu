<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ShowAttachFile.aspx.vb" Inherits="HSHC.ShowAttachFile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ShowFileDetails</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<script language=javascript src='<%= Request.ApplicationPath + "/INC/Common.js"%>'></script>
		<script language=javascript src='<%= Request.ApplicationPath + "/INC/dtree.js"%>'></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="frmFileDetails" method="post" runat="server">
			<P><asp:label id="Label1" runat="server" CssClass="eDMS_Banner" Width="100%">.:: DANH SÁCH FILE TOÀN VĂN ::.</asp:label></P>
			<asp:datagrid id="dgdUpload" runat="server" Width="100%" AutoGenerateColumns="False" BorderStyle="Solid"
				CssClass="eDMS_TableContent" BorderColor="#D3E0FA">
				<HeaderStyle CssClass="eDMS_TableHeader" ForeColor="#00008B"></HeaderStyle>
				<AlternatingItemStyle CssClass="eDMS_TableAlternate"></AlternatingItemStyle>
				<Columns>
					<asp:BoundColumn visible="False" DataField="AttachFileID" HeaderText="ItemID"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="STT">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" width="5%"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblSTT" Enabled="True" runat="server" Text='<%# dgdUpload.CurrentPageIndex*dgdUpload.PageSize + dgdUpload.Items.Count+1  %>' />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="FileName" HeaderText="Tên tập tin">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>					
					<asp:TemplateColumn HeaderText="File đính kèm">
					<HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
					<ItemStyle HorizontalAlign="Center" width="15%"></ItemStyle>
					<ItemTemplate>
						<asp:HyperLink ImageURL="../../images/clip.gif" NavigateUrl=<%# "javascript:ShowAttachedFile('" & Request.ApplicationPath & DataBinder.Eval(Container.DataItem, "FilePath") & "','" & DataBinder.Eval(Container.DataItem, "FileName") & "')" %>  id="HyperLink1" runat="server">Xem file toàn van</asp:HyperLink>
					</ItemTemplate>
				</asp:TemplateColumn>
				</Columns>
				<PagerStyle BorderWidth="0px" HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<asp:TextBox ID="txtHoSoTiepNhaID" Runat="server" Visible="False"></asp:TextBox>
			<p align="center"><input type="button" onclick="window.close()" value=" Ðóng " class="eDMS_button"></p>
		</form>
	</body>
</HTML>
