SELECT * 
FROM dbo.TB_DULIEUKHACHHANG
WHERE DANHBO='13132120424'

SELECT * 
FROM dbo.TB_DULIEUKHACHHANG
WHERE DANHBO='13132123058'

UPDATE TB_DULIEUKHACHHANG
SET CHITHAN='CON',
	CHIGOC='CON'
WHERE CHITHAN IS NULL OR CHITHAN=''

UPDATE TB_DULIEUKHACHHANG
SET HIEUDH='KEN',