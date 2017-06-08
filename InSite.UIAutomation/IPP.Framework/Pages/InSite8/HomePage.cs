using IPP.Framework.Extensions.InSite8;
using IPP.Framework.FrameworkComponents;
using IPP.Framework.Interfaces;

namespace IPP.Framework.Pages.InSite8
{
    public class HomePage
    {
        public string Url { get { return InSiteExtensions.BaseUrl + "StaffHome.aspx"; } }

        public void Navigate()
        {
            DriverManager.Driver.Navigate().GoToUrl(Url);
        }
    }
}
