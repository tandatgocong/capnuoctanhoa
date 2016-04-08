SELECT COUNT(*) FROM HOADONTH12_2015

ALTER TABLE HOADONTH12_2015
ADD HIEUDH nvarchar(250)
go

ALTER TABLE HOADONTH12_2015
ADD SOTHAN nvarchar(250)
go

ALTER TABLE HOADONTH12_2015
ADD NAMLD nvarchar(250)
go

ALTER TABLE HOADONTH12_2015
ADD NGAYKIEMDINH nvarchar(250)
go

ALTER TABLE HOADONTH12_2015
ADD NHANVIEN nvarchar(250)
go

ALTER TABLE HOADONTH12_2015
ADD MADMA nvarchar(250)
go




UPDATE HOADONTH12_2015 SET KHU = DOT+''+ CUON+''+MLT;
------------------------------------------------------
UPDATE HOADONTH12_2015 SET  DANHBO=  REPLACE(HOADONTH12_2015.DANHBO,' ','')
 /*
UPDATE TB_DULIEUKHACHHANG SET HOTEN = t2.TENKH,GIABIEU=t2.GIABIEU, DINHMUC=t2.DINHMUC
FROM HOADONTH12_2015 t2
WHERE TB_DULIEUKHACHHANG.DANHBO= t2.DANHBO  and t2.CODE <> 'M'
UPDATE HOADONTH12_2015 SET  KHU= t2.LOTRINH
FROM TB_DULIEUKHACHHANG t2
WHERE REPLACE(HOADONTH12_2015.DANHBO,' ','')=  REPLACE(t2.DANHBO,' ','')

UPDATE HOADONTH12_2015 SET  KHU= t2.LOTRINH
FROM TB_DULIEUKHACHHANG_HUYDB t2
WHERE HOADONTH12_2015.DANHBO= t2.DANHBO



UPDATE HOADONTH12_2015 SET  PHUONG= t2.PHUONG, QUAN=t2.QUAN,HIEUDH=t2.HIEUDH,SOTHAN=t2.SOTHANDH,MADMA=t2.MADMA,NGAYGAN = CONVERT(VARCHAR(50),t2.NGAYTHAY,103),
NGAYKIEMDINH = CONVERT(VARCHAR(50),t2.NGAYKIEMDINH,103)
FROM TB_DULIEUKHACHHANG t2
WHERE HOADONTH12_2015.DANHBO = t2.DANHBO

UPDATE HOADONTH12_2015 SET  PHUONG= t2.PHUONG, QUAN=t2.QUAN,HIEUDH=t2.HIEUDH,SOTHAN=t2.SOTHANDH,MADMA=t2.MADMA,NGAYGAN = CONVERT(VARCHAR(50),t2.NGAYTHAY,103),
NGAYKIEMDINH = CONVERT(VARCHAR(50),t2.NGAYKIEMDINH,103)
FROM TB_DULIEUKHACHHANG_HUYDB t2
WHERE HOADONTH12_2015.DANHBO = t2.DANHBO

*/

UPDATE HOADONTH12_2015 SET  PHUONG= t2.PHUONG, QUAN=t2.QUAN,HIEUDH=t2.HIEUDH,NAMLD = YEAR(t2.NGAYTHAY)
FROM TB_DULIEUKHACHHANG t2
WHERE HOADONTH12_2015.DANHBO = t2.DANHBO

UPDATE HOADONTH12_2015 SET  PHUONG= t2.PHUONG, QUAN=t2.QUAN,HIEUDH=t2.HIEUDH,NAMLD = YEAR(t2.NGAYTHAY)
FROM TB_DULIEUKHACHHANG_HUYDB t2
WHERE HOADONTH12_2015.DANHBO = t2.DANHBO

UPDATE HOADONTH02_2016 SET  NHANVIEN = t2.NAME
FROM [CAPNUOCTANHOA].[dbo].[TB_NHANVIENDOCSO] t2
WHERE CONVERT(int,SUBSTRING(Khu,3,2))= t2.MAYDS
------------------------------------------------------
select * from  HOADONTH12_2015 order by khu asc
-------------------------------------------------------

UPDATE HOADONTH12_2015 SET  NHANVIEN = t2.NAME
FROM TB_NHANVIENDOCSO t2
WHERE CONVERT(int,SUBSTRING(Khu,3,2))= t2.MAYDS

UPDATE HOADONTH12_2015 SET  KY01 =CONVERT(varchar(10), t2.LNCC)  +' - Code: ' + t2.Code
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



SELECT Khu,DanhBo,HopDong,TenKH,SoNha,DUONG,kh.GIABIEU,kh.DINHMUC, kh.CODE,kh.CSCU,CSMOI,kh.LNCC
FROM HOADONTH12_2015 kh, PHUONG p, QUAN q
WHERE LNCC=0  AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND DANHBO IN (select DANHBO  FROM [CAPNUOCTANHOA].[dbo].[SOLIEUHD] )
ORDER BY  p.MAQUAN,p.MAPHUONG ASC

------------------------------

SELECT p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN, COUNT(*)
FROM HOADONTH12_2015 kh, PHUONG p, QUAN q
WHERE Code='K' AND LNCC>0  AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
GROUP BY p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN
ORDER BY  p.MAQUAN,p.MAPHUONG ASC



SELECT Khu,DanhBo,HopDong,TenKH,SoNha,Duong,p.TENPHUONG, q.TENQUAN,CODHN,HIEUDHN, NAMLD,NHANVIEN
FROM HOADONTH07 kh, PHUONG p, QUAN q
WHERE Code='K' AND LNCC>0  AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
ORDER BY  p.MAQUAN,p.MAPHUONG ASC


----------------------------------------------------------------------
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

-------------------------------
SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN, kh.GIABIEU, kh.DINHMUC, kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND kh.QUAN='31' AND kh.PHUONG='06'
ORDER BY  LOTRINH ASC

SELECT Khu,DanhBo,HopDong,TenKH,SoNha,Duong,p.TENPHUONG,kh.CULY,kh.HIEUDH,kh.CODE,kh.LNCC, NAMLD
FROM HOADONTH12_2015 kh, PHUONG p, QUAN q
WHERE kh.LNCC=0 AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG  
AND q.MAQUAN='31' AND p.MAPHUONG='11'
ORDER BY  KHU ASC

--------------
-- THEO QUAN PHUONG
SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN, ds.GB, ds.DM, kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME 
FROM  HOADON_TA.dbo.HOADON ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv, PHUONG p, QUAN q
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND ds.TIEUTHU=0 AND ds.KY=8 and ds.NAM=2013
ORDER BY  q.MAQUAN  ASC,P.MAPHUONG ASC, nv.NAME ASC,kh.LOTRINH ASC


SELECT SUBSTRING(kh.LOTRINH,1,2), kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN, ds.GB, ds.DM,kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME , ds.TIEUTHU
FROM  HOADON_TA.dbo.HOADON ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv, PHUONG p, QUAN q
WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND ds.TIEUTHU=0 AND ds.KY=12 and ds.NAM=2012
ORDER BY kh.LOTRINH ASC, nv.NAME ASC

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

SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, LEFT(HIEUDH,3), kh.CODH ,kh.SOTHANDH, CONVERT(NVARCHAR(20), kh.NGAYTHAY,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE kh.MADMA='TH-02-06'
ORDER BY kh.LOTRINH ASC

--------------------------------- san luong 
SELECT p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN, COUNT(*), SUM(CONVERT(FLOAT,LNCC))
FROM HOADONTH10 kh, PHUONG p, QUAN q
WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
GROUP BY p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN
ORDER BY  p.MAQUAN,p.MAPHUONG ASC



SELECT p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN, COUNT(*),COUNT(CASE WHEN kh.LNCC=0 THEN 1 ELSE NULL END)
FROM HOADONTH12_2015 kh, PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
GROUP BY p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN
ORDER BY  p.MAQUAN,p.MAPHUONG ASC

SELECT PHUONG,QUAN, COUNT(*) FROM HOADONTH12_2015 GROUP BY PHUONG,QUAN

UPDATE HOADONTH12_2015 SET PHUONG='01' WHERE PHUONG=1
WHERE LEFT(HOPDONG,2)='TP' AND QUAN IS NULL


SELECT Khu,DanhBo,HopDong,TenKH,SoNha,Duong,p.TENPHUONG,kh.CODH,kh.HIEUDH,kh.CODE,kh.LNCC, NAMLD
FROM HOADONTH08_2013 kh, PHUONG p, QUAN q
WHERE kh.LNCC=0 AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG  AND q.MAQUAN='31' AND p.MAPHUONG='11'
ORDER BY  KHU ASC

SELECT kh.Khu, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN, kh.Field13, kh.Field18, HIEUDHN, CODHN,Field21
FROM HOADONTH08 kh, PHUONG p, QUAN q
WHERE  kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND  Field29=0 AND PHUONG='15' AND QUAN='23' AND Field21 like '%M%'
ORDER BY  kh.Khu ASC


select DOT,COUNT(*)
FROM HOADONTH06_2013
WHERE LNCC=0
GROUP BY DOT
ORDER BY DOT ASC




UPDATE  TB_DULIEUKHACHHANG  SET  HOTEN= t2.TENKH
FROM HOADONTH12_2015 t2
WHERE TB_DULIEUKHACHHANG.DANHBO = t2.DANHBO


SELECT p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN, COUNT(*)
FROM TB_DULIEUKHACHHANG kh, PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG  AND KY=2 AND NAM=2014
GROUP BY p.MAQUAN,p.MAPHUONG, p.TENPHUONG, q.TENQUAN
ORDER BY  p.MAQUAN,p.MAPHUONG ASC



----------------------------------XUAT DANH BO THEO TUNG TO------------------------------------------

SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015 kh
WHERE  LNCC=0
 AND SUBSTRING(KHU,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  KHU ASC

SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015 kh
WHERE  LNCC=0
   AND SUBSTRING(KHU,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
ORDER BY  KHU ASC

SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015 kh
WHERE  LNCC=0
  AND SUBSTRING(KHU,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
ORDER BY  KHU ASC


SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015 kh
WHERE  LNCC=0 
 AND SUBSTRING(KHU,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
ORDER BY  KHU ASC


------------------------------- 6 ky lien tiep =0


SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015  kh 
WHERE LNCC=0  
AND DANHBO IN (SELECT DANHBO FROM HOADONTH12_2013 WHERE LNCC=0)
AND DANHBO IN (SELECT DANHBO FROM HOADONTH01_2014 WHERE LNCC=0)
 AND SUBSTRING(KHU,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
 ORDER BY  KHU ASC


SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015 kh 
WHERE LNCC=0  
AND DANHBO IN (SELECT DANHBO FROM HOADONTH12_2013 WHERE LNCC=0)
AND DANHBO IN (SELECT DANHBO FROM HOADONTH01_2014 WHERE LNCC=0)
   AND SUBSTRING(KHU,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
 ORDER BY  KHU ASC
 
 
 SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015 kh 
WHERE LNCC=0  
AND DANHBO IN (SELECT DANHBO FROM HOADONTH12_2013 WHERE LNCC=0)
AND DANHBO IN (SELECT DANHBO FROM HOADONTH01_2014 WHERE LNCC=0)
AND SUBSTRING(KHU,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
 ORDER BY  KHU ASC
 
 
 SELECT SUBSTRING(kh.KHU,1,2) as 'DOT',kh.KHU, kh.DANHBO, kh.HOPDONG, kh.TENKH, kh.SONHA, kh.DUONG,'','',kh.HIEUDH, kh.CODH,'', YEAR(kh.NAMLD) AS 'NAM' , ''
FROM  HOADONTH12_2015 kh 
WHERE LNCC=0  
AND PHUONG = '02' AND QUAN='31'  
 ORDER BY  KHU ASC
 
 
 