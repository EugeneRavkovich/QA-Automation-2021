using MailFramework.Models;

namespace MailFramework.Utilities
{
    public class UserCreator
    {
        private static readonly string _gmailUserName = TestDataReader.GetTestData("testdata.gmail.user.name");

        private static readonly string _gmailUserPassword = TestDataReader.GetTestData("testdata.gmail.user.password");

        private static readonly string _mailruUserName = TestDataReader.GetTestData("testdata.mailru.user.name");

        private static readonly string _mailruUserPassword = TestDataReader.GetTestData("testdata.mailru.user.password");


        public static User GmailUser()
        {
            return new User(_gmailUserName, _gmailUserPassword);
        }


        public static User GmailUserWithIncorrectUsername()
        {
            return new User(_mailruUserName, _gmailUserPassword);
        }


        public static User GmailUserWithIncorrectPassword()
        {
            return new User(_gmailUserName, _mailruUserPassword);
        }


        public static User GmailUserWithEmptyUsername()
        {
            return new User(string.Empty, _gmailUserPassword);
        }


        public static User GmailUserWithEmptyPassword()
        {
            return new User(_gmailUserName, string.Empty);
        }


        public static User MailruUser()
        {
            return new User(_mailruUserName, _mailruUserPassword);
        }        
    }
}
