USE [FSSHSHCQH]
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKeLoaiHoSoPhuong]    Script Date: 02/04/2015 15:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-------------------------------------------------------------------
	alterd by Thuytt
	Date 25/10/2004
	sp_ThongKeLoaiHoSo 'CPKT','01/01/2003','01/01/2005'
	exec sp_ThongKeLoaiHoSoPhuong @pLinhVuc = N'CPCT', @pTuNgay = N'01/06/2012', @pDenNgay = N'19/06/2012', @pNguoiXemBaoCao='host',@pMaPhuong=''
  -------------------------------------------------------------------*/
ALTER      procedure [dbo].[sp_ThongKeLoaiHoSoPhuong]
(
	@pLinhVuc nvarchar(5) = '',
	@pTuNgay nvarchar(10) = '',
	@pDenNgay nvarchar(10) = '',
	@pNguoiXemBaoCao NVARCHAR(50)='',
	@pMaPhuong nvarchar(10)=''
)
as
BEGIN
	DECLARE @pLayMaPhuong_User NVARCHAR(50)
	SET @pLayMaPhuong_User = dbo.f_GetUserInfo(@pNguoiXemBaoCao,'MaPhongBan')
	---------------------------------------------------
	--Nguoi xem bao cao khac tai khoan Host, Admin
	---------------------------------------------------
	IF @pNguoiXemBaoCao NOT IN ('host','admin','hieutt','duytm','trannth')
	BEGIN
		select lhs.TenLoaiHoSo,lhs.MaLoaiHoSo,
		SUM(isnull(MoiNhan,0)-isnull(DaHuy,0)) as TongNhan,
		SUM(isnull(NgayThuBay,0)) as NgayThuBay,
		SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) as TongDaGiaiQuyet,
		SUM(isnull(DaGQTruocHan,0)) as DaGQTruocHan,
		CAST(ROUND(100.0*SUM(isnull(DaGQTruocHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2)) as TyLeTruocHan,	
		SUM(isnull(DaGQDungHan,0)) as DaGQDungHan,
		CAST(ROUND(100.0*SUM(isnull(DaGQDungHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2)) as TyLeDungHan,	
		SUM(isnull(DaGQQuaHan,0)) as DaGQQuaHan,
		100 - 
		case ((CAST(ROUND(100.0*SUM(isnull(DaGQTruocHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))
		+ CAST(ROUND(100.0*SUM(isnull(DaGQDungHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))))
		when 0 then 100 else
		((CAST(ROUND(100.0*SUM(isnull(DaGQTruocHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))
		+ CAST(ROUND(100.0*SUM(isnull(DaGQDungHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))))
		 end as TyLeQuaHan,
		SUM(isnull(ChuaGQTrongHan,0)+ISNULL(BoTucHoSo,0)+ISNULL(ChuaGQQuaHan,0)) as ChuaGQTrongHan,
		'' GhiChu		 
		,@pMaPhuong as MaPhuong
		from (select * from DMLOAIHOSO where used='1' ) lhs 
		left join (
			--ton truoc
			select MaLoaiHoSo,count(distinct(HoSoTiepNhanID)) TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai, 0 DaGQDungHan, 
			0 DaGQQuaHan, 0 ChuaGQTrongHan, 0 ChuaGQQuaHan, 0 NgayThuBay, 0 DaGQTruocHan
			from HOSOTIEPNHAN hs
			where MaLinhVuc=@pLinhVuc 
				and MaTinhTrang is NOT NULL 
				AND LienThong ='1' AND MaPhuong=@pLayMaPhuong_User 
				and datediff(dy,NgayNhan,convert(datetime,@pTuNgay,103) )>0
				and MaTinhTrang not in ('CCV','DTN','CCVP', 'DTNP', 'DTD','DTDP','HUYP','HUY') 
			group by MaLoaiHoSo 
			
			--nhan trong ky
			union 
			select MaLoaiHoSo,0 TonTruoc,count(distinct(HoSoTiepNhanID)) MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
				0 DaGQDungHan,0 DaGQQuaHan,0 ChuaGQTrongHan,0 ChuaGQQuaHan, 0 NgayThuBay, 0 DaGQTruocHan
			from HOSOTIEPNHAN hs
 			where matinhtrang is not null
				AND LienThong ='1' 
				AND MaPhuong=@pLayMaPhuong_User
				and MaLinhVuc=@pLinhVuc 
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0 
			group by MaLoaiHoSo 
			
			--huy trong ky
			union 
			select hs.MaLoaiHoSo,0 TonTruoc,0 MoiNhan,
				count(distinct(hs.HoSoTiepNhanID)) DaHuy, 0 BoTucHoSo, 0 ConLai,0 DaGQDungHan,0 DaGQQuaHan,0 ChuaGQTrongHan,0 ChuaGQQuaHan,
				0 NgayThuBay, 0 DaGQTruocHan
			from HOSOTIEPNHAN hs
 			where hs.MaLinhVuc=@pLinhVuc 
				AND LienThong ='1' 
				AND MaPhuong=@pLayMaPhuong_User
				and hs.MaTinhTrang in ('HUYP','HUY')
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0				
				and MaTinhTrang is not null
			group by MaLoaiHoSo 

			-- BoTucHoSo
			union 
			select MaLoaiHoSo,0 TonTruoc,0 MoiNhan, 0 DaHuy, count(HoSoTiepNhanID) BoTucHoSo, 0 ConLai,
				0 DaGQDungHan,0 DaGQQuaHan,0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan
				
			from HOSOTIEPNHAN hs
 			where MaTinhTrang in ('BHSP', 'YBSP','YBS','BHS') and MaTinhTrang is not null
				AND LienThong = '1'
				AND MaPhuong=@pLayMaPhuong_User
				and MaLinhVuc=@pLinhVuc 
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
			group by MaLoaiHoSo 

			
			--da giai quyet  truoc  han
			union all 
			select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
				0 DaGQDungHan,0 DaGQQuaHan, 0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, count(hs.HoSoTiepNhanID) DaGQTruocHan
			from HOSOTIEPNHAN hs 
			left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and hs.HoSoTiepNhanID = tt.HoSoTiepNhanID )					
			where hs.MaLinhVuc=@pLinhVuc 
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0 
				and tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 
				AND LienThong ='1' 
				AND MaPhuong=@pLayMaPhuong_User
				and datediff(dy, tths.NgayTacNghiep, hs.NgayHenTra) > 0 
--				and MaLoaiHoSo in (
--						select MaLoaiHoSo
--						from DMLOAIHOSO
--						where MaLinhVuc = hs.MaLinhVuc  
--							and Used = 1
--					)
			group by hs.MaLoaiHoSo 
			

			--da giai quyet dung han--?TH ngung KD
			union all 
			select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
				count(hs.HoSoTiepNhanID) DaGQDungHan,0 DaGQQuaHan, 0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan			 
			from HOSOTIEPNHAN hs 
			left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and hs.HoSoTiepNhanID = tt.HoSoTiepNhanID )					
			where hs.MaLinhVuc=@pLinhVuc 
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0 
				and tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 
				AND LienThong ='1' 
				AND MaPhuong=@pLayMaPhuong_User
				and datediff(dy, tths.NgayTacNghiep, hs.NgayHenTra) = 0 
--				and MaLoaiHoSo in (
--						select MaLoaiHoSo
--						from DMLOAIHOSO
--						where MaLinhVuc = hs.MaLinhVuc  
--							and Used = 1
--					)
			group by hs.MaLoaiHoSo 

			--da giai quyet nhung qua han-?TH ngung KD
			union all 
			select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
				0 DaGQDungHan,count(hs.HoSoTiepNhanID) DaGQQuaHan, 0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan			
			
			from HOSOTIEPNHAN hs 
			left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and hs.HoSoTiepNhanID = tt.HoSoTiepNhanID )					
			where MaLinhVuc=@pLinhVuc 
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0 
				and tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 
				AND LienThong = '1' 
				AND MaPhuong=@pLayMaPhuong_User
				and datediff(dy, tths.NgayTacNghiep, hs.NgayHenTra) < 0 
--				and MaLoaiHoSo in (
--						select MaLoaiHoSo
--						from DMLOAIHOSO
--						where MaLinhVuc = hs.MaLinhVuc  
--							and Used = 1
--					)
			group by hs.MaLoaiHoSo 

			--chua giai quyet trong han-?TH ngung KD
			union all 
			select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
				0 DaGQDungHan,0 DaGQQuaHan, count(HoSoTiepNhanID) ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan		
			from HOSOTIEPNHAN hs
			where MaLinhVuc=@pLinhVuc 
				and MaTinhTrang is NOT NULL
				AND LienThong ='1' 
				AND MaPhuong=@pLayMaPhuong_User
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0 
				and MaTinhTrang not in ('DTN','CCV','CCVP','DTNP','DTDP','DTD','BHSP','BHS','HUYP','YBS','HUY','TDXP')
				and NgayHenTra >= convert(datetime,@pDenNgay,103)
--				and MaLoaiHoSo in (
--						select MaLoaiHoSo
--						from DMLOAIHOSO
--						where MaLinhVuc = hs.MaLinhVuc  
--							and Used = 1
--					) 
			group by MaLoaiHoSo 

			--chua giai quyet qua han-?TH ngung KD
			union all 
			select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
				0 DaGQDungHan,0 DaGQQuaHan, 0 ChuaGQTrongHan,count(HoSoTiepNhanID) ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan
			from HOSOTIEPNHAN hs
			where MaLinhVuc=@pLinhVuc 
				and MaTinhTrang is NOT NULL
				AND LienThong ='1' 
				AND MaPhuong=@pLayMaPhuong_User
				and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
				and MaTinhTrang not in ('DTN','CCV','CCVP','DTNP','DTDP','DTD','BHSP','BHS','HUYP','YBS','HUY','TDXP')				
				and NgayHenTra < convert(datetime,@pDenNgay,103) 
--				and MaLoaiHoSo in (
--						select MaLoaiHoSo
--						from DMLOAIHOSO
--						where MaLinhVuc = hs.MaLinhVuc  
--							and Used = 1
--					)
			group by MaLoaiHoSo 
			
		) a on a.MaLoaiHoSo=lhs.MaLoaiHoSo 
	where lhs.MaLinhVuc=@pLinhVuc
	group by lhs.TenLoaiHoSo, lhs.MaLoaiHoSo
	order by lhs.TenLoaiHoSo
	
	END
	
---------------------------------------------------------
-- Neu nguoi xem bao cao la host hoac admin
---------------------------------------------------------
	IF @pNguoiXemBaoCao IN ('host','admin','hieutt','duytm','trannth')
	BEGIN
		
				select lhs.TenLoaiHoSo,lhs.MaLoaiHoSo,
				SUM(isnull(MoiNhan,0)-isnull(DaHuy,0)) as TongNhan,
				SUM(isnull(NgayThuBay,0)) as NgayThuBay,
				SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) as TongDaGiaiQuyet,
				SUM(isnull(DaGQTruocHan,0)) as DaGQTruocHan,
				CAST(ROUND(100.0*SUM(isnull(DaGQTruocHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2)) as TyLeTruocHan,	
				SUM(isnull(DaGQDungHan,0)) as DaGQDungHan,
				CAST(ROUND(100.0*SUM(isnull(DaGQDungHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2)) as TyLeDungHan,	
				SUM(isnull(DaGQQuaHan,0)) as DaGQQuaHan,
				100 - 
				case ((CAST(ROUND(100.0*SUM(isnull(DaGQTruocHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))
				+ CAST(ROUND(100.0*SUM(isnull(DaGQDungHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))))
				when 0 then 100 else
				((CAST(ROUND(100.0*SUM(isnull(DaGQTruocHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))
				+ CAST(ROUND(100.0*SUM(isnull(DaGQDungHan,0))/case SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) when 0 then 1 else 1.0*SUM((isnull(DaGQTruocHan,0)+isnull(DaGQDungHan,0)+isnull(DaGQQuaHan,0))) end,2) AS numeric(36,2))))
				 end as TyLeQuaHan,
				SUM(isnull(ChuaGQTrongHan,0)+ISNULL(BoTucHoSo,0)+ISNULL(ChuaGQQuaHan,0)) as ChuaGQTrongHan,
				'' GhiChu  
				,@pMaPhuong as MaPhuong
				from (select * from DMLOAIHOSO where used='1' ) lhs 
				
				left join (
					--ton truoc
					select MaLoaiHoSo,count(distinct(HoSoTiepNhanID)) TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai, 0 DaGQDungHan, 
						0 DaGQQuaHan, 0 ChuaGQTrongHan, 0 ChuaGQQuaHan, 0 NgayThuBay, 0 DaGQTruocHan
					from HOSOTIEPNHAN 
					where MaLinhVuc=@pLinhVuc 
						and MaTinhTrang is NOT NULL 
						AND MaPhuong=@pMaPhuong
						AND LienThong ='1' 
						and datediff(dy,NgayNhan,convert(datetime,@pTuNgay,103) )>0
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and MaTinhTrang not in ('CCV','DTN','CCVP', 'DTNP', 'DTD','HUYP','HUY','DTDP')
					group by MaLoaiHoSo 
					--nhan trong ky
					union 
					select MaLoaiHoSo,0 TonTruoc,count(distinct(HoSoTiepNhanID)) MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
						0 DaGQDungHan,0 DaGQQuaHan,0 ChuaGQTrongHan,0 ChuaGQQuaHan, 0 NgayThuBay, 0 DaGQTruocHan
					from HOSOTIEPNHAN hs
 					where matinhtrang is not null
						AND LienThong ='1'
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and MaLinhVuc=@pLinhVuc 
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
					group by MaLoaiHoSo 
					--huy trong ky
					union 
					select hs.MaLoaiHoSo,0 TonTruoc,0 MoiNhan,
						count(hs.HoSoTiepNhanID) DaHuy, 0 BoTucHoSo, 0 ConLai,0 DaGQDungHan,0 DaGQQuaHan,0 ChuaGQTrongHan,0 ChuaGQQuaHan,
						0 DaTra,0 ChuaTra , 0 ChuyenQuan, 0 NhanVePhuong, 0 LienThongTraDan
					from HOSOTIEPNHAN hs
 					where hs.MaLinhVuc=@pLinhVuc 
						AND LienThong ='1'
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and hs.MaTinhTrang in ('HUYP','HUY')
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
						and MaTinhTrang is not null
					group by MaLoaiHoSo 

					-- BoTucHoSo
					union 
					select MaLoaiHoSo,0 TonTruoc,0 MoiNhan, 0 DaHuy, count(HoSoTiepNhanID) BoTucHoSo, 0 ConLai,
				0 DaGQDungHan,0 DaGQQuaHan,0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan
					from HOSOTIEPNHAN hs
 					where MaTinhTrang in ('BHSP', 'YBSP','BHS','YBS')
						AND LienThong ='1'
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and MaLinhVuc=@pLinhVuc 
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
					group by MaLoaiHoSo 
					
					--da giai truoc han--?TH ngung KD
					union all 
					select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
						0 DaGQDungHan,0 DaGQQuaHan, 0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, count(hs.HoSoTiepNhanID) DaGQTruocHan
					from HOSOTIEPNHAN hs 	
					left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and hs.HoSoTiepNhanID = tt.HoSoTiepNhanID )					
					where hs.MaLinhVuc=@pLinhVuc 
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0 
						and tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  
						AND LienThong ='1'
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and datediff(dy, tths.NgayTacNghiep, hs.NgayHenTra) > 0 
--						and MaLoaiHoSo in (
--								select MaLoaiHoSo
--								from DMLOAIHOSO
--								where MaLinhVuc = hs.MaLinhVuc 
--									and Used = 1
--							)
					group by hs.MaLoaiHoSo 

					--da giai quyet dung han--?TH ngung KD
					union all 
					select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
						count(hs.HoSoTiepNhanID) DaGQDungHan,0 DaGQQuaHan, 0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan			 
					from HOSOTIEPNHAN hs 	
					left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and hs.HoSoTiepNhanID = tt.HoSoTiepNhanID )					
					where hs.MaLinhVuc=@pLinhVuc 
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0 
						and tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  
						AND LienThong ='1'
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and datediff(dy, tths.NgayTacNghiep, hs.NgayHenTra) = 0 
--						and MaLoaiHoSo in (
--								select MaLoaiHoSo
--								from DMLOAIHOSO
--								where MaLinhVuc = hs.MaLinhVuc 
--									and Used = 1
--							)
					group by hs.MaLoaiHoSo 

					--da giai quyet nhung qua han-?TH ngung KD
					union all 
					select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
							0 DaGQDungHan,count(hs.HoSoTiepNhanID) DaGQQuaHan, 0 ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan
					from HOSOTIEPNHAN hs 
					left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and hs.HoSoTiepNhanID = tt.HoSoTiepNhanID )					
					where MaLinhVuc=@pLinhVuc 
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
						and tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  
						AND LienThong ='1'
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and datediff(dy, tths.NgayTacNghiep, hs.NgayHenTra) < 0 
--						and MaLoaiHoSo in (
--								select MaLoaiHoSo
--								from DMLOAIHOSO
--								where MaLinhVuc = hs.MaLinhVuc 
--									and Used = 1
--							)
					group by hs.MaLoaiHoSo 

					--chua giai quyet trong han-?TH ngung KD
					union all 
					select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
							0 DaGQDungHan,0 DaGQQuaHan, count(HoSoTiepNhanID) ChuaGQTrongHan,0 ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan
					from HOSOTIEPNHAN hs
					where MaLinhVuc=@pLinhVuc 
						and MaTinhTrang is NOT NULL
						AND LienThong ='1'
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
						and MaTinhTrang not in ('DTN','CCV','CCVP','DTNP','DTDP','DTD','BHSP','BHS','HUYP','YBS','HUY','TDXP')
						and NgayHenTra >= convert(datetime,@pDenNgay,103) 
--						and MaLoaiHoSo in (
--								select MaLoaiHoSo
--								from DMLOAIHOSO
--								where MaLinhVuc = hs.MaLinhVuc  
--									and Used = 1
--							)
					group by MaLoaiHoSo 

					--chua giai quyet qua han-?TH ngung KD
					union all 
					select hs.MaLoaiHoSo, 0 TonTruoc,0 MoiNhan, 0 DaHuy, 0 BoTucHoSo, 0 ConLai,
						0 DaGQDungHan,0 DaGQQuaHan, 0 ChuaGQTrongHan,count(HoSoTiepNhanID) ChuaGQQuaHan,0 NgayThuBay, 0 DaGQTruocHan
					from HOSOTIEPNHAN hs
					where MaLinhVuc=@pLinhVuc 
						and MaTinhTrang is NOT NULL
						AND LienThong ='1' 
						and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
						and datediff(dy,hs.NgayNhan,convert(datetime,@pTuNgay,103) )<=0 and datediff(dy,hs.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
						and MaTinhTrang not in ('DTN','CCV','CCVP','DTNP','DTDP','DTD','BHSP','BHS','HUYP','YBS','HUY','TDXP')			
						and NgayHenTra < convert(datetime,@pDenNgay,103)
--						and MaLoaiHoSo in (
--								select MaLoaiHoSo
--								from DMLOAIHOSO
--								where MaLinhVuc = hs.MaLinhVuc 
--									and Used = 1
--							) 
					group by MaLoaiHoSo 
					 
				) a on a.MaLoaiHoSo=lhs.MaLoaiHoSo 
			where lhs.MaLinhVuc=@pLinhVuc
			group by lhs.TenLoaiHoSo, lhs.MaLoaiHoSo
			order by lhs.TenLoaiHoSo
	END
	
	
end



























