using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class Utilities
    {
        public static void TakeScreenshot(IWebDriver driver, string path)
        {
            string datetimestamp = DateTime.Now.Ticks.ToString();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(path + datetimestamp + ".png", ScreenshotImageFormat.Png);
        }

        
        [Test]
        public static void GetTodaysDay()
        {
            string today = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine(today);

            string month = today.Split(new char[] { '/' })[0];
            string day = today.Split(new char[] { '/' })[1];
            string year = today.Split(new char[] { '/' })[2];

            Console.WriteLine("Month is: " + month);
            Console.WriteLine("Day is: " + day);
            Console.WriteLine("Year is: " + year);

            string time = DateTime.Now.ToString("hh:mm:ss");
            Console.WriteLine(time);

            string hours = time.Split(new char[] { ':' })[0];
            string minutes = time.Split(new char[] { ':' })[1];
            string seconds = time.Split(new char[] { ':' })[2];

            Console.WriteLine("Hours is: " + hours);
            Console.WriteLine("Minutes is: " + minutes);
            Console.WriteLine("Seconds is: " + seconds);
        }

    }
}
