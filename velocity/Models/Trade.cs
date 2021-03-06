﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{
    public class Trade : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string tradedata { get; set; }
        public bool  isActive { get; set; }
        public Nullable<DateTime> UpdatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> ApprovedDt { get; set; }
        public string ApprovedBy { get; set; }
    }
}
