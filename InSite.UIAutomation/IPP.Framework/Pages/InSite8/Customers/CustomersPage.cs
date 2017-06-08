using IPP.Framework.Extensions.InSite8;
using IPP.Framework.FrameworkComponents;
using IPP.Framework.Interfaces;
using IPP.Framework.Pages.InSite8.SiteComponents;
using OpenQA.Selenium;

namespace IPP.Framework.Pages.InSite8.Customers
{
    public class CustomersPage : IPageObject
    {
        private IWebElement ViewField { get { return DriverManager.Driver.FindElement(By.Id("ctl00_CustomerFilter_dropdown")); } }

        public string View
        {
            get { return ViewField.GetAttribute("value"); }
            set { ViewField.SelectDropDownOption(value); }
        }

        public WebTable Table
        {
            get { return _table ?? (_table = new WebTable("ctl00_CustomerList.Container")); }
        }
        private WebTable _table;

        public string Url { get { return InSiteExtensions.BaseUrl + "Customer/CustomerList.aspx"; } }
        
        public void Navigate()
        {
            DriverManager.Driver.Navigate().GoToUrl(Url);
            DriverManager.Driver.WaitForActionToComplete();
        }
    }
}
