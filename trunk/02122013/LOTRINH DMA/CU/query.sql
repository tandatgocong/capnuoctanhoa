SELECT DETINCT

SELECT DISTINCT  tb1.*,tb2.LNCC, tb2.CHUKY, tb2.CODE,(convert(float,tb2.LNCC)/tb2.CHUKY) as 'TBTT'
FROM (SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA + ''+TENDUONG as 'DIACHI',CODH,GIABIEU,DINHMUC, '' 'HIEULUC'
FROM TB_DULIEUKHACHHANG
UNION 
SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA + ''+TENDUONG as 'DIACHI',CODH,GIABIEU,DINHMUC , N'Hủy' as 'HIEULUC'
FROM TB_DULIEUKHACHHANG_HUYDB
) as tb1
INNER JOIN HOADONTH02_2013 tb2
ON tb1.DANHBO = tb2.DANHBO

 
SELECT DISTINCT  tb1.*,tb2.TIEUTHU, tb2.CODE,(convert(float,tb2.TIEUTHU)/tb1.CHUKYDS) as 'TBTT'
FROM (SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA + ''+TENDUONG as 'DIACHI',CODH,GIABIEU,DINHMUC, '' 'HIEULUC',CHUKYDS
FROM TB_DULIEUKHACHHANG
UNION 
SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA + ''+TENDUONG as 'DIACHI',CODH,GIABIEU,DINHMUC , N'Hủy' as 'HIEULUC',CHUKYDS
FROM TB_DULIEUKHACHHANG_HUYDB
) as tb1
INNER JOIN [DocSo_PHT].[dbo].[DS2012] tb2
ON tb1.DANHBO = tb2.DANHBA
where KY=10




/*
 private System.Windows.Forms.DataGridViewTextBoxColumn DHN_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DANHBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_HIEUDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_TENKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_CODHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_SOTHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_CHISO;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_LYDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_GHICHU;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGTT;
        
        */