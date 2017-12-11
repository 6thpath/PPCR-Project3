using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCR.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class US01_ViewProjectDetailsSteps
    {
        public IWebDriver _driver;

        [Given(@"I was in Projects list view")]
        public void GivenIWasInProjectsListView()
        {
            _driver = new ChromeDriver("./");
            _driver.Url = "http://localhost:37754/Home/User_ViewProjectList";

        }

        [When(@"I click the ViewDetail button of the project '(.*)'")]
        public void WhenIClickTheViewDetailButtonOfTheProject(string p0)
        {
            _driver.FindElement(By.XPath("//*[@id='View']")).Click();
        }

        [Then(@"the name of project on detail page should be: '(.*)'")]
        public void ThenTheNameOfProjectOnDetailPageShouldBe(string p0)
        {
            //Property Name - Price - Unit Price
            _driver.FindElement(By.XPath("//*[@id='propertynameandprice']")).Text.CompareTo("PIS Top Apartment - 100000 USD");
        }

        [Then(@"the Street Name of project on detail page should be: '(.*)'")]
        public void ThenTheStreetNameOfProjectOnDetailPageShouldBe(string p0)
        {
            //Street Name
            _driver.FindElement(By.XPath("//*[@id='street']")).Text.CompareTo("Điền Viên Thôn");
        }

        [Then(@"the Ward Name of project on detail page should be: '(.*)'")]
        public void ThenTheWardNameOfProjectOnDetailPageShouldBe(string p0)
        {
            //Ward Name
            _driver.FindElement(By.XPath("//*[@id='ward']")).Text.CompareTo("TT Tây Đằng");
        }

        [Then(@"the District Name of project on detail page should be: '(.*)'")]
        public void ThenTheDistrictNameOfProjectOnDetailPageShouldBe(string p0)
        {
            //District Name
            _driver.FindElement(By.XPath("//*[@id='district']")).Text.CompareTo("Ba Vì");
        }

        [Then(@"the Area of project on detail page should be: '(.*)'")]
        public void ThenTheAreaOfProjectOnDetailPageShouldBe(string p0)
        {
            //Area
            _driver.FindElement(By.XPath("//*[@id='area']")).Text.CompareTo("120m2");
        }

        [Then(@"the number of bedroom of project on detail page should be: '(.*)'")]
        public void ThenTheNumberOfBedroomOfProjectOnDetailPageShouldBe(int p0)
        {
            //Bedroom
            _driver.FindElement(By.XPath("//*[@id='bedroom']")).Text.CompareTo("3");
        }

        [Then(@"the number of bathroom of project on detail page should be: '(.*)'")]
        public void ThenTheNumberOfBathroomOfProjectOnDetailPageShouldBe(int p0)
        {
            //Bathroom
            _driver.FindElement(By.XPath("//*[@id='bathroom']")).Text.CompareTo("3");
        }

        [Then(@"the number of parking place of project on detail page should be: '(.*)'")]
        public void ThenTheNumberOfParkingPlaceOfProjectOnDetailPageShouldBe(int p0)
        {
            //parkingplace
            _driver.FindElement(By.XPath("//*[@id='parkingplace']")).Text.CompareTo("1");
        }

        [Then(@"the Property type of project on detail page should be: '(.*)'")]
        public void ThenThePropertyTypeOfProjectOnDetailPageShouldBe(string p0)
        {
            //Property Type
            _driver.FindElement(By.XPath("//*[@id='propertytype']")).Text.CompareTo("Apartment");
        }

        [Then(@"the Status ID of project on detail page should be: '(.*)'")]
        public void ThenTheStatusIDOfProjectOnDetailPageShouldBe(string p0)
        {
            //Property Status
            _driver.FindElement(By.XPath("//*[@id='propertystatus']")).Text.CompareTo("Đã duyệt");
            _driver.Close();
        }
    }
}
