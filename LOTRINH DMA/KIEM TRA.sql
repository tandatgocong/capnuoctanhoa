DELETE FROM DMA_TEST 

SELECT DANHBO,HOTEN,SONHA,TENDUONG,MADMA ,KY, NAM FROM TB_DULIEUKHACHHANG WHERE MADMA='TH-11-11'
AND DANHBO NOT IN (SELECT DANHBO FROM DMA_TEST)
ORDER BY  NAM desc, KY DESC

UPDATE DMA_TEST SET DANHBO= REPLACE(DANHBO,' ' ,'')

SELECT MADMA,COUNT(*)
FROM DMA_TEST
GROUP BY MADMA


SELECT * FROM DMA_TEST
WHERE DANHBO IN (SELECT DANHBO FROM DMA_TEST GROUP BY DANHBO HAVING COUNT(DANHBO) >1)
ORDER BY DANHBO ASC


-----------------------

SELECT  DANHBO,HOTEN, SONHA + ' ' + TENDUONG
FROM TB_DULIEUKHACHHANG_HUYDB
WHERE  DANHBO  IN (SELECT DANHBO FROM DMA_TEST )
AND  DANHBO NOT  IN (SELECT DANHBO FROM TB_DULIEUKHACHHANG )
ORDER BY MADMA ASC

SELECT DANHBO,HOTEN, SONHA + ' ' + TENDUONG,MADMA, KY_,NAM
FROM TB_DULIEUKHACHHANG
WHERE   DANHBO  IN (SELECT DANHBO FROM DMA_TEST  ) 
ORDER BY MADMA ASC




SELECT *
FROM DMA_TEST 
WHERE  DANHBO  NOT IN (SELECT DANHBO FROM TB_DULIEUKHACHHANG ) 


-------------------

UPDATE TB_DULIEUKHACHHANG SET MADMA='TH-03-09' WHERE DANHBO IN (SELECT DANHBO FROM DMA_TEST) AND MADMA = ''

 
 UPDATE TB_DULIEUKHACHHANG SET MADMA= ''  WHERE MADMA='TH-10-04'