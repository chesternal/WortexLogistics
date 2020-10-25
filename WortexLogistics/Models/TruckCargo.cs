using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WortexLogistics.Models
{
    public partial class TruckCargo
    {
        [Key]
        [Column(TypeName = "int(11)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TcargoName { get; set; }
        public short TcargoCount { get; set; }
        public decimal TcargoWeight { get; set; }
        public string TcargoOrigin { get; set; }
        public string TcargoDestination { get; set; }
    }
}
