-- TAN PHU
UPDATE TB_DULIEUKHACHHANG SET  PHUONG=t2.PHUONG,QUAN=t2.QUAN
FROM HANDHELD_TANPHU t2
WHERE TB_DULIEUKHACHHANG.DANHBO = t2.DANHBO


-- TAN BINH 01
UPDATE TB_DULIEUKHACHHANG SET  PHUONG=t2.PHUONG,QUAN=t2.QUAN
FROM HANDHELD t2
WHERE TB_DULIEUKHACHHANG.DANHBO = t2.DANHBO



-- update tong the
UPDATE HOADONTH05 SET  PHUONG=t2.PHUONG,QUAN=t2.QUAN
FROM TB_DULIEUKHACHHANG t2
WHERE HOADONTH05.DANHBO = t2.DANHBO

UPDATE HOADONTH05 SET  QUAN=31 where SUBSTRING(Field37,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44')
ORDER BY MALOTRINH ASC

-- SANG LUONG THEO QUAN PHUONG

SELECT QUAN,PHUONG,COUNT(*), SUM(LNCC) AS 'LNCC', SUM(LNCT) AS 'LNCC'
FROM HOADONTH05 where ((LEFT(DANHBO,7) >= '1315221' AND LEFT(DANHBO,7) <= '1321999') OR LEFT(DANHBO,7) = '1314197'  OR LEFT(DANHBO,7) = '1314198')
GROUP BY QUAN,PHUONG
ORDER BY QUAN,PHUONG

SELECT DANHBO,TENKH,SONHA,DUONG
FROM HOADONTH05 where ((LEFT(DANHBO,7) >= '1315221' AND LEFT(DANHBO,7) <= '1321999') OR LEFT(DANHBO,7) = '1314197'  OR LEFT(DANHBO,7) = '1314198') AND PHUONG=15


select *
FROM HOADONTH05 where  ((LEFT(DANHBO,7) >= '1315221' AND LEFT(DANHBO,7) <= '1321999') OR LEFT(DANHBO,7) = '1314197'  OR LEFT(DANHBO,7) = '1314198')

where SUBSTRING(Field37,3,2) not IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44') and LEFT(HOPDONG,2)='TP' and LEN(Field37)<8

 select DANHBO,TENKH,SONHA,DUONG
FROM HOADONTH05 where ((LEFT(DANHBO,7) >= '1315221' AND LEFT(DANHBO,7) <= '1321999') OR LEFT(DANHBO,7) = '1314197'  OR LEFT(DANHBO,7) = '1314198') AND PHUONG=15 
 
