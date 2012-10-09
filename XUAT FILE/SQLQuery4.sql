SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH, VITRIDHN 
FROM TB_DULIEUKHACHHANG where KY<=8 AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC


SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH, VITRIDHN 
FROM TB_DULIEUKHACHHANG where KY<=8 AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC

SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH, VITRIDHN 
FROM TB_DULIEUKHACHHANG where KY<=8 AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  LOTRINH ASC

-----------------------------------------------

SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG,P.TENPHUONG, q.TENQUAN,kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM
FROM  TB_DULIEUKHACHHANG kh,  PHUONG p, QUAN q
WHERE kh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND kh.QUAN='31' AND kh.PHUONG='04'
AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')
ORDER BY  q.MAQUAN  ASC,P.MAPHUONG ASC,kh.LOTRINH ASC