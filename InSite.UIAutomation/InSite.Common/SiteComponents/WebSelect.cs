using InSite.Common.FrameworkComponents;
using InSite.Common.SiteComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InSite.Common.Extensions;
using InSite.Common.FrameworkComponents;

namespace InSite.Common.SiteComponents
{
    public class WebSelect : WebUIComponent
    {
        public void SelectByIndex(int index)
        {
            WrappedWebElement.FindElement(By.XPath(string.Format("//li[not(@class)][{0}]", index))).Click();
            DriverManager.Driver.WaitForAjax();
        }

        public void SelectByText(string text)
        {
            WrappedWebElement.FindElement(By.XPath(string.Format("//li[a='{0}']", text))).Click();
            DriverManager.Driver.WaitForAjax();
        }

        public WebSelect BringSubSelect(string text)
        {
            IWebElement menuItem = WrappedWebElement.FindElement(By.XPath(string.Format("//li[a='{0}']", text)));
            Actions action = new Actions(DriverManager.Driver);
            action.MoveToElement(menuItem).Build().Perform();

            DriverManager.Driver.WaitForAjax();

            return new WebSelect(DriverManager.Driver.FindElement(By.Id("menuSecondLevelOptions")));
        }

        public WebSelect(IWebElement webElement)
            : base(webElement)
        {

        }
    }
}
