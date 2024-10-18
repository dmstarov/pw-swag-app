using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.Helpers;



namespace PlaywrightTests.Pages
{
    public class ProductsPage : PageTest
    {
        private readonly IPage _page;

        public ProductsPage(IPage page)
        {
            _page = page;
        }

        public async Task SelectProduct(string productName)
        {
            await _page.Locator($"[data-test=\"{productName}\"]").ClickAsync();
        }

        public async Task AddToCart()
        {
            await _page.Locator("[data-test=\"add-to-cart\"]").ClickAsync();
        }

        public async Task VerifyCartBadgeCount(string count)
        {
            await Expect(_page.Locator("[data-test=\"shopping-cart-badge\"]")).ToContainTextAsync(count);
        }

        public async Task GotoCartr()
        {
            await _page.Locator("[data-test=\"shopping-cart-link\"]").ClickAsync();
            await Expect(_page).ToHaveURLAsync(TestData.CartUrl);
        }
    }
}
