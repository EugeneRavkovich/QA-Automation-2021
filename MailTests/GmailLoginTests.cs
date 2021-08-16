using NUnit.Framework;
using MailFramework.MailServices.Gmail.Pages;
using MailFramework.Utilities;
using System.Threading.Tasks;
using MailFramework.Models;

namespace MailTests
{
    [TestFixture]
    public class GmailLoginTests: TestsBase
    {
        [SetUp]
        public void Setup()
        {
            gmailHelper.InitBrowser();
        }


        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
            gmailHelper.CloseBrowser();
            if (MailServiceBrowser.IsDriverExists("MailruBrowser"))
            {
                mailruHelper.CloseBrowser();
            }
        } 


        [Test]
        [Category("All")]
        [Category("Smoke")]
        public void Login_CorrectCredentials()
        {
            var actualPage = gmailHelper.DoLogin(gmailUser);
            Assert.IsTrue(actualPage is InboxPage);
        }

        [Test]
        [Category("All")]
        public void Login_IncorrectUsername()
        {
            Task<bool> tryFindError = new Task<bool>(() => gmailHelper.IsIncorrectUsernameMessageShown());
            Task tryLogin = new Task(() => gmailHelper.DoLogin(UserCreator.GmailUserWithIncorrectUsername()));
            tryLogin.Start();
            tryFindError.Start();
            Assert.IsTrue(tryFindError.Result);
        }


        [Test]
        [Category("All")]
        public void Login_EmptyUsername()
        {
            Task<bool> tryFindError = new Task<bool>(() => gmailHelper.IsEmptyUsernameMessageShown());
            Task tryLogin = new Task(() => gmailHelper.DoLogin(UserCreator.GmailUserWithEmptyUsername()));
            tryLogin.Start();
            tryFindError.Start();
            Assert.IsTrue(tryFindError.Result);
        }


        [Test]
        [Category("All")]
        public void Login_IncorrectPassword()
        {
            Task<bool> tryFindError = new Task<bool>(() => gmailHelper.IsIncorrectPasswordMessageShown());
            Task tryLogin = new Task(() => gmailHelper.DoLogin(UserCreator.GmailUserWithIncorrectPassword()));
            tryLogin.Start();
            tryFindError.Start();
            Assert.IsTrue(tryFindError.Result);
        }


        [Test]
        [Category("All")]
        public void Login_EmptyPassword()
        {
            Task<bool> tryFindError = new Task<bool>(() => gmailHelper.IsEmptyPasswordMessageShown());
            Task tryLogin = new Task(() => gmailHelper.DoLogin(UserCreator.GmailUserWithEmptyPassword()));
            tryLogin.Start();
            tryFindError.Start();
            Assert.IsTrue(tryFindError.Result);
        }
    }
}