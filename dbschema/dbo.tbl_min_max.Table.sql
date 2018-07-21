USE velocity
GO

drop table [tbl_min_max]
;

/****** Object:  Table [dbo].[tbl_min_max]    Script Date: 7/21/2018 4:10:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_min_max](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TransId] [varchar](max) NULL,
	[LEI] [varchar](max) NULL,
	[CIF] [varchar](max) NULL,
	[BuySell] [varchar](4) NULL,
	[ExecutionDt] [varchar](19) NULL,
	[ISIN] [varchar](max) NULL,
	[Instrument] [varchar](max) NULL,
	[Quantity] [varchar](max) NULL,
	[UnitPrice] [float] NULL,
	[TransactionCost] [float] NULL,
	[TransactionFees] [float] NULL,
	[TotalConsideration] [varchar](max) NULL,
	[FeesScheduleParagraph] [varchar](50)  NULL,
	[EffectiveDt] [varchar](10) NULL,
	[minPctFee] [float] NULL,
	[minFee] [float] NULL,
	[maxPctFee] [float] NULL,
	[maxFee] [float] NULL,
	[minFloor] [decimal](12, 2) NULL,
	[costIndicator] [nvarchar](100) NULL,
	[Country] [varchar](100) NULL,
	[businessFeesInfo] [varchar](max) NULL,
	[financialAssetsType] [varchar](max) NULL,
	[MIC] [varchar](max) NULL,
	[Currency] [varchar](106) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_min_max] ON 

INSERT [dbo].[tbl_min_max] ([id], [TransId], [LEI], [CIF], [BuySell], [ExecutionDt], [ISIN], [Instrument], [Quantity], [UnitPrice], [TransactionCost], [TransactionFees], [TotalConsideration], [FeesScheduleParagraph], [EffectiveDt], [minPctFee], [minFee], [maxPctFee], [maxFee], [minFloor], [costIndicator], [Country], [businessFeesInfo], [financialAssetsType], [MIC], [Currency]) VALUES (1, N'SCTRSC1815000001', N'RILFO74KP1CM8P6PCT96', N'271400', N'SELL', N'2018-05-15 13:39:53', NULL, N'ROYAL DUTCH SHELL PLC', N'2331', 25.35, 59090.850000000006, 174.88, N'58915.97', N'GB.02.001', N'01/13/2018', 0.25, 147.73, 1, 590.91, CAST(150.00 AS Decimal(12, 2)), N'within limit', N'United Kingdom', N'Trading and Investment Business Fees', N'Equities-listed and equity-like listed instrument transactions', N'SGX-BT (SINGAPORE EXCHANGE BOND TRADING PTE. LTD)', N'GBP (Pound sterling)')
SET IDENTITY_INSERT [dbo].[tbl_min_max] OFF
