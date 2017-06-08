using System.Collections.Generic;
using System.Collections.ObjectModel;
using IPP.Framework.Extensions;
using IPP.Framework.Extensions.InSite8;
using IPP.Framework.FrameworkComponents;
using OpenQA.Selenium;

namespace IPP.Framework.Pages.InSite8.SiteComponents
{
    public class WebTable
    {
        private string TableContainerId { get; set; }

        private IWebElement TableElement { get { return DriverManager.Driver.FindElement(By.XPath(string.Format("//div[@id = '{0}']/table", TableContainerId))); } }

        public WebTable(string containerId)
        {
            TableContainerId = containerId;
        }

        private IEnumerable<IWebElement> HeaderElements
        {
            get { return TableElement.FindElements(By.XPath(".//td[@class = 'CSWStyle_SelectableListHeader']")); }
        }

        public List<string> Headers
        {
            get
            {
                var columnNames = new List<string>();

                foreach (var headerElement in HeaderElements)
                {
                    var columnNameElement = headerElement.FindElement(By.XPath(".//span[contains(@class, 'CSWStyle_TableHeader_Text')]"));
                    var columnName = columnNameElement.Text;
                    columnNames.Add(columnName);
                }

                return columnNames;
            }
        }

        private IEnumerable<IWebElement> RowsElements
        {
            get { return TableElement.FindElements(By.XPath(".//tr[contains(@id, 'ctl00_AWEC_SelectableListEntryRow')]")); }
        }

        private string GetRowName(IWebElement row)
        {
            return row.FindElement(By.TagName("a")).Text;
        }

        public void SelectRow(string rowName)
        {
            bool found = false;

            foreach (var rowElement in RowsElements)
            {
                JavaScriptExecuter.ScrollToElement(rowElement);
                // assuming the link to press is the first 'a' element
                var a = rowElement.FindElement(By.TagName("a")); // will find the first 'a'
                if (!GetRowName(rowElement).Equals(rowName))
                    continue;

                found = true;
                a.Click();
                break;
            }

            if (!found)
                throw new NoSuchElementException("Row with name " + rowName + " does not exist in the table");

            DriverManager.Driver.WaitForActionToComplete();
        }

        public bool DoesRowExists(string rowName)
        {
            var found = false;

            foreach (var rowElement in RowsElements)
            {
                JavaScriptExecuter.ScrollToElement(rowElement);
                if (!GetRowName(rowElement).Equals(rowName))
                    continue;

                found = true;
                break;
            }

            return found;
        }
    }
}
