using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Interfaces;
using PlaywrightTests.Helpers;



namespace PlaywrightTests.Pages
{
    public class CartPage : PageTest
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        public async Task VerifyItemInCart(string itemName, string price, string quantity)
        {
            await Expect(_page.Locator("[data-test=\"item-quantity\"]")).ToContainTextAsync(quantity);
            await Expect(_page.Locator("[data-test=\"inventory-item-price\"]")).ToContainTextAsync(price);
            await Expect(_page.Locator("[data-test=\"inventory-item-name\"]")).ToContainTextAsync(itemName);
        }

        public async Task Checkout()
        {
            await _page.Locator("[data-test=\"checkout\"]").ClickAsync();
            await Expect(_page).ToHaveURLAsync(TestData.CheckoutStepOneUrl);

        }
    }
}
