using System;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text;
namespace Lab4.Pages
{
    public class SearchResultPage
    {
        private IWebDriver driver;

        public ReadOnlyCollection<IWebElement> Prices => driver.FindElements(By.XPath("//span[contains(@class, 'goods-tile__price')]"));
        public ReadOnlyCollection<IWebElement> Elements => driver.FindElements(By.XPath("//span[contains(@class, 'goods-tile__title')]"));


        public SearchResultPage(IWebDriver browser)
        {
            driver = browser;
         
        }

        public String PriceStr(int parameter)
        {
            return Prices[parameter-1].Text.Trim('₴');
        }

        public SearchResultPage ClickProduct(int parameter)
        {
            IWebElement Element = Elements[parameter - 1];
            Element.Click();
            return this;
        }
    }
}
