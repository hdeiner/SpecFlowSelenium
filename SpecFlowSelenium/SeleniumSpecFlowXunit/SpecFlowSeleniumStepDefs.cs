using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using SpecFlowSelenium;
using TechTalk.SpecFlow;
using System;
using Xunit;

namespace SpecFlowSelenium
{
    [Binding]
    public class SpecFlowSeleniumStepDefs : IDisposable
    {
        private string baseURL = "http://www.google.com";
        private RemoteWebDriver driver;

        public SpecFlowSeleniumStepDefs()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(this.baseURL);
            driver.FindElementById("lst-ib").Clear();
        }

        [When(@"I use Google")]
        public void WhenIUseGoogle()
        {
        }

        [Then(@"I should see ""(.*)"" when I search for ""(.*)""")]
        public void IShouldSeeResultWhenISearchForQuery(string searchResults, string searchTerms)
        {
            driver.FindElementById("lst-ib").SendKeys(searchTerms + Keys.Enter);
            Assert.True(driver.PageSource.Contains(searchResults));
        }

        public void Dispose()
        {
            driver.Quit();
        }
  
    }
}
