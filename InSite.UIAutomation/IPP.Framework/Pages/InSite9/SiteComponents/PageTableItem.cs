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
    public class PagesTableItem : WebUIComponent
    {
        [FindsBy(How = How.XPath, Using = "./div/span")]
        private IWebElement preflightIcon;

        [FindsBy(How = How.ClassName, Using = "itemThumbnail")]
        private IWebElement thumbnail;

        [FindsBy(How = How.CssSelector, Using = ".name.pageMainItemRow")]
        private IWebElement pageName;

        [FindsBy(How = How.CssSelector, Using = ".approval.pageMainItemRow")]
        private IWebElement approval;

        [FindsBy(How = How.CssSelector, Using = ".review.pageMainItemRow")]
        private IWebElement review;

        [FindsBy(How = How.CssSelector, Using = ".colorReview.pageMainItemRow")]
        private IWebElement colorReview;

        public string PreflightIcon
        {
            get { return preflightIcon.GetAttribute("class"); }
        }

        public Size ThumbnailSize
        {
            get
            {
                return new Size(int.Parse(thumbnail.GetCssValue("max-width").TrimEnd(new char[] { 'p', 'x' })), int.Parse(thumbnail.GetCssValue("max-height").TrimEnd(new char[] { 'p', 'x' })));
            }
        }

        public string PageName
        {
            get { return pageName.Text; }
        }

        public string Approval
        {
            get { return approval.Text; }
        }

        public string Review
        {
            get { return review.Text; }
        }

        public string ColorReview
        {
            get { return colorReview.Text; }
        }

        public PagesTableItem(IWebElement element)
            : base(element)
        {


        }

        public struct Size
        {
            public int width, height;
            public Size(int _width, int _height)
            {
                width = _width;
                height = _height;
            }
        }

    }
}
