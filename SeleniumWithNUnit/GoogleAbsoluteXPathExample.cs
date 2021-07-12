using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class GoogleAbsoluteXPathExample
    {
        public static IWebDriver driver;

        [Test, Category("GoogleTests")]
        public void Test_Google_WithXpath()
        {
            IWebElement searchbox;

            searchbox = driver.FindElement(By.XPath("/html/body/div/div[3]/form/div/div/div/div/div[2]/input"));

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
