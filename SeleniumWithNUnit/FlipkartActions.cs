using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNUnit
{
    class FlipkartActions
    {
        IWebDriver driver;

        [SetUp]
        public void LaunchFlipkart()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Navigate().GoToUrl("https://www.flipkart.com");

            IWebElement close_button = driver.FindElement(By.XPath("//button[text()='✕']"));

            Assert.IsNotNull(close_button);

            close_button.Click();
        }

        [Test]
        public void When_Hover_Over_Fashion_Then_Should_See_Menu()
        {
            IWebElement fashionicon = driver.FindElement(By.CssSelector("img[alt='Fashion']"));

            //Create a variable to hold all our actions that we want to perform
            Actions myactions = new Actions(driver);
            myactions.MoveToElement(fashionicon);

            //Create a variable to combine all the actions together
            IAction action = myactions.Build();

            //Perform the action
            action.Perform();

            Utilities.TakeScreenshot(driver, @"C:\Temp\FlipkartActions_Fashion_");

            IWebElement expectedelement = driver.FindElement(By.XPath("//a[text()=\"Men's Top Wear\"]"));
            Assert.IsTrue(expectedelement.Displayed);

            IWebElement electronicsicon = driver.FindElement(By.CssSelector("img[alt='Electronics']"));

            new Actions(driver).MoveToElement(electronicsicon).Build().Perform();

            Utilities.TakeScreenshot(driver, @"C:\Temp\FlipkartActions_Electronics_");

        }

        [Test]
        public void When_Shift_Click_Opens_New_Window()
        {
            IWebElement fashionicon = driver.FindElement(By.CssSelector("img[alt='Fashion']"));
            IWebElement menstopwearelement = driver.FindElement(By.XPath("//a[text()=\"Men's Top Wear\"]"));

            //Create a variable to hold all our actions that we want to perform
            Actions myactions = new Actions(driver);
            myactions.MoveToElement(fashionicon);
            //myactions.DragAndDropToOffset(AssemblyLoadEventHandler, 0, 100);
            /*myactions.KeyDown(Keys.Shift);
            myactions.Click(menstopwearelement);*/

            //Create a variable to combine all the actions together
            IAction action = myactions.Build();

            //Perform the action
            action.Perform();

            Utilities.TakeScreenshot(driver, @"C:\Temp\FlipkartActions_Fashion_");

            //Thread.Sleep(1000);

            myactions.KeyDown(Keys.Shift).Build().Perform();
            myactions.Click(menstopwearelement).Build().Perform();
        }
    }
}
