using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using MailFramework.MailServices.Gmail.Pages;
using MailFramework.Models;
using NLog;

namespace MailFramework.MailServices.Gmail.Helpers
{
    public class GmailHelper
    {
        private IWebDriver _driver;

        private readonly string _baseUrl = "https:/google.com/mail";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly By _availableAccountsTabLocator = By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]");

        private readonly By _currentAliasLocator = By.XPath("//div[@class='gb_lb gb_mb']");


        public void InitBrowser()
        {
            _driver = MailServiceBrowser.GetInstance("GmailBrowser");
            _driver.Navigate().GoToUrl(_baseUrl);
        }


        public void CloseBrowser()
        {
            MailServiceBrowser.CloseBrowser("GmailBrowser");
        }


        public BasePage DoLogin(User user)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.
                EnterUsername(user.Username).
                ConfirmUsername().
                EnterPassword(user.Password);
            return loginPage.ConfirmPassword();
        }


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


        public InboxPage SendMessage(User recipient, string content)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.
                OpenNewMessageTab().
                EnterRecipient(recipient.Username).
                EnterMessage(content);
            return inboxPage.SendMessage();
        }


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


        private bool IsCorrectMessage(User addressee)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            return inboxPage.IsMessageNotRead() &&
                   inboxPage.IsCorrectAddressee(addressee.Username);
        }


        public Alias GetAliasFromMessage()
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.OpenLastIncommingMessage();
            var alias = inboxPage.GetMessageContent().Split(' ');
            _driver.Navigate().Back();
            return new Alias(alias[0], alias[1]);
        }


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

         
        public ChangeNameTab ReplaceAliasBack(Alias baseAlias)
        {
            ChangeNameTab changeNameTab = new ChangeNameTab(_driver);
            changeNameTab.
                ChangeName(baseAlias.Name).
                ChangeSurname(baseAlias.Surname);
            return changeNameTab.ConfirmChanges();
        }


        public Alias GetCurrentAlias()
        {
            _driver.FindElement(_availableAccountsTabLocator).Click();
            new WebDriverWait(_driver, System.TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementIsVisible(_currentAliasLocator));
            string alias = _driver.FindElement(_currentAliasLocator).Text;
            string[] aliasParts = alias.Split(' ');
            _driver.FindElement(_availableAccountsTabLocator).Click();
            return new Alias(aliasParts[0], aliasParts[1]);
        }


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
