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
    class RediffCheckbox_Radio_Example
    {
        public static IWebDriver driver;
        [Test]
        public void When_CheckBoxClicked_AlEmail_Disappears()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Navigate().GoToUrl("https://register.rediff.com/register/register.php");

            IWebElement altemail = driver.FindElement(By.XPath("//*[starts-with(@name,'altemail')]"));

            IWebElement checkbox = driver.FindElement(By.XPath("//*[@type='checkbox']"));

            if(!checkbox.Selected)
            {
                checkbox.Click();
                //Assert.IsTrue(!altemail.Displayed);
            }

            Assert.IsTrue(checkbox.Selected);
            Assert.IsFalse(altemail.Displayed);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
