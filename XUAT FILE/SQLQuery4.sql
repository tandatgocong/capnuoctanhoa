
SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NAM,DIENTHOAI
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NAM,DIENTHOAI
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
   AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NAM,DIENTHOAI
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG

AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NAM,DIENTHOAI
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG

 AND SUBSTRING(LOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
ORDER BY  LOTRINH ASC



----------- THEO DIEU KIEN-----------
--SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH,SOTHANDH, VITRIDHN 
SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, p.TENPHUONG,	q.TENQUAN,HIEUDH,CODH,SOTHANDH,CONVERT(VARCHAR(20),NGAYTHAY,103),CONVERT(VARCHAR(20),NGAYKIEMDINH,103) , VITRIDHN 
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND YEAR(NGAYKIEMDINH)<=2011
ORDER BY  kh.LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS NAM, VITRIDHN
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND MAPHUONG='02'
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  kh.LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS NAM, VITRIDHN
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND  KY_<=4
AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  kh.LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS NAM, VITRIDHN
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND  KY_<=11
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  kh.LOTRINH ASC



------- lay so lieu 

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,CONVERT(VARCHAR(50),NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  MADMA=''
order by kh.LOTRINH asc

-----------------------------------------------------
SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE  YEAR(kh.NGAYTHAY)<=2011
 AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE  YEAR(kh.NGAYTHAY)<=2011
   AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE  YEAR(kh.NGAYTHAY)<=2011
  AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE YEAR(kh.NGAYTHAY)<=2011
 AND SUBSTRING(LOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
ORDER BY  LOTRINH ASC


--------------- ANH DAM

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,hd.GIABIEU,hd.DINHMUC,hd.CSCU, hd.cODE,hd.LNCC,
CONVERT(VARCHAR(50),NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103),hd.NHANVIEN
FROM  TB_DULIEUKHACHHANG kh,HOADONTH12_2014 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2011
 AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,hd.GIABIEU,hd.DINHMUC,hd.CSCU, hd.cODE,hd.LNCC,
CONVERT(VARCHAR(50),NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103),hd.NHANVIEN
FROM  TB_DULIEUKHACHHANG kh,HOADONTH12_2014 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2011
AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,hd.GIABIEU,hd.DINHMUC,hd.CSCU, hd.cODE,hd.LNCC,
CONVERT(VARCHAR(50),NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103),hd.NHANVIEN
FROM  TB_DULIEUKHACHHANG kh,HOADONTH12_2014 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2011
 AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,hd.GIABIEU,hd.DINHMUC,hd.CSCU, hd.cODE,hd.LNCC,
CONVERT(VARCHAR(50),NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103),hd.NHANVIEN
FROM  TB_DULIEUKHACHHANG kh,HOADONTH12_2014 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2011
AND SUBSTRING(LOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
ORDER BY  LOTRINH ASC



----------------
 

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh,HOADONTH01_2015 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND p.MAPHUONG = '05' AND p.MAQUAN='23'
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,LNCC
FROM  TB_DULIEUKHACHHANG kh,HOADONTH03_2015 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND p.MAPHUONG = '06' AND p.MAQUAN='31'   AND (LNCC>=1 AND LNCC<=4)
ORDER BY  LOTRINH ASC

   
  
  -------------- GIENG
  
SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh,HOADONTH03_2014 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND p.MAPHUONG = '01' AND p.MAQUAN='31'
AND kh.DANHBO IN (   
SELECT DISTINCT DANHBA
FROM DocSo_PHT.dbo.DS2014 
WHERE GHICHUMOI LIKE '%GI%')
ORDER BY  LOTRINH ASC




SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,hd.GIABIEU,hd.DINHMUC
FROM  TB_DULIEUKHACHHANG kh,HOADONTH03_2014 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND hd.DINHMUC>=100 AND hd.GIABIEU <25
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
 kh.CODH,SOTHANDH,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50), NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL  AND YEAR(NGAYKIEMDINH)=2011 AND MONTH(NGAYKIEMDINH)=9
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
 kh.CODH,SOTHANDH,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50), NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL  AND YEAR(NGAYKIEMDINH)=2011 AND MONTH(NGAYKIEMDINH)=10
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
 kh.CODH,SOTHANDH,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50), NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL  AND YEAR(NGAYKIEMDINH)=2011 AND MONTH(NGAYKIEMDINH)=11
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
 kh.CODH,SOTHANDH,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50), NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL  AND YEAR(NGAYKIEMDINH)=2011 AND MONTH(NGAYKIEMDINH)=12
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
 kh.CODH,SOTHANDH,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50), NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL  AND YEAR(NGAYKIEMDINH)=2011 AND MONTH(NGAYKIEMDINH)=6
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
 kh.CODH,SOTHANDH,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50), NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL  AND YEAR(NGAYKIEMDINH)=2011 AND MONTH(NGAYKIEMDINH)=7
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
 kh.CODH,SOTHANDH,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50), NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL  AND YEAR(NGAYKIEMDINH)=2011 AND MONTH(NGAYKIEMDINH)=8
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc


SELECT  MONTH(NGAYKIEMDINH), YEAR(NGAYKIEMDINH),COUNT(*)
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.NGAYKIEMDINH IS NOT NULL 
GROUP BY MONTH(NGAYKIEMDINH), YEAR(NGAYKIEMDINH)
ORDER BY YEAR(NGAYKIEMDINH), MONTH(NGAYKIEMDINH) asc


-------------------- HOA DON =0

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,
hd.CODE,hd.CSMOI,hd.LNCC
FROM  TB_DULIEUKHACHHANG kh,HOADONTH10_2014 hd
WHERE kh.DANHBO=hd.DANHBO  and hd.LNCC=0
AND hd.DANHBO IN (SELECT DANHBO FROM HOADONTH09_2014 WHERE LNCC=0)
AND hd.DANHBO IN (SELECT DANHBO FROM HOADONTH08_2014 WHERE LNCC=0)
AND hd.DANHBO IN (SELECT DANHBO FROM HOADONTH07_2014 WHERE LNCC<>0)
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM',kh.DINHMUC,hd.CODE,hd.CSMOI, hd.LNCC
FROM  TB_DULIEUKHACHHANG kh,HOADONTH05_2015 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBO and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
and kh.GIABIEU='51'
ORDER BY  LOTRINH ASC


