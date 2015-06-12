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
Imports System.Globalization

Namespace PortalQH


    '*********************************************************************
    '
    ' AdminDB Class
    '
    ' Class that encapsulates all data logic necessary to add/query/delete
    ' configuration, layout and security settings values within the Portal database.
    '
    '*********************************************************************
    Public Class AdminDB

        Public Function GetHostSetting(ByVal SettingName As String) As IDataReader

            Return DataProvider.Instance().GetHostSetting(SettingName)

        End Function

        Public Sub UpdateHostSetting(ByVal SettingName As String, ByVal SettingValue As String)

            Dim dr As IDataReader = DataProvider.Instance().GetHostSetting(SettingName)
            If dr.Read Then
                DataProvider.Instance().UpdateHostSetting(SettingName, SettingValue)
            Else
                DataProvider.Instance().AddHostSetting(SettingName, SettingValue)
            End If
            dr.Close()

            ' clear host cache
            DataCache.ClearCoreCache(CoreCacheType.Host)

        End Sub

        Public Function GetBillingFrequencyCode(ByVal Code As String) As String

            GetBillingFrequencyCode = ""
            Dim dr As IDataReader = DataProvider.Instance().GetBillingFrequencyCode(Code)
            If dr.Read Then
                GetBillingFrequencyCode = dr("Description").ToString
            End If
            dr.Close()

        End Function

        Public Sub AddSiteLog(ByVal PortalId As Integer, Optional ByVal UserId As String = "", Optional ByVal Referrer As String = "", Optional ByVal URL As String = "", Optional ByVal UserAgent As String = "", Optional ByVal UserHostAddress As String = "", Optional ByVal UserHostName As String = "", Optional ByVal TabId As Integer = -1, Optional ByVal AffiliateId As Integer = -1)

            Dim objSiteLog As New SiteLogController

            objSiteLog.AddSiteLog(PortalId, UserId, Referrer, URL, UserAgent, UserHostAddress, UserHostName, TabId, AffiliateId, 1)

        End Sub

        Public Function ExecuteSQL(ByVal SQL As String) As IDataReader

            Return DataProvider.Instance().ExecuteSQL(SQL)

        End Function

        Public Shared Function InvokePopupCal(ByVal Field As System.Web.UI.WebControls.TextBox) As String

            ' Define character array to trim from language strings
            Dim TrimChars As Char() = {","c, " "c}

            ' Get culture array of month names and convert to string for
            ' passing to the popup calendar
            Dim MonthNameString As String = ""
            Dim Month As String
            For Each Month In DateTimeFormatInfo.CurrentInfo.MonthNames
                MonthNameString += Month & ","
            Next
            MonthNameString = MonthNameString.TrimEnd(TrimChars)

            ' Get culture array of day names and convert to string for
            ' passing to the popup calendar
            Dim DayNameString As String = ""
            Dim Day As String
            For Each Day In DateTimeFormatInfo.CurrentInfo.DayNames
                DayNameString += Day.Substring(0, 3) & ","
            Next
            DayNameString = DayNameString.TrimEnd(TrimChars)

            ' Get the short date pattern for the culture
            'Dim FormatString As String = DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToString
            Dim FormatString As String = "dd/MM/yyyy"


            Return "javascript:popupCal('Cal','" & Field.ClientID & "','" & FormatString & "','" & MonthNameString & "','" & DayNameString & "');"

        End Function

        ' stub included for legacy modules
        Public Sub UpdateModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String, ByVal SettingValue As String)

            Dim objModules As New ModuleController
            objModules.UpdateModuleSetting(ModuleId, SettingName, SettingValue)

        End Sub

    End Class

    Public Class CodeInfo
        Private _Code As String
        Private _Description As String

        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal Value As String)
                _Code = Value
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
    End Class

    Public Class CodeController

        Public Function GetCurrencies() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetCurrencies, GetType(CodeInfo))

        End Function

        Public Function GetBillingFrequencyCodes() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetBillingFrequencyCodes, GetType(CodeInfo))

        End Function


        Public Function GetSiteLogReports() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetSiteLogReports(), GetType(CodeInfo))

        End Function

        Public Function GetProcessorCodes() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetProcessorCodes, GetType(CodeInfo))

        End Function

    End Class

    Public Class ClickLogInfo
        Private _DateTime As Date
        Private _FullName As String

        Public Property DateTime() As Date
            Get
                Return _DateTime
            End Get
            Set(ByVal Value As Date)
                _DateTime = Value
            End Set
        End Property
        Public Property FullName() As String
            Get
                Return _FullName
            End Get
            Set(ByVal Value As String)
                _FullName = Value
            End Set
        End Property

    End Class

    Public Class ClickLogController

        Public Function GetClicks(ByVal TableName As String, ByVal ItemId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetClicks(TableName, ItemId), GetType(ClickLogInfo))

        End Function

        Public Sub UpdateClicks(ByVal TableName As String, ByVal KeyField As String, ByVal ItemId As Integer, Optional ByVal UserId As String = "")

            DataProvider.Instance().UpdateClicks(TableName, KeyField, ItemId, UserId)

        End Sub
    End Class

    Public Class CountryInfo
        Private _Code As String
        Private _Description As String

        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal Value As String)
                _Code = Value
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
    End Class

    Public Class RegionInfo
        Private _Code As String
        Private _Description As String

        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal Value As String)
                _Code = Value
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
    End Class

    Public Class RegionalController
        Public Function GetCountries() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetCountryCodes, GetType(CountryInfo))

        End Function

        Public Function GetCountryByCode(ByVal Code As String) As CountryInfo
            'Geert : Call GetCountry sproc with a dummy value to prevent returning all records when called with empty parameter
            Return CType(DataProvider.Instance().GetCountry(Code, "dummy value"), CountryInfo)

        End Function

        Public Function GetCountryByDescription(ByVal Description As String) As CountryInfo
            'Geert : Call GetCountry sproc with a dummy value to prevent returning all records when called with empty parameter
            Return CType(CBO.FillObject(DataProvider.Instance().GetCountry("dummy value", Description), GetType(CountryInfo)), CountryInfo)

        End Function

        Public Function GetRegionsByCountry(ByVal Country As String) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetRegionCodes(Country), GetType(RegionInfo))

        End Function

        Public Function GetRegionByCode(ByVal Code As String) As RegionInfo
            'Geert : Call GetRegion sproc with a dummy value to prevent returning all records when called with empty parameter
            Return CType(DataProvider.Instance().GetRegion(Code, "dummy value"), RegionInfo)

        End Function

        Public Function GetRegionByDescription(ByVal Description As String) As RegionInfo
            'Geert : Call GetRegion sproc with a dummy value to prevent returning all records when called with empty parameter
            Return CType(CBO.FillObject(DataProvider.Instance().GetRegion("dummy value", Description), GetType(RegionInfo)), RegionInfo)

        End Function

    End Class

End Namespace
