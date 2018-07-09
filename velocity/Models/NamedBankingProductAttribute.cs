
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;


namespace velocity.Models
{
    public class NamedBankingProductAttribute : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int bpaid { get; set; }
        public string section { get; set; }
        public string description { get; set; }

    }
}
