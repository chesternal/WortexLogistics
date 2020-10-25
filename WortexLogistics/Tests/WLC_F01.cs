using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bunit;
using Bunit.TestDoubles.Authorization;
using WortexLogistics.Areas.Identity.Pages.Account;
using WortexLogistics.Shared;
using Xunit;

namespace WortexLogistics.Tests
{
    public class WLC_F01
    {
        [Fact]
        public void InvalidLoginMessageTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.Services.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");

            //// Act
            //var cut = ctx.RenderComponent<LoginModel>();

            //// Assert
            //cut.MarkupMatches(@"<h1>Welcome TEST USER</h1>
            //        <p>State: Authorized</p>");
        }
    }
}
