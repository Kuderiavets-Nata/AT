using System;
using Atata;
namespace Lab15.Pages
{
    using _ = ElementPage;

    public class ElementPage : Page<_>
    {
        [FindByClass("product-prices__big")]
        public Text<_> Price { get; private set; }



    }
}
