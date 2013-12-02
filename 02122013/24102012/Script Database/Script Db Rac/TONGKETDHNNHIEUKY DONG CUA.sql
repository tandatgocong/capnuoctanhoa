create view testter
as
SELECT
  kh.DANHBO,
  kh.HOTEN,
  kh.HOPDONG,
  (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=1 AND ds.CODE IN ('F1','64')
   ) AS CODEKY1,
  (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=2
   ) AS CODEKY2
   ,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=3
   ) AS CODEKY3,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=4
   ) AS CODEKY4,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=5
   ) AS CODEKY5,    
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=6
   ) AS CODEKY6,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=7
   ) AS CODEKY7,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=8
   ) AS CODEKY8,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=9
   ) AS CODEKY9,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=10
   ) AS CODEKY10,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=11
   ) AS CODEKY11,
   (
      SELECT TOP(1) ds.CODE
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=12
   ) AS CODEKY12
  FROM
  TB_DULIEUKHACHHANG kh










-- lấy dữ liệu các kỳ trước năm 2012

INSERT INTO DocSo_PHT.dbo.DS2012(DANHBA,CO,KY,TODS,DOT,MAY,TIEUTHU,CODECU,CODE,CSCU,CSMOI,MALOTRINH,MALOTRINH2,GB,DM)
SELECT DanhBo AS DANHBA, CoDh AS CO ,6 AS KY,
CASE WHEN SUBSTRING(Khu,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46') THEN 3 
ELSE CASE WHEN SUBSTRING(Khu,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15') THEN 1
ELSE  CASE WHEN SUBSTRING(Khu,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30') THEN 2 END END END  AS TODS 
,CONVERT(INT, LEFT(Khu,2)) AS DOT,CONVERT(INT, SUBSTRING(Khu,3,2)) AS MAY, hd.LNCC as TIEUTHU, hd.Code as CODECU, hd.Code as CODE, hd.CScu as CSCU, hd.CSmoi as CSMOI,
Khu as MALOTRINH,Khu as MALOTRINH2,hd.GiaBieu as GB, hd.DinhMuc AS DM
FROM HOADONTH06 hd
