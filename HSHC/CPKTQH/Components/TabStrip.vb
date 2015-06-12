Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
'Imports ASPNET.StarterKit.Communities

Namespace CPKTQH

    '*********************************************************************
    '
    ' Tab Strip Class
    '
    ' Used to create the tab strip on the Edit Sections page.
    '
    '*********************************************************************
    <ControlBuilderAttribute(GetType(TabStripControlBuilder)), ParseChildrenAttribute(False)> _
    Public Class TabStrip
        Inherits WebControl
        Implements INamingContainer 'ToDo: Add Implements Clauses for implementation methods of these interface(s)

        Private _isUplevel As Boolean
        Public _tabs As New ArrayList



        '*********************************************************************
        '
        ' TabStrip Constructor
        '
        ' Determine whether browser is uplevel.
        '
        '*********************************************************************
        Public Sub New()
            If Not (Context Is Nothing) Then
                If HttpContext.Current.Request.Browser.Browser = "IE" AndAlso HttpContext.Current.Request.Browser.MajorVersion >= 6 Then
                    _isUplevel = True
                Else
                    _isUplevel = False
                End If
            End If
        End Sub 'New


        '*********************************************************************
        '
        ' AddParsedSubObject Method
        '
        ' Only add tabs to the Tabs collection.
        '
        '*********************************************************************
        Protected Overrides Sub AddParsedSubObject(ByVal obj As [Object])

            If TypeOf obj Is Tab Then
                _tabs.Add(obj)
            End If
        End Sub 'AddParsedSubObject


        '*********************************************************************
        '
        ' OnPreRender Method
        '
        ' Add reference to client-side script.
        '
        '*********************************************************************
        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            Dim sPanelID As String
            sPanelID = HttpContext.Current.Request("hPanelID")
            If _isUplevel AndAlso Not Page.IsClientScriptBlockRegistered("tabstrip") Then
                Page.RegisterClientScriptBlock("tabstrip", String.Format("<script language=""JavaScript"" Src=""{0}""></script>", HttpContext.Current.Request.ApplicationPath & "/INC/tabstrip.js"))
                Page.RegisterHiddenField("hPanelID", sPanelID)

                'Dim scriptString As String = "<script language=""JavaScript"">"
                ''scriptString += " document.body.all.items('" & sPanelID & "').style.display = 'block';"
                ''scriptString += "showPanel('" & sPanelID & "', 'ctlTab_" & sPanelID & "')"
                ''scriptString += "if (document.all.namedItem('hPanelID').value != """"){ "
                ''scriptString += " showPanel(document.all.namedItem('hPanelID').value, 'ctlTab_' + document.all.namedItem('hPanelID').value); "
                'scriptString += " alert(document.all.namedItem('" & sPanelID & "').className); "
                ''scriptString += "} else { "
                ''scriptString += "//showPanel('pnlLuong', 'ctlTab_pnlLuong');}"
                ''scriptString += "} "
                'scriptString += "</script>"

                'If sPanelID <> "" AndAlso Not Page.IsClientScriptBlockRegistered("initTab") Then
                '    Page.RegisterClientScriptBlock("initTab", scriptString)
                'End If

            End If
        End Sub 'OnPreRender






        '*********************************************************************
        '
        ' RenderContents Method
        '
        ' Display tabstrip for uplevel browsers.
        '
        '*********************************************************************
        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            ' Dont't render for downlevel browsers
            If Not _isUplevel Then
                Return
            End If


            ' Display the tabs
            Dim i As Integer
            For i = 0 To _tabs.Count - 1
                Dim objTab As Tab = CType(_tabs(i), Tab)
                If objTab.Hide = "0" Then
                    If i = 0 Then
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "eDMS_tabSelected")
                    Else
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "eDMS_tab")
                    End If

                    writer.AddAttribute(HtmlTextWriterAttribute.Id, "ctlTab_" & objTab.PanelID)
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, String.Format("javascript:showPanel('{0}', 'ctlTab_{0}')", objTab.PanelID))
                    writer.AddAttribute(HtmlTextWriterAttribute.Align, "center")
                    writer.RenderBeginTag(HtmlTextWriterTag.A)
                    writer.Write(objTab.Text)
                    writer.RenderEndTag()

                    If i < _tabs.Count - 1 Then
                        writer.Write("&nbsp;&nbsp;")
                    End If
                End If
            Next i
        End Sub 'RenderContents 
    End Class 'TabStrip 







    '*********************************************************************
    '
    ' Tab Strip Control Builder Class
    '
    ' Only parse tabs in the tab strip.
    '
    '*********************************************************************

    Public Class TabStripControlBuilder
        Inherits ControlBuilder


        Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attributes As IDictionary) As Type

            If String.Compare(tagName, "tab", True) = 0 Then
                Return GetType(Tab)
            End If

            Return Nothing
        End Function 'GetChildControlType
    End Class 'TabStripControlBuilder


    '*********************************************************************
    '
    ' Tab Class
    '
    ' Represents individual tabs in the tab strip.
    '
    '*********************************************************************

    Public Class Tab
        Inherits Control

        Private _text As String
        Private _panelID As String
        Private _hide As String = "0"
        Private _value As String



        Public Property [Value]() As String
            Get
                Return _value
            End Get
            Set(ByVal Value As String)
                _value = Value
            End Set
        End Property
        Public Property [Text]() As String
            Get
                Return _text
            End Get
            Set(ByVal Value As String)
                _text = Value
            End Set
        End Property

        Public Property [Hide]() As String
            Get
                Return _hide
            End Get
            Set(ByVal Value As String)
                _hide = Value
            End Set
        End Property

        Public Property PanelID() As String
            Get
                Return _panelID
            End Get
            Set(ByVal Value As String)
                _panelID = Value
            End Set
        End Property
    End Class 'Tab


End Namespace