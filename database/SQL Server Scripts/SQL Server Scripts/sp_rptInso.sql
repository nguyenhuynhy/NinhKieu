USE [FSSHSHCQH]
GO
/****** Object:  StoredProcedure [dbo].[sp_rptInSo]    Script Date: 03/26/2015 15:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_rptInSo]
	@lhs nvarchar(10),	
	@users nvarchar(10),
	@tungay varchar(10),
	@denngay varchar(10),
	@lv nvarchar(10)
AS
BEGIN	
	if @lhs='All' begin
		select
			Row_number() over(order by lhs.TenLoaiHoSo,hs.NgayNhan) STT,
			hs.SoBienNhan,
			hs.HoTenNguoiNop,
			hs.DiaChiThuongTru,
			convert(varchar(10),hs.NgayNhan ,103) as NgayNhan,
			convert(varchar(10),hs.NgayHenTra ,103) as NgayHenTra,
			convert(varchar(10),hs.NgayThucTra ,103) as NgayThucTra,
			hs.NoiDungTrichYeu,
			'' GhiChu,
			lhs.TenLoaiHoSo
		
		from HOSOTIEPNHAN hs join DMLOAIHOSO lhs on hs.MaLoaiHoSo=lhs.MaLoaiHoSo
		where hs.MaNguoiNhan=@users
		and convert(datetime,hs.NgayNhan,103) 
		between convert(datetime,@tungay,103) 
		and convert(datetime,@denngay,103)
		order by lhs.TenLoaiHoSo,hs.NgayNhan
	end else begin
		select
			Row_number() over(order by lhs.TenLoaiHoSo,hs.NgayNhan) STT,
			hs.SoBienNhan,
			hs.HoTenNguoiNop,
			hs.DiaChiThuongTru,
			convert(varchar(10),hs.NgayNhan ,103) as NgayNhan,
			convert(varchar(10),hs.NgayHenTra ,103) as NgayHenTra,
			convert(varchar(10),hs.NgayThucTra ,103) as NgayThucTra,
			hs.NoiDungTrichYeu,
			'' GhiChu,
			lhs.TenLoaiHoSo
		
		from HOSOTIEPNHAN hs join DMLOAIHOSO lhs on hs.MaLoaiHoSo=lhs.MaLoaiHoSo
		where hs.MaNguoiNhan=@users
		and lhs.MaLoaiHoSo=@lhs
		and convert(datetime,hs.NgayNhan,103) 
		between convert(datetime,@tungay,103) 
		and convert(datetime,@denngay,103)
		order by hs.NgayNhan
	end
	
END
