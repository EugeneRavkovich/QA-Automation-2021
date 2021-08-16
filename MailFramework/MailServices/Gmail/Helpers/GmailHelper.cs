using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using MailFramework.MailServices.Gmail.Pages;
using MailFramework.Models;
using NLog;

namespace MailFramework.MailServices.Gmail.Helpers
{
    /// <summary>
    /// A class that contains auxiliary methods based on Gmail pages
    /// </summary>
    public class GmailHelper
    {
        private IWebDriver _driver;

        private readonly string _baseUrl = "https:/google.com/mail";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly By _availableAccountsTabLocator = By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]");

        private readonly By _currentAliasLocator = By.XPath("//div[@class='gb_lb gb_mb']");


        /// <summary>
        /// Inits the browser
        /// </summary>
        public void InitBrowser()
        {
            _driver = MailServiceBrowser.GetInstance("GmailBrowser");
            _driver.Navigate().GoToUrl(_baseUrl);
        }


        /// <summary>
        /// Closes the browser
        /// </summary>
        public void CloseBrowser()
        {
            MailServiceBrowser.CloseBrowser("GmailBrowser");
        }


        /// <summary>
        /// Method for logging into the account
        /// </summary>
        /// <param name="user">User to login</param>
        /// <returns>The page to which it transfers after login</returns>
        public BasePage DoLogin(User user)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.
                EnterUsername(user.Username).
                ConfirmUsername().
                EnterPassword(user.Password);
            return loginPage.ConfirmPassword();
        }


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsIncorrectUsernameMessageShown()
        {
            LoginPage loginPage = new LoginPage(_driver);
            bool isErrorShown = loginPage.IsIncorrectUsernameMessageShown();
            if (isErrorShown)
            {
                _logger.Error("Incorrect username is entered");
            }
            return isErrorShown;
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsEmptyUsernameMessageShown()
        {
            LoginPage loginPage = new LoginPage(_driver);
            bool isErrorShown = loginPage.IsEmptyUsernameMessageShown();
            if (isErrorShown)
            {
                _logger.Error("Empty username");
            }
            return isErrorShown;
        }


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsIncorrectPasswordMessageShown()
        {
            LoginPage loginPage = new LoginPage(_driver);
            bool isErrorShown = loginPage.IsIncorrectPasswordMessageShown();
            if (isErrorShown)
            {
                _logger.Error("Incorrect password is entered");
            }
            return isErrorShown;
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsEmptyPasswordMessageShown()
        {
            LoginPage loginPage = new LoginPage(_driver);
            bool isErrorShown = loginPage.IsEmptyPasswordMessageShown();
            if (isErrorShown)
            {
                _logger.Error("Empty password");
            }
            return isErrorShown;
        }


        /// <summary>
        /// Method for sending a message to the specified user
        /// </summary>
        /// <param name="recipient">Recipient user</param>
        /// <param name="content">Message content</param>
        /// <returns>The current page (Inbox page)</returns>
        public InboxPage SendMessage(User recipient, string content)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.
                OpenNewMessageTab().
                EnterRecipient(recipient.Username).
                EnterMessage(content);
            return inboxPage.SendMessage();
        }


        /// <summary>
        /// Method for waiting for a valid message
        /// </summary>
        /// <param name="addressee">The user from whom the message is expected</param>
        /// <returns>True if such message has came, else false</returns>
        public bool IsMessageCame(User addressee)
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
        /// Method that checks whether the message has not been read and has the correct addressee
        /// </summary>
        /// <param name="addressee">Addressee user</param>
        /// <returns>True if message hasn't been read and has the correct addressee, otherwise false</returns>
        private bool IsCorrectMessage(User addressee)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            return inboxPage.IsMessageNotRead() &&
                   inboxPage.IsCorrectAddressee(addressee.Username);
        }


        /// <summary>
        /// Method for getting the first two words from the last incomming message as alias
        /// </summary>
        /// <returns>Alias object</returns>
        public Alias GetAliasFromMessage()
        {
            InboxPage inboxPage = new InboxPage(_driver);
            MessageTab messageTab = inboxPage.OpenLastIncommingMessage();
            var alias = messageTab.GetMessageContent().Split(' ');
            //_driver.Navigate().Back();
            messageTab.GetBackToTheInboxPage();
            return new Alias(alias[0], alias[1]);
        }


        /// <summary>
        /// Method for replacing the old alias with a new one
        /// </summary>
        /// <param name="alias">New alias for replacing</param>
        /// <returns>The current page (ChangeNameTab)</returns>
        public ChangeNameTab ReplaceAlias(Alias alias)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.OpenAvailableAccountsTab();
            AccountPage accountPage = inboxPage.OpenAccountSettings();
            ChangeNameTab changeNameTab = accountPage.
                OpenPersonalInformationTab().
                OpenChangeNameTab().
                ChangeName(alias.Name).
                ChangeSurname(alias.Surname);
            return changeNameTab.ConfirmChanges();
        }

         
        /// <summary>
        /// Method for replacing the new alias with old one
        /// </summary>
        /// <param name="baseAlias">Old alias for replacing</param>
        /// <returns>The current page (ChangeNameTab)</returns>
        public ChangeNameTab ReplaceAliasBack(Alias baseAlias)
        {
            ChangeNameTab changeNameTab = new ChangeNameTab(_driver);
            changeNameTab.
                ChangeName(baseAlias.Name).
                ChangeSurname(baseAlias.Surname);
            return changeNameTab.ConfirmChanges();
        }


        /// <summary>
        /// Method for getting the current alias from any of gmail pages
        /// </summary>
        /// <returns>The current alias</returns>
        public Alias GetCurrentAlias()
        {
            _driver.FindElement(_availableAccountsTabLocator).Click();
            new WebDriverWait(_driver, System.TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementIsVisible(_currentAliasLocator));
            string alias = _driver.FindElement(_currentAliasLocator).Text;
            string[] aliasParts = alias.Split(' ');
            _driver.FindElement(_availableAccountsTabLocator).Click();
            return new Alias(aliasParts[0], aliasParts[1]);
        }


        /// <summary>
        /// Method for checking whether an alias has been updated
        /// </summary>
        /// <param name="baseAlias">Alias before updating</param>
        /// <returns>True if updated, else false</returns>
        public bool IsAliasUpdated(Alias baseAlias)
        {
            int waitingTime = 0;
            while (GetCurrentAlias().Equals(baseAlias))
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
