UPDATE HOADONTH05 SET  KHU= t2.LOTRINH , Field37=t2.HIEUDH 
FROM TB_DULIEUKHACHHANG t2
WHERE HOADONTH05.DANHBO = t2.DANHBO

SELECT KHU AS LOTRINH, DOT, DANHBO, CODH, HOPDONG, TENKH, SONHA, DUONG, GIABIEU, DINHMUC, KY, NAM, CODE, CODEF, CSCU, CSMOI, RT, CHUKY, LNCC, LNCT, Field36, Field37, QUAN, PHUONG FROM HOADONTH05 WHERE GIABIEU=15 AND LEFT(Field37,3) <> 'KEN'
ORDER BY LOTRINH ASC
