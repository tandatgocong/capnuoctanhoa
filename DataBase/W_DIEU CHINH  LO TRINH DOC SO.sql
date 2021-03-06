

--THAY DHN

UPDATE TB_DULIEUKHACHHANG SET  
	HIEUDH=TB_THAYDHN.HCT_HIEUDHNGAN,
	CODH=TB_THAYDHN.HCT_CODHNGAN,
	SOTHANDH=TB_THAYDHN.HCT_SOTHANGAN,
	NGAYTHAY=TB_THAYDHN.HCT_NGAYGAN,
	NGAYKIEMDINH=TB_THAYDHN.HCT_NGAYKIEMDINH	
FROM TB_THAYDHN
WHERE  TB_DULIEUKHACHHANG.DANHBO=TB_THAYDHN.DHN_DANHBO
AND  TB_THAYDHN.DHN_TODS='DA'


UPDATE TB_DULIEUKHACHHANG SET  
	HIEUDH=TB_THAYDHN.HCT_HIEUDHNGAN,
	CODH=TB_THAYDHN.HCT_CODHNGAN,
	SOTHANDH=TB_THAYDHN.HCT_SOTHANGAN,
	NGAYTHAY=TB_THAYDHN.HCT_NGAYGAN,
	NGAYKIEMDINH=TB_THAYDHN.HCT_NGAYKIEMDINH	
FROM TB_THAYDHN
WHERE  TB_DULIEUKHACHHANG.DANHBO=TB_THAYDHN.DHN_DANHBO
AND  MONTH(TB_THAYDHN.HCT_CREATEDATE)=8 AND YEAR(TB_THAYDHN.HCT_CREATEDATE)=2015




---- TAN BINH 1
SELECT * FROM KHACHHANG WHERE DANHBA='13172426454'
SELECT * FROM DS2015 WHERE DANHBA='13172426454'
SELECT MAX(KY) FROM DS2015 WHERE DANHBA='13172426454'
SELECT * FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG  WHERE DANHBO='13172426454'



UPDATE KHACHHANG SET 
	DOT=CONVERT(int,LEFT(KH.LOTRINH,2)),
	MAY=CONVERT(int,SUBSTRING(KH.LOTRINH,3,2)),
	HIEULUC=1,
	MALOTRINH=KH.LOTRINH,
	MALOTRINH2=KH.LOTRINH		
FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG KH
WHERE  KHACHHANG.DANHBA=KH.DANHBO 
AND  KH.DANHBO='13212797350'

UPDATE DS2015 SET  
	DOT=CONVERT(int,LEFT(KH.LOTRINH,2)),
	MAY=CONVERT(int,SUBSTRING(MALOTRINH,3,2)),
	MALOTRINH=KH.LOTRINH,
	MALOTRINH2=KH.LOTRINH		
FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG KH
WHERE  DS2015.DANHBA=KH.DANHBO 
AND  KH.DANHBO='13172426781' AND DS2015.KY=3


SELECT KH.MAY, COUNT(KH.DANHBA) AS SODANHBA 
FROM KHACHHANG AS KH 
LEFT OUTER JOIN MAYDOCSO AS M 
ON KH.MAY = M.MAY 
WHERE (KH.DOT = 2) AND (KH.HIEULUC = 1) 
	AND (KH.MAY IS NOT NULL) AND (KH.MAY <> '') 
	AND (M.TODS = 1) 
GROUP BY KH.MAY ORDER BY KH.MAY


SELECT DANHBA,MALOTRINH,MALOTRINH2,SUBSTRING(MALOTRINH,3,2),MAY
FROM KHACHHANG
WHERE DOT=1 AND TODS=4
ORDER BY MALOTRINH ASC


---- TAN PHU 2
SELECT MALOTRINH,MALOTRINH2
FROM KHACHHANG WHERE TODS=4 AND MALOTRINH<>MALOTRINH2

UPDATE KHACHHANG SET TODS=1, DOT=LEFT(MALOTRINH,2),MAY=CONVERT(int,SUBSTRING(MALOTRINH,3,2))
WHERE  SUBSTRING(MALOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66')


SELECT DANHBA,MALOTRINH,MALOTRINH2,SUBSTRING(MALOTRINH,3,2),MAY
FROM KHACHHANG
WHERE DOT=1 AND TODS=4
ORDER BY MALOTRINH ASC

SELECT TODS,COUNT(*)
FROM  KHACHHANG
GROUP BY TODS

UPDATE KHACHHANG SET HIEULUC=1 WHERE TODS=4




UPDATE KHACHHANG SET TODS=1
WHERE  SUBSTRING(MALOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')


UPDATE KHACHHANG SET TODS=2
WHERE  SUBSTRING(MALOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')

UPDATE KHACHHANG SET TODS=3
WHERE SUBSTRING(MALOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50')

UPDATE KHACHHANG SET TODS=4
WHERE SUBSTRING(MALOTRINH,3,2) IN ('51','52','53','54','55','56','57','58','59','60','61','62','63','64','65','66','67','67','69','70')
