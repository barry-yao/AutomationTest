using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSite.Common.SiteComponents
{
    public class SectionBase : WebUIComponent
    {
        public void Collapse()
        {
            WrappedWebElement.FindElement(By.XPath("//*[@class=\"sectionTitle\"]")).Click();

        }

        public void Expand()
        {
            WrappedWebElement.FindElement(By.XPath("//*[@class=\"sectionTitle\"]")).Click();
        }

        public SectionBase(IWebElement webElement)
            : base(webElement)
        {

        }
    }
}
