using IPP.Framework.Extensions.InSite8;
using IPP.Framework.FrameworkComponents;
using IPP.Framework.Interfaces;
using OpenQA.Selenium;

namespace IPP.Framework.Pages.InSite8
{
    public class LoginPage : IPageObject
    {
        public string Url { get { return InSiteExtensions.BaseUrl + "login.aspx"; } }

        private IWebElement UsernameField { get { return DriverManager.Driver.FindElement(By.Id("ctl00_Username")); } }

        public string Username
        {
            get { return UsernameField.GetAttribute("value"); }
            set { UsernameField.ClearAndSendKeys(value); }
        }

        private IWebElement PasswordField { get { return DriverManager.Driver.FindElement(By.Id("ctl00_Password")); } }

        public string Password
        {
            set { PasswordField.ClearAndSendKeys(value); }
        }

        private IWebElement LoginButton { get { return DriverManager.Driver.FindElement(By.Id("ctl00_LoginButton")); } }

        public void Navigate()
        {
            DriverManager.Driver.Navigate().GoToUrl(Url);
        }

        public void Login(string username = "Administrator", string password = "Kodak")
        {
            Navigate();
            DriverManager.Driver.WaitForElement(By.Id("ctl00_Username"));
            Username = username;
            Password = password;
            LoginButton.Click();
        }
    }
}
