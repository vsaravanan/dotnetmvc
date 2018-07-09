use velocity
go

drop table ProductTemplate;
go

create table ProductTemplate (
	id int primary key identity,
	Product							nvarchar(50) null,
	NamedBankingProductAttributes	nvarchar(200) null,
	BPAID							int null,
	Mandatory						nvarchar(1) null,
	OnScreen						nvarchar(1) null,
	UpdatedDt						datetime null,
	UpdatedBy						nvarchar(50) null,
	ApprovedDt						datetime null,
	ApprovedBy						nvarchar(50) null
);

