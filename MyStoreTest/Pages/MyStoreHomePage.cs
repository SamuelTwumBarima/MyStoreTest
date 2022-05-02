using MyStoreTest.BaseClasses;
using OpenQA.Selenium;
using System;

namespace MyStoreTest.Test
{
    public class MyStoreHomePage:PageBase
    {
        public  MyStoreHomePage(IWebDriver driver):base(driver)
        {
        }

        public  static void OpenUrl(string url)
        {
            LaunchUrl(url);
        }

    }
}