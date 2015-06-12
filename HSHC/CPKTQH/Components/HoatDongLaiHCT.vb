Imports PortalQH
Namespace CPKTQH
    Public Class HoatDongLaiHCTController
        Public Function updHoatDongLai(ByVal pGiayCNDKKDID As String, ByVal pTinhTrangHienTai As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_HoatDongLaiHCT", pGiayCNDKKDID, pTinhTrangHienTai)
        End Function
    End Class
End Namespace