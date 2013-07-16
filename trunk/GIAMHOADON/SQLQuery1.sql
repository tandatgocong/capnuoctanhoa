ALTER VIEW HOADON0KY12
AS
	SELECT g05.*,tb01.CODE as 'CODE06',tb01.LNCC as 'LNCC06'
	FROM
	(
			select g04.*,tb01.CODE as 'CODE05',tb01.LNCC as 'LNCC05'
			from
			(
				select g03.*,tb01.CODE as 'CODE04',tb01.LNCC as 'LNCC04'
				from
					(select g02.*,tb01.CODE as 'CODE03',tb01.LNCC as 'LNCC03'
					 from
						(select g01.*,tb01.CODE as 'CODE02',tb01.LNCC as 'LNCC02'
						from
							( select t12.*,tb01.CODE as 'CODE01',tb01.LNCC as 'LNCC01'
							  from (select SUBSTRING(t12.KHU,1,2) as DOT, t12.KHU,t12.DANHBO,t12.HOPDONG,t12.TENKH,t12.SONHA,
								t12.DUONG,t12.PHUONG,t12.QUAN, t12.GIABIEU,t12.DINHMUC,t12.HIEUDH,t12.CODH,t12.NGAYTHAY,MADMA,NHANVIEN
								,t12.CODE as 'CODE12',t12.LNCC as 'LNCC12'			
							from HOADONTH12_2012 t12 where t12.LNCC=0 ) as t12 
							LEFT JOIN HOADONTH01_2013 tb01
							ON t12.DANHBO = tb01.DANHBO
							
							) as g01
						LEFT JOIN HOADONTH02_2013 tb01
						ON g01.DANHBO = tb01.DANHBO
						) as g02
					LEFT JOIN HOADONTH03_2013 tb01
					ON g02.DANHBO = tb01.DANHBO
					) as g03
				LEFT JOIN  HOADONTH04_2013 tb01
				ON g03.DANHBO = tb01.Danhbo
			 ) as g04
			LEFT JOIN HOADONTH05_2013 tb01
			ON g04.DANHBO = tb01.DANHBO
		) AS g05
		LEFT JOIN  HOADONTH06_2013 tb01
		ON g05.DANHBO = tb01.DANHBO
		


UPDATE HOADONTH12_2012 SET  PHUONG= t2.PHUONG, QUAN=t2.QUAN, KHU= t2.LOTRINH
FROM TB_DULIEUKHACHHANG t2
WHERE HOADONTH12_2012.DANHBO = t2.DANHBO
AND t2.DANHBO IN ('13152180186','13031251490','13132181782','13141990059','13132084980','13132150445','13152206471','13192596740','13212810420','13011039448','13041801216','13041816371','13132089871','13152206003','13152241026','13031172070','13041855279','13172417540','13202745339','13222898470','13152185089','13172419531','13041815518','13041824803','13122017486','13132150680','13192596700')

SELECT * FROM TB_DULIEUKHACHHANG where DANHBO='13041821646'
SELECT * FROM HOADONTH12_2012  where DANHBO='13041821646'

SELECT * FROM HOADON0KY12
ORDER BY KHU 

SELECT PHUONG,QUAN, COUNT(*)
FROM HOADON0KY12
GROUP BY PHUONG,QUAN
ORDER BY QUAN ASC, PHUONG ASC

SELECT PHUONG,QUAN, COUNT(*)
FROM HOADON0KY12 WHERE LNCC03=0
GROUP BY PHUONG,QUAN
ORDER BY QUAN ASC, PHUONG ASC

SELECT GIABIEU,COUNT(*)
FROM HOADON0KY12 WHERE LNCC03=0
GROUP BY GIABIEU
ORDER BY GIABIEU ASC

SELECT CODE12,COUNT(*)
FROM HOADON0KY12 WHERE LNCC03=0
GROUP BY CODE12
ORDER BY CODE12 ASC

SELECT COUNT(*)
FROM HOADON0KY12 WHERE LNCC05=0 

SELECT COUNT(*)
FROM HOADON0KY12 WHERE LNCC05 !=0 

SELECT COUNT(*) FROM HOADON0KY12 WHERE LNCC01 is not null AND  LNCC02 is not  null
AND  LNCC03 is  not null AND  LNCC04 is  not null
AND  LNCC05 is  null