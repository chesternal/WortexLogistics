using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WortexLogistics.Models
{
    public partial class WarehouseCargo
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Cargo Name")]
        public string WCargoName { get; set; }

        [Column(TypeName = "smallint")]
        [Display(Name = "Cargo Count")]
        public string WCargoCount { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        [Display(Name = "Cargo Weight")]
        public string WCargoWeight { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Cargo Name")]
        public string WCargoOrigin { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Cargo Name")]
        public string WCargoDestination { get; set; }


        public WarehouseCargo GetWarehouseCargo()
        {
            return new WarehouseCargo
            {
                WCargoName = WCargoName,
                WCargoCount = WCargoCount,
                WCargoWeight = WCargoWeight,
                WCargoOrigin = WCargoOrigin,
                WCargoDestination = WCargoDestination
            };
        }
    }
}