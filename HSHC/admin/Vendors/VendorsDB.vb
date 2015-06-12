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

Namespace PortalQH

    Public Class VendorInfo
        Private _VendorId As Integer
        Private _VendorName As String
        Private _Street As String
        Private _City As String
        Private _Region As String
        Private _Country As String
        Private _PostalCode As String
        Private _Telephone As String
        Private _PortalId As Integer
        Private _Fax As String
        Private _Email As String
        Private _Website As String
        Private _ClickThroughs As Integer
        Private _Views As Integer
        Private _CreatedByUser As String
        Private _CreatedDate As Date
        Private _LogoFile As String
        Private _KeyWords As String
        Private _Unit As String
        Private _Authorized As Boolean
        Private _FirstName As String
        Private _LastName As String
        Private _Banners As Integer
        Private _UserName As String

        Public Sub New()
        End Sub

        Public Property VendorId() As Integer
            Get
                Return _VendorId
            End Get
            Set(ByVal Value As Integer)
                _VendorId = Value
            End Set
        End Property
        Public Property VendorName() As String
            Get
                Return _VendorName
            End Get
            Set(ByVal Value As String)
                _VendorName = Value
            End Set
        End Property
        Public Property Street() As String
            Get
                Return _Street
            End Get
            Set(ByVal Value As String)
                _Street = Value
            End Set
        End Property
        Public Property City() As String
            Get
                Return _City
            End Get
            Set(ByVal Value As String)
                _City = Value
            End Set
        End Property
        Public Property Region() As String
            Get
                Return _Region
            End Get
            Set(ByVal Value As String)
                _Region = Value
            End Set
        End Property
        Public Property Country() As String
            Get
                Return _Country
            End Get
            Set(ByVal Value As String)
                _Country = Value
            End Set
        End Property
        Public Property PostalCode() As String
            Get
                Return _PostalCode
            End Get
            Set(ByVal Value As String)
                _PostalCode = Value
            End Set
        End Property
        Public Property Telephone() As String
            Get
                Return _Telephone
            End Get
            Set(ByVal Value As String)
                _Telephone = Value
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
        Public Property Fax() As String
            Get
                Return _Fax
            End Get
            Set(ByVal Value As String)
                _Fax = Value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
            End Set
        End Property
        Public Property Website() As String
            Get
                Return _Website
            End Get
            Set(ByVal Value As String)
                _Website = Value
            End Set
        End Property
        Public Property ClickThroughs() As Integer
            Get
                Return _ClickThroughs
            End Get
            Set(ByVal Value As Integer)
                _ClickThroughs = Value
            End Set
        End Property
        Public Property Views() As Integer
            Get
                Return _Views
            End Get
            Set(ByVal Value As Integer)
                _Views = Value
            End Set
        End Property
        Public Property CreatedByUser() As String
            Get
                Return _CreatedByUser
            End Get
            Set(ByVal Value As String)
                _CreatedByUser = Value
            End Set
        End Property
        Public Property CreatedDate() As Date
            Get
                Return _CreatedDate
            End Get
            Set(ByVal Value As Date)
                _CreatedDate = Value
            End Set
        End Property
        Public Property LogoFile() As String
            Get
                Return _LogoFile
            End Get
            Set(ByVal Value As String)
                _LogoFile = Value
            End Set
        End Property
        Public Property KeyWords() As String
            Get
                Return _KeyWords
            End Get
            Set(ByVal Value As String)
                _KeyWords = Value
            End Set
        End Property
        Public Property Unit() As String
            Get
                Return _Unit
            End Get
            Set(ByVal Value As String)
                _Unit = Value
            End Set
        End Property
        Public Property Authorized() As Boolean
            Get
                Return _Authorized
            End Get
            Set(ByVal Value As Boolean)
                _Authorized = Value
            End Set
        End Property
        Public Property FirstName() As String
            Get
                Return _FirstName
            End Get
            Set(ByVal Value As String)
                _FirstName = Value
            End Set
        End Property
        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal Value As String)
                _LastName = Value
            End Set
        End Property
        Public Property Banners() As Integer
            Get
                Return _Banners
            End Get
            Set(ByVal Value As Integer)
                _Banners = Value
            End Set
        End Property
        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal Value As String)
                _UserName = Value
            End Set
        End Property
    End Class

    Public Class VendorController

        Public Function GetVendors(Optional ByVal PortalId As Integer = -1, Optional ByVal Filter As String = "") As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetVendors(PortalId, Filter), GetType(VendorInfo))

        End Function

        Public Function GetVendor(ByVal VendorID As Integer) As VendorInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetVendor(VendorID), GetType(VendorInfo)), VendorInfo)

        End Function

        Public Sub DeleteVendor(ByVal VendorID As Integer)

            DataProvider.Instance().DeleteVendor(VendorID)

        End Sub

        Public Function AddVendor(ByVal objVendor As VendorInfo) As Integer

            Return DataProvider.Instance().AddVendor(objVendor.PortalId, objVendor.VendorName, objVendor.Unit, objVendor.Street, objVendor.City, objVendor.Region, objVendor.Country, objVendor.PostalCode, objVendor.Telephone, objVendor.Fax, objVendor.Email, objVendor.Website, objVendor.FirstName, objVendor.LastName, objVendor.UserName, objVendor.LogoFile, objVendor.KeyWords, objVendor.Authorized.ToString)

        End Function


        Public Sub UpdateVendor(ByVal objVendor As VendorInfo)

            DataProvider.Instance().UpdateVendor(objVendor.VendorId, objVendor.VendorName, objVendor.Unit, objVendor.Street, objVendor.City, objVendor.Region, objVendor.Country, objVendor.PostalCode, objVendor.Telephone, objVendor.Fax, objVendor.Email, objVendor.Website, objVendor.FirstName, objVendor.LastName, objVendor.UserName, objVendor.LogoFile, objVendor.KeyWords, objVendor.Authorized.ToString)

        End Sub


        Public Sub DeleteVendors(Optional ByVal PortalID As Integer = -1)

            Dim dr As IDataReader = DataProvider.Instance().GetVendors(PortalID, "%")
            While dr.Read
                If Convert.ToBoolean(dr("Authorized")) = False And DateDiff(DateInterval.Day, Convert.ToDateTime(dr("CreatedDate")), Now()) > 7 Then
                    DataProvider.Instance().DeleteVendor(Convert.ToInt32(dr("VendorID")))
                End If
            End While
            dr.Close()

        End Sub

        Public Function FindVendors(ByVal DisplayPortalId As Integer, ByVal search As String, Optional ByVal SelectPortalId As Integer = -1) As ArrayList

        End Function
    End Class

    Public Class FeedBackInfo
        Private _Value As String
        Private _Comment As String

        Public Sub New()
        End Sub

        Public Property Value() As String
            Get
                Return _Value
            End Get
            Set(ByVal Value As String)
                _Value = Value
            End Set
        End Property

        Public Property Comment() As String
            Get
                Return _Comment
            End Get
            Set(ByVal Value As String)
                _Comment = Value
            End Set
        End Property
    End Class

    Public Class FeedBackController
        Public Function GetVendorFeedback(ByVal VendorID As Integer) As VendorInfo

            'Return CType(CBO.FillObject(DataProvider.Instance().GetVendorFeedback(VendorID), GetType(VendorInfo)), VendorInfo)

        End Function

        Public Function GetSingleVendorFeedback(ByVal VendorID As Integer, ByVal UserID As Integer) As FeedBackInfo

            'Return CType(CBO.FillObject(DataProvider.Instance().GetSingleVendorFeedback(VendorID, UserID), GetType(VendorInfo)), VendorInfo)

        End Function

        Public Sub UpdateVendorFeedback(ByVal VendorID As Integer, ByVal UserID As Integer, ByVal Comment As String, ByVal Value As Integer)

            'DataProvider.Instance().UpdateVendorFeedback(VendorId, UserID, Comment, Value)

        End Sub

        Public Sub DeleteVendorFeedback(ByVal VendorID As Integer, ByVal UserID As Integer)

            'DataProvider.Instance().DeleteVendorFeedback(VendorID, UserID)

        End Sub
    End Class

    Public Class BannerInfo
        Private _BannerId As Integer
        Private _VendorId As Integer
        Private _ImageFile As String
        Private _BannerName As String
        Private _URL As String
        Private _Impressions As Integer
        Private _CPM As Double
        Private _Views As Integer
        Private _ClickThroughs As Integer
        Private _StartDate As Date
        Private _EndDate As Date
        Private _CreatedByUser As String
        Private _CreatedDate As Date
        Private _BannerTypeId As Integer
        Private _BannerTypeName As String


        Public Sub New()
        End Sub

        Public Property BannerId() As Integer
            Get
                Return _BannerId
            End Get
            Set(ByVal Value As Integer)
                _BannerId = Value
            End Set
        End Property
        Public Property VendorId() As Integer
            Get
                Return _VendorId
            End Get
            Set(ByVal Value As Integer)
                _VendorId = Value
            End Set
        End Property
        Public Property ImageFile() As String
            Get
                Return _ImageFile
            End Get
            Set(ByVal Value As String)
                _ImageFile = Value
            End Set
        End Property
        Public Property BannerName() As String
            Get
                Return _BannerName
            End Get
            Set(ByVal Value As String)
                _BannerName = Value
            End Set
        End Property
        Public Property BannerTypeName() As String
            Get
                Return _BannerTypeName
            End Get
            Set(ByVal Value As String)
                _BannerTypeName = Value
            End Set
        End Property
        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
        Public Property Impressions() As Integer
            Get
                Return _Impressions
            End Get
            Set(ByVal Value As Integer)
                _Impressions = Value
            End Set
        End Property
        Public Property CPM() As Double
            Get
                Return _CPM
            End Get
            Set(ByVal Value As Double)
                _CPM = Value
            End Set
        End Property
        Public Property Views() As Integer
            Get
                Return _Views
            End Get
            Set(ByVal Value As Integer)
                _Views = Value
            End Set
        End Property
        Public Property ClickThroughs() As Integer
            Get
                Return _ClickThroughs
            End Get
            Set(ByVal Value As Integer)
                _ClickThroughs = Value
            End Set
        End Property
        Public Property StartDate() As Date
            Get
                Return _StartDate
            End Get
            Set(ByVal Value As Date)
                _StartDate = Value
            End Set
        End Property
        Public Property EndDate() As Date
            Get
                Return _EndDate
            End Get
            Set(ByVal Value As Date)
                _EndDate = Value
            End Set
        End Property
        Public Property CreatedByUser() As String
            Get
                Return _CreatedByUser
            End Get
            Set(ByVal Value As String)
                _CreatedByUser = Value
            End Set
        End Property
        Public Property CreatedDate() As Date
            Get
                Return _CreatedDate
            End Get
            Set(ByVal Value As Date)
                _CreatedDate = Value
            End Set
        End Property
        Public Property BannerTypeId() As Integer
            Get
                Return _BannerTypeId
            End Get
            Set(ByVal Value As Integer)
                _BannerTypeId = Value
            End Set
        End Property
    End Class

    Public Class BannerController


        Public Function GetBanners(ByVal VendorId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetBanners(VendorId), GetType(BannerInfo))

        End Function


        Public Function GetBanner(ByVal BannerId As Integer, ByVal VendorId As Integer) As BannerInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetBanner(BannerId, VendorId), GetType(BannerInfo)), BannerInfo)

        End Function


        Public Sub DeleteBanner(ByVal BannerId As Integer)

            DataProvider.Instance().DeleteBanner(BannerId)

        End Sub


        Public Sub AddBanner(ByVal objBannerInfo As BannerInfo)

            DataProvider.Instance().AddBanner(objBannerInfo.BannerName, objBannerInfo.VendorId, objBannerInfo.ImageFile, objBannerInfo.URL, objBannerInfo.Impressions, objBannerInfo.CPM, objBannerInfo.StartDate, objBannerInfo.EndDate, objBannerInfo.CreatedByUser, objBannerInfo.BannerTypeId)

        End Sub


        Public Sub UpdateBanner(ByVal objBannerInfo As BannerInfo)

            DataProvider.Instance().UpdateBanner(objBannerInfo.BannerId, objBannerInfo.BannerName, objBannerInfo.ImageFile, objBannerInfo.URL, objBannerInfo.Impressions, objBannerInfo.CPM, objBannerInfo.StartDate, objBannerInfo.EndDate, objBannerInfo.CreatedByUser, objBannerInfo.BannerTypeId)

        End Sub

        Public Function LoadBanners(ByVal PortalId As Integer, ByVal BannerTypeId As Integer, ByVal Banners As Integer) As ArrayList

            Dim arrBanners As ArrayList
            Dim objBanner As BannerInfo
            Dim intCounter As Integer
            Dim intViews As Integer
            Dim datStartDate As Date
            Dim datEndDate As Date

            ' get banners
            arrBanners = CBO.FillCollection(DataProvider.Instance().FindBanners(PortalId, BannerTypeId), GetType(BannerInfo))

            ' create collection
            LoadBanners = New ArrayList(Banners)

            If arrBanners.Count > 0 Then

                ' get last index for rotation
                Dim intLastBannerIndex As Integer = 0
                Dim objLastBannerIndex As Object = DataCache.GetCache("LastBannerIndex" & PortalId.ToString & BannerTypeId.ToString)
                If Not objLastBannerIndex Is Nothing Then
                    intLastBannerIndex = Convert.ToInt32(objLastBannerIndex)
                End If

                If Banners > arrBanners.Count Then
                    Banners = arrBanners.Count
                End If

                For intCounter = 1 To Banners
                    intLastBannerIndex += 1
                    If intLastBannerIndex > (arrBanners.Count - 1) Then
                        intLastBannerIndex = 0
                    End If

                    objBanner = CType(arrBanners(intLastBannerIndex), BannerInfo)

                    ' add to collection
                    LoadBanners.Add(objBanner)

                    ' update views
                    If Null.IsNull(objBanner.Views) Then
                        intViews = 1
                    Else
                        intViews = objBanner.Views + 1
                    End If
                    If Null.IsNull(objBanner.StartDate) Then
                        datStartDate = Now
                    Else
                        datStartDate = objBanner.StartDate
                    End If
                    If Null.IsNull(objBanner.EndDate) And intViews = objBanner.Impressions And objBanner.Impressions <> 0 Then
                        datEndDate = Now
                    Else
                        datEndDate = objBanner.EndDate
                    End If
                    DataProvider.Instance().UpdateBannerViews(objBanner.BannerId, intViews, datStartDate, datEndDate)
                Next

                ' save last index for rotation
                DataCache.SetCache("LastBannerIndex" & PortalId.ToString & BannerTypeId.ToString, intLastBannerIndex)

            End If

        End Function

        Public Sub UpdateBannerClickThrough(ByVal BannerId As Integer, ByVal VendorId As Integer)

            DataProvider.Instance().UpdateBannerClickThrough(BannerId, VendorId)

        End Sub

    End Class

    Public Class ClassificationInfo
        Private _ClassificationId As Integer
        Private _ClassificationName As String
        Private _ParentId As Integer
        Private _IsAssociated As Boolean

        Public Sub New()
        End Sub

        Public Property ClassificationId() As Integer
            Get
                Return _ClassificationId
            End Get
            Set(ByVal Value As Integer)
                _ClassificationId = Value
            End Set
        End Property
        Public Property ClassificationName() As String
            Get
                Return _ClassificationName
            End Get
            Set(ByVal Value As String)
                _ClassificationName = Value
            End Set
        End Property
        Public Property ParentId() As Integer
            Get
                Return _ParentId
            End Get
            Set(ByVal Value As Integer)
                _ParentId = Value
            End Set
        End Property
        Public Property IsAssociated() As Boolean
            Get
                Return _IsAssociated
            End Get
            Set(ByVal Value As Boolean)
                _IsAssociated = Value
            End Set
        End Property
    End Class

    Public Class ClassificationController

        Public Function GetVendorClassifications(Optional ByVal VendorId As Integer = -1) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetVendorClassifications(VendorId), GetType(ClassificationInfo))

        End Function


        Public Sub DeleteVendorClassifications(ByVal VendorId As Integer)

            DataProvider.Instance().DeleteVendorClassifications(VendorId)

        End Sub


        Public Sub AddVendorClassification(ByVal VendorId As Integer, ByVal ClassificationId As Integer)

            DataProvider.Instance().AddVendorClassification(VendorId, ClassificationId)

        End Sub
    End Class

    Public Class BannerTypeInfo
        Private _BannerTypeId As Integer
        Private _BannerTypeName As String

        Public Sub New()
        End Sub

        Public Property BannerTypeId() As Integer
            Get
                Return _BannerTypeId
            End Get
            Set(ByVal Value As Integer)
                _BannerTypeId = Value
            End Set
        End Property

        Public Property BannerTypeName() As String
            Get
                Return _BannerTypeName
            End Get
            Set(ByVal Value As String)
                _BannerTypeName = Value
            End Set
        End Property
    End Class

    Public Class BannerTypeController
        Public Function GetBannerTypes() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetBannerTypes, GetType(BannerTypeInfo))

        End Function
    End Class

    Public Class AffiliateInfo
        Private _AffiliateId As Integer
        Private _VendorId As Integer
        Private _StartDate As Date
        Private _EndDate As Date
        Private _CPC As Double
        Private _Clicks As Integer
        Private _CPCTotal As Double
        Private _CPA As Double
        Private _Acquisitions As Integer
        Private _CPATotal As Double

        Public Sub New()
        End Sub

        Public Property AffiliateId() As Integer
            Get
                Return _AffiliateId
            End Get
            Set(ByVal Value As Integer)
                _AffiliateId = Value
            End Set
        End Property
        Public Property VendorId() As Integer
            Get
                Return _VendorId
            End Get
            Set(ByVal Value As Integer)
                _VendorId = Value
            End Set
        End Property
        Public Property StartDate() As Date
            Get
                Return _StartDate
            End Get
            Set(ByVal Value As Date)
                _StartDate = Value
            End Set
        End Property
        Public Property EndDate() As Date
            Get
                Return _EndDate
            End Get
            Set(ByVal Value As Date)
                _EndDate = Value
            End Set
        End Property
        Public Property CPC() As Double
            Get
                Return _CPC
            End Get
            Set(ByVal Value As Double)
                _CPC = Value
            End Set
        End Property
        Public Property Clicks() As Integer
            Get
                Return _Clicks
            End Get
            Set(ByVal Value As Integer)
                _Clicks = Value
            End Set
        End Property
        Public Property CPCTotal() As Double
            Get
                Return _CPCTotal
            End Get
            Set(ByVal Value As Double)
                _CPCTotal = Value
            End Set
        End Property
        Public Property CPA() As Double
            Get
                Return _CPA
            End Get
            Set(ByVal Value As Double)
                _CPA = Value
            End Set
        End Property
        Public Property Acquisitions() As Integer
            Get
                Return _Acquisitions
            End Get
            Set(ByVal Value As Integer)
                _Acquisitions = Value
            End Set
        End Property
        Public Property CPATotal() As Double
            Get
                Return _CPATotal
            End Get
            Set(ByVal Value As Double)
                _CPATotal = Value
            End Set
        End Property
    End Class

    Public Class AffiliateController
        Public Function GetAffiliates(ByVal VendorId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetAffiliates(VendorId), GetType(AffiliateInfo))

        End Function


        Public Function GetAffiliate(ByVal AffiliateId As Integer, ByVal VendorId As Integer) As AffiliateInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetAffiliate(AffiliateId, VendorId), GetType(AffiliateInfo)), AffiliateInfo)

        End Function


        Public Sub DeleteAffiliate(ByVal AffiliateId As Integer)

            DataProvider.Instance().DeleteAffiliate(AffiliateId)

        End Sub


        Public Sub AddAffiliate(ByVal objAffiliate As AffiliateInfo)

            DataProvider.Instance().AddAffiliate(objAffiliate.VendorId, objAffiliate.StartDate, objAffiliate.EndDate, objAffiliate.CPC, objAffiliate.CPA)

        End Sub


        Public Sub UpdateAffiliate(ByVal objAffiliate As AffiliateInfo)

            DataProvider.Instance().UpdateAffiliate(objAffiliate.AffiliateId, objAffiliate.StartDate, objAffiliate.EndDate, objAffiliate.CPC, objAffiliate.CPA)

        End Sub


        Public Sub UpdateAffiliateStats(ByVal AffiliateId As Integer, ByVal Clicks As Integer, ByVal Acquisitions As Integer)

            DataProvider.Instance().UpdateAffiliateStats(AffiliateId, Clicks, Acquisitions)

        End Sub
    End Class

End Namespace

