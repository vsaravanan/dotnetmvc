using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{

    [Table("tbl_min_max")]
    public class MinMax : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string transId { get; set; }
        public string LEI { get; set; }
        public string CIF { get; set; }
        public string BuySell { get; set; }
        public DateTime? executionDt { get; set; }
        public string ISIN { get; set; }
        public string instrument { get; set; }
        public decimal quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal transactionCost { get; set; }
        public decimal transactionFees { get; set; }
        public decimal totalConsideration { get; set; }
        public string feesScheduleParagraph { get; set; }
        public DateTime? effectiveDt { get; set; }
        public decimal minFeePct { get; set; }
        public decimal minFee { get; set; }
        public decimal maxFeePct { get; set; }
        public decimal maxFee { get; set; }
        public decimal minFloor { get; set; }
        public string costIndicator { get; set; }
        public string country { get; set; }
        public string businessFeesInfo { get; set; }
        public string financialAssetsType { get; set; }
        public string MIC { get; set; }
        public string ccy { get; set; }
        public bool isActive { get; set; }
    }
}
