CREATE TABLE [dbo].[W_SOLIEUHD](
	[DANHBO] [varchar](20) NULL,
	[T0] [int] NULL,
	[C0] varchar(10) NULL,
	[T1] [int] NULL,
	[C1] varchar(10) NULL,
	[T2] [int] NULL,
	[C2] varchar(10) NULL,
	[T3] [int] NULL,
	[C3] varchar(10) NULL,
	[T4] [int] NULL,
	[C4] varchar(10) NULL,
	[T5] [int] NULL,
	[C5] varchar(10) NULL,
	[T6] [int] NULL,
	[C6] varchar(10) NULL,
	[T7] [int] NULL,
	[C7] varchar(10) NULL,
	[T8] [int] NULL,
	[C8] varchar(10) NULL,
	[T9] [int] NULL,
	[C9] varchar(10) NULL,
	[T10] [int] NULL,
	[C10] varchar(10) NULL,
	[T11] [int] NULL,
	[C11] varchar(10) NULL,
	[T12] [int] NULL,
	[C12] varchar(10) NULL,
	)
	
----------------------

SELECT MAX(DOT) FROM HOADON WHERE KY=2 AND NAM=2016


SELECT h.DOT, sl.DANHBO,h.HOPDONG,h.TENKH,h.SO,h.DUONG,h.GB,h.DM, T0, C0, T1, C1, T2, C2, T3, C3, T4, C4, T5, C5, T6, C6, T7, C7, T8, C8, T9, C9, T10, C10, T11, C11, T12, C12
FROM HOADON h,W_SOLIEUHD sl
WHERE h.DANHBA=sl.DANHBO and h.KY=12 and h.NAM=2015
order by h.MALOTRINH asc


INSERT INTO W_SOLIEUHD(DANHBO,T0,C0)
SELECT h.DANHBA, h.TIEUTHU as 'T0',h.CODE as 'C0'
FROM HOADON h
WHERE KY=12 AND NAM=2015 AND TIEUTHU=0;

UPDATE W_SOLIEUHD SET T1 =hd.TIEUTHU,C1=hd.CODE
FROM HOADON hd
WHERE W_SOLIEUHD.DANHBO= hd.DANHBA  and KY=1 and NAM=2016

UPDATE W_SOLIEUHD SET T2 =hd.TIEUTHU,C2=hd.CODE
FROM HOADON hd
WHERE W_SOLIEUHD.DANHBO= hd.DANHBA  and KY=2 and NAM=2016