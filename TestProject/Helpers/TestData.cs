namespace PlaywrightTests.Helpers
{
    public static class TestData
    {
        // URLs
        public static string BaseUrl = "https://www.saucedemo.com/";
        public static string InventoryUrl = "https://www.saucedemo.com/inventory.html";
        public static string CartUrl = "https://www.saucedemo.com/cart.html";
        public static string CheckoutStepOneUrl = "https://www.saucedemo.com/checkout-step-one.html";
        public static string CheckoutStepTwoUrl = "https://www.saucedemo.com/checkout-step-two.html";
        public static string CheckoutCompleteUrl = "https://www.saucedemo.com/checkout-complete.html";

        // Credentials
        public static string ValidUsername = "standard_user";
        public static string ValidPassword = "secret_sauce";

        // Product Data
        public static string TshirtName = "Sauce Labs Bolt T-Shirt";
        public static string TshirtPrice = "$15.99";
        public static string Quantity = "1";

        // Checkout Info
        public static string FirstName = "testName";
        public static string LastName = "testLastName";
        public static string PostalCode = "1212";
    }
}
