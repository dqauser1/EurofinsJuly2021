using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class RediffLoginTest
    {
        public static IWebDriver driver;
        [SetUp]
        public void openBrowser()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");
            //1. Navigate to www.rediff.com
            driver.Navigate().GoToUrl("https://www.rediff.com");
        }
        [Test]
        public void When_Login_With_Incorrect_Email_Then_Should_Get_Error()
        {
            //2. Click on the Rediffmail icon / link on the top 
            driver.FindElement(By.LinkText("Rediffmail")).Click();

            //3. Enter username as "test"
            driver.FindElement(By.Id("login1")).SendKeys("test");

            //4. Enter password as "test"
            driver.FindElement(By.Id("password")).SendKeys("test");

            //5. Click on Sign in button
            driver.FindElement(By.Name("proceed")).Click();

            //6. Verify that the error message is "Wrong username and password combination."
            string actual = driver.FindElement(By.Id("div_login_error")).Text;
            string expected = "Wrong username and password combination.";

            Assert.AreEqual(actual, expected);
        }

        [TearDown]
        public void CloseBrower()
        {
            driver.Quit();
        }
    }
}
