use velocity
go

drop table CreateModelTemplate;
go

create table CreateModelTemplate (
	id int primary key identity,
	Product							nvarchar(50) null,
	NamedBankingProductAttributes	nvarchar(200) null,
	BPAID							int null,
	TargetModelAttribute			nvarchar(50) null,
	Mandatory						nvarchar(1) null,
	OnScreen						nvarchar(1) null,
	UpdatedDt						datetime null,
	UpdatedBy						nvarchar(50) null,
	ApprovedDt						datetime null,
	ApprovedBy						nvarchar(50) null
);

