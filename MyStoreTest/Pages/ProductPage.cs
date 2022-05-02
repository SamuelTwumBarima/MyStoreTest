using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStoreTest.BaseClasses;
using OpenQA.Selenium;

namespace MyStoreTest.Test
{
    public class ProductPage :PageBase
    {
        #region ObjectDefinitions
		// size dropdown
        public static IWebElement dpDownSize => Driver.FindElement(By.Id("group_1"));

		// quantity field
        public static IWebElement txtQuantity => Driver.FindElement(By.Id("quantity_wanted"));

		// add to cart button
        public static IWebElement btnAddToCart => Driver.FindElement(By.CssSelector("#add_to_cart"));

		// proceed to checkout button
        public static IWebElement btnProceedToCheckout => Driver.FindElement(By.CssSelector("[title = 'Proceed to checkout']"));

        #endregion

        public ProductPage(IWebDriver driver):base(driver)
        {
        }

		public static void ClickOnProceedToCheckOut()
		{
			WaitForElementToBeVisible(btnProceedToCheckout);
			btnProceedToCheckout.Click();
		}

		public static void SelectProductPreferenceAndAddToCart(string itemColour, string itemSize, string itemQuantity)
		{
			// select colour
			SelectItemColour(itemColour);

			//select size
			SelectDropdownItemByText(dpDownSize, itemSize);

			//select quantity
			SetTextBoxValue(txtQuantity, itemQuantity);

			// click on add to cart
			btnAddToCart.Click();
		}

		public static void SelectItemColour(string productColour)
		{
			Wait(2);
			IWebElement itemColour = Driver.FindElement(By.XPath($"//*[@title='{productColour}']"));
			itemColour.Click();
		}
	}
}