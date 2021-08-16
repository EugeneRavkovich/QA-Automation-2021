using NUnit.Framework;
using MailFramework.Models;

namespace MailTests
{
    [TestFixture]
    public class ReplaceAliasTests: TestsBase
    {
        private Alias baseAlias;


        [SetUp]
        public void SetUp()
        {
            gmailHelper.InitBrowser();
            gmailHelper.DoLogin(gmailUser);
            baseAlias = gmailHelper.GetCurrentAlias();
            gmailHelper.SendMessage(mailruUser, messageContent1);

            mailruHelper.InitBrowser();
            mailruHelper.DoLogin(mailruUser);
            mailruHelper.IsMessageCame(gmailUser, messageContent1);
            mailruHelper.SendReplyToTheLastIncommingLetter(replyMessage);

            gmailHelper.IsMessageCame(mailruUser);
            gmailHelper.ReplaceAlias(gmailHelper.GetAliasFromMessage());
        }


        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
            gmailHelper.ReplaceAliasBack(baseAlias);
            gmailHelper.CloseBrowser();
            mailruHelper.CloseBrowser();
        }


        [Test]
        [Category("All")]
        public void ReplaceAliasTest()
        {
            bool isUpdated = gmailHelper.IsAliasUpdated(baseAlias);
            Assert.IsTrue(isUpdated);
        } 
    }
}
