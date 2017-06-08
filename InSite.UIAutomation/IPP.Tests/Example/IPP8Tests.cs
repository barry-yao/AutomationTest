using IPP.Framework.FrameworkComponents;
using IPP.Framework.Helpers;
using IPP.Framework.Pages.InSite8;
using IPP.Framework.Pages.InSite8.Customers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPP.Tests.Example
{
    [TestClass]
    public class IPP8Tests
    {
        public LoginPage LoginPage
        {
            get { return _loginPage ?? (_loginPage = PageFactory.GetPage<LoginPage>()); }
        }
        private LoginPage _loginPage;

        public CustomersPage CustomersPage
        {
            get { return _customersPage ?? (_customersPage = PageFactory.GetPage<CustomersPage>()); }
        }
        private CustomersPage _customersPage;

        public CustomerOverviewPage CustomerOverviewPage
        {
            get { return _customerOverviewPage ?? (_customerOverviewPage = PageFactory.GetPage<CustomerOverviewPage>());}
        }
        private CustomerOverviewPage _customerOverviewPage;

        [TestInitialize]
        public void TestInitialize()
        {
            LoginPage.Login();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DriverManager.Stop();
        }

        [TestMethod]
        public void TC_IPP8_Example()
        {
            const string customer = "cust111";
            const string jobName = "1340close";

            CustomersPage.Navigate();
            CustomersPage.Table.SelectRow(customer);
            CustomerOverviewPage.Status = JobStatus.AllJobs;
            bool doesJobExist = CustomerOverviewPage.Table.DoesRowExists(jobName);

            Assert.IsTrue(doesJobExist, "Job with name " + jobName + " does not exist in Job list for customer " + customer);
        }
    }
}
