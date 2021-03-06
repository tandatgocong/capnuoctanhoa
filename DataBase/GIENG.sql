SELECT  *   FROM [DocSo_PHT].[dbo].[DS2013]  WHERE KY=7 AND DOT=1 AND MAY=36

    
GO


SELECT  [DocSo_PHT].[dbo].[DS2013].DOT, COUNT(*)
  FROM [DocSo_PHT].[dbo].[DS2013]
LEFT JOIN TB_DULIEUKHACHHANG
ON TB_DULIEUKHACHHANG.DANHBO = [DocSo_PHT].[dbo].[DS2013].DANHBA
 WHERE [DocSo_PHT].[dbo].[DS2013].KY=7 AND [DocSo_PHT].[dbo].[DS2013].GHICHUMOI LIKE N'%GIẾ%'
 GROUP BY [DocSo_PHT].[dbo].[DS2013].DOT
 ORDER BY [DocSo_PHT].[dbo].[DS2013].DOT ASC
 
 

SELECT  (case when (TODS=1)  then 'TB01' else case when (TODS=2)  then 'TB02' else 'TP' end end) AS TODS , COUNT(*) AS TONGCONG,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='01')  then 1 else null end) AS DOT01,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='02')  then 1 else null end) AS DOT02,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='03')  then 1 else null end) AS DOT03,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='04')  then 1 else null end) AS DOT04,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='05')  then 1 else null end) AS DOT05,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='06')  then 1 else null end) AS DOT06,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='07')  then 1 else null end) AS DOT07,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='08')  then 1 else null end) AS DOT08,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='09')  then 1 else null end) AS DOT09,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='10')  then 1 else null end) AS DOT10,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='11')  then 1 else null end) AS DOT11,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='12')  then 1 else null end) AS DOT12,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='13')  then 1 else null end) AS DOT13,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='14')  then 1 else null end) AS DOT14,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='15')  then 1 else null end) AS DOT15,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='16')  then 1 else null end) AS DOT16,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='17')  then 1 else null end) AS DOT17, 
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='18')  then 1 else null end) AS DOT18,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='19')  then 1 else null end) AS DOT19,  
	COUNT(case when (SUBSTRING(MALOTRINH,1,2)='20')  then 1 else null end) AS DOT20  
FROM [DocSo_PHT].[dbo].[DS2013] WHERE (KY=8 or KY=7) AND GHICHUMOI LIKE N'%GIẾ%' 
GROUP BY (case when (TODS=1)  then 'TB01' else case when (TODS=2)  then 'TB02' else 'TP' end end)


select q.MAQUAN,p.MAPHUONG, q.TENQUAN,p.TENPHUONG,COUNT(*)
FROM TB_DULIEUKHACHHANG kh, [DocSoTH].[dbo].[DocSo] ds ,QUAN q,PHUONG p
WHERE  ds.DANHBA=kh.DANHBO AND ds.KY=3  and ds.Nam=2016
AND GhiChuDS LIKE N'%GIẾ%' 
AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
group by  q.MAQUAN,p.MAPHUONG, q.TENQUAN,p.TENPHUONG
order by q.MAQUAN,p.MAPHUONG asc



SELECT SUBSTRING(LOTRINH,1,2) as 'DOT', kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH,kh.GIABIEU,kh.DINHMUC, SOTHANDH , VITRIDHN, convert(varchar(20),kh.NGAYTHAY,103) AS NAM,DIENTHOAI
FROM TB_DULIEUKHACHHANG kh, [DocSo_PHT].[dbo].[DS2016] ds ,QUAN q,PHUONG p
WHERE  ds.DANHBA=kh.DANHBO AND ds.KY=1 
AND GHICHUMOI LIKE N'%GIẾ%' AND kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG
AND q.MAQUAN=31 AND p.MAPHUONG='06'
ORDER BY kh.LOTRINH asc
