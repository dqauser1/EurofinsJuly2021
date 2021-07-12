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
    class FlipkartExample
    {
        [Test]
        public void When_Search_Flipkart_Then_ShouldSeeResults()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Navigate().GoToUrl("https://www.flipkart.com");

            IWebElement close_button = driver.FindElement(By.XPath("//button[text()='✕']"));

            Assert.IsNotNull(close_button);

            close_button.Click();

            driver.FindElement(By.Name("q")).SendKeys("iphone");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            Thread.Sleep(5000);

            ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//div[contains(@class,'row')]"));

            for(int i=0; i<25; i++)
            {
                IWebElement row = rows[i];
                string name = row.FindElement(By.XPath("./div/div")).Text;
                string price = row.FindElement(By.XPath("./div[2]/div/div/div")).Text;
                Console.WriteLine(name + " : " + price);
            }
        }
    }
}
