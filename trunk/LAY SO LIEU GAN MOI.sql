INSERT INTO KHACHHANG (MAQUAN,MAPHUONG,TODS, MAY, DOT, DANHBA, HOPDONG, TENKH, SO, DUONG, GB, DM, TILESH, TILEHCSN, TILESX, TILEKD, MALOTRINH,MALOTRINH2, HIEULUCKY, NAM, NGAYGAN, CHISO, TIEUTHU, CODE,HIEU,SOTHAN)
SELECT kh.QUAN AS MAQUAN ,kh.PHUONG AS MAPHUONG ,'3' AS TODS,SUBSTRING(LOTRINH,3,2) AS MAY,SUBSTRING(LOTRINH,1,2) AS DOT,kh.DANHBO AS DANHBA,HOPDONG,
	   kh.HOTEN as TENKH,kh.SONHA as SO, kh.TENDUONG as DUONG, kh.GIABIEU AS GB, kh.DINHMUC AS DM, '0' AS TILESH, '0' AS TILEHCSN, '0' AS TILESX, '0' AS TILEKD ,
	   kh.LOTRINH AS MALOTRINH , kh.LOTRINH AS MALOTRINH2 , convert(varchar(20),kh.KY)+'/'+convert(varchar(20),kh.NAM) AS HIEULUCKY, kh.NAM AS NAM,
	   kh.NGAYTHAY AS NGAYGAN, kh.CHISOKYTRUOC AS CHISO, '0' AS TIEUTHU, kh.CODE AS CODE, HIEUDH AS HIEU, SOTHANDH AS SOTHAN
FROM  CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh 
WHERE kh.KY= 7 AND  kh.DANHBO NOT IN (SELECT DANHBA FROM DocSo_PHT.dbo.KHACHHANG)

SELECT * FROM DocSo_PHT.dbo.KHACHHANG  WHERE DANHBA='13031135448'
SELECT * FROM DocSo_PHT.dbo.DS2012  WHERE DANHBA='13031135448'

-- CAP NHAT LO TRINH

UPDATE TB_DULIEUKHACHHANG SET  LOTRINH=t2.LOTRINH
FROM CAPNUOCTANHOA.dbo.HANDHELD as t2
WHERE TB_DULIEUKHACHHANG.DANHBO = t2.DANHBO
  AND LEFT(t2.LOTRINH,4) IN ('0109','0106')
  
  
UPDATE KHACHHANG SET  MALOTRINH=t2.LOTRINH ,MALOTRINH2=t2.LOTRINH
FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2
WHERE KHACHHANG.DANHBA = t2.DANHBO

  AND LEFT(t2.LOTRINH,4) IN ('0109','0106')
  
SELECT LEFT(t2.LOTRINH,4)
FROM CAPNUOCTANHOA.dbo.HANDHELD as t2


select * from  dbo.KHACHHANG where LEFT(MALOTRINH,4)='0718'

UPDATE dbo.KHACHHANG SET MALOTRINH2=MALOTRINH

