using MailRu.Pages;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;
using MailRu.DriverInstance;

namespace MailRu.Helpers
{
    public class MailRuHelper
    {
        private static readonly string _baseUrl = "https://account.mail.ru/login";

        private static IWebDriver _driver;

        public static void InitBrowser()
        {
            _driver = Driver.GetInstance();
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        public static void CloseBrowser()
        {
            Driver.CloseBrowser();
        }


        public static InboxPage DoLogin(string username, string password)
        {
            LoginPage lp = new LoginPage(_driver);
            lp.OpenPage();
            lp.EnterUsername(username);
            lp.ConfirmUsername();
            lp.EnterPassword(password);
            return lp.ConfirmPassword();
        }


        public static bool IsCorrectMessage(string addressee)
        {
            InboxPage ip = new InboxPage(_driver);
            return ip.IsMessageNotRead() && ip.IsCorrectAddressee(addressee);
        }


        public static bool IsCorrectContent(string content)
        {
            InboxPage ip = new InboxPage(_driver);
            ip.OpenMessage();
            return ip.GetMessageContent() == content;
        }


        public static bool IsMessageCame(string addressee, string content)
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


        public static void SendReply(string message)
        {
            InboxPage ip = new InboxPage(_driver);
            ip.
                OpenMessage().
                OpenReplyWindow().
                EnterReplyMessage(message).
                SendReply();
        }
    }
}
