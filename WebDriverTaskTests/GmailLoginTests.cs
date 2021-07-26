using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleMail.Helpers;
using GoogleMail.Pages;
using System.Threading.Tasks;

namespace WebDriverTaskTests
{
    [TestClass]
    public class GmailLoginTests
    {
        private const string CorrectUsername = "qwerty7312oo";
        private const string IncorrectUsername = "wqewqefsdfdsf";
        private const string CorrectPassword = "password1_8pass";
        private const string IncorrectPassword = "qwewqewqedsadada";
        


        [TestInitialize]
        public void TestInitialize()
        {
            GmailHelper.InitBrowser();
        }


        [TestCleanup]
        public void TestCleanup()
        {
            GmailHelper.CloseBrowser();
        }


        [TestMethod]
        public void Login_CorrectCredentials()
        {
            var actualPage = GmailHelper.DoLogin(CorrectUsername, CorrectPassword);
            Assert.IsTrue(actualPage is InboxPage);
        }


        [TestMethod]
        [DataRow(IncorrectUsername, CorrectPassword)]
        [DataRow("", CorrectPassword)]
        [DataRow(CorrectUsername, IncorrectPassword)]
        [DataRow(CorrectUsername, "")]
        public void Login_IncorrectUsername(string username, string password)
        {
            Assert.ThrowsException<OpenQA.Selenium.WebDriverTimeoutException>(
                () => GmailHelper.DoLogin(username, password));
        }


        //[TestMethod]
        //public void Login_WrongUsername()
        //{
        //    Task<bool> tryFindError = new Task<bool>(() => GmailHelper.IsIncorrectUsernameMessageShown());
        //    Task tryLogin = new Task(() => GmailHelper.DoLogin(IncorrectUsername, CorrectPassword));
        //    tryLogin.Start();
        //    tryFindError.Start();
        //    Assert.IsTrue(tryFindError.Result);
        //}


        //[TestMethod]
        //public void Login_EmptyUsername()
        //{
        //    Task<bool> tryFindError = new Task<bool>(() => GmailHelper.IsEmptyUsernameMessageShown());
        //    Task tryLogin = new Task(() => GmailHelper.DoLogin(string.Empty, CorrectPassword));
        //    tryLogin.Start();
        //    tryFindError.Start();
        //    Assert.IsTrue(tryFindError.Result);
        //}


        //[TestMethod]
        //public void Login_CorrectUsernameWrongPassword()
        //{
        //    Task<bool> tryFindError = new Task<bool>(() => GmailHelper.IsIncorrectPasswordMessageShown());
        //    Task tryLogin = new Task(() => GmailHelper.DoLogin(CorrectUsername, IncorrectPassword));
        //    tryLogin.Start();
        //    tryFindError.Start();
        //    Assert.IsTrue(tryFindError.Result);
        //}


        //[TestMethod]
        //public void Login_CorrectUsenameEmptyPassword()
        //{
        //    Task<bool> tryFindError = new Task<bool>(() => GmailHelper.IsEmptyPasswordMessageShown());
        //    Task tryLogin = new Task(() => GmailHelper.DoLogin(CorrectUsername, string.Empty));
        //    tryLogin.Start();
        //    tryFindError.Start();
        //    Assert.IsTrue(tryFindError.Result);
        //}
    }
}
