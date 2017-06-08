using ICW.Framework.FrameworkComponents;
using ICW.Framework.Extensions;
using ICW.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace ICW.Framework.Pages
{
    public abstract class BasePage<T> : InSite.Common.Pages.BasePage<T>, INavigatablePage where T : OpenQA.Selenium.Support.UI.LoadableComponent<T>
    {
        public override void Navigate()
        {
            DriverManager.Driver.Navigate().GoToUrl(ICWExtensions.BaseUrl + "#" + PageTitle);
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
