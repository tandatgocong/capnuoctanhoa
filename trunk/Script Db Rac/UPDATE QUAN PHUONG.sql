-- TAN PHU
UPDATE TB_DULIEUKHACHHANG SET  PHUONG=t2.PHUONG,QUAN=t2.QUAN
FROM HANDHELD_TANPHU t2
WHERE TB_DULIEUKHACHHANG.DANHBO = t2.DANHBO


-- TAN BINH 01
UPDATE TB_DULIEUKHACHHANG SET  PHUONG=t2.PHUONG,QUAN=t2.QUAN
FROM HANDHELD t2
WHERE TB_DULIEUKHACHHANG.DANHBO = t2.DANHBO



-- update tong the
UPDATE HOADONTH05 SET  PHUONG=t2.PHUONG,QUAN=t2.QUAN
FROM TB_DULIEUKHACHHANG t2
WHERE HOADONTH05.DANHBO = t2.DANHBO

-- SANG LUONG THEO QUAN PHUONG

SELECT QUAN,PHUONG,COUNT(*), SUM(LNCC) AS 'LNCC', SUM(LNCT) AS 'LNCC'
FROM HOADONTH05
GROUP BY QUAN,PHUONG
ORDER BY QUAN,PHUONG

 