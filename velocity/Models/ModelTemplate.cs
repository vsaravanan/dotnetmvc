using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{
    public class ModelTemplate : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Product { get; set; }
        public int namedBankingProductAttribute { get; set; }
        public int bpaid { get; set; }
        public string targetModelAttribute { get; set; }
        public bool mandatory { get; set; }
        public bool onScreen { get; set; }
        public Nullable<DateTime> UpdatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> ApprovedDt { get; set; }
        public string ApprovedBy { get; set; }


    }
}


