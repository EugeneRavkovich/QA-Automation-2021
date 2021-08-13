using OpenQA.Selenium;
using MailFramework.MailServices.MailRu.Pages;
using MailFramework.Models;

namespace MailFramework.MailServices.MailRu.Helpers
{
    public class MailruHelper
    {
        private IWebDriver _driver;

        private readonly string _baseurl = "https://account.mail.ru/login";


        public void InitBrowser()
        {
            _driver = MailServiceBrowser.GetInstance("MailruBrowser");
            _driver.Navigate().GoToUrl(_baseurl);
        }


        public void CloseBrowser()
        {
            MailServiceBrowser.CloseBrowser("MailruBrowser");
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


        public bool IsMessageCame(User addressee, string content)
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
            if (!IsCorrectContent(content))
            {
                _driver.Navigate().Back();
                IsMessageCame(addressee, content);
            }
            _driver.Navigate().Back();
            return true;
        }


        private bool IsCorrectMessage(User addressee)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            return inboxPage.IsMessageNotRead() &&
                   inboxPage.IsCorrectAddressee(addressee.Username);
        }


        private bool IsCorrectContent(string content)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.OpenLastIncommingMessage();
            return inboxPage.GetMessageContent() == content;
        }


        public void SendReplyToTheLastIncommingLetter(string content)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.
                OpenLastIncommingMessage().
                OpenReplyWindow().
                EnterReplyMessage(content).
                SendReply();
        }
    }
}
