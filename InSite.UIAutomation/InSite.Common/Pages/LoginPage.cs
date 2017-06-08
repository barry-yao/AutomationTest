using InSite.Common.FrameworkComponents;
using InSite.Common.Extensions;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace InSite.Common.Pages
{
    public class LoginPage<T> : BasePage<T> where T : OpenQA.Selenium.Support.UI.LoadableComponent<T>
    {
        public override string PageTitle { get { return ""; } }

        [FindsBy(How=How.Id, Using="signin-username")]
        private IWebElement UsernameField;

        public string Username
        {
            get { return UsernameField.GetAttribute("value"); }
            set { UsernameField.SendKeys(value); }
        }

        [FindsBy(How=How.Id, Using="signin-password")]
        private IWebElement PasswordField;

        public string Password
        {
            get { return PasswordField.GetAttribute("value"); }
            set { PasswordField.SendKeys(value); }
        }

        [FindsBy(How = How.Id, Using = "signin-button")]
        private IWebElement SignInButton;

        public void SignIn()
        {
            SignInButton.Click();
        }

        public void Login(string username = "Administrator", string password = "Kodak")
        {
            Navigate();
            WaitForIndicatorElementReady();
            Username = username;
            Password = password;
            SignIn();
        }

        public LoginPage()
        {
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(DriverManager.Driver, this);
        }

        public virtual void WaitForIndicatorElementReady()
        {
            throw new NotImplementedException();
        }

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                DriverManager.Driver.WaitForElement(By.Id("signin-button"));
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }

            return true;      
        }

        protected override void ExecuteLoad()
        {
            Navigate();
        }
    }
}
