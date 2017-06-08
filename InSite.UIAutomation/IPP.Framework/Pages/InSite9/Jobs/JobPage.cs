using InSite.Common.FrameworkComponents;
using InSite.Common.SiteComponents;
using IPP.Framework.Interfaces;
using IPP.Framework.Pages.InSite9.SiteComponents;
using OpenQA.Selenium;

namespace IPP.Framework.Pages.InSite9.Jobs
{
    public class JobPage : IPageObject
    {
        public WebTable Table
        {
            get { return _table ?? (_table = new WebTable("page")); }
        }
        private WebTable _table;

        public Slider ThumbnailSizeSlider
        {
            get
            {
                return new Slider(DriverManager.Driver.FindElement(By.Id("sliderThumbSize")));
            }
            set
            {

            }
        }

    }
}
