using System;
using Atata;
namespace Lab15.Pages
{
    using _ = MainPage;

    [Url("https://rozetka.com.ua/")]
    public class MainPage : Page<_>
    {
        [FindByName("search") ]
        public TextInput<_> SearchFlield { get; private set; }

        [FindByClass("search-form__submit") ]
        public Button<_> SearchButton { get; private set; }

        [FindByXPath("//a[@href='/ua/']") ]
        public Link<_> UaLangButton { get; private set; }


    }
}
