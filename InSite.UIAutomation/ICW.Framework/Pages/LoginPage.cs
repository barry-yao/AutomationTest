using InSite.Common.FrameworkComponents;
using ICW.Framework.Extensions;
using OpenQA.Selenium;

namespace ICW.Framework.Pages
{
    public class LoginPage : InSite.Common.Pages.LoginPage<LoginPage>
    {
        public override void Navigate()
        {
            DriverManager.Driver.Navigate().GoToUrl(ICWExtensions.BaseUrl + "#" + PageTitle);
        }

        public override void WaitForIndicatorElementReady()
        {
            DriverManager.Driver.WaitForElement(By.Id("projectsSearchBox"));
        }
    }
}
