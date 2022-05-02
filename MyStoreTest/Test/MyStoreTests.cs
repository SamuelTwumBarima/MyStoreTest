using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStoreTest.BaseClasses;
using MyStoreTest.TestDataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace MyStoreTest.Test
{
    [TestClass]
    public class MyStoreTests : TestBase
    {
        string url = ConfigurationManager.AppSettings["URL"];

        [TestMethod]
        public void SelectProductandCheckOut()
        {
            var productQueryA = ExcelDataAccess.GetTestData("QueryA");
            var productQueryB = ExcelDataAccess.GetTestData("QueryB");

            // Open Url
            MyStoreHomePage.OpenUrl(url);

            //Search for the product
            ProductResultPage.SearchforProduct(productQueryA.ProductName);

            // Select the item based on the chosen price
            ProductResultPage.SelectItemFromResult(productQueryA.Price);

            // Select the product description 
            ProductPage.SelectProductPreferenceAndAddToCart(productQueryA.Colour, productQueryA.Size, productQueryA.Quantity);

            // Click on proceed
            ProductPage.ClickOnProceedToCheckOut();

            //validate the basket values/elements
            ShoppingCartSummaryPage.CheckThatCartValuesAreCorrect(productQueryA.Total,productQueryA.Shipping,productQueryA.TotalPrice);

            // change the quantity of products in the basket
            ShoppingCartSummaryPage.UpdateQuantity(productQueryB.Quantity);

            //validate the basket values/elements
            PageBase.Wait(3);
            ShoppingCartSummaryPage.CheckThatCartValuesAreCorrect(productQueryB.Total, productQueryB.Shipping, productQueryB.TotalPrice);

        }


    }
}
