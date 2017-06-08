using IPP.Framework.FrameworkComponents;
using IPP.Framework.Extensions.InSite9;
using IPP.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace IPP.Framework.Pages.InSite9
{
    public class BasePage<T> : InSite.Common.Pages.BasePage<T>, INavigatablePage where T : OpenQA.Selenium.Support.UI.LoadableComponent<T>
    {
        public override void Navigate()
        {
            DriverManager.Driver.Navigate().GoToUrl(IPPExtensions.BaseUrl + "#" + PageTitle);
        }

        protected override bool EvaluateLoadedStatus()
        {
            throw new NotImplementedException();
        }

        protected override void ExecuteLoad()
        {
            throw new NotImplementedException();
        }
    }
}
