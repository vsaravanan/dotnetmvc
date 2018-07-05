

drop table "User";


create table "User" (
	id int primary key identity,
	bankId   nvarchar(50) not null,
	username nvarchar(50) not null,
	password nvarchar(50) null,
	isActive bit not null,
	isMaker bit not null,
	makerDt datetime null,
	makerBy nvarchar(50) null,
	checkDt datetime null,
	checkBy nvarchar(50) null
);

insert into "User" (bankId, username, password, isActive, isMaker) values ('1256173','Saravanan', 'dummy',  1, 1);
insert into "User" (bankId, username, password, isActive, isMaker) values ('1533039','Ramesh', 'dummy',  1, 1);
insert into "User" (bankId, username, password, isActive, isMaker) values ('1587096','Kushal', 'dummy',  1, 1);

select * from "User";