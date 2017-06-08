using IPP.Framework.FrameworkComponents;
using IPP.Framework.Pages.InSite9.SiteComponents;
using IPP.Framework.Extensions.InSite9;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;
using InSite.Common.SiteComponents;

namespace IPP.Framework.Pages.InSite9.Jobs
{
    public class JobsPage : BasePage<JobsPage>
    {
        public override string PageTitle { get { return "jobs"; } }

        public LinkedWebTable Table
        {
            get { return _table ?? (_table = new LinkedWebTable("job")); }
        }
        private LinkedWebTable _table;

        [FindsBy(How = How.Id, Using = "deleteJob")]
        private IWebElement _deleteJob;

        [FindsBy(How = How.Id, Using = "createJob")]
        private IWebElement _createJob;

        [FindsBy(How = How.Id, Using = "buttonShowCustomerList")]
        private IWebElement _customerListButton;

        [FindsBy(How = How.Id, Using = "menuFilterOptions")]
        private IWebElement _customerListDropdown;

        public void DeleteJob(string jobName)
        {
            Table.MarkRow(jobName);
            //_deleteJob.Click();
            Table.BringContextMenu().SelectByText("Delete Job");
            DeleteJobDialog deleteJobDiaglog = new DeleteJobDialog(DriverManager.Driver.FindElement(By.Id("dialog")));
            deleteJobDiaglog.Confirm();

        }

        public void CreateJob(string jobName)
        {
            _createJob.Click();
            CreateJobDialog createJobDialog = new CreateJobDialog(DriverManager.Driver.FindElement(By.Id("dialog")));
            createJobDialog.JobInfoContainer.SelectCustomer("123");
            createJobDialog.JobInfoContainer.TypeJobName(jobName);
            createJobDialog.Create();
        }

        public void MoveToProduction(string jobName)
        {
            Table.MarkRow(jobName);
            Table.BringContextMenu().SelectByIndex(1);
        }

        public void SetToComplete(string jobName)
        {
            Table.MarkRow(jobName);
            Table.BringContextMenu().SelectByIndex(2);
        }

        public WebSelect CustomerList()
        {
            _customerListButton.Click();
            return new WebSelect(_customerListDropdown);

        }

        public void SelectCustomer(string customerGroup, string customer)
        {
            var subMenu = CustomerList().BringSubSelect(customerGroup);
            subMenu.SelectByText(customer);
        }


        public void WaitForIndicatorElementReady()
        {
            DriverManager.Driver.WaitForElement(By.Id("jobSearchBox"));
            DriverManager.Driver.WaitForAjax();
        }

        public JobsPage()
        {
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(DriverManager.Driver, this);
        }
    }
}
