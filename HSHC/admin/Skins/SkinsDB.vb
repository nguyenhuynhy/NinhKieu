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
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports System.Xml
Imports System.Text.RegularExpressions

Namespace PortalQH

    Public Class SkinInfo

        ' skin root values
        Public Shared ReadOnly Property RootSkin() As String
            Get
                Return "Skins"
            End Get
        End Property
        Public Shared ReadOnly Property RootContainer() As String
            Get
                Return "Containers"
            End Get
        End Property

        ' local property declarations
        Private _SkinId As Integer
        Private _PortalId As Integer
        Private _TabId As Integer
        Private _ModuleId As Integer
        Private _SkinRoot As String
        Private _SkinType As String
        Private _SkinName As String
        Private _SkinSrc As String

        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property SkinId() As Integer
            Get
                Return _SkinId
            End Get
            Set(ByVal Value As Integer)
                _SkinId = Value
            End Set
        End Property

        Public Property PortalId() As Integer
            Get
                Return _PortalId
            End Get
            Set(ByVal Value As Integer)
                _PortalId = Value
            End Set
        End Property

        Public Property TabId() As Integer
            Get
                Return _TabId
            End Get
            Set(ByVal Value As Integer)
                _TabId = Value
            End Set
        End Property

        Public Property ModuleId() As Integer
            Get
                Return _ModuleId
            End Get
            Set(ByVal Value As Integer)
                _ModuleId = Value
            End Set
        End Property

        Public Property SkinRoot() As String
            Get
                Return _SkinRoot
            End Get
            Set(ByVal Value As String)
                _SkinRoot = Value
            End Set
        End Property

        Public Property SkinType() As String
            Get
                Return _SkinType
            End Get
            Set(ByVal Value As String)
                _SkinType = Value
            End Set
        End Property

        Public Property SkinName() As String
            Get
                Return _SkinName
            End Get
            Set(ByVal Value As String)
                _SkinName = Value
            End Set
        End Property

        Public Property SkinSrc() As String
            Get
                Return _SkinSrc
            End Get
            Set(ByVal Value As String)
                _SkinSrc = Value
            End Set
        End Property

    End Class

    Public Class SkinController

        Public Shared Function GetSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabID As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean) As SkinInfo
            Return CType(CBO.FillObject(DataProvider.Instance().GetSkin(SkinRoot, PortalId, TabID, ModuleId, IsAdmin), GetType(SkinInfo)), SkinInfo)
        End Function


        Public Shared Sub SetSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabID As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean, ByVal SkinType As String, ByVal SkinName As String, ByVal SkinSrc As String)

            Dim objSkin As SkinInfo

            ' save current info if this is a non-admin skin assignment 
            If SkinRoot = SkinInfo.RootSkin And IsAdmin = False Then
                objSkin = GetSkin(SkinRoot, PortalId, TabID, ModuleId, IsAdmin)
            End If

            ' remove skin assignment
            DataProvider.Instance().DeleteSkin(SkinRoot, PortalId, TabID, ModuleId, IsAdmin)

            ' add new skin assignment if specified
            If SkinName <> "" Then
                DataProvider.Instance().AddSkin(SkinRoot, PortalId, TabID, ModuleId, IsAdmin, SkinType, SkinName, SkinSrc)

                If Not objSkin Is Nothing Then
                    ' if this is a completely new skin assignment
                    If SkinName <> objSkin.SkinName Then
                        ' remove the old container assignments
                        Dim objModules As New ModuleController
                        Dim objModule As ModuleInfo
                        Dim arrModules As ArrayList
                        Dim intModule As Integer

                        Dim objTabs As New TabController
                        Dim objTab As TabInfo
                        Dim arrTabs As ArrayList = objTabs.GetTabs(PortalId)
                        Dim intTab As Integer
                        For intTab = 0 To arrTabs.Count - 1
                            objTab = CType(arrTabs(intTab), TabInfo)
                            arrModules = objModules.GetPortalTabModules(PortalId, objTab.TabID)
                            For intModule = 0 To arrModules.Count - 1
                                objModule = CType(arrModules(intModule), ModuleInfo)
                                DataProvider.Instance().DeleteSkin(SkinInfo.RootContainer, Null.NullInteger, Null.NullInteger, objModule.ModuleID, IsAdmin)
                            Next
                        Next
                    End If
                End If
            End If
        End Sub

        Public Shared Function UploadSkin(ByVal RootPath As String, ByVal SkinRoot As String, ByVal objHttpPostedFile As HttpPostedFile) As String

            Dim objZipInputStream As New ZipInputStream(objHttpPostedFile.InputStream)
            Dim objZipEntry As ZipEntry
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Dim strExtension As String
            Dim strFileName As String
            Dim objFileStream As FileStream
            Dim intSize As Integer = 2048
            Dim arrData(2048) As Byte
            Dim strMessage As String = ""
            Dim arrSkinFiles As New ArrayList

            strMessage += FormatMessage("Begin processing zip file", Path.GetFileName(objHttpPostedFile.FileName), -1, False)

            objZipEntry = objZipInputStream.GetNextEntry
            While Not objZipEntry Is Nothing
                If Not objZipEntry.IsDirectory Then
                    ' validate file extension
                    strExtension = objZipEntry.Name.Substring(objZipEntry.Name.LastIndexOf(".") + 1)
                    If InStr(1, ",ASCX,HTM,HTML,CSS," & _portalSettings.HostSettings("FileExtensions").ToString.ToUpper, "," & strExtension.ToUpper) <> 0 Then

                        strFileName = RootPath & SkinRoot & "\" & Path.GetFileNameWithoutExtension(objHttpPostedFile.FileName) & "\" & objZipEntry.Name

                        ' create the directory if it does not exist
                        If Not Directory.Exists(Path.GetDirectoryName(strFileName)) Then
                            strMessage += FormatMessage("Creating directory", Path.GetDirectoryName(strFileName), 2, False)
                            Directory.CreateDirectory(Path.GetDirectoryName(strFileName))
                        End If

                        ' remove the old file
                        If File.Exists(strFileName) Then
                            File.SetAttributes(strFileName, FileAttributes.Normal)
                            File.Delete(strFileName)
                        End If
                        ' create the new file
                        objFileStream = File.Create(strFileName)

                        ' unzip the file
                        strMessage += FormatMessage("Writing file", Path.GetFileName(strFileName), 2, False)
                        intSize = objZipInputStream.Read(arrData, 0, arrData.Length)
                        While intSize > 0
                            objFileStream.Write(arrData, 0, intSize)
                            intSize = objZipInputStream.Read(arrData, 0, arrData.Length)
                        End While
                        objFileStream.Close()

                        ' save the skin file
                        Select Case Path.GetExtension(strFileName)
                            Case ".htm", ".html", ".ascx", ".css"
                                arrSkinFiles.Add(strFileName)
                        End Select
                    Else
                        strMessage += FormatMessage("Error processing file", objZipEntry.Name & " is a restricted file type. Valid file types include ( *." & Replace(_portalSettings.HostSettings("FileExtensions").ToString, ",", ", *.") & " ). Please contact your hosting provider if you need to upload a file type which is not supported.", 2, True)
                    End If
                End If
                objZipEntry = objZipInputStream.GetNextEntry
            End While
            strMessage += FormatMessage("End processing zip file", Path.GetFileName(objHttpPostedFile.FileName), 1, False)
            objZipInputStream.Close()

            ' process the list of skin files
            Dim NewSkin As New SkinFileProcessor(RootPath, SkinRoot, Path.GetFileNameWithoutExtension(objHttpPostedFile.FileName))
            strMessage += NewSkin.ProcessList(arrSkinFiles)

            Return strMessage

        End Function

        Public Shared Function FormatMessage(ByVal Title As String, ByVal Body As String, ByVal Level As Integer, ByVal IsError As Boolean) As String
            Dim Message As String = Title

            If IsError Then
                Message = "<font class=""NormalRed"">" & Title & "</font>"
            End If

            Select Case Level
                Case -1
                    Message = "<hr><br><b>" & Message & "</b>"
                Case 0
                    Message = "<br><br><b>" & Message & "</b>"
                Case 1
                    Message = "<br><b>" & Message & "</b>"
                Case Else
                    Message = "<br><li>" & Message
            End Select

            Return Message & ": " & Body & vbCrLf

        End Function

    End Class

    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : SkinFileProcessor
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Handles processing of a list of uploaded skin files into a working skin.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[willhsc]	3/3/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class SkinFileProcessor

        Private ReadOnly m_SkinRoot As String
        Private ReadOnly m_SkinPath As String
        Private ReadOnly m_SkinName As String
        Private ReadOnly m_SkinAttributes As New XmlDocument
        Private ReadOnly m_PathFactory As New PathParser
        Private ReadOnly m_ControlFactory As ControlParser
        Private ReadOnly m_ControlList As New Hashtable
        Private m_Message As String = ""

        Public ReadOnly Property SkinRoot() As String
            Get
                Return m_SkinRoot
            End Get
        End Property

        Public ReadOnly Property SkinPath() As String
            Get
                Return m_SkinPath
            End Get
        End Property

        Public ReadOnly Property SkinName() As String
            Get
                Return m_SkinName
            End Get
        End Property

        Private ReadOnly Property PathFactory() As PathParser
            Get
                Return m_PathFactory
            End Get
        End Property

        Private ReadOnly Property ControlFactory() As ControlParser
            Get
                Return m_ControlFactory
            End Get
        End Property

        Private ReadOnly Property SkinAttributes() As XmlDocument
            Get
                Return m_SkinAttributes
            End Get
        End Property

        Private Property Message() As String
            Get
                Return m_Message
            End Get
            Set(ByVal Value As String)
                m_Message = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     SkinFileProcessor class constructor.
        ''' </summary>
        ''' <param name="SkinPath">File path to the portals upload directory.</param>
        ''' <param name="SkinRoot">Specifies type of skin (Skins or Containers)</param>
        ''' <param name="SkinFolderName">Name of folder in which skin will reside (Zip file name)</param>
        ''' <remarks>
        '''     The constructor primes the file processor with path information and
        '''     control data that should only be retrieved once.  It checks for the
        '''     existentce of a skin level attribute file and read it in, if found.
        '''     It also sorts through the complete list of controls and creates
        '''     a hashtable which contains only the skin objects and their source paths.
        '''     These are recognized by their ControlKey's which are formatted like
        '''     tokens ("[TOKEN]").  The hashtable is required for speed as it will be
        '''     processed for each token found in the source file by the Control Parser.
        ''' </remarks>
        ''' <history>
        ''' 	[willhsc]	3/3/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New(ByVal SkinPath As String, ByVal SkinRoot As String, ByVal SkinName As String)

            Me.Message += SkinController.FormatMessage("Initialize processor for skin/container files", SkinRoot & " :: " & SkinName, 0, False)

            ' Save path information for future use
            m_SkinRoot = SkinRoot
            m_SkinPath = SkinPath
            m_SkinName = SkinName

            ' Check for and read skin package level attribute information file
            Dim FileName As String = Me.SkinPath & Me.SkinRoot & "\" & Me.SkinName & "\" & SkinRoot.Substring(0, SkinRoot.Length - 1) & ".xml"
            If File.Exists(FileName) Then
                Try
                    Me.SkinAttributes.Load(FileName)
                    Me.Message += SkinController.FormatMessage("Loaded package level attribute file", Path.GetFileName(FileName), 2, False)
                Catch
                    ' could not load XML file
                    Me.Message += SkinController.FormatMessage("Error loading package level attribute file", Path.GetFileName(FileName), 2, True)
                End Try
            End If

            ' Retrieve a list of available controls
            Dim objModuleControls As New ModuleControlController
            Dim arrModuleControls As ArrayList = objModuleControls.GetModuleControls(Null.NullInteger)

            ' Look at every control
            Dim Token As String
            Dim i As Integer
            Dim objModuleControl As ModuleControlInfo
            For i = 0 To arrModuleControls.Count - 1
                objModuleControl = DirectCast(arrModuleControls(i), ModuleControlInfo)
                ' If the control is a skin object, save the key and source in the hash table
                If objModuleControl.ControlType = SecurityAccessLevel.SkinObject Then
                    Token = objModuleControl.ControlKey.ToUpper

                    ' If the control is already in the hash table
                    If m_ControlList.ContainsKey(Token) Then
                        ' Record an error message and skip it
                        Me.Message += SkinController.FormatMessage("Discarding duplicate skin object for token " & objModuleControl.ControlKey.ToString.ToUpper, _
                            "Any skin that references this token will utilize the skin control registered first (" & DirectCast(m_ControlList.Item(Token), String) & ") rather than the one specified by the duplicate (" & objModuleControl.ControlSrc.ToString & ").  The skin may render incorrectly.", 2, True)
                    Else
                        ' Add it
                        Me.Message += SkinController.FormatMessage("Loading skin object for token " & objModuleControl.ControlKey.ToString.ToUpper, objModuleControl.ControlSrc.ToString, 2, False)
                        m_ControlList.Add(Token, objModuleControl.ControlSrc)
                    End If
                End If
            Next

            ' Instantiate the control parser with the list of skin objects
            m_ControlFactory = New ControlParser(m_ControlList)

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Perform processing on list of files to generate skin.
        ''' </summary>
        ''' <param name="FileList">ArrayList of files to be processed.</param>
        ''' <returns>HTML formatted string of informational messages.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[willhsc]	3/3/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ProcessList(ByVal FileList As ArrayList) As String

            Dim FileName As String

            ' process each file in the list
            For Each FileName In FileList

                Me.Message += SkinController.FormatMessage("Begin processing file", Path.GetFileName(FileName), 0, False)

                ' create a skin file object to aid in processing
                Dim objSkinFile As New SkinFile(Me.SkinRoot, FileName, Me.SkinAttributes)

                ' choose processing based on type of file
                Select Case objSkinFile.FileExtension

                    Case ".htm", ".html"
                        ' replace paths, process control tokens and convert html to ascx format
                        Me.Message += Me.PathFactory.Parse(objSkinFile.Contents, Me.PathFactory.HTMLList, objSkinFile.SkinRootPath)
                        Me.Message += Me.ControlFactory.Parse(objSkinFile.Contents, objSkinFile.Attributes)
                        Me.Message += objSkinFile.PrependASCXDirectives(Me.ControlFactory.Registrations)

                    Case ".ascx"
                        ' replace paths
                        Me.Message += Me.PathFactory.Parse(objSkinFile.Contents, Me.PathFactory.HTMLList, objSkinFile.SkinRootPath)

                    Case ".css"
                        ' replace paths
                        Me.Message += Me.PathFactory.Parse(objSkinFile.Contents, Me.PathFactory.CSSList, objSkinFile.SkinRootPath)

                End Select

                objSkinFile.Write()
                Me.Message += objSkinFile.Messages

                Me.Message += SkinController.FormatMessage("End processing file", Path.GetFileName(FileName), 1, False)
            Next

            Me.Message += SkinController.FormatMessage("End processing skin/container files", Me.SkinRoot & " :: " & Me.SkinName, 0, False)

            Return Me.Message

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Utility class for processing of skin files.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[willhsc]	3/3/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Class SkinFile
            Private ReadOnly m_FileName As String
            Private ReadOnly m_FileExtension As String
            Private ReadOnly m_WriteFileName As String
            Private ReadOnly m_SkinRoot As String
            Private ReadOnly m_SkinRootPath As String
            Private ReadOnly m_FileAttributes As XmlDocument
            Private m_FileContents As String
            Private m_Messages As String = ""

            Public ReadOnly Property SkinRoot() As String
                Get
                    Return m_SkinRoot
                End Get
            End Property
            Public ReadOnly Property Attributes() As XmlDocument
                Get
                    Return m_FileAttributes
                End Get
            End Property
            Public ReadOnly Property Messages() As String
                Get
                    Return m_Messages
                End Get
            End Property
            Public ReadOnly Property FileName() As String
                Get
                    Return m_FileName
                End Get
            End Property
            Public ReadOnly Property WriteFileName() As String
                Get
                    Return m_WriteFileName
                End Get
            End Property
            Public ReadOnly Property FileExtension() As String
                Get
                    Return m_FileExtension
                End Get
            End Property
            Public ReadOnly Property SkinRootPath() As String
                Get
                    Return m_SkinRootPath
                End Get
            End Property
            Public Property Contents() As String
                Get
                    Return m_FileContents
                End Get
                Set(ByVal Value As String)
                    m_FileContents = Value
                End Set
            End Property

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     SkinFile class constructor.
            ''' </summary>
            ''' <param name="SkinRoot"></param>
            ''' <param name="FileName"></param>
            ''' <param name="SkinAttributes"></param>
            ''' <remarks>
            '''     The constructor primes the utility class with basic file information.
            '''     It also checks for the existentce of a skinfile level attribute file
            '''     and read it in, if found.  
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public Sub New(ByVal SkinRoot As String, ByVal FileName As String, ByVal SkinAttributes As XmlDocument)

                ' capture file information
                m_FileName = FileName
                m_FileExtension = Path.GetExtension(FileName)
                m_SkinRoot = SkinRoot
                m_FileAttributes = SkinAttributes

                ' determine and store path to portals skin root folder
                Dim strTemp As String = Replace(FileName, Path.GetFileName(FileName), "")
                strTemp = Replace(strTemp, "\", "/")
                m_SkinRootPath = Global.ApplicationPath & Mid(strTemp, InStr(1, strTemp, "/Portals"))

                ' read file contents
                Me.Contents = Read(FileName)

                ' setup some attributes based on file extension
                Select Case Me.FileExtension

                    Case ".htm", ".html"
                        ' set output file name to <filename>.ASCX
                        m_WriteFileName = FileName.Replace(Path.GetExtension(FileName), ".ascx")
                        ' capture warning if file does not contain a "ContentPane"
                        Dim PaneCheck As New Regex("\s*id\s*=\s*""" & glbDefaultPane & """", RegexOptions.IgnoreCase)
                        If Not PaneCheck.IsMatch(Me.Contents) Then
                            m_Messages += SkinController.FormatMessage("File formatting error", FileName & " does not contain a ContentPane.", 2, True)
                        End If

                        ' Check for existence of and load skin file level attribute information 
                        If File.Exists(FileName.Replace(Me.FileExtension, ".xml")) Then
                            Try
                                m_FileAttributes.Load(FileName.Replace(Me.FileExtension, ".xml"))
                                m_Messages += SkinController.FormatMessage("Loading attribute file", FileName, 2, False)
                            Catch ex As Exception ' could not load XML file
                                m_FileAttributes = SkinAttributes
                                m_Messages += SkinController.FormatMessage("Error loading attribute file", FileName, 2, True)
                            End Try
                        End If

                    Case Else
                        ' output file name is same as input file name
                        m_WriteFileName = FileName

                End Select

            End Sub

            Private Function Read(ByVal FileName As String) As String

                Dim objStreamReader As New StreamReader(FileName)
                Dim strFileContents As String = objStreamReader.ReadToEnd()
                objStreamReader.Close()

                Return strFileContents

            End Function

            Public Sub Write()

                ' delete the file before attempting to write
                If File.Exists(Me.WriteFileName) Then
                    File.Delete(Me.WriteFileName)
                End If

                m_Messages += SkinController.FormatMessage("Writing file", Path.GetFileName(Me.WriteFileName), 2, False)
                Dim objStreamWriter As New StreamWriter(Me.WriteFileName)
                objStreamWriter.WriteLine(Me.Contents)
                objStreamWriter.Flush()
                objStreamWriter.Close()

            End Sub

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     Prepend ascx control directives to file contents.
            ''' </summary>
            ''' <param name="Registrations">ArrayList of registration directives.</param>
            ''' <remarks>
            '''     This procedure formats the @Control directive and prepends it and all
            '''     registration directives to the file contents.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public Function PrependASCXDirectives(ByVal Registrations As ArrayList) As String

                Dim Messages As String = ""
                Dim Prefix As String = ""

                ' format and save @Control directive
                Select Case Me.SkinRoot
                    Case SkinInfo.RootSkin
                        Prefix += "<%@ Control language=""vb"" CodeBehind=""~/admin/" & SkinRoot & "/skin.vb"" AutoEventWireup=""false"" Explicit=""True"" Inherits=""PortalQH.Skin"" %>" & vbCrLf
                    Case SkinInfo.RootContainer
                        Prefix += "<%@ Control language=""vb"" CodeBehind=""~/admin/" & SkinRoot & "/container.vb"" AutoEventWireup=""false"" Explicit=""True"" Inherits=""PortalQH.Container"" %>" & vbCrLf
                End Select

                Messages += SkinController.FormatMessage("Formatting control directive", HttpUtility.HtmlEncode(Prefix), 2, False)

                ' add preformatted Control Registrations
                Dim Item As String
                For Each Item In Registrations
                    Messages += SkinController.FormatMessage("Formatting registration directive", HttpUtility.HtmlEncode(Item), 2, False)
                    Prefix += Item
                Next

                ' update file contents to include ascx header information
                Me.Contents = Prefix + Me.Contents

                Return Messages

            End Function

        End Class

        ''' -----------------------------------------------------------------------------
        ''' Project	 : PortalQH
        ''' Class	 : SkinFileProcessor.PathParser
        ''' 
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Parsing functionality for path replacement in new skin files.
        ''' </summary>
        ''' <remarks>
        '''     This class encapsulates the data and methods necessary to appropriately
        '''     handle all the path replacement parsing needs for new skin files. Parsing
        '''     supported for CSS syntax and HTML syntax (which covers ASCX files also). 
        ''' </remarks>
        ''' <history>
        ''' 	[willhsc]	3/3/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Class PathParser

            Private m_HTMLPatterns As New ArrayList
            Private m_CSSPatterns As New ArrayList
            Private m_SkinPath As String = ""
            Private m_Messages As String = ""

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     List of regular expressions for processing HTML syntax.
            ''' </summary>
            ''' <returns>ArrayList of Regex objects formatted for the Parser method.</returns>
            ''' <remarks>
            '''     Additional patterns can be added to this list (if necessary) if properly
            '''     formatted to return <tag>, <content> and <endtag> groups.  For future
            '''     consideration, this list could be imported from a configuration file to
            '''     provide for greater flexibility.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public ReadOnly Property HTMLList() As ArrayList
                Get
                    ' if the arraylist in uninitialized
                    If m_HTMLPatterns.Count() = 0 Then

                        ' retrieve the patterns
                        Dim arrPattern() As String = { _
                            "(?<tag><head[^>]*?\sprofile\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><object[^>]*?\s(?:codebase|data|usemap)\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><img[^>]*?\s(?:src|longdesc|usemap)\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><input[^>]*?\s(?:src|usemap)\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><iframe[^>]*?\s(?:src|longdesc)\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><(?:td|th|table|body)[^>]*?\sbackground\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><(?:script|bgsound|embed|xml|frame)[^>]*?\ssrc\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><(?:base|link|a|area)[^>]*?\shref\s*=\s*"")(?!https://|http://|\\|[~/]|javascript:|mailto:)(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><(?:blockquote|ins|del|q)[^>]*?\scite\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)", _
                            "(?<tag><(?:param\s+name\s*=\s*""(?:movie|src|base)"")[^>]*?\svalue\s*=\s*"")(?!https://|http://|\\|[~/])(?<content>[^""]*)(?<endtag>""[^>]*>)"}

                        ' for each pattern, create a regex object
                        Dim i As Integer
                        For i = 0 To arrPattern.GetLength(0) - 1
                            Dim re As New Regex(arrPattern(i), RegexOptions.Multiline Or RegexOptions.IgnoreCase)
                            ' add the Regex object to the pattern array list
                            m_HTMLPatterns.Add(re)
                        Next
                        ' optimize the arraylist size since it will not change
                        m_HTMLPatterns.TrimToSize()

                    End If

                    Return m_HTMLPatterns

                End Get
            End Property

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     List of regular expressions for processing CSS syntax.
            ''' </summary>
            ''' <returns>ArrayList of Regex objects formatted for the Parser method.</returns>
            ''' <remarks>
            '''     Additional patterns can be added to this list (if necessary) if properly
            '''     formatted to return <tag>, <content> and <endtag> groups.  For future
            '''     consideration, this list could be imported from a configuration file to
            '''     provide for greater flexibility.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public ReadOnly Property CSSList() As ArrayList
                Get
                    ' if the arraylist in uninitialized
                    If m_CSSPatterns.Count() = 0 Then

                        ' retrieve the patterns
                        Dim arrPattern() As String = { _
                            "(?<tag>\surl\u0028)(?<content>[^\u0029]*)(?<endtag>\u0029.*;)"}

                        ' for each pattern, create a regex object
                        Dim i As Integer
                        For i = 0 To arrPattern.GetLength(0) - 1
                            Dim re As New Regex(arrPattern(i), RegexOptions.Multiline Or RegexOptions.IgnoreCase)
                            ' add the Regex object to the pattern array list
                            m_CSSPatterns.Add(re)
                        Next
                        ' optimize the arraylist size since it will not change
                        m_CSSPatterns.TrimToSize()

                    End If

                    Return m_CSSPatterns

                End Get
            End Property

            Private ReadOnly Property Handler() As MatchEvaluator
                Get
                    Return AddressOf MatchHandler
                End Get
            End Property

            Private Property SkinPath() As String
                Get
                    Return m_SkinPath
                End Get
                Set(ByVal Value As String)
                    m_SkinPath = Value
                End Set
            End Property

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     Perform parsing on the specified source file.
            ''' </summary>
            ''' <param name="Source">Pointer to Source string to be parsed.</param>
            ''' <param name="RegexList">ArrayList of properly formatted regular expression objects.</param>
            ''' <param name="SkinPath">Path to use in replacement operation.</param>
            ''' <remarks>
            '''     This procedure iterates through the list of regular expression objects
            '''     and invokes a handler for each match which uses the specified path.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public Function Parse(ByRef Source As String, ByRef RegexList As ArrayList, ByVal SkinPath As String) As String

                m_Messages = ""

                ' set path propery which is file specific
                Me.SkinPath = SkinPath

                ' process each regular expression
                Dim i As Integer
                For i = 0 To RegexList.Count - 1
                    Source = DirectCast(RegexList(i), Regex).Replace(Source, Me.Handler)
                Next

                Return m_Messages

            End Function

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     Process regular expression matches.
            ''' </summary>
            ''' <param name="m">Regular expression match for path information which requires processing.</param>
            ''' <returns>Properly formatted path information.</returns>
            ''' <remarks>
            '''     The handler is invoked by the Regex.Replace method once for each match that
            '''     it encounters.  The returned value of the handler is substituted for the
            '''     original match.  So the handler properly formats the path information and
            '''     returns it in favor of the improperly formatted match.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Private Function MatchHandler(ByVal m As Match) As String
                m_Messages += SkinController.FormatMessage("Substituting", m.Groups("content").Value & "<br>With: " & Me.SkinPath & m.Groups("content").Value, 2, False)
                Return m.Groups("tag").Value & Me.SkinPath & m.Groups("content").Value & m.Groups("endtag").Value
            End Function

        End Class

        ''' -----------------------------------------------------------------------------
        ''' Project	 : PortalQH
        ''' Class	 : SkinFileProcessor.ControlParser
        ''' 
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Parsing functionality for token replacement in new skin files.
        ''' </summary>
        ''' <remarks>
        '''     This class encapsulates the data and methods necessary to appropriately
        '''     handle all the token parsing needs for new skin files (which is appropriate
        '''     only for HTML files).  The parser accomodates some ill formatting of tokens
        '''     (ignoring whitespace and casing) and allows for naming of token instances
        '''     if more than one instance of a particular control is desired on a skin.  The
        '''     proper syntax for an instance is: "[TOKEN_INSTANCE]" where the instance can
        '''     be any alphanumeric string.  Generated control ID's all take the
        '''     form of "TOKENINSTANCE".
        ''' </remarks>
        ''' <history>
        ''' 	[willhsc]	3/3/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Class ControlParser

            Private ReadOnly m_ControlList As New Hashtable
            Private ReadOnly m_InitMessages As String = ""
            Private m_RegisterList As New ArrayList
            Private m_Attributes As New XmlDocument
            Private m_ParseMessages As String = ""

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     Registration directives generated as a result of the Parse method.
            ''' </summary>
            ''' <returns>ArrayList of formatted registration directives.</returns>
            ''' <remarks>
            '''     In addition to the updated file contents, the Parse method also
            '''     creates this list of formatted registration directives which can
            '''     be processed later.  They are not performed in place during the
            '''     Parse method in order to preserve the formatting of the input file
            '''     in case additional parsing might not anticipate the formatting of
            '''     those directives.  Since they are properly formatted, it is better
            '''     to exclude them from being subject to parsing.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public ReadOnly Property Registrations() As ArrayList
                Get
                    Return m_RegisterList
                End Get
            End Property

            Private ReadOnly Property Handler() As MatchEvaluator
                Get
                    Return AddressOf TokenMatchHandler
                End Get
            End Property

            Private Property RegisterList() As ArrayList
                Get
                    Return m_RegisterList
                End Get
                Set(ByVal Value As ArrayList)
                    m_RegisterList = Value
                End Set
            End Property

            Private ReadOnly Property ControlList() As Hashtable
                Get
                    Return m_ControlList
                End Get
            End Property

            Private Property Attributes() As XmlDocument
                Get
                    Return m_Attributes
                End Get
                Set(ByVal Value As XmlDocument)
                    m_Attributes = Value
                End Set
            End Property

            Private Property Messages() As String
                Get
                    Return m_ParseMessages
                End Get
                Set(ByVal Value As String)
                    m_ParseMessages = Value
                End Set
            End Property

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     ControlParser class constructor.
            ''' </summary>
            ''' <param name="SkinObjects">ArrayList of ModuleControlInfo objects known to DNN.</param>
            ''' <remarks>
            '''     The constructor processes accepts a hashtable of skin objects to process against.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public Sub New(ByVal ControlList As Hashtable)

                m_ControlList = DirectCast(ControlList.Clone, Hashtable)

            End Sub

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     Perform parsing on the specified source file using the specified attributes.
            ''' </summary>
            ''' <param name="Source">Pointer to Source string to be parsed.</param>
            ''' <param name="Attributes">XML document containing token attribute information (can be empty).</param>
            ''' <remarks>
            '''     This procedure invokes a handler for each match of a formatted token.
            '''     The attributes are first set because they will be referenced by the
            '''     match handler.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Public Function Parse(ByRef Source As String, ByVal Attributes As XmlDocument) As String

                Me.Messages = m_InitMessages

                ' set the token attributes
                Me.Attributes = Attributes
                ' clear register list
                Me.RegisterList.Clear()

                ' define the regular expression to match tokens
                Dim FindTokenInstance As New Regex("\[\s*(?<token>\w*)\s*:?\s*(?<instance>\w*)\s*]", RegexOptions.IgnoreCase)

                ' parse the file
                Source = FindTokenInstance.Replace(Source, Me.Handler)

                Return Messages

            End Function

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     Process regular expression matches.
            ''' </summary>
            ''' <param name="m">Regular expression match for token which requires processing.</param>
            ''' <returns>Properly formatted token.</returns>
            ''' <remarks>
            '''     The handler is invoked by the Regex.Replace method once for each match that
            '''     it encounters.  The returned value of the handler is substituted for the
            '''     original match.  So the handler properly formats the replacement for the
            '''     token and returns it instead.  If an unknown token is encountered, the token
            '''     is unmodified.  This can happen if a token is used for a skin object which
            '''     has not yet been installed.
            ''' </remarks>
            ''' <history>
            ''' 	[willhsc]	3/3/2004	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
            Private Function TokenMatchHandler(ByVal m As Match) As String

                Dim Token As String = m.Groups("token").Value.ToUpper
                Dim ControlName As String = Token & m.Groups("instance").Value

                ' if the token has an instance name, use it to look for the corresponding attributes
                Dim AttributeNode As String = Token & Convert.ToString(IIf(m.Groups("instance").Value = "", "", ":" & m.Groups("instance").Value))

                Me.Messages += SkinController.FormatMessage("Processing token", "[" & AttributeNode & "]", 2, False)

                ' if the token is a recognized skin control
                If Me.ControlList.ContainsKey(Token) Then

                    Me.Messages += SkinController.FormatMessage("Token is skin object", DirectCast(Me.ControlList.Item(Token), String), 2, False)

                    ' format the inner contents of the control statement
                    Dim SkinControl As String = "dnn:" & ControlName & " runat=""server"" id=""dnn" & ControlName & """"

                    ' if there is an attribute file
                    If Not Me.Attributes.DocumentElement Is Nothing Then
                        ' look for the the node of this instance of the token
                        Dim xmlSkinAttributeRoot As XmlNode = Me.Attributes.DocumentElement.SelectSingleNode("descendant::Object[Token='[" & AttributeNode & "]']")
                        ' if the token is found
                        If Not xmlSkinAttributeRoot Is Nothing Then
                            Me.Messages += SkinController.FormatMessage("Token found in attributes file", "[" & AttributeNode & "]", 2, False)
                            ' process each token attribute
                            Dim xmlSkinAttribute As XmlNode
                            For Each xmlSkinAttribute In xmlSkinAttributeRoot.SelectNodes(".//Settings/Setting")
                                If xmlSkinAttribute.SelectSingleNode("Value").InnerText <> "" Then
                                    ' append the formatted attribute to the inner contents of the control statement
                                    Me.Messages += SkinController.FormatMessage("Formatting token attribute", xmlSkinAttribute.SelectSingleNode("Name").InnerText & "=""" & xmlSkinAttribute.SelectSingleNode("Value").InnerText & """", 2, False)
                                    SkinControl += " " & xmlSkinAttribute.SelectSingleNode("Name").InnerText & "=""" & xmlSkinAttribute.SelectSingleNode("Value").InnerText.Replace("""", "&quot;") & """"
                                End If
                            Next
                        Else
                            Me.Messages += SkinController.FormatMessage("Token NOT found in attributes file", "[" & AttributeNode & "]", 2, False)
                        End If
                    End If

                    ' Save control registration statement
                    RegisterList.Add("<%@ Register TagPrefix=""dnn"" TagName=""" & ControlName & """ Src=""~/" & DirectCast(Me.ControlList.Item(Token), String) & """ %>" & vbCrLf)

                    ' return the control statement
                    Me.Messages += SkinController.FormatMessage("Formatting control statement", "&lt;" & SkinControl & "&gt;", 2, False)
                    Return ("<" & SkinControl & " />")
                Else
                    ' return the unmodified token
                    ' note that this is currently protecting array syntax in embedded javascript
                    ' should be fixed in the regular expressions but is not, currently.
                    Me.Messages += SkinController.FormatMessage("Token not found", "[" & m.Groups("token").Value & "]", 2, False)
                    Return "[" & m.Groups("token").Value & "]"
                End If

            End Function

        End Class

    End Class

End Namespace