using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleMail.DriverInstance
{
    public class Driver
    {
        private static IWebDriver _driver;

        private Driver() { }

        public static IWebDriver GetInstance()
        {
            if (_driver is null)
            {
                _driver = new ChromeDriver();
                //_driver.Manage().Window.Maximize();
            }
            return _driver;
        }


        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
