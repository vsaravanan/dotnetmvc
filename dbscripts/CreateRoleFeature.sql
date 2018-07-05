
use velocity
go

drop table RoleFeature;


create table RoleFeature (
	id int primary key identity,
	roleName nvarchar(50) not null,
	featureName nvarchar(50) not null,
	isActive bit not null,
	isMaker bit not null,
	makerDt datetime null,
	makerBy nvarchar(50) null,
	checkDt datetime null,
	checkBy nvarchar(50) null
);

insert into RoleFeature (featureName, roleName, isActive, isMaker)
select featureName, roleName, 1, 1 from
(
	select featureName, roleName 
	from Feature f, Role r
	where roleName = 'Maker'
	and ( featureName like 'view%' or featureName like 'edit%')
	union all
	select featureName, roleName 
	from Feature f, Role r
	where roleName = 'Checker'
	and ( featureName like 'approve%' )
	union all
	select featureName, roleName 
	from Feature f, Role r
	where roleName in ('Readonly')
	and ( featureName like 'view%' )
	union all
	select featureName, roleName 
	from Feature f, Role r
	where roleName in ('Tester')
)
a


select * from RoleFeature;