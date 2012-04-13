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
INSERT INTO TB_HIEUDONGHO VALUES('ITR',N'ITRON MUILTI')
INSERT INTO TB_HIEUDONGHO VALUES('KEN',N'KENT')
INSERT INTO TB_HIEUDONGHO VALUES('LUG',N'LUG MỚI')
INSERT INTO TB_HIEUDONGHO VALUES('MUL',N'MULTI')
INSERT INTO TB_HIEUDONGHO VALUES('PRE',N'PRECIFLO')
INSERT INTO TB_HIEUDONGHO VALUES('SEN',N'SENSUS')
INSERT INTO TB_HIEUDONGHO VALUES('TAC',N'TAC')
INSERT INTO TB_HIEUDONGHO VALUES('WOL',N'WOLTEX')

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


CREATE TABLE W_BAOCAO_LOAIKD_THAP(
	TODS INT PRIMARY KEY NOT NULL,
	TENTO NVARCHAR(MAX),
	KN_SH0 FLOAT,KN_SH4 FLOAT,
    KN_SX0 FLOAT,KN_SX4 FLOAT,
    KN_KD0 FLOAT,KN_KD4 FLOAT,
    KN_CC0 FLOAT,KN_CC4 FLOAT,
    KN_HCSN0 FLOAT,KN_HCSN4 FLOAT,
	KT_SH0 FLOAT,KT_SH4 FLOAT,
    KT_SX0 FLOAT,KT_SX4 FLOAT,
    KT_KD0 FLOAT,KT_KD4 FLOAT,
    KT_CC0 FLOAT, KT_CC4 FLOAT,
    KT_HCSN0 FLOAT,KT_HCSN4 FLOAT
)
GO

INSERT INTO W_BAOCAO_LOAIKD_THAP VALUES('1',N'TÂN BÌNH 01',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_LOAIKD_THAP VALUES('2',N'TÂN BÌNH 02',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
INSERT INTO W_BAOCAO_LOAIKD_THAP VALUES('3',N'TÂN PHÚ',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)