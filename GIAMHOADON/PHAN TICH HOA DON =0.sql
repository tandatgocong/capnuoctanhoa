SELECT COUNT(*)
FROM HOADONTH12_2012 K12, [DocSo_PHT].[dbo].[DS2013] ds
WHERE ds.KY=6  AND K12.DANHBO= ds.DANHBA AND K12.LNCC!=0 AND ds.TIEUTHU =0

SELECT COUNT(*)
FROM HOADONTH12_2012 K12, HOADONTH01_2013 K01
WHERE K12.DANHBO= K01.DANHBO AND K12.LNCC =0 AND K01.LNCC =0