using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;

namespace IPP.Framework.Extensions.InSite8
{
    public static class WebElementExtensions
    {
        public static void ClickAndWait(this IWebElement element)
        {
            element.Click();
            DriverManager.Driver.WaitForActionToComplete();
        }

        public static void ClearAndSendKeys(this IWebElement element, string keys)
        {
            element.Clear();
            element.SendKeys(keys);
        }

        public static void ClearSendKeysAndWait(this IWebElement element, string keys)
        {
            element.ClearAndSendKeys(keys);
            DriverManager.Driver.WaitForActionToComplete();
        }

        public static void SendKeysAndWait(this IWebElement element, string keys)
        {
            element.SendKeys(keys);
            DriverManager.Driver.WaitForActionToComplete();
        }

        public static void SelectDropDownOption(this IWebElement select, string optionText)
        {
            var options = select.FindElements(By.XPath("./option"));
            bool found = false;

            foreach (var option in options)
            {
                var text = option.Text;
                if (text.Equals(optionText))
                {
                    found = true;
                    option.ClickAndWait();
                }
            }
            
            if (!found)
                throw new NoSuchElementException("No such option in drop down: " + optionText);
        }
    }
}
