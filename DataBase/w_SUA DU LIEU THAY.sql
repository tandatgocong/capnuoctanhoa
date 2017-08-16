select * from TB_THAYDHN where DHN_DANHBO='13152231226' order by HCT_NGAYGAN desc

SELECT LEFT(HIEUDH,3),COUNT(*)
FROM TB_DULIEUKHACHHANG
GROUP BY LEFT(HIEUDH,3)

SELECT * FROM TB_DULIEUKHACHHANG WHERE HIEUDH IS NULL

UPDATE TB_DULIEUKHACHHANG
SET HIEUDH=TB_THAYDHN.HCT_HIEUDHNGAN,
	NGAYTHAY=TB_THAYDHN.HCT_NGAYGAN,
	SOTHANDH=TB_THAYDHN.HCT_SOTHANGAN,
	NGAYKIEMDINH = TB_THAYDHN.HCT_NGAYKIEMDINH,
	CODH=TB_THAYDHN.HCT_CODHNGAN
FROM TB_THAYDHN
WHERE TB_DULIEUKHACHHANG.DANHBO=TB_THAYDHN.DHN_DANHBO
AND  TB_THAYDHN.DHN_DANHBO='13041800166' AND TB_THAYDHN.DHN_TODS='DA'
	

select ID_BAOTHAY,DHN_DANHBO,HCT_HIEUDHNGAN,HCT_NGAYGAN,HCT_SOTHANGAN,HCT_NGAYKIEMDINH from TB_THAYDHN WHERE DHN_DANHBO='13101690350' order by ID_BAOTHAY desc
select ID,DANHBO,HIEUDH,NGAYTHAY,SOTHANDH,NGAYKIEMDINH from TB_DULIEUKHACHHANG WHERE  DANHBO='13101690350'  

UPDATE TB_DULIEUKHACHHANG
SET HIEUDH=TB_THAYDHN.HCT_HIEUDHNGAN,
	NGAYTHAY=TB_THAYDHN.HCT_NGAYGAN,
	SOTHANDH=TB_THAYDHN.HCT_SOTHANGAN,
	NGAYKIEMDINH = TB_THAYDHN.HCT_NGAYKIEMDINH,
	CODH=TB_THAYDHN.HCT_CODHNGAN,
	CHIGOC=TB_THAYDHN.HCT_CHIGOC,
	CHITHAN=TB_THAYDHN.HCT_CHITHAN	
FROM TB_THAYDHN
WHERE TB_DULIEUKHACHHANG.DANHBO=TB_THAYDHN.DHN_DANHBO
AND  ID_BAOTHAY='186761'