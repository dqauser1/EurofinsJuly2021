using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace SeleniumWithNUnit
{
    class FlipkartSuggestions
    {
        [Test]
        public void When_Search_Flipkart_Then_ShouldSeeSugestions()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.flipkart.com");

            IWebElement close_button = driver.FindElement(By.XPath("//button[text()='✕']"));

            Assert.IsNotNull(close_button);

            close_button.Click();

            driver.FindElement(By.Name("q")).SendKeys("samsung");

            //Capture the Suggestions
            IReadOnlyList<IWebElement> suggestions = driver.FindElements(By.CssSelector("form li"));

            //Thread.Sleep(500);
            //Explicit Wait
            WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("form li"),"samsung"));

            foreach(IWebElement suggestion in suggestions)
            {
                Console.WriteLine(suggestion.Text);
            }
        }
    }
}
