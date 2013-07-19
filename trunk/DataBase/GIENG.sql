SELECT  *   FROM [DocSo_PHT].[dbo].[DS2013]  WHERE KY=7 AND DOT=1 AND MAY=36

    
GO


SELECT  [DocSo_PHT].[dbo].[DS2013].DOT, COUNT(*)
  FROM [DocSo_PHT].[dbo].[DS2013]
LEFT JOIN TB_DULIEUKHACHHANG
ON TB_DULIEUKHACHHANG.DANHBO = [DocSo_PHT].[dbo].[DS2013].DANHBA
 WHERE [DocSo_PHT].[dbo].[DS2013].KY=7 AND [DocSo_PHT].[dbo].[DS2013].GHICHUMOI LIKE N'%GIẾ%'
 GROUP BY [DocSo_PHT].[dbo].[DS2013].DOT
 ORDER BY [DocSo_PHT].[dbo].[DS2013].DOT ASC
 
 
SELECT  (case when (TODS=1)  then 'TB01' else case when (TODS=2)  then 'TB02' else 'TP' end end) , COUNT(*) AS TONGCONG,
COUNT(case when (SUBSTRING(MALOTRINH,1,2)='01')  then 1 else null end) AS DOT01
FROM [DocSo_PHT].[dbo].[DS2013]
WHERE KY=7 AND GHICHUMOI LIKE N'%GIẾ%'
GROUP BY (case when (TODS=1)  then 'TB01' else case when (TODS=2)  then 'TB02' else 'TP' end end)

