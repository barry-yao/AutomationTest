using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace IPP.Framework.Extensions.InSite8
{
    public static class WebDriverExtensions
    {
        public static void WaitForElement(this IWebDriver driver, By by, int secondsToWait = 60)
        {
            InSite.Common.Extensions.WebDriverExtensions.WaitForElement(driver, by, secondsToWait);
        }

        public static void WaitForActionToComplete(this IWebDriver driver, int secondsToWait = 60)
        {
            var timeout = new TimeSpan(0, 0, secondsToWait);
            var sw = new Stopwatch();
            bool done = false;

            sw.Start();
            while (!done && sw.ElapsedMilliseconds < timeout.TotalMilliseconds)
            {
                var elements = driver.FindElements(By.Id("LoadingIndicatorPanel"));
                
                if (!elements.Any()) // Loading indicator is not part of this page
                    return;

                var isDisplayed = elements.First().Displayed;
                if (isDisplayed)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    done = true;
                }
            }
            if (!done)
            {
                throw new TimeoutException("Action did not complete within " + secondsToWait + " seconds");
            }
        }
    }
}
