



declare @pLinhVuc nvarchar(5)
declare	@pLoaiHoSo nvarchar(20)
declare	@pTuNgay nvarchar(10)
declare @pDenNgay nvarchar(10)
declare	@pType nvarchar(100)
declare @pTinhTrang nvarchar(50)
declare @pURL nvarchar(1000)
declare @pNguoiXemBaoCaoChiTiet NVARCHAR(50)
declare	@pMaPhuong nvarchar(10)

set @pLinhVuc = 'cpct'
set	@pLoaiHoSo = '00155'
set	@pTuNgay = '16/01/2015'
set @pDenNgay = '05/02/2015'
set	@pType = 'DANGGIAIQUYET'
set @pTinhTrang = ''
set @pURL = ''
set @pNguoiXemBaoCaoChiTiet = 'host'
set	@pMaPhuong = ''
	

IF @pNguoiXemBaoCaoChiTiet IN ('host','admin','minhvd','suonghh','hungnb') BEGIN
	/* ================ TỔNG NHẬN ====================*/
	
	IF @pType='TONGNHAN' BEGIN
	 --nhan trong ky 
		select distinct h.SoBienNhan  N'Số biên nhận' , h.HoTenNguoiNop  N'Họ tên' ,
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ',
			convert(nvarchar,h.NgayNhan,103) N'Ngày nhận' , convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả' ,
			(
				select top 1  convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo  in( 'CCVP','DTNP')
			) as  N'Ngày hoàn thành' ,
			(
				select top 1  convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo = 'DTDP'
			) as  N'Ngày dân đến nhận' ,
			tt.TenTinhTrang  N'Tình trạng' ,
			replace( @pURL ,'VALUE',h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc + 
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType AS URL
		from HOSOTIEPNHAN h
			left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
			left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
			left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
			left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
			left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
			left join TINHTRANGHOSO tths on tths.MaTinhTrangHoSo=h.MaTinhTrang and tths.HoSoTiepNhanID = h.HoSoTiepNhanID
		where h.MaTinhTrang  is not null			
			and datediff(dy,h.NgayNhan,convert(datetime,@pTuNgay,103))<=0 
			and datediff(dy,h.NgayNhan,convert(datetime, @pDenNgay ,103) )>=0
			AND h.LienThong ='1' 		
			and h.MaLinhVuc= @pLinhVuc  and h.MaLoaiHoSo=@pLoaiHoSo 
	END
	
	/* =============== THỐNG KÊ HỒ SƠ NHẬN NGÀY THỨ BẢY ======================= */
	IF @pType='THUBAY' BEGIN
	--nhan trong ky 
		select distinct h.SoBienNhan  N'Số biên nhận' , h.HoTenNguoiNop  N'Họ tên' ,
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ',
			convert(nvarchar,h.NgayNhan,103) N'Ngày nhận' , convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả' ,
			(
				select top 1  convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo  in( 'CCVP','DTNP')
			) as  N'Ngày hoàn thành' ,
			(
				select top 1  convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo = 'DTDP'
			) as  N'Ngày dân đến nhận' ,
			tt.TenTinhTrang  N'Tình trạng' ,
			replace( @pURL ,'VALUE',h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc + 
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType AS URL
		from HOSOTIEPNHAN h
			left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
			left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
			left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
			left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
			left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
			left join TINHTRANGHOSO tths on tths.MaTinhTrangHoSo=h.MaTinhTrang and tths.HoSoTiepNhanID = h.HoSoTiepNhanID
		where h.MaTinhTrang  is not null			
			and datediff(dy,h.NgayNhan,convert(datetime,@pTuNgay,103))<=0 
			and datediff(dy,h.NgayNhan,convert(datetime, @pDenNgay ,103) )>=0
			AND h.LienThong ='1' 		
			and h.MaLinhVuc= @pLinhVuc  and h.MaLoaiHoSo=@pLoaiHoSo 
			and DATEPART(dw, h.NgayNhan)=7		
	end
	/* =============== THỐNG KÊ HỒ SƠ TRẢ TRƯỚC HẠN ======================= */
	IF @pType='TRUOCHAN' BEGIN
			select  distinct h.SoBienNhan  N'Số biên nhận' , h.HoTenNguoiNop  N'Họ tên' ,
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ',
			convert(nvarchar,h.NgayNhan,103) N'Ngày nhận' , convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả' ,
			(
				select  top 1  convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 	
			) as  N'Ngày hoàn thành' ,
			(
				select  top 1 convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo = 'DTDP'
			) as N'Ngày dân đếnn nhận' ,
			tt.TenTinhTrang N'Tình trạng' ,
			replace( @pURL ,'VALUE', h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc +
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType as URL
		from HOSOTIEPNHAN h
			left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
			left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
			left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
			left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
			left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
			left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and h.HoSoTiepNhanID = tt.HoSoTiepNhanID )
		where  tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 	
			and datediff(dy,h.NgayNhan,convert(datetime,@pTuNgay ,103))<=0 
			and datediff(dy,h.NgayNhan,convert(datetime,@pDenNgay ,103) )>=0
			and datediff(dy, tths.NgayTacNghiep, h.NgayHenTra) >= 0			
			AND h.LienThong ='1' 				
			and h.MaLinhVuc=  @pLinhVuc and h.MaLoaiHoSo = @pLoaiHoSo
	END
	/* =============== THỐNG KÊ HỒ SƠ TRẢ ĐÚNG HẸN ======================= */
	IF @pType='DAGQDUNGHAN' BEGIN
			select distinct h.SoBienNhan  N'Số biên nhận' , h.HoTenNguoiNop  N'Họ tên' ,
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ' ,
			convert(nvarchar,h.NgayNhan,103)  N'Ngày nhận' , convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả' ,
			(
				select  top 1  convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 	
			) as  N'Ngày hoàn thành' ,
			(
				select  top 1 convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo = 'DTDP'
			) as  N'Ngày dân đếnn nhận' ,
			tt.TenTinhTrang  N'Tình trạng' ,
			replace(@pURL,'VALUE',h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc +
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType AS URL
		from HOSOTIEPNHAN h
			left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
			left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
			left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
			left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
			left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
			left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and h.HoSoTiepNhanID = tt.HoSoTiepNhanID )
		where  tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 	
			and datediff(dy,h.NgayNhan,convert(datetime,@pTuNgay,103))<=0 and datediff(dy,h.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
			and datediff(dy, tths.NgayTacNghiep, h.NgayHenTra) >= 0			
			AND h.LienThong ='1' 				
			and h.MaLinhVuc= @pLinhVuc and h.MaLoaiHoSo = @pLoaiHoSo 
		
	END
	
	/* =============== THỐNG KÊ HỒ SƠ ĐÃ GIẢI QUYẾT QUÁ HẠN ======================= */
	IF @pType='DAGQQUAHAN' BEGIN
		select distinct h.SoBienNhan  N'Số biên nhận' , 
			h.HoTenNguoiNop  N'Họ tên' ,
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ' ,
			convert(nvarchar,h.NgayNhan,103)  N'Ngày nhận' , 
			convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả' ,
			(
				select  top 1 convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo  in ('DTN','CCV','CCVP','DTNP','TDXP') 	
			) as  N'Ngày hoàn thành' ,
			(
				select top 1  convert(nvarchar,NgayTacNghiep,103)
				from TINHTRANGHOSO
				where HoSoTiepNhanID = h.HoSoTiepNhanID
					and MaTinhTrangHoSo = 'DTDP'
			) as  N'Ngày dân đến nhận' ,
			datediff(dy,h.ngayhentra,tths.NgayTacNghiep) as  N'Số ngày quá hạn' ,
			replace(@pURL ,'VALUE',h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc +
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType AS URL
		from HOSOTIEPNHAN h
			left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
			left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
			left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
			left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
			left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
			left join TINHTRANGHOSO tths on TinhTrangHoSoID= (select max(TinhTrangHoSoID) from TINHTRANGHOSO tt where MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP')  and h.HoSoTiepNhanID = tt.HoSoTiepNhanID )
		where tths.MaTinhTrangHoSo in ('DTN','CCV','CCVP','DTNP','TDXP') 	
			and datediff(dy,h.NgayNhan,convert(datetime, @pTuNgay ,103))<=0 and datediff(dy,h.NgayNhan,convert(datetime, @pDenNgay ,103) )>=0
			and datediff(dy, tths.NgayTacNghiep, h.NgayHenTra) < 0 			
			AND h.LienThong ='1'					
			and h.MaLinhVuc= @pLinhVuc and h.MaLoaiHoSo= @pLoaiHoSo 
	END
	/* =============== THỐNG KÊ HỒ SƠ ĐANG GIẢI QUYẾT ======================= */
	IF @pType='DANGGIAIQUYET' BEGIN
	-- chua gq k trong han
		select distinct h.SoBienNhan  N'Số biên nhận', h.HoTenNguoiNop  N'Họ tên',
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ',
			convert(nvarchar,h.NgayNhan,103)  N'Ngày nhận', 
			convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả',
			tt.TenTinhTrang  N'Tình trạng',
			replace(@pURL,'VALUE',h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc +
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType AS URL
		from HOSOTIEPNHAN h
			left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
			left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
			left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
			left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
			left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
		where h.MaTinhTrang not in ('DTN','CCV','CCVP','DTNP','DTDP','DTD','BHSP','BHS','HUYP','YBS','HUY','TDXP')
			and h.NgayHenTra >= convert(datetime,@pDenNgay ,103)
			and datediff(dy,h.NgayNhan,convert(datetime,@pTuNgay,103))<=0
			and datediff(dy,h.NgayNhan,convert(datetime, @pDenNgay ,103) )>=0
			AND h.LienThong ='1' 			
			--and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
			and h.MaLinhVuc=@pLinhVuc and h.MaLoaiHoSo= @pLoaiHoSo
			
	UNION ALL
	 --BO TUC HS
	select distinct h.SoBienNhan  N'Số biên nhận', h.HoTenNguoiNop  N'Họ tên',
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ',
			convert(nvarchar,h.NgayNhan,103)  N'Ngày nhận', 
			convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả',
			tt.TenTinhTrang  N'Tình trạng',
			replace(@pURL,'VALUE',h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc +
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType AS URL
	from HOSOTIEPNHAN h 
		left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
		left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
		left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
		left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
		left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
	where h.MaTinhTrang  in( 'BHSP','YBSP','BHS','YBS')
		and datediff(dy,h.NgayNhan,convert(datetime, @pTuNgay ,103))<=0 and datediff(dy,h.NgayNhan,convert(datetime,@pDenNgay ,103) )>=0
		AND h.LienThong ='1' 		
		--and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
		and h.MaLinhVuc=@pLinhVuc and h.MaLoaiHoSo= @pLoaiHoSo
		
	UNION ALL
	-- CHUA GQ QUA HAN
		select distinct h.SoBienNhan  N'Số biên nhận', h.HoTenNguoiNop  N'Họ tên',
			h.SoNha + ', ' + d.TenDuong + ', ' + p.TenDonVi  N'Ðịa chỉ',
			convert(nvarchar,h.NgayNhan,103)  N'Ngày nhận', 
			convert(nvarchar,h.NgayHenTra,103)  N'Ngày hẹn trả',
			tt.TenTinhTrang  N'Tình trạng',
			replace(@pURL,'VALUE',h.HoSoTiepNhanID) + '&Malv=' + lv.MaLinhVuc + '&Tenlv=' + lv.TenLinhVuc +
			'&MaLHS=' + lhs.MaLoaiHoSo + '&TenLHS=' + lhs.TenLoaiHoSo + '&TuNgay=' + @pTuNgay + '&DenNgay=' + @pDenNgay + '&Loai=' + @pType AS URL
		from HOSOTIEPNHAN h
			left join FSSPORTALQH.dbo.DMDUONG d on h.MaDuong = d.MaDuong
			left join FSSPORTALQH.dbo.DMDONVI p on h.MaPhuong = p.MaDonVi and p.MaLoaiDonVi in ('G','F')
			left join DMLINHVUC lv on lv.MaLinhVuc = h.MaLinhVuc
			left join DMLOAIHOSO lhs on lhs.MaLinhVuc = h.MaLinhVuc and lhs.MaLoaiHoSo = h.MaLoaiHoSo
			left join DMTINHTRANGHOSO tt on tt.MaTinhTrang=h.MaTinhTrang and tt.MaLinhVuc=h.MaLinhVuc
			inner join TINHTRANGHOSO tths ON tths.HoSoTiepNhanID = h.HoSoTiepNhanID 
				and tths.TinhTrangHoSoID = (
					select MAX(TinhTrangHoSoID)
					from TINHTRANGHOSO
					where HoSoTiepNhanID = h.HoSoTiepNhanID
				)
			inner join FSSPORTALQH..USERS u ON u.UserName = tths.MaNguoiNhan
			where h.MaTinhTrang not in ('DTN','CCV','CCVP','DTNP','DTDP','DTD','BHSP','BHS','HUYP','YBS','HUY','TDXP')
			and datediff(dy,h.NgayNhan,convert(datetime,@pTuNgay,103))<=0 
			and datediff(dy,h.NgayNhan,convert(datetime,@pDenNgay,103) )>=0
			and h.NgayHenTra < convert(datetime,@pDenNgay,103)			
			AND h.LienThong = '1' 		
			--and (@pMaPhuong='' OR MaPhuong=@pMaPhuong)
			and h.MaLinhVuc=@pLinhVuc and h.MaLoaiHoSo= @pLoaiHoSo
	END
	
	
END