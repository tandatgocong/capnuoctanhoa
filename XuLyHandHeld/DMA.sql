update DMA_TANPHU set DANHBO=REPLACE(DANHBO,' ','')

SELECT DANHBO FROM DMA_TANPHU   where DANHBO LIKE '0%' 
GROUP BY DANHBO

SELECT DANHBO FROM DMA_TANPHU 
GROUP BY DANHBO
HAVING COUNT(*) >=2

SELECT MALOTRINH,COUNT(*) FROM DMA_TANPHU 
GROUP BY MALOTRINH
HAVING COUNT(*) >=2



SELECT LOTRINH,DANHBO,HOPDONG,SONHA,TENDUONG,HOTEN, MADMA,KY,NAM
FROM  TB_DULIEUKHACHHANG kh
WHERE SUBSTRING(LOTRINH,3,2) NOT IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
  AND DANHBO NOT IN (select DANHBO from DMA_TANBINH01)
AND DANHBO NOT IN (SELECT DANHBO FROM DMA_TANBINH02 )
ORDER BY  LOTRINH ASC

  AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
  AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')


SELECT DANHBO FROM DMA_TANPHU 
WHERE DANHBO NOT IN  (SELECT DANHBO
FROM  TB_DULIEUKHACHHANG kh
WHERE SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')




update DMA_TANBINH01  set DANHBO=REPLACE(DANHBO,' ','')


SELECT SUBSTRING(LOTRINH,1,2) as 'DOT',kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,MADMA,KY,NAM
FROM  TB_DULIEUKHACHHANG kh
WHERE (SUBSTRING(LOTRINH,3,2)  IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
  OR SUBSTRING(LOTRINH,3,2)  IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15'))
AND DANHBO NOT IN (SELECT DANHBO FROM DMA_TANBINH01 )
ORDER BY  LOTRINH ASC

---------------------------------

select COUNT(*) from DMA_TANBINH01
select COUNT(*) from DMA_TANBINH02
select COUNT(*) from DMA_TANPHU
select COUNT(*) from TB_DULIEUKHACHHANG

-- kiem tra huy

SELECT * FROM DMA_TANBINH01 
WHERE DANHBO in (SELECT DANHBO FROM TB_DULIEUKHACHHANG_HUYDB)
and DANHBO not in (SELECT DANHBO FROM TB_DULIEUKHACHHANG)



SELECT DANHBO,LOTRINH,'',HOPDONG,HOTEN,SONHA,DUONG
 FROM DMA_TANBINH02 
WHERE DANHBO in (SELECT DANHBO FROM TB_DULIEUKHACHHANG_HUYDB)
and DANHBO not in (SELECT DANHBO FROM TB_DULIEUKHACHHANG)

SELECT DANHBO,LOTRINH,'',HOPDONG,TENKH,SONHA,DUONG
 FROM DMA_TANPHU
WHERE DANHBO in (SELECT DANHBO FROM TB_DULIEUKHACHHANG_HUYDB)
and DANHBO not in (SELECT DANHBO FROM TB_DULIEUKHACHHANG)


-- TRUNG CAC TO

SELECT SUBSTRING(DMA_TANBINH01.LOTRINH,0,2), * FROM DMA_TANBINH01 
WHERE DANHBO in (SELECT DANHBO FROM DMA_TANBINH02)
OR DANHBO  in (SELECT DANHBO FROM DMA_TANPHU)

SELECT * FROM DMA_TANBINH02 
WHERE DANHBO in (SELECT DANHBO FROM DMA_TANBINH01)
OR DANHBO  in (SELECT DANHBO FROM DMA_TANPHU)

SELECT * FROM DMA_TANPHU 
WHERE DANHBO in (SELECT DANHBO FROM DMA_TANBINH02)
OR DANHBO  in (SELECT DANHBO FROM DMA_TANBINH01 )

-------------------------------------------------------------------------------------------------------
UPDATE DMA_TANBINH01 SET NGAYDOC=KY01
FROM DMA_LICHDOC 
WHERE DMA_LICHDOC.DOT = SUBSTRING(LOTRINH,1,2)

UPDATE DMA_TANPHU SET NGAYDOC=KY01
FROM DMA_LICHDOC 
WHERE DMA_LICHDOC.DOT = SUBSTRING(LOTRINH,1,2)


alter VIEW V_TB_DULIEUKHACHHANG
AS
	SELECT kh.*,ds.KY12 FROM TB_DULIEUKHACHHANG kh, DMA_LICHDOC ds
	where SUBSTRING(LOTRINH,1,2)=ds.DOT


SELECT KH.DANHBO,SUBSTRING(KH.LOTRINH,1,2) AS 'DOT CU',KH.LOTRINH AS 'LO TRINH CU',
SUBSTRING(tb01.LOTRINH,1,2) AS 'DOT MOI',tb01.LOTRINH AS 'LO TRINH MOI',KH.GIABIEU,KH.DINHMUC,KH.KY12 ,tb01.NGAYDOC as ky1,
DATEDIFF(DD,KH.KY12,tb01.NGAYDOC),
(30-DAY(KH.KY12) + DAY(tb01.NGAYDOC)) AS SONGAY,
ROUND(((31-DAY(KH.KY12) + DAY(tb01.NGAYDOC)-30)*KH.DINHMUC)/30,0)+KH.DINHMUC AS CAPBU,
CASE WHEN (ROUND(((31-DAY(KH.KY12) + DAY(tb01.NGAYDOC)-30)*KH.DINHMUC)/30,0)+KH.DINHMUC)%2=1 THEN 
	(ROUND(((31-DAY(KH.KY12) + DAY(tb01.NGAYDOC)-30)*KH.DINHMUC)/30,0)+KH.DINHMUC)+1 ELSE ROUND(((31-DAY(KH.KY12) + DAY(tb01.NGAYDOC)-30)*KH.DINHMUC)/30,0)+KH.DINHMUC END AS LAMTRON
FROM V_TB_DULIEUKHACHHANG KH,  DMA_TANPHU tb01
WHERE KH.DANHBO=tb01.DANHBO AND SUBSTRING(KH.LOTRINH,1,2) != SUBSTRING(tb01.LOTRINH,1,2)
ORDER BY tb01.LOTRINH ASC



SELECT KH.DANHBO,KH.GIABIEU,DMA.GB,KH.DINHMUC,DMA.DM
FROM TB_DULIEUKHACHHANG KH, DMA_KHACHHANG DMA
WHERE KH.DANHBO=DMA.DANHBO


UPDATE TB_DULIEUKHACHHANG SET GIABIEU=DMA.GIABIEU,DINHMUC=DMA.DINHMUC
FROM HOADONTH11_2013 DMA
WHERE TB_DULIEUKHACHHANG.DANHBO=DMA.DANHBO 

-----------------------------]
SELECT SUBSTRING(tb01.LOTRINH,1,2) AS DOTCU,tb01.LOTRINH AS LOTRINHCU, SUBSTRING(KH.LOTRINH,1,2) AS DOTMOI,KH.LOTRINH AS LOTRINHMOI,
DATEDIFF(DD,KH.KY12,tb01.NGAYDOC) AS LECHNGAY,KH.DANHBO,KH.CODH,KH.HOPDONG,KH.HOTEN,KH.SONHA,KH.TENDUONG,KH.GIABIEU,KH.DINHMUC
INTO DMA_TONGLOTRINH
FROM V_TB_DULIEUKHACHHANG KH,  DMA_TANPHU tb01
WHERE KH.DANHBO=tb01.DANHBO
ORDER BY tb01.LOTRINH asc

DELETE  FROM DMA_TONGLOTRINH

INSERT INTO DMA_TONGLOTRINH
SELECT SUBSTRING(KH.LOTRINH,1,2) AS DOTCU,KH.LOTRINH AS LOTRINHCU,SUBSTRING(tb01.LOTRINH,1,2) AS DOTMOI,tb01.LOTRINH AS LOTRINHMOI, 
DATEDIFF(DD,KH.KY12,tb01.NGAYDOC) AS LECHNGAY,KH.DANHBO,KH.CODH,KH.HOPDONG,KH.HOTEN,KH.SONHA,KH.TENDUONG,KH.GIABIEU,KH.DINHMUC
FROM V_TB_DULIEUKHACHHANG KH,  DMA_TANPHU tb01
WHERE KH.DANHBO=tb01.DANHBO
ORDER BY tb01.LOTRINH asc


SELECT COUNT(*) FROM DMA_TONGLOTRINH 
SELECT COUNT(*) FROM DMA_KHACHHANG 

SELECT *
FROM DMA_TONGLOTRINH 
WHERE DANHBO='13182503013'

SELECT * FROM DMA_TONGLOTRINH  WHERE DANHBO  NOT IN (SELECT DANHBO FROM DMA_KHACHHANG )

SELECT * FROM DMA_TONGLOTRINH ORDER BY LEFT(LOTRINHMOI,2) ASC


SELECT LOTRINHMOI FROM DMA_TONGLOTRINH 
GROUP BY LOTRINHMOI
HAVING COUNT(LOTRINHMOI)>=2

DOTCU, LOTRINHCU, DOTMOI, LOTRINHMOI, LECHNGAY, DANHBO, CODH, HOPDONG, HOTEN, SONHA, TENDUONG, GIABIEU, DINHMUC

UPDATE DMA_TONGLOTRINH set DINHMUC='' where DINHMUC is null

SELECT '"'+DOTCU+'","'+LOTRINHCU+'","'+DOTMOI+'","'+LOTRINHMOI+'","'+CONVERT(VARCHAR(10),LECHNGAY)+'","'+DANHBO+'","'+CODH+'","'+HOPDONG+'","'+HOTEN+'","'+SONHA+'","'+TENDUONG+'","'+GIABIEU+'","'+DINHMUC+'"'
FROM DMA_TONGLOTRINH ORDER BY LEFT(LOTRINHMOI,2) ASC

DANHBO,DOT MOI, BOOK_NO MOI, STT MOI, DINH MUC MOI,NGUOI KY, NGAY_KY, SO QUYET DINH

UPDATE DMA_KHACHHANG SET DM=TB_DULIEUKHACHHANG.DINHMUC
FROM TB_DULIEUKHACHHANG 
where DMA_KHACHHANG.DANHBO=TB_DULIEUKHACHHANG.DANHBO

SELECT '"' +DANHBO+'","' + LEFT(LOTRINHMOI,2) +'","' + SUBSTRING(LOTRINHMOI,3,2)+'","' + SUBSTRING(LOTRINHMOI,5,5)+'","' + DMBU2+'"'
FROM DMA_TONGLOTRINH where DMBU <> ''
ORDER BY LOTRINHMOI ASC

"13172412391","08","43","14300","40"

SELECT LECHNGAY, COUNT(*) FROM DMA_TONGLOTRINH
GROUP BY LECHNGAY
ORDER BY LECHNGAY ASC


SELECT * FROM DMA_TONGLOTRINH WHERE DANHBO='13172412391'

select *
FROM DMA_TONGLOTRINH 
where LECHNGAY>=34
ORDER BY LOTRINHMOI ASC


UPDATE TB_DULIEUKHACHHANG SET DOT =DOTMOI,LOTRINH = LOTRINHMOI
FROM DMA_TONGLOTRINH
WHERE DMA_TONGLOTRINH.DANHBO = TB_DULIEUKHACHHANG.DANHBO
AND DOTMOI IN ('11','12','13','14','15','16','17','18','19','20')



UPDATE [DocSo_PHT].[dbo].[KHACHHANG] SET MALOTRINH =kh.LOTRINH,MALOTRINH2 = kh.LOTRINH
,[DocSo_PHT].[dbo].[KHACHHANG].DOT=LEFT(kh.LOTRINH,2),
[DocSo_PHT].[dbo].[KHACHHANG].MAY=SUBSTRING(kh.LOTRINH,3,2)
FROM TB_DULIEUKHACHHANG kh
WHERE kh.DANHBO = [DocSo_PHT].[dbo].[KHACHHANG].DANHBA


AND DOTMOI IN ('11','12','13','14','15','16','17','18','19','20')



