USE velocity
GO

drop table tbl_min_max
;

/****** Object:  Table dbo.tbl_min_max    Script Date: 7/21/2018 4:10:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.tbl_min_max(
	id int IDENTITY(1,1) NOT NULL,
	transId varchar(max) NULL,
	LEI varchar(max) NULL,
	CIF varchar(max) NULL,
	buySell varchar(4) NULL,
	executionDt dateTime NULL,
	ISIN varchar(max) NULL,
	instrument varchar(max) NULL,
	quantity			decimal(18,2) NULL,
	unitPrice			decimal(18,2) NULL,
	transactionCost		decimal(18,2) NULL,
	transactionFees		decimal(18,2) NULL,
	totalConsideration	decimal(18,2) NULL,
	feesScheduleParagraph varchar(50)  NULL,
	effectiveDt dateTime NULL,
	minFeePct			decimal(18,2) NULL,
	minFee				decimal(18,2) NULL,
	maxFeePct			decimal(18,2) NULL,
	maxFee				decimal(18,2) NULL,
	minFloor			decimal(18,2) NULL,
	costIndicator nvarchar(100) NULL,
	country varchar(100) NULL,
	businessFeesInfo varchar(max) NULL,
	financialAssetsType varchar(max) NULL,
	MIC varchar(max) NULL,
	ccy varchar(106) NULL,
	isActive bit null
)
GO
SET IDENTITY_INSERT dbo.tbl_min_max ON 

USE [velocity]
GO

INSERT INTO [dbo].[tbl_min_max]
           (id
		   ,[transId]
           ,[LEI]
           ,[CIF]
           ,[buySell]
           ,[executionDt]
           ,[ISIN]
           ,[instrument]
           ,[quantity]
           ,[unitPrice]
           ,[transactionCost]
           ,[transactionFees]
           ,[totalConsideration]
           ,[feesScheduleParagraph]
           ,[effectiveDt]
           ,[minFeePct]
           ,[minFee]
           ,[maxFeePct]
           ,[maxFee]
           ,[minFloor]
           ,[costIndicator]
           ,[country]
           ,[businessFeesInfo]
           ,[financialAssetsType]
           ,[MIC]
           ,[ccy]
		   ,isActive)
     VALUES
 (1, N'SCTRSC1815000001', N'RILFO74KP1CM8P6PCT96', N'271400', N'SELL', N'2018-05-15 13:39:53', NULL, N'ROYAL DUTCH SHELL PLC', N'2331', 25.35, 59090.850000000006, 174.88, N'58915.97', N'GB.02.001', N'01/13/2018', 0.25, 147.73, 1, 590.91, CAST(150.00 AS Decimal(12, 2)), N'within limit', N'United Kingdom', N'Trading and Investment Business Fees', N'Equities-listed and equity-like listed instrument transactions', N'SGX-BT (SINGAPORE EXCHANGE BOND TRADING PTE. LTD)', N'GBP (Pound sterling)',1)
 ;
 GO



SET IDENTITY_INSERT dbo.tbl_min_max OFF

select * from tbl_min_max;


--update tbl_min_max set isActive = null;