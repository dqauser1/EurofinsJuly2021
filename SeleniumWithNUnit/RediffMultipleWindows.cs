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
    class RediffMultipleWindows
    {
        public static IWebDriver driver;
        [Test]
        public void Test_Multiple_Windows()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Navigate().GoToUrl("https://register.rediff.com/register/register.php");

            string mainwindow = driver.CurrentWindowHandle;

            driver.FindElement(By.PartialLinkText("terms")).Click();

            driver.FindElement(By.PartialLinkText("privacy")).Click();


            //driver.WindowHandles returns a List of Strings
            //This list of strings are unique identifiers for all the browser windows that are currently open
            IReadOnlyCollection<string> handles = driver.WindowHandles;

            Console.WriteLine("No. of windows opened = " + handles.Count);

            //Switch to Terms and Conditions Window
            foreach(string handle in handles)
            {
                driver.SwitchTo().Window(handle);
                if(driver.Title.Contains("Terms"))
                {
                    Console.WriteLine("Switched to terms and conditions window");
                    break;
                }
            }

            IWebElement header = driver.FindElement(By.XPath("//div[@class='header']/div[1]"));

            Assert.AreEqual(header.Text, "Terms and Conditions");

            driver.Close();


            //Switch to Privacy Policy Tab
            foreach (string handle in handles)
            {
                driver.SwitchTo().Window(handle);
                if (driver.Title.Contains("Welcome"))
                {
                    Console.WriteLine("Switched to Privacy Policy window"); 
                    break;
                }
            }

            IWebElement privacyheader = driver.FindElement(By.CssSelector("tr[bgcolor='#DEDEDE'] b"));
            Assert.That(privacyheader.Text, Is.EqualTo("Rediff.com India Ltd. - Privacy Policy").IgnoreCase);

            //driver.Close();

            driver.SwitchTo().Window(mainwindow);

        }


        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
