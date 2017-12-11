using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCR.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        public IWebDriver _driver;

        [Given(@"I was in Projects-list view")]
        public void GivenIWasInProjects_ListView()
        {
            _driver = new ChromeDriver("./");
            _driver.Url = "http://localhost:37754/Home/User_ViewProjectList";
        }
        
        [When(@"I typed keyword i want to search for, Ex: '(.*)'")]
        public void WhenITypedKeywordIWantToSearchForEx(string p0)
        {
            _driver.FindElement(By.XPath("//*[@id='keyword']")).SendKeys("PIS");
            
        }

        [When(@"I press Search button")]
        public void WhenIPressSearchButton()
        {
            _driver.FindElement(By.XPath("//*[@id='button']")).Click();
        }
        
        [Then(@"There should be a list contains only: '(.*)', '(.*)', '(.*)'")]
        public void ThenThereShouldBeAListContainsOnly(string p0, string p1, string p2)
        {
            _driver.FindElement(By.XPath("//*[@id='propertyname']")).Text.CompareTo("PIS Top Apartment");
            _driver.FindElement(By.XPath("//*[@id='propertyname']")).Text.CompareTo("PIS Serviced Apartment – Boho Style");
            _driver.FindElement(By.XPath("//*[@id='propertyname']")).Text.CompareTo("PIS Serviced Apartment – Style 3");
            _driver.Close();
        }
    }
}
