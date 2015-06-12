
'---------------------------------
' Coded by Viên Hoàng Tuấn Anh
' Created Date : 04/04/2005
'---------------------------------

Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports PortalQH

Namespace PortalQH

    Public Class ComboFilter
        Inherits System.Web.UI.Control
        Implements IPostBackDataHandler


        Public Property ConditionID() As String
            Get
                Return CStr(ViewState("sConditionID" & Me.ID))
            End Get
            Set(ByVal Value As String)
                ViewState("sConditionID" & Me.ID) = Value
            End Set
        End Property

        Public Property ConditionValue() As String
            Get
                Return CStr(ViewState("sConditionValue" & Me.ID))
            End Get
            Set(ByVal Value As String)
                ViewState("sConditionValue" & Me.ID) = Trim(Value)
            End Set
        End Property

        Public Property ConditionText() As String
            Get
                Return CStr(ViewState("sConditionText" & Me.ID))
            End Get
            Set(ByVal Value As String)
                ViewState("sConditionText" & Me.ID) = Trim(Value)
            End Set
        End Property

        Public Property ConditionDS() As DataSet
            Get
                Return CType(ViewState("dsCondition" & Me.ID), DataSet)
            End Get
            Set(ByVal Value As DataSet)
                ViewState("dsCondition" & Me.ID) = Value
            End Set
        End Property

        Public Property ResultID() As String
            Get
                Return CStr(ViewState("sResultID" & Me.ID))
            End Get
            Set(ByVal Value As String)
                ViewState("sResultID" & Me.ID) = Value
            End Set
        End Property

        Public Property ResultValue() As String
            Get
                Return CStr(ViewState("sResultValue" & Me.ID))
            End Get
            Set(ByVal Value As String)
                ViewState("sResultValue" & Me.ID) = Trim(Value)
            End Set
        End Property

        Public Property ResultText() As String
            Get
                Return CStr(ViewState("sResultText" & Me.ID))
            End Get
            Set(ByVal Value As String)
                ViewState("sResultText" & Me.ID) = Trim(Value)
            End Set
        End Property

        Public Property ResultDS() As DataSet
            Get
                Return CType(ViewState("dsResult" & Me.ID), DataSet)
            End Get
            Set(ByVal Value As DataSet)
                ViewState("dsResult" & Me.ID) = Value
            End Set
        End Property

        Private Function BuildScript() As String
            Dim _script As String

            If Not IsNothing(ConditionDS) And Not IsNothing(ResultDS) Then
                _script &= BuildScriptCondition()
                _script &= BuildScriptResult()
                _script &= BuildScriptFunction()
            End If

            Return _script

        End Function


        Private Function BuildScriptCondition() As String
            Dim _script As String

            _script &= "var Condition" & Me.ID & "  = new Array(2);"
            _script &= "Condition" & Me.ID & "[0] = new Array(" & CStr(ConditionDS.Tables(0).Rows.Count) & ");"
            _script &= "Condition" & Me.ID & "[1] = new Array(" & CStr(ConditionDS.Tables(0).Rows.Count) & ");"
            _script &= "Condition" & Me.ID & "[0][0]='';"
            _script &= "Condition" & Me.ID & "[1][0]='';"

            Dim i As Integer
            For i = 0 To ConditionDS.Tables(0).Rows.Count - 1
                _script &= "Condition" & Me.ID & "[0][" & i & "] = '" & ConditionDS.Tables(0).Rows(i).Item(ConditionValue).ToString & "';"
                _script &= "Condition" & Me.ID & "[1][" & i & "] = '" & ConditionDS.Tables(0).Rows(i).Item(ConditionText).ToString & "';"
            Next

            Return _script
        End Function

        Private Function BuildScriptResult() As String
            Dim _script As String

            _script &= "var Result" & Me.ID & "  = new Array(" & CStr(ResultDS.Tables(0).Rows.Count) & ");"
            _script &= "Result" & Me.ID & "[0] = new Array(" & CStr(ResultDS.Tables(0).Rows.Count) & ");"
            _script &= "Result" & Me.ID & "[1] = new Array(" & CStr(ResultDS.Tables(0).Rows.Count) & ");"
            _script &= "Result" & Me.ID & "[2] = new Array(" & CStr(ResultDS.Tables(0).Rows.Count) & ");"
            _script &= "Result" & Me.ID & "[0][0]='';"
            _script &= "Result" & Me.ID & "[1][0]='';"
            _script &= "Result" & Me.ID & "[2][0]='';"

            Dim i As Integer
            For i = 0 To ResultDS.Tables(0).Rows.Count - 1
                _script &= "Result" & Me.ID & "[0][" & i & "] = '" & ResultDS.Tables(0).Rows(i).Item(ResultValue).ToString & "';"
                _script &= "Result" & Me.ID & "[1][" & i & "] = '" & ResultDS.Tables(0).Rows(i).Item(ResultText).ToString & "';"
                _script &= "Result" & Me.ID & "[2][" & i & "] = '" & ResultDS.Tables(0).Rows(i).Item(ConditionValue).ToString & "';"
            Next

            Return _script
        End Function

        Private Function BuildScriptFunction() As String
            Dim _script As String
            _script &= vbCrLf & "function ComboFilter" & Me.ID & "(allRecords){" & vbCrLf
            _script &= "var all = document.all(""" & ResultID & """).length; " & vbCrLf
            _script &= "var MaDieuKien;" & vbCrLf
            _script &= "for (i=0;i<all;i++) document.all(""" & ResultID & """).remove(0);" & vbCrLf
            _script &= "document.all(""" & ResultID & """).add(new Option('', ''));" & vbCrLf
            _script &= "MaDieuKien = document.all(""" & ConditionID & """).value;" & vbCrLf
            'nếu điều kiện là '' thì hiển thị hết tất cả record
            _script &= "if (MaDieuKien == '' && allRecords=='1') {" & vbCrLf
            _script &= "var j, flag;" & vbCrLf
            _script &= "for (i=0;i<" & ResultDS.Tables(0).Rows.Count & ";i++){ " & vbCrLf
            _script &= "flag = 0;" & vbCrLf
            _script &= "for (j=i + 1; j<" & ResultDS.Tables(0).Rows.Count & ";j++)" & vbCrLf
            _script &= "if (Result" & Me.ID & "[0][i]==Result" & Me.ID & "[0][j]){ flag=1; break;} " & vbCrLf
            _script &= "if (flag==0) document.all(""" & ResultID & """).add(new Option(Result" & Me.ID & "[1][i], Result" & Me.ID & "[0][i]));" & vbCrLf
            _script &= "}" & vbCrLf
            _script &= "}" & vbCrLf
            'ngược lại chỉ hiển thị các record tương ứng với MaDieuKien
            _script &= "else {" & vbCrLf
            _script &= "for (i=0;i<" & ResultDS.Tables(0).Rows.Count & ";i++) " & vbCrLf
            _script &= "if (Result" & Me.ID & "[2][i]==MaDieuKien) document.all(""" & ResultID & """).add(new Option(Result" & Me.ID & "[1][i], Result" & Me.ID & "[0][i]));" & vbCrLf
            _script &= "}" & vbCrLf
            _script &= "}"
            Return _script
        End Function

        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            If Not (Page Is Nothing) Then
                Page.RegisterRequiresPostBack(Me)
            End If
        End Sub 'OnInit

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not Page.IsClientScriptBlockRegistered("ScriptFilter" & Me.ID) Then
                Page.RegisterClientScriptBlock("ScriptFilter" & Me.ID, String.Format("<script language=""JavaScript"">{0}</script>", BuildScript))
            End If
        End Sub 'OnPreRender

        Public Function LoadPostData(ByVal postDataKey As String, ByVal postCollection As System.Collections.Specialized.NameValueCollection) As Boolean Implements System.Web.UI.IPostBackDataHandler.LoadPostData

        End Function

        Public Sub RaisePostDataChangedEvent() Implements System.Web.UI.IPostBackDataHandler.RaisePostDataChangedEvent

        End Sub
    End Class

End Namespace