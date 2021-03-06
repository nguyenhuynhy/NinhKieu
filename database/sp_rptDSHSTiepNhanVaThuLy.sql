USE [FSSHSHCQH]
GO
/****** Object:  StoredProcedure [dbo].[sp_rptDSHSTiepNhanVaThuLy]    Script Date: 04/14/2015 15:23:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


/*
	*
	* Nguoi tao : TuanNH
	* Ngay tao  : 26/09/2007
	* Mo ta     : Bao cao danh sach ho so tiep nhan va thu ly
	*
*/
ALTER   procedure [dbo].[sp_rptDSHSTiepNhanVaThuLy]  
(  
 @pTabID nvarchar(5)='',  
 @pUserID nvarchar(20)='',  
 @pMaLinhVuc nvarchar(20) = '',  
 @pTuNgay nvarchar(10) = '',  
 @pDenNgay nvarchar(10) = '',   
 @pLoaiHoSo nvarchar(5) = ''  
)  
as  
BEGIN  
  if	@pLoaiHoSo <> '' AND @pLoaiHoSo is not null
select upper(dbo.f_GetParam('','TinhThanh')) as TinhThanh,   
  upper(dbo.f_GetParam('','CongTy'))  as CongTy, 
   upper(dbo.f_GetParam('','VanPhong'))  as VanPhong, 
   upper(dbo.f_GetParam('','PhongBan'))  as PhongBan, 
   @pMaLinhVuc  as LVBaoCao, LoaiBaoCao = '', TuNgay = @pTuNgay ,
  DenNgay= @pDenNgay , 
  LV.TenLinhVuc, substring(h.SoBienNhan,10,7) SoBienNhan, h.HoTenNguoiNop HoTen, 
   h.SoNha , d.TenDuong , p.TenDonVi DiaChi, l.TenLoaiHoSo, 
   convert(nvarchar,h.NgayNhan,103) NgayNhanHS, convert(nvarchar,h.NgayHenTra,103) NgayHenTra,tt.TenTinhTrang TinhTrang 
  
FROM DMLINHVUC LV 
  left join HOSOTIEPNHAN h on LV.MaLinhVuc=h.MaLinhVuc AND h.LienThong IS null
  left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong 
  left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
  left join DMLOAIHOSO l on h.MaLoaiHoSo = l.MaLoaiHoSo and h.MaLinhVuc = l.MaLinhVuc 
  left join DMTINHTRANGHOSO tt on tt.MaTinhTrang = h.MaTinhTrang and tt.MaLinhVuc = h.MaLinhVuc
  
WHERE 1=1  and LV.MaLinhVuc= @pMaLinhVuc and LV.MaLinhVuc in (SELECT ItemCode 
        FROM MENU WHERE tabcode=  @pTabID  and 
        (@pUserID =2 or (MenuID in (select MenuID from MENU_USER where UserID = @pUserID  or  @pUserID is null ) and @pUserID <> 2)) 
        And isnumeric(ItemCode)=0)
        and h.NgayNhan between convert(datetime,@pTuNgay ,103) and convert(datetime,@pDenNgay ,103)
        AND h.MaLoaiHoSo = @pLoaiHoSo 
else
select upper(dbo.f_GetParam('','TinhThanh')) as TinhThanh,   
  upper(dbo.f_GetParam('','CongTy'))  as CongTy, 
   upper(dbo.f_GetParam('','VanPhong'))  as VanPhong, 
   upper(dbo.f_GetParam('','PhongBan'))  as PhongBan, 
   @pMaLinhVuc  as LVBaoCao, LoaiBaoCao = '', TuNgay = @pTuNgay ,
  DenNgay= @pDenNgay , 
  LV.TenLinhVuc, substring(h.SoBienNhan,10,7) SoBienNhan, h.HoTenNguoiNop HoTen, 
   h.SoNha , d.TenDuong , p.TenDonVi DiaChi, l.TenLoaiHoSo, 
   convert(nvarchar,h.NgayNhan,103) NgayNhanHS, convert(nvarchar,h.NgayHenTra,103) NgayHenTra,tt.TenTinhTrang TinhTrang 
  
FROM DMLINHVUC LV 
  left join HOSOTIEPNHAN h on LV.MaLinhVuc=h.MaLinhVuc AND h.LienThong IS null
  left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong 
  left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
  left join DMLOAIHOSO l on h.MaLoaiHoSo = l.MaLoaiHoSo and h.MaLinhVuc = l.MaLinhVuc 
  left join DMTINHTRANGHOSO tt on tt.MaTinhTrang = h.MaTinhTrang and tt.MaLinhVuc = h.MaLinhVuc
  
WHERE 1=1  and LV.MaLinhVuc= @pMaLinhVuc and LV.MaLinhVuc in (SELECT ItemCode 
        FROM MENU WHERE tabcode=  @pTabID  and 
        (@pUserID =2 or (MenuID in (select MenuID from MENU_USER where UserID = @pUserID  or  @pUserID is null ) and @pUserID <> 2)) 
        And isnumeric(ItemCode)=0)
        and h.NgayNhan between convert(datetime,@pTuNgay ,103) and convert(datetime,@pDenNgay ,103)


END


