using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;

namespace InSite.Common.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClickAndWait(this IWebElement element)
        {
            element.Click();
            DriverManager.Driver.WaitForAjax();
        }
    }
}
