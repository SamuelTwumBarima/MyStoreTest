using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStoreTest.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyStoreTest.Test
{
    public class ProductResultPage :PageBase
    {
		#region ObjectDefinitions
		// search field
		public static IWebElement txtSearch => Driver.FindElement(By.CssSelector("#search_query_top"));

		// search button
		public static IWebElement iconSearch => Driver.FindElement(By.CssSelector("[name='submit_search']"));
		#endregion

		public ProductResultPage(IWebDriver driver):base(driver)
        {  
        }

		public static void SelectItemFromResult(string itemPrice)
		{
			Wait(2);
			IWebElement itemToHover = Driver.FindElement(By.XPath($"//*[@class='right-block']/div/span[contains(text(),'{itemPrice}')]/parent::div/parent::div/parent::div/div[2]/h5"));
			HoverMouse(itemToHover);

			IWebElement itemToSelect = Driver.FindElement(By.XPath($"//*[@class='right-block']/div/span[contains(text(),'{itemPrice}')]/parent::div/parent::div/parent::div/div[2]/div[2]/a[2]"));
			itemToSelect.Click();
		}

        public static void SearchforProduct(string productName)
        {
			// type product name in search field
			SetTextBoxValue(txtSearch, productName);

			//Click on search icon
			iconSearch.Click();
		}
    }
}