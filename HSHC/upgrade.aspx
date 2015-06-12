<%@ Page language="VB" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">

    '
    ' This page reads the web.config and then resaves it to alter the timestamp. By changing the
    ' the timestamp, it forces the Application_Start event to fire which performs the AutoUpgrade logic
    '
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	    
            Dim strWebConfig As String
            
            Dim objStreamReader As StreamReader
            objStreamReader = File.OpenText(Server.MapPath("web.config"))
            strWebConfig = objStreamReader.ReadToEnd
            objStreamReader.Close()

            Dim objStream As StreamWriter
            objStream = File.CreateText(Server.MapPath("web.config"))
            objStream.WriteLine(strWebConfig)
            objStream.Close()

            Response.Redirect("default.aspx")
        	
    End Sub

</script>
