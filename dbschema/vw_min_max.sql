
use test
go

drop view vw_min_max
go

create view vw_min_max
as
WITH arm as 
(
SELECT 
	   arm.ARM_002_04 AS TransId
	  ,arm.ARM_004_02 AS LEI
	  , isnull(arm.ARM_007_01, arm.ARM_016_01) AS CIF  -- IDENTIFY BUYER OR SELLER
	  , IIF(arm.ARM_007_01 IS NULL, 'SELL', 'BUY') AS BuySell -- IDENTIFY SIDE BUY OR SELL
	  , LEFT(CONVERT(datetime2, arm.ARM_028_01, 126),19) AS ExecutionDt
	  , arm.ARM_041_01 AS ISIN
	  , arm.ARM_042_01 AS Instrument
	  , arm.ARM_030_01 as Quantity
	  , round(arm.ARM_033_01,2) as UnitPrice
	  , round(arm.ARM_030_01,2) * round(arm.ARM_033_01, 2) as TransactionCost   -- QUANTITY x UNIT PRICE
	  , abs( round( ( round(arm.ARM_030_01,2) * round(arm.ARM_033_01, 2) ) - round(arm.ARM_035_04, 2) , 2) ) as TransactionFees   -- TOTAL CONSIDERATION - TRANSACTION COST
	  , arm.ARM_035_04 as TotalConsideration
	  , ARM_037_02
	  , ARM_031_01
  FROM	ttn_host_txn_arm arm
  where arm.ARM_043_01 = 'SHARES'
)
, model as (
	select 
		  arm.TransId
		, arm.LEI
		, arm.CIF
		, arm.BuySell
		, arm.ExecutionDt
		, arm.ISIN
		, arm.Instrument
		, arm.Quantity
		, arm.UnitPrice
		, arm.TransactionCost
		, arm.TransactionFees
		, arm.TotalConsideration
		, model.*
	FROM arm
  INNER JOIN ttn_fees_bus_mdl model
  ON arm.ARM_037_02 = model.idx_iso_a2		-- Only UK
  AND arm.ARM_031_01 = model.idx_iso_a3		-- Only GBP
  AND model.idx_iso_a2 = 'GB'
  AND model.idx_business_class_code = 'TXN_EQUITY'	
  AND model.model_id = 7001
)
, final as (
	SELECT model.*
		, fees.idx_code FeesScheduleParagraph
		, CONVERT(VARCHAR(10), model.data_model_effective, 101) EffectiveDt
		, round(cast(fees.pct_MIN_txn_value as float), 2) minPctFee
		, round(model.TransactionCost *  fees.pct_MIN_txn_value / 100, 2)  minFee
		, round(cast(fees.pct_MAX_txn_value as float), 2) maxPctFee
		, round(model.TransactionCost *  fees.pct_MAX_txn_value / 100, 2)  maxFee
		, fees.floor_txn_fee minFloor
	FROM model
	INNER JOIN  ttn_fees_schedule fees
	ON		fees.idx_model_id = model.idx_model_code
	AND		fees.idx_model_id = 'GB.0001'
)
SELECT 
	  final.TransId
	, final.LEI
	, final.CIF
	, final.BuySell
	, final.ExecutionDt
	, final.ISIN
	, final.Instrument
	, final.Quantity
	, final.UnitPrice
	, final.TransactionCost
	, final.TransactionFees
	, final.TotalConsideration
	, final.FeesScheduleParagraph
	, final.EffectiveDt
	, final.minPctFee
	, final.minFee
	, final.maxPctFee
	, final.maxFee
	, final.minFloor
	, dbo.fnCheckBreach(final.minFee, final.maxFee, final.minFloor, final.TransactionFees) costIndicator
	, country.iso_country_name_plain Country
	, business.info_description businessFeesInfo
	, assets.data_business_class_description financialAssetsType
	, mic.data_iso_ACRONYM + ' (' + mic.data_iso_NAME_INSTITUTION_DESCRIPTION +')' MIC
	, final.idx_iso_a3 + ' (' + ccy.iso_ccy_name +')' Currency
FROM final 
INNER JOIN ttn_ISO3166 country
ON country.iso_a2 = final.idx_iso_a2
INNER JOIN ttn_fees_business business
ON final.idx_fees_bus_center = business.idx_fees_bus_center
INNER JOIN ttn_business_class assets
ON final.idx_business_class_code = assets.idx_business_class_code
INNER JOIN ttn_ISO10383 mic
ON final.idx_iso_MIC = mic.iso_MIC	
INNER JOIN ttn_ISO4217 ccy
ON final.idx_iso_a3 = ccy.iso_a3
;

drop table tbl_min_max;
go

select 
id=IDENTITY (int, 1,1)
, m.* into tbl_min_max from vw_min_max m
;