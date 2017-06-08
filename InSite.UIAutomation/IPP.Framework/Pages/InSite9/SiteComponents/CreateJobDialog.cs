using InSite.Common.SiteComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPP.Framework.Pages.InSite9.SiteComponents
{
    public class CreateJobDialog : WebDialogBase
    {
        [FindsBy(How = How.Id, Using = "jobInfo")]
        private IWebElement jobInfo;

        public JobInfoPanel JobInfoContainer
        {
            get
            {
                jobInfo.Click();
                return new JobInfoPanel();
            }
        }

        public CreateJobDialog(IWebElement webElement)
            : base(webElement)
        {

        }
    }
}
