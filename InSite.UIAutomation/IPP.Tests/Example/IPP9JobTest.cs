using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IPP.Framework.Pages.InSite9;
using IPP.Framework.Pages.InSite9.Jobs;
using OpenQA.Selenium.Support.UI;
using IPP.Framework.FrameworkComponents;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using IPP.Framework.Pages.InSite9.SiteComponents;

namespace IPP.Tests.Example
{
    [TestClass]
    public class IPP9JobsTest
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
        public void TestSetup()
        {
            LoginPage.Login("administrator", "Kodak");
            JobsPage.WaitForIndicatorElementReady();
        }

        [TestMethod]
        public void TC_CreateJob()
        {
            JobsPage.CreateJob("by_002");
        }

        [TestMethod]
        public void TC_DeleteJob()
        {

            string jobToDelete = "by_002";

            JobsPage.WaitForIndicatorElementReady();
            JobsPage.DeleteJob(jobToDelete);

            WebDriverWait wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(60));
            Assert.IsTrue(wait.Until(driver => driver.FindElements(By.XPath(string.Format("//div[@class='jobMainItemBody']//div[@class='name jobMainItemCol']/u[text()='{0}']", jobToDelete))).Count == 0));
        }

        [TestMethod]
        public void TC_SelectCustomer()
        {
            JobsPage.WaitForIndicatorElementReady();

            JobsPage.SelectCustomer("My Customers", "bycustomer");
            Assert.IsTrue(JobsPage.Table.DoesRowExists("lpv01"));

            JobsPage.CustomerList().SelectByText("Color Customers");
            Assert.IsTrue(JobsPage.Table.DoesRowExists("444"));

        }

        [TestMethod]
        public void TC_ChangePageListThumbnailSize()
        {
            string jobName = "lpv01";
            string pageName = "Alta Vista Destinations Cook Book_70p.p1.pdf";

            //JobsPage.WaitForIndicatorElementReady();
            //Thread.Sleep(3000);
            JobsPage.Table.SelectRow(jobName);

            JobPage.ThumbnailSizeSlider.moveSliderToPosition(300);
            IWebElement rowElement = JobPage.Table.MarkRow(pageName);
            PagesTableItem pageItem = new PagesTableItem(rowElement);

            Assert.AreEqual(231, pageItem.ThumbnailSize.width, "the width of page thumbnail isn't expected");
            Assert.AreEqual(300, pageItem.ThumbnailSize.height, "the height of page thumbnail isn't expected");

        }
    }
}
