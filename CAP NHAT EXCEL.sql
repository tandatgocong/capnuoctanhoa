UPDATE TB_DULIEUKHACHHANG
SET  HIEUDH = DULIEU_HANDHELD.HIEU,
	 SOTHANDH = DULIEU_HANDHELD.SOTHAN,
	 CHITHAN = 'CON',
	 CHIGOC = 'CON',	
	 VITRIDHN = DULIEU_HANDHELD.VITRI,
	 NGAYTHAY = '01/01/' + CONVERT(VARCHAR(20),DULIEU_HANDHELD.NAM)
 FROM DULIEU_HANDHELD
 WHERE TB_DULIEUKHACHHANG.DANHBO = DULIEU_HANDHELD.DANHBO

SELECT *
FROM DULIEU_HANDHELD
WHERE DULIEU_HANDHELD.NAM<2000

UPDATE DULIEU_HANDHELD
SET NAM='2011'
WHERE DANHBO IN ('12101906080','12101906119','12101906400')

SELECT *
FROM dbo.TB_DULIEUKHACHHANG
WHERE DANHBO IN ('12101906080','12101906119','12101906400')


-- TAN PHU

UPDATE TB_DULIEUKHACHHANG
SET  HIEUDH = TANPHU1.HIEU,
	 SOTHANDH = TANPHU1.SOTHAN,
	 SONHA = CASE WHEN SOMOI IS NULL THEN SOCU ELSE (SOCU+''+SOMOI) END,
	 CHITHAN = 'CON',
	 CHIGOC = 'CON',	
	 VITRIDHN = TANPHU1.VITRI,
	 NGAYTHAY = '01/01/' + CONVERT(VARCHAR(20),TANPHU1.NAM)
 FROM TANPHU1
 WHERE TB_DULIEUKHACHHANG.DANHBO = [TANPHU1].DANHBO

SELECT *
FROM [TANPHU]
WHERE [TANPHU].NAM>2012

SELECT (SOCU+''+SOMOI) AS DIACHI
FROM TANPHU
WHERE SOMOI LIKE N'%(%(%'

UPDATE TANPHU
SET SOMOI='('+SOMOI+')'
WHERE SOMOI NOT LIKE N'%(%'

DELETE FROM TANPHU




SELECT *
FROM TB_DULIEUKHACHHANG
WHERE ((LEFT(DANHBO,7) >= '1315221' AND LEFT(DANHBO,7) <= '1321999') OR LEFT(DANHBO,7) = '1314197'  OR LEFT(DANHBO,7) = '1314198')
AND SONHA LIKE N'%((%'
