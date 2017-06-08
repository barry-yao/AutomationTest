using OpenQA.Selenium;

namespace ICW.Framework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForElement(this IWebDriver driver, By by, int secondsToWait = 60)
        {
            InSite.Common.Extensions.WebDriverExtensions.WaitForElement(driver, by, secondsToWait);
        }

        public static void WaitForAjax(this IWebDriver driver, int secondsToWait = 60)
        {
            InSite.Common.Extensions.WebDriverExtensions.WaitForAjax(driver, secondsToWait);
        }
    }
}
