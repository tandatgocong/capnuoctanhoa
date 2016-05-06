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


-------------------------


CREATE TABLE [dbo].[W_SOLIEUHD0](
	[STT] [INT] NULL,
	[NHANVIEN] [varchar](250) NULL,
	[DANHBO] [Nvarchar](20) NULL,
	[DIACHI] [Nvarchar](250) NULL,
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

UPDATE W_SOLIEUHD0 SET DANHBO=REPLACE(DANHBO,' ','')

SELECT sl.STT, h.DOT,sl.NHANVIEN, sl.DANHBO,sl.DIACHI,h.GB,h.DM, T0, C0, T1, C1, T2, C2, T3, C3, T4, C4, T5, C5, T6, C6, T7, C7, T8, C8, T9, C9, T10, C10, T11, C11, T12, C12
FROM W_SOLIEUHD0 sl
LEFT JOIN HOADON h
ON h.DANHBA=sl.DANHBO
WHERE h.DANHBA=sl.DANHBO and h.KY=12 and h.NAM=2015
order by sl.STT asc



UPDATE W_SOLIEUHD0 SET T0 =hd.TIEUTHU,C0=hd.CODE
FROM HOADON hd
WHERE W_SOLIEUHD0.DANHBO= hd.DANHBA  and KY=12 and NAM=2015


UPDATE W_SOLIEUHD0 SET T1 =hd.TIEUTHU,C1=hd.CODE
FROM HOADON hd
WHERE W_SOLIEUHD0.DANHBO= hd.DANHBA  and KY=1 and NAM=2016

UPDATE W_SOLIEUHD0 SET T2 =hd.TIEUTHU,C2=hd.CODE
FROM HOADON hd
WHERE W_SOLIEUHD0.DANHBO= hd.DANHBA  and KY=2 and NAM=2016

---------------------------------


CREATE TABLE [dbo].[W_SOLIEUHD2016=0](
	[DANHBO] [varchar](20) NULL,
	[T1] [int] NULL,[C1] varchar(10) NULL,
	[T2] [int] NULL,[C2] varchar(10) NULL,
	[T3] [int] NULL,[C3] varchar(10) NULL,
	[T4] [int] NULL,[C4] varchar(10) NULL,
	[T5] [int] NULL,[C5] varchar(10) NULL,
	[T6] [int] NULL,[C6] varchar(10) NULL,
	[T7] [int] NULL,[C7] varchar(10) NULL,
	[T8] [int] NULL,[C8] varchar(10) NULL,
	[T9] [int] NULL,[C9] varchar(10) NULL,
	[T10] [int] NULL,[C10] varchar(10) NULL,
	[T11] [int] NULL,[C11] varchar(10) NULL,
	[T12] [int] NULL,[C12] varchar(10) NULL,
	[T12015] [int] NULL,[C12015] varchar(10) NULL,
	[T22015] [int] NULL,[C22015] varchar(10) NULL,
	[T32015] [int] NULL,[C32015] varchar(10) NULL,
	[T42015] [int] NULL,[C42015] varchar(10) NULL,
	[T52015] [int] NULL,[C52015] varchar(10) NULL,
	[T62015] [int] NULL,[C62015] varchar(10) NULL,
	[T72015] [int] NULL,[C72015] varchar(10) NULL,
	[T82015] [int] NULL,[C82015] varchar(10) NULL,
	[T92015] [int] NULL,[C92015] varchar(10) NULL,
	[T102015] [int] NULL,[C102015] varchar(10) NULL,
	[T112015] [int] NULL,[C112015] varchar(10) NULL,
	[T122015] [int] NULL,[C122015] varchar(10) NULL
) ON [PRIMARY]

GO

INSERT INTO [W_SOLIEUHD2016=0](DANHBO,T4,C4)
SELECT h.DANHBA, h.TIEUTHU as 'T4',h.CODE as 'C4'
FROM HOADON h
WHERE KY=4 AND NAM=2016 AND TIEUTHU=0;


UPDATE [W_SOLIEUHD2016=0] SET T1 =hd.TIEUTHU,C1=hd.CODE
FROM HOADON hd
WHERE [W_SOLIEUHD2016=0].DANHBO= hd.DANHBA  and KY=1 and NAM=2016

UPDATE [W_SOLIEUHD2016=0] SET T2 =hd.TIEUTHU,C2=hd.CODE
FROM HOADON hd
WHERE [W_SOLIEUHD2016=0].DANHBO= hd.DANHBA  and KY=2 and NAM=2016


UPDATE [W_SOLIEUHD2016=0] SET T3 =hd.TIEUTHU,C3=hd.CODE
FROM HOADON hd
WHERE [W_SOLIEUHD2016=0].DANHBO= hd.DANHBA  and KY=3 and NAM=2016


UPDATE [W_SOLIEUHD2016=0] SET T122015 =hd.TIEUTHU,C122015=hd.CODE
FROM HOADON hd
WHERE [W_SOLIEUHD2016=0].DANHBO= hd.DANHBA  and KY=12 and NAM=2015



SELECT h.DOT, sl.DANHBO,h.HOPDONG,h.TENKH,h.SO,h.DUONG,h.GB,h.DM, h.Quan,h.Phuong,  T12015, C12015, T22015, C22015, T32015, C32015, T42015, C42015, T52015, C52015, T62015, C62015, T72015, C72015, T82015, C82015, T92015, C92015, T102015, C102015, T112015, C112015, T122015, C122015, T1, C1, T2, C2, T3, C3, T4, C4
FROM HOADON h,[W_SOLIEUHD2016=0] sl
WHERE h.DANHBA=sl.DANHBO and h.KY=4 and h.NAM=2016
order by h.Quan asc,h.Phuong asc