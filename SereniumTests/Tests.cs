using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
/* For using Remote Selenium WebDriver */
using OpenQA.Selenium.Remote;
 
// [assembly: CollectionBehavior(MaxParallelThreads = 4)]
//[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
 
namespace xUnit_Test_Cross_Browser
{
    public class Tests
    {
        String baseUrl = "http://localhost:5000/";
 
        [Fact]
        public void TC01()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                
                var greeting = driver.FindElement(By.Id("greeting"));

                Assert.Equal("Hello, manager@wortex.com!", greeting.Text);

                driver.Quit();
            }
        }

        [Fact]
        public void TC02()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Vale");
                
                var greeting = driver.FindElement(By.Id("error-login"));

                Assert.Equal("Invalid login attempt.", greeting.Text);

                driver.Quit();
            }
        }

        [Fact]
        public void TC03()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "DontKnow@d", "Parool123!");
                
                var greeting = driver.FindElement(By.Id("error-login"));

                Assert.Equal("Invalid login attempt.", greeting.Text);

                driver.Quit();
            }
        }

        [Fact]
        public void TC04()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "worker@wortex.com", "Parool123!");
                
                var greeting = driver.FindElement(By.Id("role"));

                Assert.Equal("Role: transportworker", greeting.Text);

                driver.Quit();
            }
        }

        [Fact]
        public void TC05()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");

                var greeting = driver.FindElement(By.Id("role"));

                Assert.Equal("Role: manager", greeting.Text);

                driver.Quit();
            }
        }

        [Fact]
        public void TC06()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                var warehouse = driver.FindElement(By.Id("warehousecargo-link"));
                warehouse.Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("create")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("WcargoName")).SendKeys("New cargo");
                driver.FindElement(By.Id("WcargoCount")).SendKeys("1");
                driver.FindElement(By.Id("WcargoWeight")).SendKeys("23");
                driver.FindElement(By.Id("WcargoOrigin")).SendKeys("Rakvere");
                driver.FindElement(By.Id("WcargoDestination")).SendKeys("Tallinn");

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                
                Assert.NotNull(driver.FindElements(By.XPath("//td")).First(x => x.Text == "New cargo"));
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC07()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                var warehouse = driver.FindElement(By.Id("warehousecargo-link"));
                warehouse.Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("create")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("WcargoName")).SendKeys("New cargo");
                driver.FindElement(By.Id("WcargoCount")).SendKeys("ye");
                driver.FindElement(By.Id("WcargoWeight")).SendKeys("23");
                driver.FindElement(By.Id("WcargoOrigin")).SendKeys("Rakvere");
                driver.FindElement(By.Id("WcargoDestination")).SendKeys("Tallinn");

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                
                Assert.Equal("Please enter a valid number.", driver.FindElement(By.Id("WcargoCount-error")).Text);
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC08()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("warehousecargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("create")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("WcargoName")).SendKeys("New cargo");
                driver.FindElement(By.Id("WcargoCount")).SendKeys("1");
                driver.FindElement(By.Id("WcargoWeight")).SendKeys("no");
                driver.FindElement(By.Id("WcargoOrigin")).SendKeys("Rakvere");
                driver.FindElement(By.Id("WcargoDestination")).SendKeys("Tallinn");
                
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                
                Assert.Equal("The field WcargoWeight must be a number.", driver.FindElement(By.Id("WcargoWeight-error")).Text);
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC09()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("warehousecargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("edit")).Click();

                System.Threading.Thread.Sleep(1000);
                var origin = driver.FindElement(By.Id("WcargoOrigin"));
                origin.Clear();
                origin.SendKeys("Paide");
                
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                
                Assert.NotNull(driver.FindElements(By.XPath("//td")).First(x => x.Text == "Paide"));
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC10()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "worker@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("warehousecargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                
                Assert.Contains("cargo in the warehouse!", driver.FindElement(By.XPath("//main")).Text);
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC11()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "worker@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("warehousecargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("details")).Click();
                
                Assert.Equal("Details - WortexLogistics", driver.Title);

                driver.Quit();
            }
        }

        [Fact]
        public void TC12()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("warehousecargo-link")).Click();
                
                System.Threading.Thread.Sleep(1000);
                var re = new Regex(@"(\d+) cargo in the warehouse!");
                var match = re.Match(driver.FindElement(By.XPath("//main")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count = int.Parse(match.Groups[1].Value);

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("delete")).Click();
                
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();

                System.Threading.Thread.Sleep(1000);
                match = re.Match(driver.FindElement(By.XPath("//main")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count2 = int.Parse(match.Groups[1].Value);

                Assert.True(count != count2);

                driver.Quit();
            }
        }   


        [Fact]
        public void TC13()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("warehousecargo-link")).Click();
                
                System.Threading.Thread.Sleep(1000);
                var re = new Regex(@"(\d+) cargo in the warehouse!");
                var match = re.Match(driver.FindElement(By.XPath("//main")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count = int.Parse(match.Groups[1].Value);

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("delete")).Click();
                
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("back")).Click();

                System.Threading.Thread.Sleep(1000);
                match = re.Match(driver.FindElement(By.XPath("//main")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count2 = int.Parse(match.Groups[1].Value);

                Assert.True(count == count2);

                driver.Quit();
            }
        }   

        [Fact]
        public void TC14()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("truckcargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("item")));
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC15()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("truckcargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                
                Assert.NotNull(driver.FindElement(By.Id("item")));
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC16()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("truckcargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                
                Assert.Contains("Location : ", driver.FindElement(By.XPath("//main")).Text);
                
                driver.Quit();
            }
        }

        [Fact]
        public void TC17()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                var warehouse = driver.FindElement(By.Id("truckcargo-link"));
                warehouse.Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("create")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("TcargoName")).SendKeys("Car");
                driver.FindElement(By.Id("TcargoCount")).SendKeys("4");
                driver.FindElement(By.Id("TcargoWeight")).SendKeys("22");
                driver.FindElement(By.Id("TcargoOrigin")).SendKeys("Parnu");
                driver.FindElement(By.Id("TcargoDestination")).SendKeys("Tartu");

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                
                Assert.NotNull(driver.FindElement(By.Id("item")));

                driver.Quit();
            }
        }

        [Fact]
        public void TC18()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("truckcargo-link")).Click();

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("edit")).Click();

                System.Threading.Thread.Sleep(1000);
                var elem = driver.FindElement(By.Id("TcargoDestination"));
                elem.Clear();
                elem.SendKeys("Voru");

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                
                Assert.NotNull(driver.FindElements(By.XPath("//td")).First(x => x.Text == "Voru"));

                driver.Quit();
            }
        }

        [Fact]
        public void TC19()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("truckcargo-link")).Click();
                
                System.Threading.Thread.Sleep(1000);
                var re = new Regex(@"Total Weight: (\d+)");
                var match = re.Match(driver.FindElement(By.Id("total")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count = int.Parse(match.Groups[1].Value);

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("delete")).Click();
                
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();

                System.Threading.Thread.Sleep(1000);
                match = re.Match(driver.FindElement(By.Id("total")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count2 = int.Parse(match.Groups[1].Value);

                Assert.True(count != count2);

                driver.Quit();
            }
        }   


        [Fact]
        public void TC20()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("--allow-insecure-localhost");

            using (var driver = new ChromeDriver(opts))
            {
                Login(driver, "manager@wortex.com", "Parool123!");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("truckcargo-link")).Click();
                
                System.Threading.Thread.Sleep(1000);
                var re = new Regex(@"Total Weight: (\d+)");
                var match = re.Match(driver.FindElement(By.Id("total")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count = int.Parse(match.Groups[1].Value);

                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("delete")).Click();
                
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("back")).Click();

                System.Threading.Thread.Sleep(1000);
                match = re.Match(driver.FindElement(By.Id("total")).Text);

                if (!match.Success)
                {
                    Assert.True(false);
                }

                var count2 = int.Parse(match.Groups[1].Value);

                Assert.True(count == count2);

                driver.Quit();
            }
        }   


        private void Login(ChromeDriver driver, string username, string password){
            driver.Navigate().GoToUrl(baseUrl + "identity/account/login");
            
            Assert.Equal("Log in - WortexLogistics", driver.Title);

            var usernameElem = driver.FindElement(By.Id("Input_Email"));
            usernameElem.SendKeys(username);

            var passwordElem = driver.FindElement(By.Id("Input_Password"));
            passwordElem.SendKeys(password);

            var submit = driver.FindElement(By.XPath("//button[@type='submit']"));
            submit.Click();
        }
    }
}