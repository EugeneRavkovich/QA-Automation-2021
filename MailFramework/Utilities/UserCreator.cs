using MailFramework.Models;

namespace MailFramework.Utilities
{
    /// <summary>
    /// A class that defines an UserCreator entity
    /// </summary>
    public class UserCreator
    {
        private static readonly string _gmailUserName = TestDataReader.GetTestData("testdata.gmail.user.name");

        private static readonly string _gmailUserPassword = TestDataReader.GetTestData("testdata.gmail.user.password");

        private static readonly string _mailruUserName = TestDataReader.GetTestData("testdata.mailru.user.name");

        private static readonly string _mailruUserPassword = TestDataReader.GetTestData("testdata.mailru.user.password");


        /// <summary>
        /// Method that returns a gmail user with correct credentials
        /// </summary>
        /// <returns>User object</returns>
        public static User GmailUser()
        {
            return new User(_gmailUserName, _gmailUserPassword);
        }


        /// <summary>
        /// Method that returns a gmail user with incorrect username
        /// </summary>
        /// <returns>User object</returns>
        public static User GmailUserWithIncorrectUsername()
        {
            return new User(_mailruUserName, _gmailUserPassword);
        }


        /// <summary>
        /// Method that returns a gmail user with incorrect password
        /// </summary>
        /// <returns>User object</returns>
        public static User GmailUserWithIncorrectPassword()
        {
            return new User(_gmailUserName, _mailruUserPassword);
        }


        /// <summary>
        /// Method that returns a gmail user without username
        /// </summary>
        /// <returns>User object</returns>
        public static User GmailUserWithEmptyUsername()
        {
            return new User(string.Empty, _gmailUserPassword);
        }


        /// <summary>
        /// Method that returns a gmail user without password
        /// </summary>
        /// <returns>User object</returns>
        public static User GmailUserWithEmptyPassword()
        {
            return new User(_gmailUserName, string.Empty);
        }


        /// <summary>
        /// Method that returns a mailru user with correct credentials
        /// </summary>
        /// <returns>User object</returns>
        public static User MailruUser()
        {
            return new User(_mailruUserName, _mailruUserPassword);
        }        
    }
}
