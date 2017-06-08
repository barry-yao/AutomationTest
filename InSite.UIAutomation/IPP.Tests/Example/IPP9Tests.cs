using IPP.Framework.FrameworkComponents;
using IPP.Framework.Helpers;
using IPP.Framework.Pages.InSite9;
using IPP.Framework.Pages.InSite9.Jobs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPP.Tests.Example
{
    [TestClass]
    public class IPP9Tests
    {
        public LoginPage LoginPage
        {
            get { return _loginPage ?? (_loginPage = PageFactory.GetPage<LoginPage>()); }
        }
        private LoginPage _loginPage;

        public JobsPage JobsPage
        {
            get { return _jobsPage ?? (_jobsPage = PageFactory.GetPage<JobsPage>()); }
        }
        private JobsPage _jobsPage;

        public JobPage JobPage
        {
            get { return _jobPage ?? (_jobPage = PageFactory.GetPage<JobPage>()); }
        }
        private JobPage _jobPage;

        [TestInitialize]
        public void TestInitialize()
        {
            LoginPage.Navigate();
            LoginPage.WaitForIndicatorElementReady();
            LoginPage.Login();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DriverManager.Stop();
        }

        [TestMethod]
        public void TC_IPP9_Example()
        {

            const string jobName = "lpv01";
            const string pageName = "Alta Vista Destinations Cook Book_70p.p19.pdf";

            JobsPage.WaitForIndicatorElementReady();
            JobsPage.Table.MarkRow(jobName);
            JobsPage.Table.SelectRow(jobName);

            JobPage.Table.MarkRow(pageName);
        }
    }
}
