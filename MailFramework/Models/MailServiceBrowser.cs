using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using NLog;
using System.Collections.Generic;

namespace MailFramework.Models
{
    /// <summary>
    /// A class that defines Selenium WebDriver objects for each of provided mail services
    /// </summary>
    public class MailServiceBrowser
    {
        /// <summary>
        /// Dictionary for WebDriver object for available mail services
        /// </summary>
        private static Dictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>
        {
            { "GmailBrowser", null },
            { "MailruBrowser", null }
        };

        /// <summary>
        /// The logger instance of the current class
        /// </summary>
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Private constructor w\o parameters
        /// </summary>
        private MailServiceBrowser() { }


        /// <summary>
        /// Method for getting the driver instance
        /// </summary>
        /// <param name="mailServiceBrowser">Specified mail service whose driver state you want to get</param>
        /// <returns>New driver instance if called for the first time, otherwise the current state of the
        /// existing driver</returns>
        public static IWebDriver GetInstance(string mailServiceBrowser)
        {
            if (!drivers.TryGetValue(mailServiceBrowser, out var tmp))
            {
                throw new System.Exception("There is no such mail service provided");
            }

            if (drivers.TryGetValue(mailServiceBrowser, out IWebDriver driver) &&
                driver is null)
            {
                switch (TestContext.Parameters[mailServiceBrowser])
                {
                    case "Chrome":
                        _logger.Info("Running the Chrome browser");
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        drivers[mailServiceBrowser] = new ChromeDriver();
                        break;

                    case "Firefox":
                        _logger.Info("Running the Firefox browser");
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        drivers[mailServiceBrowser] = new FirefoxDriver();
                        break;

                    case "Opera":
                        _logger.Info("Running the Opera browser");
                        new WebDriverManager.DriverManager().SetUpDriver(new OperaConfig());
                        drivers[mailServiceBrowser] = new OperaDriver();
                        break;

                    default:
                        _logger.Info("The default browser is used - Chrome");
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        drivers[mailServiceBrowser] = new ChromeDriver();
                        break;
                }
            }
            drivers[mailServiceBrowser].Manage().Window.Maximize();
            return drivers[mailServiceBrowser];
        }


        /// <summary>
        /// Method for checking if driver of provided mail service exists or not
        /// </summary>
        /// <param name="mailServiceBrowser">Mail service whose driver state is getting</param>
        /// <returns>True if driver exists, else false</returns>
        public static bool IsDriverExists(string mailServiceBrowser)
        {
            return drivers[mailServiceBrowser] != null;
        }


        /// <summary>
        /// Method for closing the driver of the provided mail service
        /// </summary>
        /// <param name="mailServiceBrowser">Mail service whose driver you want to close</param>
        public static void CloseBrowser(string mailServiceBrowser)
        {
            drivers[mailServiceBrowser].Quit();
            drivers[mailServiceBrowser] = null;
        }
    }
}
