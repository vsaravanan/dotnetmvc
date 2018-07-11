using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{
    [Table("MiFiDIIdataModel")]
    public class Mifid : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("Type")]
        public string mifidType { get; set; }
        public string attribute { get; set; }
        public int namedBankingProductAttribute { get; set; }
        public string wMXMLxPATH { get; set; }

    }
}


