using OpenQA.Selenium;

namespace ICW.Framework.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClickAndWait(this IWebElement element)
        {
            InSite.Common.Extensions.WebElementExtensions.ClickAndWait(element);
        }
    }
}
