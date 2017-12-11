using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCR.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver _driver;

        [Given(@"I was in the Login View")]
        public void GivenIWasInTheLoginView()
        {
            _driver = new ChromeDriver("./");
            _driver.Url = "http://localhost:37754/Account/Login";
        }
        
        [Given(@"I filled the username and password field")]
        public void GivenIFilledTheUsernameAndPasswordField()
        {
            _driver.FindElement(By.XPath("//*[@id='Email']")).SendKeys("Hades@gmail.com");
            _driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
        }
        
        [When(@"I press Login")]
        public void WhenIPressLogin()
        {
            _driver.FindElement(By.XPath("//*[@id='login']")).Click();
        }
        
        [Then(@"I should be Logged in and arrive at homepage")]
        public void ThenIShouldBeLoggedInAndArriveAtHomepage()
        {
            _driver.FindElement(By.XPath("//*[@id='user']")).Text.CompareTo("Welcome back Hades!");
            _driver.Url.CompareTo("http://localhost:37754/Home");
            _driver.Close();
        }
    }
}
