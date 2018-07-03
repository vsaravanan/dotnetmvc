using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace velocity.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string bankId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool  isActive { get; set; }
        public bool isMaker { get; set; }
        public Nullable<DateTime> makerDt { get; set; }
        public string makerBy { get; set; }
        public Nullable<DateTime> checkDt { get; set; }
        public string checkBy { get; set; }
    }
}
