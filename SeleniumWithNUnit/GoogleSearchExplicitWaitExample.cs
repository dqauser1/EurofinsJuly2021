using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class GoogleSearchExplicitWaitExample
    {
        public static IWebDriver driver;

        [Test, Category("GoogleTests")]
        [Category("ExplicitWaitTests")]
        public void When_I_Enter_String_And_Click_Search_Then_I_Receive_Results()
        {
            //Act
            //Enter the search string               
            IWebElement searchbox = driver.FindElement(By.Name("q"));
            string searchstring = "selenium";
            searchbox.SendKeys(searchstring);

            //Click on the Google Search Button
            IWebElement searchbutton = driver.FindElement(By.CssSelector("input[value='Google Search']"));

            //Explict wait for Element to be clickable / Solution for - Element Not Interactable Exception
            WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchbutton));

            searchbutton.Click();            
        }

        [SetUp]
        public void Setup()
        {
            //Arrange
            //Open a Browser
            //Navigate to the URL
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");
            driver.Navigate().GoToUrl("https://www.google.com");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void CloseBrower()
        {
            driver.Quit();
        }

    }
}
