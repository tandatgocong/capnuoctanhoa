SELECT LEFT(LOTRINH,2), LOTRINH, DANHBO, HOPDONG, HOTEN, SONHA, TENDUONG, PHUONG, QUAN,HIEUDH,CODH, SOTHANDH,VITRIDHN 
FROM TB_DULIEUKHACHHANG where KY<=6 AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')
ORDER BY  LOTRINH ASC