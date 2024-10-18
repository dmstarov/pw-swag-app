using Microsoft.Playwright.NUnit;
using PlaywrightTests.Pages;
using Microsoft.Playwright;
using PlaywrightTests.Helpers;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;


namespace TestProject.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{
    LoginPage _loginPage;
    ProductsPage _productsPage;
    CartPage _cartPage;
    CheckoutPage _checkoutPage;

    [SetUp]
    public void Setup()
    {
        _loginPage = new LoginPage(Page);
        _productsPage = new ProductsPage(Page);
        _cartPage = new CartPage(Page);
        _checkoutPage = new CheckoutPage(Page);
    }

    [Test]

    public async Task SaucedemoTest()

    {
        // Step 1 - Navigate to the Sauce Labs Sample Application
        await Page.GotoAsync(TestData.BaseUrl);
        await Expect(Page).ToHaveURLAsync(TestData.BaseUrl);

        // Step 2 - Log in with valid credentials
        await _loginPage.Login();
        await _loginPage.VerifyLoginSuccess();

        // Step 3-7: Product Selection and Cart
        await _productsPage.SelectProduct("item-1-title-link");
        await _productsPage.AddToCart();
        await _productsPage.VerifyCartBadgeCount(TestData.Quantity);
        await _productsPage.GotoCartr();

        // Step 8-10: Cart Page Verification
        //await _cartPage.Checkout();
        await _cartPage.VerifyItemInCart(TestData.TshirtName, TestData.TshirtPrice, TestData.Quantity);
        await _cartPage.Checkout();

        // Step 11-16: Checkout and Order Completion
        await _checkoutPage.FillCheckoutInformation(TestData.FirstName, TestData.LastName, TestData.PostalCode);
        await _checkoutPage.ContinueCheckout();
        await _checkoutPage.VerifyOrderSummary();
        await _checkoutPage.FinishOrder();

        // Step 17-19: Order Completion and Logout
        await Expect(Page).ToHaveURLAsync(TestData.CheckoutCompleteUrl);
        await Expect(Page.Locator("[data-test=\"complete-header\"]")).ToContainTextAsync("Thank you for your order!");

        // Logout
        await Page.GetByRole(AriaRole.Button, new() { Name = "Open Menu" }).ClickAsync();
        await Page.Locator("[data-test=\"logout-sidebar-link\"]").ClickAsync();
        await Expect(Page).ToHaveURLAsync(TestData.BaseUrl);
    }
}
