
use velocity
go

drop table Role;


create table Role (
	id int primary key identity,
	roleName nvarchar(50) not null,
	roleDesc nvarchar(50) not null,
	isActive bit not null,
	isMaker bit not null,
	makerDt datetime null,
	makerBy nvarchar(50) null,
	checkDt datetime null,
	checkBy nvarchar(50) null
);

insert into Role (roleName, roleDesc, isActive, isMaker) values ('Admin','Admin', 1, 1);
insert into Role (roleName, roleDesc, isActive, isMaker) values ('Maker','Maker', 1, 1);
insert into Role (roleName, roleDesc, isActive, isMaker) values ('Checker','Checker', 1, 1);
insert into Role (roleName, roleDesc, isActive, isMaker) values ('Readonly','Readonly', 1, 1);
insert into Role (roleName, roleDesc, isActive, isMaker) values ('Trader','Trader', 1, 1);
insert into Role (roleName, roleDesc, isActive, isMaker) values ('Dealer','Dealer', 1, 1);
insert into Role (roleName, roleDesc, isActive, isMaker) values ('Tester','Tester', 1, 1);
insert into Role (roleName, roleDesc, isActive, isMaker) values ('Operator','Operator', 1, 1);


select * from Role;