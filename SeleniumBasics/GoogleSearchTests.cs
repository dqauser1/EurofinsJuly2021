/*using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasics
{
    class GoogleSearchTests
    {
        public static IWebDriver driver;

        [Test]
        [Category("C1")]
        [Property("TestTime","Long")]
        [Property("Priority", "2")]
        [Property("Owner", "Ameya")]
        public void TestGoogleSearch()
        {
            Console.WriteLine("Inside Test Google Search");

            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("selenium");
            //driver.FindElement(By.Name("q")).Submit();

            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);

            string actualtitle = driver.Title;

            Assert.That(actualtitle, Is.EqualTo("selenium - Google Search"));

            Assert.That(actualtitle, Contains.Substring("Selenium"));

            Assert.That(actualtitle, Does.Contain("google").And.Contain("selenium"));

        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }

    //public class c1 : CategoryAttribute { }
}
*/