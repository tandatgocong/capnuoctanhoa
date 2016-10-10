-- truy xuat all

SELECT CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15') 
                      THEN 'TB01' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30') 
                      THEN 'TB02' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50') 
                      THEN 'TP01' ELSE 'TP02' END END END AS TODS,   SUBSTRING(LOTRINH,1,2) as 'DOT',MADMA,kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NGAYGAN,DIENTHOAI
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND kh.QUAN <> '31'
ORDER BY  LOTRINH ASC
--


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NAM,DIENTHOAI
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NAM,DIENTHOAI
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
   AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
   AND SUBSTRING(LOTRINH,1,2) IN ('17','18','19','20')
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
UPDATE TB_DULIEUKHACHHANG SET CODE=DS.CODE,CHISOKYTRUOC=DS.CSMOI
FROM DocSo_PHT.dbo.DS2015 DS
WHERE DS.DANHBA= TB_DULIEUKHACHHANG.DANHBO AND DS.KY=12 AND CSMOI IS NOT NULL 

SELECT DOT FROM DocSo_PHT.dbo.DS2015 WHERE KY=12 GROUP BY DOT 



SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG,HIEUDH,CODH,SOTHANDH,CONVERT(VARCHAR(20),NGAYTHAY,103) as NGAYGAN,CONVERT(VARCHAR(20),NGAYKIEMDINH,103) as NGAYKD , VITRIDHN ,CODE,CHISOKYTRUOC
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
AND YEAR(NGAYTHAY)<=2012
ORDER BY  kh.LOTRINH ASC

SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG,HIEUDH,CODH,SOTHANDH,CONVERT(VARCHAR(20),NGAYTHAY,103) as NGAYGAN,CONVERT(VARCHAR(20),NGAYKIEMDINH,103) as NGAYKD , VITRIDHN ,CODE,CHISOKYTRUOC
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
AND YEAR(NGAYTHAY)<=2012
ORDER BY  kh.LOTRINH ASC


SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG,HIEUDH,CODH,SOTHANDH,CONVERT(VARCHAR(20),NGAYTHAY,103) as NGAYGAN,CONVERT(VARCHAR(20),NGAYKIEMDINH,103) as NGAYKD , VITRIDHN ,CODE,CHISOKYTRUOC
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
AND YEAR(NGAYTHAY)<=2012
ORDER BY  kh.LOTRINH ASC


SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG,HIEUDH,CODH,SOTHANDH,CONVERT(VARCHAR(20),NGAYTHAY,103) as NGAYGAN,CONVERT(VARCHAR(20),NGAYKIEMDINH,103) as NGAYKD , VITRIDHN,CODE,CHISOKYTRUOC 
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
 AND SUBSTRING(LOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
AND YEAR(NGAYTHAY)<=2012
ORDER BY  kh.LOTRINH ASC



------- lay so lieu  THAY

SELECT CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15') 
                      THEN 'TB01' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30') 
                      THEN 'TB02' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50') 
                      THEN 'TP01' ELSE 'TP02' END END END AS TODS,                      
 SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
  kh.CODH,SOTHANDH,  CONVERT(VARCHAR(50),ngaythay,103) AS 'NGAYTHAY' , CONVERT(VARCHAR(50),NGAYKIEMDINH,103) as 'NGAY KD'
FROM  TB_DULIEUKHACHHANG kh
WHERE  CODH='100'
order by kh.LOTRINH asc



SELECT CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15') 
                      THEN 'TB01' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30') 
                      THEN 'TB02' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50') 
                      THEN 'TP01' ELSE 'TP02' END END END AS TODS,                      
 SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH,
  kh.CODH,SOTHANDH, MONTH(ISNULL(NGAYTHAY,0)) AS THANGTHAY,YEAR(ISNULL(NGAYTHAY,0)) AS NAMTHAY,MONTH(ISNULL(NGAYKIEMDINH,0)) AS THANGKD,YEAR(ISNULL(NGAYKIEMDINH,0)) AS NAMKD,
     CONVERT(VARCHAR(50),ngaythay,103) AS 'NGAYTHAY' ,
      CONVERT(VARCHAR(50),NGAYKIEMDINH,103) as 'NGAY KD'
FROM  TB_DULIEUKHACHHANG kh WHERE YEAR(NGAYTHAY)<=2014
order by kh.LOTRINH asc



-----------------------------------------------------
SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE  YEAR(kh.NGAYTHAY)<=2012
 AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE  YEAR(kh.NGAYTHAY)<=2012
   AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE  YEAR(kh.NGAYTHAY)<=2012
  AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh
WHERE YEAR(kh.NGAYTHAY)<=2012
 AND SUBSTRING(LOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
ORDER BY  LOTRINH ASC


--------------- ANH DAM

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,kh.GIABIEU,kh.DINHMUC,kh.CHISOKYTRUOC, kh.CODE,
CONVERT(VARCHAR(50),kh.NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2012
 AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,kh.GIABIEU,kh.DINHMUC,kh.CHISOKYTRUOC, kh.CODE,
CONVERT(VARCHAR(50),NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2012
AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,kh.GIABIEU,kh.DINHMUC,kh.CHISOKYTRUOC, kh.CODE,
CONVERT(VARCHAR(50),NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2012
 AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,kh.GIABIEU,kh.DINHMUC,kh.CHISOKYTRUOC, kh.CODE,
CONVERT(VARCHAR(50),NGAYTHAY,103),CONVERT(VARCHAR(50),NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND  YEAR(kh.NGAYTHAY)<=2012
AND SUBSTRING(LOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
ORDER BY  LOTRINH ASC



----------------
 
SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN
FROM  TB_DULIEUKHACHHANG kh,[SERVER9].[HOADON_TA].[dbo].[HOADON] hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBA and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG 
AND p.MAPHUONG = '05' AND p.MAQUAN='31' AND hd.KY=7 and hd.NAM=2016 AND hd.TIEUTHU=0
ORDER BY  LOTRINH ASC



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
AND kh.DANHBO IN (   
SELECT DISTINCT DANHBA
FROM DocSo_PHT.dbo.DS2015  
WHERE TTDHN_MOI LIKE '%DN%' AND KY=8)
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

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM' , VITRIDHN,hd.GIABIEU,hd.DINHMUC
,hd.CODE,hd.CSMOI,hd.LNCC,CONVERT(varchar(50), NGAYTHAY,103), CONVERT(varchar(50),kh.NGAYKIEMDINH,103)
FROM  TB_DULIEUKHACHHANG kh,HOADONTH12_2015 hd
WHERE kh.DANHBO=hd.DANHBO  and hd.CODE='4'
AND hd.DANHBO IN (SELECT DANHBO FROM HOADONTH02_2016 WHERE CODE='K')
AND hd.DANHBO IN (SELECT DANHBO FROM HOADONTH08_2014 WHERE LNCC=0)
AND hd.DANHBO IN (SELECT DANHBO FROM HOADONTH07_2014 WHERE LNCC<>0)
ORDER BY  LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM',kh.DINHMUC,hd.CODE,hd.CSMOI, hd.TIEUTHU
FROM  TB_DULIEUKHACHHANG kh,DocSo_PHT.dbo.DS2015 hd,  PHUONG p, QUAN q
WHERE kh.DANHBO=hd.DANHBA and kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND hd.DOT=14 AND hd.KY=9  and hd.CODE='4'  and hd.MAY='22' and hd.TIEUTHU=0
ORDER BY  LOTRINH ASC

select * from DocSo_PHT.dbo.DS2015 hd where hd.DOT=14 AND hd.KY=10 

-- HOA DON =0

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS 'NAM',kh.DINHMUC,hd.CODE,hd.CSMOI, hd.TIEUTHU
FROM  TB_DULIEUKHACHHANG kh,[SERVER9].[HOADON_TA].[dbo].[HOADON] hd
WHERE kh.DANHBO=hd.DANHBA 
AND  hd.KY=8  AND hd.NAM=2016  and hd.TIEUTHU=0
AND kh.PHUONG='03' AND kh.QUAN='31'
ORDER BY  LOTRINH ASC


SELECT DOT FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] WHERE KY=8 AND NAM=2016 GROUP BY DOT


------ gia bieu


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,kh.HIEUDH, kh.CODH,kh.GIABIEU,kh.DINHMUC
FROM  TB_DULIEUKHACHHANG kh
WHERE  kh.GIABIEU=51 AND QUAN<>31
ORDER BY  LOTRINH ASC

