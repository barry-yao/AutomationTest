using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;

namespace InSite.Common.Extensions
{
    public static class JavaScriptExecuter
    {
        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static bool IsJQueryComplete()
        {
            return (bool)((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript("return jQuery.active == 0");
        }
    }
}
