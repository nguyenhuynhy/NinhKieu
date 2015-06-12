'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Shaun Walker ( shaunw1@shaw.ca ) of Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
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
Imports System.Runtime.Serialization.Formatters

Namespace PortalQH

    Public Class HostSettings
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtHostTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHostURL As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHostEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents ctlHostSkin As SkinControl
        Protected WithEvents ctlHostContainer As SkinControl
        Protected WithEvents ctlAdminSkin As SkinControl
        Protected WithEvents ctlAdminContainer As SkinControl
        Protected WithEvents cboProcessor As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdProcessor As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtUserId As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHostFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboHostCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHostSpace As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSiteLogBuffer As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSiteLogHistory As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDemoPeriod As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDemoSignup As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkPageTitleVersion As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtEncryptionKey As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtProxyServer As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtProxyPort As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtProxyUsername As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtProxyPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWebRequestTimeout As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSMTPServer As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSMTPUsername As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSMTPPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdEmail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
        Protected WithEvents txtFileExtensions As System.Web.UI.WebControls.TextBox
        Protected WithEvents optSkinUpload As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents txtCache As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdCache As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkUseCustomErrorMessages As System.Web.UI.WebControls.CheckBox

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton

        Protected WithEvents cboUpgrade As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpgrade As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkSessionTracking As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtUsersOnlineTime As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkUsersOnline As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblUpgrade As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '*******************************************************
        '
        ' The Page_Load server event handler on this user control is used
        ' to populate the current site settings from the config system
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' Verify that the current user has access to access this page
                If CType(Context.User.Identity.Name, String) <> _portalSettings.SuperUserId Then
                    Response.Redirect(NavigateURL("Edit Access Denied"), True)
                End If

                ' If this is the first visit to the page, populate the site data
                If Page.IsPostBack = False Then
                    BindData()
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub BindData()
            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim objCode As New CodeController

            txtHostTitle.Text = Convert.ToString(_portalSettings.HostSettings("HostTitle"))
            txtHostURL.Text = Convert.ToString(_portalSettings.HostSettings("HostURL"))
            txtHostEmail.Text = Convert.ToString(_portalSettings.HostSettings("HostEmail"))

            Dim objSkins As New SkinController
            Dim objSkin As SkinInfo

            ctlHostSkin.Width = "300px"
            ctlHostSkin.SkinRoot = SkinInfo.RootSkin
            objSkin = objSkins.GetSkin(SkinInfo.RootSkin, Null.NullInteger, Null.NullInteger, Null.NullInteger, False)
            If Not objSkin Is Nothing Then
                If Null.IsNull(objSkin.PortalId) = True And Null.IsNull(objSkin.TabId) = True Then
                    ctlHostSkin.SkinType = objSkin.SkinType
                    ctlHostSkin.SkinName = objSkin.SkinName
                    ctlHostSkin.SkinSrc = objSkin.SkinSrc
                End If
            End If
            ctlHostContainer.Width = "300px"
            ctlHostContainer.SkinRoot = SkinInfo.RootContainer
            objSkin = objSkins.GetSkin(SkinInfo.RootContainer, Null.NullInteger, Null.NullInteger, Null.NullInteger, False)
            If Not objSkin Is Nothing Then
                If Null.IsNull(objSkin.PortalId) = True And Null.IsNull(objSkin.ModuleId) = True Then
                    ctlHostContainer.SkinType = objSkin.SkinType
                    ctlHostContainer.SkinName = objSkin.SkinName
                    ctlHostContainer.SkinSrc = objSkin.SkinSrc
                End If
            End If

            ctlAdminSkin.Width = "300px"
            ctlAdminSkin.SkinRoot = SkinInfo.RootSkin
            objSkin = objSkins.GetSkin(SkinInfo.RootSkin, Null.NullInteger, Null.NullInteger, Null.NullInteger, True)
            If Not objSkin Is Nothing Then
                If Null.IsNull(objSkin.PortalId) = True And Null.IsNull(objSkin.TabId) = True Then
                    ctlAdminSkin.SkinType = objSkin.SkinType
                    ctlAdminSkin.SkinName = objSkin.SkinName
                    ctlAdminSkin.SkinSrc = objSkin.SkinSrc
                End If
            End If
            ctlAdminContainer.Width = "300px"
            ctlAdminContainer.SkinRoot = SkinInfo.RootContainer
            objSkin = objSkins.GetSkin(SkinInfo.RootContainer, Null.NullInteger, Null.NullInteger, Null.NullInteger, True)
            If Not objSkin Is Nothing Then
                If Null.IsNull(objSkin.PortalId) = True And Null.IsNull(objSkin.ModuleId) = True Then
                    ctlAdminContainer.SkinType = objSkin.SkinType
                    ctlAdminContainer.SkinName = objSkin.SkinName
                    ctlAdminContainer.SkinSrc = objSkin.SkinSrc
                End If
            End If

            cboProcessor.DataSource = objCode.GetProcessorCodes
            cboProcessor.DataBind()

            If Not cboProcessor.Items.FindByText(_portalSettings.HostSettings("PaymentProcessor").ToString) Is Nothing Then
                cboProcessor.Items.FindByText(_portalSettings.HostSettings("PaymentProcessor").ToString).Selected = True
            End If
            txtUserId.Text = Convert.ToString(_portalSettings.HostSettings("ProcessorUserId"))
            txtPassword.Text = Convert.ToString(_portalSettings.HostSettings("ProcessorPassword"))

            txtHostFee.Text = Convert.ToString(_portalSettings.HostSettings("HostFee"))
            cboHostCurrency.DataSource = objCode.GetCurrencies()
            cboHostCurrency.DataBind()
            If Not cboHostCurrency.Items.FindByValue(Convert.ToString(_portalSettings.HostSettings("HostCurrency"))) Is Nothing Then
                cboHostCurrency.Items.FindByValue(_portalSettings.HostSettings("HostCurrency").ToString).Selected = True
            Else
                cboHostCurrency.Items.FindByValue("USD").Selected = True
            End If
            txtHostSpace.Text = Convert.ToString(_portalSettings.HostSettings("HostSpace"))
            If Convert.ToString(_portalSettings.HostSettings("SiteLogBuffer")) = "" Then
                txtSiteLogBuffer.Text = "100"
            Else
                txtSiteLogBuffer.Text = Convert.ToString(_portalSettings.HostSettings("SiteLogBuffer"))
            End If
            txtSiteLogHistory.Text = Convert.ToString(_portalSettings.HostSettings("SiteLogHistory"))
            txtDemoPeriod.Text = Convert.ToString(_portalSettings.HostSettings("DemoPeriod"))
            If Convert.ToString(_portalSettings.HostSettings("DemoSignup")) = "Y" Then
                chkDemoSignup.Checked = True
            Else
                chkDemoSignup.Checked = False
            End If
            If _portalSettings.HostSettings.ContainsKey("DisablePageTitleVersion") Then
                If _portalSettings.HostSettings("DisablePageTitleVersion").ToString = "Y" Then
                    chkPageTitleVersion.Checked = True
                Else
                    chkPageTitleVersion.Checked = False
                End If
            Else
                chkPageTitleVersion.Enabled = False
            End If
            If _portalSettings.HostSettings.ContainsKey("DisableUsersOnline") Then
                If _portalSettings.HostSettings("DisableUsersOnline").ToString = "Y" Then
                    chkUsersOnline.Checked = True
                Else
                    chkUsersOnline.Checked = False
                End If
            Else
                chkUsersOnline.Checked = False
            End If
            txtUsersOnlineTime.Text = Convert.ToString(_portalSettings.HostSettings("UsersOnlineTime"))
            txtEncryptionKey.Text = Convert.ToString(_portalSettings.HostSettings("EncryptionKey"))
            txtProxyServer.Text = Convert.ToString(_portalSettings.HostSettings("ProxyServer"))
            txtProxyPort.Text = Convert.ToString(_portalSettings.HostSettings("ProxyPort"))
            txtProxyUsername.Text = Convert.ToString(_portalSettings.HostSettings("ProxyUsername"))
            txtProxyPassword.Text = Convert.ToString(_portalSettings.HostSettings("ProxyPassword"))
            txtSMTPServer.Text = Convert.ToString(_portalSettings.HostSettings("SMTPServer"))
            txtSMTPUsername.Text = Convert.ToString(_portalSettings.HostSettings("SMTPUsername"))
            txtSMTPPassword.Text = Convert.ToString(_portalSettings.HostSettings("SMTPPassword"))
            txtFileExtensions.Text = Convert.ToString(_portalSettings.HostSettings("FileExtensions"))
            If Convert.ToString(_portalSettings.HostSettings("CacheTimeout")) = "" Then
                txtCache.Text = "60"
            Else
                txtCache.Text = Convert.ToString(_portalSettings.HostSettings("CacheTimeout"))
            End If

            If _portalSettings.HostSettings.ContainsKey("UseCustomErrorMessages") Then
                If _portalSettings.HostSettings("UseCustomErrorMessages").ToString = "Y" Then
                    chkUseCustomErrorMessages.Checked = True
                Else
                    chkUseCustomErrorMessages.Checked = False
                End If
            Else
                chkUseCustomErrorMessages.Checked = False
            End If

            If Convert.ToString(_portalSettings.HostSettings("SkinUpload")) <> "" Then
                optSkinUpload.Items.FindByValue(_portalSettings.HostSettings("SkinUpload").ToString).Selected = True
            Else
                optSkinUpload.Items.FindByValue("G").Selected = True
            End If

            ' Get the name of the data provider
            'Dim objProviderConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration("data")

            '' get list of script files
            'Dim strProviderPath As String = PortalSettings.GetProviderPath()
            'Dim arrScriptFiles As New ArrayList
            'Dim strFile As String
            'Dim arrFiles As String() = Directory.GetFiles(strProviderPath, "*." & objProviderConfiguration.DefaultProvider)
            'For Each strFile In arrFiles
            '    arrScriptFiles.Add(Path.GetFileNameWithoutExtension(strFile))
            'Next
            'arrScriptFiles.Sort()

            'cboUpgrade.DataSource = arrScriptFiles
            'cboUpgrade.DataBind()

        End Sub

        Private Sub Update_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim objAdmin As New AdminDB

                objAdmin.UpdateHostSetting("HostTitle", txtHostTitle.Text)
                objAdmin.UpdateHostSetting("HostURL", txtHostURL.Text)
                objAdmin.UpdateHostSetting("HostEmail", txtHostEmail.Text)
                objAdmin.UpdateHostSetting("PaymentProcessor", cboProcessor.SelectedItem.Text)
                objAdmin.UpdateHostSetting("ProcessorUserId", txtUserId.Text)
                objAdmin.UpdateHostSetting("ProcessorPassword", txtPassword.Text)
                objAdmin.UpdateHostSetting("HostFee", txtHostFee.Text)
                objAdmin.UpdateHostSetting("HostCurrency", cboHostCurrency.SelectedItem.Value)
                objAdmin.UpdateHostSetting("HostSpace", txtHostSpace.Text)
                objAdmin.UpdateHostSetting("SiteLogBuffer", txtSiteLogBuffer.Text)
                objAdmin.UpdateHostSetting("SiteLogHistory", txtSiteLogHistory.Text)
                objAdmin.UpdateHostSetting("DemoPeriod", txtDemoPeriod.Text)
                objAdmin.UpdateHostSetting("DemoSignup", Convert.ToString(IIf(chkDemoSignup.Checked, "Y", "N")))
                objAdmin.UpdateHostSetting("DisablePageTitleVersion", Convert.ToString(IIf(chkPageTitleVersion.Checked, "Y", "N")))
                objAdmin.UpdateHostSetting("DisableUsersOnline", Convert.ToString(IIf(chkUsersOnline.Checked, "Y", "N")))
                objAdmin.UpdateHostSetting("UsersOnlineTime", txtUsersOnlineTime.Text)
                objAdmin.UpdateHostSetting("ProxyServer", txtProxyServer.Text)
                objAdmin.UpdateHostSetting("ProxyPort", txtProxyPort.Text)
                objAdmin.UpdateHostSetting("ProxyUsername", txtProxyUsername.Text)
                objAdmin.UpdateHostSetting("ProxyPassword", txtProxyPassword.Text)
                objAdmin.UpdateHostSetting("SMTPServer", txtSMTPServer.Text)
                objAdmin.UpdateHostSetting("SMTPUsername", txtSMTPUsername.Text)
                objAdmin.UpdateHostSetting("SMTPPassword", txtSMTPPassword.Text)
                objAdmin.UpdateHostSetting("FileExtensions", txtFileExtensions.Text)
                objAdmin.UpdateHostSetting("SkinUpload", optSkinUpload.SelectedItem.Value)
                objAdmin.UpdateHostSetting("CacheTimeout", txtCache.Text)
                objAdmin.UpdateHostSetting("UseCustomErrorMessages", Convert.ToString(IIf(chkUseCustomErrorMessages.Checked, "Y", "N")))

                Dim objSkins As New SkinController
                objSkins.SetSkin(SkinInfo.RootSkin, Null.NullInteger, Null.NullInteger, Null.NullInteger, False, ctlHostSkin.SkinType, ctlHostSkin.SkinName, ctlHostSkin.SkinSrc)
                objSkins.SetSkin(SkinInfo.RootContainer, Null.NullInteger, Null.NullInteger, Null.NullInteger, False, ctlHostContainer.SkinType, ctlHostContainer.SkinName, ctlHostContainer.SkinSrc)
                objSkins.SetSkin(SkinInfo.RootSkin, Null.NullInteger, Null.NullInteger, Null.NullInteger, True, ctlAdminSkin.SkinType, ctlAdminSkin.SkinName, ctlAdminSkin.SkinSrc)
                objSkins.SetSkin(SkinInfo.RootContainer, Null.NullInteger, Null.NullInteger, Null.NullInteger, True, ctlAdminContainer.SkinType, ctlAdminContainer.SkinName, ctlAdminContainer.SkinSrc)

                ' re-encrypt user passwords if EncryptionKey has changed
                If txtEncryptionKey.Text <> _portalSettings.HostSettings("EncryptionKey").ToString Then
                    Dim strBody As String

                    Dim objSecurity As New PortalSecurity
                    Dim objUsers As New UserController
                    Dim strPassword As String
                    Dim Arr As ArrayList
                    Arr = objUsers.GetUsers()
                    Dim i As Integer
                    For i = 0 To Arr.Count - 1
                        Dim objUser As UserInfo = CType(Arr(i), UserInfo)
                        strPassword = objUser.Password
                        strPassword = objSecurity.Decrypt(_portalSettings.HostSettings("EncryptionKey").ToString, strPassword)
                        If strPassword = "" Then ' decryption error - reset password
                            strPassword = (objUser.FullName).ToLower
                            strBody = "Dear " & objUser.FullName & "," & vbCrLf & vbCrLf
                            strBody = strBody & "Due to a website encryption problem your password has been reset." & vbCrLf & vbCrLf
                            strBody = strBody & "Please login using the following information:" & vbCrLf & vbCrLf
                            strBody = strBody & "Portal Website Address: " & GetPortalDomainName(PortalAlias, Request) & vbCrLf
                            strBody = strBody & "Username: " & objUser.Name & vbCrLf
                            strBody = strBody & "Password: " & strPassword & vbCrLf
                            strBody = strBody & vbCrLf & "We apologize for the inconvenience." & vbCrLf
                            strBody = strBody & vbCrLf & "Sincerely," & vbCrLf
                            strBody = strBody & "Portal Administrator" & vbCrLf & vbCrLf
                            SendNotification(_portalSettings.Email, objUser.Email, "", _portalSettings.PortalName & " Password Reset", strBody)
                        End If
                        strPassword = objSecurity.Encrypt(txtEncryptionKey.Text, strPassword)
                        objUsers.UpdateUser(-1, objUser.UserID, objUser.FullName, objUser.Unit, objUser.Street, objUser.City, objUser.Region, objUser.PostalCode, objUser.Country, objUser.Telephone, objUser.Email, objUser.Name, strPassword, objUser.Authorized, "", "")
                    Next

                    ' set the encryption key
                    objAdmin.UpdateHostSetting("Encryptionkey", txtEncryptionKey.Text)
                End If

                ' clear host settings cache
                DataCache.ClearCoreCache(CoreCacheType.Host)

                ' Redirect to this site to refresh host settings
                Response.Redirect(Request.RawUrl, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdProcessor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdProcessor.Click
            Try
                Response.Redirect(AddHTTP(cboProcessor.SelectedItem.Value), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpgrade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpgrade.Click
            Try
                ' get path to provider
                Dim strProviderPath As String = PortalSettings.GetProviderPath()

                If File.Exists(strProviderPath & cboUpgrade.SelectedItem.Text & ".log") Then
                    Dim objStreamReader As StreamReader
                    objStreamReader = File.OpenText(strProviderPath & cboUpgrade.SelectedItem.Text & ".log")
                    lblUpgrade.Text = Replace(objStreamReader.ReadToEnd, ControlChars.Lf, "<br>")
                    objStreamReader.Close()
                Else
                    lblUpgrade.Text = "Database script was not executed for specified version."
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEmail.Click
            Try
                If txtHostEmail.Text <> "" Then

                    Dim strMessage As String = SendNotification(txtHostEmail.Text, txtHostEmail.Text, "", txtHostTitle.Text & " Email Configuration Test", "", "", "", Convert.ToString(IIf(txtSMTPServer.Text <> "", txtSMTPServer.Text, "")))
                    If strMessage <> "" Then
                        lblEmail.Text = "<br>" & strMessage
                    Else
                        lblEmail.Text = "<br>" & "Email Sent Successfully"
                    End If
                Else
                    lblEmail.Text = "<br>You Must Specify The Host Email Address"
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCache_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCache.Click

            ' clear entire cache
            DataCache.ClearCoreCache(CoreCacheType.Host, , True)
            'clear stored params cache
            DataCache.ClearCacheParameterSet("", "")

            Response.Redirect(Request.RawUrl, True)

        End Sub

    End Class

End Namespace

