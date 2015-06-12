Imports System
Imports System.Web.UI
Imports System.Web
Imports System.Text
Imports System.Collections
Namespace PortalQH
    Public Class MessageBox
        Private Shared m_executingPages As New Hashtable

        Private Sub MessageBox()
        End Sub
        Public Shared Sub Show(ByVal sMessage As String)

            ' If this is the first time a page has called this method then
            
            If m_executingPages.Contains(HttpContext.Current.Handler) = False Then
                ' Attempt to cast HttpHandler as a Page.
                Dim executingPage As Page = CType(HttpContext.Current.Handler, Page)
                If (Not executingPage Is Nothing) Then
                    ' Create a Queue to hold one or more messages.
                    Dim messageQueue As New Queue

                    ' Add our message to the Queue
                    messageQueue.Enqueue(sMessage)
                    ' Add our message queue to the hash table. Use our page reference
                    ' (IHttpHandler) as the key.
                    m_executingPages.Add(HttpContext.Current.Handler, messageQueue)
                    ' Wire up Unload event so that we can inject some JavaScript for the alerts.
                    'executingPage.Unload += EventHandler
                End If
            Else
                ' If were here then the method has allready been called from the executing Page.
                ' We have allready created a message queue and stored a reference to it in our hastable. 
                Dim queue As queue = CType((m_executingPages(HttpContext.Current.Handler)), queue)
                'Add our message to the Queue
                queue.Enqueue(sMessage)
            End If
        End Sub
        Private Shared Sub ExecutingPage_Unload(ByVal sender As Object, ByVal e As EventArgs)
            'Get our message queue from the hashtable
            Dim queue As queue = CType(m_executingPages(HttpContext.Current.Handler), queue)
            If (Not queue Is Nothing) Then
                Dim sb As New StringBuilder

                ' How many messages have been registered?
                Dim iMsgCount As Integer = CType(queue.Count, Integer)
                ' Use StringBuilder to build up our client slide JavaScript.
                sb.Append("<script language='javascript'>")
                ' Loop round registered messages
                Dim sMsg As String
                While (iMsgCount > 0)
                    sMsg = CType(queue.Dequeue(), String)
                    sMsg = sMsg.Replace("\n", "\\n")
                    sb.Append("alert( """ + sMsg + """ );")
                    iMsgCount -= 1
                End While

                ' Close our JS
                sb.Append("</script>")
                ' Were done, so remove our page reference from the hashtable
                m_executingPages.Remove(HttpContext.Current.Handler)
                ' Write the JavaScript to the end of the response stream.
                HttpContext.Current.Response.Write(sb.ToString())
            End If
        End Sub
    End Class
End Namespace

