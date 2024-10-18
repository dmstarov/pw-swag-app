using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class LoginPage : PageTest
    {
        private readonly IPage _page;
        private readonly string usernameInput = "[data-test=\"username\"]";
        private readonly string passwordInput = "[data-test=\"password\"]";
        private readonly string loginButton = "[data-test=\"login-button\"]";

        public LoginPage(IPage page)
        {
            _page = page;
        }

        //public async Task Login(string username, string password)
        public async Task Login()
        {
            await _page.Locator(usernameInput).FillAsync(TestData.ValidUsername);
            await _page.Locator(passwordInput).FillAsync(TestData.ValidPassword);
            await _page.Locator(loginButton).ClickAsync();
        }

        public async Task VerifyLoginSuccess()
        {
            await Expect(_page).ToHaveURLAsync(TestData.InventoryUrl);
        }
    }
}
