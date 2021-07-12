using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumWithNUnit
{
    class GoogleSuggestions
    {
        public static IWebDriver driver;

        [Test, Category("GoogleTests")]
        public void When_I_Search_Then_I_Receive_Suggestions()
        {
            //Act
            //Enter the search string               
            IWebElement searchbox = driver.FindElement(By.Name("q"));
            string searchstring = "selenium";
            searchbox.SendKeys(searchstring);

            IWebElement firstsuggestion = driver.FindElement(By.XPath("//form//ul//li"));

            //Explicit Wait
            OpenQA.Selenium.Support.UI.WebDriverWait mywait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //mywait.Until(ExpectedConditions.TextToBePresentInElement(firstsuggestion,searchstring));

            //Custom Expected Condition
            Func<IWebDriver, bool> mycustomcondition = new Func<IWebDriver, bool>(
                (IWebDriver browser) =>
                {
                    Console.WriteLine("Inside Custom Condition");
                    bool result = true;
                    List<IWebElement> suggestions = browser.FindElements(By.XPath("//form//ul//li")).ToList<IWebElement>();
                    
                    if(suggestions.Count < 10)
                    {
                        result = false;
                    }

                    return result;
                }           
                );

            mywait.PollingInterval = TimeSpan.FromMilliseconds(200);
            mywait.Until(mycustomcondition);

            List<IWebElement> suggestions = driver.FindElements(By.XPath("//form//ul//li")).ToList<IWebElement>();

            Console.WriteLine(suggestions.Count);

            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("suggestion = "+ suggestion.Text);
            }

            Utilities.TakeScreenshot(driver, "C:\\Temp\\googlesuggestionsscreenshot");
        }

        public void TakeScreenshot(string path)
        {
            string datetimestamp = DateTime.Now.Ticks.ToString();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(path+datetimestamp+".png", ScreenshotImageFormat.Png);
        }

        [SetUp]
        public void Setup()
        {
            //Arrange
            //Open a Browser
            //Navigate to the URL
            driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void CloseBrower()
        {
            driver.Quit();
        }

    }
}
