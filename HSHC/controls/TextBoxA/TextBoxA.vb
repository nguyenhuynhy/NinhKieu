'by AnhLH
'date May 17 2004
'------------------------------------------------------------------------------------------------

Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Configuration
Imports System.Web.Caching
Imports System.IO
Imports System.Collections

<Assembly: TagPrefix("PortalQH.Web.UI.WebControls.TextBoxA", "PortalQH")> 

Namespace PortalQH.Web.UI.WebControls
    <ToolboxData("<{0}:TextBoxA runat=server></{0}:TextBoxA>")> _
    Public Class TextBoxA
        Inherits System.Web.UI.WebControls.TextBox
#Region " Declarations "

        Private _IsNull As Boolean = True
        Private _IsNumber As Boolean = False
        Private _IsCMND As Boolean = False
        Private _IsKey As Boolean = False

#End Region

#Region " Properties "
        Public Property IsNull() As Boolean

            Get
                Return _IsNull
            End Get

            Set(ByVal Value As Boolean)
                _IsNull = Value
            End Set
        End Property
        Public Property IsNumber() As Boolean
            Get
                Return _IsNumber
            End Get
            Set(ByVal Value As Boolean)
                _IsNumber = Value
            End Set
        End Property
        Public Property IsKey() As Boolean

            Get
                Return _IsKey
            End Get

            Set(ByVal Value As Boolean)
                _IsKey = Value
            End Set
        End Property

#End Region

    End Class

End Namespace
