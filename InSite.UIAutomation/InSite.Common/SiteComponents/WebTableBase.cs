using System.Collections.Generic;
using System.Collections.ObjectModel;
using InSite.Common.Extensions;
using InSite.Common.FrameworkComponents;
using OpenQA.Selenium;

namespace InSite.Common.SiteComponents
{
    public class WebTableBase
    {
        internal string TableMainItemPrefix { get; set; }

        internal string TableContainerId { get { return TableMainItemPrefix + "MainItemCollection"; } }

        internal IWebElement TableElement { get { return DriverManager.Driver.FindElement(By.XPath(string.Format("//div[@id = '{0}']", TableContainerId))); } }

        public WebTableBase(string tableMainItemPrefix)
        {
            TableMainItemPrefix = tableMainItemPrefix;
        }

        internal IEnumerable<IWebElement> HeaderElements
        {
            get { return TableElement.FindElements(By.XPath(string.Format(".//div[@class = '{0}MainItemTitle']/div", TableMainItemPrefix))); }
        }

        public List<string> Headers
        {
            get
            {
                var columnNames = new List<string>();

                foreach (var headerElement in HeaderElements)
                {
                    var columnName = headerElement.Text;
                    columnNames.Add(columnName);
                }

                return columnNames;
            }
        }

        protected IEnumerable<IWebElement> RowsElements
        {
            get { return TableElement.FindElements(By.XPath(string.Format(".//div[@class = '{0}MainItemBody']/div", TableMainItemPrefix))); }
        }

        public virtual string GetRowName(IWebElement row)
        {
            return row.FindElement(By.XPath(string.Format(".//div[@class = 'name {0}MainItemRow']", TableMainItemPrefix))).Text;
        }

        public IWebElement MarkRow(string rowName)
        {
            //var found = false;
            IWebElement rowFound = null;
            foreach (var rowElement in RowsElements)
            {
                JavaScriptExecuter.ScrollToElement(rowElement);
                if (!GetRowName(rowElement).Equals(rowName))
                    continue;

                //found = true;
                rowFound = rowElement;
                rowElement.ClickAndWait();
                DriverManager.Driver.WaitForAjax();
                break;
            }

            if (rowFound == null)
                throw new NoSuchElementException("Row with name " + rowName + " does not exist in the table");
            return rowFound;
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
