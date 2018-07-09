

drop table "User";


create table "User" (
	id int primary key identity,
	bankId   nvarchar(50) not null,
	username nvarchar(50) not null,
	password nvarchar(50) null,
	role	 nvarchar(50) null,
	avatar   nvarchar(200) null,
	isActive bit not null,
	isMaker bit not null,
	makerDt datetime null,
	makerBy nvarchar(50) null,
	checkDt datetime null,
	checkBy nvarchar(50) null
);

insert into "User" (bankId, username, password, role, avatar, isActive, isMaker) values ('1256173','Saravanan', 'dummy', 'Admin','http://www.gravatar.com/avatar/897f1cc24b3be89bd6a6c090293f6358',  1, 1);
insert into "User" (bankId, username, password, role, avatar, isActive, isMaker) values ('1533039','Ramesh', 'dummy', 'Trader','http://www.gravatar.com/avatar/8438955dfe1b59fe2c1fe01869c8bc3c', 1, 1);
insert into "User" (bankId, username, password, role, avatar, isActive, isMaker) values ('1587096','Kushal', 'dummy', 'Readonly','',  1, 1);

select * from "User";