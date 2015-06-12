
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
Imports System.Configuration
Imports System.Data
Imports System.Globalization
Imports System.IO
Imports System.Xml
Imports ICSharpCode.SharpZipLib.Zip

Namespace PortalQH

    Public Class DesktopModuleInfo

        Private _DesktopModuleID As Integer
        Private _FriendlyName As String
        Private _Description As String
        Private _Version As String
        Private _IsPremium As Boolean
        Private _IsAdmin As Boolean
        Private _PortalModuleDefinitionID As Integer
        Private _HostFee As Double

        Public Sub New()
        End Sub

        Public Property DesktopModuleID() As Integer
            Get
                Return _DesktopModuleID
            End Get
            Set(ByVal Value As Integer)
                _DesktopModuleID = Value
            End Set
        End Property
        Public Property FriendlyName() As String
            Get
                Return _FriendlyName
            End Get
            Set(ByVal Value As String)
                _FriendlyName = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property
        Public Property Version() As String
            Get
                Return _Version
            End Get
            Set(ByVal Value As String)
                _Version = Value
            End Set
        End Property
        Public Property IsPremium() As Boolean
            Get
                Return _IsPremium
            End Get
            Set(ByVal Value As Boolean)
                _IsPremium = Value
            End Set
        End Property
        Public Property IsAdmin() As Boolean
            Get
                Return _IsAdmin
            End Get
            Set(ByVal Value As Boolean)
                _IsAdmin = Value
            End Set
        End Property
        Public Property PortalModuleDefinitionID() As Integer
            Get
                Return _PortalModuleDefinitionID
            End Get
            Set(ByVal Value As Integer)
                _PortalModuleDefinitionID = Value
            End Set
        End Property
        Public Property HostFee() As Double
            Get
                Return _HostFee
            End Get
            Set(ByVal Value As Double)
                _HostFee = Value
            End Set
        End Property
    End Class

    Public Class DesktopModuleController

        Public Function GetDesktopModule(ByVal DesktopModuleId As Integer) As DesktopModuleInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetDesktopModule(DesktopModuleId), GetType(DesktopModuleInfo)), DesktopModuleInfo)

        End Function

        Public Function GetDesktopModuleByName(ByVal FriendlyName As String) As DesktopModuleInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetDesktopModuleByName(FriendlyName), GetType(DesktopModuleInfo)), DesktopModuleInfo)

        End Function

        Public Function GetDesktopModules() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetDesktopModules(), GetType(DesktopModuleInfo))

        End Function

        Public Function GetPortalDesktopModules(ByVal PortalID As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetPortalDesktopModules(PortalID), GetType(DesktopModuleInfo))

        End Function

        Public Function GetPremiumDesktopModules(ByVal PortalID As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetPremiumDesktopModules(PortalID), GetType(DesktopModuleInfo))

        End Function

        Public Function AddDesktopModule(ByVal objDesktopModule As DesktopModuleInfo) As Integer

            Return DataProvider.Instance().AddDesktopModule(objDesktopModule.FriendlyName, objDesktopModule.Description, objDesktopModule.Version, objDesktopModule.IsPremium)

        End Function

        Public Sub UpdateDesktopModule(ByVal objDesktopModule As DesktopModuleInfo)

            DataProvider.Instance().UpdateDesktopModule(objDesktopModule.DesktopModuleID, objDesktopModule.FriendlyName, objDesktopModule.Description, objDesktopModule.Version, objDesktopModule.IsPremium)

            If Not objDesktopModule.IsPremium Then
                Dim objPortals As New PortalController
                Dim objPortal As PortalInfo
                Dim intPortal As Integer

                Dim arrPortals As ArrayList = objPortals.GetPortals
                For intPortal = 0 To arrPortals.Count - 1
                    objPortal = CType(arrPortals(intPortal), PortalInfo)
                    DataProvider.Instance().DeletePortalModuleDefinition(objPortal.PortalID, objDesktopModule.DesktopModuleID)
                Next intPortal
            End If

        End Sub

        Public Sub DeleteDesktopModule(ByVal DesktopModuleId As Integer)

            DataProvider.Instance().DeleteDesktopModule(DesktopModuleId)

        End Sub

        Public Sub UpdatePortalModuleDefinition(ByVal PortalID As Integer, ByVal DesktopModuleID As Integer, ByVal Subscribed As Boolean, ByVal HostFee As Double)

            Dim dr As IDataReader = DataProvider.Instance().GetPortalModuleDefinition(PortalID, DesktopModuleID)
            If dr.Read Then
                If Subscribed Then
                    DataProvider.Instance().UpdatePortalModuleDefinition(PortalID, DesktopModuleID, HostFee)
                Else
                    DataProvider.Instance().DeletePortalModuleDefinition(PortalID, DesktopModuleID)
                End If
            Else
                DataProvider.Instance().AddPortalModuleDefinition(PortalID, DesktopModuleID, HostFee)
            End If
            dr.Close()

        End Sub

    End Class

    Public Class ModuleDefinitionInfo

        Private _ModuleDefID As Integer
        Private _FriendlyName As String
        Private _DesktopModuleID As Integer
        Private _TempModuleID As Integer

        Public Sub New()
        End Sub

        Public Property ModuleDefID() As Integer
            Get
                Return _ModuleDefID
            End Get
            Set(ByVal Value As Integer)
                _ModuleDefID = Value
            End Set
        End Property
        Public Property FriendlyName() As String
            Get
                Return _FriendlyName
            End Get
            Set(ByVal Value As String)
                _FriendlyName = Value
            End Set
        End Property
        Public Property DesktopModuleID() As Integer
            Get
                Return _DesktopModuleID
            End Get
            Set(ByVal Value As Integer)
                _DesktopModuleID = Value
            End Set
        End Property
        Public Property TempModuleID() As Integer
            Get
                Return _TempModuleID
            End Get
            Set(ByVal Value As Integer)
                _TempModuleID = Value
            End Set
        End Property
    End Class

    Public Class ModuleDefinitionController

        Public Function GetModuleDefinitions(ByVal DesktopModuleId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetModuleDefinitions(DesktopModuleId), GetType(ModuleDefinitionInfo))

        End Function

        Public Function GetModuleDefinition(ByVal ModuleDefId As Integer) As ModuleDefinitionInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetModuleDefinition(ModuleDefId), GetType(ModuleDefinitionInfo)), ModuleDefinitionInfo)

        End Function

        Public Function GetModuleDefinitionByName(ByVal DesktopModuleId As Integer, ByVal FriendlyName As String) As ModuleDefinitionInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetModuleDefinitionByName(DesktopModuleId, FriendlyName), GetType(ModuleDefinitionInfo)), ModuleDefinitionInfo)

        End Function

        Public Function AddModuleDefinition(ByVal objModuleDefinition As ModuleDefinitionInfo) As Integer

            Return DataProvider.Instance().AddModuleDefinition(objModuleDefinition.DesktopModuleID, objModuleDefinition.FriendlyName)

        End Function

        Public Sub DeleteModuleDefinition(ByVal ModuleDefinitionId As Integer)

            DataProvider.Instance().DeleteModuleDefinition(ModuleDefinitionId)

        End Sub

    End Class

    Public Class ModuleControlInfo

        Private _ModuleControlID As Integer
        Private _ModuleDefID As Integer
        Private _ControlKey As String
        Private _ControlTitle As String
        Private _ControlSrc As String
        Private _IconFile As String
        Private _ControlType As Integer
        Private _ViewOrder As Integer

        Public Sub New()
        End Sub

        Public Property ModuleControlID() As Integer
            Get
                Return _ModuleControlID
            End Get
            Set(ByVal Value As Integer)
                _ModuleControlID = Value
            End Set
        End Property
        Public Property ModuleDefID() As Integer
            Get
                Return _ModuleDefID
            End Get
            Set(ByVal Value As Integer)
                _ModuleDefID = Value
            End Set
        End Property
        Public Property ControlKey() As String
            Get
                Return _ControlKey
            End Get
            Set(ByVal Value As String)
                _ControlKey = Value
            End Set
        End Property
        Public Property ControlTitle() As String
            Get
                Return _ControlTitle
            End Get
            Set(ByVal Value As String)
                _ControlTitle = Value
            End Set
        End Property
        Public Property ControlSrc() As String
            Get
                Return _ControlSrc
            End Get
            Set(ByVal Value As String)
                _ControlSrc = Value
            End Set
        End Property
        Public Property IconFile() As String
            Get
                Return _IconFile
            End Get
            Set(ByVal Value As String)
                _IconFile = Value
            End Set
        End Property
        Public Property ControlType() As SecurityAccessLevel
            Get
                Return CType(_ControlType, SecurityAccessLevel)
            End Get
            Set(ByVal Value As SecurityAccessLevel)
                _ControlType = Value
            End Set
        End Property
        Public Property ViewOrder() As Integer
            Get
                Return _ViewOrder
            End Get
            Set(ByVal Value As Integer)
                _ViewOrder = Value
            End Set
        End Property
    End Class

    Public Class ModuleControlController

        Public Function GetModuleControl(ByVal ModuleControlId As Integer) As ModuleControlInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetModuleControl(ModuleControlId), GetType(ModuleControlInfo)), ModuleControlInfo)

        End Function

        Public Function GetModuleControls(ByVal ModuleDefID As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetModuleControls(ModuleDefID), GetType(ModuleControlInfo))

        End Function

        Public Function GetModuleControlsByKey(ByVal ControlKey As String, ByVal ModuleDefId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetModuleControlsByKey(ControlKey, ModuleDefId), GetType(ModuleControlInfo))

        End Function

        Public Function GetModuleControlByKeyAndSrc(ByVal ModuleDefId As Integer, ByVal ControlKey As String, ByVal ControlSrc As String) As ModuleControlInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetModuleControlByKeyAndSrc(ModuleDefId, ControlKey, ControlSrc), GetType(ModuleControlInfo)), ModuleControlInfo)

        End Function

        Public Sub AddModuleControl(ByVal objModuleControl As ModuleControlInfo)

            DataProvider.Instance().AddModuleControl(objModuleControl.ModuleDefID, objModuleControl.ControlKey, objModuleControl.ControlTitle, objModuleControl.ControlSrc, objModuleControl.IconFile, CType(objModuleControl.ControlType, Integer), objModuleControl.ViewOrder)

        End Sub

        Public Sub UpdateModuleControl(ByVal objModuleControl As ModuleControlInfo)

            DataProvider.Instance().UpdateModuleControl(objModuleControl.ModuleControlID, objModuleControl.ModuleDefID, objModuleControl.ControlKey, objModuleControl.ControlTitle, objModuleControl.ControlSrc, objModuleControl.IconFile, CType(objModuleControl.ControlType, Integer), objModuleControl.ViewOrder)

        End Sub

        Public Sub DeleteModuleControl(ByVal ModuleControlId As Integer)

            DataProvider.Instance().DeleteModuleControl(ModuleControlId)

        End Sub

    End Class

End Namespace

