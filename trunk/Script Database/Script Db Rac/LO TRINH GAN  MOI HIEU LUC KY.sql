-- TAN BINH 01
select LEFT(LOTRINH,4), COUNT(*) from dbo.TB_DULIEUKHACHHANG
WHERE KY=8 AND NAM=2012
AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
GROUP BY LEFT(LOTRINH,4)
ORDER BY LEFT(LOTRINH,4) ASC

-- TAN BINH 02
select LEFT(LOTRINH,4), COUNT(*) from dbo.TB_DULIEUKHACHHANG
WHERE KY=8 AND NAM=2012
AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
GROUP BY LEFT(LOTRINH,4)
ORDER BY LEFT(LOTRINH,4) ASC
-- TAN PHU 
select LEFT(LOTRINH,4), COUNT(*) from dbo.TB_DULIEUKHACHHANG
WHERE KY=8 AND NAM=2012
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
GROUP BY LEFT(LOTRINH,4)
ORDER BY LEFT(LOTRINH,4) ASC

select COUNT(*) from dbo.TB_DULIEUKHACHHANG
WHERE KY=8 AND NAM=2012
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
GROUP BY LEFT(LOTRINH,4)
ORDER BY LEFT(LOTRINH,4) ASC

--------------------------------------------------------------------------------------

SELECT TODS,COUNT(*) AS TONG,
COUNT(case when (SUBSTRING(PLT,1,2)='01')  then 1 else null end) AS DOT01,
COUNT(case when (SUBSTRING(PLT,1,2)='02')  then 1 else null end) AS DOT02,
COUNT(case when (SUBSTRING(PLT,1,2)='03')  then 1 else null end) AS DOT03,
COUNT(case when (SUBSTRING(PLT,1,2)='04')  then 1 else null end) AS DOT04,
COUNT(case when (SUBSTRING(PLT,1,2)='05')  then 1 else null end) AS DOT05,
COUNT(case when (SUBSTRING(PLT,1,2)='06')  then 1 else null end) AS DOT06,
COUNT(case when (SUBSTRING(PLT,1,2)='07')  then 1 else null end) AS DOT07,
COUNT(case when (SUBSTRING(PLT,1,2)='08')  then 1 else null end) AS DOT08,
COUNT(case when (SUBSTRING(PLT,1,2)='09')  then 1 else null end) AS DOT09,
COUNT(case when (SUBSTRING(PLT,1,2)='10')  then 1 else null end) AS DOT10,
COUNT(case when (SUBSTRING(PLT,1,2)='11')  then 1 else null end) AS DOT11,
COUNT(case when (SUBSTRING(PLT,1,2)='12')  then 1 else null end) AS DOT12,
COUNT(case when (SUBSTRING(PLT,1,2)='13')  then 1 else null end) AS DOT13,
COUNT(case when (SUBSTRING(PLT,1,2)='14')  then 1 else null end) AS DOT14,
COUNT(case when (SUBSTRING(PLT,1,2)='15')  then 1 else null end) AS DOT15,
COUNT(case when (SUBSTRING(PLT,1,2)='16')  then 1 else null end) AS DOT16,
COUNT(case when (SUBSTRING(PLT,1,2)='17')  then 1 else null end) AS DOT17,
COUNT(case when (SUBSTRING(PLT,1,2)='18')  then 1 else null end) AS DOT18,
COUNT(case when (SUBSTRING(PLT,1,2)='19')  then 1 else null end) AS DOT19,
COUNT(case when (SUBSTRING(PLT,1,2)='20')  then 1 else null end) AS DOT20
FROM TB_GANMOI
WHERE HIEULUC='08/2012'
GROUP BY TODS
ORDER BY TODS


