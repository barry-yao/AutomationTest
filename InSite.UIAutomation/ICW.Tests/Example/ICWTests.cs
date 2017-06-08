using ICW.Framework.FrameworkComponents;
using ICW.Framework.Pages;
using ICW.Framework.Pages.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPP.Tests.Example
{
    [TestClass]
    public class ICWTests
    {
        public LoginPage LoginPage
        {
            get { return _loginPage ?? (_loginPage = PageFactory.GetPage<LoginPage>()); }
        }
        private LoginPage _loginPage;

        public ProjectsPage ProjectsPage
        {
            get { return _projectsPage ?? (_projectsPage = PageFactory.GetPage<ProjectsPage>()); }
        }
        private ProjectsPage _projectsPage;

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
        public void TC_ICW_Example()
        {
            const string projectName = "ice_p1";

            ProjectsPage.Table.MarkRow(projectName);
            ProjectsPage.Table.SelectRow(projectName);
        }
    }
}
