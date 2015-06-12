Option Strict Off
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Drawing.Font
Imports PortalQH

Namespace CPXD

    Public Class TiepNhanHoSoController
        '============================================================================================'
        '======================Khai bao bien su dung cho phan format to barcode======================'
        Const N As Integer = &H0&
        Const DEFAULT_COLOR As Integer = &H0&
        Dim W As Color
        '=============================================End============================================'
        '============================================================================================'
        Public Function GetDMHoSoKemTheo(ByVal pMaLoaiHoSo As String, ByVal pHoSoTiepNhanID As String, ByVal pMaLinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDMHoSoKemTheo", pMaLoaiHoSo, pHoSoTiepNhanID, pMaLinhVuc)
        End Function
        Public Function getSoNgayQuiDinh(ByVal pMaLoaiHoSo As String, ByVal pMaLinhVuc As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_getSoNgayGiaiQuyet", pMaLoaiHoSo, pMaLinhVuc)
        End Function
        Public Function GetChiTietHoSoTiepNhan(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getChiTietHoSoTiepNhan", pID)
        End Function
        Public Function UpdHoSoTiepNhan(ByVal obj As Object) As String
            'return "" khong thanh cong <> hosotiepnhanid thanh cong
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHoSoTiepNhan", obj)
        End Function
        Public Sub UpdTraHoSo(ByVal pID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_updTraHoSo", pID)
        End Sub
        Public Function AddHoSoKemTheo(ByVal pSoBanChinh As String, ByVal pSoBanSao As String, _
                                    ByVal pHoSoTiepNhanID As String, ByVal pMaHoSoKemTheo As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_updHoSoKemTheo", pSoBanChinh, pSoBanSao, pHoSoTiepNhanID, pMaHoSoKemTheo)
        End Function
        Public Function DelHoSoKemTheo(ByVal pHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_delHoSoKemTheo", pHoSoTiepNhanID)
        End Function
        '=========================================End NganTL========================================'
        Public Function GetThongTinChungHoSoTiepNhan(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetThongTinChungHoSoTiepNhan", pID)
        End Function
        Public Function GetChuDauTuByHSID(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetChuDauTuByHSID", pID)
        End Function
        Public Function AddChuDauTuByHSID(ByVal pID As Object, ByVal HoTen As Object, ByVal NgaySinh As Object, ByVal GioiTinh As Object, ByVal SoCMND As Object, ByVal NoiCapCMND As Object, ByVal NgayCapCMND As Object, ByVal DienThoai As Object, ByVal Fax As Object, ByVal Email As Object, ByVal NoiDKTT As Object) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_InsChuDauTuByHSID", pID, HoTen, NgaySinh, GioiTinh, SoCMND, NoiCapCMND, NgayCapCMND, DienThoai, Fax, Email, NoiDKTT)
        End Function
        Public Function UpdChuDauTu(ByVal pID As Object, ByVal HoTen As Object, ByVal NgaySinh As Object, ByVal GioiTinh As Object, ByVal SoCMND As Object, ByVal NoiCapCMND As Object, ByVal NgayCapCMND As Object, ByVal DienThoai As Object, ByVal Fax As Object, ByVal Email As Object, ByVal NoiDKTT As Object) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_UpdChuDauTu", pID, HoTen, NgaySinh, GioiTinh, SoCMND, NoiCapCMND, NgayCapCMND, DienThoai, Fax, Email, NoiDKTT)
        End Function
        Public Function DelChuDauTu(ByVal pID As Object) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelChuDauTu", pID)
        End Function
        '**********************************************************************************************************'
        '***************************************Define barcode tu so bien nhan*************************************'
        '****************So Bien Nhan duoc dinh dang theo : AAAABBBBCCDDDDDDDDDD***********************************'
        '****************Trong do AAAA      : Nam        ( vi du 2004 )********************************************'
        '****************Trong do BBBB      : Linh vuc   ( vi du SDND )********************************************'
        '****************Trong do CC        : Loai ho so ( vi du 01 )**********************************************'
        '****************Trong do DDDDDDDDDD: So tu sinh ( vi du 0000000001 )**************************************'
        '**********************************************************************************************************'

        Public Function FormatToBarCode(ByVal mSoBNhan As String, ByVal mLoaiBarCode As String) As String
            Dim Sequencia As Object
            Dim i As Integer
            Dim Total As Integer
            Dim DigitoDeControl As Integer

            mSoBNhan = Mid(mSoBNhan, 4, mSoBNhan.Length())
            mSoBNhan = mSoBNhan.Substring(0, 1) & mLoaiBarCode & mSoBNhan.Substring(5, 7)

            If mSoBNhan.Length() < 13 Then
                Dim str As String = ""
                For i = 1 To 12 - mSoBNhan.Length()
                    str = str & "0"
                Next
                mSoBNhan = str & mSoBNhan
            Else
                mSoBNhan = Mid(mSoBNhan, 1, 12)
            End If

            Sequencia = New Object() {13, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3}

            For i = 1 To 12
                Total = Total + Mid(mSoBNhan, i, 1) * Sequencia(i)
            Next i

            DigitoDeControl = IIf(Right(Total, 1) = 0, 0, 10 - Val(Right(Total, 1)))

            FormatToBarCode = mSoBNhan & DigitoDeControl
            Return FormatToBarCode
        End Function
        Public Function FormatToBNhan(ByVal mBarcode As String, ByVal mLoaiCP As String) As String
            FormatToBNhan = ""
            mBarcode = "200" & mBarcode
            mBarcode = Mid(mBarcode, 1, 4) & mLoaiCP & Mid(mBarcode, 9, 7)
            FormatToBNhan = mBarcode
            Return FormatToBNhan
        End Function
        Public Function ColorLinea(ByVal Digito As Integer, ByVal Numero As Integer, ByVal Posicion As Integer, ByVal NumeroLinea As Integer) As Object
            Dim Sequencia As Object
            Dim SequenciaColor As Object
            Dim Tipo As Integer
            Dim N As Integer = &H0&
            Dim W As Color = System.Drawing.Color.White

            Select Case Digito
                Case 0
                    Sequencia = New Object() {12, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3, 3, 3}
                Case 1
                    Sequencia = New Object() {12, 1, 1, 2, 1, 2, 2, 3, 3, 3, 3, 3, 3}
                Case 2
                    Sequencia = New Object() {12, 1, 1, 2, 2, 1, 2, 3, 3, 3, 3, 3, 3}
                Case 3
                    Sequencia = New Object() {12, 1, 1, 2, 2, 2, 1, 3, 3, 3, 3, 3, 3}
                Case 4
                    Sequencia = New Object() {12, 1, 2, 1, 1, 2, 2, 3, 3, 3, 3, 3, 3}
                Case 5
                    Sequencia = New Object() {12, 1, 2, 2, 1, 1, 2, 3, 3, 3, 3, 3, 3}
                Case 6
                    Sequencia = New Object() {12, 1, 2, 2, 2, 1, 1, 3, 3, 3, 3, 3, 3}
                Case 7
                    Sequencia = New Object() {12, 1, 2, 1, 2, 1, 2, 3, 3, 3, 3, 3, 3}
                Case 8
                    Sequencia = New Object() {12, 1, 2, 1, 2, 2, 1, 3, 3, 3, 3, 3, 3}
                Case 9
                    Sequencia = New Object() {12, 1, 2, 2, 1, 2, 1, 3, 3, 3, 3, 3, 3}
            End Select

            Tipo = Sequencia(Posicion)

            Select Case Numero
                Case 0
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, W, W, N, N, W, N}
                        Case 2
                            SequenciaColor = New Object() {7, W, N, W, W, N, N, N}
                        Case 3
                            SequenciaColor = New Object() {7, N, N, N, W, W, N, W}
                    End Select
                Case 1
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, W, N, N, W, W, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, N, N, W, W, N, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, N, W, W, N, N, W}
                    End Select
                Case 2
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, W, N, W, W, N, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, W, N, N, W, N, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, N, W, N, N, W, W}
                    End Select
                Case 3
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, N, N, N, N, W, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, N, W, W, W, W, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, W, W, W, W, N, W}
                    End Select
                Case 4
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, N, W, W, W, N, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, W, N, N, N, W, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, W, N, N, N, W, W}
                    End Select
                Case 5
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, N, N, W, W, W, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, W, N, N, W, W, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, W, W, N, N, N, W}
                    End Select
                Case 6
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, N, W, N, N, N, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, W, W, W, N, W, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, W, N, W, W, W, W}
                    End Select
                Case 7
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, N, N, N, W, N, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, W, N, W, W, W, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, W, W, W, N, W, W}
                    End Select
                Case 8
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, N, N, W, N, N, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, W, W, N, W, W, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, W, W, N, W, W, W}
                    End Select
                Case 9
                    Select Case Tipo
                        Case 1
                            SequenciaColor = New Object() {7, W, W, W, N, W, N, N}

                        Case 2
                            SequenciaColor = New Object() {7, W, W, N, W, N, N, N}

                        Case 3
                            SequenciaColor = New Object() {7, N, N, N, W, N, W, W}
                    End Select

            End Select
            ColorLinea = SequenciaColor(NumeroLinea)

        End Function
        Public Sub CreateBarCode(ByVal mSoBienNhan As String, ByVal mLoaiBarCode As String, _
                                    ByVal mFileTemplate As String, ByVal mFileExport As String)

            Dim X As Integer, x1, y1 As Integer, Columna As Integer, NumeroDeGrupo As Integer, Grupo As Integer
            Dim Inicial As Integer, Resto As String, NNumero As Integer, PPosicion As Integer
            Dim Begin_Top As Integer = 5
            Dim Begin_Left As Integer = 10
            Dim Bspace As Single = 1.0  'khoang cach giua 2 vach
            Dim mImage As Image = mImage.FromFile(mFileTemplate)
            Dim objDraw As Graphics = Graphics.FromImage(mImage)
            Dim objPen As New System.Drawing.Pen(Color.Black, 1.3)
            Dim LineColor As Object
            Dim W As Color
            Dim HightL As Integer = 50 '30  do dai moi vach
            Dim HightS As Integer = 40 '24  do rong moi vach
            Dim strFontName As String = "MS Sans Serif"
            Dim X0 As Integer = Begin_Left
            Dim Y0 As Integer = Begin_Top
            Dim mstrBarCode As String
            Try
                mstrBarCode = FormatToBarCode(mSoBienNhan, mLoaiBarCode)
                W = System.Drawing.Color.White  'ok
                Inicial = Mid(mstrBarCode, 1, 1)    'ok
                Resto = Mid(mstrBarCode, 2, 12) 'ok
                've line 1
                X = X0
                objDraw.DrawLine(objPen, X, Y0, X, Y0 + HightL)
                've line 2
                X += Bspace * 2
                objDraw.DrawLine(objPen, X, Y0, X, Y0 + HightL)
                'write chu dau tien
                If Inicial <> "0" Then
                    x1 = X - Bspace * 2 - 8
                    y1 = Y0 + HightS + Bspace * 2 / 3
                    objDraw.DrawString(Inicial, New Font(strFontName, 8, FontStyle.Regular), SystemBrushes.ControlDarkDark, x1, y1)
                End If
                For Grupo = 1 To 2
                    Select Case Grupo
                        Case 1
                            X = X0 + (Bspace * 2) '  165 toa do vach dau tien cua Grupo 1
                        Case 2
                            X = X0 + (Bspace * 7) + (6 * 7 * Bspace)    'toa do vach dau tien cua Grupo 2
                    End Select
                    've 6 so trong Grupo
                    For NumeroDeGrupo = 1 To 6
                        PPosicion = IIf(Grupo = 1, NumeroDeGrupo, NumeroDeGrupo + 6)
                        NNumero = IIf(Grupo = 1, Mid(Resto, NumeroDeGrupo, 1), Mid(Resto, NumeroDeGrupo + 6, 1))
                        've vach cua so
                        For Columna = 1 To 7
                            If Columna = 1 Then
                                Dim intCol As Integer
                                Dim intRow As Integer
                                If Grupo = 1 Then intCol = X Else intCol = X
                                intRow = Y0 + HightS + Bspace * 2 / 3
                                objPen.Color = Color.Black
                                'write so o vach dau tien
                                objDraw.DrawString(NNumero, New Font(strFontName, 8, FontStyle.Regular), SystemBrushes.ControlDarkDark, intCol, intRow)
                            End If
                            LineColor = ColorLinea(Inicial, NNumero, PPosicion, Columna)
                            If LineColor.GetType.Name = "Color" Then
                                objPen.Color = LineColor
                            Else
                                objPen.Color = Color.Black
                            End If
                            've vach
                            objDraw.DrawLine(objPen, X + (Bspace * Columna), Y0, X + (Bspace * Columna), Y0 + HightS)
                        Next Columna
                        X = (X + (7 * Bspace))
                    Next NumeroDeGrupo
                    Select Case Grupo
                        Case 1  've 2 cuoi nhom 1
                            objPen.Color = Color.Black
                            objDraw.DrawLine(objPen, X + Bspace * 2, Y0, X + Bspace * 2, Y0 + HightS + CType(((HightL - HightS) / 2), Integer))
                            objDraw.DrawLine(objPen, X + Bspace * 4, Y0, X + Bspace * 4, Y0 + HightS + CType(((HightL - HightS) / 2), Integer))
                        Case 2  've 2 cuoi nhom 2=2 duong cuoi
                            objPen.Color = Color.Black
                            objDraw.DrawLine(objPen, X + Bspace, Y0, X + Bspace, Y0 + HightL)
                            objDraw.DrawLine(objPen, X + Bspace * 3, Y0, X + Bspace * 3, Y0 + HightL)
                    End Select
                Next Grupo
            Catch exp As Exception
                Throw New Exception
            End Try
            objDraw.Save()
            mImage.Save(mFileExport)
        End Sub
        '***********************************************End barcode************************************************'

    End Class

End Namespace

