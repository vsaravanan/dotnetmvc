use velocity
go

drop table ProductTemplate;
go

create table ProductTemplate (
	id int primary key identity,
	Product							nvarchar(50) null,
	NamedBankingProductAttribute	nvarchar(200) null,
	BPAID							int null,
	Mandatory						nvarchar(1) null,
	OnScreen						nvarchar(1) null,
	widgetType						nvarchar(50) null,
	"values"						nvarchar(200) null,
	UpdatedDt						datetime null,
	UpdatedBy						nvarchar(50) null,
	ApprovedDt						datetime null,
	ApprovedBy						nvarchar(50) null
);

SET IDENTITY_INSERT [dbo].[ProductTemplate] ON 
INSERT [dbo].[ProductTemplate] ([id], [Product], [NamedBankingProductAttribute], [BPAID], [Mandatory], [OnScreen], [UpdatedDt], [UpdatedBy], [ApprovedDt], [ApprovedBy]) VALUES (1, N'NOTES', N'Instrument identification code', 1, N'Y', N'Y', CAST(N'2018-03-06T11:00:00.000' AS DateTime), N'Haridasani, Ajay Shankar', CAST(N'2018-03-06T11:00:00.000' AS DateTime), N'Haridasani, Ajay Shankar')
SET IDENTITY_INSERT [dbo].[ProductTemplate] OFF
