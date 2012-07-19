SELECT left(LOTRINH,2), nv.NAME,COUNT(*)
FROM TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv
WHERE convert(int,substring(LOTRINH,3,2)) = nv.MAYDS AND (HIEUDH  IS NULL OR HIEUDH='' OR NGAYTHAY IS NULL)
AND LEFT(LOTRINH,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15','16','17','18','19','20')
GROUP BY LEFT(LOTRINH,2), nv.NAME
ORDER BY LEFT(LOTRINH,2) ASC


SELECT left(LOTRINH,2), COUNT(*)
FROM TB_DULIEUKHACHHANG kh
WHERE (HIEUDH  IS NULL OR HIEUDH='' OR NGAYTHAY IS NULL)
GROUP BY left(LOTRINH,2)
ORDER BY left(LOTRINH,2) ASC

SELECT LEFT(LOTRINH,2), LOTRINH, kh.DANHBO, kh.HOPDONG, HOTEN, kh.SONHA, TENDUONG, kh.PHUONG, kh.QUAN,HIEUDH, SOTHANDH,VITRIDHN, nv.NAME , hd.Code
FROM TB_DULIEUKHACHHANG kh,TB_NHANVIENDOCSO nv, HOADONTH06 hd
WHERE convert(int,substring(LOTRINH,3,2)) = nv.MAYDS AND hd.DanhBo= kh.DANHBO 
AND (HIEUDH  IS NULL OR HIEUDH='' OR NGAYTHAY IS NULL) 
AND LEFT(LOTRINH,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15','16','17','18','19','20')
ORDER BY  LEFT(LOTRINH,2) ASC

SELECT LEFT(LOTRINH,2), LOTRINH, kh.DANHBO, kh.HOPDONG, HOTEN, kh.SONHA, TENDUONG, kh.PHUONG, kh.QUAN,HIEUDH, SOTHANDH,VITRIDHN, nv.NAME , hd.Code
FROM TB_DULIEUKHACHHANG kh,TB_NHANVIENDOCSO nv, HOADONTH06 hd
WHERE convert(int,substring(LOTRINH,3,2)) = nv.MAYDS AND hd.DanhBo= kh.DANHBO 
AND (HIEUDH  IS NULL OR HIEUDH='' OR NGAYTHAY IS NULL) 
AND LEFT(LOTRINH,2) IN ('18','19','20')
ORDER BY  LEFT(LOTRINH,2) ASC
