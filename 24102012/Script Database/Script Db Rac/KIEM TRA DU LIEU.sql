SELECT Khu, Dot, DanhBo, CoDh, HopDong, TenKH, SoNha, Duong, GiaBieu, DinhMuc, Ky, Nam, Code, CodeF, CSCu, CSMoi, NDKT, NDKN, ChuKy, CuonGCS, CuonSTT,NgayGan
FROM dbo.HOADONTH06  
WHERE DanhBo NOT IN (SELECT DanhBo FROM TB_DULIEUKHACHHANG WHERE KY<=6 AND NAM<=2012)
AND ((LEFT(DANHBO,7) >= '1315221' AND LEFT(DANHBO,7) <= '1321999') OR LEFT(DANHBO,7) = '1314197'  OR LEFT(DANHBO,7) = '1314198')


SELECT  *
FROM TB_DULIEUKHACHHANG
WHERE  KY<=6 AND  ((LEFT(DANHBO,7) >= '1315221' AND LEFT(DANHBO,7) <= '1321999') OR LEFT(DANHBO,7) = '1314197'  OR LEFT(DANHBO,7) = '1314198')


SELECT COUNT(*) FROM TB_DULIEUKHACHHANG WHERE KY<=6 AND NAM<=2012