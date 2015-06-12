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

Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Collections.Specialized
Imports Microsoft.ApplicationBlocks.ExceptionManagement

Imports PortalQH
'Imports System.Data.SqlClient


Namespace PortalQH



    Public Class EmailExceptionPublisher
        Implements IExceptionPublisher

        Private m_AdminEmail As String = ""
        Private m_SMTPServer As String = ""

        Sub Publish(ByVal exception As Exception, ByVal additionalInfo As NameValueCollection, ByVal configSettings As NameValueCollection) Implements IExceptionPublisher.Publish


            Dim m_TopLevelExceptionMessage As String = exception.Message
            Dim m_TopLevelExceptionType As String = exception.GetType().ToString

            If Not configSettings("SMTPServer") Is Nothing AndAlso configSettings("SMTPServer").Length > 0 Then
                m_SMTPServer = configSettings("SMTPServer")
            End If
            If Not configSettings("AdminEmail") Is Nothing AndAlso configSettings("AdminEmail").Length > 0 Then
                m_AdminEmail = configSettings("AdminEmail")
            End If


            Dim TEXT_SEPARATOR As String = "*********************************************"


            Dim strInfo As New StringBuilder
            Dim i As String
            Dim currentException As exception
            Dim intExceptionCount As Integer = 1 ' Count variable to track the number of exceptions in the chain.
            Dim aryPublicProperties As PropertyInfo()
            Dim currentAdditionalInfo As NameValueCollection
            Dim p As PropertyInfo
            Dim j As Integer
            Dim k As Integer
            Dim myBasePortalException As BasePortalException

            If TypeOf exception Is BasePortalException Then
                myBasePortalException = CType(exception, BasePortalException)
            Else
                myBasePortalException = New BasePortalException("Unhandled Portal Exception", exception)
                exception = myBasePortalException
            End If


            ' Record the contents of the AdditionalInfo collection.
            If Not (additionalInfo Is Nothing) Then

                ' Record General information.
                strInfo.AppendFormat("{0}General Information {0}{1}{0}Additional Info:", Environment.NewLine, TEXT_SEPARATOR)

                For Each i In additionalInfo
                    strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, i, additionalInfo.Get(i))
                Next i
            End If

            If exception Is Nothing Then
                strInfo.AppendFormat("{0}{0}No Exception object has been provided..{0}", Environment.NewLine)
            Else
                ' Loop through each exception class in the chain of exception objects.
                ' Temp variable to hold InnerException object during the loop.
                currentException = exception '

                Do
                    ' Write title information for the exception object.
                    strInfo.AppendFormat("{0}{0}{1}) Exception Information{0}{2}", Environment.NewLine, intExceptionCount.ToString(), TEXT_SEPARATOR)
                    strInfo.AppendFormat("{0}Exception Type: {1}", Environment.NewLine, currentException.GetType().FullName)

                    ' Loop through the public properties of the exception object and record their value.
                    aryPublicProperties = currentException.GetType().GetProperties()  '

                    For Each p In aryPublicProperties
                        ' Do not log information for the InnerException or StackTrace. This information is 
                        ' captured later in the process.
                        If p.Name <> "InnerException" And p.Name <> "StackTrace" Then
                            If p.GetValue(currentException, Nothing) Is Nothing Then
                                strInfo.AppendFormat("{0}{1}: NULL", Environment.NewLine, p.Name)
                            Else
                                ' Loop through the collection of AdditionalInformation if the exception type is a BaseApplicationException.
                                If p.Name = "AdditionalInformation" And TypeOf currentException Is BaseApplicationException Then
                                    ' Verify the collection is not null.
                                    If Not (p.GetValue(currentException, Nothing) Is Nothing) Then
                                        ' Cast the collection into a local variable.
                                        currentAdditionalInfo = CType(p.GetValue(currentException, Nothing), NameValueCollection)

                                        ' Check if the collection contains values.
                                        If currentAdditionalInfo.Count > 0 Then
                                            strInfo.AppendFormat("{0}AdditionalInformation:", Environment.NewLine)

                                            ' Loop through the collection adding the information to the string builder.
                                            k = currentAdditionalInfo.Count - 1
                                            For j = 0 To k
                                                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, currentAdditionalInfo.GetKey(j), currentAdditionalInfo(j))
                                            Next
                                        End If
                                    End If
                                    ' Otherwise just write the ToString() value of the property.
                                Else
                                    strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, p.Name, p.GetValue(currentException, Nothing))
                                End If
                            End If
                        End If
                    Next p

                    ' Record the StackTrace with separate label.
                    If Not (currentException.StackTrace Is Nothing) Then '
                        strInfo.AppendFormat("{0}{0}StackTrace Information{0}{1}", Environment.NewLine, TEXT_SEPARATOR)
                        strInfo.AppendFormat("{0}{1}", Environment.NewLine, currentException.StackTrace)
                    End If

                    ' Reset the temp exception object and iterate the counter.
                    currentException = currentException.InnerException
                    intExceptionCount += 1
                Loop While Not (currentException Is Nothing)
            End If '

            Dim body As String = strInfo.ToString()

            'Using the Email Publisher we first see if email is active for the portal
            'If an error is thrown we attempt to send to the address in the config fill
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
                'If Host Settings exist and set to "Y" proceed to send email
                If _portalSettings.HostSettings.ContainsKey("EnableErrorReporting") AndAlso _portalSettings.HostSettings("EnableErrorReporting").ToString = "Y" Then
                    'If Host Mail address isn't blank or "support@PortalQH" by default
                    Dim HostEmail As String = _portalSettings.HostSettings("HostEmail").ToString
                    If HostEmail <> "support@PortalQH.com" AndAlso HostEmail <> "" Then
                        'Create a string with error details and mail it to the specified user

                        Dim Msg As String = strInfo.ToString()
                        SendNotification(HostEmail, HostEmail, "", "Portal Error: " & exception.GetType.ToString, body)
                    End If
                End If
            Catch
                ' send notification email if operatorMail attribute was provided
                If m_AdminEmail.Length > 0 Then
                    SendNotification(m_AdminEmail, m_AdminEmail, "", "DNN Automatic Error Report", body)
                End If
            End Try

        End Sub 'Publish 
    End Class

End Namespace

