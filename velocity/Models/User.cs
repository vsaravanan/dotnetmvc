using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{
    public class User : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string bankId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string avatar { get; set; }
        public bool  isActive { get; set; }
        public bool isMaker { get; set; }
        public Nullable<DateTime> makerDt { get; set; }
        public string makerBy { get; set; }
        public Nullable<DateTime> checkDt { get; set; }
        public string checkBy { get; set; }
    }
}
