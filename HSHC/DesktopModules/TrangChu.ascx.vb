Imports System.Configuration
Imports System.IO


Namespace PortalQH
    Public Class TrangChu
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Public urlVanHoa As String
        Public urlKinhTe As String
        Public urlLaoDong As String
        Public url1Cua As String
        Public urlVPHC As String
        Public urlTHTT As String

        Private fileLienKet As String


        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            
            fileLienKet = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("PathXML") & "DMLIENKET.xml"

            'Me.initURL()

        End Sub


        Private Sub initURL()
            'get url default
            urlVanHoa = Request.ServerVariables("URL")
            urlKinhTe = Request.ServerVariables("URL")
            urlLaoDong = Request.ServerVariables("URL")
            url1Cua = Request.ServerVariables("URL")
            urlVPHC = Request.ServerVariables("URL")
            urlTHTT = Request.ServerVariables("URL")

            'get danh muc lien ket
            Dim dsDanhMuc As New DataSet
            If File.Exists(fileLienKet) Then
                dsDanhMuc.ReadXml(fileLienKet)
            End If

            Dim tabItem As New TabController
            Dim tabCPVH, tabCPKT, tabCPLD, tabMOTCUA, tabTHTT As String
            tabCPVH = tabItem.GetTabIDByParentId(CInt(dsDanhMuc.Tables(0).Rows(0)("CPVH").ToString())).Tables(0).Rows(0)(0).ToString()
            tabCPLD = tabItem.GetTabIDByParentId(CInt(dsDanhMuc.Tables(0).Rows(0)("CPLD").ToString())).Tables(0).Rows(0)(0).ToString()
            tabCPKT = tabItem.GetTabIDByParentId(CInt(dsDanhMuc.Tables(0).Rows(0)("CPKT").ToString())).Tables(0).Rows(0)(0).ToString()
            tabMOTCUA = tabItem.GetTabIDByParentId(CInt(dsDanhMuc.Tables(0).Rows(0)("MOTCUA").ToString())).Tables(0).Rows(0)(0).ToString()
            tabTHTT = dsDanhMuc.Tables(0).Rows(0)("THTT").ToString()

            'set new url with areas
            If Not dsDanhMuc Is Nothing Then
                If dsDanhMuc.Tables.Count > 0 Then
                    urlVanHoa = urlVanHoa + "?TabID=" + tabCPVH
                    urlKinhTe = urlKinhTe + "?TabID=" + tabCPKT
                    urlLaoDong = urlLaoDong + "?TabID=" + tabCPLD
                    url1Cua = url1Cua + "?TabID=" + tabMOTCUA
                    urlTHTT = urlTHTT + "?TabID=" + tabTHTT
                End If
            End If
            urlVPHC = urlVPHC.ToUpper().Replace("HSHC", "VPHC").ToLower()

        End Sub

        Sub CreatLink(ByVal pLink As Object, ByVal pID As String, ByVal pURL As String, ByVal pText As String)

        End Sub
    End Class
End Namespace
