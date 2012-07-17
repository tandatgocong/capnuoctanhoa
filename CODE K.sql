UPDATE HOADONTH06 SET  HIEUDHN=t2.HIEUDH,CODHN=t2.CODH,NAMLD=YEAR(t2.NGAYTHAY),Khu= t2.LOTRINH
FROM TB_DULIEUKHACHHANG t2
WHERE HOADONTH06.DANHBO = t2.DANHBO AND HOADONTH06.Code='K'

UPDATE HOADONTH06 SET  NHANVIEN = t2.NAME
FROM TB_NHANVIENDOCSO t2
WHERE CONVERT(int,SUBSTRING(Khu,3,2))= t2.MAYDS AND HOADONTH06.Code='K'

UPDATE HOADONTH06 SET  KY01 =CONVERT(varchar(10), t2.LNCC)  +' - Code: ' + t2.Code
FROM HOADONTH01 t2
WHERE HOADONTH06.DanhBo=t2.DanhBo


UPDATE HOADONTH06 SET  KY02 = t2.LNCC
FROM HOADONTH02 t2
WHERE HOADONTH06.DanhBo=t2.DanhBo


UPDATE HOADONTH06 SET  KY03 = t2.LNCC
FROM HOADONTH03 t2
WHERE HOADONTH06.DanhBo=t2.DanhBo


UPDATE HOADONTH06 SET  KY04 = t2.LNCC
FROM HOADONTH04 t2
WHERE HOADONTH06.DanhBo=t2.DanhBo

UPDATE HOADONTH06 SET  KY05 = t2.LNCC
FROM HOADONTH05 t2
WHERE HOADONTH06.DanhBo=t2.DanhBo


SELECT Khu,DanhBo,HopDong,TenKH,SoNha,Duong,HIEUDHN,CODHN,NAMLD,KY01,KY02,KY03,KY04,KY05,NHANVIEN
FROM HOADONTH06
WHERE Code='4' AND LNCC=0
ORDER BY  NHANVIEN ASC,Khu ASC

-----
SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME 
FROM  DocSo_PHT.dbo.DS2012 ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS
AND ds.CODE LIKE 'K%' AND ds.KY=7
ORDER BY  nv.NAME ASC,kh.LOTRINH ASC


SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME 
FROM  DocSo_PHT.dbo.DS2012 ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS
AND ds.CODE LIKE 'K%' AND ds.KY=7
ORDER BY  nv.NAME ASC,kh.LOTRINH ASC