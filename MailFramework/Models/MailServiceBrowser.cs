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
    public class MailServiceBrowser
    {
        private static Dictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>
        {
            { "GmailBrowser", null },
            { "MailruBrowser", null }
        };

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();


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


        public static bool IsDriverExists(string mailServiceBrowser)
        {
            return drivers[mailServiceBrowser] != null;
        }


        public static void CloseBrowser(string mailServiceBrowser)
        {

            drivers[mailServiceBrowser].Quit();
            drivers[mailServiceBrowser] = null;
        }
    }
}
