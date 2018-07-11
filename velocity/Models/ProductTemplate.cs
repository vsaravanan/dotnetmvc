using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{
    public class ProductTemplate : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Product { get; set; }
        public string namedBankingProductAttribute { get; set; }
        public int bpaid { get; set; }
        public string mandatory { get; set; }
        public string onScreen { get; set; }
        public Nullable<DateTime> UpdatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> ApprovedDt { get; set; }
        public string ApprovedBy { get; set; }


    }
}


