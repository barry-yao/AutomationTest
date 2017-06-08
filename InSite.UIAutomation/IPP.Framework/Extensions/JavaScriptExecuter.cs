using OpenQA.Selenium;

namespace IPP.Framework.Extensions
{
    public static class JavaScriptExecuter
    {
        internal static void ScrollToElement(IWebElement element)
        {
            InSite.Common.Extensions.JavaScriptExecuter.ScrollToElement(element);
        }

        internal static bool IsJQueryComplete()
        {
            return InSite.Common.Extensions.JavaScriptExecuter.IsJQueryComplete();
        }
    }
}
