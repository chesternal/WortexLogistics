using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WortexLogistics.Controllers;
using WortexLogistics.Data;
using WortexLogistics.Models;
using WortexLogistics.Tests.Mocks;
using Xunit;
using Xunit.Abstractions;

namespace WortexLogistics.Tests
{
    public class WLC_F07
    {
        [Fact]
        public async void DetailedStockListTest()
        {
            // var options = new DbContextOptionsBuilder<wortexlogisticsContext>().UseInMemoryDatabase("wortex").Options;
            // var context = new wortexlogisticsContext(options);
            // List<TruckCargo> truckCargos = new List<TruckCargo>();
            // for (int i = 0; i < 10; i++)
            // {
            //     truckCargos.Add(new TruckCargo());
            // }
            // context.TruckCargo.AddRange(truckCargos);
            // await context.SaveChangesAsync();

            // var controller = new TruckCargoesController(context);
            // var ienumerable = (await controller.GetTruckCargo()).Value;

            // Assert.True(ienumerable.Count() == truckCargos.Count);
        }
    }
}
