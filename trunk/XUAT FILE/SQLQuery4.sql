SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, YEAR(kh.NGAYTHAY) AS NAM
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, YEAR(kh.NGAYTHAY) AS NAM
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
ORDER BY  LOTRINH ASC

SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH , VITRIDHN, YEAR(kh.NGAYTHAY) AS NAM
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  LOTRINH ASC


SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH,SOTHANDH, VITRIDHN 
FROM TB_DULIEUKHACHHANG where SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC

SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH,SOTHANDH, VITRIDHN 
FROM TB_DULIEUKHACHHANG where SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  LOTRINH ASC

-----------------------------------------------
SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH,SOTHANDH, VITRIDHN 
SELECT LEFT(LOTRINH,2)kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND kh.QUAN='31' AND kh.PHUONG='06'
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  kh.LOTRINH ASC


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,SOTHANDH, YEAR(kh.NGAYTHAY) AS NAM, VITRIDHN
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND kh.QUAN='31' AND kh.PHUONG='06'
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  kh.LOTRINH ASC



------- lay so lieu 
drop table truysuat

SELECT LOTRINH,DANHBO, CASE WHEN MONTH(NGAYTHAY)<=5  THEN '0' ELSE MONTH(NGAYTHAY) END as 'KYTHAY', hd.TENDONGHO, CASE WHEN LEFT(kh.HIEUDH,3)='KEN'  THEN 'C' ELSE 'B' END as 'CAP', kh.CODH
INTO truysuat
FROM TB_DULIEUKHACHHANG kh, TB_HIEUDONGHO hd
WHERE MONTH(NGAYTHAY)<=8 AND YEAR(NGAYTHAY)=2012 AND DANHBO NOT IN (SELECT GANMOI_2012.DB FROM GANMOI_2012) AND LEFT(kh.HIEUDH,3) = hd.HIEUDH


select DANHBO, KYTHAY, TENDONGHO, CAP, CODH from truysuat  WHERE code=8
order by KYTHAY asc


SELECT * from  TB_DULIEUKHACHHANG 
WHERE DANHBO IN (SELECT DanhBo FROM HOADONTH01 where Code LIKE '8%')
  
  
UPDATE truysuat SET KYTHAY =8
FROM (SELECT * FROM HOADONTH08 where Field21 LIKE '8%'  ) as t2
WHERE  truysuat.DANHBO =  t2.DanhBo AND KYTHAY=0


insert into truysuat(LOTRINH, DANHBO, KYTHAY, TENDONGHO, CAP, CODH)
SELECT Khu as 'LOTRINH', HOADONTH01.DanhBo,'1',HIEU,CAP,CoDh 
FROM HOADONTH01 where Code LIKE '8%' AND NgayGan='2011'
AND DanhBo NOT IN (SELECT DANHBO FROM truysuat)
 
select KYTHAY,COUNT(*) from truysuat 
group by KYTHAY
order by KYTHAY asc


SELECT * fROM truysuat WHERE DANHBO IN (SELECT DANHBO FROM TB_GANMOI)

SELECT * fROM truysuat WHERE KYTHAY=2




UPDATE HOADONTH01 SET NgayGan = YEAR(t2.NGAYTHAY),HIEU=t2.TENDONGHO,CAP=CASE WHEN LEFT(t2.HIEUDH,3)='KEN'  THEN 'C' ELSE 'B' END, Khu=t2.LOTRINH


insert into DATKHUNG(DANHBO,KYTHAY)
SELECT DanhBo,'1'
FROM HOADONTH01
WHERE  code LIKE '8%'

SELECT LOTRINH,DANHBO, CASE WHEN MONTH(NGAYTHAY)<=5  THEN '0' ELSE MONTH(NGAYTHAY) END as 'KYTHAY', hd.TENDONGHO, CASE WHEN LEFT(kh.HIEUDH,3)='KEN'  THEN 'C' ELSE 'B' END as 'CAP', kh.CODH
INTO truysuat
FROM TB_DULIEUKHACHHANG kh, TB_HIEUDONGHO hd
WHERE MONTH(NGAYTHAY)<=8 AND YEAR(NGAYTHAY)=2012 AND DANHBO NOT IN (SELECT GANMOI_2012.DB FROM GANMOI_2012) AND LEFT(kh.HIEUDH,3) = hd.HIEUDH


select kh.DANHBO, MAX(dk.KYTHAY) as 'KYTHAY', hd.TENDONGHO, CASE WHEN LEFT(kh.HIEUDH,3)='KEN'  THEN 'C' ELSE 'B' END as 'CAP', kh.CODH
from DATKHUNG dk ,TB_DULIEUKHACHHANG kh, TB_HIEUDONGHO hd
where LEFT(kh.HIEUDH,3) = hd.HIEUDH and dk.DANHBO= kh.DANHBO
GROUP BY LOTRINH,kh.DANHBO, hd.TENDONGHO, CASE WHEN LEFT(kh.HIEUDH,3)='KEN'  THEN 'C' ELSE 'B' END, kh.CODH
