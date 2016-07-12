SELECT NVCapNhat FROM BaoThay  GROUP BY NVCapNhat

DELETE FROM BaoThay WHERE NVCapNhat IN ('ngochc ','phuonghc ','nhunghc ','khahc ') AND ViTriMoi <> '888'


INSERT INTO dbo.BaoThay( DanhBa, LoaiBT, NgayThay, HieuMoi, CoMoi, SoThanMoi, ViTriMoi, ChiThanMoi, ChiCoMoi, CSGo, CSGan, NgayCapNhat, NVCapNhat)
SELECT DHN_DANHBO as [DanhBa]
      ,1 as [LoaiBT]
      ,HCT_NGAYGAN as [NgayThay]
      ,HCT_HIEUDHNGAN as [HieuMoi]
      ,HCT_CODHNGAN as [CoMoi]
      ,HCT_SOTHANGAN AS [SoThanMoi]
      , '888' AS  [ViTriMoi]
      ,'CON'  as [ChiThanMoi]
      ,'CON'  as [ChiCoMoi]
      ,HCT_CHISOGO AS [CSGo]
      , HCT_CHISOGAN AS [CSGan]
      ,HCT_CREATEDATE AS [NgayCapNhat]
      , HCT_CREATEBY [NVCapNhat]
  FROM CAPNUOCTANHOA.dbo.TB_THAYDHN where DHN_LOAIBANGKE='MA'