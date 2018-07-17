using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using velocity.Generic;

namespace velocity.Models
{

    [Table("ttn_fees_bus_mdl")]
    public class Fee : IPK<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("model_id")]
        public int id { get; set; }
        public string idx_iso_a2 { get; set; }
        public string idx_fees_bus_center { get; set; }
        public string idx_business_class_code { get; set; }
        public string idx_iso_MIC { get; set; }
        public string idx_iso_a3 { get; set; }
        public int? idx_tenor_id { get; set; }
        public string idx_asset_base_denomination { get; set; }
        public string idx_model_code { get; set; }
        public int idx_model_ver { get; set; }
        public DateTime data_model_effective { get; set; }
        public bool isActive { get; set; }
    }
}
