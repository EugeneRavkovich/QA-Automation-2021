using OpenQA.Selenium;
using GoogleMail.DriverInstance;
using GoogleMail.Pages;

namespace GoogleMail.Helpers
{
    /// <summary>
    /// A class that contains auxiliary methods based on Gmail pages
    /// </summary>
    public class GmailHelper
    {
        private static IWebDriver _driver;

        private static readonly string _baseUrl = "https:/google.com/mail";

        private static By _availableAccountsTabLocator = By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]");

        private static By _currentAliasLocator = By.XPath("//div[@class='gb_lb gb_mb']");


        /// <summary>
        /// Inits the browser
        /// </summary>
        public static void InitBrowser()
        {
            _driver = Driver.GetInstance();
            _driver.Navigate().GoToUrl(_baseUrl);
        }


        /// <summary>
        /// Closes the browser
        /// </summary>
        public static void CloseBrowser()
        {
            Driver.CloseBrowser();
        }


        /// <summary>
        /// Method for logging into the account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The page to which it transfers after the login</returns>
        public static BasePage DoLogin(string username, string password)
        {
            LoginPage lp = new LoginPage(_driver);
            lp.
                EnterUsername(username).
                ConfirmUsername().
                EnterPassword(password);
            return lp.ConfirmPassword();
        }


        /// <summary>
        /// Method for sending a message to the specified user 
        /// </summary>
        /// <param name="recipient">Recipient email</param>
        /// <param name="message">Message content</param>
        /// <returns>Current page (Inbox page)</returns>
        public static InboxPage SendMessage(string recipient, string message)
        {
            InboxPage ip = new InboxPage(_driver);
            ip.
                OpenNewMessageTab().
                EnterRecipient(recipient).
                EnterMessage(message);
            return ip.SendMessage();
        }


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public static bool IsIncorrectUsernameMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsIncorrectUsernameMessageShown();
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public static bool IsEmptyUsernameMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsEmptyUsernameMessageShown();
        }


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public static bool IsIncorrectPasswordMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsIncorrectPasswordMessageShown();
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public static bool IsEmptyPasswordMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsEmptyPasswordMessageShown();
        }


        /// <summary>
        /// Method that checks whether the message has not been read and has the correct addressee
        /// </summary>
        /// <param name="addressee">The addressee username</param>
        /// <returns>True if message hasn't been read and has the correct addressee, otherwise false</returns>
        public static bool IsCorrectMessage(string addressee)
        {
            InboxPage ip = new InboxPage(_driver);
            return ip.IsMessageNotRead() && ip.IsCorrectAddressee(addressee);
        }


        /// <summary>
        /// Method for waiting for a valid message
        /// </summary>
        /// <param name="addressee">The addressee username</param>
        /// <returns>True if such message has came, else false</returns>
        public static bool IsMessageCame(string addressee)
        {
            int waitingTime = 0;
            while (!IsCorrectMessage(addressee))
            {
                System.Threading.Thread.Sleep(5000);
                waitingTime += 5000;
                _driver.Navigate().Refresh();
                if (waitingTime >= 60000)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Method for geting the first to words from the last incomming message
        /// </summary>
        /// <returns>String[] with words</returns>
        public static string[] GetAliasFromMessage()
        {
            InboxPage ip = new InboxPage(_driver);
            ip.OpenMessage();
            var alias = ip.GetMessageContent().Split(' ');
            _driver.Navigate().Back();
            return alias;
        }


        /// <summary>
        /// Method for replacing the old alias with a new one
        /// </summary>
        /// <param name="alias">New alias for replacing</param>
        /// <returns>Current page (Account page)</returns>
        public static AccountPage ReplaceAlias(string[] alias)
        {
            InboxPage ip = new InboxPage(_driver);
            ip.OpenAvailableAccountsTab();
            AccountPage ap = ip.OpenAccountSettings();
            ap.OpenPersonalInformationTab().
                OpenChangeNameTab().
                ChangeName(alias[0]).
                ChangeSurname(alias[1]);
            return ap.ConfirmChanges();
        }


        /// <summary>
        /// Method for getting the current alias from any of gmail pages
        /// </summary>
        /// <returns>The current alias</returns>
        public static string GetCurrentAlias()
        {
            //_driver.Navigate().Refresh();
            //new WebDriverWait(_driver, System.TimeSpan.FromSeconds(15)).Until(
            //    ExpectedConditions.ElementIsVisible(_availableAccountsTabLocator));
            _driver.FindElement(_availableAccountsTabLocator).Click();
            string alias = _driver.FindElement(_currentAliasLocator).Text;
            _driver.FindElement(_availableAccountsTabLocator).Click();
            return alias;
        }


        /// <summary>
        /// Method for checking whether an alias has been updated
        /// </summary>
        /// <param name="baseAlias">Base alias before updating</param>
        /// <returns>True if updated, else false</returns>
        public static bool IsAliasUpdated(string baseAlias)
        {
            int waitingTime = 0;
            while (GetCurrentAlias() == baseAlias)
            {
                System.Threading.Thread.Sleep(5000);
                waitingTime += 5000;
                if (waitingTime >= 60000)
                {
                    return false;
                }
                _driver.Navigate().Refresh();
            }
            return true;
        }
    }
}