using System;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text;
namespace Lab4.Pages
{
    public class ElementPage
    {
        private IWebDriver driver;

        public IWebElement Price => driver.FindElement(By.CssSelector(".product-prices__big"));
       

        public ElementPage(IWebDriver browser)
        {
            driver = browser;
        }

        

        public String PriceStr()
        {
            return Price.Text.Trim('₴');
        }

    }
}
