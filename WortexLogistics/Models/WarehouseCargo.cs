using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WortexLogistics.Models
{
    public partial class WarehouseCargo
    {
        [Key]
        [Column(TypeName = "int(11)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string WcargoName { get; set; }
        public short WcargoCount { get; set; }
        public decimal WcargoWeight { get; set; }
        public string WcargoOrigin { get; set; }
        public string WcargoDestination { get; set; }
    }
}
