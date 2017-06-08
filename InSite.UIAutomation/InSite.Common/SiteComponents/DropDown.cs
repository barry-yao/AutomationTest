using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InSite.Common.SiteComponents
{
    class DropDown : WebUIComponent
    {
        public DropDown(IWebElement webElement, WebSelect select)
            : base(webElement)
        {

        }

        public WebSelect Click()
        {
            WrappedWebElement.Click();

            //Todo
            return new WebSelect(null);

        }

    }
}
