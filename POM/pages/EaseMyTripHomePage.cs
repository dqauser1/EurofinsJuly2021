using System;
using POM.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace POM.tests
{
    internal class EaseMyTripHomePage : BasePOM
    {
        //Object Repository
        static IWebElement departcity, arrivalcity, departdate, searchbutton, day;

        public static void InitializeElements()
        {
            departcity = driver.FindElement(By.Id("FromSector_show"));
            arrivalcity = driver.FindElement(By.Id("Editbox13_show"));
            departdate = driver.FindElement(By.Id("ddate"));
            searchbutton = driver.FindElement(By.ClassName("src_btn"));
            
        }

        public EaseMyTripHomePage()
        {
            driver.Navigate().GoToUrl("https://easemytrip.com/");
            InitializeElements();
        }

        internal void SetDepartureCity(string v)
        {
            departcity.Click();
            departcity.SendKeys(v);
            
        }
        
        internal void SetArrivalCity(string v)
        {
            arrivalcity.Click();
            arrivalcity.SendKeys(v);
        }

        internal void SetDepartDate(string v)
        {
            Thread.Sleep(2000);
            departdate.Click();
            day = driver.FindElement(By.XPath("//li[text()='10']"));
            day.Click();
        }

        internal void Search()
        {
            searchbutton.Click();
        }
    }
}