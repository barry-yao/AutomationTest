using System.Collections.Generic;
using System.Collections.ObjectModel;
using InSite.Common.Extensions;
using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace InSite.Common.SiteComponents
{
    public class LinkedWebTableBase : WebTableBase
    {
        protected virtual string _linkTag { get { return "u"; } }

        public LinkedWebTableBase(string tableMainItemPrefix)
            : base(tableMainItemPrefix)
        {
        }

        public override string GetRowName(IWebElement row)
        {
            return row.FindElement(By.TagName(_linkTag)).Text;
        }

        public void SelectRow(string rowName)
        {
            bool found = false;

            foreach (var rowElement in RowsElements)
            {
                JavaScriptExecuter.ScrollToElement(rowElement);
                // assuming the link to press is the first '_tagName' element
                var link = rowElement.FindElement(By.TagName(_linkTag)); // will find the first '_tagName'
                if (!GetRowName(rowElement).Equals(rowName))
                    continue;

                found = true;
                link.ClickAndWait();
                break;
            }

            if (!found)
                throw new NoSuchElementException("Row with name " + rowName + " does not exist in the table");

            DriverManager.Driver.WaitForAjax();
        }

        public WebSelect BringContextMenu()
        {
            Actions builder = new Actions(DriverManager.Driver);
            builder.ContextClick().Build().Perform();
            return new WebSelect(DriverManager.Driver.FindElement(By.Id("menuJobActions")));
        }
    }
}
