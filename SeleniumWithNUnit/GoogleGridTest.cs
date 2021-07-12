using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace SeleniumWithNUnit
{
    class GoogleGridTest
    {
        public static IWebDriver driver;

        [Test, Category("GoogleTests")]
        public void When_Grid_IsOpened_NumberOfApps_IsEqualTo31()
        {
            //Click on the GRID icon on google home page
            driver.FindElement(By.ClassName("gb_Ve")).Click();

            driver.SwitchTo().Frame(0);

            //Add some wait
            Thread.Sleep(5000);

            //Get All the elements of the same class j1ei8c
            ReadOnlyCollection<IWebElement> all_apps = driver.FindElements(By.ClassName("Rq5Gcb"));
            int number_of_apps = all_apps.Count;

            foreach(IWebElement everyapp in all_apps)
            {
                Console.WriteLine(everyapp.Text);
            }

            Console.WriteLine("Number of Elements found: " + number_of_apps);
            
            Assert.AreEqual(31, number_of_apps);
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
