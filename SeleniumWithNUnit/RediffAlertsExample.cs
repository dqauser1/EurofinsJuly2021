using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNUnit
{
    class RediffAlertsExample 
    { 
        public static IWebDriver driver;

        [Test]
        public void Test_Alert()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Navigate().GoToUrl("https://register.rediff.com/register/register.php");

            driver.FindElement(By.Id("Register")).Click();

            //Utilities.TakeScreenshot(driver, "C:\\Temp\\rediffpopup_");

            IAlert rediffalert = driver.SwitchTo().Alert();

            string alerttext = rediffalert.Text;
            Assert.That(alerttext, Does.Contain("full name cannot be blank").IgnoreCase);

            Thread.Sleep(5000);

            rediffalert.Accept();

        }


        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
