using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MyStoreTest.BaseClasses
{
    [TestClass]
    public class TestBase
    {
        public static IWebDriver Driver;

        [TestCleanup]
        public void RunAfterEveryTest()
        {
            PageBase.CloseBrowser();
        }
    }
}
