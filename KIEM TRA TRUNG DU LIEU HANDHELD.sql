SELECT * FROM HANDHELD WHERE DANHBO='13132115444'
WHERE TENKH IS NOT NULL

SELECT DANHBO FROM HANDHELD
GROUP BY DANHBO
HAVING COUNT(DANHBO)>=2
ORDER BY DANHBO ASC

SELECT DANHBO FROM HANDHELD
GROUP BY DANHBO
HAVING COUNT(LOTRINH)>=2
ORDER BY DANHBO ASC