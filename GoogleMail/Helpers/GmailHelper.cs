using OpenQA.Selenium;
using GoogleMail.DriverInstance;
using GoogleMail.Pages;
using OpenQA.Selenium.Support.UI;

namespace GoogleMail.Helpers
{
    public class GmailHelper
    {
        private static IWebDriver _driver;

        private static readonly string _baseUrl = "https:/google.com/mail";

        private static By _availableAccountsTabLocator = By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]");

        private static By _currentAliasLocator = By.XPath("//div[@class='gb_lb gb_mb']");


        public static void InitBrowser()
        {
            _driver = Driver.GetInstance();
            _driver.Navigate().GoToUrl(_baseUrl);
        }


        public static void CloseBrowser()
        {
            Driver.CloseBrowser();
        }


        public static BasePage DoLogin(string username, string password)
        {
            LoginPage lp = new LoginPage(_driver);
            lp.
                EnterUsername(username).
                ConfirmUsername().
                EnterPassword(password);
            return lp.ConfirmPassword();
        }


        public static InboxPage SendMessage(string recipient, string message)
        {
            InboxPage ip = new InboxPage(_driver);
            ip.
                OpenNewMessageTab().
                EnterRecipient(recipient).
                EnterMessage(message);
            return ip.SendMessage();
        }


        public static bool IsIncorrectUsernameMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsIncorrectUsernameMessageShown();
        }


        public static bool IsEmptyUsernameMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsEmptyUsernameMessageShown();
        }


        public static bool IsIncorrectPasswordMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsIncorrectPasswordMessageShown();
        }


        public static bool IsEmptyPasswordMessageShown()
        {
            LoginPage lp = new LoginPage(_driver);
            return lp.IsEmptyPasswordMessageShown();
        }


        public static bool IsCorrectMessage(string addressee)
        {
            InboxPage ip = new InboxPage(_driver);
            return ip.IsMessageNotRead() && ip.IsCorrectAddressee(addressee);
        }


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


        public static string[] GetAliasFromMessage()
        {
            InboxPage ip = new InboxPage(_driver);
            ip.OpenMessage();
            var alias = ip.GetMessageContent().Split(' ');
            _driver.Navigate().Back();
            return alias;
        }


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