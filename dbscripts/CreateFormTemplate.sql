use velocity
go

drop table FormTemplate
go


create table FormTemplate (
	id int primary key identity,
	fieldName nvarchar(50) not null,
	isRequired bit not null,
	isScreen bit not null,
	inputType nvarchar(50) not null,
	"values" nvarchar(200) null,
	isActive bit not null,
	isMaker bit not null,
	makerDt datetime null,
	makerBy nvarchar(50) null,
	checkDt datetime null,
	checkBy nvarchar(50) null
);

insert into FormTemplate (fieldName, isRequired, isScreen, inputType, "values", isActive, isMaker) 
select
	'f1', 1, 1, 'textbox', null, 1, 0
union all
select
	'f2', 0, 1, 'textbox', null, 1, 0
union all
select
	'f3', 1, 0, 'textbox', null, 1, 0
union all
select
	'f4', 0, 1, 'checkbox', null, 1, 0
union all
select
	'f5', 0, 1, 'listbox', 'Open|InProcess|Closed', 1, 0


select * from FormTemplate;