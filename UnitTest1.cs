using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;



namespace Lab4
{
    public class Tests
    {
        IWebDriver driver;

        private Pages.MainPage mainPage;
        private Pages.SearchResultPage searchResultPage;
        private Pages.ElementPage elementPage;

        [OneTimeSetUp]
        public void SetupBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [Test]
        public void Test1()
        {
            int parameter = 1;

            mainPage = new Pages.MainPage(driver);
            mainPage.NavigateToUrl()
                .ClickUaButton()
                .ImputTextIntoSearchField("macbook pro")
                .ClickOnSearchButton();

           searchResultPage = new Pages.SearchResultPage(driver);
            string PriceStrOnSearchResultPage =  searchResultPage.PriceStr(parameter);

            searchResultPage.ClickProduct(parameter);
            elementPage = new Pages.ElementPage(driver);
            string PriceStrOnElementPage = elementPage.PriceStr();

            driver.Navigate().Back();

            string PriceStrOnSearchResultPage2 = searchResultPage.PriceStr(parameter);


            TestContext.WriteLine(PriceStrOnSearchResultPage);
            TestContext.WriteLine(PriceStrOnElementPage);
            TestContext.WriteLine(PriceStrOnSearchResultPage2);

            Assert.AreEqual(PriceStrOnSearchResultPage, PriceStrOnElementPage);
            Assert.AreEqual(PriceStrOnSearchResultPage, PriceStrOnSearchResultPage2);
        }

        [OneTimeTearDown]
        public void TearDownBroser()
        {
            driver.Close();
        }
    }
}