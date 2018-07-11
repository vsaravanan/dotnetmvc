use velocity
go

drop table ModelTemplate;
go

create table ModelTemplate (
	id int primary key identity,
	Product							nvarchar(50) null,
	NamedBankingProductAttribute	nvarchar(200) null,
	BPAID							int null,
	TargetModelAttribute			nvarchar(50) null,
	Mandatory						nvarchar(1) null,
	OnScreen						nvarchar(1) null,
	widgetType						nvarchar(50) null,
	"values"						nvarchar(200) null,
	UpdatedDt						datetime null,
	UpdatedBy						nvarchar(50) null,
	ApprovedDt						datetime null,
	ApprovedBy						nvarchar(50) null
);

SET IDENTITY_INSERT [dbo].[ModelTemplate] ON 
INSERT [dbo].[ModelTemplate] ([id], [Product], [NamedBankingProductAttribute], [BPAID], [TargetModelAttribute], [Mandatory], [OnScreen], [UpdatedDt], [UpdatedBy], [ApprovedDt], [ApprovedBy]) VALUES (1, N'NOTES', N'Instrument identification code', 1, N'APA.001.01', N'Y', N'Y', CAST(N'2018-03-06T11:00:00.000' AS DateTime), N'Haridasani, Ajay Shankar', CAST(N'2018-03-06T11:00:00.000' AS DateTime), N'Haridasani, Ajay Shankar')
SET IDENTITY_INSERT [dbo].[ModelTemplate] OFF
