
create view THIDUA_GIAMHOADON
as
SELECT
  kh.DANHBO,
  kh.LOTRINH,
  kh.HOTEN,
  kh.HOPDONG,
  (kh.SONHA + ' ' + TENDUONG) as 'DIACHI'
  ,
  (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=1 AND CODE NOT LIKE('%M%')
   ) AS CSKY1,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=1 AND CODE NOT LIKE('%M%')
   ) AS TTKY1,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=2 AND CODE NOT LIKE('%M%')
   ) AS CSKY2,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=2 AND CODE NOT LIKE('%M%')
   ) AS TTKY2,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=3 AND CODE NOT LIKE('%M%')
   ) AS CSKY3,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=3 AND CODE NOT LIKE('%M%')
   ) AS TTKY3,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=4 AND CODE NOT LIKE('%M%')
   ) AS CSKY4,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=4 AND CODE NOT LIKE('%M%')
   ) AS TTKY4,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=5 AND CODE NOT LIKE('%M%')
   ) AS CSKY5,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=5 AND CODE NOT LIKE('%M%')
   ) AS TTKY5,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=6 AND CODE NOT LIKE('%M%')
   ) AS CSKY6,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=6 AND CODE NOT LIKE('%M%')
   ) AS TTKY6,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=7 AND CODE NOT LIKE('%M%')
   ) AS CSKY7,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=7 AND CODE NOT LIKE('%M%')
   ) AS TTKY7,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=8 AND CODE NOT LIKE('%M%')
    ) AS CSKY8,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=8 AND CODE NOT LIKE('%M%')
   ) AS TTKY8,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=9 AND CODE NOT LIKE('%M%')
   ) AS CSKY9,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=9 AND CODE NOT LIKE('%M%')
   ) AS TTKY9,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=10 AND CODE NOT LIKE('%M%')
   ) AS CSKY10,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=10 AND CODE NOT LIKE('%M%')
   ) AS TTKY10,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=11 AND CODE NOT LIKE('%M%')
   ) AS CSKY11,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=11 AND CODE NOT LIKE('%M%')
   ) AS TTKY11,
   (
      SELECT TOP(1) ds.CSMOI
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=12 AND CODE NOT LIKE('%M%')
   ) AS CSKY12,
   (
      SELECT TOP(1) ds.TIEUTHU
      FROM DocSo_PHT.dbo.DS2012 ds
      WHERE ds.DANHBA=kh.DANHBO AND ds.KY=12 AND CODE NOT LIKE('%M%')
   ) AS TTKY12
  
  FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh
  
  
select top(20) TTKY1,TTKY2,TTKY3,TTKY4=0,TTKY5=0,TTKY6=0,TTKY7=0,TTKY8,TTKY9,TTKY10 from THIDUA_GIAMHOADON WHERE
TTKY1=0  and TTKY2=0  and  TTKY3=0 and TTKY4=0 and TTKY5=0 and TTKY6=0  and TTKY7=0 and (TTKY8<>0  or TTKY9<>0 or TTKY10<>0 )
  AND CONVERT(int,SUBSTRING(LOTRINH,3,2))= 40
  ORDER BY TTKY8 desc ,TTKY9 desc,TTKY10 desc
  
  , TB_NHANVIENDOCSO nv
  WHERE CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS AND LEFT(HIEUDH,3)  in ('ZEN','LUG','BAD','ROC','HER')
ORDER BY  nv.NAME ASC,kh.LOTRINH ASC
  
  
  ----
  
  SELECT * FROM testter
  
 -----------------------------------------

select * from PHANTICHHD order by dot asc

 SELECT DOT,DANHBA,MALOTRINH,CODE,CSCU,CSMOI,TIEUTHU
 INTO PHANTICHHD
 FROM DocSo_PHT.dbo.DS2015 ds
 WHERE ds.TIEUTHU=0
 
 UPDATE PHANTICHHD SET T08=hd.LNCC,CODE08=hd.CODE
 FROM HOADONTH08_2014 hd
 WHERE PHANTICHHD.DANHBA=hd.DANHBO
 

