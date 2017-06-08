using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InSite.Common.Extensions;
using InSite.Common.FrameworkComponents;

namespace InSite.Common.SiteComponents
{
    public class Slider : WebUIComponent
    {
        public Slider(IWebElement webElement)
            : base(webElement)
        {

        }

        public Int64 getPosition()
        {
            return (Int64)((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript("return $(\"div#pageSizeSlider\" ).slider(\"value\");");
        }

        public Int64 getMaxPosition()
        {
            return (Int64)((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript("return $(\"div#pageSizeSlider\" ).slider(\"option\", \"max\");");
        }


        public void moveSliderToPosition(int position)
        {
            //int max = 300;

            DriverManager.Driver.FindElement(By.XPath("//div[@id='sliderThumbSize']/../div[1]")).Click();

            ((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript(string.Format("$(\"div#pageSizeSlider\" ).slider( 'value', {0} );", position));

            DriverManager.Driver.FindElement(By.XPath("//div[@id='pageSizeSlider']/span")).Click();

            DriverManager.Driver.WaitForAjax();

        }

    }
}
