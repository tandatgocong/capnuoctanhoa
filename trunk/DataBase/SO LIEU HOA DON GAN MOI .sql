SELECT hd.DOT,hd.KHU,sl.DANHBO,hd.HOPDONG,hd.TENKH,hd.SONHA,hd.DUONG,hd.GIABIEU,hd.DINHMUC,hd.HIEUDH,hd.CODH,
sl.T1,sl.T2,sl.T3,sl.T4,sl.T5,sl.T6,sl.T7,sl.T8,sl.T9,sl.T10,sl.T11,sl.T12,
sl.T12014,sl.T22014,sl.T32014,sl.T42014,sl.T52014,sl.T62014,SL.T72014,SL.T82014,SL.T92014,SL.T102014,SL.T112014,SL.T122014
FROM SOLIEUHD2013 sl
LEFT JOIN HOADONTH12_2014 hd
ON hd.DANHBO=sl.DANHBO
ORDER BY DOT ASC



UPDATE SOLIEUHD2013 SET T122014 =hd.LNCC
FROM HOADONTH12_2014 hd
WHERE SOLIEUHD2013.DANHBO= hd.DANHBO



------------------------------------------------------------------------------------------
SELECT hd.DOT,hd.KHU,sl.DANHBO,hd.HOPDONG,hd.TENKH,hd.SONHA,hd.DUONG,hd.GIABIEU,hd.DINHMUC,hd.HIEUDH,hd.CODH,
sl.T1,sl.T2,sl.T3,sl.T4,sl.T5,sl.T6,sl.T7,sl.T8,sl.T9,sl.T10,sl.T11,sl.T12
FROM SOLIEUHD2014 sl
LEFT JOIN HOADONTH12_2014 hd
ON hd.DANHBO=sl.DANHBO
ORDER BY DOT ASC



INSERT INTO SOLIEUHD2014(DANHBO,T12)
SELECT h.DANHBO, h.LNCC as 'T12'
FROM HOADONTH12_2014 h
WHERE CODE='M';

UPDATE SOLIEUHD2014 SET T12 =hd.LNCC
FROM HOADONTH12_2014 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO