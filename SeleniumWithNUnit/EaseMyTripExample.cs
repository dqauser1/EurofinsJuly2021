using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNUnit
{
    class EaseMyTripExample
    {

        IWebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {
            
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void TestBookTicket()
        {
            
            driver.Navigate().GoToUrl("https://www.easemytrip.com/");

            driver.FindElement(By.XPath("(//input[@class='src_btn'])[1]")).Click();



            driver.FindElement(By.XPath("//button[text()='Book Now']")).Click();

            Assert.IsNotNull(driver.FindElement(By.XPath("//span[text()='Flight Detail']")));

        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
