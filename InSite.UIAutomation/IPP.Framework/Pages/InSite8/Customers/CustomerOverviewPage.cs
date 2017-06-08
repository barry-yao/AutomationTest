using IPP.Framework.Extensions;
using IPP.Framework.Extensions.InSite8;
using IPP.Framework.FrameworkComponents;
using IPP.Framework.Interfaces;
using IPP.Framework.Pages.InSite8.SiteComponents;
using OpenQA.Selenium;

namespace IPP.Framework.Pages.InSite8.Customers
{
    public class CustomerOverviewPage : IPageObject
    {
        private IWebElement StatusField { get { return DriverManager.Driver.FindElement(By.Id("ctl00_ctl60")); } }

        public string Status
        {
            get { return StatusField.GetAttribute("value"); }
            set { StatusField.SelectDropDownOption(value); }
        }

        public WebTable Table
        {
            get { return _table ?? (_table = new WebTable("ctl00_CustomerHomeJobList.Container")); }
        }
        private WebTable _table;
    }
}
