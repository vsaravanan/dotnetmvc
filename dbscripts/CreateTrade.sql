use velocity
go

drop table Trade;
go

create table Trade (
	id int primary key identity,
	tradedata						nvarchar(4000) null,
	isActive						bit not null,
	UpdatedDt						datetime null,
	UpdatedBy						nvarchar(50) null,
	ApprovedDt						datetime null,
	ApprovedBy						nvarchar(50) null
);

