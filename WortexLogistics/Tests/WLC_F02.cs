using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bunit;
using Bunit.TestDoubles.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using WortexLogistics.Areas.Identity.Pages.Account;
using WortexLogistics.Shared;
using WortexLogistics.Tests.Mocks;
using Xunit;
using Xunit.Abstractions;
using Index = WortexLogistics.Pages.Index;
using TruckIndex = WortexLogistics.Pages.TruckCargos.IndexModel;
    
namespace WortexLogistics.Tests
{
    public class WLC_F02
    {
        [Fact]
        public void TransportWorkerCanSeeTruckInfoNavigationButton()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<NavigationManager>(new MockNavigationManager());

            var authContext = ctx.Services.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");
            authContext.SetRoles("transportworker");

            //// Act
            var cut = ctx.RenderComponent<NavMenu>();

            //// Assert
            Assert.Contains("Truck", cut.Markup);
        }
    }
}
