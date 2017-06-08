using IPP.Framework.FrameworkComponents;
using IPP.Framework.Extensions.InSite9;
using OpenQA.Selenium;

namespace IPP.Framework.Pages.InSite9
{
    public class LoginPage : InSite.Common.Pages.LoginPage<LoginPage>
    {
        public override void Navigate()
        {
            DriverManager.Driver.Navigate().GoToUrl(IPPExtensions.BaseUrl + "#" + PageTitle);
        }

        public override void WaitForIndicatorElementReady()
        {
            //DriverManager.Driver.WaitForElement(By.Id("jobsSearchBox"));
            DriverManager.Driver.WaitForElement(By.Id("signin-button"));
        }
    }
}
