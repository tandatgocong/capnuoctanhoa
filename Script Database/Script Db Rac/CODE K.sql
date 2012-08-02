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

SELECT Khu,DanhBo,HopDong,TenKH,SoNha,Duong,HIEUDHN,CODHN,NAMLD,KY01,KY02,KY03,KY04,KY05,LNCC,NHANVIEN
FROM HOADONTH06
WHERE Code='4' AND LNCC>=1 AND NAMLD<=2006
ORDER BY  NHANVIEN ASC,Khu ASC

-- CODE F
SELECT Khu,DanhBo,HopDong,TenKH,SoNha,Duong,HIEUDHN,CODHN,NAMLD,KY01,KY02,KY03,KY04,KY05,LNCC,NHANVIEN
FROM HOADONTH06
WHERE Code='N' AND LNCc<=0 AND NAMLD<=2006
ORDER BY  NHANVIEN ASC,Khu ASC

SELECT  LEFT(HIEUDHN,3),CODHN,NAMLD, COUNT(*)
FROM HOADONTH06
WHERE Code='4' AND LNCC>=1 AND NAMLD<=2006
GROUP BY LEFT(HIEUDHN,3),CODHN,NAMLD
ORDER BY NAMLD ASC

------

SELECT  LEFT(HIEUDHN,3),CODHN,NAMLD, COUNT(*)
FROM HOADONTH06
WHERE Code='4' AND LNCC<=0 AND NAMLD<=2006
GROUP BY LEFT(HIEUDHN,3),CODHN,NAMLD
ORDER BY NAMLD ASC


--------------
-- THEO QUAN PHUONG
SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN, ds.GB, ds.DM, kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME 
FROM  HOADON_TA.dbo.HOADON ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv, PHUONG p, QUAN q
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND ds.TIEUTHU=0 AND ds.KY=7 and ds.NAM=2012
ORDER BY  q.MAQUAN  ASC,P.MAPHUONG ASC, nv.NAME ASC,kh.LOTRINH ASC


SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN, ds.GB, ds.DM,kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME , ds.TIEUTHU
FROM  HOADON_TA.dbo.HOADON ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv, PHUONG p, QUAN q
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND ds.TIEUTHU>0 and ds.TIEUTHU<=4 AND ds.KY=7 and ds.NAM=2012
ORDER BY  q.MAQUAN  ASC,P.MAPHUONG ASC, nv.NAME ASC,kh.LOTRINH ASC

select * from HOADON_TA.dbo.HOADON ds where ds.TIEUTHU=0 and ds.KY=7 and ds.NAM=2012

SELECT  q.MAQUAN,p.MAPHUONG ,P.TENPHUONG , q.TENQUAN, COUNT(*) as TONGCONG 
FROM  HOADON_TA.dbo.HOADON ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv, PHUONG p, QUAN q
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
 AND ds.KY=7 and ds.NAM=2012
GROUP BY  q.MAQUAN,p.MAPHUONG ,P.TENPHUONG , q.TENQUAN
ORDER BY  q.MAQUAN ASC ,P.MAPHUONG  ASC


SELECT  q.MAQUAN,p.MAPHUONG ,P.TENPHUONG , q.TENQUAN, COUNT(*) as TONGCONG 
FROM   TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv, PHUONG p, QUAN q
WHERE  CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
 AND kh.KY<=7 and kh.NAM=2012
GROUP BY  q.MAQUAN,p.MAPHUONG ,P.TENPHUONG , q.TENQUAN
ORDER BY  q.MAQUAN ASC ,P.MAPHUONG  ASC

SELECT * FROM TB_DULIEUKHACHHANG kh WHERE kh.KY<=7 and kh.NAM=2012 AND kh.PHUONG in (SELECT MAPHUONG from PHUONG )

UPDATE TB_DULIEUKHACHHANG set PHUONG='10' where DANHBO='12142100690'

SELECT  q.MAQUAN,p.MAPHUONG ,P.TENPHUONG , q.TENQUAN, COUNT(*) as TONGCONG 
FROM  HOADON_TA.dbo.HOADON ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv, PHUONG p, QUAN q
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND ds.TIEUTHU>0 and ds.TIEUTHU<=4 AND ds.KY=7 and ds.NAM=2012
GROUP BY  q.MAQUAN,p.MAPHUONG ,P.TENPHUONG , q.TENQUAN
ORDER BY  q.MAQUAN ASC ,P.MAPHUONG  ASC


------

SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, LEFT(HIEUDH,3), kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME 
FROM  TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv
WHERE CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND LEFT(HIEUDH,3)  in ('ZEN','LUG','BAD','ROC','HER')
ORDER BY  nv.NAME ASC,kh.LOTRINH ASC





