using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{
    public class RoleFeature : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string roleName { get; set; }
        public string featureName { get; set; }
        public bool   isActive { get; set; }
        public bool   isMaker { get; set; }
        public Nullable<DateTime> makerDt { get; set; }
        public string makerBy { get; set; }
        public Nullable<DateTime> checkDt { get; set; }
        public string checkBy { get; set; }
    }
}
