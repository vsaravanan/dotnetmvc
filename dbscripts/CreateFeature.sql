
use velocity
go

drop table Feature;


create table Feature (
	id int primary key identity,
	featureName nvarchar(50) not null,
	featureDesc nvarchar(50) not null,
	isActive bit not null,
	isMaker bit not null,
	makerDt datetime null,
	makerBy nvarchar(50) null,
	checkDt datetime null,
	checkBy nvarchar(50) null
);

insert into Feature (featureName, featureDesc, isActive, isMaker) values ('viewLendingAgreement','', 1, 1);
insert into Feature (featureName, featureDesc, isActive, isMaker) values ('editLendingAgreement','', 1, 1);
insert into Feature (featureName, featureDesc, isActive, isMaker) values ('approveLendingAgreement','', 1, 1);

insert into Feature (featureName, featureDesc, isActive, isMaker) values ('viewLendingException','', 1, 1);
insert into Feature (featureName, featureDesc, isActive, isMaker) values ('editLendingException','', 1, 1);
insert into Feature (featureName, featureDesc, isActive, isMaker) values ('approveLendingException','', 1, 1);

insert into Feature (featureName, featureDesc, isActive, isMaker) values ('viewLendingStatic','', 1, 1);
insert into Feature (featureName, featureDesc, isActive, isMaker) values ('editLendingStatic','', 1, 1);
insert into Feature (featureName, featureDesc, isActive, isMaker) values ('approveLendingStatic','', 1, 1);


select * from Feature;