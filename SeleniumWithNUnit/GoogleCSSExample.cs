using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class GoogleCSSExample
    {
        public static IWebDriver driver;

        [Test, Category("GoogleTests")]
        public void Test_Google_WithCSS()
        {
            IWebElement searchbox;

            searchbox = driver.FindElement(By.CssSelector("form div.a4bIc > input"));

            searchbox.SendKeys("Learning Selenium Xpath");
        }

        [SetUp]
        public void Setup()
        {
            //Arrange
            //Open a Browser
            //Navigate to the URL
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");
            driver.Navigate().GoToUrl("https://www.google.com");
        }
    }
}
