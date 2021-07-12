using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumWithNUnit
{
    class GoogleSearch
    {
        public static IWebDriver driver;

        public static List<TestCaseData> TestInputs()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\ameya\Projects\EurofinsJuly2021\testdata\googletestdata.csv"));

            var testdata = new List<TestCaseData>();

            while(!reader.EndOfStream)
            {
                char separator = ',';

                var line = reader.ReadLine();

                string[] words = line.Split(separator);

                testdata.Add(new TestCaseData(words[0],words[1]));
            }

            return testdata;
        }

        [Category("DataDrivenFromCSV")]
        [TestCaseSource("TestInputs")]
        public void Google_Search_From_CSV(string search, string result)
        {
            Console.WriteLine(search + " : " + result);
        }


        
        [Category("DataDrivenGoogleTests")]
        [TestCase("selenium", "Selenium")]
        [TestCase("nunit", "Nunit")]
        [TestCase("csharp", "C#")]
        public void When_I_Search_Then_I_Receive_Results(string searchstring, string expected)
        {
            //Act
            //Enter the search string               
            IWebElement searchbox = driver.FindElement(By.Name("q"));
            //string searchstring = "selenium";
            searchbox.SendKeys(searchstring);

            //Hit the Enter key
            searchbox.SendKeys(Keys.Enter);

            //Assert
            //Verify that the title contains searchstring
            //Assert.Contains(actualtitle, "selenium");
            Assert.That(driver.Title, Does.Contain(searchstring));

            //First link on results page should contain searchstring
            IWebElement firstlink = driver.FindElement(By.TagName("h3"));
            Assert.That(firstlink.Text, Does.Contain(expected));
            //Assert.Pass(firstlink.Text, searchstring, StringComparison.OrdinalIgnoreCase);
        }

        [SetUp]
        public void Setup()
        {
            //Arrange
            //Open a Browser
            //Navigate to the URL
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [TearDown]
        public void CloseBrower()
        {
            driver.Quit();
        }

    }
}
