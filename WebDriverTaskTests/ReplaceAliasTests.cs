using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailRu.Helpers;
using GoogleMail.Helpers;

namespace WebDriverTaskTests
{
    [TestClass]
    public class ReplaceAliasTests
    {
        private const string MailRuUsername = "gaaasmanov@mail.ru";

        private const string MailRuAlias = "Олег";

        private const string MailRuPassword = "password1_9pass";

        private const string GmailUsername = "qwerty7312oo";

        private const string GmailPassword = "password1_8pass";

        private const string GmailUserAlias = "Антон Антонов";

        private const string MessageContent = "Hello!";

        private const string ReplyMessage = "Иван Иванов";

        private static string BaseAlias;


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GmailHelper.InitBrowser();
            GmailHelper.DoLogin(GmailUsername, GmailPassword);
            BaseAlias = GmailHelper.GetCurrentAlias();
            GmailHelper.SendMessage(MailRuUsername, MessageContent);
            

            MailRuHelper.InitBrowser();
            MailRuHelper.DoLogin(MailRuUsername, MailRuPassword);
            MailRuHelper.IsMessageCame(GmailUserAlias, MessageContent);
            MailRuHelper.SendReply(ReplyMessage);

            if (GmailHelper.IsMessageCame(MailRuAlias))
            {
                GmailHelper.ReplaceAlias(GmailHelper.GetAliasFromMessage());
            }
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            MailRuHelper.CloseBrowser();
            GmailHelper.CloseBrowser();
        }


        [TestMethod]
        public void ReplaceAlias()
        {
            bool isUpdated = GmailHelper.IsAliasUpdated(BaseAlias);
            Assert.IsTrue(isUpdated);
        }
    }
}