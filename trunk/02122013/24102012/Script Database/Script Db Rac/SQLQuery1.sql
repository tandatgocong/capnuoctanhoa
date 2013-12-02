select LEFT(PLT,4) from dbo.TB_GANMOI where TODS='tp'
group by LEFT(PLT,4)
order by LEFT(PLT,4) asc