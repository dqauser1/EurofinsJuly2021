using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class GoogleSearch
    {
        public static IWebDriver driver;

        [Test, Category("GoogleTests")]
        public void When_I_Search_Then_I_Receive_Results()
        {
            //Act
            //Enter the search string               
            IWebElement searchbox = driver.FindElement(By.Name("q"));
            string searchstring = "selenium";
            searchbox.SendKeys(searchstring);

            //Hit the Enter key
            searchbox.SendKeys(Keys.Enter);

            //Assert
            //Verify that the title contains searchstring
            //Assert.Contains(actualtitle, "selenium");
            Assert.That(driver.Title, Does.Contain(searchstring));

            //First link on results page should contain searchstring
            IWebElement firstlink = driver.FindElement(By.TagName("h3"));
            Assert.That(firstlink.Text, Does.Contain(searchstring).IgnoreCase);
            //Assert.Pass(firstlink.Text, searchstring, StringComparison.OrdinalIgnoreCase);
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

        [TearDown]
        public void CloseBrower()
        {
            driver.Quit();
        }

    }
}
