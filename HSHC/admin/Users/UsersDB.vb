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

    Public Class UserInfo
        Private _UserID As String
        Private _FullName As String
        Private _Street As String
        Private _City As String
        Private _Region As String
        Private _PostalCode As String
        Private _Country As String
        Private _Password As String
        Private _Email As String
        Private _Unit As String
        Private _IsSuperUser As Boolean
        Private _Telephone As String
        Private _Name As String
        Private _LastLoginDate As Date
        Private _Authorized As Boolean
        Private _CreatedDate As Date
        'ngantl them
        Private _MaChucDanh As String
        Private _MaPhongBan As String

        Public Sub New()
        End Sub
        Public Property MaChucDanh() As String
            Get
                Return _MaChucDanh
            End Get
            Set(ByVal Value As String)
                _MaChucDanh = Value
            End Set
        End Property
        Public Property MaPhongBan() As String
            Get
                Return _MaPhongBan
            End Get
            Set(ByVal Value As String)
                _MaPhongBan = Value
            End Set
        End Property
        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
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
        Public Property PostalCode() As String
            Get
                Return _PostalCode
            End Get
            Set(ByVal Value As String)
                _PostalCode = Value
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
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal Value As String)
                _Password = Value
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
        Public Property Unit() As String
            Get
                Return _Unit
            End Get
            Set(ByVal Value As String)
                _Unit = Value
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
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal Value As String)
                _Name = Value
            End Set
        End Property
        Public Property IsSuperUser() As Boolean
            Get
                Return _IsSuperUser
            End Get
            Set(ByVal Value As Boolean)
                _IsSuperUser = Value
            End Set
        End Property
        Public Property LastLoginDate() As Date
            Get
                Return _LastLoginDate
            End Get
            Set(ByVal Value As Date)
                _LastLoginDate = Value
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
        Public Property CreatedDate() As Date
            Get
                Return _CreatedDate
            End Get
            Set(ByVal Value As Date)
                _CreatedDate = Value
            End Set
        End Property

    End Class

    Public Enum UserRegistrationStatus
        AddUser = 0
        AddPortalUser = -1
        UsernameAlreadyExists = -2
        UserAlreadyRegistered = -3
        UnexpectedError = -4
    End Enum

    Public Class UserController

        Public Function AddUser(ByVal PortalId As Integer, ByVal FullName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal PostalCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Username As String, ByVal Password As String, ByVal Authorized As Boolean, ByVal AffiliateId As Integer, ByVal ChucDanh As String, ByVal PhongBan As String) As String

            Dim UserId As String = ""
            Dim Status As UserRegistrationStatus

            Try
                Dim objRoles As New RoleController
                Dim objRole As RoleInfo
                Dim objUsers As UserController
                Dim objUser As UserInfo

                ' check if username exists in database for any portal
                objUser = GetUserByUsername(Null.NullInteger, Username)
                If Not objUser Is Nothing Then
                    ' the username exists but the user registering may not be the same person
                    If objUser.Password = Password Then
                        ' the specified password matches the password on file
                        UserId = objUser.UserID

                        ' check if user exists for the portal specified
                        objUser = GetUserByUsername(PortalId, Username)
                        If Not objUser Is Nothing Then
                            ' the user is already registered for this portal
                            Status = UserRegistrationStatus.UserAlreadyRegistered
                        Else
                            ' the user does not exist in this portal - add them
                            Status = UserRegistrationStatus.AddPortalUser
                        End If
                    Else
                        ' not the same person - prevent registration
                        Status = UserRegistrationStatus.UsernameAlreadyExists
                    End If
                Else
                    ' the user does not exist
                    Status = UserRegistrationStatus.AddUser
                End If

                If Status = UserRegistrationStatus.AddUser Then
                    ' add the user
                    UserId = DataProvider.Instance().AddUser(FullName, Unit, Street, City, Region, PostalCode, Country, Telephone, Email, Username, Password, AffiliateId, ChucDanh, PhongBan)
                    ' set the status to add the user to the portal
                    Status = UserRegistrationStatus.AddPortalUser
                End If

                If Status = UserRegistrationStatus.AddPortalUser Then

                    ' add user to portal specified
                    objUser = CType(CBO.FillObject(DataProvider.Instance().GetUser(PortalId, UserId), GetType(UserInfo)), UserInfo)
                    If objUser Is Nothing Then
                        DataProvider.Instance().AddPortalUser(PortalId, UserId, Authorized)
                    End If

                    ' autoassign user to portal roles
                    Dim arrRoles As ArrayList = CBO.FillCollection(DataProvider.Instance().GetPortalRoles(PortalId), GetType(RoleInfo))
                    Dim i As Integer
                    For i = 0 To arrRoles.Count - 1
                        objRole = CType(arrRoles(i), RoleInfo)
                        If objRole.AutoAssignment = True Then
                            objRoles.AddUserRole(PortalId, UserId, objRole.RoleID, Null.NullDate)
                        End If
                    Next

                End If

            Catch ' an unexpected error occurred

                Status = UserRegistrationStatus.UnexpectedError

            End Try

            ' if there were registration problems then return the error status
            'If Status <> UserRegistrationStatus.AddPortalUser Then
            '    UserId = Status
            'End If

            Return UserId

        End Function

        Public Function DeleteUser(ByVal PortalId As Integer, ByVal UserId As String) As Boolean

            Dim CanDelete As Boolean = True
            Dim dr As IDataReader

            dr = DataProvider.Instance().GetPortal(PortalId)
            If dr.Read Then
                If UserId = CType(dr("AdministratorId"), String) Then
                    CanDelete = False
                End If
            End If
            dr.Close()

            If CanDelete Then
                DataProvider.Instance().DeletePortalUser(PortalId, UserId)

                dr = DataProvider.Instance().GetRolesByUser(UserId, PortalId)
                While dr.Read
                    DataProvider.Instance().DeleteUserRole(UserId, Convert.ToInt32(dr("RoleId")))
                End While
                dr.Close()

                dr = DataProvider.Instance().GetUserPortals(UserId)
                If Not dr.Read Then
                    DataProvider.Instance().DeleteUser(UserId)
                End If
                dr.Close()
            End If

        End Function


        Public Sub DeleteUsers(ByVal PortalId As Integer)

            Dim dr As IDataReader = DataProvider.Instance().GetUsers(PortalId, "%")
            While dr.Read
                If IsDBNull(dr("CreatedDate")) = False Then
                    If (Convert.ToBoolean(dr("Authorized")) = False Or IsDBNull(dr("LastLoginDate")) = True) And DateDiff(DateInterval.Day, Convert.ToDateTime(dr("CreatedDate")), Now()) > 7 Then
                        DataProvider.Instance().DeleteUser(CType(dr("UserId"), String))
                    End If
                End If
            End While
            dr.Close()

        End Sub


        Public Function ChangePassword(ByVal UserName As String, ByVal OldPassword As String, ByVal NewPassword As String) As IDataReader

            Return DataProvider.Instance().ChangePassword(UserName, OldPassword, NewPassword)

        End Function

        Public Sub UpdateUser(ByVal PortalId As Integer, ByVal UserId As String, ByVal FullName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal PostalCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Username As String, ByVal Password As String, ByVal Authorized As Boolean, ByVal ChucDanh As String, ByVal PhongBan As String)

            'error from this Check out
            DataProvider.Instance().UpdateUser(UserId, FullName, Unit, Street, City, Region, PostalCode, Country, Telephone, Email, Username, Password, ChucDanh, PhongBan)


            Dim dr As IDataReader = DataProvider.Instance().GetPortalUser(PortalId, UserId)
            If dr.Read Then
                Dim LastLoginDate As Date
                If Not dr("LastLoginDate") Is DBNull.Value Then
                    LastLoginDate = Date.Parse(dr("LastLoginDate").ToString)
                Else
                    LastLoginDate = Convert.ToDateTime(Null.SetNull(LastLoginDate))
                End If
                DataProvider.Instance().UpdatePortalUser(PortalId, UserId, Authorized, LastLoginDate)
            End If
            dr.Close()

        End Sub


        Public Function UpdateUserLogin(ByVal UserId As String, ByVal PortalId As Integer, ByVal SuperUserId As String) As Boolean


            If UserId <> SuperUserId Then
                ' validate user in portal
                UpdateUserLogin = False
                Dim dr As IDataReader = DataProvider.Instance().GetPortalUser(PortalId, UserId)
                If dr.Read Then
                    UpdateUserLogin = Convert.ToBoolean(dr("Authorized"))
                End If
                dr.Close()

                ' update last login
                If UpdateUserLogin Then
                    DataProvider.Instance().UpdatePortalUser(PortalId, UserId, UpdateUserLogin, Now)
                End If
            Else
                UpdateUserLogin = True
            End If

        End Function


        Public Function GetUsers(Optional ByVal PortalId As Integer = -1, Optional ByVal Filter As String = "") As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetUsers(PortalId, Filter), GetType(UserInfo))

        End Function

        'Public Function GetUsersDataSet(Optional ByVal PortalId As Integer = -1, Optional ByVal Filter As String = "") As DataSet

        '    Return DataProvider.Instance().ExecuteQueryStoreProc("sp_GetUsers", PortalId, Filter)

        'End Function

        Public Function GetUsersDataSet(Optional ByVal PortalId As Integer = -1, Optional ByVal Filter As String = "", Optional ByVal Noidung As String = "", Optional ByVal HinhThuc As String = "0") As DataSet

            Return DataProvider.Instance().GetUsersDataSet(PortalId, Filter, Noidung, HinhThuc)

        End Function




        Public Function GetUser(ByVal PortalId As Integer, ByVal UserId As String) As UserInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetUser(PortalId, UserId), GetType(UserInfo)), UserInfo)

        End Function

        Public Function GetRoleMembership(ByVal PortalId As Integer, Optional ByVal RoleId As Integer = -1, Optional ByVal UserId As String = "") As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetRoleMembership(PortalId, RoleId, UserId), GetType(UserRoleInfo))

        End Function

        Public Function GetUserByUsername(ByVal PortalID As Integer, ByVal Username As String) As UserInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetUserByUsername(PortalID, Username), GetType(UserInfo)), UserInfo)

        End Function
        Public Function getDMChucDanh() As DataSet
            Return DataProvider.Instance.GetDMChucDanh()
        End Function
        Public Function getDMPhongBan() As DataSet
            Return DataProvider.Instance.GetDMPhongBan()
        End Function
        Public Function GetUsersRole(ByVal PortalId As Integer, Optional ByVal RoleId As Integer = -1, Optional ByVal UserId As String = "") As DataSet
            'Return CBO.FillCollection(DataProvider.Instance().GetRoleMembership(PortalId, RoleId, UserId), GetType(UserRoleInfo))
            Return DataProvider.Instance().ExecuteQueryStoreProc("GetRoleMembership", RoleId, UserId)
        End Function
    End Class

    Public Class UserRoleInfo
        Inherits RoleInfo
        Private _UserRoleID As Integer
        Private _UserID As String
        Private _FullName As String
        Private _Email As String
        Private _ExpiryDate As Date
        Private _Subscribed As Boolean

        Public Property UserRoleID() As Integer
            Get
                Return _UserRoleID
            End Get
            Set(ByVal Value As Integer)
                _UserRoleID = Value
            End Set
        End Property
        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
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
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
            End Set
        End Property
        Public Property ExpiryDate() As Date
            Get
                Return _ExpiryDate
            End Get
            Set(ByVal Value As Date)
                _ExpiryDate = Value
            End Set
        End Property

        Public Property Subscribed() As Boolean
            Get
                Return _Subscribed
            End Get
            Set(ByVal Value As Boolean)
                _Subscribed = Value
            End Set
        End Property

    End Class

    Public Class RoleInfo
        Private _RoleID As Integer
        Private _PortalID As Integer
        Private _RoleName As String
        Private _Description As String
        Private _ServiceFee As Single
        Private _BillingFrequency As String
        Private _TrialPeriod As Integer
        Private _TrialFrequency As String
        Private _BillingPeriod As Integer
        Private _TrialFee As Single
        Private _IsPublic As Boolean
        Private _AutoAssignment As Boolean

        Public Property RoleID() As Integer
            Get
                Return _RoleID
            End Get
            Set(ByVal Value As Integer)
                _RoleID = Value
            End Set
        End Property
        Public Property PortalID() As Integer
            Get
                Return _PortalID
            End Get
            Set(ByVal Value As Integer)
                _PortalID = Value
            End Set
        End Property
        Public Property RoleName() As String
            Get
                Return _RoleName
            End Get
            Set(ByVal Value As String)
                _RoleName = Value
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
        Public Property BillingFrequency() As String
            Get
                Return _BillingFrequency
            End Get
            Set(ByVal Value As String)
                _BillingFrequency = Value
            End Set
        End Property
        Public Property ServiceFee() As Single
            Get
                Return _ServiceFee
            End Get
            Set(ByVal Value As Single)
                _ServiceFee = Value
            End Set
        End Property
        Public Property TrialFrequency() As String
            Get
                Return _TrialFrequency
            End Get
            Set(ByVal Value As String)
                _TrialFrequency = Value
            End Set
        End Property
        Public Property TrialPeriod() As Integer
            Get
                Return _TrialPeriod
            End Get
            Set(ByVal Value As Integer)
                _TrialPeriod = Value
            End Set
        End Property
        Public Property BillingPeriod() As Integer
            Get
                Return _BillingPeriod
            End Get
            Set(ByVal Value As Integer)
                _BillingPeriod = Value
            End Set
        End Property
        Public Property TrialFee() As Single
            Get
                Return _TrialFee
            End Get
            Set(ByVal Value As Single)
                _TrialFee = Value
            End Set
        End Property
        Public Property IsPublic() As Boolean
            Get
                Return _IsPublic
            End Get
            Set(ByVal Value As Boolean)
                _IsPublic = Value
            End Set
        End Property
        Public Property AutoAssignment() As Boolean
            Get
                Return _AutoAssignment
            End Get
            Set(ByVal Value As Boolean)
                _AutoAssignment = Value
            End Set
        End Property

    End Class

    Public Class RoleController
        Public Function GetRolesByUser(ByVal UserId As String, ByVal PortalId As Integer) As String()

            Dim userRoles As New ArrayList
            '???
            Dim dr As IDataReader = DataProvider.Instance().GetRolesByUser(UserId, PortalId)
            While dr.Read()
                userRoles.Add(dr("RoleId").ToString)
            End While
            dr.Close()

            Return CType(userRoles.ToArray(GetType(String)), String())

        End Function

        Public Function GetPortalRoles(ByVal PortalId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetPortalRoles(PortalId), GetType(RoleInfo))

        End Function

        Public Function GetRole(ByVal RoleID As Integer) As RoleInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetRole(RoleID), GetType(RoleInfo)), RoleInfo)

        End Function


        Public Function AddRole(ByVal objRoleInfo As RoleInfo) As Integer

            Dim RoleId As Integer = -1

            RoleId = DataProvider.Instance().AddRole(objRoleInfo.PortalID, objRoleInfo.RoleName, objRoleInfo.Description, objRoleInfo.ServiceFee, objRoleInfo.BillingPeriod.ToString, objRoleInfo.BillingFrequency, objRoleInfo.TrialFee, objRoleInfo.TrialPeriod, objRoleInfo.TrialFrequency, objRoleInfo.IsPublic, objRoleInfo.AutoAssignment)

            If objRoleInfo.AutoAssignment Then
                ' loop through users for portal and add to role
                '???
                Dim dr As IDataReader = DataProvider.Instance().GetPortalUsers(objRoleInfo.PortalID)
                While dr.Read
                    Try
                        DataProvider.Instance().AddUserRole(objRoleInfo.PortalID, CType(dr("UserId"), String), RoleId, Null.NullDate)
                    Catch ex As Exception
                        ' user already belongs to role
                    End Try
                End While
                dr.Close()
            End If

            Return RoleId

        End Function


        Public Sub DeleteRole(ByVal RoleId As Integer)

            DataProvider.Instance().DeleteRole(RoleId)

        End Sub


        Public Sub UpdateRole(ByVal objRoleInfo As RoleInfo)

            DataProvider.Instance().UpdateRole(objRoleInfo.RoleID, objRoleInfo.RoleName, objRoleInfo.Description, objRoleInfo.ServiceFee, objRoleInfo.BillingPeriod.ToString, objRoleInfo.BillingFrequency, objRoleInfo.TrialFee, objRoleInfo.TrialPeriod, objRoleInfo.TrialFrequency, objRoleInfo.IsPublic, objRoleInfo.AutoAssignment)

            If objRoleInfo.AutoAssignment Then
                Dim dr As IDataReader = DataProvider.Instance().GetPortalUsers(objRoleInfo.PortalID)
                While dr.Read
                    Try
                        DataProvider.Instance().AddUserRole(objRoleInfo.PortalID, CType(dr("UserId"), String), objRoleInfo.RoleID, Null.NullDate)
                    Catch
                        ' user role already exists
                    End Try
                End While
                dr.Close()
            End If

        End Sub

        Public Function IsUserInRole(ByVal UserId As String, ByVal RoleId As Integer, ByVal PortalId As Integer) As Boolean

            IsUserInRole = False

            Dim dr As IDataReader = DataProvider.Instance().IsUserInRole(UserId, RoleId, PortalId)
            If dr.Read Then
                If Not IsDBNull(dr("UserID")) Then
                    IsUserInRole = True
                End If
            End If
            dr.Close()

        End Function


        Public Sub AddUserRole(ByVal PortalID As Integer, _
                                ByVal UserId As String, ByVal RoleId As Integer, _
                                ByVal ExpiryDate As Date, _
                                Optional ByVal Authorized As Boolean = True)

            Dim UserRoleId As Integer = -1
            'CBO
            Dim dr As IDataReader = DataProvider.Instance().GetUserRole(PortalID, UserId, RoleId)
            If dr.Read Then
                DataProvider.Instance().UpdateUserRole(Convert.ToInt32(dr("UserRoleId")), ExpiryDate)
            Else
                DataProvider.Instance().AddPortalUser(PortalID, UserId, Authorized)
                DataProvider.Instance().AddUserRole(PortalID, UserId, RoleId, ExpiryDate)
            End If
            dr.Close()

        End Sub


        Public Function DeleteUserRole(ByVal PortalId As Integer, ByVal UserId As String, ByVal RoleId As Integer) As Boolean

            Dim objPortals As New PortalController
            Dim blnDelete As Boolean = True

            Dim objPortal As PortalInfo = objPortals.GetPortal(PortalId)
            If Not objPortal Is Nothing Then
                If (objPortal.AdministratorId <> UserId Or objPortal.AdministratorRoleId <> RoleId) And objPortal.RegisteredRoleId <> RoleId Then
                    DataProvider.Instance().DeleteUserRole(UserId, RoleId)
                Else
                    blnDelete = False
                End If
            End If

            Return blnDelete

        End Function


        Public Function GetServices(ByVal PortalId As Integer, Optional ByVal UserId As String = "") As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetServices(PortalId, UserId), GetType(UserRoleInfo))

        End Function


        Public Sub UpdateService(ByVal PortalId As Integer, ByVal UserId As String, ByVal RoleId As Integer, Optional ByVal Cancel As Boolean = False)

            If Cancel Then
                DataProvider.Instance().DeleteUserRole(UserId, RoleId)
            Else
                Dim dr As IDataReader

                Dim UserRoleId As Integer = -1
                Dim ExpiryDate As Date = Now
                Dim IsTrialUsed As Boolean = False
                Dim Period As Integer
                Dim Frequency As String

                dr = DataProvider.Instance().GetUserRole(PortalId, UserId, RoleId)
                If dr.Read Then
                    UserRoleId = Convert.ToInt32(dr("UserRoleId"))
                    If Not IsDBNull(dr("ExpiryDate")) Then
                        ExpiryDate = Convert.ToDateTime(dr("ExpiryDate"))
                    End If
                    If Not IsDBNull(dr("IsTrialUsed")) Then
                        IsTrialUsed = Convert.ToBoolean(dr("IsTrialUsed"))
                    End If
                End If
                dr.Close()

                dr = DataProvider.Instance().GetRole(RoleId)
                If dr.Read Then
                    If IsTrialUsed = False And dr("TrialFrequency").ToString <> "N" Then
                        Period = Convert.ToInt32(dr("TrialPeriod"))
                        Frequency = dr("TrialFrequency").ToString
                    Else
                        Period = Convert.ToInt32(dr("BillingPeriod"))
                        Frequency = dr("BillingFrequency").ToString
                    End If
                End If
                dr.Close()

                If ExpiryDate < Now Then
                    ExpiryDate = Now
                End If

                Select Case Frequency
                    Case "N" : ExpiryDate = Null.NullDate
                    Case "O" : ExpiryDate = New System.DateTime(9999, 12, 31)
                    Case "D" : ExpiryDate = DateAdd(DateInterval.Day, Period, Convert.ToDateTime(ExpiryDate))
                    Case "W" : ExpiryDate = DateAdd(DateInterval.Day, (Period * 7), Convert.ToDateTime(ExpiryDate))
                    Case "M" : ExpiryDate = DateAdd(DateInterval.Month, Period, Convert.ToDateTime(ExpiryDate))
                    Case "Y" : ExpiryDate = DateAdd(DateInterval.Year, Period, Convert.ToDateTime(ExpiryDate))
                End Select

                If UserRoleId <> -1 Then
                    DataProvider.Instance().UpdateUserRole(UserRoleId, ExpiryDate)
                Else
                    DataProvider.Instance().AddUserRole(PortalId, UserId, RoleId, ExpiryDate)
                End If
            End If

        End Sub
        
    End Class

End Namespace
