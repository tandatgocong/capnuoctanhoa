CREATE VIEW TAPHOPSOLIEU
AS
SELECT     DANHBO, LOTRINH, HOTEN, HOPDONG, SONHA + ' ' + TENDUONG AS DIACHI,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 1) ) AS CODEKY1,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 1) AND (CODE NOT LIKE '%M%')) AS CSKY1,
                          (SELECT     TOP (1) TIEUTHU
                           FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 1) AND (CODE NOT LIKE '%M%')) AS TTKY1,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 2) ) AS CODEKY2,                            
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 2) AND (CODE NOT LIKE '%M%')) AS CSKY2,
                          (SELECT     TOP (1) TIEUTHU
                           FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 2) AND (CODE NOT LIKE '%M%')) AS TTKY2,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 3) ) AS CODEKY3,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 3) AND (CODE NOT LIKE '%M%')) AS CSKY3,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 3) AND (CODE NOT LIKE '%M%')) AS TTKY3,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 4) ) AS CODEKY4,
                          (SELECT     TOP (1) CSMOI
							FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 4) AND (CODE NOT LIKE '%M%')) AS CSKY4,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 4) AND (CODE NOT LIKE '%M%')) AS TTKY4,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 5) ) AS CODEKY5,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 5) AND (CODE NOT LIKE '%M%')) AS CSKY5,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 5) AND (CODE NOT LIKE '%M%')) AS TTKY5,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 6) ) AS CODEKY6,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 6) AND (CODE NOT LIKE '%M%')) AS CSKY6,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 6) AND (CODE NOT LIKE '%M%')) AS TTKY6,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 7) ) AS CODEKY7,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 7) AND (CODE NOT LIKE '%M%')) AS CSKY7,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 7) AND (CODE NOT LIKE '%M%')) AS TTKY7,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 8) ) AS CODEKY8,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 8) AND (CODE NOT LIKE '%M%')) AS CSKY8,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 8) AND (CODE NOT LIKE '%M%')) AS TTKY8,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 9) ) AS CODEKY9,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 9) AND (CODE NOT LIKE '%M%')) AS CSKY9,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 9) AND (CODE NOT LIKE '%M%')) AS TTKY9,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 10) ) AS CODEKY10,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 10) AND (CODE NOT LIKE '%M%')) AS CSKY10,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 10) AND (CODE NOT LIKE '%M%')) AS TTKY10,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 11) ) AS CODEKY11,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 11) AND (CODE NOT LIKE '%M%')) AS CSKY11,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 11) AND (CODE NOT LIKE '%M%')) AS TTKY11,
                          (SELECT     TOP (1) CODE
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 12) ) AS CODEKY12,
                          (SELECT     TOP (1) CSMOI
                            FROM          HOADON_TA.dbo.HOADON AS ds
                            WHERE      (ds.DANHBA = kh.DANHBO) AND NAM=2012 AND (KY = 12) AND (CODE NOT LIKE '%M%')) AS CSKY12,
                          (SELECT     TOP (1) TIEUTHU
                            FROM          DocSo_PHT.dbo.DS2012 AS ds
                            WHERE      (DANHBA = kh.DANHBO) AND (KY = 12) AND (CODE NOT LIKE '%M%')) AS TTKY12
FROM         dbo.TB_DULIEUKHACHHANG AS kh

SELECT * FROM TAPHOPSOLIEU WHERE TTKY7=0 AND ( TTKY8 <> 0 OR TTKY9 <> TTKY10 )

