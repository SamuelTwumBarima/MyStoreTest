using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MyStoreTest.BaseClasses
{
    [TestClass]
    public class PageBase
    {
        public static IWebDriver Driver;

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public static void SetTextBoxValue(IWebElement txtBoxElement, string ValueToSet)
        {
            txtBoxElement.Click();
            txtBoxElement.Clear();
            txtBoxElement.SendKeys($"{ValueToSet}");
        }

        public static void SelectDropdownItemByText(IWebElement dropdownItem, string valueToSelect)
        {
            SelectElement select = new SelectElement(dropdownItem);
            select.SelectByText(valueToSelect);
        }

        public static void SelectDropdownItembyValue(IWebElement dropdownitem, String valuetoSelect)
        {
            SelectElement select = new SelectElement(dropdownitem);
            select.SelectByValue(valuetoSelect);
        }

        public static void CloseBrowser()
        {
            // use try-catch as this would fail if browser has already been closed
            try
            {
                Driver.Close();
                Driver.Quit();
            }
            catch { }
        }

        public static void LaunchUrl(string UrlToLaunch, string browserToUse = "chrome")
        {
            InitializeDriver(browserToUse);

            // intermittent timeout issue
            try
            {
                Driver.Navigate().GoToUrl(UrlToLaunch);
            }
            catch { }
        }

        public static void InitializeDriver(string browser = "chrome")
        {
            if (browser.ToLower() == "firefox")
            {
                Driver = new FirefoxDriver();
            }
            else if (browser.ToLower() == "chrome")
            {

                Driver = new ChromeDriver();
            }
            else if (browser.ToLower() == "ie" || browser.ToLower() == "internet explorer")
            {

                Driver = new InternetExplorerDriver();
            }
            else if (browser.ToLower() == "edge")
            {

                Driver = new EdgeDriver();
            }

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public static void WaitForElementToBeVisible(IWebElement elementToWait, int timeoutInSeconds = 30, bool waitToBeVisible = true)
        {
            bool isVisible = !waitToBeVisible;
            while (isVisible != waitToBeVisible)
            {
                try
                {
                    isVisible = elementToWait.Displayed;
                }
                catch
                {
                    isVisible = false;
                }
            }
        }

        public static void WaitForElement(string propertyType, string propertyValue, int timeoutInSeconds = 600)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            DateTime dteStart = DateTime.Now;
            bool isElementFound = false;
            do
            {
                switch (propertyType.ToUpper())
                {
                    case "XPATH":
                        isElementFound = Driver.FindElement(By.XPath(propertyValue)).Displayed;
                        break;

                    case "ID":
                        isElementFound = Driver.FindElement(By.Id(propertyValue)).Displayed;
                        break;

                    case "LINKTEXT":
                        isElementFound = Driver.FindElement(By.LinkText(propertyValue)).Displayed;
                        break;
                }
            } while ((isElementFound == false) && (DateTime.Now.Subtract(dteStart).Seconds < timeoutInSeconds));

            if (isElementFound == false)
                throw new Exception("Element NOT Found: " + propertyValue);
        }

        public static void HoverMouse(IWebElement itemToHover)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(itemToHover).Perform();
        }
    }
}
