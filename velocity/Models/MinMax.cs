using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using velocity.Generic;

namespace velocity.Models
{

    public class MinMax : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string tradeId { get; set; }
        public string executionDt { get; set; }
        public string ISIN { get; set; }
        public string equity { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string feesSchedulePara { get; set; }
        public DateTime effectiveDt { get; set; }
        public decimal minFeePct { get; set; }
        public decimal maxFeePct { get; set; }
        public decimal minFee { get; set; }
        public string transactionCost { get; set; }
        public string costIndicator { get; set; }
        public string country { get; set; }
        public string businessFees { get; set; }
        public string financialAssets { get; set; }
        public string MIC { get; set; }
        public string Currency { get; set; }
        public bool isActive { get; set; }
    }
}
