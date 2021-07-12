using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class DragAndDropExample
    {

        [Test]
        public void Test_Drag_And_Drop()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Url = "https://jqueryui.com/slider";

            driver.SwitchTo().Frame(0);

            IWebElement slider = driver.FindElement(By.Id("slider"));

            IWebElement handle = driver.FindElement(By.CssSelector("#slider span"));

            int width = slider.Size.Width;

            Actions myactions = new Actions(driver);
            myactions.DragAndDropToOffset(handle, width/2, 0);

            IAction action = myactions.Build();
            action.Perform();

            string actual = handle.GetAttribute("style");
            string expected = "left: 50%;";

            Assert.AreEqual(actual, expected);

            Utilities.TakeScreenshot(driver, @"C:\Temp\Slider_");

        }
    }
}
