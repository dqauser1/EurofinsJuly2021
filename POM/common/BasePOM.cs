using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace POM.common
{
    class BasePOM
    {
        public static IWebDriver driver;

        public BasePOM()
        {
            LaunchBrowser("Chrome");
        }

        public void LaunchBrowser(string browsername)
        {
            if (browsername.Contains("Chrome")) {
                driver = new ChromeDriver(@"C:\Tools\Selenium\chromedriver_90");
            }
        }
    }
}
