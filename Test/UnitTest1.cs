using Atata;
using NUnit.Framework;

namespace Lab15
{
    public class Tests : UITestFixture
    { 
        
        [Test]
        public void Test1()
        {
            Go.To<Pages.MainPage>().
                SearchFlield.
                Set("macbook pro").
                SearchButton.ClickAndGo<Pages.SearchResultPage>();

            string PriceStrOnSearchResultPage = Go.To<Pages.SearchResultPage>().Prises.Get().Trim(' ','₴');

            Go.To<Pages.SearchResultPage>().
                FindedElement.ClickAndGo<Pages.ElementPage>();

            string PriceStrOnElementPage = Go.To<Pages.ElementPage>().Price.Get().Trim(' ', '₴');

            Go.To<Pages.ElementPage>().
                GoBack<Pages.SearchResultPage>();

            string PriceStrOnSearchResultPage2 = Go.To<Pages.SearchResultPage>().Prises.Get().Trim(' ', '₴');

            Assert.AreEqual(PriceStrOnSearchResultPage, PriceStrOnElementPage);
            Assert.AreEqual(PriceStrOnSearchResultPage, PriceStrOnSearchResultPage2);



        }
    }
}