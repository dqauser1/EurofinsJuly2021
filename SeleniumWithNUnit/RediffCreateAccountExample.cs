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
    class RediffCreateAccountExample
    {
        public static IWebDriver driver;
        [Test]
        public void When_CreateAccount_WithValidData_Then_Successful()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");

            driver.Navigate().GoToUrl("https://register.rediff.com/register/register.php");

            driver.FindElement(By.XPath("//table//input[starts-with(@name,'name')]")).SendKeys("Ameya");

            //Select Values in the Date of Birth Dropdown using XPath
            /*driver.FindElement(By.XPath("//option[text()='07']")).Click();
            driver.FindElement(By.XPath("//option[text()='SEP']")).Click();
            driver.FindElement(By.XPath("//option[text()='1994']")).Click();*/

            //Select Dropdown values using Selenium's Select API
            SelectElement day = new SelectElement(driver.FindElement(By.XPath("//select[starts-with(@name,'DOB_Day')]")));
            day.SelectByText("07");

            SelectElement month = new SelectElement(driver.FindElement(By.XPath("//select[starts-with(@name,'DOB_Month')]")));
            month.SelectByText("SEP");

            SelectElement year = new SelectElement(driver.FindElement(By.XPath("//select[starts-with(@name,'DOB_Year')]")));
            year.SelectByText("1994");

            IWebElement actual_year = year.SelectedOption;
            Assert.AreEqual(actual_year.Text, "1994");
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
