SELECT hd.DOT,hd.KHU,sl.DANHBO,hd.HOPDONG,hd.TENKH,hd.SONHA,hd.DUONG,hd.GIABIEU,hd.DINHMUC,hd.HIEUDH,hd.CODH,
sl.T1,sl.T2,sl.T3,sl.T4,sl.T5,sl.T6,sl.T7,sl.T8,sl.T9,sl.T10,sl.T11,sl.T12,sl.T12014,sl.T22014,sl.T32014,sl.T42014
FROM SOLIEUHD2013 sl
LEFT JOIN HOADONTH04_2014 hd
ON hd.DANHBO=sl.DANHBO
ORDER BY DOT ASC


UPDATE SOLIEUHD2013 SET T32014 =hd.LNCC
FROM HOADONTH03_2014 hd
WHERE SOLIEUHD2013.DANHBO= hd.DANHBO

UPDATE SOLIEUHD2013 SET T42014 =hd.LNCC
FROM HOADONTH04_2014 hd
WHERE SOLIEUHD2013.DANHBO= hd.DANHBO


UPDATE SOLIEUHD2013 SET T5 =hd.LNCC
FROM HOADONTH02_2014 hd
WHERE SOLIEUHD2013.DANHBO= hd.DANHBO

UPDATE SOLIEUHD2013 SET T6 =hd.LNCC
FROM HOADONTH06_2013 hd
WHERE SOLIEUHD2013.DANHBO= hd.DANHBO

UPDATE SOLIEUHD2013 SET T7 =hd.LNCC
FROM HOADONTH07_2013 hd
WHERE SOLIEUHD2013.DANHBO= hd.DANHBO


------------------------------------------------------------------------------------------
SELECT hd.DOT,hd.KHU,sl.DANHBO,hd.HOPDONG,hd.TENKH,hd.SONHA,hd.DUONG,hd.GIABIEU,hd.DINHMUC,hd.HIEUDH,hd.CODH,
sl.T1,sl.T2,sl.T3,sl.T4,sl.T5,sl.T6,sl.T7,sl.T8,sl.T9,sl.T10,sl.T11,sl.T12
FROM SOLIEUHD2014 sl
LEFT JOIN HOADONTH04_2014 hd
ON hd.DANHBO=sl.DANHBO
ORDER BY DOT ASC



DELETE FROM SOLIEUHD2014

INSERT INTO SOLIEUHD2014(DANHBO,T1)
SELECT h.DANHBO, h.LNCC as 'T1'
FROM HOADONTH01_2014 h
WHERE CODE='M';



UPDATE SOLIEUHD2014 SET T2 =hd.LNCC
FROM HOADONTH02_2014 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T2)
SELECT h.DANHBO, h.LNCC as 'T2'
FROM HOADONTH02_2014 h
WHERE CODE='M';
-----------
UPDATE SOLIEUHD2014 SET T3 =hd.LNCC
FROM HOADONTH03_2014 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T3)
SELECT h.DANHBO, h.LNCC as 'T3'
FROM HOADONTH03_2014 h
WHERE CODE='M';


---------------

UPDATE SOLIEUHD2014 SET T4 =hd.LNCC
FROM HOADONTH04_2014 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T4)
SELECT h.DANHBO, h.LNCC as 'T4'
FROM HOADONTH04_2014 h
WHERE CODE='M';
---

UPDATE SOLIEUHD2014 SET T5 =hd.LNCC
FROM HOADONTH05_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T5)
SELECT h.DANHBO, h.LNCC as 'T5'
FROM HOADONTH05_2013 h
WHERE CODE='M';
-------------
UPDATE SOLIEUHD2014 SET T6 =hd.LNCC
FROM HOADONTH06_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T6)
SELECT h.DANHBO, h.LNCC as 'T6'
FROM HOADONTH06_2013 h
WHERE CODE='M';

-------------
UPDATE SOLIEUHD2014 SET T7 =hd.LNCC
FROM HOADONTH07_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T7)
SELECT h.DANHBO, h.LNCC as 'T7'
FROM HOADONTH07_2013 h
WHERE CODE='M';
-------------
UPDATE SOLIEUHD2014 SET T8 =hd.LNCC
FROM HOADONTH08_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T8)
SELECT h.DANHBO, h.LNCC as 'T8'
FROM HOADONTH08_2013 h
WHERE CODE='M';
-------------
UPDATE SOLIEUHD2014 SET T9 =hd.LNCC
FROM HOADONTH09_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T9)
SELECT h.DANHBO, h.LNCC as 'T9'
FROM HOADONTH09_2013 h
WHERE CODE='M';
-------------
UPDATE SOLIEUHD2014 SET T10 =hd.LNCC
FROM HOADONTH10_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T10)
SELECT h.DANHBO, h.LNCC as 'T10'
FROM HOADONTH10_2013 h
WHERE CODE='M';

-------------
UPDATE SOLIEUHD2014 SET T11 =hd.LNCC
FROM HOADONTH11_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T11)
SELECT h.DANHBO, h.LNCC as 'T11'
FROM HOADONTH11_2013 h
WHERE CODE='M';
-------------
UPDATE SOLIEUHD2014 SET T12 =hd.LNCC
FROM HOADONTH12_2013 hd
WHERE SOLIEUHD2014.DANHBO= hd.DANHBO


INSERT INTO SOLIEUHD2014(DANHBO,T12)
SELECT h.DANHBO, h.LNCC as 'T12'
FROM HOADONTH12_2013 h
WHERE CODE='M';

