UPDATE DK_GIAMHOADON SET KTKS_CAMKET='X', KTKS_NGAYTIEPXUC=th.ngaycamket
FROM T_NhapThuHoi th
WHERE DK_GIAMHOADON.DHN_DANHBO=th.db AND th.ngaycamket IS NOT NULL

UPDATE DK_GIAMHOADON SET KTKS_BAMHI = 'thuhoi', KTKS_NGAYTIEPXUC=th.ngaythuhoi,
 KTKS_TH_MAKIEM = th.makem,
 KTKS_TH_HIEU =th.hieu,
 KTKS_TH_CO = th.co, 
 KTKS_TH_SOTHAN =th.sothanDHN2,
 KTKS_TH_CHISO = th.cs,
 KTKS_TH_NGAY = th.ngaythuhoi                            
FROM T_NhapThuHoi th
WHERE DK_GIAMHOADON.DHN_DANHBO=th.db AND th.ngaythuhoi IS NOT NULL


SELECT *
FROM T_NhapThuHoi th
WHERE th.ngaycamket IS NOT NULL