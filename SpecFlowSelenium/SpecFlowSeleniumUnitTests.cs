using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using System;
using Xunit;


namespace SpecFlowSelenium
{
    public class SpecFlowSeleniumUnitTests : IDisposable
    {
        private string baseURL = "http://www.google.com";
        private RemoteWebDriver driver;

        public SpecFlowSeleniumUnitTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(this.baseURL);
            driver.FindElementById("lst-ib").Clear();
        }

        [Fact]
        public void SearchForLincolnAssisination()
        {
            driver.FindElementById("lst-ib").SendKeys("Abraham Lincoln assisination date" + Keys.Enter);
            Assert.True(driver.PageSource.Contains("April 14, 1865"));
        }

        [Fact]
        public void SearchForFirstManOnTheMoon()
        {
            driver.FindElementById("lst-ib").SendKeys("first man on the moon" + Keys.Enter);
            Assert.True(driver.PageSource.Contains("Neil Armstrong"));
            Assert.True(driver.PageSource.Contains("Apollo 11"));
        }

        public void Dispose()
          {
            driver.Quit();
          }

    }
}
