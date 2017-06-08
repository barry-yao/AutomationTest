using InSite.Common.FrameworkComponents;
using InSite.Common.Interfaces;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;


namespace InSite.Common.Pages
{
    public abstract class BasePage<T> : LoadableComponent<T>, INavigatablePage where T : OpenQA.Selenium.Support.UI.LoadableComponent<T>
    {
        public virtual string PageTitle { get { throw new NotImplementedException(); } }

        public virtual void Navigate()
        {
            throw new NotImplementedException();
        }
    }
}
