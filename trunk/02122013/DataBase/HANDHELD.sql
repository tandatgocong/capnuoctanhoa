SELECT * FROM DocSo_PHT.dbo.LENHDONGNUOC WHERE DANHBA IN (SELECT DANHBO FROM TB_DULIEUKHACHHANG WHERE KY=10 AND NAM=2013 ) and DANHBA='13152256181'


INSERT INTO LENHDONGNUOC(DANHBA, HIEU, CO, SOTHAN,LOAI_LENH, NGAYTHUCHIEN, GHICHU, NGAYCAPNHAT, SOLENH, NAM, CSDONG_MO) 
SELECT kh.DANHBO AS DANHBA,kh.HIEUDH AS HIEU,kh.CODH AS CO,kh.SOTHANDH AS SOTHAN,'2' AS LOAI_LENH,kh.NGAYTHAY AS NGAYTHUCHIEN,'GM' AS GHICHU,GETDATE() AS NGAYCAPNHAT,'123' AS SOLENH,2013 AS NAM,kh.CHISOKYTRUOC AS CSDONG_MO
FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh
where KY=9 AND NAM=2013 
                                         