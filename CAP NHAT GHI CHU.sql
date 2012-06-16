/****** Script for SelectTopNRows command from SSMS  ******/
SELECT NGAYCN,DB,
CASE LDon
         WHEN 'DM' THEN N'Điều Chỉnh Định Mức Từ '+ convert(varchar(20),DM) +' -> ' +convert(varchar(20),DMDC)   
         WHEN 'GB' THEN N'Điều Chỉnh Giá Biểu Từ  '+ convert(varchar(20),GB) +' -> ' +convert(varchar(20),GBDC)       
END AS 'NOIDUNG'
FROM [CAPNUOCTANHOA].[dbo].[Bang_Ke_Dieu_Chinh_Table]
WHERE NAM in ('2009','2010','2011','2012')  AND LDon IN ('GB') 

SELECT  HCT_NGAYGAN,DHN_DANHBO,
CASE DHN_LOAIBANGKE
         WHEN 'DK' THEN N'Thay ĐHN Định Kỳ'   
         WHEN 'BB' THEN N'Thay ĐHN ' + DHN_LYDOTHAY     
         WHEN 'BT' THEN N'Thay ĐHN Bồi Thường'   
         WHEN 'DC' THEN N'Thay ĐHN Đứt Chì'
         WHEN 'KM' THEN N'Thay ĐHN Kính Mờ'   
         WHEN 'NG' THEN N'Thay ĐHN Ngưng'     
END AS 'NOIDUNG'
FROM  TB_THAYDHN
WHERE HCT_TRONGAI = 'False' AND HCT_NGAYGAN IS NOT NULL

------------------------

INSERT INTO TB_GHICHU (DANHBO,NOIDUNG,DONVI, CREATEDATE)
SELECT DB as DANHBO,
CASE LDon
         WHEN 'DM' THEN N'Điều Chỉnh Định Mức Từ '+ convert(varchar(20),DM) +' -> ' +convert(varchar(20),DMDC)   
         WHEN 'GB' THEN N'Điều Chỉnh Giá Biểu Từ  '+ convert(varchar(20),GB) +' -> ' +convert(varchar(20),GBDC)       
END AS NOIDUNG,'KTKS' as DONVI,NGAYCN AS CREATEDATE
FROM [CAPNUOCTANHOA].[dbo].[Bang_Ke_Dieu_Chinh_Table]
WHERE NAM in ('2009','2010','2011','2012')  AND LDon IN ('GB','DM') 


---------------------------
INSERT INTO TB_GHICHU (DANHBO,NOIDUNG,DONVI, CREATEDATE)
SELECT  DHN_DANHBO AS DANHBO,
CASE DHN_LOAIBANGKE
         WHEN 'DK' THEN N'Thay ĐHN Định Kỳ'   
         WHEN 'BB' THEN N'Thay ĐHN ' + DHN_LYDOTHAY     
         WHEN 'BT' THEN N'Thay ĐHN Bồi Thường'   
         WHEN 'DC' THEN N'Thay ĐHN Đứt Chì'
         WHEN 'KM' THEN N'Thay ĐHN Kính Mờ'   
         WHEN 'NG' THEN N'Thay ĐHN Ngưng'     
END AS 'NOIDUNG','DHN' as DONVI,HCT_NGAYGAN AS CREATEDATE
FROM  TB_THAYDHN
WHERE HCT_TRONGAI = 'False' AND HCT_NGAYGAN IS NOT NULL
