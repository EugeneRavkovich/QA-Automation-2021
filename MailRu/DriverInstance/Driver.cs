using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailRu.DriverInstance
{
    /// <summary>
    /// Class that defines a Selenium driver object
    /// </summary>
    public class Driver
    {
        private static IWebDriver _driver;


        /// <summary>
        /// Constructor w\o parameters
        /// </summary>
        private Driver() { }


        /// <summary>
        /// Method for getting the driver instance
        /// </summary>
        /// <returns>New driver instance if called for the first time,
        /// otherwise the current state of the existing driver</returns>
        public static IWebDriver GetInstance()
        {
            if (_driver is null)
            {
                _driver = new ChromeDriver();
                //_driver.Manage().Window.Maximize();
            }
            return _driver;
        }


        /// <summary>
        /// Method for stopping the driver
        /// </summary>
        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}