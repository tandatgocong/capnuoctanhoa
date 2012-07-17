SELECT DANHBO,LTCU,LTMOI
FROM TB_YEUCAUDC
WHERE DANHBO NOT IN (SELECT DANHBO FROM TB_GANMOI WHERE HIEULUC='08/2012')
AND KY=8 AND NAM=2012
ORDER BY LTCU ASC

SELECT LOTRINH, COUNT(*) FROM TB_DULIEUKHACHHANG 
GROUP BY LOTRINH HAVING COUNT(*)>2