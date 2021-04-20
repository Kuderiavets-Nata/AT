using System;
using OpenQA.Selenium;




namespace Lab4.Pages
{
    public class MainPage
    {
        private IWebDriver driver;
        private string url = "https://rozetka.com.ua/";

        public IWebElement SearchFlield => driver.FindElement(By.CssSelector("input[name='search']"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[contains(., 'Знайти')]"));
        public IWebElement UaLangButton => driver.FindElement(By.XPath("//a[@href='/ua/']"));
       

        public MainPage(IWebDriver browser)
        {
            driver = browser;
        }

        public MainPage NavigateToUrl()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public MainPage ImputTextIntoSearchField(string parameter)
        {
            SearchFlield.Clear();
            SearchFlield.SendKeys(parameter);
            SearchButton.Click();
            return this;

        }
        public MainPage ClickOnSearchButton()
        {
            SearchButton.Click();
            return this;
        }

        public MainPage ClickUaButton()
        {
            UaLangButton.Click();
            return this;
        }

        

    }
}

