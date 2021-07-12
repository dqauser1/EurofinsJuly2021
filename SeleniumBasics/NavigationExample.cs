using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasics
{
    class NavigationExample
    {
       public static void Main(String[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Tools\\Selenium\\chromedriver_90");

            driver.Url = "https://www.google.com";

            String actualTitle = driver.Title;

            String actualUrl = driver.Url;

            Console.WriteLine("Navigated to: " + actualTitle + " : " + actualUrl);

            if(actualTitle.Equals("Google"))
            {
                Console.WriteLine("Test 1 Passed: Successfully Navigated to google.com");
            }

            driver.Navigate().GoToUrl("https://www.amazon.com");

            Console.WriteLine("Navigated to:" + driver.Title + " : " + driver.Url);

            driver.Navigate().GoToUrl("https://www.flipkart.com");

            Console.WriteLine("Navigated to:" + driver.Title + " : " + driver.Url);

            driver.Navigate().Back();

            Console.WriteLine("Back To:" + driver.Title + " : " + driver.Url);

            driver.Navigate().Forward();

            Console.WriteLine("Forward to:" + driver.Title + " : " + driver.Url);

            driver.Navigate().Back();

            Console.WriteLine("Back to:" + driver.Title + " : " + driver.Url);

            driver.Navigate().Refresh();

            Console.WriteLine("Refreshed:" + driver.Title + " : " + driver.Url);

            driver.Navigate().Back();

            Console.WriteLine("Back to:" + driver.Title + " : " + driver.Url);

            driver.Quit();
        }
    }
}
