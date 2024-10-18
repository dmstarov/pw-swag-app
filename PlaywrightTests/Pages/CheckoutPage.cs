using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.Helpers;


namespace PlaywrightTests.Pages
{
    public class CheckoutPage : PageTest
    {
        private readonly IPage _page;

        public CheckoutPage(IPage page)
        {
            _page = page;
        }

        public async Task FillCheckoutInformation(string firstName, string lastName, string postalCode)
        {
            await _page.Locator("[data-test=\"firstName\"]").FillAsync(firstName);
            await _page.Locator("[data-test=\"lastName\"]").FillAsync(lastName);
            await _page.Locator("[data-test=\"postalCode\"]").FillAsync(postalCode);
        }

        public async Task ContinueCheckout()
        {
            await _page.Locator("[data-test=\"continue\"]").ClickAsync();
            await Expect(_page).ToHaveURLAsync(TestData.CheckoutStepTwoUrl);

        }

        public async Task VerifyOrderSummary()
        {
            await Expect(_page.Locator("[data-test=\"total-label\"]")).ToContainTextAsync("Total: $17.27");
            await Expect(_page.Locator("[data-test=\"payment-info-value\"]")).ToContainTextAsync("SauceCard #31337");
        }

        public async Task FinishOrder()
        {
            await _page.Locator("[data-test=\"finish\"]").ClickAsync();
            await Expect(_page).ToHaveURLAsync(TestData.CheckoutCompleteUrl);

        }
    }
}
