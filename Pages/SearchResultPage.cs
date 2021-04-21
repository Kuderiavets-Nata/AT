using System;
using Atata;
namespace Lab15.Pages
{
    using _ = SearchResultPage;

    public class SearchResultPage : Page<_>
    {
        [FindByClass("goods-tile__price")]
        public Text<_> Prises { get; private set; }

        [FindByXPath("//a[@href='https://rozetka.com.ua/apple_z11b000q8/p284631368/']")]
        public Link<_> FindedElement { get; private set; }
 
        
    }
}
