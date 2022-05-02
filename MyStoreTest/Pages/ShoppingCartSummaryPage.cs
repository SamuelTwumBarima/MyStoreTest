using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStoreTest.BaseClasses;
using MyStoreTest.TestDataAccess;
using OpenQA.Selenium;
using System;

namespace MyStoreTest.Test
{
    public class ShoppingCartSummaryPage :PageBase
    {
        #region ObjectDefinitions
        // total value including shipping
        public static IWebElement tblTotal => Driver.FindElement(By.Id("total_price_without_tax"));

        // shipping value
        public static IWebElement tblTotalShipping => Driver.FindElement(By.Id("total_shipping"));

        // total value of products
        public static IWebElement tblTotalProducts => Driver.FindElement(By.Id("total_product"));

        // product quantity
        public static IWebElement txtCartQuantity => Driver.FindElement(By.CssSelector(".cart_quantity_input.form-control.grey"));
        #endregion

        public ShoppingCartSummaryPage(IWebDriver driver):base(driver)
        {
        }

        public static void CheckThatCartValuesAreCorrect(string productTotal, string productShipping, string productTotalPrice)
        {
            // check that total product price is correct
            Assert.AreEqual(tblTotalProducts.Text, productTotal);

            // check that shipping cost is correct
            Assert.AreEqual(tblTotalShipping.Text, productShipping);
            
            // check that total price is correct
            Assert.AreEqual(tblTotal.Text, productTotalPrice);
        }

        public static void UpdateQuantity(string quantity)
        {
            SetTextBoxValue(txtCartQuantity, quantity);
        }
    }
}