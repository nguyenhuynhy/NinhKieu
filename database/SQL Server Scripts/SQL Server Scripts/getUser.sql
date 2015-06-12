SELECT * from Users us join DMDONVI dv on dv.MaDonVi = us.MaPhongBan

exec sp_getReportInfo @pMaLinhVuc=N'HSNV',@pTabCode=N'1001',@pItemCode=N'1'