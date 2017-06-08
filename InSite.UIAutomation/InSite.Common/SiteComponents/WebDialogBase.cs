using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSite.Common.SiteComponents
{
    public class WebDialogBase : WebUIComponent
    {
        [FindsBy(How = How.Id, Using = "confirm")]
        private IWebElement _confirm;

        [FindsBy(How = How.Id, Using = "cancel")]
        private IWebElement _cancel;

        [FindsBy(How = How.Id, Using = "save")]
        private IWebElement _save;

        [FindsBy(How = How.Id, Using = "create")]
        private IWebElement _create;

        [FindsBy(How = How.Id, Using = "dialogHeader")]
        private IWebElement _dialogHeader;

        public void Confirm()
        {
            _confirm.Click();
        }

        public void Cancel()
        {
            _cancel.Click();
        }

        public void Save()
        {
            _save.Click();
        }

        public void Create()
        {
            _create.Click();
        }

        public string DialogHeader
        {
            get
            {
                return _dialogHeader.FindElement(By.TagName("div")).Text;
            }
        }

        public WebDialogBase(IWebElement webElement)
            : base(webElement)
        {

        }
    }
}
