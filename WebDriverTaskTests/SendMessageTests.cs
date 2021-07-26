using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailRu.Helpers;
using GoogleMail.Helpers;

namespace WebDriverTaskTests
{
    [TestClass]
    public class SendMessageTests
    {
        private const string MailRuUsername = "gaaasmanov@mail.ru";

        private const string MailRuPassword = "password1_9pass";

        private const string GmailUsername = "qwerty7312oo";

        private const string GmailPassword = "password1_8pass";

        private const string GmailUserAlias = "Антон Антонов";

        private const string MessageContent = "Hello! World!";



        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GmailHelper.InitBrowser();
            GmailHelper.DoLogin(GmailUsername, GmailPassword);
            GmailHelper.SendMessage(MailRuUsername, MessageContent);

            MailRuHelper.InitBrowser();
            MailRuHelper.DoLogin(MailRuUsername, MailRuPassword);
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            MailRuHelper.CloseBrowser();
            GmailHelper.CloseBrowser();
        }


        [TestMethod]
        public void IsCorrectMessage()
        {
            bool isMessageCame = MailRuHelper.IsMessageCame(GmailUserAlias, MessageContent);
            Assert.IsTrue(isMessageCame);
        }
    }
}
