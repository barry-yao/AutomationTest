using OpenQA.Selenium;

namespace IPP.Framework.Extensions.InSite9
{
    public static class WebElementExtensions
    {
        public static void ClickAndWait(this IWebElement element)
        {
            InSite.Common.Extensions.WebElementExtensions.ClickAndWait(element);
        }
    }
}
