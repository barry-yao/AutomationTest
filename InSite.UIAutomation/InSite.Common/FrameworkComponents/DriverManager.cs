using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InSite.Common.FrameworkComponents
{
    public class DriverManager
    {
        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    KillChromes();
                    var co = new ChromeOptions();
                    co.AddArguments("--start-maximized", "--disable-extensions");
                    _driver = new ChromeDriver(@"C:\ChromeDriver", co);
                }
                return _driver;
            }
        }
        private static IWebDriver _driver;

        public static void Start()
        {
            
        }

        public static void Stop()
        {
            Driver.Quit();
            _driver = null;
        }

        private static void KillChromes()
        {
            var victims = from p in Process.GetProcesses()
                          where p.ProcessName.Contains("chrome")
                          select p;

            foreach (var victim in victims)
            {
                victim.Kill();
            }

        }
    }
}
