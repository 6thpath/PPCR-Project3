using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PPCR.Models;
using System.Linq;

namespace PPCR.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class RegisterSteps
    {
        [BeforeScenario("mytag")]
        public void cleandatabase()
        {
            using (DemoPPCRentalEntities db = new DemoPPCRentalEntities())
            {
                string email = "xPaths@gmail.com";
                USER user = db.USERs.SingleOrDefault(x => x.Email == email);
                int id = user.ID;
                USER u = db.USERs.Find(id);
                db.USERs.Remove(u);
                db.SaveChanges();

            }
        }
        public IWebDriver _driver;
        [Given(@"I was in register page")]
        public void GivenIWasInRegisterPage()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://localhost:37754/Account/Register";
        }

        [Given(@"I want to register with my infomation")]
        public void GivenIWantToRegisterWithMyInfomation(Table table)
        {
            foreach (var item in table.Rows)
            {
                _driver.FindElement(By.Id(item["title"])).SendKeys(item["input"]);
            }
        }

        [When(@"I press '(.*)'")]
        public void WhenIPress(string p0)
        {
            _driver.FindElement(By.XPath("//*[@id='button']")).Click();
        }

        [Then(@"There should be a success message show up")]
        public void ThenThereShouldBeASuccessMessageShowUp()
        {
            _driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div/div/form/div/div[1]/label")).Text.CompareTo("Your account successfully registered. Your account will be activated in 24h if all information is valid.");
            _driver.Close();
        }
    }
}
