'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Shaun Walker ( sales@perpetualmotion.ca ) of Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System.IO
Imports System.Xml
Imports System.Collections.Specialized
Imports Microsoft.ApplicationBlocks.ExceptionManagement

Namespace PortalQH
    Public Class XMLExceptionPublisher
        Implements IExceptionXmlPublisher

        Public Sub Publish(ByVal ExceptionInfo As XmlDocument, ByVal ConfigSettings As NameValueCollection) Implements IExceptionXmlPublisher.Publish
            Try
                PublishXML(ExceptionInfo, ConfigSettings)
            Catch
                'this prevents the exception from bubbling
                'up to the exception block
            End Try
        End Sub
        Private Sub PublishXML(ByVal ExceptionInfo As XmlDocument, ByVal ConfigSettings As NameValueCollection)
            Dim fs As FileStream
            Dim sw As StreamWriter
            Try
                Dim filename As String

                If Not ConfigSettings Is Nothing Then
                    'get config settings from web.config
                    filename = ConfigSettings("fileName")

                    'check to see if they entered a filename or an absolute file path
                    If filename.LastIndexOf("\") = -1 And filename.LastIndexOf("/") = -1 Then
                        'Config settings specified a filename only, with no absolute path
                        'Use the /Portals/_default/Logs directory to store the log file
                        'This allows user to specify alternative location for
                        'log files to be stored, othre than the DNN directory.
                        filename = HttpContext.Current.Server.MapPath(Global.HostPath + "Logs/" + filename)
                    End If

                End If


                ' Write the entry to the event log.   
                fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read)
                If fs Is Nothing Then
                    HttpContext.Current.Response.Write("An error has occurred writing to the exception log.")
                    HttpContext.Current.Response.End()
                Else
                    'Instantiate a new StreamWriter
                    sw = New StreamWriter(fs)

                    'check to see if this file is new
                    If fs.Length > 0 Then
                        'file is not new, set the
                        'position to just before
                        'the closing root element tag
                        fs.Position = fs.Length - 15
                    Else
                        'file is new, create the opening
                        'root element tag
                        sw.WriteLine("<exceptions>")
                    End If
                    'write out our exception
                    sw.WriteLine(ExceptionInfo.OuterXml)

                    'write out the closing root element tag
                    sw.WriteLine("</exceptions>")
                End If
                'handle the more common exceptions up 
                'front, leave less common ones to the end
            Catch exc As UnauthorizedAccessException
                HttpContext.Current.Response.Write("<font color=""red"">An error has occurred writing to the exception log.  The permissions are not set properly on the log file or directory, or the log file has been marked as READ-ONLY.</font><hr size=""1"" noshade>")
                HttpContext.Current.Response.End()
            Catch exc As DirectoryNotFoundException
                HttpContext.Current.Response.Write("<font color=""red"">An error has occurred writing to the exception log.  The directory was not found.</font><hr size=""1"" noshade>")
                HttpContext.Current.Response.End()
            Catch exc As PathTooLongException
                HttpContext.Current.Response.Write("<font color=""red"">An error has occurred writing to the exception log.  The filename path is too long.</font><hr size=""1"" noshade>")
                HttpContext.Current.Response.End()
            Catch exc As IOException
                HttpContext.Current.Response.Write("<font color=""red"">An IO Error has occurred writing to the exception log.</font><hr size=""1"" noshade>")
                HttpContext.Current.Response.End()
            Catch exc As Exception
                HttpContext.Current.Response.Write("<font color=""red"">An unhandled error has occurred writing to the exception log.</font><hr size=""1"" noshade>")
                HttpContext.Current.Response.End()
            Finally
                If Not sw Is Nothing Then
                    sw.Close()
                End If
                If Not fs Is Nothing Then
                    fs.Close()
                End If
            End Try
        End Sub
    End Class
End Namespace

