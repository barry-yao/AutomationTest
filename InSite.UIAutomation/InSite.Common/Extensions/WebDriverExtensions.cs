using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using InSite.Common.FrameworkComponents;

namespace InSite.Common.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForElement(this IWebDriver driver, By by, int secondsToWait = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));

            wait.Until(ExpectedConditions.ElementExists(by));

            //var timeout = new TimeSpan(0, 0, secondsToWait);
            //var sw = new Stopwatch();
            //bool found = false;

            //sw.Start();
            //while (!found && sw.ElapsedMilliseconds < timeout.TotalMilliseconds)
            //{
            //    var elements = driver.FindElements(by);
            //    if (elements.Any())
            //    {
            //        found = true;
            //    }
            //    else
            //    {
            //        Thread.Sleep(500);
            //    }
            //}
            //if (!found)
            //{
            //    throw new NoSuchElementException("Could not locate element: " + by.ToString());
            //}
        }

        public static void WaitForAjax(this IWebDriver driver, int secondsToWait = 60)
        {
       

            var timeout = new TimeSpan(0, 0, secondsToWait);
            var sw = new Stopwatch();
            bool done = false;

            sw.Start();
            while (!done && sw.ElapsedMilliseconds < timeout.TotalMilliseconds)
            {
                done = JavaScriptExecuter.IsJQueryComplete();

                if (!done)
                {
                    Thread.Sleep(500);
                }
            }
            if (!done)
            {
                throw new TimeoutException("WaitForAjax did not complete within " + secondsToWait + " seconds");
            }
        }
    }
}
