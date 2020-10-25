using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bunit;
using Bunit.TestDoubles.Authorization;
using WortexLogistics.Areas.Identity.Pages.Account;
using WortexLogistics.Shared;
using Xunit;
using Xunit.Abstractions;
using Index = WortexLogistics.Pages.Index;

namespace WortexLogistics.Tests
{
    public class WLC_F02
    {
        [Fact]
        public void AuthorizedUserSeeRole()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.Services.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");
            authContext.SetRoles("manager");

            //// Act
            var cut = ctx.RenderComponent<Index>();

            //// Assert
            Assert.True(cut.Markup.Contains("Role: manager"));
        }
    }
}
