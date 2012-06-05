USE MASTER
GO
/*
IF EXISTS( SELECT * FROM  sys.databases WHERE NAME = 'CAPNUOCTANHOA')
   DROP DATABASE CAPNUOCTANHOA
USE MASTER
GO
CREATE DATABASE CAPNUOCTANHOA
GO	
*/
USE CAPNUOCTANHOA
GO


CREATE TABLE SYS_ROLES(
	ROLEID VARCHAR(5)  PRIMARY KEY NOT NULL,
	ROLENAME NVARCHAR(50)	
)
GO

INSERT INTO SYS_ROLES VALUES('AD','Administrators')
INSERT INTO SYS_ROLES VALUES('US','Users')
INSERT INTO SYS_ROLES VALUES('QT',N'Quản Trị')

CREATE TABLE SYS_PHONGBANDOI
(
	MAPHONG VARCHAR(20) PRIMARY KEY NOT NULL,
	TENPHONG NVARCHAR(250) NOT NULL,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME)
GO

INSERT INTO SYS_PHONGBANDOI VALUES('QLDHN',N'Đội Quản Lý Đồng Hồ Nước',null, null,null, null)
INSERT INTO SYS_PHONGBANDOI VALUES('DTCTB',N'Đội Thi Công Tu Bổ',null, null,null, null)
INSERT INTO SYS_PHONGBANDOI VALUES('TOCNTT',N'Tổ CNTT',null, null,null, null)

CREATE TABLE SYS_USERS
(
	USERNAME	VARCHAR(20) PRIMARY KEY NOT NULL,
	[PASSWORD]	VARCHAR(50),
	FULLNAME	NVARCHAR(50),
	ROLEID		VARCHAR(5),
	[ENABLED]	BIT,
	CAP			INT,
	MAPHONG		VARCHAR(20),
	TODS		VARCHAR(20),
	GIOIHAN		NVARCHAR(MAX),
	CONSTRAINT FR_USERS FOREIGN KEY (ROLEID) REFERENCES SYS_ROLES(ROLEID),
	CONSTRAINT FR_PHONG FOREIGN KEY (MAPHONG) REFERENCES SYS_PHONGBANDOI(MAPHONG),
	CREATEBY	VARCHAR(50),
	CREATEDATE	DATETIME,
	MODIFYBY	VARCHAR(50),
	MODIFYDATE	DATETIME,
	DUYET		BIT,
)
GO

INSERT INTO SYS_USERS VALUES('admin','y47NNdw/OT0=',N'Lê Tấn Đạt','AD','True',0,'TOCNTT','CNTT',null, null,null,null,0)
INSERT INTO SYS_USERS VALUES('tai','y47NNdw/OT0=',N'Nguyễn Văn Tài','US','True',0,'QLDHN','TB01', null, null,null,null,0)
INSERT INTO SYS_USERS VALUES('thu','y47NNdw/OT0=',N'Đổ Minh Thu','US','True',0,'QLDHN','TB02', null, null,null,null,0)
INSERT INTO SYS_USERS VALUES('sang','y47NNdw/OT0=',N'Nguyễn Minh Sang','US','True',0,'QLDHN','TP',null, null,null,null,0)
INSERT INTO SYS_USERS VALUES('an','y47NNdw/OT0=',N'Ngô Gia An','US','True',0,'DTCTB','Thay DHN', null, null,null,null,0)

CREATE TABLE TB_DULIEUKHACHHANG
(
	ID			INT IDENTITY(1,1),
	KHU			VARCHAR(255),
	DOT			VARCHAR(255),
	CUON_GCS	NVARCHAR(MAX),
	CUON_STT	NVARCHAR(MAX),
	DANHBO		VARCHAR(255) PRIMARY KEY NOT NULL,
	NGAYGANDH	NVARCHAR(255),
	HOPDONG		VARCHAR(255),
	HOTEN		NVARCHAR(MAX),
	SONHA		NVARCHAR(MAX),
	TENDUONG	NVARCHAR(MAX),
	PHUONG		NVARCHAR(255),
	QUAN		NVARCHAR(255),
	CHUKY		NVARCHAR(255),
	CODE		NVARCHAR(255),
	CODEFU		NVARCHAR(255),
	GIABIEU		NVARCHAR(255),
	DINHMUC		NVARCHAR(255),
	SH			NVARCHAR(255),
	HCSN		NVARCHAR(255),
	SX			NVARCHAR(255),
	DV			NVARCHAR(255),
	CODH		NVARCHAR(255),
	HIEUDH		NVARCHAR(255),
	CAP			NVARCHAR(255),
	SOTHANDH	NVARCHAR(255),
	CHITHAN		NVARCHAR(255),
	CHIGOC		NVARCHAR(255),
	VITRIDHN	NVARCHAR(255),
	NGAYTHAY	DATETIME,
	SODHN		NVARCHAR(255),
	MSTHUE		NVARCHAR(255),
	SOHO		NVARCHAR(255),
	CHISOKYTRUOC NVARCHAR(255),
	BAOTHAY		BIT,
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO

CREATE TABLE TB_LOAIBANGKE
(
	LOAIBK VARCHAR(20) PRIMARY KEY NOT NULL,
	TENBANGKE	NVARCHAR(MAX)
)
GO

INSERT INTO TB_LOAIBANGKE VALUES('DK',N'ĐỊNH KỲ')
INSERT INTO TB_LOAIBANGKE VALUES('NG',N'NGƯNG')
INSERT INTO TB_LOAIBANGKE VALUES('KM',N'KÍNH MỜ')
INSERT INTO TB_LOAIBANGKE VALUES('BB',N'THEO BIÊN BẢN KIỂM TRA')
INSERT INTO TB_LOAIBANGKE VALUES('TT',N'THEO TỜ TRÌNH')
INSERT INTO TB_LOAIBANGKE VALUES('BT',N'BỒI THƯỜNG')
INSERT INTO TB_LOAIBANGKE VALUES('HC',N'HẠ CỞ')
INSERT INTO TB_LOAIBANGKE VALUES('TH',N'THAY THỬ')

CREATE TABLE TB_HIEUDONGHO
(
	HIEUDH VARCHAR(20) PRIMARY KEY NOT NULL,
	TENDONGHO	NVARCHAR(MAX)
)
GO

INSERT INTO TB_HIEUDONGHO VALUES('ACT',N'ACTARIS')
INSERT INTO TB_HIEUDONGHO VALUES('AIC',N'AICHI')
INSERT INTO TB_HIEUDONGHO VALUES('ASA',N'ASAHI')
INSERT INTO TB_HIEUDONGHO VALUES('BAY',N'BAYLAN')
INSERT INTO TB_HIEUDONGHO VALUES('FLO',N'FLOSTAR')
INSERT INTO TB_HIEUDONGHO VALUES('INV',N'INVENSYS')
INSERT INTO TB_HIEUDONGHO VALUES('ITR',N'ITRON')
INSERT INTO TB_HIEUDONGHO VALUES('KEN',N'KENT')
INSERT INTO TB_HIEUDONGHO VALUES('LUG',N'LUGIACO')
INSERT INTO TB_HIEUDONGHO VALUES('MUL',N'MULTI')
INSERT INTO TB_HIEUDONGHO VALUES('PRE',N'PRECIFLO')
INSERT INTO TB_HIEUDONGHO VALUES('SEN',N'SENSUS')
INSERT INTO TB_HIEUDONGHO VALUES('TAC',N'TAC')
INSERT INTO TB_HIEUDONGHO VALUES('WOL',N'WOLTEX')
INSERT INTO TB_HIEUDONGHO VALUES('MEI',N'MEINECKER')
INSERT INTO TB_HIEUDONGHO VALUES('HYD',N'HYDROMETER')
INSERT INTO TB_HIEUDONGHO VALUES('ZEN',N'ZENNER')
INSERT INTO TB_HIEUDONGHO VALUES('BAD',N'BADGER')
INSERT INTO TB_HIEUDONGHO VALUES('ROC',N'ROCKWELL')
INSERT INTO TB_HIEUDONGHO VALUES('HER',N'HERSEY')

CREATE TABLE TB_THAYDHN
(
	ID_BAOTHAY		INT IDENTITY(1,1)  PRIMARY KEY,
	DHN_LANTHAY		INT,
	DHN_LOAIBANGKE	NVARCHAR(20),
	DHN_SOBANGKE	INT,
	DHN_STT			INT,
	DHN_DANHBO		NVARCHAR(50),
	DHN_NGAYBAOTHAY DATETIME,
	DHN_DOT			VARCHAR(20),
	DHN_TODS		NVARCHAR(20),
	DHN_NGAYGAN		DATETIME,
	DHN_CHITHAN		NVARCHAR(20),
	DHN_CHIGOC		NVARCHAR(20),
	DHN_HIEUDHN		NVARCHAR(20),
	DHN_CODH		NVARCHAR(20),
	DHN_SOTHAN		NVARCHAR(20),
	DHN_CAP			NVARCHAR(20),
	DHN_CHISO		INT,
	DHN_LYDOTHAY	NVARCHAR(20),	
	DHN_GHICHU		NVARCHAR(20),
	DHN_BANGKECHUYEN NVARCHAR(MAX),
	DHN_NGAYCHUYEN	DATETIME,	
	DHN_CREATEDATE	DATETIME,
	DHN_CREATEBY	NVARCHAR(100),
	DHN_MODIFYDATE	DATETIME,
	DHN_MODIFYBY	NVARCHAR(100),
	HCT_CHISOGO		INT,
	HCT_SOTHANGO	NVARCHAR(20),
	HCT_HIEUDHNGAN	NVARCHAR(20),
	HCT_CODHNGAN	NVARCHAR(20),
	HCT_SOTHANGAN	NVARCHAR(20),
	HCT_CAP			NVARCHAR(20),
	HCT_CHISOGAN	INT, 
	HCT_LOAIDHGAN	BIT,/* 1: MOI 2: TAN TRANG*/
	HCT_NGAYGAN		DATETIME,
	HCT_CHITHAN		NVARCHAR(20),
	HCT_CHIGOC		NVARCHAR(20),
	HCT_TRONGAI		BIT,
	HCT_LYDOTRONGAI	NVARCHAR(20),
	HCT_CREATEDATE	DATETIME,
	HCT_CREATEBY	NVARCHAR(100),
	HCT_MODIFYDATE	DATETIME,
	HCT_MODIFYBY	NVARCHAR(100)
	XLT_XULY		BIT,
	XLT_CHUYENXL	NVARCHAR(200),	
	XLT_NGAYCHUYEN	DATETIME,
	XLT_TRAKQ		BIT,
	XLT_KETQUA		NVARCHAR(MAX),	
	XLT_NGAYCAPNHAT	DATETIME,
	XLT_CREATEDATE	DATETIME,
	XLT_CREATEBY	NVARCHAR(100)
)
GO

CREATE TABLE TB_DHN_BAOCAO
(
	ID_BC		INT IDENTITY(1,1)  PRIMARY KEY,
	CVPGKD		NVARCHAR(MAX),
	TENPGKD		NVARCHAR(MAX),
	CVDQLDH		NVARCHAR(MAX),
	TENQLDHN	NVARCHAR(MAX),
	CVPGDKT		NVARCHAR(MAX),
	TENPGDKT	NVARCHAR(MAX),
	CVKIEMTRA	NVARCHAR(MAX),
	TENKIEMTRA	NVARCHAR(MAX),
	CVTHICONG	NVARCHAR(MAX),
	TENTHICONG	NVARCHAR(MAX),
)
GO

INSERT INTO TB_DHN_BAOCAO(CVPGKD,TENPGKD,CVDQLDH,TENQLDHN,CVPGDKT,TENPGDKT,CVKIEMTRA,TENKIEMTRA,CVTHICONG,TENTHICONG)
VALUES( N'PHÓ GIÁM ĐỐC KINH DOANH',N'LÊ VĂN SƠN',
	    N'ĐỘI QUẢN LÝ ĐHN',N'TRẦN CÔNG LỄ',
		N'PHÓ GIÁM ĐỐC KỸ THUẬT',N'PHẠM MẠNH HIỂN',
		N'BAN KIỂM TRA KIỂM SOÁT',N'HUỲNH CÔNG KHANH',
		N'ĐỘI THI CÔNG TU BỔ',N'TRƯƠNG TẤN QUỐC'
)


CREATE TABLE TB_VATUTHAY(
	STT			INT PRIMARY KEY NOT NULL,
	MAVT		NVARCHAR(100),
	TENVT		NVARCHAR(MAX),
	DVT			NVARCHAR(MAX),
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)	
)
GO

INSERT INTO TB_VATUTHAY VALUES('1','OT2520',N'ỐNG TÚM Ø25 x 20',N'Cái',NULL,NULL,NULL,NULL)
INSERT INTO TB_VATUTHAY VALUES('2','OT2015',N'ỐNG TÚM Ø20x15 (¾ × ½)',N'Cái',NULL,NULL,NULL,NULL)
INSERT INTO TB_VATUTHAY VALUES('3','JKG20',N'JOINT KHÓA GÓC 20',N'Cái',NULL,NULL,NULL,NULL)
INSERT INTO TB_VATUTHAY VALUES('4','JTLK15',N'JOINT TLK 15 Ly',N'Cái',NULL,NULL,NULL,NULL)
INSERT INTO TB_VATUTHAY VALUES('5','JBR15',N'JOINT BRIDE 15',N'Cái',NULL,NULL,NULL,NULL)
INSERT INTO TB_VATUTHAY VALUES('6','KNTLK15',N'KHÂU NỐI TLK 15 LY',N'Cái',NULL,NULL,NULL,NULL)
INSERT INTO TB_VATUTHAY VALUES('7','BRT15',N'BRIDE TLK 15',N'Cái',NULL,NULL,NULL,NULL)
INSERT INTO TB_VATUTHAY VALUES('8','1050',N'BULON + TÁN 10 x 50',N'Cái',NULL,NULL,NULL,NULL)

CREATE TABLE TB_VATUTHAY_DHN(
	ID_BC		INT IDENTITY(1,1)  PRIMARY KEY,
	ID_BAOTHAY  INT,
	DOTTHAY		NVARCHAR(100),
	STT			INT,
	MAVT		NVARCHAR(100),
	TENVT		NVARCHAR(MAX),
	DVT			NVARCHAR(MAX),
	SOLUONG		INT,
	GHICHU		NVARCHAR(MAX),
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100),
	CONSTRAINT FR_VATUTHAY_DHN FOREIGN KEY (ID_BAOTHAY) REFERENCES TB_THAYDHN(ID_BAOTHAY)
)
GO

CREATE TABLE W_BAOCAO_SANLUONG(
	TODS INT PRIMARY KEY NOT NULL,
	TENTO NVARCHAR(MAX),
	KN_DHN FLOAT,
    KN_SANLUONG FLOAT,
    KT_DHN FLOAT,
    KT_SANLUONG FLOAT,
    TANGIAM_DHN FLOAT,
	TANGIAM_SANLUONG FLOAT,
    NT_DHN FLOAT,
    NT_SANLUONG FLOAT,
    NT_TANGIAM_DHN FLOAT,
	NT_TANGIAM_SANLUONG FLOAT
)
GO

INSERT INTO W_BAOCAO_SANLUONG VALUES('1',N'TÂN BÌNH 01',0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_SANLUONG VALUES('2',N'TÂN BÌNH 02',0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_SANLUONG VALUES('3',N'TÂN PHÚ',0,0,0,0,0,0,0,0,0,0)

CREATE TABLE W_BAOCAO_SANLUONG_MAY(
	TODS INT ,
	MAYDS INT,
	KN_DHN FLOAT,
    KN_SANLUONG FLOAT,
    KT_DHN FLOAT,
    KT_SANLUONG FLOAT,
    TANGIAM_DHN FLOAT,
	TANGIAM_SANLUONG FLOAT,
    NT_DHN FLOAT,
    NT_SANLUONG FLOAT,
    NT_TANGIAM_DHN FLOAT,
	NT_TANGIAM_SANLUONG FLOAT
)
GO

CREATE TABLE W_BAOCAO_LOAIKD(
	TODS INT PRIMARY KEY NOT NULL,
	TENTO NVARCHAR(MAX),
	KN_SH_DH FLOAT,KN_SH_SL FLOAT,
    KN_SX_DH FLOAT,KN_SX_SL FLOAT,
    KN_KD_DH FLOAT,KN_KD_SL FLOAT,
    KN_CC_DH FLOAT,KN_CC_SL FLOAT,
    KN_HCSN_DH FLOAT,KN_HCSN_SL FLOAT,
	KT_SH_DH FLOAT,KT_SH_SL FLOAT,
    KT_SX_DH FLOAT,KT_SX_SL FLOAT,
    KT_KD_DH FLOAT,KT_KD_SL FLOAT,
    KT_CC_DH FLOAT, KT_CC_SL FLOAT,
    KT_HCSN_DH FLOAT,KT_HCSN_SL FLOAT
)
GO

INSERT INTO W_BAOCAO_LOAIKD VALUES('1',N'TÂN BÌNH 01',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_LOAIKD VALUES('2',N'TÂN BÌNH 02',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_LOAIKD VALUES('3',N'TÂN PHÚ',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)



CREATE TABLE W_BAOCAO_LOAIKD_MAY(
	TODS INT ,
	MAYDS INT,
	KN_SH_DH FLOAT,KN_SH_SL FLOAT,
    KN_SX_DH FLOAT,KN_SX_SL FLOAT,
    KN_KD_DH FLOAT,KN_KD_SL FLOAT,
    KN_CC_DH FLOAT,KN_CC_SL FLOAT,
    KN_HCSN_DH FLOAT,KN_HCSN_SL FLOAT,
	KT_SH_DH FLOAT,KT_SH_SL FLOAT,
    KT_SX_DH FLOAT,KT_SX_SL FLOAT,
    KT_KD_DH FLOAT,KT_KD_SL FLOAT,
    KT_CC_DH FLOAT, KT_CC_SL FLOAT,
    KT_HCSN_DH FLOAT,KT_HCSN_SL FLOAT
)
GO
	
	
CREATE TABLE W_BAOCAO_LOAIKD_THAP(
	TODS INT PRIMARY KEY NOT NULL,
	TENTO NVARCHAR(MAX),
	KN_SH0 INT,KN_SH4 INT,
    KN_SX0 INT,KN_SX4 INT,
    KN_KD0 INT,KN_KD4 INT,
    KN_CC0 INT,KN_CC4 INT,
    KN_HCSN0 INT,KN_HCSN4 INT,
	KT_SH0 INT,KT_SH4 INT,
    KT_SX0 INT,KT_SX4 INT,
    KT_KD0 INT,KT_KD4 INT,
    KT_CC0 INT, KT_CC4 INT,
    KT_HCSN0 INT,KT_HCSN4 INT
)
GO

INSERT INTO W_BAOCAO_LOAIKD_THAP VALUES('1',N'TÂN BÌNH 01',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_LOAIKD_THAP VALUES('2',N'TÂN BÌNH 02',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_LOAIKD_THAP VALUES('3',N'TÂN PHÚ',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)

CREATE TABLE W_BAOCAO_CODE(
	TODS INT PRIMARY KEY NOT NULL,
	TENTO NVARCHAR(MAX),
	KN_CODE4 INT,
	KN_CODE5 INT,
    KN_CODE6 INT,
	KN_CODE8 INT,
    KN_CODEM INT,
	KN_CODEN INT,
    KN_CODEQ INT,
	KN_CODEF INT,
    KN_CODEK INT,
	KT_CODE4 INT,
	KT_CODE5 INT,
	KT_CODE6 INT,
    KT_CODE8 INT,
	KT_CODEM INT,
    KT_CODEN INT,
	KT_CODEQ INT,
    KT_CODEF INT,
	KT_CODEK INT
)
GO

INSERT INTO W_BAOCAO_CODE VALUES('1',N'TÂN BÌNH 01',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_CODE VALUES('2',N'TÂN BÌNH 02',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_CODE VALUES('3',N'TÂN PHÚ',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)

CREATE TABLE W_BAOCAO_CODE_MAY(
	TODS INT ,
	MAYDS INT,
	KN_CODE4 INT,
	KN_CODE5 INT,
    KN_CODE6 INT,
	KN_CODE8 INT,
    KN_CODEM INT,
	KN_CODEN INT,
    KN_CODEQ INT,
	KN_CODEF INT,
    KN_CODEK INT,
	KT_CODE4 INT,
	KT_CODE5 INT,
	KT_CODE6 INT,
    KT_CODE8 INT,
	KT_CODEM INT,
    KT_CODEN INT,
	KT_CODEQ INT,
    KT_CODEF INT,
	KT_CODEK INT
)
GO

CREATE TABLE QUAN
(
	MAQUAN INT PRIMARY KEY NOT NULL,
	TENQUAN NVARCHAR(50)
)
GO

INSERT INTO QUAN(MAQUAN, TENQUAN) VALUES(22, N' PHU NHUAN')
INSERT INTO QUAN(MAQUAN, TENQUAN) VALUES(23, N' TAN BINH')
INSERT INTO QUAN(MAQUAN, TENQUAN) VALUES(31, N' TAN PHU')

CREATE TABLE PHUONG
(
	MAQUAN INT NOT NULL,
	MAPHUONG VARCHAR(10) NOT NULL,
	TENPHUONG NVARCHAR(50),
	CONSTRAINT PR_PHUONG PRIMARY KEY(MAQUAN, MAPHUONG),
	CONSTRAINT FR_PHUONG FOREIGN KEY (MAQUAN) REFERENCES QUAN(MAQUAN)
)
GO

INSERT INTO PHUONG VALUES(22,'10',N' 10')
INSERT INTO PHUONG VALUES(22,'14',N' 14')
INSERT INTO PHUONG VALUES(23,'01',N' 1')
INSERT INTO PHUONG VALUES(23,'02',N' 2')
INSERT INTO PHUONG VALUES(23,'03',N' 3')
INSERT INTO PHUONG VALUES(23,'04',N' 4')
INSERT INTO PHUONG VALUES(23,'05',N' 5')
INSERT INTO PHUONG VALUES(23,'06',N' 6')
INSERT INTO PHUONG VALUES(23,'07',N' 7')
INSERT INTO PHUONG VALUES(23,'08',N' 8')
INSERT INTO PHUONG VALUES(23,'09',N' 9')
INSERT INTO PHUONG VALUES(23,'10',N' 10')
INSERT INTO PHUONG VALUES(23,'11',N' 11')
INSERT INTO PHUONG VALUES(23,'12',N' 12')
INSERT INTO PHUONG VALUES(23,'13',N' 13')
INSERT INTO PHUONG VALUES(23,'14',N' 14')
INSERT INTO PHUONG VALUES(23,'15',N' 15')
INSERT INTO PHUONG VALUES(31,'01',N' TAN SON NHI')
INSERT INTO PHUONG VALUES(31,'02',N' TAN QUY')
INSERT INTO PHUONG VALUES(31,'03',N' SON KY')
INSERT INTO PHUONG VALUES(31,'04',N' TAN THANH')
INSERT INTO PHUONG VALUES(31,'05',N' PHU THOA HOA')
INSERT INTO PHUONG VALUES(31,'06',N' PHU THANH')
INSERT INTO PHUONG VALUES(31,'07',N' PHU TRUNG ')
INSERT INTO PHUONG VALUES(31,'08',N' HOA THANH')
INSERT INTO PHUONG VALUES(31,'09',N' TAN THOI HOA')
INSERT INTO PHUONG VALUES(31,'10',N' HIEP TAN')
INSERT INTO PHUONG VALUES(31,'11',N' TAY THANH')


CREATE TABLE TB_DULIEUKHACHHANG_HUYDB
(
	ID			INT IDENTITY(1,1)  PRIMARY KEY NOT NULL,
	KHU			VARCHAR(255),
	DOT			VARCHAR(255),
	CUON_GCS	NVARCHAR(MAX),
	CUON_STT	NVARCHAR(MAX),
	LOTRINH		VARCHAR(255),
	DANHBO		VARCHAR(255),
	NGAYGANDH	NVARCHAR(255),
	HOPDONG		VARCHAR(255),
	HOTEN		NVARCHAR(MAX),
	SONHA		NVARCHAR(MAX),
	TENDUONG	NVARCHAR(MAX),
	PHUONG		NVARCHAR(255),
	QUAN		NVARCHAR(255),
	CHUKY		NVARCHAR(255),
	CODE		NVARCHAR(255),
	CODEFU		NVARCHAR(255),
	GIABIEU		NVARCHAR(255),
	DINHMUC		NVARCHAR(255),
	SH			NVARCHAR(255),
	HCSN		NVARCHAR(255),
	SX			NVARCHAR(255),
	DV			NVARCHAR(255),
	CODH		NVARCHAR(255),
	HIEUDH		NVARCHAR(255),
	CAP			NVARCHAR(255),
	SOTHANDH	NVARCHAR(255),
	CHITHAN		NVARCHAR(255),
	CHIGOC		NVARCHAR(255),
	VITRIDHN	NVARCHAR(255),
	NGAYTHAY	DATETIME,
	NGAYKIEMDINH	DATETIME,
	SODHN		NVARCHAR(255),
	MSTHUE		NVARCHAR(255),
	SOHO		NVARCHAR(255),
	CHISOKYTRUOC NVARCHAR(255),
	SOPHIEU		NVARCHAR(255),
	NGAYHUY		DATETIME,
	HIEULUCHUY	NVARCHAR(255),
	NGUYENNHAN	NVARCHAR(MAX),
	GHICHU		NVARCHAR(MAX),
	TAILAPDB	BIT DEFAULT 0,
	NGAYTAILAP	DATETIME,
	TL_SOPHIEU	NVARCHAR(255),
	TL_HIEULUC	NVARCHAR(255),
	TL_DOT		NVARCHAR(255),
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO

CREATE TABLE TB_GANMOI(
	ID		INT IDENTITY(1,1),
	SHS		NVARCHAR(50),
	DANHBO	NVARCHAR(50) PRIMARY KEY NOT NULL,
	HOPDONG	NVARCHAR(50),
	HOTEN	NVARCHAR(MAX),
	SONHA	NVARCHAR(MAX),
	DUONG	NVARCHAR(MAX),
	MAPHUONG	NVARCHAR(20),
	MAQUAN	NVARCHAR(20),
	PLT		NVARCHAR(50),
	GIABIEU	NVARCHAR(50),
	DINHMUC	NVARCHAR(10),
	HIEULUC	NVARCHAR(10),
	NGAYGANTLK	DATETIME,
	HIEU	NVARCHAR(100),	
	COTLK	NVARCHAR(100),	
	SOTLK	NVARCHAR(100),	
	CHISOTLK	NVARCHAR(100),	
	SOHO	NVARCHAR(100),	
	TODS	NVARCHAR(100),
	DOT		NVARCHAR(100),
	MAYDS	NVARCHAR(100),
	CHUYEN	BIT,
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO

CREATE TABLE TB_DIEUCHINHDANHBO
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	LOAI	NVARCHAR(255),
	SOPHIEU	NVARCHAR(255),
	HIEULUC	NVARCHAR(255),
	DOT		NVARCHAR(255),
	DANHBO	NVARCHAR(255),
	CU_HOPDONG	NVARCHAR(255),
	CU_COTLK	NVARCHAR(255),
	CU_GIABIEU	NVARCHAR(255),
	CU_DINHMUC	NVARCHAR(255),
	CU_HOTEN	NVARCHAR(MAX),
	CU_DIACHI	NVARCHAR(MAX),
	MOI_HOPDONG	NVARCHAR(255),
	MOI_COTLK	NVARCHAR(255),
	MOI_GIABIEU	NVARCHAR(255),
	MOI_DINHMUC	NVARCHAR(255),
	MOI_HOTEN	NVARCHAR(MAX),
	MOI_DIACHI	NVARCHAR(MAX),
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO


CREATE TABLE TB_THONGKEDHN
(
	STT	INT,
	MADHN VARCHAR(50) PRIMARY KEY NOT NULL,
	TENDHN	NVARCHAR(255),
	HIEUCU	BIT,
	CO15 float, 
	CO20 float, 
	CO25 float, 
	CO40 float, 
	CO50 float, 
	CO80 float, 
	CO100 float, 
	CO150 float,
	CO200 float,
	NHOCO15 float, 
	NHOCO20 float, 
	NHOCO25 float, 
	NHOCO40 float, 
	NHOCO50 float, 
	NHOCO80 float, 
	NHOCO100 float, 
	NHOCO150 float, 
	NHOCO200 float, 
	LONCO15 float, 
	LONCO20 float, 
	LONCO25 float, 
	LONCO40 float, 
	LONCO50 float, 
	LONCO80 float, 
	LONCO100 float, 
	LONCO150 float, 
	LONCO200 float
)
GO

INSERT INTO TB_THONGKEDHN
VALUES(1,'ACT','Actaris',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(2,'ASA','Asahi',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(3,'TAC','Tac',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(4,'AIC','Aichi',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(5,'SEN','Sensus',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(6,'INV','Invensys',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(7,'MEI','Meinecker',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(8,'FLO','Flostar',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(9,'WOL','Woltex',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(10,'PRE','Preciflo',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(11,'MUL','Multi',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(12,'BAY','Baylan',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(13,'KEN','Kent',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(14,'ITR','Itron',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(15,'HYD','Hydrometer',0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(1,'ZEN','Zenner',1 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(2,'LUG',N'Lug Cũ',1 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(3,'BAD','Badger',1 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(4,'ROC','Rockwell',1 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

INSERT INTO TB_THONGKEDHN
VALUES(5,'HER','Hersey',1 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)


CREATE TABLE W_BAOCAO_CODE_DETAIL(
	TODS INT PRIMARY KEY NOT NULL,
	TENTO NVARCHAR(MAX),
	KN_60 INT,
	KN_61 INT,
    KN_62 INT,
	KN_63 INT,
    KN_64 INT,
	KN_65 INT,
    KN_66 INT,
	KN_54 INT,
    KN_58 INT,
    KN_F1 INT,
    KN_F2 INT,
    KN_F3 INT,
    KN_F5 INT,
	KT_60 INT,
	KT_61 INT,
    KT_62 INT,
	KT_63 INT,
    KT_64 INT,
	KT_65 INT,
    KT_66 INT,
	KT_54 INT,
    KT_58 INT,
    KT_F1 INT,
    KT_F2 INT,
    KT_F3 INT,
    KT_F5 INT
)

GO

INSERT INTO W_BAOCAO_CODE_DETAIL VALUES('1',N'TÂN BÌNH 01',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_CODE_DETAIL VALUES('2',N'TÂN BÌNH 02',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_CODE_DETAIL VALUES('3',N'TÂN PHÚ',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)

---------------

CREATE TABLE CHART_BIENDONGDHN
(
	NAM INT,
	THANG INT,
	GANMOI INT,
	HUY	INT,
	TAILAP INT,
	CONSTRAINT PR_CHART_BIENDONGDHN PRIMARY KEY(NAM, THANG)	
)
GO

CREATE TABLE CHART_SANLUONG
(
	NAM INT PRIMARY KEY NOT NULL,
	THANG01 INT,
	THANG02 INT,
	THANG03 INT,
	THANG04 INT,
	THANG05 INT,
	THANG06 INT,
	THANG07 INT,
	THANG08 INT,
	THANG09 INT,
	THANG10 INT,
	THANG11 INT,
	THANG12 INT,
)
GO

CREATE TABLE CHART_SANLUONG_TRUNGBINH
(
	NAM INT PRIMARY KEY NOT NULL,
	THANG01 INT,
	THANG02 INT,
	THANG03 INT,
	THANG04 INT,
	THANG05 INT,
	THANG06 INT,
	THANG07 INT,
	THANG08 INT,
	THANG09 INT,
	THANG10 INT,
	THANG11 INT,
	THANG12 INT,
	CHITIEU INT,
)
GO

CREATE TABLE CHART_DOANHTHU
(
	NAM INT PRIMARY KEY NOT NULL,
	THANG01 FLOAT,
	THANG02 FLOAT,
	THANG03 FLOAT,
	THANG04 FLOAT,
	THANG05 FLOAT,
	THANG06 FLOAT,
	THANG07 FLOAT,
	THANG08 FLOAT,
	THANG09 FLOAT,
	THANG10 FLOAT,
	THANG11 FLOAT,
	THANG12 FLOAT,
	CHITIEU FLOAT,
)
GO

CREATE TABLE TB_CHUYENKIEMTRA
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,	
	KY INT,
	DOT INT,
	NAM INT,
	MAYDS INT ,
	DANHBO VARCHAR(20),
    LOTRINH VARCHAR(20),
    HOTEN NVARCHAR(255),
	DIACHI NVARCHAR(255),
    CODEKYTRUOC VARCHAR(20),
    CSCU VARCHAR(20),
    NGAYCHUYEN DATETIME,
    GIOCHUYEN TIME,	
    TRAKETQUA BIT,
    KETQUA NVARCHAR(255),
	NGAYCOKQ DATETIME,
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO


CREATE TABLE TB_CHUYENDINHMUC
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,	
	KY INT,
	DOT INT,
	NAM INT,
	TODS VARCHAR(20),
	DANHBO VARCHAR(20),
    LOTRINH VARCHAR(20),
    HOTEN NVARCHAR(255),
	DIACHI NVARCHAR(255),
	HOPDONG NVARCHAR(255),
    GB NVARCHAR(255),
    DM NVARCHAR(255),
    TTBQ INT,
    CONGDUNG NVARCHAR(255),
    NGAYLAP DATETIME,
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO

 

CREATE TABLE TB_GANHOPBV
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,	
	TODS VARCHAR(20),
	DANHBO VARCHAR(20),
    LOTRINH VARCHAR(20),
    HOTEN NVARCHAR(255),
	DIACHI NVARCHAR(255),
	HOPDONG NVARCHAR(255),
    GB NVARCHAR(255),
    DM NVARCHAR(255),
    HIEU NVARCHAR(255),
    CO VARCHAR(20),
	GHICHU NVARCHAR(255),
    NGAYLAP DATETIME,
    GANHOP BIT,	
	NGAYGANHOP DATETIME,
    GH_GHICHU NVARCHAR(255),
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO

CREATE TABLE TB_DHNAMSAU
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,	
	TODS VARCHAR(20),
	DANHBO VARCHAR(20),
    LOTRINH VARCHAR(20),
    HOTEN NVARCHAR(255),
	DIACHI NVARCHAR(255),
	HOPDONG NVARCHAR(255),
    HIEU NVARCHAR(255),
    CO VARCHAR(20),
	GHICHU NVARCHAR(255),
    NGAYLAP DATETIME,
    NANG BIT,	
	NGAYNANG DATETIME,
    NANG_GHICHU NVARCHAR(255),
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100),
	MODIFYDATE	DATETIME,
	MODIFYBY	NVARCHAR(100)
)
GO

CREATE TABLE TB_MACHI(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,	
	MACHI NVARCHAR(20),
)
GO

CREATE TABLE TB_YEUCAUDC
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,	
	DANHBO		VARCHAR(20),
	LTCU		VARCHAR(20),
	LTMOI		VARCHAR(20),
	KY			INT,
	NAM			INT,
	DACHUYEN	BIT,
	NGAYCHUYEN	DATETIME,
	CREATEDATE	DATETIME,
	CREATEBY	NVARCHAR(100)
)
GO

--------------

CREATE TABLE TB_NHANVIENDOCSO
(
	MAYDS INT PRIMARY KEY NOT NULL,
	TODS INT,
	NAME	NVARCHAR(MAX),
	FULLNAME NVARCHAR(MAX),
	SOLUONGDHN INT,
	SANLUONG	INT,
	KHONGGHI	INT,
	NHAXD	INT,
	TANG	INT,
	GIAM	INT
)
GO

INSERT INTO TB_NHANVIENDOCSO VALUES('1','1',N'Hữu Liêm',N'Nguyễn Hữu Liêm',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('5','1',N'Đăng Khoa',N'Lê Đăng Khoa',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('7','1',N'Chiếm Vinh',N'Trần Chiếm Vinh',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('3','1',N'Vĩnh Khang',N'Nguyễn Vĩnh Khang',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('9','1',N'Hoàng Phương',N'Phạm Hoàng Phương',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('6','1',N'Thanh Nghị',N'Quách Thanh Nghị',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('4','1',N'Phi Long',N'Hoàng Phi Long',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('2','1',N'Bảo Quốc',N'Diệp Trần Bảo Quốc',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('8','1',N'Hoàng Tuân',N'Nguyễn Hoàng Tuân',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('28','2',N'Hữu Năng',N'Nguyễn Hữu Năng',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('16','2',N'Tấn Công',N'Huỳnh Tấn Công',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('17','2',N'Tuấn Sĩ',N'Nguyễn Tuấn Sĩ',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('18','2',N'Chí Thiện',N'Lâm Chí Thiện',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('19','2',N'Phi Long',N'Đặng Phi Long',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('20','2',N'Trọng Tuân',N'Nguyễn Trọng Tuân',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('21','2',N'Anh Dũng',N'Nguyễn Anh Dũng',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('22','2',N'Văn Lâm',N'Phạm Văn Lâm',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('23','2',N'Hoàng Sang',N'Nguyễn Hoàng Sang',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('24','2',N'Đức Thành',N'Nguyễn Đức Thành',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('25','2',N'Thanh Bình',N'Lê Thanh Bình',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('26','2',N'Hải Vương',N'Lê Hải Vương',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('27','2',N'Tiến Cường ',N'Hà Tiến Cường',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('41','3',N'Thành Hiếu',N'Nguyễn Thành Hiếu',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('32','3',N'Duy Quang',N'Nguyễn Duy Quang',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('31','3',N'Thanh Điền',N'Nguyễn Thanh Điền',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('44','3',N'Tuấn Tài',N'Huỳnh Tuấn Tài',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('38','3',N'Minh Tuấn',N'Nguyễn Minh Tuấn',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('34','2',N'Hoàng Phong',N'Võ Hoàng Phong',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('35','3',N'Hoàng Lộc',N'Trương Hoàng Lộc',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('42','3',N'Anh Tùng',N'Nguyễn Anh Tùng',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('43','3',N'Trung Hiền',N'Lê Trung Hiền',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('39','3',N'Minh Quân',N'Trần Minh Quân',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('36','3',N'Kim Văn',N'Dương Kim Văn',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('37','3',N'Văn Ấm',N'Nguyễn Văn Ấm',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('33','3',N'Minh Cường',N'Nguyễn Minh Cường',0,0,0,0,0,0)
INSERT INTO TB_NHANVIENDOCSO VALUES('40','3',N'Hồng Phương',N'Phạm Trần Hồng Phương',0,0,0,0,0,0)
