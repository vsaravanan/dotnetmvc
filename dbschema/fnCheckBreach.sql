--sp_helptext vw_MIN_MAX_RPRT

drop function fnCheckBreach;
go


create function fnCheckBreach(@min decimal, @max decimal, @floor decimal, @fees decimal)
returns nvarchar(100)
as 
begin
	declare @boundary decimal;
	set @boundary = iif(@floor > @min, @floor, @min);
	if @floor > @max 
	begin
		if @fees != @boundary
			return 'breach in favour of bank';
	end
	else
	begin
		if @fees < @boundary
			return 'breach in favour of client';
		if @fees > @max
			return 'breach in favour of bank';
	end
	return 'within limit';
end;
go



select dbo.fnCheckBreach(20, 100, 30, 10);
select dbo.fnCheckBreach(20, 100, 30, 110);
select dbo.fnCheckBreach(20, 100, 30, 30);
select dbo.fnCheckBreach(20, 100, 30, 35);
select dbo.fnCheckBreach(20, 100, 30, 100);


select dbo.fnCheckBreach(20, 100, 15, 10);
select dbo.fnCheckBreach(20, 100, 15, 110);
select dbo.fnCheckBreach(20, 100, 15, 20);
select dbo.fnCheckBreach(20, 100, 15, 15);
select dbo.fnCheckBreach(20, 100, 15, 35);
select dbo.fnCheckBreach(20, 100, 15, 100);

select dbo.fnCheckBreach(20, 100, 105, 10);
select dbo.fnCheckBreach(20, 100, 105, 110);
select dbo.fnCheckBreach(20, 100, 105, 105);
select dbo.fnCheckBreach(20, 100, 105, 20);
select dbo.fnCheckBreach(20, 100, 105, 35);
select dbo.fnCheckBreach(20, 100, 105, 100);

