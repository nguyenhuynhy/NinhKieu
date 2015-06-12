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

Namespace PortalQH

    Public Class Address
        Inherits System.Web.UI.UserControl

        Protected WithEvents rowCountry As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblCountry As System.Web.UI.WebControls.Label
        Protected WithEvents cboCountry As PortalQH.Web.UI.WebControls.CountryListBox
        Protected WithEvents chkCountry As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblCountryRequired As System.Web.UI.WebControls.Label
        Protected WithEvents valCountry As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rowRegion As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblRegion As System.Web.UI.WebControls.Label
        Protected WithEvents cboRegion As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtRegion As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkRegion As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblRegionRequired As System.Web.UI.WebControls.Label
        Protected WithEvents valRegion1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valRegion2 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rowCity As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblCity As System.Web.UI.WebControls.Label
        Protected WithEvents txtCity As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkCity As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblCityRequired As System.Web.UI.WebControls.Label
        Protected WithEvents valCity As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rowStreet As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblStreet As System.Web.UI.WebControls.Label
        Protected WithEvents txtStreet As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkStreet As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblStreetRequired As System.Web.UI.WebControls.Label
        Protected WithEvents valStreet As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rowUnit As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblUnit As System.Web.UI.WebControls.Label
        Protected WithEvents txtUnit As System.Web.UI.WebControls.TextBox
        Protected WithEvents rowPostal As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblPostal As System.Web.UI.WebControls.Label
        Protected WithEvents txtPostal As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkPostal As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblPostalRequired As System.Web.UI.WebControls.Label
        Protected WithEvents valPostal As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rowTelephone As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblTelephone As System.Web.UI.WebControls.Label
        Protected WithEvents txtTelephone As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkTelephone As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblTelephoneRequired As System.Web.UI.WebControls.Label
        Protected WithEvents valTelephone As System.Web.UI.WebControls.RequiredFieldValidator

        Private _ModuleId As Integer
        Private _LabelColumnWidth As String = ""
        Private _ControlColumnWidth As String = ""
        Private _StartTabIndex As Integer = 1

        Private _Unit As String
        Private _Street As String
        Private _City As String
        Private _Region As String
        Private _Country As String
        Private _Postal As String
        Private _Telephone As String

        Private _ShowUnit As Boolean = True
        Private _ShowStreet As Boolean = True
        Private _ShowCity As Boolean = True
        Private _ShowRegion As Boolean = True
        Private _ShowCountry As Boolean = True
        Private _ShowPostal As Boolean = True
        Private _ShowTelephone As Boolean = True

        Private _CountryData As String = "Text"
        Private _RegionData As String = "Text"

        ' public properties
        Public Property ModuleId() As Integer
            Get
                ModuleId = Convert.ToInt32(ViewState("ModuleId"))
            End Get
            Set(ByVal Value As Integer)
                _ModuleId = Value
            End Set
        End Property

        Public Property LabelColumnWidth() As String
            Get
                LabelColumnWidth = Convert.ToString(ViewState("LabelColumnWidth"))
            End Get
            Set(ByVal Value As String)
                _LabelColumnWidth = Value
            End Set
        End Property

        Public Property ControlColumnWidth() As String
            Get
                ControlColumnWidth = Convert.ToString(ViewState("ControlColumnWidth"))
            End Get
            Set(ByVal Value As String)
                _ControlColumnWidth = Value
            End Set
        End Property

        Public WriteOnly Property StartTabIndex() As Integer
            Set(ByVal Value As Integer)
                _StartTabIndex = Value
            End Set
        End Property

        Public Property Telephone() As String
            Get
                Telephone = txtTelephone.Text
            End Get
            Set(ByVal Value As String)
                _Telephone = Value
            End Set
        End Property

        Public Property Unit() As String
            Get
                Unit = txtUnit.Text
            End Get
            Set(ByVal Value As String)
                _Unit = Value
            End Set
        End Property

        Public Property Street() As String
            Get
                Street = txtStreet.Text
            End Get
            Set(ByVal Value As String)
                _Street = Value
            End Set
        End Property

        Public Property City() As String
            Get
                City = txtCity.Text
            End Get
            Set(ByVal Value As String)
                _City = Value
            End Set
        End Property

        Public Property Region() As String
            Get
                If cboRegion.Visible Then
                    If Not cboRegion.SelectedItem Is Nothing Then
                        Select Case LCase(_RegionData)
                            Case "text"
                                Region = cboRegion.SelectedItem.Text
                            Case "value"
                                Region = cboRegion.SelectedItem.Value
                        End Select
                    Else
                        Region = ""
                    End If
                Else
                    Region = txtRegion.Text
                End If
            End Get
            Set(ByVal Value As String)
                _Region = Value
            End Set
        End Property

        Public Property Country() As String
            Get
                If Not cboCountry.SelectedItem Is Nothing Then
                    Select Case LCase(_CountryData)
                        Case "text"
                            Country = cboCountry.SelectedItem.Text
                        Case "value"
                            Country = cboCountry.SelectedItem.Value
                    End Select
                Else
                    Country = ""
                End If
            End Get
            Set(ByVal Value As String)
                _Country = Value
            End Set
        End Property

        Public Property Postal() As String
            Get
                Postal = txtPostal.Text
            End Get
            Set(ByVal Value As String)
                _Postal = Value
            End Set
        End Property

        Public WriteOnly Property ShowTelephone() As Boolean
            Set(ByVal Value As Boolean)
                _ShowTelephone = Value
            End Set
        End Property

        Public WriteOnly Property ShowUnit() As Boolean
            Set(ByVal Value As Boolean)
                _ShowUnit = Value
            End Set
        End Property

        Public WriteOnly Property ShowStreet() As Boolean
            Set(ByVal Value As Boolean)
                _ShowStreet = Value
            End Set
        End Property

        Public WriteOnly Property ShowCity() As Boolean
            Set(ByVal Value As Boolean)
                _ShowCity = Value
            End Set
        End Property

        Public WriteOnly Property ShowRegion() As Boolean
            Set(ByVal Value As Boolean)
                _ShowRegion = Value
            End Set
        End Property

        Public WriteOnly Property ShowCountry() As Boolean
            Set(ByVal Value As Boolean)
                _ShowCountry = Value
            End Set
        End Property

        Public WriteOnly Property ShowPostal() As Boolean
            Set(ByVal Value As Boolean)
                _ShowPostal = Value
            End Set
        End Property

        Public WriteOnly Property CountryData() As String
            Set(ByVal Value As String)
                _CountryData = Value
            End Set
        End Property

        Public WriteOnly Property RegionData() As String
            Set(ByVal Value As String)
                _RegionData = Value
            End Set
        End Property

#Region " Web Form Designer Generated Code "


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
        ' The Page_Load server event handler on this page is used
        ' to populate the role information for the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If Not Page.IsPostBack Then

                    If _LabelColumnWidth <> "" Then
                        lblCountry.Width = System.Web.UI.WebControls.Unit.Parse(_LabelColumnWidth)
                        lblRegion.Width = System.Web.UI.WebControls.Unit.Parse(_LabelColumnWidth)
                        lblCity.Width = System.Web.UI.WebControls.Unit.Parse(_LabelColumnWidth)
                        lblStreet.Width = System.Web.UI.WebControls.Unit.Parse(_LabelColumnWidth)
                        lblUnit.Width = System.Web.UI.WebControls.Unit.Parse(_LabelColumnWidth)
                        lblPostal.Width = System.Web.UI.WebControls.Unit.Parse(_LabelColumnWidth)
                        lblTelephone.Width = System.Web.UI.WebControls.Unit.Parse(_LabelColumnWidth)
                    End If

                    If _ControlColumnWidth <> "" Then
                        cboCountry.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                        cboRegion.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                        txtRegion.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                        txtCity.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                        txtStreet.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                        txtUnit.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                        txtPostal.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                        txtTelephone.Width = System.Web.UI.WebControls.Unit.Parse(_ControlColumnWidth)
                    End If

                    cboCountry.TabIndex = Convert.ToInt16(_StartTabIndex + 3)
                    cboRegion.TabIndex = Convert.ToInt16(_StartTabIndex + 4)
                    txtRegion.TabIndex = Convert.ToInt16(_StartTabIndex + 5)
                    txtCity.TabIndex = Convert.ToInt16(_StartTabIndex + 2)
                    txtStreet.TabIndex = Convert.ToInt16(_StartTabIndex)
                    txtUnit.TabIndex = Convert.ToInt16(_StartTabIndex + 1)
                    txtPostal.TabIndex = Convert.ToInt16(_StartTabIndex + 6)
                    txtTelephone.TabIndex = Convert.ToInt16(_StartTabIndex + 7)

                    Dim objRegionalController As New RegionalController

                    cboCountry.DataSource = objRegionalController.GetCountries
                    cboCountry.DataBind()
                    cboCountry.Items.Insert(0, New ListItem("<Not Specified>", ""))

                    Select Case LCase(_CountryData)
                        Case "text"
                            If Not cboCountry.Items.FindByText(_Country) Is Nothing Then
                                cboCountry.ClearSelection()
                                cboCountry.Items.FindByText(_Country).Selected = True
                            End If
                        Case "value"
                            If Not cboCountry.Items.FindByValue(_Country) Is Nothing Then
                                cboCountry.ClearSelection()
                                cboCountry.Items.FindByValue(_Country).Selected = True
                            End If
                    End Select

                    Localize()

                    If cboRegion.Visible Then
                        Select Case LCase(_RegionData)
                            Case "text"
                                If Not cboRegion.Items.FindByText(_Region) Is Nothing Then
                                    cboRegion.Items.FindByText(_Region).Selected = True
                                End If
                            Case "value"
                                If Not cboRegion.Items.FindByValue(_Region) Is Nothing Then
                                    cboRegion.Items.FindByValue(_Region).Selected = True
                                End If
                        End Select
                    Else
                        txtRegion.Text = _Region
                    End If

                    txtCity.Text = _City
                    txtStreet.Text = _Street
                    txtUnit.Text = _Unit
                    txtPostal.Text = _Postal
                    txtTelephone.Text = _Telephone

                    rowUnit.Visible = _ShowUnit
                    rowStreet.Visible = _ShowStreet
                    rowCity.Visible = _ShowCity
                    rowRegion.Visible = _ShowRegion
                    rowCountry.Visible = _ShowCountry
                    rowPostal.Visible = _ShowPostal
                    rowTelephone.Visible = _ShowTelephone

                    If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) Then
                        chkCountry.Visible = True
                        chkRegion.Visible = True
                        chkCity.Visible = True
                        chkStreet.Visible = True
                        chkPostal.Visible = True
                        chkTelephone.Visible = True
                    End If

                    ViewState("ModuleId") = Convert.ToString(_ModuleId)
                    ViewState("LabelColumnWidth") = _LabelColumnWidth
                    ViewState("ControlColumnWidth") = _ControlColumnWidth

                    ShowRequiredFields()

                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cboCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCountry.SelectedIndexChanged
            Try
                Localize()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub Localize()
            Dim objRegionalController As New RegionalController

            Select Case LCase(cboCountry.SelectedItem.Value)
                Case "us"
                    cboRegion.ClearSelection()
                    cboRegion.Visible = True
                    txtRegion.Visible = False
                    cboRegion.DataSource = objRegionalController.GetRegionsByCountry(cboCountry.SelectedItem.Value)
                    cboRegion.DataBind()
                    cboRegion.Items.Insert(0, New ListItem("<Not Specified>", ""))
                    valRegion1.Enabled = True
                    valRegion2.Enabled = False
                    lblRegion.Text = "State:"
                    lblPostal.Text = "Zip Code:"
                Case "ca"
                    cboRegion.ClearSelection()
                    cboRegion.Visible = True
                    txtRegion.Visible = False
                    cboRegion.DataSource = objRegionalController.GetRegionsByCountry(cboCountry.SelectedItem.Value)
                    cboRegion.DataBind()
                    cboRegion.Items.Insert(0, New ListItem("<Not Specified>", ""))
                    valRegion1.Enabled = True
                    valRegion2.Enabled = False
                    lblRegion.Text = "Province:"
                    lblPostal.Text = "Postal Code:"
                Case Else
                    cboRegion.ClearSelection()
                    cboRegion.Visible = False
                    txtRegion.Visible = True
                    valRegion1.Enabled = False
                    valRegion2.Enabled = True
                    lblRegion.Text = "Region:"
                    lblPostal.Text = "Postal Code:"
            End Select

            If lblRegionRequired.Text = "" Then
                valRegion1.Enabled = False
                valRegion2.Enabled = False
            End If

        End Sub

        Private Sub ShowRequiredFields()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim settings As Hashtable = _portalSettings.GetModuleSettings(ModuleId)

            lblCountryRequired.Text = IIf(CType(settings("addresscountry"), String) = "N", "", "*").ToString
            lblRegionRequired.Text = IIf(CType(settings("addressregion"), String) = "N", "", "*").ToString
            lblCityRequired.Text = IIf(CType(settings("addresscity"), String) = "N", "", "*").ToString
            lblStreetRequired.Text = IIf(CType(settings("addressstreet"), String) = "N", "", "*").ToString
            lblPostalRequired.Text = IIf(CType(settings("addresspostal"), String) = "N", "", "*").ToString
            lblTelephoneRequired.Text = IIf(CType(settings("addresstelephone"), String) = "N", "", "*").ToString

            If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) Then
                If lblCountryRequired.Text = "*" Then
                    chkCountry.Checked = True
                    valCountry.Enabled = True
                End If
                If lblRegionRequired.Text = "*" Then
                    chkRegion.Checked = True
                    If cboRegion.Visible = True Then
                        valRegion1.Enabled = True
                        valRegion2.Enabled = False
                    Else
                        valRegion1.Enabled = False
                        valRegion2.Enabled = True
                    End If
                End If
                If lblCityRequired.Text = "*" Then
                    chkCity.Checked = True
                    valCity.Enabled = True
                End If
                If lblStreetRequired.Text = "*" Then
                    chkStreet.Checked = True
                    valStreet.Enabled = True
                End If
                If lblPostalRequired.Text = "*" Then
                    chkPostal.Checked = True
                    valPostal.Enabled = True
                End If
                If lblTelephoneRequired.Text = "*" Then
                    chkTelephone.Checked = True
                    valTelephone.Enabled = True
                End If
            End If

            If lblCountryRequired.Text = "" Then
                valCountry.Enabled = False
            End If
            If lblRegionRequired.Text = "" Then
                valRegion1.Enabled = False
                valRegion2.Enabled = False
            End If
            If lblCityRequired.Text = "" Then
                valCity.Enabled = False
            End If
            If lblStreetRequired.Text = "" Then
                valStreet.Enabled = False
            End If
            If lblPostalRequired.Text = "" Then
                valPostal.Enabled = False
            End If
            If lblTelephoneRequired.Text = "" Then
                valTelephone.Enabled = False
            End If

        End Sub

        Private Sub UpdateRequiredFields()

            If chkCountry.Checked = False Then
                chkRegion.Checked = False
            End If

            Dim objModules As New ModuleController
            objModules.UpdateModuleSetting(ModuleId, "addresscountry", IIf(chkCountry.Checked, "", "N").ToString)
            objModules.UpdateModuleSetting(ModuleId, "addressregion", IIf(chkRegion.Checked, "", "N").ToString)
            objModules.UpdateModuleSetting(ModuleId, "addresscity", IIf(chkCity.Checked, "", "N").ToString)
            objModules.UpdateModuleSetting(ModuleId, "addressstreet", IIf(chkStreet.Checked, "", "N").ToString)
            objModules.UpdateModuleSetting(ModuleId, "addresspostal", IIf(chkPostal.Checked, "", "N").ToString)
            objModules.UpdateModuleSetting(ModuleId, "addresstelephone", IIf(chkTelephone.Checked, "", "N").ToString)

            ShowRequiredFields()

        End Sub

        Private Sub chkCountry_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCountry.CheckedChanged
            Try
                UpdateRequiredFields()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkRegion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRegion.CheckedChanged
            Try
                UpdateRequiredFields()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkCity_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCity.CheckedChanged
            Try
                UpdateRequiredFields()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkStreet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStreet.CheckedChanged
            Try
                UpdateRequiredFields()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkPostal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPostal.CheckedChanged
            Try
                UpdateRequiredFields()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkTelephone_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTelephone.CheckedChanged
            Try
                UpdateRequiredFields()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
