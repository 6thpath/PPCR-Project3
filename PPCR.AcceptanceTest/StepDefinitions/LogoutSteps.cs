using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCR.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class LogoutSteps
    {
        public IWebDriver _driver;

        [Given(@"I was logged in the website")]
        public void GivenIWasLoggedInTheWebsite()
        {
            _driver = new ChromeDriver("./");
            _driver.Url = "http://localhost:37754/Account/Login";
            _driver.FindElement(By.XPath("//*[@id='Email']")).SendKeys("Hades@gmail.com");
            _driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
            _driver.FindElement(By.XPath("//*[@id='login']")).Click();
        }
        
        [Given(@"I was in Homepage")]
        public void GivenIWasInHomepage()
        {
            _driver.FindElement(By.XPath("//*[@id='user']")).Text.CompareTo("Welcome back Hades!");
            _driver.Url.CompareTo("http://localhost:37754/Home");
        }
        
        [When(@"I press Logout")]
        public void WhenIPressLogout()
        {
            _driver.FindElement(By.XPath("//*[@id='logout']")).Click();
        }
        
        [Then(@"I should be Logged out and arrive at Login Page")]
        public void ThenIShouldBeLoggedOutAndArriveAtLoginPage()
        {
            _driver.Url.CompareTo("http://localhost:37754/Account/Login");
            _driver.Close();
        }
    }
}
