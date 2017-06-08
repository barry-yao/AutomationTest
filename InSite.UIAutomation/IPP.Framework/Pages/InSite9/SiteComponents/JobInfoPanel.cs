using InSite.Common.SiteComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPP.Framework.Pages.InSite9.SiteComponents
{
    public class JobInfoPanel : WebUIComponent
    {
        [FindsBy(How = How.Id, Using = "jobName")]
        private IWebElement _jobNameField;

        [FindsBy(How = How.ClassName, Using = "iconArrowDownHollow")]
        private IWebElement _iconArrowDown;

        [FindsBy(How = How.Id, Using = "menuSelectOptions")]
        private IWebElement _customerListDropdown;

        public void TypeJobName(string jobName)
        {
            _jobNameField.Clear();
            _jobNameField.SendKeys(jobName);
        }

        public void SelectCustomer(string customerName)
        {
            _iconArrowDown.Click();
            //ToDo
            Thread.Sleep(3000);
            WebSelect customerList = new WebSelect(_customerListDropdown);
            customerList.SelectByText(customerName);


        }


    }
}
