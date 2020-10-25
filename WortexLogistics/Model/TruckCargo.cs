using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WortexLogistics.Models
{
    public partial class TruckCargo
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Cargo Name")]
        public string TCargoName { get; set; }

        [Column(TypeName = "smallint")]
        [Display(Name = "Cargo Count")]
        public string TCargoCount { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        [Display(Name = "Cargo Weight")]
        public string TCargoWeight { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Cargo Name")]
        public string TCargoOrigin { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Cargo Name")]
        public string TCargoDestination { get; set; }


        public TruckCargo GetTruckCargo()
        {
            return new TruckCargo
            {
                TCargoName = TCargoName,
                TCargoCount = TCargoCount,
                TCargoWeight = TCargoWeight,
                TCargoOrigin = TCargoOrigin,
                TCargoDestination = TCargoDestination
            };
        }
    }
}