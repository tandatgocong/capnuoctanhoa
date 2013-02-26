UPDATE KT_DMA SET  MLT= t2.LOTRINH 
FROM TB_DULIEUKHACHHANG t2
WHERE KT_DMA.DANHBO = t2.DANHBO


CREATE TABLE KT_DMA
(
	ID			INT IDENTITY(1,1),
	DOT		VARCHAR(255) NOT NULL,
	DANHBO		VARCHAR(255) NOT NULL,
	HOTEN		NVARCHAR(MAX),
	SONHA		NVARCHAR(MAX),
	TENDUONG	NVARCHAR(MAX),
	HOPDONG		VARCHAR(255),
	MLT			VARCHAR(255)
)
GO
SELECT * FROM KT_DMA ORDER BY MLT ASC