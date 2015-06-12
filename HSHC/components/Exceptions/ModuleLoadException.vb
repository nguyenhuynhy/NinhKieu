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

Imports System.Runtime.Serialization
Imports System.Security.Permissions

Namespace PortalQH
    <Serializable()> Public Class ModuleLoadException
        Inherits BasePortalException

        Private m_ModuleId As Integer
        Private m_ModuleDefId As Integer
        Private m_FriendlyName As String
        Private m_CurrentModuleSettings As ModuleSettings
        Private m_ModuleControlSource As String


        ' default constructor
        Public Sub New()
            MyBase.New()
        End Sub

        'constructor with exception message
        Public Sub New(ByVal message As String)
            MyBase.New(message)
            InitilizePrivateVariables()
        End Sub

        'constructor with exception message
        Public Sub New(ByVal message As String, ByVal inner As Exception, ByVal CurrentModuleSettings As ModuleSettings)
            MyBase.New(message, inner)
            m_CurrentModuleSettings = CurrentModuleSettings
            InitilizePrivateVariables()
        End Sub

        ' constructor with message and inner exception
        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
            InitilizePrivateVariables()
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            InitilizePrivateVariables()
            m_ModuleId = info.GetInt32("m_ModuleId")
            m_ModuleDefId = info.GetInt32("m_ModuleDefId")
            m_FriendlyName = info.GetString("m_FriendlyName")
        End Sub

        Private Sub InitilizePrivateVariables()
            'Try and get the Portal settings from context
            'If an error occurs getting the context then set the variables to -1
            Try
                m_ModuleId = m_CurrentModuleSettings.ModuleId
                m_ModuleDefId = m_CurrentModuleSettings.ModuleDefId
                m_FriendlyName = m_CurrentModuleSettings.ModuleTitle
                m_ModuleControlSource = m_CurrentModuleSettings.ControlSrc
            Catch exc As Exception
                m_ModuleId = -1
                m_ModuleDefId = -1
                m_FriendlyName = ""
            End Try
        End Sub

        <SecurityPermission(SecurityAction.Demand, SerializationFormatter:=True)> _
        Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            ' Serialize this class' state and then call the base class GetObjectData
            info.AddValue("m_ModuleId", m_ModuleId, GetType(Int32))
            info.AddValue("m_ModuleDefId", m_ModuleDefId, GetType(Int32))
            info.AddValue("m_FriendlyName", m_FriendlyName, GetType(String))
            info.AddValue("m_ModuleControlSource", m_ModuleControlSource, GetType(String))

            MyBase.GetObjectData(info, context)
        End Sub



        Public ReadOnly Property ModuleId() As Integer
            Get
                Return m_ModuleId
            End Get
        End Property

        Public ReadOnly Property ModuleDefId() As Integer
            Get
                Return m_ModuleDefId
            End Get
        End Property

        Public ReadOnly Property FriendlyName() As String
            Get
                Return m_FriendlyName
            End Get
        End Property
        Public ReadOnly Property ModuleControlSource() As String
            Get
                Return m_ModuleControlSource
            End Get
        End Property

    End Class

End Namespace