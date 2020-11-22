using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WortexLogistics.Models;

namespace WortexLogistics.Pages.TruckCargos
{
    public class IndexModel : PageModel
    {
        private readonly WortexLogistics.Data.wortexlogisticsContext _context;

        public IndexModel(WortexLogistics.Data.wortexlogisticsContext context)
        {
            _context = context;
        }

        public IList<TruckCargo> TruckCargo { get;set; }
        public decimal TotalWeight { get; set; }
        public string ErrorHandling { get; set; }
        public string WeightHandling { get; set; }

        public string CurrentLocation { get; set; }
        public string Moving { get; set; }
        public string NextDestination { get; set; }

        public string Button { get; set; }

        public async Task OnGetAsync()
        {
            TruckCargo = await _context.TruckCargo.ToListAsync();
            foreach(var cargo in TruckCargo)
            {
                if (cargo.TcargoCount == 0)
                {
                    WeightHandling = "ERROR: No cargo!";
                }
                else if(cargo.TcargoWeight <= 0 || cargo.TcargoWeight > 500)
                {
                    TotalWeight = (decimal)(TotalWeight + cargo.TcargoWeight);
                    WeightHandling = "ERROR: At least one item has a strange weight";
                }
                else
                {
                    TotalWeight = (decimal)(TotalWeight + (cargo.TcargoWeight*cargo.TcargoCount));
                }
            }

            NextDestination = TruckCargo.Any() ? TruckCargo[0].TcargoDestination : "Home";
            Button = "Dispatch!";
            if (TotalWeight > 500)
            {
                ErrorHandling = "ERROR: Truck has too much load";
                CurrentLocation = "Home";
                Moving = "Stopped";
            }
            else if (TotalWeight < 0)
            {
                ErrorHandling = "ERROR: Truck has negative load";
                CurrentLocation = "Home";
                Moving = "Stopped";
            }
            else if(!TruckCargo.Any()){
                CurrentLocation = "Home";
                Button = "Dispatch!";
                Moving = "Stopped";
            }
            else
            {
                ErrorHandling = "Good to go!";
                
                string[] gps = new string[] { "Tallinn", "Tartu", "Pärnu", "Viljandi", "Rapla", "Haapsalu", "Valga", "Seal", "Siin", "Iganurgapeal", "Jõgeva", "Home", "Home", "Home", "Home", "Home", "Home" };

                while (CurrentLocation != NextDestination)
                {
                    Button = "Check";
                    Random rnd = new Random();
                    int random = rnd.Next(0, 16);
                    CurrentLocation = gps[random];

                    if (CurrentLocation == "Siin" || CurrentLocation == "Seal" || CurrentLocation == "Iganurgapeal")
                    {
                        Moving = "WRONG WAY!";
                        break;
                    }
                    else if (CurrentLocation == NextDestination)
                    {
                        Moving = "Stopped";
                        break;
                    }
                    else if (CurrentLocation == "Home")
                    {
                        Button = "Dispatch!";
                        Moving = "Stopped";
                        break;
                    }
                    else
                    {
                        Moving = "Driving!";
                        break;
                    }
                }
            }
        }
    }
}
