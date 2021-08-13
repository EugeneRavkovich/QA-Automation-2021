using NUnit.Framework;
using NUnit.Framework.Interfaces;
using MailFramework.MailServices.Gmail.Helpers;
using MailFramework.MailServices.MailRu.Helpers;
using MailFramework.Models;
using MailFramework.Utilities;

namespace MailTests
{
    public abstract class TestsBase
    {
        protected readonly GmailHelper gmailHelper = new GmailHelper();

        protected readonly MailruHelper mailruHelper = new MailruHelper();

        protected readonly User gmailUser = UserCreator.GmailUser();

        protected readonly User mailruUser = UserCreator.MailruUser();

        protected readonly string messageContent1 = "Hello!";

        protected readonly string messageContent2 = "asdas";

        protected readonly string replyMessage = "Даниил Данилов";
        //protected readonly string replyMessage = "Антон Антонов";

        [TearDown]
        public virtual void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == ResultState.Failure.Status)
            {
                ScreenshotMaker.MakeScreenshot(MailServiceBrowser.GetInstance("GmailBrowser"));
                ScreenshotMaker.MakeScreenshot(MailServiceBrowser.GetInstance("MailruBrowser"));
            }
        }
    }
}
