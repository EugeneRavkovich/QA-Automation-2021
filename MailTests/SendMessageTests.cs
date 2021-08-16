using NUnit.Framework;

namespace MailTests
{
    [TestFixture]
    public class SendMessageTests: TestsBase
    {
        [SetUp]
        public void SetUp()
        {
            gmailHelper.InitBrowser();
            gmailHelper.DoLogin(gmailUser);
            gmailHelper.SendMessage(mailruUser, messageContent2);

            mailruHelper.InitBrowser();
            mailruHelper.DoLogin(mailruUser);
        }


        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
            //gmailHelper.CloseBrowser();
            //mailruHelper.CloseBrowser();
        }


        [Test]
        [Category("All")]
        [Category("Smoke")]
        public void IsMessageFromGmailCame()
        {
            bool isMessageCame = mailruHelper.IsMessageCame(gmailUser, messageContent2);
            Assert.IsTrue(isMessageCame);
        }
    }
}
