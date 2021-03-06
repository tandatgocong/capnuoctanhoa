SELECT hd.DOT,hd.KHU,sl.DANHBO,hd.HOPDONG,hd.TENKH,hd.SONHA,hd.DUONG,hd.GIABIEU,hd.DINHMUC,hd.HIEUDH,hd.CULY,
sl.T1,sl.T2,sl.T3,sl.T4,sl.T5,sl.T6,sl.T7,sl.T8,sl.T9,sl.T10,sl.T11,sl.T12,
sl.T12015,sl.T22015,sl.T32015,sl.T42015,sl.T52015,sl.T62015,SL.T72015,SL.T82015,SL.T92015,SL.T102015,SL.T112015,SL.T122015
FROM SOLIEUHD2014 sl
LEFT JOIN HOADONTH03_2015 hd
ON hd.DANHBO=sl.DANHBO
ORDER BY DOT ASC



UPDATE SOLIEUHD2014 SET SOLIEUHD2014.T32015 =hd.LNCC
FROM HOADONTH03_2015 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO



------------------------------------------------------------------------------------------
SELECT hd.DOT,hd.KHU,sl.DANHBO,hd.HOPDONG,hd.TENKH,hd.SONHA,hd.DUONG,hd.GIABIEU,hd.DINHMUC,hd.HIEUDH,hd.CULY,
sl.T1,sl.T2,sl.T3,sl.T4,sl.T5,sl.T6,sl.T7,sl.T8,sl.T9,sl.T10,sl.T11,sl.T12
FROM SOLIEUHD2015 sl
LEFT JOIN HOADONTH09_2015 hd
ON hd.DANHBO=sl.DANHBO
ORDER BY DOT ASC



INSERT INTO SOLIEUHD2015(DANHBO,T9)
SELECT h.DANHBO, h.LNCC as 'T9'
FROM HOADONTH09_2015 h
WHERE CODE='M';

UPDATE SOLIEUHD2015 SET T4 =hd.LNCC
FROM HOADONTH04_2015 hd
WHERE SOLIEUHD2015.DANHBO= hd.DANHBO

delete from SOLIEUHD2015
