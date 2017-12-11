using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCR.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class ViewProjectsListSteps
    {
        public IWebDriver _driver;

        [Given(@"I was in the Homepage")]
        public void GivenIWasInTheHomepage()
        {
            _driver = new ChromeDriver("./");
            _driver.Url = "http://localhost:37754/Home/Index";
        }
        
        [When(@"I press View more on '(.*)' section")]
        public void WhenIPressViewMoreOnSection(string p0)
        {
            //View more button
            _driver.FindElement(By.XPath("//*[@id='viewmore']")).Click();
        }

        [Then(@"I should be in Projects list view")]
        public void ThenIShouldBeInProjectsListView()
        {
            //Compare 
            _driver.Url.CompareTo("http://localhost:37754/Home/User_ViewProjectList");
            _driver.Close();
        }
    }
}
