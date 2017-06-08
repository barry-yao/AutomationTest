using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSite.Common.SiteComponents
{
    public class WebUIComponent
    {
        protected IWebElement WrappedWebElement { set; get; }

        public WebUIComponent(IWebElement webElement)
        {
            WrappedWebElement = webElement;

            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(WrappedWebElement, this);
        }

        public WebUIComponent()
        {
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(DriverManager.Driver, this);
        }

    }
}
