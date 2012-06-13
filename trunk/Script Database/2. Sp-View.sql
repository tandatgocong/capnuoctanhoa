--- To Thay Dong Ho Nuoc
DROP VIEW V_DHN_BANGKE
GO

CREATE VIEW V_DHN_BANGKE
AS
	SELECT loai.TENBANGKE,kh.HOPDONG,kh.LOTRINH,kh.HOTEN,kh.SONHA,kh.TENDUONG,thay.*
	FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh
	WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK
GO

DROP VIEW V_TCTB_TKVATTUTHAY
GO

CREATE VIEW V_TCTB_TKVATTUTHAY
AS
	SELECT STT,MAVT,TENVT,DVT,SUM(SOLUONG) AS 'TONGSL'
	FROM TB_VATUTHAY_DHN 
	GROUP BY  STT,MAVT,TENVT,DVT
GO


DROP VIEW V_TCTB_HOANCONGNHANH
GO

CREATE VIEW V_TCTB_HOANCONGNHANH
AS 
	SELECT HCT_NGAYGAN,CASE WHEN DHN_LOAIBANGKE='DK' THEN N'ĐỊNH KỲ' ELSE N'HƯ' END AS 'DHN_LOAIBANGKE',(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) AS 'TENBK'
	,count(case when HCT_TRONGAI ='0' then 1 else null end) AS 'HOANTAT'  
	,count(case when HCT_TRONGAI ='1' then 1 else null end) AS 'TRONGAI'  
	FROM TB_THAYDHN 
	GROUP BY (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)),HCT_NGAYGAN,CASE WHEN DHN_LOAIBANGKE='DK' THEN N'ĐỊNH KỲ' ELSE N'HƯ' END
GO

DROP VIEW V_SEARCH
GO

CREATE VIEW V_SEARCH
AS 
	SELECT ID_BAOTHAY,LOTRINH,DHN_LOAIBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) AS 'DHN_SOBANGKE', DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_NGAYBAOTHAY,DHN_NGAYGAN,DHN_CHITHAN,DHN_CHIGOC,DHN_HIEUDHN,DHN_CODH,DHN_SOTHAN,DHN_CHISO,DHN_LYDOTHAY 
	,HCT_CAP , HCT_CHISOGO, HCT_SOTHANGO, HCT_HIEUDHNGAN, HCT_CODHNGAN, HCT_SOTHANGAN, HCT_CHISOGAN, HCT_LOAIDHGAN, HCT_NGAYGAN, HCT_CHITHAN, HCT_CHIGOC, HCT_TRONGAI, HCT_LYDOTRONGAI,HCT_NGAYKIEMDINH, (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) AS SO_BANGKE
	FROM TB_THAYDHN thay,TB_DULIEUKHACHHANG kh
	WHERE kh.DANHBO=thay.DHN_DANHBO
GO

DROP VIEW V_THONGKEDHN
GO

CREATE VIEW V_THONGKEDHN
AS 
	SELECT TENDONGHO,
	COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
	COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
	COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
	COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
	COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
	COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
	COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
	COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
	FROM dbo.TB_DULIEUKHACHHANG kh,TB_HIEUDONGHO hdh
	WHERE LEFT(kh.HIEUDH,3)=hdh.HIEUDH AND kh.HIEUDH IS NOT NULL AND kh.HIEUDH !=''
	GROUP BY TENDONGHO
GO

DROP VIEW V_THONGKEDHN
GO

CREATE VIEW V_THONGKEDHN
AS 
	SELECT TENDONGHO,
	COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
	COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
	COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
	COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
	COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
	COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
	COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
	COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
	FROM dbo.TB_DULIEUKHACHHANG kh,TB_HIEUDONGHO hdh
	WHERE LEFT(kh.HIEUDH,3)=hdh.HIEUDH AND kh.HIEUDH IS NOT NULL AND kh.HIEUDH !=''
	GROUP BY TENDONGHO
GO


DROP VIEW V_THONGKEDHN_TB01
GO

CREATE VIEW V_THONGKEDHN_TB01
AS 
	SELECT TENDONGHO,
	COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
	COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
	COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
	COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
	COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
	COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
	COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
	COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
	FROM dbo.TB_DULIEUKHACHHANG kh,TB_HIEUDONGHO hdh
	WHERE LEFT(kh.HIEUDH,3)=hdh.HIEUDH AND kh.HIEUDH IS NOT NULL AND kh.HIEUDH !='' AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
	GROUP BY TENDONGHO
GO

DROP VIEW THONGKEDHN_TB02
GO

CREATE VIEW THONGKEDHN_TB02
AS 
	SELECT TENDONGHO,
	COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
	COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
	COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
	COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
	COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
	COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
	COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
	COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
	FROM dbo.TB_DULIEUKHACHHANG kh,TB_HIEUDONGHO hdh
	WHERE LEFT(kh.HIEUDH,3)=hdh.HIEUDH AND kh.HIEUDH IS NOT NULL AND kh.HIEUDH !='' AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
	GROUP BY TENDONGHO
GO

DROP VIEW THONGKEDHN_TP
GO

CREATE VIEW THONGKEDHN_TP
AS 
	SELECT TENDONGHO,
	COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
	COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
	COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
	COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
	COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
	COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
	COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
	COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
	FROM dbo.TB_DULIEUKHACHHANG kh,TB_HIEUDONGHO hdh
	WHERE LEFT(kh.HIEUDH,3)=hdh.HIEUDH AND kh.HIEUDH IS NOT NULL AND kh.HIEUDH !='' AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
	GROUP BY TENDONGHO
GO

-------------------------------------------
DROP PROCEDURE THONGKEDHN
GO

CREATE PROCEDURE THONGKEDHN
	@KY INT,
	@NAM INT
AS
	UPDATE TB_THONGKEDHN SET 
		CO15 = t2.CO15,
		CO20 = t2.CO20,
		CO25 = t2.CO25,
		CO40 = t2.CO40,
		CO50 = t2.CO50,
		CO80 = t2.CO80,
		CO100 = t2.CO100,
		CO150 = t2.CO150,
		CO200 = t2.CO200,
		NHOCO15 = t2.NHOCO15,
		NHOCO20 = t2.NHOCO20,
		NHOCO25 = t2.NHOCO25,
		NHOCO40 = t2.NHOCO40,
		NHOCO50 = t2.NHOCO50,
		NHOCO80 = t2.NHOCO80,
		NHOCO100 = t2.NHOCO100,
		NHOCO150 = t2.NHOCO150,
		NHOCO200 = t2.NHOCO200,
		LONCO15 = t2.LONCO15,
		LONCO20 = t2.LONCO20,
		LONCO25 = t2.LONCO25,
		LONCO40 = t2.LONCO40,
		LONCO50 = t2.LONCO50,
		LONCO80 = t2.LONCO80,
		LONCO100 = t2.LONCO100,
		LONCO150 = t2.LONCO150,
		LONCO200 = t2.LONCO200
	FROM (
			SELECT LEFT(kh.HIEUDH,3) AS HIEUDH,
				COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
				COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
				COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
				COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
				COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
				COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
				COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
				COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
			FROM dbo.TB_DULIEUKHACHHANG kh
			WHERE kh.NAM<=@NAM AND kh.KY<=@KY
			GROUP BY  LEFT(kh.HIEUDH,3)
	) as t2
	WHERE TB_THONGKEDHN.MADHN=t2.HIEUDH 	
GO




DROP PROCEDURE THONGKEDHN_TP
GO

CREATE PROCEDURE THONGKEDHN_TP
	@KY INT,
	@NAM INT
AS
	UPDATE TB_THONGKEDHN SET 
		CO15 = t2.CO15,
		CO20 = t2.CO20,
		CO25 = t2.CO25,
		CO40 = t2.CO40,
		CO50 = t2.CO50,
		CO80 = t2.CO80,
		CO100 = t2.CO100,
		CO150 = t2.CO150,
		CO200 = t2.CO200,
		NHOCO15 = t2.NHOCO15,
		NHOCO20 = t2.NHOCO20,
		NHOCO25 = t2.NHOCO25,
		NHOCO40 = t2.NHOCO40,
		NHOCO50 = t2.NHOCO50,
		NHOCO80 = t2.NHOCO80,
		NHOCO100 = t2.NHOCO100,
		NHOCO150 = t2.NHOCO150,
		NHOCO200 = t2.NHOCO200,
		LONCO15 = t2.LONCO15,
		LONCO20 = t2.LONCO20,
		LONCO25 = t2.LONCO25,
		LONCO40 = t2.LONCO40,
		LONCO50 = t2.LONCO50,
		LONCO80 = t2.LONCO80,
		LONCO100 = t2.LONCO100,
		LONCO150 = t2.LONCO150,
		LONCO200 = t2.LONCO200
	FROM (
			SELECT LEFT(kh.HIEUDH,3) AS HIEUDH,
				COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
				COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
				COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
				COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
				COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
				COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
				COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
				COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
			FROM dbo.TB_DULIEUKHACHHANG kh
			WHERE kh.NAM<=@NAM AND kh.KY<=@KY  AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
			GROUP BY  LEFT(kh.HIEUDH,3)
	) as t2
	WHERE TB_THONGKEDHN.MADHN=t2.HIEUDH 	
GO

DROP PROCEDURE THONGKEDHN_TB02
GO

CREATE PROCEDURE THONGKEDHN_TB02
	@KY INT,
	@NAM INT
AS
	UPDATE TB_THONGKEDHN SET 
		CO15 = t2.CO15,
		CO20 = t2.CO20,
		CO25 = t2.CO25,
		CO40 = t2.CO40,
		CO50 = t2.CO50,
		CO80 = t2.CO80,
		CO100 = t2.CO100,
		CO150 = t2.CO150,
		CO200 = t2.CO200,
		NHOCO15 = t2.NHOCO15,
		NHOCO20 = t2.NHOCO20,
		NHOCO25 = t2.NHOCO25,
		NHOCO40 = t2.NHOCO40,
		NHOCO50 = t2.NHOCO50,
		NHOCO80 = t2.NHOCO80,
		NHOCO100 = t2.NHOCO100,
		NHOCO150 = t2.NHOCO150,
		NHOCO200 = t2.NHOCO200,
		LONCO15 = t2.LONCO15,
		LONCO20 = t2.LONCO20,
		LONCO25 = t2.LONCO25,
		LONCO40 = t2.LONCO40,
		LONCO50 = t2.LONCO50,
		LONCO80 = t2.LONCO80,
		LONCO100 = t2.LONCO100,
		LONCO150 = t2.LONCO150,
		LONCO200 = t2.LONCO200
	FROM (
			SELECT LEFT(kh.HIEUDH,3) AS HIEUDH,
				COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
				COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
				COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
				COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
				COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
				COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
				COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
				COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
			FROM dbo.TB_DULIEUKHACHHANG kh
			WHERE kh.NAM<=@NAM AND kh.KY<=@KY AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')
			GROUP BY  LEFT(kh.HIEUDH,3)
	) as t2
	WHERE TB_THONGKEDHN.MADHN=t2.HIEUDH 	
GO

DROP PROCEDURE THONGKEDHN_TB01
GO

CREATE PROCEDURE THONGKEDHN_TB01
	@KY INT,
	@NAM INT
AS
	UPDATE TB_THONGKEDHN SET 
		CO15 = t2.CO15,
		CO20 = t2.CO20,
		CO25 = t2.CO25,
		CO40 = t2.CO40,
		CO50 = t2.CO50,
		CO80 = t2.CO80,
		CO100 = t2.CO100,
		CO150 = t2.CO150,
		CO200 = t2.CO200,
		NHOCO15 = t2.NHOCO15,
		NHOCO20 = t2.NHOCO20,
		NHOCO25 = t2.NHOCO25,
		NHOCO40 = t2.NHOCO40,
		NHOCO50 = t2.NHOCO50,
		NHOCO80 = t2.NHOCO80,
		NHOCO100 = t2.NHOCO100,
		NHOCO150 = t2.NHOCO150,
		NHOCO200 = t2.NHOCO200,
		LONCO15 = t2.LONCO15,
		LONCO20 = t2.LONCO20,
		LONCO25 = t2.LONCO25,
		LONCO40 = t2.LONCO40,
		LONCO50 = t2.LONCO50,
		LONCO80 = t2.LONCO80,
		LONCO100 = t2.LONCO100,
		LONCO150 = t2.LONCO150,
		LONCO200 = t2.LONCO200
	FROM (
			SELECT LEFT(kh.HIEUDH,3) AS HIEUDH,
				COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,
				COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,
				COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,
				COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,
				COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80,
				COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,
				COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,
				COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5)  THEN 1 ELSE NULL END) AS NHOCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) <= 5) THEN 1 ELSE NULL END) AS NHOCO200,
				COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO15,
				COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO20,
				COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO25,
				COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO40,
				COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO50,
				COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5)  THEN 1 ELSE NULL END) AS LONCO80,
				COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO100,
				COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO150,
				COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >5) THEN 1 ELSE NULL END) AS LONCO200
			FROM dbo.TB_DULIEUKHACHHANG kh
			WHERE kh.NAM<=@NAM AND kh.KY<=@KY AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
			GROUP BY  LEFT(kh.HIEUDH,3)
	) as t2
	WHERE TB_THONGKEDHN.MADHN=t2.HIEUDH 	
GO




























create view W_BIENDOCCSTO 
AS
	SELECT TODS AS MATO, SUM(SOLUONGDHN) AS SOLUONGDHN,SUM(SANLUONG)  AS SANLUONG, SUM(KHONGGHI) AS KHONGGHI,SUM(NHAXD) AS NHAXD,SUM(TANG) AS TANG,SUM(GIAM) AS GIAM
	FROM dbo.TB_NHANVIENDOCSO
	GROUP BY TODS
